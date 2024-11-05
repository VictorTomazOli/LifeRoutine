namespace LifeRoutineV0.Domain.Entities;

public class Refeicao : BaseEntity
{
    protected Refeicao() { }

    public Refeicao(DateTime dataCriacao, List<Alimento> alimentos)
    {
        DataDeCriacao = dataCriacao;
        Alimentos = alimentos;
    }

    public DateTime DataDeCriacao {  get; private set; }
    public List<Alimento> Alimentos { get; private set; }
    public int FichaAlimentacaoId { get; private set; }

    public void AlterarRefeicao(DateTime dataCriacao, List<Alimento> alimentos)
    {
        DataDeCriacao = dataCriacao;
        Alimentos = alimentos;
    }
}