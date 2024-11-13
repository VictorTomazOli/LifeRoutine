using LifeRoutineV0.Domain.Entities;
using LifeRoutineV0.Domain.Repositories;
using LifeRoutineV0.Infra.Context;
using LifeRoutineV0.Infra.Extensions;
using Microsoft.EntityFrameworkCore;

namespace LifeRoutineV0.Infra.Repositories;

public class FichaAlimentacaoRepository(LifeRoutineV0DbContext context)
    : Repository<FichaAlimentacao>(context), IFichaAlimentacaoRepository
{
    public async Task<FichaAlimentacao> ListarFichaUsuario(int userId, int fichaId, string include,
        IEnumerable<string>? thenIncludes = null)
        => await context.FichaAlimentacaos.ThenIncludes(include, thenIncludes).FirstOrDefaultAsync(x => x.UsuarioId == userId && x.Id == fichaId);

    public async Task<Usuario> ListarUsuario(int userId)
        => await context.Usuarios.FirstOrDefaultAsync(x => x.Id == userId);
}
