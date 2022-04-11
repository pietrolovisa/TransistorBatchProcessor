using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransisterBatchCore
{
    public class TransisterWorkSheetArgs
    {
        public string Name { get; set; }
        public int StartRow { get; set; } = 2;
        public int EndRow { get; set; } = 101;
        public int KeyColumn { get; set; } = 1;
        public int HefColumn { get; set; } = 2;
        public int BetaColumn { get; set; } = 3;
    }
}
