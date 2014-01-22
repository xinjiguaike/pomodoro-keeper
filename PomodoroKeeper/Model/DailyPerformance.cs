/***********************************************************************
 * Module:  DailyPerformance.cs
 * Author:  Rudy
 * Purpose: Definition of the Class DailyPerformance
 ***********************************************************************/

using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
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
	[Table("DailyPerformance")]
	public class DailyPerformance: INotifyPropertyChanged
	{
		private int _internals;
		private int _externals;

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		public int StartedPoms { get; set; }

		public int EstimatedPoms { get; set; }

		public int CompletedPoms { get; set; }

		public int AbandonedPoms { get; set; }

		public int InternalInterrupts
		{
			get { return _internals; }
			set
			{
				_internals = value;
				OnPropertyChanged("InternalInterrupts");
			}
		}

		public int ExternalInterrupts
		{
			get { return _externals; }
			set
			{
				_externals = value;
				OnPropertyChanged("ExternalInterrupts");
			}
		}

		public DateTime Date { get; set; }


		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}