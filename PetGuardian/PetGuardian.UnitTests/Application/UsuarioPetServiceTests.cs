using Microsoft.Extensions.Logging;
using Moq;
using PetGuardian.Application.DTOs;
using PetGuardian.Application.Repositories;
using PetGuardian.Application.Services.Implementations;
using PetGuardian.Domain.Entities;
using PetGuardian.Domain.Enums;
using PetGuardian.UnitTests.Fixtures;
using Xunit;

namespace PetGuardian.UnitTests.Application;

[Collection(UnitTestCollection.Name)]
public class UsuarioPetServiceTests
{
    private readonly Mock<IUsuarioPetRepository> _usuarioPetRepoMock = new();
    private readonly Mock<IUsuarioRepository> _usuarioRepoMock = new();
    private readonly Mock<IPetRepository> _petRepoMock = new();
    private readonly Mock<ITarefaRepository> _tarefaRepoMock = new();
    private readonly Mock<IHistoricoRepository> _historicoRepoMock = new();
    private readonly Mock<ILogger<UsuarioPetService>> _loggerMock = new();

    private UsuarioPetService CreateService() =>
        new(_usuarioPetRepoMock.Object,
            _usuarioRepoMock.Object,
            _petRepoMock.Object,
            _tarefaRepoMock.Object,
            _historicoRepoMock.Object,
            _loggerMock.Object);

    [Fact]
    public void InviteByUsuario_AdminValidoEConvidadoNaoVinculado_DeveCriarVinculoComoCoCuidador()
    {
        // Arrange
        var service = CreateService();
        var adminId = Guid.NewGuid();
        var convidadoId = Guid.NewGuid();
        var petId = Guid.NewGuid();

        var adminVinculo = new UsuarioPet(adminId, petId, responPrinc: true);
        var request = new UsuarioPetInviteByUsuarioRequest(adminId, convidadoId, petId);

        _usuarioRepoMock.Setup(r => r.ExistsById(adminId)).Returns(true);
        _petRepoMock.Setup(r => r.ExistsById(petId)).Returns(true);
        _usuarioRepoMock.Setup(r => r.ExistsById(convidadoId)).Returns(true);
        _usuarioPetRepoMock.Setup(r => r.GetByUsuarioAndPet(adminId, petId)).Returns(adminVinculo);
        _usuarioPetRepoMock.Setup(r => r.Exists(convidadoId, petId)).Returns(false);
        _usuarioPetRepoMock.Setup(r => r.Add(It.IsAny<UsuarioPet>())).Returns<UsuarioPet>(v => v);

        // Act
        var result = service.InviteByUsuario(request);

        // Assert
        Assert.NotNull(result);
        Assert.False(result.ResponPrinc); // Convidado nasce como co-cuidador
        _usuarioPetRepoMock.Verify(r => r.Add(It.Is<UsuarioPet>(v => v.UsuarioId == convidadoId && !v.ResponPrinc)), Times.Once);
    }

    [Fact]
    public void Update_RemoverUnicoResponsavelPrincipal_DeveLancarInvalidOperationException()
    {
        // Arrange
        var service = CreateService();
        var usuarioId = Guid.NewGuid();
        var petId = Guid.NewGuid();
        var vinculo = new UsuarioPet(usuarioId, petId, responPrinc: true);
        var request = new UsuarioPetUpdateRequest(ResponPrinc: false);

        _usuarioPetRepoMock.Setup(r => r.GetByUsuarioAndPet(usuarioId, petId)).Returns(vinculo);
        _usuarioPetRepoMock.Setup(r => r.GetByPetId(petId)).Returns([vinculo]);

        // Act & Assert
        var ex = Assert.Throws<InvalidOperationException>(() => service.Update(usuarioId, petId, request));
        Assert.Contains("Não é permitido remover o único responsável principal", ex.Message);
    }

    [Fact]
    public void GetRedeCuidadoByUsuarioId_UsuarioExistente_DeveRetornarEstruturaRedeCuidado()
    {
        // Arrange
        var service = CreateService();
        var usuarioId = Guid.NewGuid();
        var coCuidadorId = Guid.NewGuid();
        var petId = Guid.NewGuid();
        var pet = new Pet("Bidu", DateTime.UtcNow.AddYears(-3), SexoPet.Macho, PortePet.Pequeno, false, Guid.NewGuid());
        var coCuidador = new Usuario("CoCuidador", "co@teste.com", "senha123", RoleUsuario.Comum, Guid.NewGuid());

        var vinculo1 = new UsuarioPet(usuarioId, pet.Id, true);
        var vinculo2 = new UsuarioPet(coCuidadorId, pet.Id, false);

        _usuarioRepoMock.Setup(r => r.ExistsById(usuarioId)).Returns(true);
        _usuarioPetRepoMock.Setup(r => r.GetByUsuarioId(usuarioId)).Returns([vinculo1]);
        _petRepoMock.Setup(r => r.Find(It.IsAny<System.Linq.Expressions.Expression<Func<Pet, bool>>>())).Returns([pet]);
        _tarefaRepoMock.Setup(r => r.GetByPetId(pet.Id)).Returns([]);
        _historicoRepoMock.Setup(r => r.GetByPetId(pet.Id)).Returns([]);
        _usuarioPetRepoMock.Setup(r => r.GetByPetId(pet.Id)).Returns([vinculo1, vinculo2]);
        _usuarioRepoMock.Setup(r => r.Find(It.IsAny<System.Linq.Expressions.Expression<Func<Usuario, bool>>>())).Returns([coCuidador]);

        // Act
        var result = service.GetRedeCuidadoByUsuarioId(usuarioId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(usuarioId, result.UsuarioId);
        Assert.Single(result.Pets);
        Assert.Single(result.CoCuidadores);
        Assert.Equal(coCuidador.Nome, result.CoCuidadores[0].Nome);
    }
}
