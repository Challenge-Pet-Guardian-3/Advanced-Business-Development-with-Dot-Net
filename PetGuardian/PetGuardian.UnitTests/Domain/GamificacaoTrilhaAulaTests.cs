using PetGuardian.Domain.Entities;
using PetGuardian.Domain.Exceptions;
using PetGuardian.UnitTests.Fixtures;
using Xunit;

namespace PetGuardian.UnitTests.Domain;

[Collection(UnitTestCollection.Name)]
public class GamificacaoTrilhaAulaTests(TestFixture fixture)
{
    [Fact]
    public void Trilha_CriacaoEAtualizacao_DeveFuncionarComSucesso()
    {
        // Arrange
        var trilha = fixture.CriarTrilhaValida();

        // Act
        trilha.Atualizar("Novo Nome Trilha", "Nova Descricao Trilha");

        // Assert
        Assert.Equal("Novo Nome Trilha", trilha.Nome);
        Assert.Equal("Nova Descricao Trilha", trilha.Descricao);
    }

    [Fact]
    public void Modulo_CriacaoEAtualizacao_DeveFuncionarComSucesso()
    {
        // Arrange
        var modulo = fixture.CriarModuloValido();

        // Act
        modulo.Atualizar("Modulo Atualizado", "3 horas", "Descricao Atualizada");

        // Assert
        Assert.Equal("Modulo Atualizado", modulo.Nome);
        Assert.Equal("3 horas", modulo.TempoConclusao);
        Assert.Equal("Descricao Atualizada", modulo.Descricao);
    }

    [Fact]
    public void Aula_Concluir_DeveMarcarComoConcluida()
    {
        // Arrange
        var aula = fixture.CriarAulaValida();
        Assert.False(aula.Concluida);

        // Act
        aula.Concluir();

        // Assert
        Assert.True(aula.Concluida);
    }

    [Fact]
    public void Aula_ConcluirJaConcluida_DeveLancarDomainException()
    {
        // Arrange
        var aula = fixture.CriarAulaValida();
        aula.Concluir();

        // Act & Assert
        var ex = Assert.Throws<DomainException>(() => aula.Concluir());
        Assert.Equal("Esta aula já foi concluída.", ex.Message);
    }

    [Fact]
    public void Historico_Registrar_DeveCriarInstanciaComDataUtc()
    {
        // Arrange
        var petId = Guid.NewGuid();

        // Act
        var hist = Historico.Registrar("VACINA_APLICADA", petId);

        // Assert
        Assert.Equal("VACINA_APLICADA", hist.TipoHist);
        Assert.Equal(petId, hist.PetId);
        Assert.True((DateTime.UtcNow - hist.DataHist).TotalSeconds < 5);
    }

    [Fact]
    public void UsuarioPet_AtualizarResponsabilidade_DeveAlternarFlag()
    {
        // Arrange
        var vinculo = new UsuarioPet(Guid.NewGuid(), Guid.NewGuid(), responPrinc: false);

        // Act
        vinculo.AtualizarResponsabilidade(true);

        // Assert
        Assert.True(vinculo.ResponPrinc);
    }
}
