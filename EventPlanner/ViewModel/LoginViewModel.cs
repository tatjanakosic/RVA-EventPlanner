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
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _username;
        private string _password;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand LoginCommand { get; }
        public ICommand ClearFieldsCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(param => Login(), param => ValidateInput());
            ClearFieldsCommand = new RelayCommand(param => ClearFields(), param => true);
        }

        private bool ValidateInput()
        {
            // Implement validation logic here
            // Return true if valid, false otherwise
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);
        }

        private void Login()
        {
            if (ValidateInput())
            {
                // Implement login logic here
                Console.WriteLine("Logging in...");
            }
            else
            {
                Console.WriteLine("Invalid username or password.");
            }
        }

        private void ClearFields()
        {
            Username = string.Empty;
            Password = string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
