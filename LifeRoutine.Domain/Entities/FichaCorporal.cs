using LifeRoutine.Domain.ValueObjects;

namespace LifeRoutine.Domain.Entities;

public class FichaCorporal : BaseEntity
{
    public FichaCorporal(float peso, float altura, Perimetria perimetria)
    {
        Guid = Guid.NewGuid();
        Peso = peso;
        Altura = altura;
        Perimetria = perimetria;
        DataCriacao = DateTime.UtcNow;
    }
    public Guid Guid { get; set; }
    public float Peso { get; private set; }
    public float Altura { get; private set; }
    public Perimetria Perimetria {get;set;}
    public DateTime DataCriacao { get; private set; }
}