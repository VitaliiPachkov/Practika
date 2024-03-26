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
using System.Windows.Shapes;
using Pachkov_Auth.Classes;
using Pachkov_Auth.Windows;

namespace Pachkov_Auth.Windows
{
    /// <summary>
    /// Логика взаимодействия для Registr.xaml
    /// </summary>
    public partial class Registr : Window
    {
        public Registr()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow auth = new MainWindow();
            auth.Show();
            this.Hide();
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            var login = LoginBox.Text;

            var pass = PassBox.Text;

            var mail = MailBox.Text;

            var context = new AppDbContext();

            var user_exists = context.Users.FirstOrDefault(x => x.Login == login);
            if (user_exists is not null)
            {
                MessageBox.Show("Такой пользователь уже есть!");
                return;
            }
            var user = new User { Login = login, Password = pass, Email = mail };
            context.Users.Add(user);
            context.SaveChanges();
            MessageBox.Show("Ну привет!");
        }
    }
}
