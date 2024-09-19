using LifeRoutine.Domain.Enums;

namespace LifeRoutine.Domain.Entities;

public class Alimento : BaseEntity
{
    public Alimento(string nome, EgrupoAlimentar grupoAlimentar)
    {
        Nome = nome;
        GrupoAlimentar = grupoAlimentar;
    }
    public string Nome { get; private set; }
    public EgrupoAlimentar GrupoAlimentar { get; private set; }
}