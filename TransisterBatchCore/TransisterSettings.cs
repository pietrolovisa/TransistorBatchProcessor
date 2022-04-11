using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
