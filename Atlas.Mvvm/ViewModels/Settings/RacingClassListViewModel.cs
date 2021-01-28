﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atlas.Domain.Entities;
using Atlas.Infrastructure.Abstraction.Interfaces;
using Atlas.Mvvm.Helpers;
using Atlas.Mvvm.ServiceAbstractions;
using Microsoft.EntityFrameworkCore;

namespace Atlas.Mvvm.ViewModels.Settings
{
    public class RacingClassListViewModel : BaseViewModel
    {
        public override string Title => "Racing classes";

        private readonly IAppDbContext dbContext;
        private readonly INavigationService navigationService;
        private readonly IDialogService dialogService;

        public RelayCommand EditCommand { get; }
        public RelayCommand DeleteCommand { get; }
        public IEnumerable<RacingClass> RacingClasses { get; private set; } = new List<RacingClass>();

        public RacingClassListViewModel(IAppDbContext dbContext, INavigationService navigationService, IDialogService dialogService)
        {
            this.dbContext = dbContext;
            this.navigationService = navigationService;
            this.dialogService = dialogService;

            EditCommand = new RelayCommand(EditExecute);
            DeleteCommand = new RelayCommand(DeleteExecute);

            RacingClasses = dbContext.RacingClasses.ToList();
            //RaisePropertyChanged(nameof(RacingClasses));
            //Task.Run(UpdateRacingClasses);
        }

        private async Task UpdateRacingClasses()
        {
            RacingClasses = await dbContext.RacingClasses.ToListAsync();
            RaisePropertyChanged(nameof(RacingClasses));
        }

        private void EditExecute()
        {
            throw new NotImplementedException();
        }

        private async void DeleteExecute()
        {
            var result = await dialogService.DisplayAlert("Удаление", $"Вы действительно хотите удалить класс ?", "Удалить", "Отмена");
            if (result)
            {

            }
        }
    }
}
