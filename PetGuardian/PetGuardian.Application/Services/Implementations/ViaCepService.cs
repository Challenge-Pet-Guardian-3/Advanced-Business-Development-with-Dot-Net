using System.Net.Http.Json;
using PetGuardian.Application.Services.Interfaces;

namespace PetGuardian.Application.Services.Implementations;

/// <summary>
/// Implementação assíncrona desacoplada para consulta de endereços na API ViaCEP.
/// </summary>
public sealed class ViaCepService(HttpClient httpClient) : IViaCepService
{
    public async Task<ViaCepResponseDto?> ConsultarCepAsync(string cep, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(cep))
            return null;

        var cepLimpo = cep.Trim().Replace("-", "").Replace(".", "");
        if (cepLimpo.Length != 8 || !cepLimpo.All(char.IsDigit))
            return null;

        var url = $"https://viacep.com.br/ws/{cepLimpo}/json/";

        try
        {
            var response = await httpClient.GetFromJsonAsync<ViaCepResponseDto>(url, cancellationToken);
            if (response == null || response.PossuiErro)
                return null;

            return response;
        }
        catch (HttpRequestException)
        {
            return null;
        }
        catch (TaskCanceledException)
        {
            return null;
        }
    }
}
