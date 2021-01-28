using System.Threading.Tasks;
using Atlas.Mvvm.ViewModels;

namespace Atlas.Mvvm.ServiceAbstractions
{
    public interface INavigationService
    {
        void Push<TViewModel>() where TViewModel : BaseViewModel;
        void Push<TViewModel>(params object[] parameters) where TViewModel : BaseViewModel;
        void Push(BaseViewModel viewModel);
        void Pop();
    }
}
