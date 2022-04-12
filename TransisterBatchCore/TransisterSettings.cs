using System;

namespace TransisterBatchCore
{
    public class TransisterSettings
    {
        public int Key { get; set; }
        public double HFE { get; set; }
        public double Beta { get; set; }

        public override string ToString()
        {
            return $"{nameof(Key)} [{Key}] {nameof(HFE)} [{HFE}] {nameof(Beta)} [{Beta}]";
        }
    }
}
