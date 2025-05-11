using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;

namespace ubys_app.MVVM.ViewModel
{
    public class AddAdminViewModel : INotifyPropertyChanged
    {
        // INotifyPropertyChanged ile veri bağlama yapıyoruz.
        public event PropertyChangedEventHandler PropertyChanged;

        private string _firstName;
        private string _lastName;
        private string _gender;
        private string _phone;
        private string _email;
        private string _loginNumber;

        // Property'ler
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public string Gender
        {
            get { return _gender; }
            set
            {
                _gender = value;
                OnPropertyChanged(nameof(Gender));
            }
        }

        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string LoginNumber
        {
            get { return _loginNumber; }
            set
            {
                _loginNumber = value;
                OnPropertyChanged(nameof(LoginNumber));
            }
        }

        // SaveCommand
        public ICommand SaveCommand { get; }

        public AddAdminViewModel()
        {
            // SaveCommand'in işlevi
            SaveCommand = new RelayCommand(Save, CanSave);
        }

        // Save işlemini burada yapıyoruz
        private void Save(object parameter)
        {
            // Burada admin ekleme işlemi yapılabilir
            // Veritabanına kaydetme işlemi vb. buraya yazılabilir
            MessageBox.Show("New admin added successfully!");
        }

        // Save butonunun aktif olup olmayacağını kontrol eder
        private bool CanSave(object parameter)
        {
            // Eğer tüm gerekli alanlar doluysa, Save işlemi aktif olur
            return !string.IsNullOrWhiteSpace(FirstName) &&
                   !string.IsNullOrWhiteSpace(LastName) &&
                   !string.IsNullOrWhiteSpace(Gender) &&
                   !string.IsNullOrWhiteSpace(Phone) &&
                   !string.IsNullOrWhiteSpace(Email) &&
                   !string.IsNullOrWhiteSpace(LoginNumber);
        }

        // PropertyChanged olayını tetiklemek için kullanılan metod
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
