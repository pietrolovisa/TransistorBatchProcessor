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
        ActionResult<TransistorGroupDiscovery> GenerateTransisterManifest(List<Transistor> transistors, TransistorGroupLoadArgs workSheetArgs);
    }

    public class BatchProcessor : IBatchProcessor
    {
        public ActionResult<TransistorGroupDiscovery> GenerateTransisterManifest(List<Transistor> transistors, TransistorGroupLoadArgs groupLoadArgs)
        {
            ActionResult<TransistorGroupDiscovery> result = new ActionResult<TransistorGroupDiscovery>();
            try
            {
                result.Data = new TransistorGroupDiscovery();
                foreach (Transistor transistor in transistors)
                {
                    result.Data.Discovery.Add(transistor);
                }
                result.Data.Discovery = new TransistorGroup(result.Data.Discovery.OrderBy(d => d.HEF));
                List<TransistorGroup> batches = result.Data.Discovery.Process(groupLoadArgs);
                result.Data.Matches = batches
                    .Where(b => b.Count > 1)
                    //.OrderBy(b => b[0].Idx)
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

    public class TransistorGroupDiscovery
    {
        public int ItemCount { get; set; }
        public TransistorGroup Discovery { get; set; } = new TransistorGroup();
        public TransistorGroup Errors { get; set; } = new TransistorGroup();
        public List<TransistorGroup> Matches { get; set; } = new List<TransistorGroup>();
        public List<TransistorGroup> Outliers { get; set; } = new List<TransistorGroup>();

        public bool HasErrors => (Errors?.Count ?? 0) > 0;
    }
}
