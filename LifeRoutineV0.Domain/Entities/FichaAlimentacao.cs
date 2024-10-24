namespace LifeRoutineV0.Domain.Entities;

public class FichaAlimentacao : BaseEntity
{
    public FichaAlimentacao() { }
    public int UsuarioId { get; private set; }
    public Usuario Usuario { get; private set; } = null!;
    public List<Refeicao> Refeicoes { get; private set; } = new();
}