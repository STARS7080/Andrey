using Demo.Model;
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

namespace Demo
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void txtLogin_TextChanged(object sender, TextChangedEventArgs e)
        { 
        
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = txtLogin.Text;
            string password = txtPassword.Password;


            if (string.IsNullOrWhiteSpace(login) || (string.IsNullOrWhiteSpace(password)))
                {
                MessageBox.Show("Введите логин и пароль");
                return;
            }

            try
            {
                using (var context = new DemoEntities())
                {
                    var user = context.Users
                        .FirstOrDefault(u => u.Login == login && u.Pass ==password);

                    if (user != null)
                    {
                        var role = user.Role?.RoleName ?? "неизвестный";
                        MessageBox.Show($"Добро пожаловатьб {login}! ваша роль: {role}");

                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения к базе данных" + ex.Message );
            }

        }
    }
}
