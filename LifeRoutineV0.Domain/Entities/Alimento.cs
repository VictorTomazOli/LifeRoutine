using LifeRoutineV0.Domain.Enums;

namespace LifeRoutineV0.Domain.Entities;

public class Alimento : BaseEntity
{
    protected Alimento() { }

    public Alimento(string nome, EGrupoAlimentar grupoAlimentar)
    {
        Nome = nome;
        GrupoAlimentar = grupoAlimentar;
    }

    public string Nome { get; private set; }
    public EGrupoAlimentar GrupoAlimentar { get; private set; }

    public void AlterarAlimento(string nome, EGrupoAlimentar grupoAlimentar)
    {
        Nome = nome;
        GrupoAlimentar = grupoAlimentar;
    }
}