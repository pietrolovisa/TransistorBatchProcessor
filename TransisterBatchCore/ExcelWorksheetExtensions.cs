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
    }
}
