using PetGuardian.Domain.Entities;
using PetGuardian.Domain.Enums;

namespace PetGuardian.UnitTests.Fixtures;

/// <summary>
/// Fixture compartilhada para geração consistente de entidades e DTOs de teste.
/// </summary>
public class TestFixture
{
    public Pet CriarPetValido(string nome = "Rex", Guid? racaId = null)
    {
        return new Pet(
            nome: nome,
            dataNascimento: DateTime.UtcNow.AddYears(-3),
            sexo: SexoPet.Macho,
            porte: PortePet.Medio,
            castrado: false,
            racaId: racaId ?? Guid.NewGuid()
        );
    }

    public Usuario CriarUsuarioValido(string nome = "Carlos Silva", string email = "carlos@email.com", Guid? telefoneId = null)
    {
        return new Usuario(
            nome: nome,
            email: email,
            senha: "senhaSegura123",
            role: RoleUsuario.Comum,
            telefoneId: telefoneId ?? Guid.NewGuid()
        );
    }

    public Tarefa CriarTarefaValida(Guid? petId = null, Guid? usuarioId = null, Guid? statusId = null)
    {
        return new Tarefa(
            titulo: "Passeio Matinal",
            pontosTarefa: 50,
            descricao: "Caminhada de 30 minutos no parque.",
            prazo: DateTime.UtcNow.AddDays(1),
            petId: petId ?? Guid.NewGuid(),
            statusId: statusId ?? Guid.NewGuid(),
            usuarioId: usuarioId ?? Guid.NewGuid()
        );
    }

    public Trilha CriarTrilhaValida(Guid? petId = null)
    {
        return new Trilha(
            nome: "Trilha de Adestramento",
            descricao: "Comandos básicos de obediência e socialização.",
            petId: petId ?? Guid.NewGuid()
        );
    }

    public Modulo CriarModuloValido(Guid? trilhaId = null)
    {
        return new Modulo(
            nome: "Módulo 1 - Comandos Básicos",
            tempoConclusao: "2 horas",
            descricao: "Comandos senta, deita e fica.",
            trilhaId: trilhaId ?? Guid.NewGuid()
        );
    }

    public Aula CriarAulaValida(Guid? moduloId = null)
    {
        return new Aula(
            nome: "Aula 1: Sentar",
            descricao: "Ensinando o comando senta com petisco.",
            pontosAula: 20,
            dificuldade: "Facil",
            conteudo: "Guia passo a passo do treino.",
            concluida: false,
            moduloId: moduloId ?? Guid.NewGuid()
        );
    }
}
