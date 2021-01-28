using Atlas.Mvvm.Helpers;
using Atlas.Mvvm.ServiceAbstractions;

namespace Atlas.Mvvm.ViewModels.Settings
{
    public class SettingsViewModel : BaseViewModel
    {
        public override string Title => "Settings";

        private readonly INavigationService navigationService;

        public RelayCommand GoBackCommand { get; }

        public RelayCommand ShowWarningCommand { get; }
        public RelayCommand ShowDialogCommand { get; }

        public SettingsViewModel(INavigationService navigationService, INotificationService notificationService, IDialogService dialogService)
        {
            this.navigationService = navigationService;
            GoBackCommand = new RelayCommand(() => navigationService.Pop());
            ShowWarningCommand = new RelayCommand(() => notificationService.ShowMessage("Hello"));
            ShowDialogCommand = new RelayCommand(async () => await dialogService.DisplayAlert("Hello", "Message", "Ok", "Cancel"));
        }
    }
}
