using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LifeRoutineV0.Infra.Extensions;

public static class RepositoryExtensions
{
    public static IQueryable<TEntity> Include<TEntity>(this IQueryable<TEntity> query, 
        IEnumerable<string>? includes) where TEntity : class
    {
        if (includes != null)
            query = includes.Aggregate(query, (entity, include) => entity.Include(include));

        return query;
    }

    public static IQueryable<TEntity> ThenIncludes<TEntity>(this IQueryable<TEntity> query,
        string navigation, IEnumerable<string>? includes) where TEntity : class
    {
        if (includes != null)
            query = includes.Aggregate(query, 
                (entity, include) => entity.Include($"{navigation}.{include}"));

        return query;
    }

    public static IQueryable<TEntity> WhereN<TEntity>(this IQueryable<TEntity> query, 
        Expression<Func<TEntity, bool>>? where = null)
    {
        if (where != null)
            query = query.Where(where);

        return query;
    }
}