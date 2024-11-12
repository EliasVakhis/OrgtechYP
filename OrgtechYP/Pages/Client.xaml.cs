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
    /// Логика взаимодействия для Client.xaml
    /// </summary>
    public partial class Client : Window
    {

        public int ID;
        YPOrgtechBDEntities rep = new YPOrgtechBDEntities();

        public Client()
        {
            InitializeComponent();
            Vid.ItemsSource = rep.EquipmentTypes.ToList();
            Clients.ItemsSource = rep.Users.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Equipment equipment = new Equipment();

                equipment.EquipmentTypeID = Vid.SelectedIndex + 1;
                equipment.Model = model.Text;
                rep.Equipment.Add(equipment);
                rep.SaveChanges();

                RepairRequests repairRequest = new RepairRequests
                {
                    StartDate = DateTime.Now,
                    Equipment = equipment,
                    ProblemDescription = description.Text,
                    StatusID = 1,
                    // Устанавливаем пользователя из выбранного элемента в Clients
                    Users = Clients.SelectedItem as Users,
                };

                // Выводим сообщение о том, что заявка успешно создана
                rep.RepairRequests.Add(repairRequest);
                rep.SaveChanges();
                MessageBox.Show("Заявка успешно создана");
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            RequestClients clients = new RequestClients();
            clients.ID = ID;
            clients.Show();
        }

        private void Vid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Clients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
