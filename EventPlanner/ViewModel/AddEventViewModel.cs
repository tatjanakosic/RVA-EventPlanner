using Common.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EventPlanner.ViewModel
{
    public class AddEventViewModel : INotifyPropertyChanged
    {
        private Event _event = new Event();
        public Event Event
        {
            get => _event;
            set
            {
                _event = value;
                OnPropertyChanged(nameof(Event));
            }
        }

        public ICommand AddEventCommand { get; }
        public ICommand CancelCommand { get; }

        public AddEventViewModel()
        {
            AddEventCommand = new RelayCommand(param => AddEvent(), param => true);
            CancelCommand = new RelayCommand(param => Cancel(), param => true);
        }

        private void AddEvent()
        {
            // Implement logic to add the event
            // This could involve saving the event to a database or another storage mechanism
            Console.WriteLine("Adding event...");
        }

        private void Cancel()
        {
            // Implement logic to cancel the event addition process
            // This could involve resetting form fields or navigating away from the view
            Console.WriteLine("Cancelling event addition...");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
