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
    /// Логика взаимодействия для ClientsWindow.xaml
    /// </summary>
    public partial class ClientsWindow : Window
    {
        private CustomerRepository repo = new CustomerRepository();
        private UserService us = new UserService();
        private AbonementRepository abonementRepo = new AbonementRepository();
        private int currentCustomerId = -1;
        public ClientsWindow()
        {
            InitializeComponent();

        }

        private void viewCustomer()
        {
            Customer customer = repo.searchCustomerByFio(customerSearch.Text);
            fio.Text = customer.Fio;
            balance.Text = customer.Balance.ToString();
            currentCustomerId = customer.CustomerId;
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            if (customerSearch.Text.Length < 3)
            {
                customerViewInfo.Text = "Минимум 3 символа для поиска!";
                return;
            }
            try
            {
                viewCustomer();
            }
            catch (NullReferenceException ex)
            {
                customerViewInfo.Text = "уточните запрос";
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (currentCustomerId < 0)
            {
                customerViewInfo.Text = "пользователь не выбран";
                return;
            }

            if(repo.updateCustomer(currentCustomerId,fio.Text,Decimal.Parse(balance.Text))){
                 customerViewInfo.Text = "обновлено";
            }else{
                viewCustomer();
                customerViewInfo.Text = "обновление не удалось";
            }
        }
        private void getCustomersAbonement()
        {
            Abonement abomenet = abonementRepo.getAbonementByCustomer(currentCustomerId);
            abDesc.Text = abomenet.Desc;
            abCost.Text = abomenet.Cost.ToString();
            abVisitCount.Text = abomenet.VisitsCount.ToString();
            abVisitRem.Text = abomenet.VisitsCountRem.ToString();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (currentCustomerId < 0)
            {
                customerViewInfo.Text = "пользователь не выбран";
                return;
            }
            try
            {
                getCustomersAbonement();
                return;
            }
            catch (Exception ex)
            {
                customerViewInfo.Text = ex.Message;
            }

        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            if (currentCustomerId < 0)
            {
                customerViewInfo.Text = "пользователь не выбран";
                return;
            }

            try{
                abonementRepo.getAbonementByCustomer(currentCustomerId);
                customerViewInfo.Text = "Абонемент уже существует! Удалите!";
                return;
            }

            catch (Exception ex){

            }
            try
            {
                if (abonementRepo.addAbonement(abDesc.Text, Decimal.Parse(abCost.Text), Int32.Parse(abVisitCount.Text), Int32.Parse(abVisitRem.Text), currentCustomerId))
                {
                    customerViewInfo.Text = "Добавлен!";
                    return;
                }
                else
                {
                    customerViewInfo.Text = "Ошибка!";
                }

 
            }
            catch (Exception ex)
            {
                customerViewInfo.Text = ex.Message;
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            if (abonementRepo.decreaseAbomenetVisits(currentCustomerId))
            {
                getCustomersAbonement();
            }
            else
            {
                customerViewInfo.Text = "Ошибка!";
            }

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if (currentCustomerId < 0)
            {
                customerViewInfo.Text = "пользователь не выбран";
                return;
            }

            if (abonementRepo.deleteCustAbomenet(currentCustomerId))
            {
                abDesc.Text = "удален";
                abCost.Text = "удален";
                abVisitCount.Text = "удален";
                abVisitRem.Text = "удален";
                return;
            }
            else
            {
                customerViewInfo.Text = "Ошибка!";
            }
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AdminWin adminWin = new AdminWin();
            adminWin.Show();
        }
    }
}
