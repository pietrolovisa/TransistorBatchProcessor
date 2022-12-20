using OfficeOpenXml;
using System;
using System.Collections.Generic;

namespace TransisterBatchCore
{
    public interface IExcelWorkspace
    {
        ExcelPackage Package { get; }

        ActionResult Load(string path);
        ActionResult<List<string>> GetWorksheetNames();
        ActionResult<TransistorBatchDiscovery> LoadTransisterBatch(TransistorBatchLoadArgs workSheetArgs);
        ActionResult<TransistorBatchSave> GenerateDiscoveryWorksheet(TransistorBatchLoadArgs batchLoadArgs, TransistorBatchDiscovery transistorBatchDiscovery);
    }
}
