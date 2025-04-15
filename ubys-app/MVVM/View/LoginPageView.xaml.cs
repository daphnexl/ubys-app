using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ubys_app.MVVM.View
{
    public partial class LoginPageView : UserControl
    {
        public LoginPageView()
        {
            InitializeComponent();
            this.DataContext = new LoginPageViewModel(); 
        }
        private void UsernameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (UsernameTextBox.Text == "username")
            {
                UsernameTextBox.Text = string.Empty;
                UsernameTextBox.Foreground = new SolidColorBrush(System.Windows.Media.Colors.Black);
            }
        }
        private void UsernameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(UsernameTextBox.Text))
            {
                UsernameTextBox.Text = "username";
                UsernameTextBox.Foreground = new SolidColorBrush(System.Windows.Media.Colors.Gray);
            }
        }
        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordPlaceholder.Visibility == Visibility.Visible)
            {
                PasswordPlaceholder.Visibility = Visibility.Hidden;
            }
        }
        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(PasswordBox.Password))
            {
                PasswordPlaceholder.Visibility = Visibility.Visible;
            }
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
        }
    }
}

