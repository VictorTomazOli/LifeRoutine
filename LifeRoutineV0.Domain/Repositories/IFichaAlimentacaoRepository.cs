using LifeRoutineV0.Domain.Entities;

namespace LifeRoutineV0.Domain.Repositories;

public interface IFichaAlimentacaoRepository : IRepository<FichaAlimentacao>
{
    public Task<Usuario> ListarUsuario(int id);
}