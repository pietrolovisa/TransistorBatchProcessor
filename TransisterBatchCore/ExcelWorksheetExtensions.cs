using System;
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
    }
}
