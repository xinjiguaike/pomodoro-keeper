/***********************************************************************
 * Module:  InventoryTask.cs
 * Author:  Rudy
 * Purpose: Definition of the Class InventoryTask
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
	[Table("InventoryTask")]
	public class InventoryTask : INotifyPropertyChanged
	{
		private string _strDescription;

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public int Priority { get; set; }

		[Ignore]
		public string Description
		{
			get { return _strDescription; }
			set
			{
				_strDescription = value;
				OnPropertyChanged("Description");
			}
		}
		
		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

