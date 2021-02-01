using Atlas.Mvvm.Helpers;
using Atlas.Mvvm.ServiceAbstractions;

namespace Atlas.Mvvm.ViewModels.Race
{
    public class RaceViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;
        public override string Title => "Race";

        public RelayCommand StartNewRaceCommand { get; }

        public RaceViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            StartNewRaceCommand = new RelayCommand(StartNewRaceCommandExecute);
        }

        private void StartNewRaceCommandExecute()
        {
            
        }
    }
}
