using System.Windows;
using System.Windows.Input;

namespace ubys_app.MVVM.ViewModel
{
    public class AddStudentViewModel : ViewModelBase
    {
        public ICommand SaveCommand { get; }

        public AddStudentViewModel()
        {
            SaveCommand = new RelayCommand(OnSave);
        }

        private void OnSave(object obj)
        {
            MessageBox.Show("Saved successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
