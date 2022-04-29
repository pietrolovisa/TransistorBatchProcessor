using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using OfficeOpenXml;

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

        public ActionResult<TransistorBatchDiscovery> LoadTransisterBatch(TransistorBatchLoadArgs workSheetArgs)
        {
            ActionResult<TransistorBatchDiscovery> result = new ActionResult<TransistorBatchDiscovery>();
            try
            {
                result.Data = new TransistorBatchDiscovery();
                ExcelWorksheet worksheet = Package.Workbook.Worksheets[workSheetArgs.Name];
                if(worksheet != null)
                {
                    int index = workSheetArgs.StartRow;
                    bool endOfFile = false;
                    while (!endOfFile)
                    {
                        TransisterSettings transisterSettings = new TransisterSettings
                        {
                            Key = worksheet.GetCellAsInt(index, workSheetArgs.KeyColumn),
                            HFE = worksheet.GetCellAsDouble(index, workSheetArgs.HefColumn),
                            Beta = worksheet.GetCellAsDouble(index, workSheetArgs.BetaColumn)
                        };
                        endOfFile = transisterSettings.EndOfFile;
                        if (!endOfFile)
                        {
                            index++;
                            if (transisterSettings.HasErrors)
                            {
                                result.Data.Errors.Add(transisterSettings);
                            }
                            else
                            {
                                result.Data.Discovery.Add(transisterSettings);
                            }
                        }
                    }
                    result.Data.Discovery = new TransistorBatch(result.Data.Discovery.OrderBy(d => d.HFE));
                    result.Message = $"Successfully loaded batch data and found [{result.Data.Discovery.Count}] items";
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
