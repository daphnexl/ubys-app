using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ubys_app.MVVM.ViewModel
{
    public class NavigationTeacherBarViewModel : ViewModelBase
    {
        public ICommand HomeCommand { get; }
        public ICommand MyCoursesCommand { get; }
        public ICommand EditNoteCommand { get; }
        public ICommand StudentsCommand { get; }
        public ICommand LogOutCommand { get; }

        public bool IsMenuCollapsed
        {
            get => _isMenuCollapsed;
            set => SetProperty(ref _isMenuCollapsed, value);
        }
        private bool _isMenuCollapsed;

        public NavigationTeacherBarViewModel(
            ICommand homeCommand,
            ICommand myCoursesCommand,
            ICommand editNoteCommand,
            ICommand studentsCommand,
            ICommand logOutCommand)
        {
            HomeCommand = homeCommand;
            MyCoursesCommand = myCoursesCommand;
            EditNoteCommand = editNoteCommand;
            StudentsCommand = studentsCommand;
            LogOutCommand = logOutCommand;
        }
    }
    }
