using System.Net;
using System.Net.Http.Json;
using PetGuardian.Application.DTOs;
using PetGuardian.Domain.Enums;
using PetGuardian.IntegrationTests.Fixtures;
using Xunit;

namespace PetGuardian.IntegrationTests.Endpoints;

[Collection(IntegrationTestCollection.Name)]
public class UsuarioPetControllerIntegrationTests(CustomWebApplicationFactory factory)
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task FluxoCompleto_RedeDeCuidadoEUpdateResponsabilidade_DeveFuncionarComSucesso()
    {
        // 1. Criar Pet
        var racas = await _client.GetFromJsonAsync<List<RacaResponse>>("/api/raca");
        var petPost = await _client.PostAsJsonAsync("/api/pet", new PetRequest("Max", DateTime.UtcNow.AddYears(-2), SexoPet.Macho, PortePet.Grande, false, racas!.First().Id));
        var pet = await petPost.Content.ReadFromJsonAsync<PetResponse>();

        // 2. Criar 2 Usuários
        var tel1 = await (await _client.PostAsJsonAsync("/api/telefone", new TelefoneRequest("11", "911112222"))).Content.ReadFromJsonAsync<TelefoneResponse>();
        var user1Post = await _client.PostAsJsonAsync("/api/usuario", new UsuarioRequest("Tutor Principal", $"tutor1_{Guid.NewGuid():N}@teste.com", "senha123", RoleUsuario.Comum, tel1!.Id));
        var user1 = await user1Post.Content.ReadFromJsonAsync<UsuarioResponse>();

        var tel2 = await (await _client.PostAsJsonAsync("/api/telefone", new TelefoneRequest("11", "933334444"))).Content.ReadFromJsonAsync<TelefoneResponse>();
        var user2Post = await _client.PostAsJsonAsync("/api/usuario", new UsuarioRequest("Co Cuidador", $"tutor2_{Guid.NewGuid():N}@teste.com", "senha123", RoleUsuario.Comum, tel2!.Id));
        var user2 = await user2Post.Content.ReadFromJsonAsync<UsuarioResponse>();

        // 3. Vincular user1 como responsável principal
        var vinculo1Post = await _client.PostAsJsonAsync("/api/usuariopet", new UsuarioPetRequest(user1!.Id, pet!.Id, ResponPrinc: true));
        Assert.Equal(HttpStatusCode.Created, vinculo1Post.StatusCode);

        // 4. Convidar user2 via invite by usuario (feita pelo user1)
        var invitePost = await _client.PostAsJsonAsync("/api/usuariopet/invite/by-usuario", new UsuarioPetInviteByUsuarioRequest(user1.Id, user2!.Id, pet.Id));
        Assert.Equal(HttpStatusCode.Created, invitePost.StatusCode);

        // 5. Consultar Rede de Cuidado do user1
        var redeResponse = await _client.GetAsync($"/api/usuariopet/rede-cuidado/{user1.Id}");
        Assert.Equal(HttpStatusCode.OK, redeResponse.StatusCode);
        var rede = await redeResponse.Content.ReadFromJsonAsync<RedeCuidadoResponse>();
        Assert.NotNull(rede);
        Assert.NotEmpty(rede.Pets);
        Assert.NotEmpty(rede.CoCuidadores);

        // 6. UPDATE: Alternar responsabilidade principal (PUT)
        // Primeiro promove user2 ou altera flag
        var putResponse = await _client.PutAsJsonAsync($"/api/usuariopet/{user2.Id}/{pet.Id}", new UsuarioPetUpdateRequest(ResponPrinc: false));
        Assert.Equal(HttpStatusCode.OK, putResponse.StatusCode);

        // 7. DELETE: Desvincular co-cuidador
        var deleteResponse = await _client.DeleteAsync($"/api/usuariopet/{user2.Id}/{pet.Id}");
        Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);
    }
}
