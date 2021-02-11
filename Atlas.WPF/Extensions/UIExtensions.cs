using System.Windows;
using System.Windows.Controls;

namespace Atlas.WPF.Extensions
{
    public class UIExtensions : DependencyObject
    {
        public static readonly DependencyProperty PanelItemsMarginProperty = DependencyProperty.RegisterAttached(
            "PanelItemsMargin", typeof(Thickness), typeof(UIExtensions), new PropertyMetadata(new Thickness(0), PanelItemsMarginChanged));

        public static void SetPanelItemsMargin(DependencyObject element, Thickness value)
            => element.SetValue(PanelItemsMarginProperty, value);

        public static Thickness GetPanelItemsMargin(DependencyObject element)
            => (Thickness)element.GetValue(PanelItemsMarginProperty);

        private static void PanelItemsMarginChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Panel panel)
            {
                foreach (UIElement item in panel.Children)
                {
                    if (item is FrameworkElement element)
                    {

                        element.Margin = (Thickness)e.NewValue;
                    }
                }
            }
        }
    }
}
