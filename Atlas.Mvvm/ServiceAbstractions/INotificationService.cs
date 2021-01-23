namespace Atlas.Mvvm.ServiceAbstractions
{
    public interface INotificationService
    {
        void ShowMessage(string message, MessageType type = MessageType.Information);
        void Clear();
    }

    public enum MessageType
    {
        Information,
        Success,
        Warning,
        Error
    }
}
