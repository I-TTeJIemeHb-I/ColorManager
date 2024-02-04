using ColorManager.DataBase;
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

namespace ColorManager.Data.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            using (var db = new ApplicationContext())
            {
                var users = db.Users;

                var user = users.FirstOrDefault(u => u.Login == "1" && u.Password == "1");

                if (user != null)
                {
                    MessageBox.Show($"Имя пользователя: {user.Name}");
                }
                else
                {
                    MessageBox.Show($"Такого пользователя не существует");
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Registr form = new Registr();
            form.Show();
            this.Hide();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            Vxod form = new Vxod();
            form.Show();
            this.Hide();
        }
    }
}
