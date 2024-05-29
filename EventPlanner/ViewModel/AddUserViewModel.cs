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
    public class AddUserViewModel : INotifyPropertyChanged
    {
        private User _user = new User();
        public User User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        public ICommand AddUserCommand { get; }
        public ICommand CancelCommand { get; }

        public AddUserViewModel()
        {
            AddUserCommand = new RelayCommand(param => AddUser(), param => true);
            CancelCommand = new RelayCommand(param => Cancel(), param => true);
        }

        private void AddUser()
        {
            // Implement logic to add the user
            // This could involve saving the user to a database or another storage mechanism
            Console.WriteLine("Adding user...");
        }

        private void Cancel()
        {
            // Implement logic to cancel the user addition process
            // This could involve resetting form fields or navigating away from the view
            Console.WriteLine("Cancelling user addition...");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
