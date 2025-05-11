using System.Windows;
using System.Windows.Controls;

namespace ubys_app.MVVM.View
{
    /// <summary>
    /// TeacherMainPage.xaml etkileşim mantığı
    /// </summary>
    public partial class TeacherMainPage : UserControl
    {
        public TeacherMainPage()
        {
            InitializeComponent();
        }

        // Hamburger menüsüne tıklanınca çalışacak olay metodu
        private void Hamburger_Click(object sender, RoutedEventArgs e)
        {
            // Menü genişliğini değiştirebiliriz (eğer isterseniz)
            if (SidebarColumn.Width.Value == 50)
            {
                SidebarColumn.Width = new GridLength(400);  // Menü genişliğini artır
            }
            else
            {
                SidebarColumn.Width = new GridLength(50);  // Menü daralt
            }
        }
    }
}
