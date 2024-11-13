using LifeRoutineV0.Domain.Entities;

namespace LifeRoutineV0.Domain.Repositories;

public interface IFichaAlimentacaoRepository : IRepository<FichaAlimentacao>
{
    public Task<Usuario> ListarUsuario(int userId);

    public Task<FichaAlimentacao> ListarFichaUsuario(int userId, int fichaId, string include,
        IEnumerable<string>? thenIncludes = null);
}