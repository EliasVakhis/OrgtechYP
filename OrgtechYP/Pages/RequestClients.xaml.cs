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
    /// Логика взаимодействия для RequestClients.xaml
    /// </summary>
    public partial class RequestClients : Window
    {
        public int ID;
        YPOrgtechBDEntities RepairRequestsDBEntities = new YPOrgtechBDEntities();

        public RequestClients()
        {
            InitializeComponent();
        }

        private void dg_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            RepairRequests repairRequest = dg.SelectedItem as RepairRequests;
            EditRequestForEmployee editRequest = new EditRequestForEmployee(repairRequest);
            editRequest.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dg.ItemsSource = RepairRequestsDBEntities.RepairRequests.Where(x => x.Users.UserID == ID).ToList();
        }
    }
}
