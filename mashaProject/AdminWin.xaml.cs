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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class AdminWin : Window
    {
        public AdminWin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ClientsWindow clientsWindow= new ClientsWindow();
            clientsWindow.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AddClient addClient= new AddClient();
            addClient.Show();
        }
    }
}
