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

namespace EventPlanner.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }
        /*
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            int lg;
            if (VerifyUser(txtUsername.Text, passwordbox.Password, out lg) && lg == 1)
            {
                MessageBox.Show("Successfully logged in as admin!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                MainWindow window = new MainWindow();
                window.Show();
            }
            else if (VerifyUser(txtUsername.Text, passwordbox.Password, out lg) && lg == 2)
            {
                MessageBox.Show("Successfully logged in as user!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                PlannerDashboardView plannerDashboard = new PlannerDashboardView();
                plannerDashboard.Show();
            }
            else
            {
                MessageBox.Show("Incorrect data", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            txtUsername.Text = "";
            passwordbox.Password = "";
        }

        */
        private bool VerifyUser(string username, string password, out int logcode)
        {
            bool result = false;
            logcode = 0;

          
            if (username.Equals("admin") && password.Equals("admin"))
            {
                result = true;
                logcode = 1;
            }
            else if (username.Equals("korisnik") && password.Equals("korisnik"))
            {
                result = true;
                logcode = 2;
            }

            return result;
        }
    }
}
