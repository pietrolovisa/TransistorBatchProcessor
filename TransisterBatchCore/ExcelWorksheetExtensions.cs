using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OfficeOpenXml;
using OfficeOpenXml.Style;
namespace TransisterBatchCore
{
    public static class ExcelWorksheetExtensions
    {
        public static int GetCellAsInt(this ExcelWorksheet worksheet, int row, int column)
        {
            string rawValue = worksheet.Cells[row, column].Value.ToString();
            _ = int.TryParse(rawValue, out int result);
            return result;
        }

        public static double GetCellAsDouble(this ExcelWorksheet worksheet, int row, int column)
        {
            string rawValue = worksheet.Cells[row, column].Value.ToString();
            _ = double.TryParse(rawValue, out double result);
            return result;
        }
    }
}
