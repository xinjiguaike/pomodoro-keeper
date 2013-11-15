/***********************************************************************
 * Module:  ToDoTask.cs
 * Author:  Rudy
 * Purpose: Definition of the Class ToDoTask
 ***********************************************************************/

using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace PomodoroKeeper.Model
{
	[Table("ToDoTask")]
	public class ToDoTask :  INotifyPropertyChanged//InventoryTask,
	{
		private string _strDescription;
		private int _internalInterrupts;
		private int _externalInterrupts;
		private double _taskOpacity;
		private bool _bDone;
		private string _taskColor;
		private bool _bSelected;

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		public DateTime Date { get; set; }

		public int Priority { get; set; }

		public int EstimatedPoms { get; set; }

		public bool IsUnplanned { get; set; }

		public int CompletedPomos { get; set; }

		public int AbandonedPoms { get; set; }

		public int RunningPomIndex { get; set; }

		public string Description
		{
			get { return _strDescription; }
			set
			{
				_strDescription = value;
				OnPropertyChanged("Description");
			}
		}

		public string TaskColor
		{
		    get { return _taskColor; }
		    set
		    {
				_taskColor = value;
				OnPropertyChanged("TaskColor");
		    }
		}

		public bool IsSelected
		{
		    get { return _bSelected; }
		    set
		    {
				_bSelected = value;
				OnPropertyChanged("IsSelected");
		    }
		}
		
		public bool IsDone
		{
		    get { return _bDone; }
		    set
		    {
				_bDone = value;
				OnPropertyChanged("IsDone");
		    }
		}

		public int InternalInterrupts
		{
		    get { return _internalInterrupts; }
		    set
		    {
				_internalInterrupts = value;
				OnPropertyChanged("InternalInterrupts");
		    }
		}

		public int ExternalInterrupts
		{
		    get { return _externalInterrupts; }
		    set
			{
				_externalInterrupts = value;
				OnPropertyChanged("ExternalInterrupts");
			}
		}

		public double TaskOpacity
		{
			get { return _taskOpacity; }
			set
			{
				_taskOpacity = value;
				OnPropertyChanged("TaskOpacity");
		    }
		}

		
		public byte[] PomsBytes { get; set; }

		[Ignore]
		public ObservableCollection<string> PomsList { get; set; }

		public ToDoTask()
		{
			TaskOpacity = 1;
		}

		public ObservableCollection<string> GetPomsListFromBytes()
		{
			ObservableCollection<string> newPomsList = new ObservableCollection<string>();
			for(int i = 0; i < PomsBytes.Length; i++)
			{
				if (PomsBytes[i] == 0)
					newPomsList.Add("White");
				else if (PomsBytes[i] == 1)
					newPomsList.Add("Yellow");
				else if (PomsBytes[i] == 2)
					newPomsList.Add("Red");
			}
			return newPomsList;
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged(string propertyName)
		{
		    if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}