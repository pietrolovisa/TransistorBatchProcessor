using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using OfficeOpenXml;

namespace TransisterBatchCore
{
    internal class EPPlusExcelWorkspace : IExcelWorkspace
    {
        private FileInfo File { get; set; } 
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
                File = new FileInfo(path);
                if (File.Exists)
                {
                    Package = new ExcelPackage(File);
                }
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

        public ActionResult GenerateDiscoveryWorksheet(TransistorBatchLoadArgs batchLoadArgs, TransistorBatchDiscovery transistorBatchDiscovery)
        {
            ActionResult result = new ActionResult();
            try
            {
                int discoveryIndex = batchLoadArgs.StartRow;
                int outlierIndex = batchLoadArgs.StartRow;
                ExcelWorksheet discoveryWorksheet = Package.Workbook.Worksheets.Add(
                    Package.CreateUniqueNameWorksheetName($"{batchLoadArgs.Name}_discovery"));
                discoveryWorksheet.AddHeader(batchLoadArgs);
                ExcelWorksheet outlierWorksheet = Package.Workbook.Worksheets.Add(
                    Package.CreateUniqueNameWorksheetName($"{batchLoadArgs.Name}_outliers"));
                outlierWorksheet.AddHeader(batchLoadArgs);
                List<List<TransisterSettings>> batches = transistorBatchDiscovery.Discovery.Process(batchLoadArgs);
                foreach (List<TransisterSettings> batch in batches)
                {
                    if (batch.Count == 1)
                    {
                        outlierWorksheet.AppendTransisterSettings(batchLoadArgs, batch[0], outlierIndex++);
                    }
                    else if (batch.Count > 1)
                    {
                        discoveryWorksheet.AddMatchHeader(batch.Count, batchLoadArgs, discoveryIndex++);
                        foreach (TransisterSettings match in batch)
                        {
                            discoveryWorksheet.AppendTransisterSettings(batchLoadArgs, match, discoveryIndex++);
                        }
                    }
                }
                Package.Save();
            }
            catch (Exception ex)
            {
                result.SetError(ex, $"Failed to generate discovery worksheet [{batchLoadArgs.Name}]");
            }
            return result;
        }
    }
}
