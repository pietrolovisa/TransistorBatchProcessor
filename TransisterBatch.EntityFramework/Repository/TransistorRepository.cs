using TransisterBatch.EntityFramework.Domain;
using TransisterBatch.EntityFramework.Extensions;
using TransisterBatch.EntityFramework.QueryFilters;
using Microsoft.EntityFrameworkCore;

namespace TransisterBatch.EntityFramework.Repository
{
    public interface ITransistorRepository : IRepositoryBase<Transistor, TransistorQueryFilter>
    {
        Task<List<Transistor>> FindByBatchId(int batchId, TransistorQueryFilter queryFilter = null);
        Task<Transistor> FindByKey(int transistorId, TransistorQueryFilter queryFilter = null);
    }

    public class TransistorRepository : RepositoryBase<Transistor, TransistorQueryFilter>, ITransistorRepository
    {
        public TransistorRepository(EFContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<List<Transistor>> FindByBatchId(int batchId, TransistorQueryFilter queryFilter = null)
        {
            return await _dbSet.ToListAsync(a => a.BatchId == batchId, queryFilter);
        }

        public async Task<Transistor> FindByKey(int transistorId, TransistorQueryFilter queryFilter = null)
        {
            return await _dbSet.FirstOrDefaultAsync(a => a.Id == transistorId, queryFilter);
        }
    }

    public class TransistorQueryFilter : QueryFilterBase<Transistor>
    {
    }
}
