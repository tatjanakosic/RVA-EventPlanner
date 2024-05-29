using Common.Classes;
using EventPlanner.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EventPlanner.ViewModel
{
    public class EventDashboardViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Event> _events = new ObservableCollection<Event>();
        public ObservableCollection<Event> Events
        {
            get => _events;
            set
            {
                _events = value;
                OnPropertyChanged(nameof(Events));
            }
        }

        // Placeholder for commands, you'll need to implement RelayCommand or similar
        public ICommand BackCommand { get; }
        public ICommand AddEventCommand { get; }
        public ICommand UpdateEventCommand { get; }
        public ICommand DeleteEventCommand { get; }

        public EventDashboardViewModel()
        {
            // Initialize commands here
            BackCommand = new RelayCommand(param => Back(), param => true); // Simple implementation
            AddEventCommand = new RelayCommand(param => AddEvent(), param => true); // Simple implementation
            UpdateEventCommand = new RelayCommand(param => UpdateEvent((Event)param), param => true); // Requires casting
            DeleteEventCommand = new RelayCommand(param => DeleteEvent((Event)param), param => true); // Requires casting
        }

        private void Back()
        {
            // Implement navigation back logic
        }

        private void AddEvent()
        {
            AddEventView addEvent = new AddEventView();
            addEvent.Show();
        }

        private void UpdateEvent(Event eventToUpdate)
        {
            // Implement logic to update an event
        }

        private void DeleteEvent(Event eventToDelete)
        {
            // Implement logic to delete an event
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
