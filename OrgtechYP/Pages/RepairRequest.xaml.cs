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
    /// Логика взаимодействия для RepairRequest.xaml
    /// </summary>
    public partial class RepairRequest : Window
    {
        YPOrgtechBDEntities dbOrgTech = new YPOrgtechBDEntities();

        public RepairRequest()
        {
            InitializeComponent();
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Получаем выбранный элемент из таблицы (DataGrid) и приводим тип к RepairRequests
            var selectedRequest = dg.SelectedItem as RepairRequests;
        
            DateTime StartDate = selectedRequest.StartDate;

            DateTime CompletionDate = (DateTime)selectedRequest.CompletionDate;

            TimeSpan duration = CompletionDate - StartDate;

            // Получаем количество дней, потраченных на выполнение запроса
            int daysTaken = duration.Days;

            MessageBox.Show($"{daysTaken}");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dg.ItemsSource = dbOrgTech.RepairRequests.Where(x => x.Statuses.StatusName == "Выполнен").ToList();
            var completedRequests = dbOrgTech.RepairRequests.Where(x => x.Statuses.StatusName == "Выполнен").ToList();
            dg.ItemsSource = completedRequests;
            if (completedRequests.Count > 0)
            {
                double totalDays = 0;
                int requestCount = 0;
                int requestCount2 = completedRequests.Count;

                // Вычисляем общее количество дней выполнения для всех запросов
                foreach (var request in completedRequests)
                {
                    DateTime startDate = request.StartDate;
                    DateTime completionDate = (DateTime)request.CompletionDate;
                    TimeSpan duration = completionDate - startDate;
                    totalDays += duration.TotalDays;
                    requestCount++;
                }
                // Отображаем информацию о среднем количестве выполненных заявок и общем количестве выполненных заявок

                double averageDays = totalDays / requestCount;
                QuantityDay.Content = $"Среднее количество дней выполнения заявок: {averageDays:F2}";
                ZZZ.Content = $"Количество выполненных заявок: {requestCount2}";
            }
        }
    }
}
