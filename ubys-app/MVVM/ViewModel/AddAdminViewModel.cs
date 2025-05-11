using System.Windows.Input;
using ubys_app.Commands;
using ubys_app.MVVM.Model;

namespace ubys_app.MVVM.ViewModel
{
    public class AddAdminViewModel : ObservableObject
    {
        public ICommand SaveCommand { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string LoginNumber { get; set; }

        public AddAdminViewModel()
        {
            SaveCommand = new SaveCommand(Save);
        }

        private void Save(object parameter)
        {
            if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName) ||
                string.IsNullOrEmpty(Phone) || string.IsNullOrEmpty(Email))
            {
                // Uyarı mesajı
                Console.WriteLine("All fields must be filled.");
                return;
            }

            // Admin nesnesi oluşturma
            Admin newAdmin = new Admin
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                Gender = this.Gender,
                Phone = this.Phone,
                Email = this.Email,
                LoginNumber = this.LoginNumber
            };

            SaveAdminToDatabase(newAdmin);
        }

        private void SaveAdminToDatabase(Admin admin)
        {
            Console.WriteLine($"Admin {admin.FirstName} {admin.LastName} added to the database.");
        }
    }
}
