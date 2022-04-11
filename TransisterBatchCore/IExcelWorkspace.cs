using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransisterBatchCore
{
    public interface IExcelWorkspace
    {
        ActionResult Load(string path);
        ActionResult<List<string>> GetWorksheetNames();
        ActionResult<TransistorBatch> LoadTransisterBatch(TransisterWorkSheetArgs workSheetArgs);
    }
}
