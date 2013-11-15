using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using PomodoroKeeper.ControlsSample;
using PomodoroKeeper.Views;
using PomodoroKeeper.PomodoroViews;
using PomodoroKeeper.Model;
using Windows.ApplicationModel.Resources.Core;
using Windows.ApplicationModel.Resources;
using Windows.Storage;
using System.Globalization;
using Windows.Globalization;
using SQLite;
using Windows.UI.Popups;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=234227

namespace PomodoroKeeper
{
	/// <summary>
	/// Provides application-specific behavior to supplement the default Application class.
	/// </summary>
	sealed partial class App : Application//, INotifyPropertyChanged
	{
		/// Global Data for all pages to share.
		
		private ApplicationDataContainer dataContainer = ApplicationData.Current.LocalSettings;

		public ToDoSheet PomToDoSheet;
		public PomSettings LocalPomSettings;
		public ResourceLoader ResLoader = new ResourceLoader();
		public static SQLiteAsyncConnection Connection { get; set; }

		/// <summary>
		/// Initializes the singleton application object.  This is the first line of authored code
		/// executed, and as such is the logical equivalent of main() or WinMain().
		/// </summary>
		public App()
		{
			// Initializes the global data.
			PomToDoSheet = new ToDoSheet() { Date = DateTime.Today };

			//Access the Local Settings - by Rudy
			LocalPomSettings = new PomSettings();
			if(dataContainer.Values.ContainsKey("pomIndex"))
				LocalPomSettings.PomIndex = (int)dataContainer.Values["pomIndex"];
			if (dataContainer.Values.ContainsKey("breakIndex"))
				LocalPomSettings.BreakIndex = (int)dataContainer.Values["breakIndex"];
			if (dataContainer.Values.ContainsKey("longBreakIndex"))
				LocalPomSettings.LongBreakIndex = (int)dataContainer.Values["longBreakIndex"];
			if (dataContainer.Values.ContainsKey("pomNumBeforeLongBreak"))
				LocalPomSettings.PomNumBeforeLongBreak = (int)dataContainer.Values["pomNumBeforeLongBreak"];

			this.InitializeComponent();
			this.Suspending += OnSuspending;
		}

		static Frame rootFrame;

		/// <summary>
		/// Invoked when the application is launched normally by the end user.  Other entry points
		/// will be used when the application is launched to open a specific file, to display
		/// search results, and so forth.
		/// </summary>
		/// <param name="args">Details about the launch request and process.</param>
		protected override async void OnLaunched(LaunchActivatedEventArgs args)
		{
			try
			{
				await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync("pomtasks.db");
				Connection = new SQLiteAsyncConnection("pomtasks.db");
				GetData(); 
			}
			catch
			{
				CreateDB();
			}

			ResourceManager.Current.DefaultContext.QualifierValues.MapChanged += QualifierValues_MapChanged;

			rootFrame = Window.Current.Content as Frame;

			// Do not repeat app initialization when the Window already has content,
			// just ensure that the window is active
			if (rootFrame == null)
			{
				// Create a Frame to act as the navigation context and navigate to the first page
				rootFrame = new Frame();

				if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
				{
					//TODO: Load state from previously suspended application
				}

				// Place the frame in the current Window
				Window.Current.Content = rootFrame;
			}

			if (rootFrame.Content == null)
			{
				// When the navigation stack isn't restored navigate to the first page,
				// configuring the new page by passing required information as a navigation
				// parameter
				if (!rootFrame.Navigate(typeof(ToDoPage), args.Arguments))
				{
					throw new Exception("Failed to create initial page");
				}
			}
			// Ensure the current window is active
			Window.Current.Activate();
		}

		private void QualifierValues_MapChanged(IObservableMap<string, string> sender, IMapChangedEventArgs<string> @event)
		{
			TimerPage.pomTimer.SetPomContent(ResLoader);
		}

		public static void NavigateToPage(Type pageType)
		{
			if (rootFrame != null)
			{
				if (!rootFrame.Navigate(pageType))
				{
					throw new Exception("Failed to create initial page");
				}
			}
		}

		private async void CreateDB()
		{
			Connection = new SQLiteAsyncConnection("pomtasks.db");
			await Connection.CreateTableAsync<InventoryTask>();
			await Connection.CreateTableAsync<ToDoTask>();
			//await Connection.CreateTableAsync<DailyPerformance>();
		}

		private async void GetData()
		{
			try
			{
				List<ToDoTask> TaskList = await App.Connection.Table<ToDoTask>().ToListAsync();
				foreach (ToDoTask newTask in TaskList)
				{
					newTask.PomsList = newTask.GetPomsListFromBytes();
					if (newTask.IsUnplanned)
					{
						
						PomToDoSheet.AddUnplannedTask(newTask);
					}
					else
					{
						PomToDoSheet.AddToDoTask(newTask);
					}
				}
			}
			catch (Exception)
			{
				MessageDialog dialog = new MessageDialog("Something went wrong, try restarting the app");
			}
		}
		/// <summary>
		/// Invoked when application execution is being suspended.  Application state is saved
		/// without knowing whether the application will be terminated or resumed with the contents
		/// of memory still intact.
		/// </summary>
		/// <param name="sender">The source of the suspend request.</param>
		/// <param name="e">Details about the suspend request.</param>
		private void OnSuspending(object sender, SuspendingEventArgs e)
		{
			var deferral = e.SuspendingOperation.GetDeferral();
			//TODO: Save application state and stop any background activity

			//Save the LocalSettings - by Rudy
			dataContainer.Values["pomIndex"] = LocalPomSettings.PomIndex;
			dataContainer.Values["breakIndex"] = LocalPomSettings.BreakIndex;
			dataContainer.Values["longBreakIndex"] = LocalPomSettings.LongBreakIndex;
			dataContainer.Values["pomNumBeforeLongBreak"] = LocalPomSettings.PomNumBeforeLongBreak;
			//End save settings

			deferral.Complete();
		}
	}
}
