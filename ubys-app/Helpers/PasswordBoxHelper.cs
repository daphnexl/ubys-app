using System.Windows;
using System.Windows.Controls;

namespace ubys_app.Helpers
{
    public class PasswordBoxHelper
    {
        public static readonly DependencyProperty BoundPasswordProperty =
            DependencyProperty.RegisterAttached(
                "BoundPassword",                           
                typeof(string),                           
                typeof(PasswordBoxHelper),                 
                new PropertyMetadata(string.Empty, OnBoundPasswordChanged)); 
        public static string GetBoundPassword(DependencyObject obj)
        {
            return (string)obj.GetValue(BoundPasswordProperty);
        }
        public static void SetBoundPassword(DependencyObject obj, string value)
        {
            obj.SetValue(BoundPasswordProperty, value);
        }
        private static readonly DependencyProperty IsUpdatingProperty =
            DependencyProperty.RegisterAttached(
                "IsUpdating",                              
                typeof(bool),                              
                typeof(PasswordBoxHelper),                 
                new PropertyMetadata(false));             
        private static bool GetIsUpdating(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsUpdatingProperty);
        }
        private static void SetIsUpdating(DependencyObject obj, bool value)
        {
            obj.SetValue(IsUpdatingProperty, value);
        }
        private static void OnBoundPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PasswordBox passwordBox)
            {
                passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

                if (!GetIsUpdating(passwordBox))
                {
                    passwordBox.Password = (string)e.NewValue; 
                }
                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            }
        }
        private static void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox passwordBox)
            {
                SetIsUpdating(passwordBox, true);

                SetBoundPassword(passwordBox, passwordBox.Password);

                SetIsUpdating(passwordBox, false);
            }
        }
    }
}
