/***********************************************************************
 * Module:  Timer.cs
 * Author:  Rudy
 * Purpose: Definition of the Class Timer
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Windows.ApplicationModel.Resources;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace PomodoroKeeper.Model
{
	public enum Status 
	{
		Waitting,
		Running,
		Breaking
	}

	public class Timer: INotifyPropertyChanged
	{
		public ToDoTask CurrentTask;

		private DateTime TimeCounter { get; set; }

		public Status PomStatus { get; set; }

		private int PomodoringTime { get; set; }

		private int BreakingTime { get; set; }

		private string _strMinute;
		private string _strSecond;
		private string _strStartContent;

		public string TimerMinute
		{

			get { return _strMinute; }
			set 
			{
				_strMinute = value;
				OnPropertyChanged("TimerMinute");
			}
		}
		public string TimerSecond
		{
			get { return _strSecond; }
			set
			{
				_strSecond = value;
				OnPropertyChanged("TimerSecond");
			}
		}

		public string TimerStartContent
		{
			get { return _strStartContent; }
			set
			{
				_strStartContent = value;
				OnPropertyChanged("TimerStartContent");
			}
		}

		private bool _bWaiting;
		private bool _bBreaking;
		private double _pomProgress;
		private double _breakProgress;

		public bool IsWaiting
		{

			get { return _bWaiting; }
			set
			{
				_bWaiting = value;
				OnPropertyChanged("IsWaiting");
			}
		}
		public bool IsBreaking
		{

			get { return _bBreaking; }
			set
			{
				_bBreaking = value;
				OnPropertyChanged("IsBreaking");
			}
		}

		public double PomProgress
		{
			get { return _pomProgress; }
			set
			{
				_pomProgress = value;
				OnPropertyChanged("PomProgress");
			}
		}
		public double BreakProgress
		{
			get { return _breakProgress; }
			set
			{
				_breakProgress = value;
				OnPropertyChanged("BreakProgress");
			}
		}
		
		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
				handler(this, new PropertyChangedEventArgs(propertyName));
		}

		public void SetPomContent(ResourceLoader resLoader)
		{
			if (PomStatus == Status.Running)
				TimerStartContent = resLoader.GetString("ABANDON_POM");
			else
				TimerStartContent = resLoader.GetString("START_POM");
		}

		public Timer()
		{
			PomProgress = 0;
			BreakProgress = 0;
			IsBreaking = false;
			IsWaiting = true;
			PomStatus = Status.Waitting;
		}
	} 
}