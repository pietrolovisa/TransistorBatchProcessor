using Microsoft.EntityFrameworkCore;
using TransisterBatch.EntityFramework.QueryFilters;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System;

namespace TransisterBatch.EntityFramework.Extensions
{
    public static class QueryFilterExtensions
    {
        //public static async Task<int> DeleteAsync<TDomain>(this IQueryable<TDomain> query, Expression<Func<TDomain, bool>> predicate)
        //    where TDomain : class
        //{
        //    return await query
        //        .Where(predicate)
        //        .ExecuteDeleteAsync();
        //}

        public static async Task<TDomain> FirstOrDefaultAsync<TDomain, TOptions>(this IQueryable<TDomain> query, Expression<Func<TDomain, bool>> predicate, TOptions queryFilter = default)
            where TDomain : class
            where TOptions : class, IQueryFilter<TDomain>, new()
        {
            return await query
                .Where(predicate)
                .FirstOrDefaultAsync(queryFilter);
        }

        public static async Task<TDomain> FirstOrDefaultAsync<TDomain, TOptions>(this IQueryable<TDomain> query, TOptions queryFilter = default)
            where TDomain : class
            where TOptions : class, IQueryFilter<TDomain>, new()
        {
            return await query
                .Where(queryFilter)
                .FirstOrDefaultAsync();
        }

        public static async Task<List<TDomain>> ToListAsync<TDomain, TOptions>(this IQueryable<TDomain> query, Expression<Func<TDomain, bool>> predicate, TOptions queryFilter = default)
            where TDomain : class
            where TOptions : class, IQueryFilter<TDomain>, new()
        {
            return await query
                .Where(predicate)
                .ToListAsync(queryFilter);
        }

        public static async Task<List<TDomain>> ToListAsync<TDomain, TOptions>(this IQueryable<TDomain> query, TOptions queryFilter = default)
            where TDomain : class
            where TOptions : class, IQueryFilter<TDomain>, new()
        {
            return await query
                .Where(queryFilter)
                .ToListAsync();
        }

        public static IQueryable<TDomain> Where<TDomain, TOptions>(this IQueryable<TDomain> query, TOptions queryFilter = default)
            where TDomain : class
            where TOptions : class, IQueryFilter<TDomain>, new()
        {
            queryFilter ??= new TOptions();
            return queryFilter.Where(query);
        }
    }
}
