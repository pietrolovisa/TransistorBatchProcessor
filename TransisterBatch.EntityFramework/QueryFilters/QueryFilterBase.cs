using Microsoft.EntityFrameworkCore;

namespace TransisterBatch.EntityFramework.QueryFilters
{
    public abstract class QueryFilterBase<TDomain> : IQueryFilter<TDomain>
        where TDomain : class
    {
        public const bool DEFAULT_INCLUDE_INACTIVE = false;
        public const bool DEFAULT_TRACKING = false;
        public const bool DEFAULT_AUTO_COMMIT = true;

        /// <summary>
        /// Disabling change tracking is useful for read-only scenarios because it avoids the overhead of setting
        /// up change tracking for each entity instance. You should not disable change tracking if you want to
        /// manipulate entity instances and persist those changes to the database using.
        /// </summary>
        public bool Track { get; set; } = DEFAULT_TRACKING;
        /// <summary>
        /// Inactive rows is a RetinaCS datebase paradigm.  This will indicate to the repository performing the 
        /// query to include rows where this field is set to 'true'.
        /// </summary>
        public bool IncludeInactiveRows { get; set; } = DEFAULT_INCLUDE_INACTIVE;
        /// <summary>
        /// I think this goes away.  everyting gets saved.  If dev wants the option to roll back they encase in a transaction.
        /// </summary>
        public bool AutoCommit { get; set; } = DEFAULT_AUTO_COMMIT;

        public virtual IQueryable<TDomain> Where(IQueryable<TDomain> query)
        {
            if (!Track)
            {
                query = query
                    .AsNoTracking();
            }
            //if (!IncludeInactiveRows && query.HasEntityState())
            //{
            //    query = query
            //        .Where(assetIP => (assetIP as IEntityState).Inactive == false);
            //}
            return query;
        }
    }
}
