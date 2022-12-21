using OfficeOpenXml;
using System.Collections.Generic;

namespace TransisterBatchCore
{
    public interface IExcelWorkspace
    {
        ExcelPackage Package { get; }

        ActionResult Load(string path);
        ActionResult<List<string>> GetWorksheetNames();
        ActionResult<TransistorBatchDiscovery> GenerateTransisterManifest(TransistorBatchLoadArgs workSheetArgs);
        ActionResult<TransistorBatchSave> GenerateDiscoveryWorksheets(TransistorBatchLoadArgs batchLoadArgs, TransistorBatchDiscovery transistorBatchDiscovery);
    }
}
