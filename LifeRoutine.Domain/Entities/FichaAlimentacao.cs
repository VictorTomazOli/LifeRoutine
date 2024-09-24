namespace LifeRoutine.Domain.Entities;

public class FichaAlimentacao : BaseEntity
{
    public FichaAlimentacao()
    {
        
    }
    public int UsuarioId { get; private set; }
    public Usuario Usuario { get; private set; } = null!;
    public List<Refeicao> Refeicoes { get; private set; } = new();
    
    public void AdicionarRefeicao(Refeicao refeicao)
    {
        Refeicoes.Add(refeicao);
    }
    public void AdicionarVariasRefeicoes(IList<Refeicao> refeicoes)
    {
        Refeicoes.AddRange(refeicoes);
    }
}