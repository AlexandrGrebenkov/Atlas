using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using Atlas.WPF.Views;

namespace Atlas.WPF.Resources.Controls
{
    public partial class NavigationFrame : Frame
    {
        public NavigationFrame()
        {
            InitializeComponent();
        }

        private void OnNavigating(object sender, NavigatingCancelEventArgs e)
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
                page.BeginAnimation(MarginProperty, animation);
        }
    }
}
