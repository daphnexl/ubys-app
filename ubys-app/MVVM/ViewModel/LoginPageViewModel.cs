using System.Windows.Input;
using System.Windows;
using CommunityToolkit.Mvvm.Input;
using ubys_app.MVVM.View;

namespace ubys_app.MVVM.ViewModels
{
    public class LoginPageViewModel
    {
        public ICommand LoginCommand { get; set; }
        public ICommand ForgotPasswordCommand { get; set; }

        public LoginPageViewModel()
        {
            LoginCommand = new RelayCommand(ExecuteLoginCommand);
            ForgotPasswordCommand = new RelayCommand(ExecuteForgotPasswordCommand);
        }
        private void ExecuteLoginCommand(object parameter)
        {
            // parameter olarak UserControl (LoginPageView) nesnesi alıyoruz
            var loginPageView = parameter as LoginPageView;

            if (loginPageView == null)
            {
                MessageBox.Show("Geçersiz parametre!");
                return;
            }

            string username = loginPageView.UsernameTextBox.Text;
            string password = loginPageView.PasswordBox.Password;

            // Kullanıcı adı ve şifre kontrolü
            if (username == "admin" && password == "password123")
            {
                MessageBox.Show("Giriş Başarılı!");
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı.");
            }
        }
        private void ExecuteForgotPasswordCommand(object parameter)
        {
            MessageBox.Show("Şifre sıfırlama linki gönderildi.");
        }
    }
}
