using LifeRoutineV0.Domain.Entities;
using LifeRoutineV0.Domain.Repositories;
using LifeRoutineV0.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace LifeRoutineV0.Infra.Repositories;

public class FichaAlimentacaoRepository(LifeRoutineV0DbContext context)
    : Repository<FichaAlimentacao>(context), IFichaAlimentacaoRepository
{
    public async Task<Usuario> ListarUsuario(int id)
        => await context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
}
