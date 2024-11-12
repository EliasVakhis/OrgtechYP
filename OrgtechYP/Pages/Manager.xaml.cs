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

namespace OrgtechYP.Pages
{
    /// <summary>
    /// Логика взаимодействия для Manager.xaml
    /// </summary>
    public partial class Manager : Window
    {
        public YPOrgtechBDEntities dbOrgTech = new YPOrgtechBDEntities();
        public int ID;

        public Manager()
        {
            InitializeComponent();
            dg.ItemsSource = dbOrgTech.RepairRequests.ToList();
            statuscombobox.ItemsSource = dbOrgTech.Statuses.ToList();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Pages.AddRequest addRequest = new Pages.AddRequest();
            addRequest.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Pages.Operator Operator = new Pages.Operator();
            Operator.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Pages.RepairRequest repairRequest = new Pages.RepairRequest();
            repairRequest.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RepairRequests repairRequest = dg.SelectedItem as RepairRequests;
            Pages.RequestClients editRequest = new Pages.RequestClients();
            editRequest.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (ID == 2)
            {
                ManagerAdd.Visibility = Visibility.Hidden;
                ManagerMster.Visibility = Visibility.Hidden;
                Applicatione.Visibility = Visibility.Hidden;
                Name.Content = "Мастер";
            }
        }

        private void nametextbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void statuscombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
