using System.Windows.Input;
using ubys_app.Commands;
using ubys_app.Services;
using ubys_app.Stores;

namespace ubys_app.MVVM.ViewModel
{
    public class AdminNavigationBarVM: ViewModelBase
    {
        public readonly AdminBarStore _navigationBarPropertiesStore;

        #region NavigationBarVisibility Command
        public bool IsNavigationBarVisible
        {
            get => _navigationBarPropertiesStore.IsNavigationBarVisible;
            set
            {
                if (_navigationBarPropertiesStore.IsNavigationBarVisible != value)
                {
                    _navigationBarPropertiesStore.IsNavigationBarVisible = value;
                    OnPropertyChanged(nameof(IsNavigationBarVisible));
                }
            }
        }

        public ICommand ToggleNavigationBarVisibleCommand { get; }
        #endregion

        #region NavigationBarMenuSelectedStore Properties
        public bool IsHomeSelected
        {
            get => _navigationBarPropertiesStore.IsHomeSelected;
            set
            {
                if (_navigationBarPropertiesStore.IsHomeSelected != value)
                {
                    _navigationBarPropertiesStore.IsHomeSelected = value;
                    OnPropertyChanged(nameof(IsHomeSelected));
                }
            }
        }

        public bool IsAddCourseSelected
        {
            get => _navigationBarPropertiesStore.IsAddCourseSelected;
            set
            {
                if (_navigationBarPropertiesStore.IsAddCourseSelected != value)
                {
                    _navigationBarPropertiesStore.IsAddCourseSelected = value;
                    OnPropertyChanged(nameof(IsAddCourseSelected));
                }
            }
        }

        public bool IsAddTeacherSelected
        {
            get => _navigationBarPropertiesStore.IsAddTeacherSelected;
            set
            {
                if (_navigationBarPropertiesStore.IsAddTeacherSelected != value)
                {
                    _navigationBarPropertiesStore.IsAddTeacherSelected = value;
                    OnPropertyChanged(nameof(IsAddTeacherSelected));
                }
            }
        }

        public bool IsAddAdminSelected
        {
            get => _navigationBarPropertiesStore.IsAddAdminSelected;
            set
            {
                if (_navigationBarPropertiesStore.IsAddAdminSelected != value)
                {
                    _navigationBarPropertiesStore.IsAddAdminSelected = value;
                    OnPropertyChanged(nameof(IsAddAdminSelected));
                }
            }
        }

        public bool IsCourseSelectionStatusSelected
        {
            get => _navigationBarPropertiesStore.IsCourseSelectionStatusSelected;
            set
            {
                if (_navigationBarPropertiesStore.IsCourseSelectionStatusSelected != value)
                {
                    _navigationBarPropertiesStore.IsCourseSelectionStatusSelected = value;
                    OnPropertyChanged(nameof(IsCourseSelectionStatusSelected));
                }
            }
        }

        #endregion

        #region Navigation Commands
        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateAddCourseCommand { get; }
        public ICommand NavigateAddTeacherCommand { get; }
        public ICommand NavigateAddAdminCommand { get; }
        public ICommand NavigateCourseSelectionStatusCommand { get; }
        public ICommand LogOutCommand { get; }
        #endregion

        public AdminNavigationBarVM(
            AdminBarStore navigationBarPropertiesStore,
            INavigationService homeNavigationService,
            INavigationService addCourseNavigationService,
            INavigationService addTeacherNavigationService,
            INavigationService addAdminNavigationService,
            INavigationService courseSelectionStatusNavigationService,
            INavigationService logoutNavigationService)
        {
            _navigationBarPropertiesStore = navigationBarPropertiesStore;

            _navigationBarPropertiesStore.NavigationBarVisibilityChanged += NavigationBarVisibilityChanged;
            _navigationBarPropertiesStore.SelectedNavigationBarMenuChanged += NavigationBarMenuChanged;

            ToggleNavigationBarVisibleCommand = new RelayCommand(_ => ToggleNavigationBarVisibility());

            NavigateHomeCommand = new NavigateCommand(homeNavigationService);
            NavigateAddCourseCommand = new NavigateCommand(addCourseNavigationService);
            NavigateAddTeacherCommand = new NavigateCommand(addTeacherNavigationService);
            NavigateAddAdminCommand = new NavigateCommand(addAdminNavigationService);
            NavigateCourseSelectionStatusCommand = new NavigateCommand(courseSelectionStatusNavigationService);
            LogOutCommand = new NavigateCommand(logoutNavigationService);
        }

        private void NavigationBarVisibilityChanged()
        {
            OnPropertyChanged(nameof(IsNavigationBarVisible));
        }

        private void NavigationBarMenuChanged()
        {
            OnPropertyChanged(nameof(IsHomeSelected));
            OnPropertyChanged(nameof(IsAddCourseSelected));
            OnPropertyChanged(nameof(IsAddTeacherSelected));
            OnPropertyChanged(nameof(IsAddAdminSelected));
            OnPropertyChanged(nameof(IsCourseSelectionStatusSelected));
        }

        private void ToggleNavigationBarVisibility()
        {
            _navigationBarPropertiesStore.IsNavigationBarVisible = !_navigationBarPropertiesStore.IsNavigationBarVisible;
        }

        public override void Dispose()
        {
            _navigationBarPropertiesStore.SelectedNavigationBarMenuChanged -= NavigationBarMenuChanged;
            base.Dispose();
        }
    }
}
