using Microsoft.Extensions.Logging;
using Moq;
using PetGuardian.Application.DTOs;
using PetGuardian.Application.Repositories;
using PetGuardian.Application.Services.Implementations;
using PetGuardian.Domain.Entities;
using PetGuardian.UnitTests.Fixtures;
using Xunit;

namespace PetGuardian.UnitTests.Application;

[Collection(UnitTestCollection.Name)]
public class GamificacaoServicesTests(TestFixture fixture)
{
    [Fact]
    public void AulaService_Create_ModuloValido_DeveCriarAula()
    {
        // Arrange
        var aulaRepoMock = new Mock<IAulaRepository>();
        var moduloRepoMock = new Mock<IModuloRepository>();
        var loggerMock = new Mock<ILogger<AulaService>>();
        var service = new AulaService(aulaRepoMock.Object, moduloRepoMock.Object, loggerMock.Object);

        var moduloId = Guid.NewGuid();
        var request = new AulaRequest("Aula 1", "Descricao", 15, "Medio", "Conteudo", false, moduloId);

        moduloRepoMock.Setup(m => m.ExistsById(moduloId)).Returns(true);
        aulaRepoMock.Setup(a => a.Add(It.IsAny<Aula>())).Returns<Aula>(a => a);

        // Act
        var response = service.Create(request);

        // Assert
        Assert.NotNull(response);
        Assert.Equal("Aula 1", response.Nome);
        aulaRepoMock.Verify(a => a.Add(It.IsAny<Aula>()), Times.Once);
    }

    [Fact]
    public void ModuloService_Update_ModuloExistente_DeveAtualizar()
    {
        // Arrange
        var moduloRepoMock = new Mock<IModuloRepository>();
        var trilhaRepoMock = new Mock<ITrilhaRepository>();
        var loggerMock = new Mock<ILogger<ModuloService>>();
        var service = new ModuloService(moduloRepoMock.Object, trilhaRepoMock.Object, loggerMock.Object);

        var modulo = fixture.CriarModuloValido();
        var updateRequest = new ModuloUpdateRequest("Modulo Editado", "5 horas", "Nova Desc");

        moduloRepoMock.Setup(m => m.GetById(modulo.Id)).Returns(modulo);
        moduloRepoMock.Setup(m => m.Update(modulo)).Returns(modulo);

        // Act
        var response = service.Update(modulo.Id, updateRequest);

        // Assert
        Assert.NotNull(response);
        Assert.Equal("Modulo Editado", response.Nome);
        moduloRepoMock.Verify(m => m.Update(modulo), Times.Once);
    }

    [Fact]
    public void TrilhaService_Create_PetValido_DeveCriarTrilha()
    {
        // Arrange
        var trilhaRepoMock = new Mock<ITrilhaRepository>();
        var petRepoMock = new Mock<IPetRepository>();
        var loggerMock = new Mock<ILogger<TrilhaService>>();
        var service = new TrilhaService(trilhaRepoMock.Object, petRepoMock.Object, loggerMock.Object);

        var petId = Guid.NewGuid();
        var request = new TrilhaRequest("Trilha Filhote", "Cuidados iniciais", petId);

        petRepoMock.Setup(p => p.ExistsById(petId)).Returns(true);
        trilhaRepoMock.Setup(t => t.Add(It.IsAny<Trilha>())).Returns<Trilha>(t => t);

        // Act
        var response = service.Create(request);

        // Assert
        Assert.NotNull(response);
        Assert.Equal("Trilha Filhote", response.Nome);
        trilhaRepoMock.Verify(t => t.Add(It.IsAny<Trilha>()), Times.Once);
    }

    [Fact]
    public void HistoricoService_Create_PetValido_DeveCriarHistorico()
    {
        // Arrange
        var histRepoMock = new Mock<IHistoricoRepository>();
        var petRepoMock = new Mock<IPetRepository>();
        var loggerMock = new Mock<ILogger<HistoricoService>>();
        var service = new HistoricoService(histRepoMock.Object, petRepoMock.Object, loggerMock.Object);

        var petId = Guid.NewGuid();
        var request = new HistoricoRequest("CONSULTA", DateTime.UtcNow, petId);

        petRepoMock.Setup(p => p.ExistsById(petId)).Returns(true);
        histRepoMock.Setup(h => h.Add(It.IsAny<Historico>())).Returns<Historico>(h => h);

        // Act
        var response = service.Create(request);

        // Assert
        Assert.NotNull(response);
        Assert.Equal("CONSULTA", response.TipoHist);
        histRepoMock.Verify(h => h.Add(It.IsAny<Historico>()), Times.Once);
    }
}
