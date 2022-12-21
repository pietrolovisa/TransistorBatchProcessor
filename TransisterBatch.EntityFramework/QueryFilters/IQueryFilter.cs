using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransisterBatch.EntityFramework.QueryFilters
{
    public interface IQueryFilter<TDomain>
    {
        bool Track { get; set; }
        bool IncludeInactiveRows { get; set; }

        IQueryable<TDomain> Where(IQueryable<TDomain> query);
    }
}
