using TransisterBatch.EntityFramework.Domain;
using TransisterBatch.EntityFramework.Extensions;
using TransisterBatch.EntityFramework.QueryFilters;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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
