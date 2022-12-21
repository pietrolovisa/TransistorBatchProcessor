
namespace TransisterBatchCore
{
    public class TransisterSettings
    {
        public const string INVALID = "INVALID";

        public int Key { get; set; }
        public double HFE { get; set; }
        public double Beta { get; set; }

        public TransisterSettingsSource Source { get; set; } = TransisterSettingsSource.Unknown;

        public bool EndOfFile => Key == -1 && HFE == -1 && Beta == -1;
        public bool HasErrors => Key == -1 || HFE == -1 || Beta == -1;

        public override string ToString()
        {
            return $"{nameof(Key)} [{(Key == -1 ? INVALID : Key)}] {nameof(HFE)} [{(HFE == -1 ? INVALID : HFE)}] {nameof(Beta)} [{(Beta == -1 ? INVALID : Beta)}]";
        }
    }

    public class TransisterSettingsSource
    {
        public string Name { get; set; }
        public int Row { get; set; }

        public static TransisterSettingsSource Unknown => new TransisterSettingsSource
        {
            Name = TransisterSettings.INVALID,
            Row = -1
        };
    }
}
