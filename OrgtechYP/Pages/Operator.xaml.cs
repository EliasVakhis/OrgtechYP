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
    /// Логика взаимодействия для Operator.xaml
    /// </summary>
    public partial class Operator : Window
    {
        YPOrgtechBDEntities rep = new YPOrgtechBDEntities();
        private RepairRequests selectedOrder;

        public Operator()
        {
            InitializeComponent();
            FillOrders();
            Vid.ItemsSource = rep.EquipmentTypes.ToList();
            Clients.ItemsSource = rep.Users.ToList();
            Stat.ItemsSource = rep.Statuses.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                selectedOrder.ProblemDescription = description.Text;
                selectedOrder.StatusID = Stat.SelectedIndex + 1;
                selectedOrder.CustomerID = Clients.SelectedIndex + 1;
                selectedOrder.EquipmentID = Vid.SelectedIndex + 1;
                selectedOrder.Equipment.Model = model.Text;

                rep.SaveChanges();
                MessageBox.Show("Изменения успешно сохранены.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Orders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                RepairRequests orders = Orders.SelectedItem as RepairRequests;
                selectedOrder = orders;
                description.Text = selectedOrder.ProblemDescription;
                Vid.Text = orders.Equipment.EquipmentTypes.TypeName;
                model.Text = orders.Equipment.Model;
                Clients.Text = orders.Users.FullName;
                Stat.Text = orders.Statuses.StatusName;
            }
            catch (Exception)
            {
                MessageBox.Show("Неверное действие");
            }
        }
        private void FillOrders()
        {
            Orders.ItemsSource = rep.RepairRequests.ToList();
        }

        private void NumberApp_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (NumberApp.Text != null)
            {
                int NumberZak = Convert.ToInt32(NumberApp.Text);
                Orders.ItemsSource = rep.RepairRequests.Where(x => x.RequestID == NumberZak).ToList();
            }
        }
    }
}
