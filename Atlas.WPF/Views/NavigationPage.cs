using System.Windows;
using System.Windows.Controls;

namespace Atlas.WPF.Views
{
    public abstract class NavigationPage : Page
    {
        public StackPanel ToolbarItems
        {
            get { return (StackPanel)GetValue(ToolbarItemsProperty); }
            set { SetValue(ToolbarItemsProperty, value); }
        }

        public static readonly DependencyProperty ToolbarItemsProperty =
            DependencyProperty.Register("Toolbar", typeof(StackPanel), typeof(NavigationPage), new PropertyMetadata(null));
    }
}
