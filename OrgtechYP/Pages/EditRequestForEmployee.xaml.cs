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
    /// Логика взаимодействия для EditRequestForEmployee.xaml
    /// </summary>
    public partial class EditRequestForEmployee : Window
    {
        YPOrgtechBDEntities repair = new YPOrgtechBDEntities();
        RepairRequests request;

        public EditRequestForEmployee(RepairRequests repairRequest)
        {
            InitializeComponent();
            request = repair.RepairRequests.FirstOrDefault(rr => rr.RequestID == repairRequest.RequestID);
            newOtv.IsEnabled = true;
            var oldOtv = repair.ActiveRequests.FirstOrDefault(ar => ar.RequestID == request.RequestID);
            if (oldOtv != null)
            {
                oldOtvLabel.Text = $"{oldOtv.Users.FullName}";
                newOtv.ItemsSource = repair.Users.Where(x => x.UserTypeID == 2 && x.UserID != oldOtv.MasterID).ToList();
            }
            else
            {
                oldOtvLabel.Text = "Не назначен";
                newOtv.ItemsSource = repair.Users.Where(x => x.UserTypeID == 2).ToList();
            }
            oldEtap.Text = repairRequest.Statuses.StatusName;
            newEtap.ItemsSource = repair.Statuses.ToList();
            oldDesc.Text = repairRequest.ProblemDescription;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (request.StatusID == 1)
                {
                    request.ProblemDescription = newDesc.Text;
                    repair.SaveChanges();
                }
                else if (request.StatusID == 2)
                {
                    request.ProblemDescription = newDesc.Text;
                    repair.SaveChanges();

                    ActiveRequests requestActive = new ActiveRequests();
                    requestActive.RequestID = request.RequestID;
                    requestActive.StartDate = DateTime.Now;
                    requestActive.Users = newOtv.SelectedItem as Users;
                    repair.ActiveRequests.Add(requestActive);
                    repair.SaveChanges();
                }
                else if (request.StatusID == 3)
                {
                    ActiveRequests active = repair.ActiveRequests.FirstOrDefault(ar => ar.RepairRequests == request);
                    if (active != null)
                    {
                        repair.ActiveRequests.Remove(active);
                    }
                    request.ProblemDescription = newDesc.Text;
                    repair.SaveChanges();
                }
                MessageBox.Show("Сохранено!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }

        private void newEtap_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
