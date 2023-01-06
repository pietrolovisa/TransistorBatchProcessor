using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransisterBatchCore;

namespace TransistorBatchProcessor
{
    public enum EventType
    {
        Empty,
        BatchAdded,
        BatchRemoved,
        BatchTypeItemChanged
    }

    delegate void RaiseNotifyDelegate(NotificationEventArgs args);

    public class NotificationEventArgs : EventArgs
    {
        public static NotificationEventArgs BatchAdded => new NotificationEventArgs() { Event = EventType.BatchAdded };
        public static NotificationEventArgs BatchRemoved => new NotificationEventArgs() { Event = EventType.BatchRemoved };
        public static NotificationEventArgs BatchTypeItemChanged => new NotificationEventArgs() { Event = EventType.BatchTypeItemChanged };

        public EventType Event { get; set; } = EventType.Empty;
        public object Entity { get; set; }

        public NotificationEventArgs()
        {
        }
    }
}
