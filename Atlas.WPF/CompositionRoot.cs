using System;
using System.IO;
using System.Windows;
using Atlas.DataAccess.Extensions;
using Atlas.Infrastructure.Implementation.Extensions;
using Atlas.Mvvm.Extensions;
using Atlas.Mvvm.ServiceAbstractions;
using Atlas.Mvvm.ViewModels.MainMenu;
using Atlas.WPF.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Atlas.WPF
{
    internal class CompositionRoot
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public IConfiguration Configuration { get; private set; }

        public void ConfigureAndRun()
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();

            var navigation = ServiceProvider.GetRequiredService<INavigationService>();
            navigation.Push<MainMenuViewModel>();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.RegisterDataAccess();
            services.RegisterMvvm();
            services.RegisterInfrastructure();
            services.RegisterWpfServices();
        }
    }
}
