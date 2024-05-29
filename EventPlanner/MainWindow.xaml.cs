using Common.ServiceContracts;
using EventPlanner.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
        private readonly IService service_proxy;
        public MainWindow()
        {
            InitializeComponent();

            NetTcpBinding binding = new NetTcpBinding();
            var endpointAddress = new EndpointAddress("net.tcp://localhost:4000/ServiceImpl");
            var channelFactory = new ChannelFactory<IService>(binding, endpointAddress);
            service_proxy = channelFactory.CreateChannel();
        }

      
        private void Button_Click(object sender, RoutedEventArgs e)
        {
       
            try
            {
                string result = service_proxy.GetData();
                 MessageBox.Show(result);
                LoginView loginView = new LoginView();
                loginView.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PlannerDashboardView plannerDashboard = new PlannerDashboardView();
            plannerDashboard.Show();
        }
        
        
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            EventDashboardView eventDashboard = new EventDashboardView();
            eventDashboard.Show();
        }
    }
}
