using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ubys_app.MVVM.ViewModel;

namespace ubys_app.MVVM.ViewModel
{
    public class NavigationStudentBarViewModel
    {
        private readonly LayoutViewModel _layout;

        public ICommand HomeCommand { get; }
        public ICommand MyCoursesCommand { get; }
        public ICommand CourseSelectionCommand { get; }
        public ICommand ExamScheduleCommand { get; }
        public ICommand LogOutCommand { get; }

        public NavigationStudentBarViewModel(LayoutViewModel layout)
        {
            _layout = layout;

            HomeCommand = new RelayCommand(o => _layout.NavigateTo(new StudentHomeViewModel()));
            MyCoursesCommand = new RelayCommand(o => _layout.NavigateTo(new MyCoursesViewModel()));
            CourseSelectionCommand = new RelayCommand(o => _layout.NavigateTo(new CourseSelectionViewModel()));
            ExamScheduleCommand = new RelayCommand(o => _layout.NavigateTo(new ExamScheduleViewModel()));
            LogOutCommand = new RelayCommand(o => Application.Current.Shutdown());
        }
    }

}
