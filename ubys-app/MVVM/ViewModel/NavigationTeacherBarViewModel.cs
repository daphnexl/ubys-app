using System.Windows.Input;
using ubys_app.Commands;
using ubys_app.Services;
using ubys_app.Stores;

namespace ubys_app.MVVM.ViewModel
{
    public class NavigationTeacherBarViewModel : ViewModelBase
    {
        private readonly TeacherBarStore _navigationBarPropertiesStore;

        #region Menu Visibility
        public bool IsMenuCollapsed
        {
            get => !_navigationBarPropertiesStore.IsNavigationBarVisible;
            set
            {
                _navigationBarPropertiesStore.IsNavigationBarVisible = !value;
                OnPropertyChanged(nameof(IsMenuCollapsed));
            }
        }

        public ICommand ToggleMenuCollapseCommand { get; }
        #endregion

        #region Menu Seçimleri
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

        public bool IsMyCoursesSelected
        {
            get => _navigationBarPropertiesStore.IsMyCoursesSelected;
            set
            {
                if (_navigationBarPropertiesStore.IsMyCoursesSelected != value)
                {
                    _navigationBarPropertiesStore.IsMyCoursesSelected = value;
                    OnPropertyChanged(nameof(IsMyCoursesSelected));
                }
            }
        }

        public bool IsEditNoteSelected
        {
            get => _navigationBarPropertiesStore.IsEditNoteSelected;
            set
            {
                if (_navigationBarPropertiesStore.IsEditNoteSelected != value)
                {
                    _navigationBarPropertiesStore.IsEditNoteSelected = value;
                    OnPropertyChanged(nameof(IsEditNoteSelected));
                }
            }
        }

        public bool IsStudentsSelected
        {
            get => _navigationBarPropertiesStore.IsStudentsSelected;
            set
            {
                if (_navigationBarPropertiesStore.IsStudentsSelected != value)
                {
                    _navigationBarPropertiesStore.IsStudentsSelected = value;
                    OnPropertyChanged(nameof(IsStudentsSelected));
                }
            }
        }
        #endregion

        #region Komutlar
        public ICommand HomeCommand { get; }
        public ICommand MyCoursesCommand { get; }
        public ICommand EditNoteCommand { get; }
        public ICommand StudentsCommand { get; }
        public ICommand LogOutCommand { get; }
        #endregion

        public NavigationTeacherBarViewModel(
            TeacherBarStore navigationBarPropertiesStore,
            INavigationService homeNavigationService,
            INavigationService myCoursesNavigationService,
            INavigationService editNoteNavigationService,
            INavigationService studentsNavigationService,
            INavigationService logOutNavigationService)
        {
            _navigationBarPropertiesStore = navigationBarPropertiesStore;

            _navigationBarPropertiesStore.NavigationBarVisibilityChanged += () =>
            {
                OnPropertyChanged(nameof(IsMenuCollapsed));
            };

            _navigationBarPropertiesStore.SelectedNavigationBarMenuChanged += OnSelectedMenuChanged;

            ToggleMenuCollapseCommand = new RelayCommand(_ => ToggleMenu());

            HomeCommand = new NavigateCommand(homeNavigationService);
            MyCoursesCommand = new NavigateCommand(myCoursesNavigationService);
            EditNoteCommand = new NavigateCommand(editNoteNavigationService);
            StudentsCommand = new NavigateCommand(studentsNavigationService);
            LogOutCommand = new NavigateCommand(logOutNavigationService);
        }

        private void ToggleMenu()
        {
            _navigationBarPropertiesStore.IsNavigationBarVisible = !_navigationBarPropertiesStore.IsNavigationBarVisible;
        }

        private void OnSelectedMenuChanged()
        {
            OnPropertyChanged(nameof(IsHomeSelected));
            OnPropertyChanged(nameof(IsMyCoursesSelected));
            OnPropertyChanged(nameof(IsEditNoteSelected));
            OnPropertyChanged(nameof(IsStudentsSelected));
        }

        public override void Dispose()
        {
            _navigationBarPropertiesStore.SelectedNavigationBarMenuChanged -= OnSelectedMenuChanged;
            base.Dispose();
        }
    }
}
