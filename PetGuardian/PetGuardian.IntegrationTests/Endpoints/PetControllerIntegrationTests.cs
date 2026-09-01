using System.Net;
using System.Net.Http.Json;
using PetGuardian.Application.DTOs;
using PetGuardian.Domain.Enums;
using PetGuardian.IntegrationTests.Fixtures;
using Xunit;

namespace PetGuardian.IntegrationTests.Endpoints;

[Collection(IntegrationTestCollection.Name)]
public class PetControllerIntegrationTests(CustomWebApplicationFactory factory)
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task CrudCompleto_Pet_DeveExecutarTodasOperacoesComSucesso()
    {
        // 1. Obter uma raça existente
        var racasResponse = await _client.GetFromJsonAsync<List<RacaResponse>>("/api/raca");
        Assert.NotNull(racasResponse);
        Assert.NotEmpty(racasResponse);
        var racaId = racasResponse.First().Id;

        // 2. CREATE (POST)
        var createRequest = new PetRequest(
            Nome: "Totó",
            DataNascimento: DateTime.UtcNow.AddYears(-2),
            Sexo: SexoPet.Macho,
            Porte: PortePet.Medio,
            Castrado: false,
            RacaId: racaId
        );

        var postResponse = await _client.PostAsJsonAsync("/api/pet", createRequest);
        Assert.Equal(HttpStatusCode.Created, postResponse.StatusCode);
        var petCriado = await postResponse.Content.ReadFromJsonAsync<PetResponse>();
        Assert.NotNull(petCriado);
        Assert.Equal("Totó", petCriado.Nome);

        // 3. READ (GET BY ID)
        var getByIdResponse = await _client.GetAsync($"/api/pet/{petCriado.Id}");
        Assert.Equal(HttpStatusCode.OK, getByIdResponse.StatusCode);
        var petLido = await getByIdResponse.Content.ReadFromJsonAsync<PetResponse>();
        Assert.NotNull(petLido);
        Assert.Equal(petCriado.Id, petLido.Id);

        // 4. UPDATE (PUT)
        var updateRequest = new PetRequest(
            Nome: "Totó Atualizado",
            DataNascimento: DateTime.UtcNow.AddYears(-2),
            Sexo: SexoPet.Macho,
            Porte: PortePet.Grande,
            Castrado: true,
            RacaId: racaId
        );

        var putResponse = await _client.PutAsJsonAsync($"/api/pet/{petCriado.Id}", updateRequest);
        Assert.Equal(HttpStatusCode.OK, putResponse.StatusCode);
        var petAtualizado = await putResponse.Content.ReadFromJsonAsync<PetResponse>();
        Assert.NotNull(petAtualizado);
        Assert.Equal("Totó Atualizado", petAtualizado.Nome);
        Assert.True(petAtualizado.Castrado);

        // 5. GET HISTORICO
        var historicoResponse = await _client.GetAsync($"/api/pet/{petCriado.Id}/historico");
        Assert.Equal(HttpStatusCode.OK, historicoResponse.StatusCode);

        // 6. DELETE
        var deleteResponse = await _client.DeleteAsync($"/api/pet/{petCriado.Id}");
        Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);

        // 7. VERIFICAR QUE NÃO EXISTE MAIS
        var getAposDeleteResponse = await _client.GetAsync($"/api/pet/{petCriado.Id}");
        Assert.Equal(HttpStatusCode.NotFound, getAposDeleteResponse.StatusCode);
    }

    [Fact]
    public async Task Create_PayloadInvalido_DeveRetornar400BadRequest()
    {
        // Arrange
        var requestInvalido = new
        {
            Nome = "", // Inválido
            RacaId = Guid.Empty
        };

        // Act
        var response = await _client.PostAsJsonAsync("/api/pet", requestInvalido);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}
