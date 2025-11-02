using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DContextInheritance
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>


    public partial class MainWindow : Window
    {

        private UserData _userData = new UserData { UserName = "Алла" };
        private AdminData _adminData = new AdminData { AdminName = "Администратор" };
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = _userData;
        }
        private void SwitchToAdmin_Click(object sender, RoutedEventArgs e)
        {
            // Изменение DataContext затронет все элементы,
            // которые наследуют контекст окна
            this.DataContext = _adminData;
        }

        private void SwitchToUser_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = _userData;
        }
    }
}
