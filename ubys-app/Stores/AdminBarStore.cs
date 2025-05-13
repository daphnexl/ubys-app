using System;

namespace ubys_app.Stores
{
    public class AdminBarStore
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

        private bool _isAddCourseSelected;
        public bool IsAddCourseSelected
        {
            get => _isAddCourseSelected;
            set
            {
                if (_isAddCourseSelected != value)
                {
                    _isAddCourseSelected = value;
                    SelectedNavigationBarMenuChanged?.Invoke();
                }
            }
        }

        private bool _isAddTeacherSelected;
        public bool IsAddTeacherSelected
        {
            get => _isAddTeacherSelected;
            set
            {
                if (_isAddTeacherSelected != value)
                {
                    _isAddTeacherSelected = value;
                    SelectedNavigationBarMenuChanged?.Invoke();
                }
            }
        }

        private bool _isAddAdminSelected;
        public bool IsAddAdminSelected
        {
            get => _isAddAdminSelected;
            set
            {
                if (_isAddAdminSelected != value)
                {
                    _isAddAdminSelected = value;
                    SelectedNavigationBarMenuChanged?.Invoke();
                }
            }
        }

        private bool _isCourseSelectionStatusSelected;
        public bool IsCourseSelectionStatusSelected
        {
            get => _isCourseSelectionStatusSelected;
            set
            {
                if (_isCourseSelectionStatusSelected != value)
                {
                    _isCourseSelectionStatusSelected = value;
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
        public AdminBarStore()
        {
            // Varsayılan başlangıç değerleri
            _isNavigationBarVisible = false;
            _isHomeSelected = true;
            _isAddCourseSelected = false;
            _isAddTeacherSelected = false;
            _isAddAdminSelected = false;
            _isCourseSelectionStatusSelected = false;
        }
        #endregion
    }
}
