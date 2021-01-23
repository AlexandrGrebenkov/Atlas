using Atlas.Mvvm.Helpers;
using Atlas.Mvvm.ServiceAbstractions;
using Atlas.Mvvm.ViewModels.Settings;

namespace Atlas.Mvvm.ViewModels.MainMenu
{
    public class MainMenuViewModel : BaseViewModel
    {
        public string Title => "Main Menu";

        private readonly INavigationService navigationService;

        public RelayCommand OpenSettingsPageCommand { get; }

        public MainMenuViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            OpenSettingsPageCommand = new RelayCommand(() => this.navigationService.Push<SettingsViewModel>());
        }
    }
}
