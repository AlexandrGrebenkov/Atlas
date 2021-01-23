using System;
using Atlas.Mvvm.ServiceAbstractions;

namespace Atlas.WPF.Views.Common
{
    /// <summary>
    /// Interaction logic for AlertDialog.xaml
    /// </summary>
    public partial class AlertDialog : BaseDialog
    {
        public AlertDialog(AlertArguments arguments, Action close)
        {
            InitializeComponent();
            title.Text = arguments.Title;
            message.Text = arguments.Message;
            accept.Content = arguments.Accept;
            accept.Click += (sender, args) =>
            {
                arguments.SetResult(true);
                close?.Invoke();
            };
            cancel.Content = arguments.Cancel;
            cancel.Click += (sender, args) =>
            {
                arguments.SetResult(false);
                close?.Invoke();
            };
        }
    }
}
