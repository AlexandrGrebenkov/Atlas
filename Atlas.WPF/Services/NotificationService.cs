using System;
using System.Windows;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Lifetime.Clear;
using ToastNotifications.Messages;
using ToastNotifications.Position;
using Atlas.Mvvm.ServiceAbstractions;

namespace Atlas.WPF.Services
{
    internal class NotificationService : INotificationService
    {
        private readonly Notifier notifier = new Notifier(cfg =>
        {
            cfg.PositionProvider = new WindowPositionProvider(
                parentWindow: Application.Current.MainWindow,
                corner: Corner.BottomRight,
                offsetX: 10,
                offsetY: 10);

            cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                notificationLifetime: TimeSpan.FromSeconds(3),
                maximumNotificationCount: MaximumNotificationCount.FromCount(5));

            cfg.Dispatcher = Application.Current.Dispatcher;
        });

        public void Clear()
        {
            notifier.ClearMessages(new ClearAll());
        }

        public void ShowMessage(string message, MessageType type = MessageType.Information)
        {
            Application.Current.Dispatcher.BeginInvoke((Action)(() =>
            {
                switch (type)
                {
                    case MessageType.Information:
                        notifier.ShowInformation(message);
                        break;
                    case MessageType.Success:
                        notifier.ShowSuccess(message);
                        break;
                    case MessageType.Warning:
                        notifier.ShowWarning(message);
                        break;
                    case MessageType.Error:
                        notifier.ShowError(message);
                        break;
                }
            }));
        }
    }
}
