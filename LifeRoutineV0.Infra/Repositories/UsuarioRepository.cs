using LifeRoutineV0.Domain.Entities;
using LifeRoutineV0.Domain.Repositories;
using LifeRoutineV0.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LifeRoutineV0.Infra.Repositories;

public class UsuarioRepository(LifeRoutineV0DbContext context) 
    : Repository<Usuario>(context), IUsuarioRepository
{
    public async Task<Usuario> ListarPorEmailAsync(Expression<Func<Usuario, bool>> predicate)
        => await Entities.FirstOrDefaultAsync(predicate);
}