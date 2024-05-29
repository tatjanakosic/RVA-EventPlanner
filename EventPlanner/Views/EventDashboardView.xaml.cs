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
    /// Interaction logic for EventDashboard.xaml
    /// </summary>
    public partial class EventDashboardView : Window
    {
        public EventDashboardView()
        {
            InitializeComponent();
        }

    }
}

/*
 * Kostur za view model
 * 
 public class EventViewModel : BindableBase
{
    // ...

    public ICommand UpdateEventCommand { get; }
    public ICommand DeleteEventCommand { get; }

    public EventViewModel()
    {
        // ...
        UpdateEventCommand = new RelayCommand<Event>(UpdateEvent);
        DeleteEventCommand = new RelayCommand<Event>(DeleteEvent);
    }

    private void UpdateEvent(Event eventToUpdate)
    {
        // Update the event in the database or other data source
    }

    private void DeleteEvent(Event eventToDelete)
    {
        // Delete the event from the database or other data source
    }
}
 
 
 
 
 */
