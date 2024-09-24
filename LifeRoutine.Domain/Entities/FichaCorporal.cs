using LifeRoutine.Domain.ValueObjects;

namespace LifeRoutine.Domain.Entities;

public class FichaCorporal : BaseEntity
{
    protected FichaCorporal() { }
    public FichaCorporal(float peso, float altura, Perimetria perimetria)
    {
        Guid = Guid.NewGuid();
        Peso = peso;
        Altura = altura;
        Perimetria = perimetria;
        DataCriacao = DateTime.UtcNow;
    }
    public int UsuarioId { get; private set; }
    public Usuario Usuario { get; private set; } = null!;
    public Guid Guid { get; private set; }
    public float Peso { get; private set; }
    public float Altura { get; private set; }
    public Perimetria? Perimetria {get; private set;}
    public DateTime DataCriacao { get; private set; }

    /*public void AdicionarPerimetria(Perimetria perimetria)
    {
        if (perimetria is null)
            Perimetria = perimetria;
    }
    */
}