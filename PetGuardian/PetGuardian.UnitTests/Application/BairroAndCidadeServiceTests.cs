using Moq;
using PetGuardian.Application.DTOs;
using PetGuardian.Application.Repositories;
using PetGuardian.Application.Services.Implementations;
using PetGuardian.Domain.Entities;
using PetGuardian.UnitTests.Fixtures;
using Xunit;

namespace PetGuardian.UnitTests.Application;

[Collection(UnitTestCollection.Name)]
public class BairroAndCidadeServiceTests
{
    private readonly Mock<IRepository<Bairro>> _bairroRepoMock = new();
    private readonly Mock<IRepository<Cidade>> _cidadeRepoMock = new();
    private readonly Mock<IRepository<Estado>> _estadoRepoMock = new();

    [Fact]
    public void BairroService_GetByCidadeId_DeveUsarFindERetornarLista()
    {
        // Arrange
        var service = new BairroService(_bairroRepoMock.Object, _cidadeRepoMock.Object);
        var cidadeId = Guid.NewGuid();
        var bairro = new Bairro("Pinheiros", cidadeId);

        _bairroRepoMock.Setup(r => r.Find(It.IsAny<System.Linq.Expressions.Expression<Func<Bairro, bool>>>()))
            .Returns([bairro]);

        // Act
        var result = service.GetByCidadeId(cidadeId);

        // Assert
        Assert.Single(result);
        Assert.Equal("Pinheiros", result[0].NomeBairro);
        _bairroRepoMock.Verify(r => r.Find(It.IsAny<System.Linq.Expressions.Expression<Func<Bairro, bool>>>()), Times.Once);
    }

    [Fact]
    public void CidadeService_GetByEstadoId_DeveUsarFindERetornarLista()
    {
        // Arrange
        var service = new CidadeService(_cidadeRepoMock.Object, _estadoRepoMock.Object);
        var estadoId = Guid.NewGuid();
        var cidade = new Cidade("Campinas", estadoId);

        _cidadeRepoMock.Setup(r => r.Find(It.IsAny<System.Linq.Expressions.Expression<Func<Cidade, bool>>>()))
            .Returns([cidade]);

        // Act
        var result = service.GetByEstadoId(estadoId);

        // Assert
        Assert.Single(result);
        Assert.Equal("Campinas", result[0].NomeCidade);
        _cidadeRepoMock.Verify(r => r.Find(It.IsAny<System.Linq.Expressions.Expression<Func<Cidade, bool>>>()), Times.Once);
    }
}
