using PomodoroKeeper.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


// The Grouped Items Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234231

namespace PomodoroKeeper.PomodoroViews
{
	/// <summary>
	/// A page that displays a grouped collection of items.
	/// </summary>
	public sealed partial class PerformancePage : PomodoroKeeper.Common.LayoutAwarePage
	{
		static ObservableCollection<int> PomsLineCollection = new ObservableCollection<int>();
		static ObservableCollection<int> DayPerformanceCollection = new ObservableCollection<int>();
		static Random newRandom = new Random();
		static PerformancePage()
		{
			for (int i = 0; i < 11; i++)
			{
				PomsLineCollection.Add(20 - 2*i);
			}
			for (int j = 0; j < 30; j++)
			{
				DayPerformanceCollection.Add(newRandom.Next(0, 400));
			}
		}
		public PerformancePage()
		{
			//ToolTip
			this.InitializeComponent();
			lvPomsLine.ItemsSource = PomsLineCollection;
			gvPerformanceDay.ItemsSource = (Application.Current as App).CurrentMonthPerformance;
			//PerformanceChart.DataContext = PomsLineCollection;
			//PerformanceScrollViewer.MouseWheel += new MouseWheelEventHandler(PerformanceScrollViewer_MouseWheel);
		}


		/// <summary>
		/// Populates the page with content passed during navigation.  Any saved state is also
		/// provided when recreating a page from a prior session.
		/// </summary>
		/// <param name="navigationParameter">The parameter value passed to
		/// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
		/// </param>
		/// <param name="pageState">A dictionary of state preserved by this page during an earlier
		/// session.  This will be null the first time a page is visited.</param>
		protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
		{
			// TODO: Assign a collection of bindable groups to this.DefaultViewModel["Groups"]
		}
		
	}
}
