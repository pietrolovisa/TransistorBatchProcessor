using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransisterBatchCore
{
    public class TransistorBatch : List<TransisterSettings>
    {
        public TransistorBatch()
        {
        }

        public TransistorBatch(IEnumerable<TransisterSettings> seed)
            : base(seed)
        {
        }

        public List<List<TransisterSettings>> Process()
        {
            List<List<TransisterSettings>> batches = this
                .GroupBy(ts => ts, new ToleranceEqualityComparer())
                .Select(grp => grp.ToList())
                .ToList();
            return batches;
        }
    }

    public class ToleranceEqualityComparer : IEqualityComparer<TransisterSettings>
    {
        public double Tolerance { get; set; } = 0.001;
        public bool Equals(TransisterSettings x, TransisterSettings y)
        {
            return x.HFE == y.HFE &&
                x.Beta - Tolerance <= y.Beta && x.Beta + Tolerance > y.Beta;
        }

        //This is to force the use of Equals methods.
        public int GetHashCode(TransisterSettings obj) => 1;
    }
}
