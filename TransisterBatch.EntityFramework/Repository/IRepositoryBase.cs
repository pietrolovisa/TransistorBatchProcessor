using System.Linq.Expressions;

namespace TransisterBatch.EntityFramework.Repository
{
    public interface IRepositoryBase<TDomain, TOptions>
    {
        Task Insert(TDomain domain, TOptions queryFilter = default);
        Task Update(TDomain domain, TOptions queryFilter = default);
        Task Delete(TDomain domain, TOptions queryFilter = default);
        //Task<int> Delete(Expression<Func<TDomain, bool>> predicate, TOptions queryFilter = default);
        Task<List<TDomain>> FindAll(TOptions queryFilter = default);
        Task<TDomain> FindWhereOne(Expression<Func<TDomain, bool>> predicate, TOptions queryFilter = default);
        Task<List<TDomain>> FindWhereMany(Expression<Func<TDomain, bool>> predicate, TOptions queryFilter = default);

        void ClearTracker();
    }
}
