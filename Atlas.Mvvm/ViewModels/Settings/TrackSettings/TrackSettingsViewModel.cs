using Atlas.Mvvm.Helpers;
using Atlas.Mvvm.ServiceAbstractions;

namespace Atlas.Mvvm.ViewModels.Settings.TrackSettings
{
    public class TrackSettingsViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;
        public override string Title => "Параметры трассы";
        public TrackSettingsModel Model { get; }
        public RelayCommand SaveCommand { get; }

        public TrackSettingsViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            Model = new TrackSettingsModel(); // TODO: Load from settings
            SaveCommand = new RelayCommand(SaveExecute);
        }

        private void SaveExecute()
        {
            // TODO: Do save
            navigationService.Pop();
        }
    }
}
