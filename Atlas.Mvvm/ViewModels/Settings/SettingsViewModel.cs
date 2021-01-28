using Atlas.Mvvm.Helpers;
using Atlas.Mvvm.ServiceAbstractions;

namespace Atlas.Mvvm.ViewModels.Settings
{
    public class SettingsViewModel : BaseViewModel
    {
        public override string Title => "Settings";

        private readonly INavigationService navigationService;

        public RelayCommand GoBackCommand { get; }

        public RelayCommand RacingClassesCommand { get; }

        public SettingsViewModel(INavigationService navigationService, INotificationService notificationService, IDialogService dialogService)
        {
            this.navigationService = navigationService;
            GoBackCommand = new RelayCommand(() => navigationService.Pop());
            RacingClassesCommand = new RelayCommand(RacingClassesExecute);
        }

        private void RacingClassesExecute()
        {
            navigationService.Push<RacingClassListViewModel>();
        }
    }
}
