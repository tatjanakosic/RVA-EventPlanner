using EventPlanner.Views;
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

namespace EventPlanner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

      
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MyServiceClient client = new MyServiceClient();
            try
            {
                //string result = client.GetData();
                //  MessageBox.Show(result);
                LoginView loginView = new LoginView();
                loginView.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
               // client.Close();
            }
        }
    }
}
