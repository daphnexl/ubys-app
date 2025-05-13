using System;

namespace ubys_app.Stores
{
    public class TeacherBarStore
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

        private bool _isEditNoteSelected;
        public bool IsEditNoteSelected
        {
            get => _isEditNoteSelected;
            set
            {
                if (_isEditNoteSelected != value)
                {
                    _isEditNoteSelected = value;
                    SelectedNavigationBarMenuChanged?.Invoke();
                }
            }
        }

        private bool _isStudentsSelected;
        public bool IsStudentsSelected
        {
            get => _isStudentsSelected;
            set
            {
                if (_isStudentsSelected != value)
                {
                    _isStudentsSelected = value;
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
        public TeacherBarStore()
        {
            // Varsayılan başlangıç değerleri
            _isNavigationBarVisible = false;
            _isHomeSelected = true;
            _isMyCoursesSelected = false;
            _isEditNoteSelected = false;
            _isStudentsSelected = false;
        }
        #endregion
    }
}
