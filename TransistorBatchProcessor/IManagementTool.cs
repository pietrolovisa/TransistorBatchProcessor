
namespace TransistorBatchProcessor
{
    public interface IManagementTool
    {
        string DisplayName { get; }

        void InitializeView();
        void HandleEvent(NotificationEventArgs args);

        event EventHandler<NotificationEventArgs> OnNotify;
    }
}
