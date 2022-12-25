using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransisterBatch.EntityFramework.Domain;

namespace TransisterBatchCore
{
    public interface IBatchProcessor
    {
        ActionResult<TransistorGroupDiscovery> GenerateTransisterManifest(Batch batch, TransistorGroupLoadArgs workSheetArgs);
    }

    public class BatchProcessor : IBatchProcessor
    {
        public ActionResult<TransistorGroupDiscovery> GenerateTransisterManifest(Batch batch, TransistorGroupLoadArgs groupLoadArgs)
        {
            ActionResult<TransistorGroupDiscovery> result = new ActionResult<TransistorGroupDiscovery>();
            try
            {
                result.Data = new TransistorGroupDiscovery();
                foreach (Transistor transistor in batch.Transistors)
                {
                    result.Data.Discovery.Add(transistor);
                }
                result.Data.Discovery = new TransistorGroup(result.Data.Discovery.OrderBy(d => d.HEF));
                List<TransistorGroup> batches = result.Data.Discovery.Process(groupLoadArgs);
                result.Data.Matches = batches
                    .Where(b => b.Count > 1)
                    .OrderBy(b => b[0].Idx)
                    .ToList();
                result.Data.Outliers = batches
                    .Where(b => b.Count == 1)
                    .OrderBy(b => b[0].Idx)
                    .ToList();
                result.Message = $"Successfully loaded batch data and found [{result.Data.Discovery.Count}] items";
            }
            catch (Exception ex)
            {
                result.SetError(ex, $"Failed to load transister batch data");
            }
            return result;
        }
    }

    public class TransistorGroupLoadArgs
    {
        public double BetaTolerance { get; set; } = 0.001;
        public int HefTolerance { get; set; } = 0;
    }

    public class TransistorGroupDiscovery
    {
        public int ItemCount { get; set; }
        public TransistorGroup Discovery { get; set; } = new TransistorGroup();
        public TransistorGroup Errors { get; set; } = new TransistorGroup();
        public List<TransistorGroup> Matches { get; set; } = new List<TransistorGroup>();
        public List<TransistorGroup> Outliers { get; set; } = new List<TransistorGroup>();

        public bool HasErrors => (Errors?.Count ?? 0) > 0;
    }

    public class TransistorGroup : List<Transistor>
    {
        public TransistorGroup()
        {
        }

        public TransistorGroup(IEnumerable<Transistor> seed)
            : base(seed)
        {
        }

        public List<TransistorGroup> Process(TransistorGroupLoadArgs args)
        {
            List<TransistorGroup> batches = this
                .GroupBy(ts => ts, new TransistorEqualityComparer
                {
                    BetaTolerance = args.BetaTolerance,
                    HefTolerance = args.HefTolerance
                })
                .Select(grp => new TransistorGroup(grp.ToList()))
                .OrderByDescending(grp => grp.Count)
                .ToList();
            return batches;
        }
    }

    public class TransistorEqualityComparer : IEqualityComparer<Transistor>
    {
        public double BetaTolerance { get; set; } = 0.001;
        public double HefTolerance { get; set; } = 0;

        public bool Equals(Transistor x, Transistor y)
        {
            return x.HEF == y.HEF &&
                x.Beta - BetaTolerance <= y.Beta && x.Beta + BetaTolerance > y.Beta;
        }

        public int GetHashCode(Transistor obj) => 1;
    }
}
