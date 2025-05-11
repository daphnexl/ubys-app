using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ubys_app.MVVM.ViewModel
{
    public class NavigationAdminBarViewModel : ViewModelBase
    {
        public ICommand HomeCommand { get; }
        public ICommand AddCourseCommand { get; }
        public ICommand AddTeacherCommand { get; }
        public ICommand AddAdminCommand { get; }
        public ICommand CSelectionStCommand { get; }
        public ICommand LogOutCommand { get; }

        public bool IsMenuCollapsed
        {
            get => _isMenuCollapsed;
            set => SetProperty(ref _isMenuCollapsed, value);
        }
        private bool _isMenuCollapsed;

        public NavigationAdminBarViewModel(
            ICommand homeCommand,
            ICommand addCourseCommand,
            ICommand addTeacherCommand,
            ICommand addAdminCommand,
            ICommand cSelectionStCommand,
            ICommand logOutCommand)
        {
            HomeCommand = homeCommand;
            AddCourseCommand = addCourseCommand;
            AddTeacherCommand = addTeacherCommand;
            AddAdminCommand = addAdminCommand;
            CSelectionStCommand = cSelectionStCommand;
            LogOutCommand = logOutCommand;
        }
    }
}
