using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Npgsql;


namespace mashaProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            UserService userSevice = new UserService();
            if (userSevice.login(loginInput.Text, passwordInput.Text))
            {
                this.Hide();
                AdminWin adminWin = new AdminWin();
                adminWin.Show();

            }
            else
            {
                output.Text = "bad credentials";
            }

        }

    }
}
