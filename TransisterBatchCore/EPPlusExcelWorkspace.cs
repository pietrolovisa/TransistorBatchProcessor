using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace TransisterBatchCore
{
    internal class EPPlusExcelWorkspace : IExcelWorkspace
    {
        private ExcelPackage Package { get; set; }

        public EPPlusExcelWorkspace()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        public ActionResult Load(string path)
        {
            ActionResult result = new ActionResult();
            try
            {
                byte[] bin = File.ReadAllBytes(path);
                using MemoryStream stream = new MemoryStream(bin);
                Package = new ExcelPackage(stream);
                result.Message = $"Successfully loaded excel file and found {Package?.Workbook?.Worksheets?.Count} worksheet(s).";
            }
            catch (Exception ex)
            {
                result.SetError(ex, $"Failed to load excel file [{path}]");
            }
            return result;
        }

        public ActionResult<List<string>> GetWorksheetNames()
        {
            ActionResult<List<string>> result = new ActionResult<List<string>>();
            
            try
            {
                result.Data = new List<string>();
                foreach (ExcelWorksheet worksheet in Package.Workbook.Worksheets)
                {
                    result.Data.Add(worksheet.Name);
                }
            }
            catch (Exception ex)
            {
                result.SetError(ex, $"Failed to iterate excel worksheets");
            }
            return result;
        }

        public ActionResult<TransistorBatch> LoadTransisterBatch(TransisterWorkSheetArgs workSheetArgs)
        {
            ActionResult<TransistorBatch> result = new ActionResult<TransistorBatch>();
            try
            {
                result.Data = new TransistorBatch();
                ExcelWorksheet worksheet = Package.Workbook.Worksheets[workSheetArgs.Name];
                if(worksheet != null)
                {
                    for (int i = workSheetArgs.StartRow; i <= workSheetArgs.EndRow; i++)
                    {
                        result.Data.Add(new TransisterSettings
                        {
                            Key = worksheet.GetCellAsInt(i, workSheetArgs.KeyColumn),
                            HFE = worksheet.GetCellAsDouble(i, workSheetArgs.HefColumn),
                            Beta = worksheet.GetCellAsDouble(i, workSheetArgs.BetaColumn)
                        });
                    }
                    result.Data = new TransistorBatch(result.Data.OrderBy(d => d.HFE));
                    result.Message = $"Successfully loaded batch data and found [{result.Data.Count}] items";
                }
            }
            catch (Exception ex)
            {
                result.SetError(ex, $"Failed to load transister batch data");
            }
            return result;
        }
    }
}
