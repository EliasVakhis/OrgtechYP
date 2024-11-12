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
    /// Логика взаимодействия для AddRequest.xaml
    /// </summary>
    public partial class AddRequest : Window
    {
        YPOrgtechBDEntities dbOrgTech = new YPOrgtechBDEntities();


        public AddRequest()
        {
            InitializeComponent();
            vidorg.ItemsSource = dbOrgTech.EquipmentTypes.ToList();
            customers.ItemsSource = dbOrgTech.Users.Where(u => u.UserTypes.UserTypeName == "Заказчик").ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Создаем новый объект Equipment (Оборудование)
            Equipment equipment = new Equipment
            {
                // Устанавливаем ID типа оборудования на основе выбранного индекса в vidorg
                EquipmentTypeID = vidorg.SelectedIndex + 1,

                // Устанавливаем модель оборудования из текстового поля model
                Model = model.Text,
            };

            dbOrgTech.Equipment.Add(equipment);
            dbOrgTech.SaveChanges();
            RepairRequests repairRequest = new RepairRequests();
            repairRequest.StartDate = DateTime.Now;
            repairRequest.Equipment = equipment;
            repairRequest.ProblemDescription = description.Text;
            repairRequest.StatusID = 1;
            repairRequest.Users = customers.SelectedItem as Users;

            // Добавляем запрос на ремонт в контекст базы данных и сохраняем изменения
            dbOrgTech.RepairRequests.Add(repairRequest);
            dbOrgTech.SaveChanges();

            MessageBox.Show("Заявка успешно добавлена!");
        }
    }
}
