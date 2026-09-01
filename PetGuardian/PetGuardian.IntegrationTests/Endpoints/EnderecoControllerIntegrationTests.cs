using System.Net;
using System.Net.Http.Json;
using PetGuardian.Application.DTOs;
using PetGuardian.IntegrationTests.Fixtures;
using Xunit;

namespace PetGuardian.IntegrationTests.Endpoints;

[Collection(IntegrationTestCollection.Name)]
public class EnderecoControllerIntegrationTests(CustomWebApplicationFactory factory)
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task Create_EnderecoComViaCepResolvido_DeveCriarERetornar201()
    {
        // Arrange
        var request = new EnderecoRequest("01001-000", "50");

        // Act
        var response = await _client.PostAsJsonAsync("/api/endereco", request);

        // Assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        var endereco = await response.Content.ReadFromJsonAsync<EnderecoResponse>();
        Assert.NotNull(endereco);
        Assert.Equal("01001000", endereco.Cep);
        Assert.Equal("50", endereco.Numero);
        Assert.Equal("Praça da Sé", endereco.Rua);
        Assert.NotEqual(Guid.Empty, endereco.BairroId);

        // Update (PUT)
        var putResponse = await _client.PutAsJsonAsync($"/api/endereco/{endereco.Id}", new EnderecoRequest("01001-000", "55"));
        Assert.Equal(HttpStatusCode.OK, putResponse.StatusCode);
        var enderecoAtualizado = await putResponse.Content.ReadFromJsonAsync<EnderecoResponse>();
        Assert.NotNull(enderecoAtualizado);
        Assert.Equal("55", enderecoAtualizado.Numero);
    }
}
