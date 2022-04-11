using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransisterBatchCore
{
    public static class ExcelWorkspaceFactory
    {
        public static IExcelWorkspace CreateWorkspace()
        {
            return new EPPlusExcelWorkspace();
        }
    }
}
