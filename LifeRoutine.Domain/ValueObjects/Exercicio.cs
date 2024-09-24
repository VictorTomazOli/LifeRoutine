using LifeRoutine.Domain.Enums;

namespace LifeRoutine.Domain.ValueObjects;

public class Exercicio
{
    protected Exercicio() { }
    public Exercicio(string nome, int numero_de_repeticoes, int numero_de_series, IEnumerable<EDiasDaSemana> diasDaSemana)
    {
        Nome = nome;
        Numero_De_Repeticoes = numero_de_repeticoes;
        Numero_De_Series = numero_de_series;
        DiasDaSemana = diasDaSemana;
    }
    public string Nome { get; set; } = string.Empty;
    public int Numero_De_Repeticoes { get; set; }
    public int Numero_De_Series { get; set; }
    public IEnumerable<EDiasDaSemana> DiasDaSemana { get; private set; } = Enumerable.Empty<EDiasDaSemana>();
}