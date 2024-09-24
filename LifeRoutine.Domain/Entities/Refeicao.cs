namespace LifeRoutine.Domain.Entities;

public class Refeicao : BaseEntity
{
    protected Refeicao() { }
    public Refeicao(DateTime dataDeCriacao, List<Alimento> alimentos)
    {
        DataDeCriacao = dataDeCriacao;
        Alimentos = alimentos;
    }
    public DateTime DataDeCriacao { get; private set; }
    public List<Alimento> Alimentos { get; private set; }
}