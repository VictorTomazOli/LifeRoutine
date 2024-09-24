using LifeRoutine.Domain.ValueObjects;

namespace LifeRoutine.Domain.Entities;

public class FichaExercicio : BaseEntity
{
    protected FichaExercicio() { }
    public FichaExercicio(List<Exercicio> exercicios)
    {
        Guid = Guid.NewGuid();
        DataCriacao = DateTime.UtcNow;
        Exercicios = exercicios;
    }
    public Guid Guid { get; set; }
    public int UsuarioId { get; private set; }
    public Usuario Usuario { get; private set; } = null!;
    public DateTime DataCriacao { get; private set; }
    public List<Exercicio> Exercicios { get; private set; } = null!;
}