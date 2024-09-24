using LifeRoutine.Domain.ValueObjects;

namespace LifeRoutine.Domain.Entities;

public class Usuario : BaseEntity
{
    protected Usuario() { }
    public Usuario(string nome, Email email, Senha senha, DateTime dataNascimento)
    {
        Nome = nome;
        Email = email;
        Senha = senha;
        DataNascimento = dataNascimento;
    }
    public string Nome { get; private set; }
    public Email Email { get; private set; }
    public Senha Senha { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public int? FichaAlimentacaoId { get; private set; }
    public FichaAlimentacao? FichaAlimentacao { get; private set; }
    public List<FichaExercicio>? FichasExercicios { get; private set; }
    public List<FichaCorporal>? FichasCorporal { get; private set; }

    public void AdicionarFichaAlimentacao(FichaAlimentacao fichaAlimentacao)
    {
        if (FichaAlimentacao is null)
            FichaAlimentacao = fichaAlimentacao;

        //O usuario so pode ter uma ficha de alimentação
    }

    public void AdicionarFichaExercicio(FichaExercicio fichaExercicio)
    {
        FichasExercicios?.Add(fichaExercicio);
    }

    public void AdicionarFichaCorporal(FichaCorporal fichaCorporal)
    {
        FichasCorporal?.Add(fichaCorporal);
    }

    public void AlterarSenha()
    {
        //Alterar Senha 
    }
}