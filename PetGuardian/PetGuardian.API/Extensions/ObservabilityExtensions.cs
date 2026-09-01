using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using PetGuardian.API.Health;
using PetGuardian.API.HealthChecks;
using PetGuardian.API.Middleware;
using PetGuardian.Infrastructure.Persistence;

namespace PetGuardian.API.Extensions;

/// <summary>
/// Concentra a configuração de Monitoramento e Observabilidade pedida pelo enunciado:
/// Health Checks, Distributed Tracing e Métricas via OpenTelemetry.
/// (O logging estruturado com Serilog é configurado separadamente em Program.cs, antes do WebApplication.CreateBuilder,
/// pois precisa ser plugado no host builder.)
/// </summary>
public static class ObservabilityExtensions
{
    private const string ServiceName = "PetGuardian.API";

    public static IServiceCollection AddPetGuardianObservability(
        this IServiceCollection services, IConfiguration configuration)
    {
        // ----- Health Checks (Microsoft.Extensions.Diagnostics.HealthChecks, já vem no SDK Web) -----
        services.AddHttpClient("ViaCepHealthCheck", client =>
        {
            client.Timeout = TimeSpan.FromSeconds(5);
        });

        services.AddHealthChecks()
            .AddCheck<OracleDbHealthCheck>(
                "oracle-database",
                tags: ["ready", "db"])
            .AddCheck<ViaCepHealthCheck>(
                "external-service-viacep",
                tags: ["ready", "external"]);

        // ----- OpenTelemetry: Tracing + Métricas -----
        services.AddOpenTelemetry()
            .ConfigureResource(resource => resource.AddService(ServiceName))
            .WithTracing(tracing => tracing
                .AddAspNetCoreInstrumentation()
                .AddHttpClientInstrumentation()
                .AddConsoleExporter())
            .WithMetrics(metrics => metrics
                .AddAspNetCoreInstrumentation()
                .AddHttpClientInstrumentation()
                .AddRuntimeInstrumentation()
                .AddMeter(RequestMetricsMiddleware.Meter.Name)
                .AddConsoleExporter());

        return services;
    }

    public static WebApplication UsePetGuardianObservability(this WebApplication app)
    {
        app.UseMiddleware<CorrelationIdMiddleware>();
        app.UseMiddleware<RequestMetricsMiddleware>();

        // /health -> visão geral (usada por orquestradores simples)
        app.MapHealthChecks("/health", new HealthCheckOptions
        {
            ResponseWriter = HealthCheckResponseWriter.WriteJsonResponse
        });

        // /health/ready -> só os checks marcados como "ready" (banco + serviços externos)
        app.MapHealthChecks("/health/ready", new HealthCheckOptions
        {
            Predicate = check => check.Tags.Contains("ready"),
            ResponseWriter = HealthCheckResponseWriter.WriteJsonResponse
        });

        // /health/live -> liveness simples, sem dependências externas
        app.MapHealthChecks("/health/live", new HealthCheckOptions
        {
            Predicate = _ => false,
            ResponseWriter = HealthCheckResponseWriter.WriteJsonResponse
        });

        return app;
    }
}