using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;
using Atlas.Mvvm.ServiceAbstractions;
using Atlas.Mvvm.ViewModels;
using Atlas.WPF.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Atlas.WPF.Services
{
    internal class NavigationService : INavigationService
    {
        private readonly Frame frame;
        private readonly Dictionary<Type, Type> pages;
        private readonly Stack<TaskCompletionSource<object>> asyncNavigationResultStack;
        private readonly IServiceProvider serviceProvider;

        public NavigationService(Frame frame, IServiceProvider serviceProvider)
        {
            this.frame = frame;
            pages = new Dictionary<Type, Type>();
            asyncNavigationResultStack = new Stack<TaskCompletionSource<object>>();
            this.serviceProvider = serviceProvider;
        }

        public void RegisterPage<TViewModel, TPage>()
            where TViewModel : BaseViewModel
            where TPage : NavigationPage
        {
            pages.Add(typeof(TViewModel), typeof(TPage));
        }

        public void Push<TViewModel>() where TViewModel : BaseViewModel
        {
            Push<TViewModel>(Array.Empty<object>());
        }

        public void Push<TViewModel>(params object[] parameters) where TViewModel : BaseViewModel
        {
            var vm = ActivatorUtilities.CreateInstance<TViewModel>(serviceProvider, parameters);
            Push(vm);
        }

        public Task<object> PushAsync<TViewModel>(params object[] parameters) where TViewModel : BaseViewModel
        {
            var vm = ActivatorUtilities.CreateInstance<TViewModel>(serviceProvider, parameters);
            return PushAsync(vm);
        }

        public Task<object> PushAsync(BaseViewModel viewModel)
        {
            return NavigateToPage(viewModel).Task;
        }

        public void Push(BaseViewModel viewModel)
        {
            NavigateToPage(viewModel);
        }

        private TaskCompletionSource<object> NavigateToPage(BaseViewModel viewModel)
        {
            var page = (Page)Activator.CreateInstance(pages[viewModel.GetType()]);
            page.DataContext = viewModel;
            frame.Navigate(page);
            var taskCompletionSource = new TaskCompletionSource<object>();
            asyncNavigationResultStack.Push(taskCompletionSource);
            return taskCompletionSource;
        }

        public void Pop()
        {
            Pop(null);
        }

        public void Pop(object resultObject)
        {

            var taskCompletionSource = asyncNavigationResultStack.Pop();
            taskCompletionSource.SetResult(resultObject);

            if (frame.CanGoBack)
            {
                frame.GoBack();
            }
        }
    }
}