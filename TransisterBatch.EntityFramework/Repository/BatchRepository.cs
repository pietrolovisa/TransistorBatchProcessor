using TransisterBatch.EntityFramework.Domain;
using TransisterBatch.EntityFramework.Extensions;
using TransisterBatch.EntityFramework.QueryFilters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace TransisterBatch.EntityFramework.Repository
{
    public interface IBatchRepository : IRepositoryBase<Batch, BatchQueryFilter>
    {
        Task<Batch> FindByKey(long batchId, BatchQueryFilter queryFilter = default);
    }

    public class BatchRepository : RepositoryBase<Batch, BatchQueryFilter>, IBatchRepository
    {
        public BatchRepository(EFContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<Batch> FindByKey(long batchId, BatchQueryFilter queryFilter = null)
        {
            return await _dbSet.FirstOrDefaultAsync(s => s.Id == batchId, queryFilter);
        }

        public override async Task Delete(Batch domain, BatchQueryFilter queryFilter = null)
        {
            IExecutionStrategy executionStrategy = _dbContext.Database.CreateExecutionStrategy();
            await executionStrategy.ExecuteAsync(async () =>
            {
                using IDbContextTransaction transaction = _dbContext.Database.BeginTransaction();
                try
                {
                    Batch batchToDelete = await FindByKey(domain.Id, new BatchQueryFilter
                    {
                        Track = true,
                        IncludeTransistors = true
                    });
                    foreach (Transistor transistor in batchToDelete.Transistors)
                    {
                        _dbContext.Transistor.Remove(transistor);
                    }
                    _dbSet.Remove(batchToDelete);
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            });
        }
    }

    public class BatchQueryFilter : QueryFilterBase<Batch>
    {
        public bool IncludeBatchType { get; set; }
        public bool IncludeTransistors { get; set; }

        public override IQueryable<Batch> Where(IQueryable<Batch> query)
        {
            query = base.Where(query);
            if (IncludeBatchType)
            {
                query = query
                    .Include(s => s.Type);
            }
            if (IncludeTransistors)
            {
                query = query
                    .Include(s => s.Transistors);
            }
            return query;
        }
    }
}
