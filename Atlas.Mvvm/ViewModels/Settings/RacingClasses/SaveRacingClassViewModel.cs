using System.Linq;
using Atlas.Domain.Entities;
using Atlas.Infrastructure.Abstraction.Interfaces;
using Atlas.Mvvm.Helpers;
using Atlas.Mvvm.ServiceAbstractions;
using Microsoft.EntityFrameworkCore;

namespace Atlas.Mvvm.ViewModels.Settings.RacingClasses
{
    public class SaveRacingClassViewModel : BaseViewModel
    {
        public override string Title { get; }

        private readonly IAppDbContext dbContext;
        private readonly INavigationService navigationService;

        private int Id { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public RelayCommand SaveCommand { get; }

        public SaveRacingClassViewModel(IAppDbContext dbContext,
                                        INavigationService navigationService,
                                        RacingClass racingClass)
        {
            this.dbContext = dbContext;
            this.navigationService = navigationService;
            Id = racingClass.Id;
            Name = racingClass.Name;
            Description = racingClass.Description;

            Title = racingClass.Id == 0 ? "Добавление" : "Редактирование";

            SaveCommand = new RelayCommand(SaveExecute);
        }

        private async void SaveExecute()
        {
            var racingClass = await dbContext.RacingClasses
                .Where(_ => _.Id == Id)
                .FirstOrDefaultAsync();

            if (racingClass == null)
            {
                racingClass = new RacingClass();
                dbContext.RacingClasses.Add(racingClass);
            }

            racingClass.Name = Name;
            racingClass.Description = Description;

            await dbContext.SaveChangesAsync();

            navigationService.Pop(racingClass);
        }
    }
}
