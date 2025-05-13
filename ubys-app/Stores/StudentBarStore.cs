using System;

namespace ubys_app.Stores
{
    public class StudentBarStore
    {
        #region NavigationBarMenuVisibility Property
        private bool _isNavigationBarVisible;
        public bool IsNavigationBarVisible
        {
            get => _isNavigationBarVisible;
            set
            {
                if (_isNavigationBarVisible != value)
                {
                    _isNavigationBarVisible = value;
                    NavigationBarVisibilityChanged?.Invoke();
                }
            }
        }
        #endregion

        #region NavigationBarMenuSelected Properties
        private bool _isHomeSelected;
        public bool IsHomeSelected
        {
            get => _isHomeSelected;
            set
            {
                if (_isHomeSelected != value)
                {
                    _isHomeSelected = value;
                    SelectedNavigationBarMenuChanged?.Invoke();
                }
            }
        }

        private bool _isMyCoursesSelected;
        public bool IsMyCoursesSelected
        {
            get => _isMyCoursesSelected;
            set
            {
                if (_isMyCoursesSelected != value)
                {
                    _isMyCoursesSelected = value;
                    SelectedNavigationBarMenuChanged?.Invoke();
                }
            }
        }

        private bool _isCourseSelectionSelected;
        public bool IsCourseSelectionSelected
        {
            get => _isCourseSelectionSelected;
            set
            {
                if (_isCourseSelectionSelected != value)
                {
                    _isCourseSelectionSelected = value;
                    SelectedNavigationBarMenuChanged?.Invoke();
                }
            }
        }

        private bool _isExamScheduleSelected;
        public bool IsExamScheduleSelected
        {
            get => _isExamScheduleSelected;
            set
            {
                if (_isExamScheduleSelected != value)
                {
                    _isExamScheduleSelected = value;
                    SelectedNavigationBarMenuChanged?.Invoke();
                }
            }
        }
        #endregion

        #region Actions
        public event Action NavigationBarVisibilityChanged;
        public event Action SelectedNavigationBarMenuChanged;
        #endregion

        #region Constructor
        public StudentBarStore()
        {
            // Varsayılan değerler
            _isNavigationBarVisible = false;
            _isHomeSelected = true;
            _isMyCoursesSelected = false;
            _isCourseSelectionSelected = false;
            _isExamScheduleSelected = false;
        }
        #endregion
    }
}
