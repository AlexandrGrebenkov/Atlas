using System.Threading.Tasks;

namespace Atlas.Mvvm.ServiceAbstractions
{
    public interface IDialogService
    {
        void CloseAlert();
        Task<bool> DisplayAlert(string Title, string Message, string Ok, string Cancel);
    }
}
