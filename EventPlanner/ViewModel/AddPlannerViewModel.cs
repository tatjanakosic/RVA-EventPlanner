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
    public class AddPlannerViewModel : INotifyPropertyChanged
    {
        private Planner _planner = new Planner();
        public Planner Planner
        {
            get => _planner;
            set
            {
                _planner = value;
                OnPropertyChanged(nameof(Planner));
            }
        }

        public ICommand AddPlannerCommand { get; }
        public ICommand CancelCommand { get; }

        public AddPlannerViewModel()
        {
            AddPlannerCommand = new RelayCommand(param => AddPlanner(), param => true);
            CancelCommand = new RelayCommand(param => Cancel(), param => true);
        }

        private void AddPlanner()
        {
            // Implement logic to add the planner
            // This could involve saving the planner to a database or another storage mechanism
            Console.WriteLine("Adding planner...");
        }

        private void Cancel()
        {
            // Implement logic to cancel the planner addition process
            // This could involve resetting form fields or navigating away from the view
            Console.WriteLine("Cancelling planner addition...");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
