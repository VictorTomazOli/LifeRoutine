using System.Linq.Expressions;

namespace LifeRoutineV0.Domain.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    public Task AtualizarAsync(TEntity entity);
    public Task<int> Contagem(Expression<Func<TEntity, bool>>? where = null);
    public Task CriarAsync(TEntity entity);
    public Task DeletarAsync(TEntity entity);
    public Task<TEntity> ListarPorIdAsync(int id, IEnumerable<string>? includes = null);
    public Task<TEntity> ListarPorIdAsync(int id, string include,
        IEnumerable<string>? thenIncludes = null);
    public Task<TEntity> ListarPorIdAsNoTracking(int id, IEnumerable<string>? includes = null);
    public Task<TEntity> ListarPorIdAsNoTracking(int id, string include,
        IEnumerable<string>? thenIncludes = null);
    public Task<IEnumerable<TEntity>> ListarTodosAsync(IEnumerable<string>? includes = null,
        Expression<Func<TEntity, bool>>? where = null);
    public Task<IEnumerable<TEntity>> ListarTodosAsync(string include, IEnumerable<string>? thenIncludes = null,
        Expression<Func<TEntity, bool>>? where = null);
    public Task<int> SalvarMudancasAsync();

}