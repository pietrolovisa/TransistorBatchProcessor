
namespace TransistorBatchProcessor
{
    public enum TransistorState
    {
        Matched,
        Unmatched
    }

    public class TransistorStateItem
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public TransistorState State { get; private set; } = TransistorState.Unmatched;

        private TransistorStateItem()
        {
        }

        public static TransistorStateItem Matched => new TransistorStateItem
        {
            Id = 0,
            Name = TransistorState.Matched.ToString(),
            State = TransistorState.Matched
        };

        public static TransistorStateItem Unmatched => new TransistorStateItem
        {
            Id = 1,
            Name = TransistorState.Unmatched.ToString(),
            State = TransistorState.Unmatched
        };

        public static List<TransistorStateItem> All => new List<TransistorStateItem>
        {
            Unmatched,
            Matched
        };
    }
}
