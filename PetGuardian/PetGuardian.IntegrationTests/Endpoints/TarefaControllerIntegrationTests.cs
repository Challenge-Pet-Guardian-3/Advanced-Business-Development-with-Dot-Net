using System.Net;
using System.Net.Http.Json;
using PetGuardian.Application.DTOs;
using PetGuardian.Domain.Enums;
using PetGuardian.IntegrationTests.Fixtures;
using Xunit;

namespace PetGuardian.IntegrationTests.Endpoints;

[Collection(IntegrationTestCollection.Name)]
public class TarefaControllerIntegrationTests(CustomWebApplicationFactory factory)
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task FluxoCompleto_Tarefa_CriacaoEdicaoEConclusao_DeveFuncionar()
    {
        // 1. Criar pet e usuário com vínculo
        var racas = await _client.GetFromJsonAsync<List<RacaResponse>>("/api/raca");
        var racaId = racas!.First().Id;

        var petPost = await _client.PostAsJsonAsync("/api/pet", new PetRequest("Mel", DateTime.UtcNow.AddYears(-1), SexoPet.Femea, PortePet.Pequeno, false, racaId));
        var pet = await petPost.Content.ReadFromJsonAsync<PetResponse>();

        var telPost = await _client.PostAsJsonAsync("/api/telefone", new TelefoneRequest("11", "988887777"));
        var tel = await telPost.Content.ReadFromJsonAsync<TelefoneResponse>();

        var userPost = await _client.PostAsJsonAsync("/api/usuario", new UsuarioRequest("Guilherme", $"gui_{Guid.NewGuid():N}@teste.com", "senha123", RoleUsuario.Comum, tel!.Id));
        var user = await userPost.Content.ReadFromJsonAsync<UsuarioResponse>();

        // Vincular usuário ao pet como cuidador
        var vinculoPost = await _client.PostAsJsonAsync("/api/usuariopet", new UsuarioPetRequest(user!.Id, pet!.Id, ResponPrinc: true));
        Assert.Equal(HttpStatusCode.Created, vinculoPost.StatusCode);

        // 2. CREATE TAREFA (POST)
        var tarefaRequest = new TarefaRequest(
            Titulo: "Dar Ração Especial",
            PontosTarefa: 25,
            Descricao: "Ração hipoalergênica 100g",
            Prazo: DateTime.UtcNow.AddDays(1),
            PetId: pet.Id,
            UsuarioId: user.Id
        );

        var tarefaPost = await _client.PostAsJsonAsync("/api/tarefa", tarefaRequest);
        Assert.Equal(HttpStatusCode.Created, tarefaPost.StatusCode);
        var tarefa = await tarefaPost.Content.ReadFromJsonAsync<TarefaResponse>();
        Assert.NotNull(tarefa);
        Assert.Equal("Dar Ração Especial", tarefa.Titulo);

        // 3. UPDATE TAREFA (PUT)
        var updateRequest = new TarefaUpdateRequest(
            Titulo: "Dar Ração Especial 150g",
            PontosTarefa: 30,
            Descricao: "Aumentar dose para 150g",
            Prazo: DateTime.UtcNow.AddDays(2)
        );

        var putResponse = await _client.PutAsJsonAsync($"/api/tarefa/{tarefa.Id}", updateRequest);
        Assert.Equal(HttpStatusCode.OK, putResponse.StatusCode);
        var tarefaAtualizada = await putResponse.Content.ReadFromJsonAsync<TarefaResponse>();
        Assert.NotNull(tarefaAtualizada);
        Assert.Equal("Dar Ração Especial 150g", tarefaAtualizada.Titulo);
        Assert.Equal(30, tarefaAtualizada.PontosTarefa);

        // 4. CONCLUIR TAREFA (POST)
        var concluirRequest = new TarefaConcluirRequest(user.Id);
        var concluirResponse = await _client.PostAsJsonAsync($"/api/tarefa/{tarefa.Id}/concluir", concluirRequest);
        Assert.Equal(HttpStatusCode.OK, concluirResponse.StatusCode);
        var tarefaConcluida = await concluirResponse.Content.ReadFromJsonAsync<TarefaResponse>();
        Assert.NotNull(tarefaConcluida);
        Assert.NotNull(tarefaConcluida.Conclusao);

        // 5. DELETE TAREFA
        var deleteResponse = await _client.DeleteAsync($"/api/tarefa/{tarefa.Id}");
        Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);
    }
}
