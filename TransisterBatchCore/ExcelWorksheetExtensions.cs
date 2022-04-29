using System;
using System.Linq;
using System.Collections.Generic;
using OfficeOpenXml;

namespace TransisterBatchCore
{
    public static class ExcelWorksheetExtensions
    {
        public static int GetCellAsInt(this ExcelWorksheet worksheet, int row, int column)
        {
            string rawValue = worksheet.Cells[row, column]?.Value?.ToString();
            int result = -1;
            if (rawValue != null)
            {
                _ = int.TryParse(rawValue, out result);
            }
            return result;
        }

        public static double GetCellAsDouble(this ExcelWorksheet worksheet, int row, int column)
        {
            string rawValue = worksheet.Cells[row, column]?.Value?.ToString();
            double result = -1;
            if (rawValue != null)
            {
                _ = double.TryParse(rawValue, out result);
            }
            return result;
        }

        public static void AddHeader(this ExcelWorksheet worksheet, TransistorBatchLoadArgs batchLoadArgs, int row = 1)
        {
            worksheet.Cells[row, batchLoadArgs.KeyColumn].Value = "TRANSISTOR";
            worksheet.Cells[row, batchLoadArgs.HefColumn].Value = "HFE";
            worksheet.Cells[row, batchLoadArgs.BetaColumn].Value = "Beta";
        }

        public static void AddMatchHeader(this ExcelWorksheet worksheet, int count, TransistorBatchLoadArgs batchLoadArgs, int row)
        {
            worksheet.Cells[row, batchLoadArgs.KeyColumn].Value = $"Found [{count}] matches...";
        }

        public static void AppendTransisterSettings(this ExcelWorksheet worksheet, TransistorBatchLoadArgs batchLoadArgs, TransisterSettings transisterSettings, int row)
        {
            worksheet.Cells[row, batchLoadArgs.KeyColumn].Value = transisterSettings.Key;
            worksheet.Cells[row, batchLoadArgs.HefColumn].Value = transisterSettings.HFE;
            worksheet.Cells[row, batchLoadArgs.BetaColumn].Value = transisterSettings.Beta;
        }

        public static string CreateUniqueNameWorksheetName(this ExcelPackage Package, string worksheetName, int maxAttempts = 1024)
        {
            List<string> existingNames = Package.Workbook.Worksheets.Where(w => w.Name.StartsWith(worksheetName)).Select(w => w.Name).ToList();
            if (existingNames.Count > 0)
            {
                for (var index = 2; index < maxAttempts; index++)
                {
                    string nextIndex = $"{worksheetName} - ({index})";
                    if (existingNames.Contains(nextIndex))
                    {
                        continue;
                    }
                    return nextIndex;
                }
            }
            else
            {
                return worksheetName;
            }
            throw new Exception("Could not create unique filename in " + maxAttempts + " attempts");
        }
    }
}
