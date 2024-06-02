﻿using Client.Model;
using Common;
using log4net;
using MaterialDesignThemes.Wpf;
using System;
using System.Linq;
using System.Windows.Controls;

namespace Client.ViewModel
{
	public class AddUserViewModel : BindableBase
	{
		private User user;

		public Command<object> CreateUserCommand { get; set; }

		public User User
		{
			get => user;
			set
			{
				user = value;
				OnPropertyChanged(nameof(User));
			}
		}

		public string SelectedRole { get; set; } = "Regular User";
		public string Username { get; set; }
		public string Name { get; set; }
		public string Lastname { get; set; }
		public string Password { get; set; }
		public SnackbarMessageQueue MessageQueue { get; set; }

		public AddUserViewModel()
		{
			CreateUserCommand = new Command<object>(OnCreate);
			MessageQueue = new SnackbarMessageQueue(TimeSpan.FromSeconds(2));
		}

		private void OnCreate(object obj)
		{
			Password = (obj as PasswordBox).Password;
			switch (SelectedRole.Split(new string[] { ": " }, System.StringSplitOptions.None).LastOrDefault())
			{
				case "Administrator":
					User = new Administrator(Name, Lastname, Username, Password);
					break;
				case "Regular User":
					User = new RegularUser(Name, Lastname, Username, Password);
					break;
				default:
					return;
			}

			User.Validate();

			if (!User.IsValid)
			{
				return;
			}

			if (!LoginViewModel.proxy.AddUser(User))
			{
				LogManager.GetLogger(typeof(AddUserViewModel)).Info($"Error adding user: {User.Username}");
				MessageQueue.Enqueue($"{Username} already exist!");
				User.ValidationErrors[nameof(Username)] = "*";
				OnPropertyChanged(nameof(User));
				return;
			}
			MessageQueue.Enqueue($"Added user: {Username}");

			LogManager.GetLogger(typeof(AddUserViewModel)).Info($"Added user: {User.Username}|{User.Password}");

			User = null;
			Name = Lastname = Username = Password = "";
			(obj as PasswordBox).Password = "";
			OnPropertyChanged(nameof(Name));
			OnPropertyChanged(nameof(Lastname));
			OnPropertyChanged(nameof(Username));
			OnPropertyChanged(nameof(Password));
		}
	}
}
