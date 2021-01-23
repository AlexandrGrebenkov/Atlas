using System.Windows;
using System.Windows.Controls;

namespace Atlas.WPF.Resources.Controls
{
    public partial class ToolBar : UserControl
    {
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(ToolBar), new PropertyMetadata(""));

        public ToolBar()
        {
            InitializeComponent();
        }
    }
}
