using TransisterBatch.EntityFramework.Domain;
using TransisterBatch.EntityFramework.Extensions;
using TransisterBatch.EntityFramework.QueryFilters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Xml.Linq;
using System.Globalization;

namespace TransisterBatch.EntityFramework.Repository
{
    public interface ITransistorRepository : IRepositoryBase<Transistor, TransistorQueryFilter>
    {
        Task<List<Transistor>> FindByBatchId(long batchId, TransistorQueryFilter queryFilter = null);
        Task<List<Transistor>> FindByBatchIdAndMatched(long batchId, TransistorQueryFilter queryFilter = null);
        Task<List<Transistor>> FindByBatchIdAndUnmatched(long batchId, TransistorQueryFilter queryFilter = null);
        Task<Transistor> FindByKey(int transistorId, TransistorQueryFilter queryFilter = null);
        Task UpdateGroups(List<TransistorGroup> transistorGroups);
    }

    public class TransistorRepository : RepositoryBase<Transistor, TransistorQueryFilter>, ITransistorRepository
    {
        public TransistorRepository(EFContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<List<Transistor>> FindByBatchId(long batchId, TransistorQueryFilter queryFilter = null)
        {
            return await _dbSet.ToListAsync(a => a.BatchId == batchId, queryFilter);
        }

        public async Task<List<Transistor>> FindByBatchIdAndMatched(long batchId, TransistorQueryFilter queryFilter = null)
        {
            return await _dbSet.ToListAsync(a => a.BatchId == batchId && a.GroupId != null, queryFilter);
        }

        public async Task<List<Transistor>> FindByBatchIdAndUnmatched(long batchId, TransistorQueryFilter queryFilter = null)
        {
            return await _dbSet.ToListAsync(a => a.BatchId == batchId && a.GroupId == null, queryFilter);
        }

        public async Task<Transistor> FindByKey(int transistorId, TransistorQueryFilter queryFilter = null)
        {
            return await _dbSet.FirstOrDefaultAsync(a => a.Id == transistorId, queryFilter);
        }

        public async Task UpdateGroups(List<TransistorGroup> transistorGroups)
        {
            IExecutionStrategy executionStrategy = _dbContext.Database.CreateExecutionStrategy();
            await executionStrategy.ExecuteAsync(async () =>
            {
                using IDbContextTransaction transaction = _dbContext.Database.BeginTransaction();
                try
                {
                    foreach (TransistorGroup group in transistorGroups)
                    {
                        string groupId = Guid.NewGuid().ToString("N").ToUpper(CultureInfo.InvariantCulture);
                        foreach (Transistor transistor in group)
                        {
                            transistor.GroupId = groupId;
                            await Update(transistor);
                        }
                    }
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

    public class TransistorQueryFilter : QueryFilterBase<Transistor>
    {
    }
}
