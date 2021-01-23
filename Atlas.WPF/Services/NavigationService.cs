using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Atlas.Mvvm.ServiceAbstractions;
using Atlas.Mvvm.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Atlas.WPF.Services
{
    internal class NavigationService : INavigationService
    {
        private readonly Frame frame;
        private readonly Dictionary<Type, Type> pages;
        private readonly IServiceProvider serviceProvider;

        public NavigationService(Frame frame, IServiceProvider serviceProvider)
        {
            this.frame = frame;
            pages = new Dictionary<Type, Type>();
            this.serviceProvider = serviceProvider;
        }

        public void RegisterPage<TViewModel, TPage>()
            where TViewModel : BaseViewModel
            where TPage : Page
        {
            pages.Add(typeof(TViewModel), typeof(TPage));
        }

        public void Push<TViewModel>() where TViewModel : BaseViewModel
        {
            var vm = ActivatorUtilities.CreateInstance<TViewModel>(serviceProvider);
            Push(vm);
        }

        public void Push(BaseViewModel viewModel)
        {
            var page = (Page)Activator.CreateInstance(pages[viewModel.GetType()]);
            page.DataContext = viewModel;
            frame.Navigate(page);
        }

        public void Pop()
        {
            if (frame.CanGoBack)
            {
                frame.GoBack();
            }
        }
    }
}