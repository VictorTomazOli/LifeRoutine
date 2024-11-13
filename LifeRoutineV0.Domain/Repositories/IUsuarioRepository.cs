using LifeRoutineV0.Domain.Entities;
using System.Linq.Expressions;

namespace LifeRoutineV0.Domain.Repositories;

public interface IUsuarioRepository : IRepository<Usuario>
{
    Task<Usuario> ListarPorEmailAsync(Expression<Func<Usuario, bool>> predicate);
}