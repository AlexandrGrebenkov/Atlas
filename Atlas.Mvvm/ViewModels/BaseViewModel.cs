using Atlas.Mvvm.Helpers;

namespace Atlas.Mvvm.ViewModels
{
    public abstract class BaseViewModel : ObservableObject
    {
        public abstract string Title { get; }
    }
}
