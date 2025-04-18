using System.Windows.Controls;
using ubys_app.MVVM.ViewModels;

namespace ubys_app.MVVM.View
{
    public partial class LoginPageView : UserControl
    {
        public LoginPageView()
        {
            InitializeComponent();
            this.DataContext = new LoginPageViewModel(); // ViewModel bağlandı
        }
    }
}
