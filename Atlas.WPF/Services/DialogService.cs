using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;
using Atlas.Mvvm.ServiceAbstractions;
using Atlas.WPF.Views.Common;

namespace Atlas.WPF.Services
{
    public class DialogService : IDialogService
    {
        private readonly Frame frame;

        public DialogService(Frame frame)
        {
            this.frame = frame;
        }

        public void CloseAlert()
        {
            if (frame.CanGoBack)
            {
                frame.GoBack();
            }
            /*if (frame.CanGoBack || frame.CanGoForward)
            {
                JournalEntry entry;
                do
                {
                    entry = frame.RemoveBackEntry();
                } while (entry != null);
            }
            frame.Content = null;*/
        }

        public Task<bool> DisplayAlert(string Title, string Message, string Ok, string Cancel)
        {
            var args = new AlertArguments(Title, Message, Ok, Cancel);
            var alert = new AlertDialog(args, CloseAlert);
            frame.Navigate(alert);
            return args.Result.Task;
        }
    }
}
