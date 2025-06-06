﻿using System;
using ubys_app.MVVM.ViewModel;
using ubys_app.Stores;

namespace ubys_app.Services
{
    public class ModalNavigationService<TViewModel> : INavigationService
        where TViewModel : ViewModelBase
    {
        private readonly ModalNavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;

        public ModalNavigationService(ModalNavigationStore navigationStore, Func<TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
