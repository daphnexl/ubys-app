using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ubys_app.Stores;

namespace ubys_app.MVVM.ViewModel
{
    public class StudentLayoutVM : ViewModelBase
    {
        public NavigationStudentBarViewModel NavigationBarVM { get; }
        public ViewModelBase ContentViewModel { get; }

        public readonly StudentBarStore _navigationBarPropertiesStore;

        public ICommand ToggleNavigationBarVisibleCommand { get; }

        public StudentLayoutVM(NavigationStudentBarViewModel navigationBarVM,
            ViewModelBase contentViewModel,
           StudentBarStore navigationBarPropertiesStore)
        {
            NavigationBarVM = navigationBarVM;
            ContentViewModel = contentViewModel;

            _navigationBarPropertiesStore = navigationBarPropertiesStore;
            _navigationBarPropertiesStore.NavigationBarVisibilityChanged += _navigationBarPropertiesStore_NavigationBarVisibilityChanged;
            ToggleNavigationBarVisibleCommand = new RelayCommand(_ => ToggleNavigationBarVisibility());
        }

        private void _navigationBarPropertiesStore_NavigationBarVisibilityChanged()
        {
            OnPropertyChanged(nameof(_navigationBarPropertiesStore.IsNavigationBarVisible));
        }

        private void ToggleNavigationBarVisibility()
        {
            _navigationBarPropertiesStore.IsNavigationBarVisible = !_navigationBarPropertiesStore.IsNavigationBarVisible;
        }

        public override void Dispose()
        {
            NavigationBarVM.Dispose();
            ContentViewModel.Dispose();
            base.Dispose();
        }
    }
}

