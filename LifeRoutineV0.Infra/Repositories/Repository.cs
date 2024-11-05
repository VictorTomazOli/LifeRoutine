using LifeRoutineV0.Domain.Entities;
using LifeRoutineV0.Domain.Repositories;
using LifeRoutineV0.Infra.Context;
using LifeRoutineV0.Infra.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace LifeRoutineV0.Infra.Repositories;

public abstract class Repository<TEntity>(LifeRoutineV0DbContext context) 
    : IRepository<TEntity> where TEntity : BaseEntity
{
    public DbSet<TEntity> Entities { get; set; } = context.Set<TEntity>();

    public async Task AtualizarAsync(TEntity entity)
        => await Task.Run( () => Entities.Update(entity));

    public async Task<int> Contagem(Expression<Func<TEntity, bool>>? where = null)
        => await Entities.WhereN(where).CountAsync();

    public async Task CriarAsync(TEntity entity)
        => await Entities.AddAsync(entity);

    public async Task DeletarAsync(TEntity entity)
        => await Task.Run(() => Entities.Remove(entity));

    public async Task<TEntity> ListarPorIdAsNoTracking(int id, IEnumerable<string>? includes = null)
        => await Entities.Include(includes) .AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

    public async Task<TEntity> ListarPorIdAsNoTracking(int id, string include, 
        IEnumerable<string>? thenIncludes = null)
        => await Entities.ThenIncludes(include, thenIncludes).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

    public async Task<TEntity> ListarPorIdAsync(int id, IEnumerable<string>? includes = null)
        => await Entities.Include(includes).FirstOrDefaultAsync(x => x.Id == id);

    public async Task<TEntity> ListarPorIdAsync(int id, string include, 
        IEnumerable<string>? thenIncludes = null)
        => await Entities.ThenIncludes(include, thenIncludes).FirstOrDefaultAsync(x => x.Id == id);

    public async Task<IEnumerable<TEntity>> ListarTodosAsync(IEnumerable<string>? includes = null,
        Expression<Func<TEntity, bool>>? where = null)
        => await Entities.Include(includes).WhereN(where).ToListAsync();

    public async Task<IEnumerable<TEntity>> ListarTodosAsync(string include, IEnumerable<string>? thenIncludes = null,
        Expression<Func<TEntity, bool>>? where = null)
        => await Entities.ThenIncludes(include, thenIncludes).WhereN(where).ToListAsync();

    public async Task<int> SalvarMudancasAsync()
        => await context.SaveChangesAsync();
}
   
