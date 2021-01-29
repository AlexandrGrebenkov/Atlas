using Atlas.Mvvm.Helpers;
using Atlas.Mvvm.ServiceAbstractions;
using Atlas.Mvvm.ViewModels.Settings.RacingClasses;
using Atlas.Mvvm.ViewModels.Settings.TrackSettings;

namespace Atlas.Mvvm.ViewModels.Settings
{
    public class SettingsViewModel : BaseViewModel
    {
        public override string Title => "Settings";

        private readonly INavigationService navigationService;

        public RelayCommand RacingClassesCommand { get; }
        public RelayCommand TrackSettingsCommand { get; }

        public SettingsViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            RacingClassesCommand = new RelayCommand(RacingClassesExecute);
            TrackSettingsCommand = new RelayCommand(TrackSettingsExecute);
        }

        private void TrackSettingsExecute()
        {
            navigationService.Push<TrackSettingsViewModel>();
        }

        private void RacingClassesExecute()
        {
            navigationService.Push<RacingClassListViewModel>();
        }
    }
}
