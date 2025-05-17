using System.Collections.ObjectModel;
using System.ComponentModel;
using ubys_app.MVVM.Model; // Course modelin buradaysa bunu eklemelisin

namespace ubys_app.MVVM.ViewModel
{
    public class TeacherMyCoursesViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Course> _myCourses;
        public ObservableCollection<Course> MyCourses
        {
            get { return _myCourses; }
            set
            {
                _myCourses = value;
                OnPropertyChanged(nameof(MyCourses));
            }
        }

        public TeacherMyCoursesViewModel()
        {
            // Örnek veri, veritabanı bağlanınca buradan kaldırılır
            MyCourses = new ObservableCollection<Course>
            {
                new Course { Course_name = "Algoritmalar", Course_code = "CSE101", Credits = 4 },
                new Course { Course_name = "Veritabanı", Course_code = "CSE303", Credits = 3 }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
