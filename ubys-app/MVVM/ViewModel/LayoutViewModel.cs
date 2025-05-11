using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ubys_app.MVVM.Model;
using ubys_app.MVVM.View;
using ubys_app.MVVM.ViewModel;

namespace ubys_app.MVVM.ViewModel
{
    public class LayoutViewModel : ViewModelBase
    {
        private ViewModelBase _navigationBarViewModel;
        public ViewModelBase NavigationBarViewModel
        {
            get => _navigationBarViewModel;
            set => SetProperty(ref _navigationBarViewModel, value);
        }

        public LayoutViewModel(User loggedInUser)
        {
            switch (loggedInUser.Role)
            {
                case Role.Admin:
                    NavigationBarViewModel = new NavigationAdminBarViewModel(
                        new RelayCommand(OnHome),
                        new RelayCommand(OnAddCourse),
                        new RelayCommand(OnAddTeacher),
                        new RelayCommand(OnAddAdmin),
                        new RelayCommand(OnCourseSelectionStatus),
                        new RelayCommand(OnLogOut));
                    break;

                case Role.Teacher:
                    NavigationBarViewModel = new NavigationTeacherBarViewModel(
                        new RelayCommand(OnHome),
                        new RelayCommand(OnMyCourses),
                        new RelayCommand(OnEditNote),
                        new RelayCommand(OnStudents),
                        new RelayCommand(OnLogOut));
                    break;
            }
        }

        // Bu metodlar sayfanızı değiştiren Navigation servisleri çağırır.
        private void OnHome() { /* Navigate to home */ }
        private void OnAddCourse() { /* Navigate */ }
        private void OnLogOut() { /* Navigate to login page */ }
        // diğerleri de benzer şekilde...
    }



}
