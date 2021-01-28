using System;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using Atlas.Mvvm.ServiceAbstractions;
using Atlas.Mvvm.ViewModels;
using Atlas.WPF.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Atlas.WPF
{
    public partial class MainWindow : Window
    {
        private readonly INavigationService navigationService;

        public MainWindow()
        {
            InitializeComponent();
            var compositionRoot = new CompositionRoot();
            compositionRoot.ConfigureAndRun();
            navigationService = compositionRoot.ServiceProvider.GetRequiredService<INavigationService>();
        }

        private void FrRoot_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            var animation = new ThicknessAnimation
            {
                Duration = TimeSpan.FromSeconds(0.3),
                DecelerationRatio = 0.7,
                To = new Thickness(0, 0, 0, 0)
            };

            if (e.NavigationMode == NavigationMode.New)
                animation.From = new Thickness(500, 0, 0, 0);
            else if (e.NavigationMode == NavigationMode.Back)
                animation.From = new Thickness(0, 0, 500, 0);

            if (e.Content is NavigationPage page)
            {
                UpdateToolbarItems(page);
                UpdateTitle(page);
                page.BeginAnimation(MarginProperty, animation);
            }
        }

        private void UpdateTitle(NavigationPage page)
        {
            if (page.DataContext is BaseViewModel vm)
            {
                Title.Text = vm.Title;
            }
        }

        private void UpdateToolbarItems(NavigationPage page)
        {
            ToolbarItems.Children.Clear();
            if (page.ToolbarItems != null)
            {
                ToolbarItems.Children.Add(page.ToolbarItems);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            navigationService.Pop();
        }

        private void frRoot_Navigated(object sender, NavigationEventArgs e)
        {
            BackButton.Visibility = frRoot.CanGoBack ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
