using System;

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
