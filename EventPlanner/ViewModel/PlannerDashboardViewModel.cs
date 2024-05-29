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
    internal class PlannerDashboardViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Planner> _planners = new ObservableCollection<Planner>();
        public ObservableCollection<Planner> Planners
        {
            get => _planners;
            set
            {
                _planners = value;
                OnPropertyChanged(nameof(Planners));
            }
        }

        // Command for adding a new planner
        public ICommand AddNewPlannerCommand { get; }

        // Constructor
        public PlannerDashboardViewModel()
        {
            // Initialize commands here if needed
            AddNewPlannerCommand = new RelayCommand(AddNewPlanner);
        }

        private void AddNewPlanner(object obj)
        {
            AddPlannerView addPlannerView = new AddPlannerView();
            addPlannerView.Show();
            // Logic to add a new planner
        }

        // Implement INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
    
