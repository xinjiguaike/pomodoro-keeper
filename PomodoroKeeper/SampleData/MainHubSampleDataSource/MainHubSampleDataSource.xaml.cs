﻿//      *********    DO NOT MODIFY THIS FILE     *********
//      This file is regenerated by a design tool. Making
//      changes to this file can cause errors.
namespace PomodoroKeeper.SampleData.MainHubSampleDataSource
{
	using System;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Media; 

// To significantly reduce the sample data footprint in your production application, you can set
// the DISABLE_SAMPLE_DATA conditional compilation constant and disable sample data at runtime.
#if DISABLE_SAMPLE_DATA
	internal class MainHubSampleDataSource { }
#else

	public class MainHubSampleDataSource : System.ComponentModel.INotifyPropertyChanged
	{
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}

		public MainHubSampleDataSource()
		{
			try
			{
				System.Uri resourceUri = new System.Uri("ms-appx:/SampleData/MainHubSampleDataSource/MainHubSampleDataSource.xaml", System.UriKind.RelativeOrAbsolute);
                Application.LoadComponent(this, resourceUri);
			}
			catch (System.Exception)
			{
			}
		}

		private Groups1 _Groups = new Groups1();

		public Groups1 Groups
		{
			get
			{
				return this._Groups;
			}
		}

		private string _PageTitle = string.Empty;

		public string PageTitle
		{
			get
			{
				return this._PageTitle;
			}

			set
			{
				if (this._PageTitle != value)
				{
					this._PageTitle = value;
					this.OnPropertyChanged("PageTitle");
				}
			}
		}
	}

	public class GroupsItem1 : System.ComponentModel.INotifyPropertyChanged
	{
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}

		private Items1 _Items = new Items1();

		public Items1 Items
		{
			get
			{
				return this._Items;
			}
		}
	}

	public class Groups1 : System.Collections.ObjectModel.ObservableCollection<GroupsItem1>
	{ 
	}

	public class ItemsItem1 : System.ComponentModel.INotifyPropertyChanged
	{
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}

		private string _title = string.Empty;

		public string title
		{
			get
			{
				return this._title;
			}

			set
			{
				if (this._title != value)
				{
					this._title = value;
					this.OnPropertyChanged("title");
				}
			}
		}

		private ImageSource _img = null;

		public ImageSource img
		{
			get
			{
				return this._img;
			}

			set
			{
				if (this._img != value)
				{
					this._img = value;
					this.OnPropertyChanged("img");
				}
			}
		}
	}

	public class Items1 : System.Collections.ObjectModel.ObservableCollection<ItemsItem1>
	{ 
	}
#endif
}
