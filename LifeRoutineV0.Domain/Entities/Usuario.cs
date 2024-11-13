using LifeRoutineV0.Domain.ValueObjects;

namespace LifeRoutineV0.Domain.Entities;

public class Usuario : BaseEntity
{
    protected Usuario() { }

    public Usuario(string nome, Email email, Senha senha, DateTime dataNascimento)
    {
        Nome = nome;
        Email = email;
        Senha = senha;
        DataNascimento = dataNascimento;
        FichaAlimentacaoId = 0;
    }

    public string Nome { get; private set; }
    public Email Email { get; private set; }
    public Senha Senha { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public int FichaAlimentacaoId { get; private set; }
    public FichaAlimentacao FichaAlimentacao { get; private set; }

    public void AlterarUsuario(string nome, Email email, DateTime dataNascimento)
    {
        Nome = nome;
        Email = email;
        DataNascimento = dataNascimento;
    }
}