using System.Net;
using System.Net.Http.Json;
using PetGuardian.Application.DTOs;
using PetGuardian.Domain.Enums;
using PetGuardian.IntegrationTests.Fixtures;
using Xunit;

namespace PetGuardian.IntegrationTests.Endpoints;

[Collection(IntegrationTestCollection.Name)]
public class GamificacaoIntegrationTests(CustomWebApplicationFactory factory)
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task FluxoCompleto_TrilhaModuloAula_DeveFuncionarComSucesso()
    {
        // 1. Criar Pet
        var racas = await _client.GetFromJsonAsync<List<RacaResponse>>("/api/raca");
        var petPost = await _client.PostAsJsonAsync("/api/pet", new PetRequest("Pipoca", DateTime.UtcNow.AddYears(-1), SexoPet.Macho, PortePet.Pequeno, false, racas!.First().Id));
        var pet = await petPost.Content.ReadFromJsonAsync<PetResponse>();

        // 2. CREATE TRILHA (POST)
        var trilhaPost = await _client.PostAsJsonAsync("/api/trilha", new TrilhaRequest("Trilha de Filhote", "Descricao Trilha", pet!.Id));
        Assert.Equal(HttpStatusCode.Created, trilhaPost.StatusCode);
        var trilha = await trilhaPost.Content.ReadFromJsonAsync<TrilhaResponse>();
        Assert.NotNull(trilha);

        // 3. UPDATE TRILHA (PUT)
        var trilhaPut = await _client.PutAsJsonAsync($"/api/trilha/{trilha.Id}", new TrilhaUpdateRequest("Trilha Filhote Pro", "Nova Desc"));
        Assert.Equal(HttpStatusCode.OK, trilhaPut.StatusCode);

        // 4. CREATE MODULO (POST)
        var moduloPost = await _client.PostAsJsonAsync("/api/modulo", new ModuloRequest("Módulo 1: Adaptação", "1 hora", "Boas práticas", trilha.Id));
        Assert.Equal(HttpStatusCode.Created, moduloPost.StatusCode);
        var modulo = await moduloPost.Content.ReadFromJsonAsync<ModuloResponse>();
        Assert.NotNull(modulo);

        // 5. UPDATE MODULO (PUT)
        var moduloPut = await _client.PutAsJsonAsync($"/api/modulo/{modulo.Id}", new ModuloUpdateRequest("Módulo 1: Adaptação Avançada", "2 horas", "Nova Desc Modulo"));
        Assert.Equal(HttpStatusCode.OK, moduloPut.StatusCode);

        // 6. CREATE AULA (POST)
        var aulaPost = await _client.PostAsJsonAsync("/api/aula", new AulaRequest("Aula 1.1: Chegada", "Como receber o pet", 20, "Facil", "Conteudo explicativo", false, modulo.Id));
        Assert.Equal(HttpStatusCode.Created, aulaPost.StatusCode);
        var aula = await aulaPost.Content.ReadFromJsonAsync<AulaResponse>();
        Assert.NotNull(aula);

        // 7. UPDATE AULA (PUT)
        var aulaPut = await _client.PutAsJsonAsync($"/api/aula/{aula.Id}", new AulaUpdateRequest("Aula 1.1: Chegada em Casa", "Descricao refinada", 25, "Facil", "Conteudo atualizado", true));
        Assert.Equal(HttpStatusCode.OK, aulaPut.StatusCode);
        var aulaAtualizada = await aulaPut.Content.ReadFromJsonAsync<AulaResponse>();
        Assert.NotNull(aulaAtualizada);
        Assert.True(aulaAtualizada.Concluida);

        // 8. HISTORICO
        var histPost = await _client.PostAsJsonAsync("/api/historico", new HistoricoRequest("MARCO_ALCANCADO", DateTime.UtcNow, pet.Id));
        Assert.Equal(HttpStatusCode.Created, histPost.StatusCode);
        var hist = await histPost.Content.ReadFromJsonAsync<HistoricoResponse>();
        Assert.NotNull(hist);

        // 9. UPDATE HISTORICO (PUT)
        var histPut = await _client.PutAsJsonAsync($"/api/historico/{hist.Id}", new HistoricoUpdateRequest("MARCO_CONCLUIDO", DateTime.UtcNow));
        Assert.Equal(HttpStatusCode.OK, histPut.StatusCode);
    }
}
