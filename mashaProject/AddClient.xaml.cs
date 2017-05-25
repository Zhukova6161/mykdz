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
using System.Windows.Shapes;

namespace mashaProject
{
    /// <summary>
    /// Логика взаимодействия для AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
        CustomerRepository repo = new CustomerRepository();
        public AddClient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

            if (repo.addCustomer(newFio.Text, Decimal.Zero))
            {
                addInfo.Text = "Добавлен";
            }
            else
            {
                addInfo.Text = "Ошибка добавление, возм пользователь уже существует";
            }
                   

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AdminWin adminWin = new AdminWin();
            adminWin.Show();
        }
    }
}
