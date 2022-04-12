using System;

namespace TransisterBatchCore
{
    public class TransistorBatchLoadArgs
    {
        public string Name { get; set; }
        public int StartRow { get; set; } = 2;
        public int EndRow { get; set; } = 101;
        public int KeyColumn { get; set; } = 1;
        public int HefColumn { get; set; } = 2;
        public int BetaColumn { get; set; } = 3;
        public double BetaTolerance { get; set; } = 0.001;
    }
}
