using LifeRoutineV0.Domain.Requests;

namespace LifeRoutineV0.Domain.Entities;

public class FichaAlimentacao : BaseEntity
{
    public FichaAlimentacao() { }
    public FichaAlimentacao(Usuario usuario) 
    {
        Usuario = usuario;
    }
    public int UsuarioId { get; private set; }
    public Usuario Usuario { get; private set; } = null!;
    public List<Refeicao> Refeicoes { get; private set; } = new();

    public void ListarRefeicoes(int pageNumber, int pageSize)
    {
        Refeicoes = new List<Refeicao>
            (Refeicoes.OrderBy(x => x.DataDeCriacao).Skip(pageNumber - 1 * pageSize).Take(pageSize).ToList());
    }

    public void AdicionarRefeicao(Refeicao refeicao)
    {
        Refeicoes.Add(refeicao);
    }

    public void RemoverRefeicao(Refeicao refeicao)
    {
        Refeicoes.Remove(refeicao);
    }
}