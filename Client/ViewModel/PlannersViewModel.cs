﻿using Client.Model;
using Client.View;
using Common;
using log4net;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Client.ViewModel
{
	public class PlannersViewModel : BindableBase
	{
		//			   method name, parameter
		private Stack<Tuple<string, object, object>> undoStack = new Stack<Tuple<string, object, object>>();
		private Stack<Tuple<string, object, object>> redoStack = new Stack<Tuple<string, object, object>>();

		private ObservableCollection<Planner> plannersToShow;

		public ObservableCollection<Planner> PlannersToShow
		{
			get => plannersToShow;
			set
			{
				plannersToShow = value;
				OnPropertyChanged(nameof(PlannersToShow));
			}
		}

		public Command<int> AddEventCommand { get; set; } // parameter is id of planner
		public Command AddPlannerCommand { get; set; }
		public Command<string> SearchCommand { get; set; } // parameter is text for search
		public Command<int> RemovePlannerCommand { get; set; }
		public Command<int> EditPlannerCommand { get; set; }
		public Command<int> DoublePlannerCommand { get; set; }
		public Command<int> EditEventCommand { get; set; }
		public Command<int> RemoveEventCommand { get; set; }
		public Command UndoCommand { get; set; }
		public Command RedoCommand { get; set; }
		public SnackbarMessageQueue MessageQueue { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PlannersViewModel()
		{
			PlannersToShow = new ObservableCollection<Planner>();

			ChangingViewEvents.Instance.PlannersEvent += (sender, e) => { plannersToShow.Clear(); LoginViewModel.proxy.GetPlanners().ForEach(item => PlannersToShow.Add(item)); };
			ChangingViewEvents.Instance.DashboardEvent += (sender, e) => { undoStack.Clear(); redoStack.Clear(); };
			ChangingViewEvents.Instance.LogoutEvent += (sender, e) => { undoStack.Clear(); redoStack.Clear(); };
			ChangingViewEvents.Instance.AddUserEvent += (sender, e) => { undoStack.Clear(); redoStack.Clear(); };

			SearchCommand = new Command<string>(OnSearch);
			AddEventCommand = new Command<int>(OnAddEvent);
			AddPlannerCommand = new Command(OnAddPlanner);
			RemovePlannerCommand = new Command<int>(OnRemovePlanner);
			EditPlannerCommand = new Command<int>(OnEditPlanner);
			DoublePlannerCommand = new Command<int>(OnDoublePlanner);
			EditEventCommand = new Command<int>(OnEditEvent);
			RemoveEventCommand = new Command<int>(OnRemoveEvent);

			UndoCommand = new Command(OnUndo);
			RedoCommand = new Command(OnRedo);
			MessageQueue = new SnackbarMessageQueue(TimeSpan.FromSeconds(2));
		}

		private void OnRedo()
		{
			if (redoStack.Count <= 0)
			{
				LogManager.GetLogger(typeof(PlannersViewModel)).Debug($"Redo - but no action left");
				MessageQueue.Enqueue("Redo not available");
				return;
			}

			var redo = redoStack.Pop();

			string userNameThatRequested = LoginViewModel.factory.Credentials.UserName.UserName;
			switch (redo.Item1)
			{
				case "AddEvent":
					LoginViewModel.proxy.RemoveEvent((int)redo.Item2, userNameThatRequested);
					break;
				case "AddPlanner":
					LoginViewModel.proxy.RemovePlanner((int)redo.Item2, userNameThatRequested);
					break;
				case "RemovePlanner":
					LoginViewModel.proxy.AddPlanner(redo.Item2 as Planner, userNameThatRequested);
					break;
				case "RemoveEvent":
					LoginViewModel.proxy.AddEvent(redo.Item2 as Event, (int)redo.Item3, userNameThatRequested);
					break;
				case "EditEvent":
					LoginViewModel.proxy.EditEvent(redo.Item2 as Event, userNameThatRequested);
					break;
				case "EditPlanner":
					LoginViewModel.proxy.EditPlanner(redo.Item2 as Planner, userNameThatRequested);
					break;
				default:
					break;
			}
			LogManager.GetLogger(typeof(PlannersViewModel)).Debug($"Redo: {redo.Item1}|{redo.Item2}|{redo.Item3}");
			MessageQueue.Enqueue("Redo successful");
			ChangingViewEvents.Instance.RaisePlannersEvent();
		}

		private void OnUndo()
		{
			if (undoStack.Count <= 0)
			{
				LogManager.GetLogger(typeof(PlannersViewModel)).Debug($"Undo - but no action left");
				MessageQueue.Enqueue("Undo not available");
				return;
			}

			var undo = undoStack.Pop();

			string userNameThatRequested = LoginViewModel.factory.Credentials.UserName.UserName;
			switch (undo.Item1)
			{
				case "RemoveEvent":
					LoginViewModel.proxy.AddEvent(undo.Item3 as Event, (int)undo.Item2, userNameThatRequested);
					var e = LoginViewModel.proxy.GetPlanner((int)undo.Item2).Events.Last();
					redoStack.Push(new Tuple<string, object, object>("AddEvent", e.Id, null));
					break;
				case "RemovePlanner":
					LoginViewModel.proxy.AddPlanner(undo.Item2 as Planner, userNameThatRequested);
					int p = LoginViewModel.proxy.GetPlanners().Last().Id;
					redoStack.Push(new Tuple<string, object, object>("AddPlanner", p, null));
					break;
				case "AddPlanner":
					int idp = (int)undo.Item2;
					var pp = LoginViewModel.proxy.GetPlanner(idp);
					LoginViewModel.proxy.RemovePlanner(idp, userNameThatRequested);
					redoStack.Push(new Tuple<string, object, object>("RemovePlanner", pp, null));
					break;
				case "AddEvent":
					int eid = (int)undo.Item2;
					var ee = LoginViewModel.proxy.GetEvent(eid);
					var ps = LoginViewModel.proxy.GetPlanners();
					int eepid = -1;
					foreach (var item in ps)
					{
						foreach (var item2 in item.Events)
						{
							if (item2.Id == eid)
							{
								eepid = item.Id;
								break;
							}
						}
						if (eepid != -1)
						{
							break;
						}
					}
					LoginViewModel.proxy.RemoveEvent(eid, userNameThatRequested);
					redoStack.Push(new Tuple<string, object, object>("RemoveEvent", ee, eepid));
					break;
				case "EditEvent":
					var eve = LoginViewModel.proxy.GetEvent((undo.Item2 as Event).Id);
					LoginViewModel.proxy.EditEvent(undo.Item2 as Event, userNameThatRequested);
					redoStack.Push(new Tuple<string, object, object>("EditEvent", eve, null));
					break;
				case "EditPlanner":
					var plan = LoginViewModel.proxy.GetPlanner((undo.Item2 as Planner).Id);
					LoginViewModel.proxy.EditPlanner(undo.Item2 as Planner, userNameThatRequested);
					redoStack.Push(new Tuple<string, object, object>("EditPlanner", plan, null));
					break;
				default:
					break;
			}
			LogManager.GetLogger(typeof(PlannersViewModel)).Debug($"Undo: {undo.Item1}|{undo.Item2}|{undo.Item3}");
			MessageQueue.Enqueue("Undo successful");
			ChangingViewEvents.Instance.RaisePlannersEvent();
		}

		private void OnRemoveEvent(int id)
		{
			int planId = -1;
			foreach (var item in plannersToShow)
			{
				foreach (var item2 in item.Events)
				{
					if (item2.Id == id)
					{
						planId = item.Id;
						break;
					}
				}
				if (planId != -1)
				{
					break;
				}
			}

			var e = LoginViewModel.proxy.GetEvent(id);
			undoStack.Push(new Tuple<string, object, object>("RemoveEvent", planId, e));

			LoginViewModel.proxy.RemoveEvent(id, LoginViewModel.factory.Credentials.UserName.UserName);
			LogManager.GetLogger(typeof(PlannersViewModel)).Info($"Event removed: id={id}");
			MessageQueue.Enqueue("Event removed");
			ChangingViewEvents.Instance.RaisePlannersEvent();
		}

		private void OnRemovePlanner(int id)
		{
			var p = LoginViewModel.proxy.GetPlanner(id);
			undoStack.Push(new Tuple<string, object, object>("RemovePlanner", p, null));

			LoginViewModel.proxy.RemovePlanner(id, LoginViewModel.factory.Credentials.UserName.UserName);
			LogManager.GetLogger(typeof(PlannersViewModel)).Info($"Planner removed: id={id}");
			MessageQueue.Enqueue("Planner removed");
			ChangingViewEvents.Instance.RaisePlannersEvent();
		}

		private void OnAddPlanner()
		{
			bool? result = new AddPlannerWindow().ShowDialog();
			if (result.Value)
			{
				int pid = LoginViewModel.proxy.GetPlanners().Last().Id;
				undoStack.Push(new Tuple<string, object, object>("AddPlanner", pid, null));
				LogManager.GetLogger(typeof(PlannersViewModel)).Info($"Planner added: id={pid}");
				MessageQueue.Enqueue("Planner added");
			}
			ChangingViewEvents.Instance.RaisePlannersEvent();
		}

		private void OnEditEvent(int obj)
		{
			var eve = LoginViewModel.proxy.GetEvent(obj);
			MessageHost.Instance.SendMessage(eve);
			foreach (var item in LoginViewModel.proxy.GetPlanners())
			{
				foreach (var item2 in item.Events)
				{
					if (item2.Id == eve.Id)
					{
						MessageHost.Instance.SendMessage(item.Id);
						goto Found;
					}
				}
			}
			Found:
			bool? result = new EditEventWindow().ShowDialog();
			var oldEvent = MessageHost.Instance.GetMessage() as Event;
			if (result.Value)
			{
				string response = MessageHost.Instance.GetMessage() as string;
				if (response == "Add")
				{
					int eid = LoginViewModel.proxy.GetEvents().LastOrDefault().Id;
					undoStack.Push(new Tuple<string, object, object>("AddEvent", eid, null));
					LogManager.GetLogger(typeof(PlannersViewModel)).Info($"Event edited: id={eid}");
				}
				else if (response == "Edit")
				{
					undoStack.Push(new Tuple<string, object, object>("EditEvent", oldEvent, null));
					LogManager.GetLogger(typeof(PlannersViewModel)).Info($"Event edited: id={oldEvent.Id}");
				}
				MessageQueue.Enqueue("Event edited");
			}
			ChangingViewEvents.Instance.RaisePlannersEvent();
		}

		private void OnDoublePlanner(int obj)
		{
			var plan = LoginViewModel.proxy.GetPlanner(obj);
			LoginViewModel.proxy.AddPlanner(plan, LoginViewModel.factory.Credentials.UserName.UserName);
			int id = LoginViewModel.proxy.GetPlanners().Last().Id;
			undoStack.Push(new Tuple<string, object, object>("AddPlanner", id, null));
			LogManager.GetLogger(typeof(PlannersViewModel)).Info($"Planner doubled: id={obj}");
			MessageQueue.Enqueue("Planner doubled");
			ChangingViewEvents.Instance.RaisePlannersEvent();
		}

		private void OnEditPlanner(int obj)
		{
			var planner = LoginViewModel.proxy.GetPlanner(obj);
			MessageHost.Instance.SendMessage(planner);
			bool? result = new EditPlannerWindow().ShowDialog();
			object oldPlaner = MessageHost.Instance.GetMessage();
			if (result.Value)
			{
				string response = MessageHost.Instance.GetMessage() as string;
				if (response == "Add")
				{
					int pid = LoginViewModel.proxy.GetPlanners().Last().Id;
					undoStack.Push(new Tuple<string, object, object>("AddPlanner", pid, null));
					LogManager.GetLogger(typeof(PlannersViewModel)).Info($"Planner edited: id={pid}");
				}
				else if (response == "Edit")
				{
					undoStack.Push(new Tuple<string, object, object>("EditPlanner", oldPlaner, null));
					LogManager.GetLogger(typeof(PlannersViewModel)).Info($"Planner edited: id={oldPlaner}");
				}
				MessageQueue.Enqueue("Planner edited");
			}
			ChangingViewEvents.Instance.RaisePlannersEvent();
		}

		private void OnAddEvent(int obj)
		{
			var Window = new AddEventWindow();
			MessageHost.Instance.SendMessage(obj);
			bool? result = Window.ShowDialog();
			if (result.Value)
			{
				int eid = LoginViewModel.proxy.GetEvents().LastOrDefault().Id;
				undoStack.Push(new Tuple<string, object, object>("AddEvent", eid, null));
				LogManager.GetLogger(typeof(PlannersViewModel)).Info($"Event added: id={eid}");
				MessageQueue.Enqueue("Event added");
			}
			ChangingViewEvents.Instance.RaisePlannersEvent();
		}

		private void OnSearch(string obj)
		{
			if (string.IsNullOrEmpty(obj))
			{
				PlannersToShow.Clear();
				LoginViewModel.proxy.GetPlanners().ForEach(item => PlannersToShow.Add(item));
				return;
			}
			var finded = new ObservableCollection<Planner>();
			var plannersList = LoginViewModel.proxy.GetPlanners();
			foreach (var item in plannersList)
			{
				if (item.Name.ToLower().Contains(obj.ToLower()))
				{
					finded.Add(item);
					continue;
				}
				if (item.Description.ToLower().Contains(obj.ToLower()))
				{
					finded.Add(item);
					continue;
				}
			}

			PlannersToShow = finded;
		}
	}
}
