namespace LifeRoutine.Domain.Entities;

public class Refeicao : BaseEntity
{
    public Refeicao(DateTime dataDeCriacao, IEnumerable<Alimento> alimentos)
    {
        DataDeCriacao = dataDeCriacao;
        Alimentos = alimentos;
    }
    public DateTime DataDeCriacao { get; private set; }
    public IEnumerable<Alimento> Alimentos { get; private set; }
}