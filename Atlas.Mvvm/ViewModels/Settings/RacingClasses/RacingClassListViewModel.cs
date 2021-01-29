using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Atlas.Domain.Entities;
using Atlas.Infrastructure.Abstraction.Interfaces;
using Atlas.Mvvm.Helpers;
using Atlas.Mvvm.ServiceAbstractions;
using Microsoft.EntityFrameworkCore;

namespace Atlas.Mvvm.ViewModels.Settings.RacingClasses
{
    public class RacingClassListViewModel : BaseViewModel
    {
        public override string Title => "Racing classes";

        private readonly IAppDbContext dbContext;
        private readonly INavigationService navigationService;
        private readonly IDialogService dialogService;

        public RelayCommand AddCommand { get; }
        public RelayCommand<RacingClass> EditCommand { get; }
        public RelayCommand<RacingClass> DeleteCommand { get; }
        public ObservableCollection<RacingClass> RacingClasses { get; private set; }

        public RacingClassListViewModel(IAppDbContext dbContext, INavigationService navigationService, IDialogService dialogService)
        {
            this.dbContext = dbContext;
            this.navigationService = navigationService;
            this.dialogService = dialogService;

            AddCommand = new RelayCommand(AddExecute);
            EditCommand = new RelayCommand<RacingClass>(EditExecute);
            DeleteCommand = new RelayCommand<RacingClass>(DeleteExecute);

            Task.Run(UpdateRacingClasses);
        }

        private async void AddExecute()
        {
            var racingClass = new RacingClass();
            racingClass = (RacingClass)await navigationService.PushAsync<SaveRacingClassViewModel>(racingClass);
            if (racingClass != null)
            {
                RacingClasses.Add(racingClass);
            }
        }

        private async Task UpdateRacingClasses()
        {
            RacingClasses = new ObservableCollection<RacingClass>(await dbContext.RacingClasses.ToListAsync());
            RaisePropertyChanged(nameof(RacingClasses));
        }

        private async void EditExecute(RacingClass racingClass)
        {
            racingClass = (RacingClass)await navigationService.PushAsync<SaveRacingClassViewModel>(racingClass);
            if (racingClass != null)
            {
                await UpdateRacingClasses();
            }
        }

        private async void DeleteExecute(RacingClass racingClass)
        {
            var result = await dialogService.DisplayAlert("Удаление", $"Вы действительно хотите удалить класс {racingClass.Name}?", "Удалить", "Отмена");
            if (result)
            {
                dbContext.RacingClasses.Remove(racingClass);
                await dbContext.SaveChangesAsync();
                RacingClasses.Remove(racingClass);
            }
        }
    }
}
