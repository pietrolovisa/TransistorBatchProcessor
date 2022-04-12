using System;
using System.Collections.Generic;

namespace TransisterBatchCore
{
    public interface IExcelWorkspace
    {
        ActionResult Load(string path);
        ActionResult<List<string>> GetWorksheetNames();
        ActionResult<TransistorBatch> LoadTransisterBatch(TransistorBatchLoadArgs workSheetArgs);
    }
}
