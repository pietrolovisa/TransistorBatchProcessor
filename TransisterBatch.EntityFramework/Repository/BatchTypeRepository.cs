using TransisterBatch.EntityFramework.Domain;
using TransisterBatch.EntityFramework.Extensions;
using TransisterBatch.EntityFramework.QueryFilters;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using System.Globalization;
using System.IO;

namespace TransisterBatch.EntityFramework.Repository
{
    public interface IBatchTypeRepository : IRepositoryBase<BatchType, BatchTypeQueryFilter>
    {
        Task<BatchType> FindByKey(long batchTypeId, BatchTypeQueryFilter queryFilter = default);
    }

    public class BatchTypeRepository : RepositoryBase<BatchType, BatchTypeQueryFilter>, IBatchTypeRepository
    {
        public BatchTypeRepository(EFContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<BatchType> FindByKey(long batchTypeId, BatchTypeQueryFilter queryFilter = null)
        {
            return await _dbSet.FirstOrDefaultAsync(s => s.Id == batchTypeId, queryFilter);
        }

        public override async Task Delete(BatchType domain, BatchTypeQueryFilter queryFilter = null)
        {
            IExecutionStrategy executionStrategy = _dbContext.Database.CreateExecutionStrategy();
            await executionStrategy.ExecuteAsync(async () =>
            {
                using IDbContextTransaction transaction = _dbContext.Database.BeginTransaction();
                try
                {
                    BatchType batchTypeToDelete = await FindByKey(domain.Id, new BatchTypeQueryFilter
                    {
                        Track = true,
                        IncludeBatches = true
                    });
                    foreach (Batch batch in batchTypeToDelete.Batches)
                    {
                        List<Transistor> transistors = _dbContext.Transistor.Where(t => t.BatchId == batch.Id).ToList();
                        foreach (Transistor transistor in batch.Transistors)
                        {
                            _dbContext.Transistor.Remove(transistor);
                        }
                        _dbContext.Batch.Remove(batch);
                    }
                    _dbSet.Remove(batchTypeToDelete);
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

    public class BatchTypeQueryFilter : QueryFilterBase<BatchType>
    {
        public bool IncludeBatches { get; set; }
        

        public override IQueryable<BatchType> Where(IQueryable<BatchType> query)
        {
            query = base.Where(query);
            if (IncludeBatches)
            {
                query = query
                    .Include(s => s.Batches);
            }
            return query;
        }
    }
}
