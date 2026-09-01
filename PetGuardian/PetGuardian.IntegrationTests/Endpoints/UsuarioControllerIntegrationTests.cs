using System.Net;
using System.Net.Http.Json;
using PetGuardian.Application.DTOs;
using PetGuardian.Domain.Enums;
using PetGuardian.IntegrationTests.Fixtures;
using Xunit;

namespace PetGuardian.IntegrationTests.Endpoints;

[Collection(IntegrationTestCollection.Name)]
public class UsuarioControllerIntegrationTests(CustomWebApplicationFactory factory)
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task CrudCompleto_Usuario_DeveExecutarComSucesso()
    {
        // 1. Obter ou criar telefone
        var telPost = await _client.PostAsJsonAsync("/api/telefone", new TelefoneRequest("11", "987654321"));
        Assert.Equal(HttpStatusCode.Created, telPost.StatusCode);
        var tel = await telPost.Content.ReadFromJsonAsync<TelefoneResponse>();
        Assert.NotNull(tel);

        var emailUnico = $"usuario_{Guid.NewGuid():N}@teste.com";

        // 2. CREATE (POST)
        var createRequest = new UsuarioRequest(
            Nome: "Fernanda Lima",
            Email: emailUnico,
            Senha: "senhaSegura123",
            Role: RoleUsuario.Comum,
            TelefoneId: tel.Id
        );

        var postResponse = await _client.PostAsJsonAsync("/api/usuario", createRequest);
        Assert.Equal(HttpStatusCode.Created, postResponse.StatusCode);
        var usuarioCriado = await postResponse.Content.ReadFromJsonAsync<UsuarioResponse>();
        Assert.NotNull(usuarioCriado);
        Assert.Equal("Fernanda Lima", usuarioCriado.Nome);

        // 3. READ BY ID
        var getByIdResponse = await _client.GetAsync($"/api/usuario/{usuarioCriado.Id}");
        Assert.Equal(HttpStatusCode.OK, getByIdResponse.StatusCode);

        // 4. READ BY EMAIL
        var getByEmailResponse = await _client.GetAsync($"/api/usuario/by-email?email={emailUnico}");
        Assert.Equal(HttpStatusCode.OK, getByEmailResponse.StatusCode);

        // 5. SCORE
        var scoreResponse = await _client.GetAsync($"/api/usuario/{usuarioCriado.Id}/score");
        Assert.Equal(HttpStatusCode.OK, scoreResponse.StatusCode);

        // 6. UPDATE (PUT)
        var updateRequest = new UsuarioUpdateRequest(
            Nome: "Fernanda Lima Silva",
            Email: emailUnico,
            Senha: "novaSenhaSegura456",
            Role: RoleUsuario.Premium
        );

        var putResponse = await _client.PutAsJsonAsync($"/api/usuario/{usuarioCriado.Id}", updateRequest);
        Assert.Equal(HttpStatusCode.OK, putResponse.StatusCode);
        var usuarioAtualizado = await putResponse.Content.ReadFromJsonAsync<UsuarioResponse>();
        Assert.NotNull(usuarioAtualizado);
        Assert.Equal("Fernanda Lima Silva", usuarioAtualizado.Nome);
        Assert.Equal(RoleUsuario.Premium, usuarioAtualizado.Role);

        // 7. DELETE
        var deleteResponse = await _client.DeleteAsync($"/api/usuario/{usuarioCriado.Id}");
        Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);
    }
}
