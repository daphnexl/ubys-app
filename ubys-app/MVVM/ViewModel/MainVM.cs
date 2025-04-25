using System;
using System.ComponentModel;
using ubys_app.Stores;

namespace ubys_app.MVVM.ViewModel
{
    public class MainVM : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly ModalNavigationStore _modalNavigationStore;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
        public ViewModelBase CurrentModalViewModel => _modalNavigationStore.CurrentViewModel;

        public bool IsOpen => _modalNavigationStore.IsOpen;

        public MainVM(NavigationStore navigationStore, ModalNavigationStore modalNavigationStore)
        {

            _navigationStore = navigationStore ?? throw new ArgumentNullException(nameof(navigationStore));
            _modalNavigationStore = modalNavigationStore ?? throw new ArgumentNullException(nameof(modalNavigationStore));

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _modalNavigationStore.CurrentViewModelChanged += OnCurrentModalViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        private void OnCurrentModalViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentModalViewModel));
            OnPropertyChanged(nameof(IsOpen));
        }
        public override void Dispose()
        {
            _navigationStore.CurrentViewModelChanged -= OnCurrentViewModelChanged;
            _modalNavigationStore.CurrentViewModelChanged -= OnCurrentModalViewModelChanged;

            base.Dispose();
        }
    }
}
