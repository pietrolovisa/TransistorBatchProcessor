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
        public ExcelPackage Package { get; private set; }

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

        public ActionResult<TransistorBatchDiscovery> LoadTransisterBatch(TransistorBatchLoadArgs batchLoadArgs)
        {
            ActionResult<TransistorBatchDiscovery> result = new ActionResult<TransistorBatchDiscovery>();
            try
            {
                result.Data = new TransistorBatchDiscovery();
                ExcelWorksheet worksheet = Package.Workbook.Worksheets[batchLoadArgs.Name];
                if(worksheet != null)
                {
                    int index = batchLoadArgs.StartRow;
                    bool endOfFile = false;
                    while (!endOfFile)
                    {
                        TransisterSettings transisterSettings = new TransisterSettings
                        {
                            Key = worksheet.GetCellAsInt(index, batchLoadArgs.KeyColumn),
                            HFE = worksheet.GetCellAsDouble(index, batchLoadArgs.HefColumn),
                            Beta = worksheet.GetCellAsDouble(index, batchLoadArgs.BetaColumn)
                        };
                        endOfFile = transisterSettings.EndOfFile;
                        if (!endOfFile)
                        {
                            result.Data.ItemCount++;
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
                    List<TransistorBatch> batches = result.Data.Discovery.Process(batchLoadArgs);
                    result.Data.Matches = batches
                        .Where(b => b.Count > 1)
                        .OrderBy(b => b[0].Key)
                        .ToList();
                    result.Data.Outliers = batches
                        .Where(b => b.Count == 1)
                        .OrderBy(b => b[0].Key)
                        .ToList();
                    result.Message = $"Successfully loaded batch data and found [{result.Data.Discovery.Count}] items";
                }
            }
            catch (Exception ex)
            {
                result.SetError(ex, $"Failed to load transister batch data");
            }
            return result;
        }

        public ActionResult<TransistorBatchSave> GenerateDiscoveryWorksheet(TransistorBatchLoadArgs batchLoadArgs, TransistorBatchDiscovery transistorBatchDiscovery)
        {
            ActionResult<TransistorBatchSave> result = new ActionResult<TransistorBatchSave>();
            try
            {
                result.Data = new TransistorBatchSave();
                int discoveryIndex = batchLoadArgs.StartRow;
                int outlierIndex = batchLoadArgs.StartRow;
                result.Data.OutliersWorksheet = Package.CreateUniqueNameWorksheetName($"{batchLoadArgs.Name}_outliers");
                result.Data.MatchesWorksheet = Package.CreateUniqueNameWorksheetName($"{batchLoadArgs.Name}_discovery");
                ExcelWorksheet discoveryWorksheet = Package.Workbook.Worksheets.Add(result.Data.MatchesWorksheet);
                discoveryWorksheet.AddHeader(batchLoadArgs);
                ExcelWorksheet outlierWorksheet = Package.Workbook.Worksheets.Add(result.Data.OutliersWorksheet);
                outlierWorksheet.AddHeader(batchLoadArgs);
                foreach (TransistorBatch outlierBatch in transistorBatchDiscovery.Outliers)
                {
                    outlierWorksheet.AppendTransisterSettings(batchLoadArgs, outlierBatch[0], outlierIndex++);
                }
                foreach (TransistorBatch discoveryBatch in transistorBatchDiscovery.Matches)
                {
                    discoveryWorksheet.AddMatchHeader(discoveryBatch.Count, batchLoadArgs, discoveryIndex++);
                    foreach (TransisterSettings match in discoveryBatch)
                    {
                        discoveryWorksheet.AppendTransisterSettings(batchLoadArgs, match, discoveryIndex++);
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
