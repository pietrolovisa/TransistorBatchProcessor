using TransisterBatch.EntityFramework.Extensions;
using TransisterBatch.EntityFramework.QueryFilters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TransisterBatch.EntityFramework.Repository
{
    public abstract class RepositoryBase
    {
        protected readonly EFContext _dbContext;

        protected RepositoryBase(EFContext dbContext)
        {
            _dbContext = dbContext;
        }
    }

    public abstract class RepositoryBase<TDomain, TOptions> : RepositoryBase
        where TDomain : class
        where TOptions : class, IQueryFilter<TDomain>, new()
    {
        protected readonly DbSet<TDomain> _dbSet;

        protected RepositoryBase(EFContext dbContext)
            : base(dbContext)
        {
            _dbSet = _dbContext.Set<TDomain>();
        }

        public virtual void ClearTracker()
        {
            _dbContext.ChangeTracker.Clear();
        }

        protected virtual async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public virtual async Task Insert(TDomain domain, TOptions queryFilter = default)
        {
            queryFilter ??= new TOptions();
            await _dbSet.AddAsync(domain);
            await SaveChangesAsync();
        }

        public virtual async Task Update(TDomain domain, TOptions queryFilter = default)
        {
            queryFilter ??= new TOptions();
            _dbSet.Update(domain);
            await SaveChangesAsync();
        }

        public virtual async Task Delete(TDomain domain, TOptions queryFilter = default)
        {
            queryFilter ??= new TOptions();
            _dbSet.Remove(domain);
            await SaveChangesAsync();
        }

        //public virtual async Task<int> Delete(Expression<Func<TDomain, bool>> predicate, TOptions queryFilter = default)
        //{
        //    queryFilter ??= new TOptions();
        //    int count = await _dbSet.DeleteAsync(predicate);
        //    await SaveChangesAsync();
        //    return count;
        //}

        public virtual async Task<List<TDomain>> FindAll(TOptions queryFilter = default)
        {
            return await _dbSet.ToListAsync(queryFilter);
        }

        public virtual async Task<TDomain> FindWhereOne(Expression<Func<TDomain, bool>> predicate, TOptions queryFilter = default)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate, queryFilter);
        }

        public virtual async Task<List<TDomain>> FindWhereMany(Expression<Func<TDomain, bool>> predicate, TOptions queryFilter = default)
        {
            return await _dbSet.ToListAsync(predicate, queryFilter);
        }
    }
}
