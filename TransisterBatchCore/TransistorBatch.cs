using System.Linq;
using System.Collections.Generic;

namespace TransisterBatchCore
{
    public class TransistorBatchDiscovery
    {
        public TransistorBatch Discovery { get; set; } = new TransistorBatch();
        public TransistorBatch Errors { get; set; } = new TransistorBatch();
    }

    public class TransistorBatch : List<TransisterSettings>
    {
        public TransistorBatch()
        {
        }

        public TransistorBatch(IEnumerable<TransisterSettings> seed)
            : base(seed)
        {
        }

        public List<List<TransisterSettings>> Process(TransistorBatchLoadArgs args)
        {
            List<List<TransisterSettings>> batches = this
                .GroupBy(ts => ts, new ToleranceEqualityComparer
                {
                    BetaTolerance = args.BetaTolerance,
                    HefTolerance = args.HefTolerance
                })
                .Select(grp => grp.ToList())
                .OrderByDescending(grp => grp.Count)
                .ToList();
            return batches;
        }
    }

    public class ToleranceEqualityComparer : IEqualityComparer<TransisterSettings>
    {
        public double BetaTolerance { get; set; } = 0.001;
        public double HefTolerance { get; set; } = 0;

        public bool Equals(TransisterSettings x, TransisterSettings y)
        {
            return x.HFE == y.HFE &&
                x.Beta - BetaTolerance <= y.Beta && x.Beta + BetaTolerance > y.Beta;
        }

        //This is to force the use of Equals methods.
        public int GetHashCode(TransisterSettings obj) => 1;
    }
}
