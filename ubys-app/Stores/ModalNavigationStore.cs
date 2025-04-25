using System;
using ubys_app.MVVM.ViewModel;

namespace ubys_app.Stores
{
    public class ModalNavigationStore
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                CurrentViewModelChanged?.Invoke();
            }
        }

        public event Action CurrentViewModelChanged;

        public bool IsOpen => CurrentViewModel != null;

        public void Close()
        {
            CurrentViewModel = null;
        }
    }
}
