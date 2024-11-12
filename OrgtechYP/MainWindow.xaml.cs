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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OrgtechYP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        YPOrgtechBDEntities dbOrgTech = new YPOrgtechBDEntities();

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Выполнение логики авторизация
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = loginText.Text;
            string password = passwordText.Text;
            var user = dbOrgTech.Users.Where(x => x.Login == login && x.Password == password).FirstOrDefault();

            try
            {
                // Пользователь - Менеджер
                if (user.UserTypeID == 1)
                {
                    Pages.Manager manager = new Pages.Manager();
                    manager.Show();
                    
                }
                // Пользователь - Мастер
                if (user.UserTypeID == 2)
                {
                    Pages.Manager master = new Pages.Manager();
                    int selectedUser = user.UserTypeID;
                    master.ID = selectedUser;
                    master.Show();
                }
                // Пользователь - Оператор
                if (user.UserTypeID == 3)
                {
                    Pages.Operator client = new Pages.Operator();

                    client.Show();
                }
                // Пользователь - Клиент
                if (user.UserTypeID == 4)
                {
                    Pages.Client client = new Pages.Client();
                    int selectedUser = user.UserID;
                    client.ID = selectedUser;
                    client.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
            Close();
        }
    }
}
