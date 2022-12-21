using System.Linq;
using System.Collections.Generic;

namespace TransisterBatchCore
{
    public class TransistorBatchSave
    {
        public string OutliersWorksheet { get; set; }
        public string MatchesWorksheet { get; set; }
    }

    public class TransistorBatchDiscovery
    {
        public int ItemCount { get; set; }
        public TransistorBatch Discovery { get; set; } = new TransistorBatch();
        public TransistorBatch Errors { get; set; } = new TransistorBatch();
        public List<TransistorBatch> Matches { get; set; } = new List<TransistorBatch>();
        public List<TransistorBatch> Outliers { get; set; } = new List<TransistorBatch>();

        public bool HasErrors => (Errors?.Count ?? 0) > 0;
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

        public List<TransistorBatch> Process(TransistorBatchLoadArgs args)
        {
            List<TransistorBatch> batches = this
                .GroupBy(ts => ts, new ToleranceEqualityComparer
                {
                    BetaTolerance = args.BetaTolerance,
                    HefTolerance = args.HefTolerance
                })
                .Select(grp => new TransistorBatch(grp.ToList()))
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

        public int GetHashCode(TransisterSettings obj) => 1;
    }
}
