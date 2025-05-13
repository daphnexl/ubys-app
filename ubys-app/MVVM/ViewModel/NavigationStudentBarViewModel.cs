using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ubys_app.Commands;
using ubys_app.MVVM.ViewModel;
using ubys_app.Services;
using ubys_app.Stores;

namespace ubys_app.MVVM.ViewModel
{
    public class NavigationStudentBarViewModel : ViewModelBase
    {
        private readonly StudentBarStore _navigationBarPropertiesStore;

        #region Menu Visibility Binding
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

        public bool IsCourseSelectionSelected
        {
            get => _navigationBarPropertiesStore.IsCourseSelectionSelected;
            set
            {
                if (_navigationBarPropertiesStore.IsCourseSelectionSelected != value)
                {
                    _navigationBarPropertiesStore.IsCourseSelectionSelected = value;
                    OnPropertyChanged(nameof(IsCourseSelectionSelected));
                }
            }
        }

        public bool IsExamScheduleSelected
        {
            get => _navigationBarPropertiesStore.IsExamScheduleSelected;
            set
            {
                if (_navigationBarPropertiesStore.IsExamScheduleSelected != value)
                {
                    _navigationBarPropertiesStore.IsExamScheduleSelected = value;
                    OnPropertyChanged(nameof(IsExamScheduleSelected));
                }
            }
        }
        #endregion

        #region Komutlar
        public ICommand HomeCommand { get; }
        public ICommand MyCoursesCommand { get; }
        public ICommand CourseSelectionCommand { get; }
        public ICommand ExamScheduleCommand { get; }
        public ICommand LogOutCommand { get; }
        #endregion

        public NavigationStudentBarViewModel(
            StudentBarStore navigationBarPropertiesStore,
            INavigationService homeNavigationService,
            INavigationService myCoursesNavigationService,
            INavigationService courseSelectionNavigationService,
            INavigationService examScheduleNavigationService,
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
            CourseSelectionCommand = new NavigateCommand(courseSelectionNavigationService);
            ExamScheduleCommand = new NavigateCommand(examScheduleNavigationService);
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
            OnPropertyChanged(nameof(IsCourseSelectionSelected));
            OnPropertyChanged(nameof(IsExamScheduleSelected));
        }

        public override void Dispose()
        {
            _navigationBarPropertiesStore.SelectedNavigationBarMenuChanged -= OnSelectedMenuChanged;
            base.Dispose();
        }
    }
}