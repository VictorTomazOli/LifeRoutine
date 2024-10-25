using System.Linq.Expressions;

namespace LifeRoutineV0.Domain.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    public Task AtualizarAsync(TEntity entity);
    public Task<int> Contagem();
    public Task<int> Contagem(Expression<Func<TEntity, bool>> where);
    public Task CriarAsync(TEntity entity);
    public Task DeletarAsync(TEntity entity);
    public Task<TEntity> ListarPorIdAsync(int id);
    public Task<TEntity> ListarPorIdAsNoTracking(int id);
    public Task<IEnumerable<TEntity>> ListarTodosAsync();
    public Task<IEnumerable<TEntity>> ListarTodosAsync(Expression<Func<TEntity, bool>> where);
    public Task<IEnumerable<TEntity>> ListarTodosAsync(Expression<Func<TEntity, bool>> where,
        Expression<Func<TEntity, object>> include);
    public Task<int> SalvarMudancasAsync();

}