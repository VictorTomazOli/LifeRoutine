using LifeRoutineV0.Domain.Entities;
using LifeRoutineV0.Domain.Repositories;
using LifeRoutineV0.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LifeRoutineV0.Infra.Repositories;

public abstract class Repository<TEntity>(LifeRoutineV0DbContext context) 
    : IRepository<TEntity> where TEntity : BaseEntity
{
    public DbSet<TEntity> Entities { get; set; } = context.Set<TEntity>();

    public async Task AtualizarAsync(TEntity entity)
        => await Task.Run( () => Entities.Update(entity));

    public async Task<int> Contagem()
        => await Entities.CountAsync();

    public async Task<int> Contagem(Expression<Func<TEntity, bool>> where)
        => await Entities.Where(where).CountAsync();

    public async Task CriarAsync(TEntity entity)
        => await Entities.AddAsync(entity);

    public async Task DeletarAsync(TEntity entity)
        => await Task.Run( () => Entities.Remove(entity));

    public async Task<TEntity> ListarPorIdAsNoTracking(int id)
        => await Entities.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

    public async Task<TEntity> ListarPorIdAsync(int id)
        => await Entities.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<IEnumerable<TEntity>> ListarTodosAsync()
        => await Entities.AsNoTracking().ToListAsync();

    public async Task<IEnumerable<TEntity>> ListarTodosAsync(Expression<Func<TEntity, bool>> where)
        => await Entities.Where(where).AsNoTracking().ToListAsync();

    public async Task<IEnumerable<TEntity>> ListarTodosAsync(Expression<Func<TEntity, bool>> where, 
        Expression<Func<TEntity, object>> include)
        => await Entities.Where(where).Include(include).AsNoTracking().ToListAsync();

    public async Task<int> SalvarMudancasAsync()
        => await context.SaveChangesAsync();
}
   
