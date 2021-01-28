using System.Windows;
using Atlas.Mvvm.ServiceAbstractions;
using Atlas.Mvvm.ViewModels.MainMenu;
using Atlas.Mvvm.ViewModels.Settings;
using Atlas.WPF.Services;
using Atlas.WPF.Views.MainMenu;
using Atlas.WPF.Views.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace Atlas.WPF.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterWpfServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<INotificationService, NotificationService>();
            serviceCollection.AddSingleton<IDialogService>(provider => new DialogService(((MainWindow)Application.Current.MainWindow).frDialog));
            serviceCollection.AddSingleton<INavigationService>(provider =>
            {
                var navigationService = new NavigationService(((MainWindow)Application.Current.MainWindow).frRoot, provider);
                navigationService.RegisterPage<MainMenuViewModel, MainMenuPage>();
                navigationService.RegisterPage<SettingsViewModel, SettingsPage>();
                navigationService.RegisterPage<RacingClassListViewModel, RacingClassListPage>();
                navigationService.RegisterPage<SaveRacingClassViewModel, SaveRacingClassPage>();
                return navigationService;
            });
        }
    }
}
