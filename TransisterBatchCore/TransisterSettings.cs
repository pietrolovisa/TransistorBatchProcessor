
namespace TransisterBatchCore
{
    public class TransisterSettings
    {
        public int Key { get; set; }
        public double HFE { get; set; }
        public double Beta { get; set; }

        public bool EndOfFile => Key == -1 && HFE == -1 && Beta == -1;
        public bool HasErrors => Key == -1 || HFE == -1 || Beta == -1;

        public override string ToString()
        {
            return $"{nameof(Key)} [{Key}] {nameof(HFE)} [{HFE}] {nameof(Beta)} [{Beta}]";
        }
    }
}
