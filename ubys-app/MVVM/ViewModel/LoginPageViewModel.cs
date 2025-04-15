using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using System.Windows.Input;

namespace ubys_app.MVVM.ViewModel
{
    public partial class LoginPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string username;

        [ObservableProperty]
        private string password;

        [RelayCommand]
        private void Login()
        {
            // Basit giriş kontrolü – örnek amaçlı
            if (Username == "admin" && Password == "1234")
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                // Rolüne göre yönlendirme burada yapılabilir.
            }
            else
            {
                MessageBox.Show("Invalid credentials.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        [RelayCommand]
        private void ForgotPassword()
        {
            MessageBox.Show("Redirecting to password recovery...", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
