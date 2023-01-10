
namespace TransistorBatchProcessor
{
    public enum EventType
    {
        Empty,
        BatchItemChanged,
        BatchTypeItemChanged
    }

    delegate void RaiseNotifyDelegate(NotificationEventArgs args);

    public class NotificationEventArgs : EventArgs
    {
        public static NotificationEventArgs BatchItemChanged(Command command = Command.None, object entity = null) => new NotificationEventArgs
        { 
            Event = EventType.BatchItemChanged,
            Command = command,
            Entity = entity
        };

        public static NotificationEventArgs BatchTypeItemChanged(Command command = Command.None, object entity = null) => new NotificationEventArgs
        { 
            Event = EventType.BatchTypeItemChanged, 
            Command = command,
            Entity = entity
        };

        public EventType Event { get; set; } = EventType.Empty;
        public Command Command { get; set; } = Command.None;
        public object Entity { get; set; }

        public NotificationEventArgs()
        {
        }
    }
}
