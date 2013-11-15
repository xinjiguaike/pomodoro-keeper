using System;
using System.Collections.Generic;
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
using PomodoroKeeper.Model;
using System.Diagnostics;
using Windows.UI.ApplicationSettings;
using PomodoroKeeper.ControlsSample;
using Windows.UI.Popups;
using System.Collections.ObjectModel;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace PomodoroKeeper.PomodoroViews
{
	/// <summary>
	/// A basic page that provides characteristics common to most applications.
	/// </summary>
	public sealed partial class ToDoPage : PomodoroKeeper.Common.LayoutAwarePage
	{
		private ToDoTask currentManipulatedTask;
		private bool isEdit;

		static ToDoPage()
		{
			SettingsCommand cmd1 = new SettingsCommand("1", "Preference", c =>
			{
				PreferencePane newPreferencePane = new PreferencePane();
				newPreferencePane.Show();
			});
			SettingsCommand cmd2 = new SettingsCommand("2", "Feedback", c => { });
			SettingsCommand cmd3 = new SettingsCommand("3", "About", c => { });
			//Add the commands in the CommandsRequested Event. 
			SettingsPane.GetForCurrentView().CommandsRequested += (sp, arg) =>
			{
				arg.Request.ApplicationCommands.Add(cmd1);
				arg.Request.ApplicationCommands.Add(cmd2);
				arg.Request.ApplicationCommands.Add(cmd3);
			};
		}

		public ToDoPage()
		{
			this.InitializeComponent();
			btnEdit.DataContext = (Application.Current as App).PomToDoSheet;
			btnRemove.DataContext = (Application.Current as App).PomToDoSheet;
			lvToDo.ItemsSource = (Application.Current as App).PomToDoSheet.ToDoTaskList;
			lvUrgent.ItemsSource = (Application.Current as App).PomToDoSheet.UnplannedTaskList;

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
		}

		/// <summary>
		/// Preserves state associated with this page in case the application is suspended or the
		/// page is discarded from the navigation cache.  Values must conform to the serialization
		/// requirements of <see cref="SuspensionManager.SessionState"/>.
		/// </summary>
		/// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
		protected override void SaveState(Dictionary<String, Object> pageState)
		{
		}

		private void GoToTimer(object sender, RoutedEventArgs e)
		{
			Frame rootFrame = Window.Current.Content as Frame;
			rootFrame.Navigate(typeof(TimerPage));
		}

		private void GoToPerformance(object sender, RoutedEventArgs e)
		{
			Frame rootFrame = Window.Current.Content as Frame;
			rootFrame.Navigate(typeof(PerformancePage));
		}

		private void OnDoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
		{
			Frame rootFrame = Window.Current.Content as Frame;
			rootFrame.Navigate(typeof(TimerPage));
		}

		private void ListItem_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
		{
			//Debug.WriteLine("ListItem ManipulationStarted");
			//Debug.WriteLine("ManipulationOrigin: " + "X: " + e.Position.X.ToString() + " Y: " + e.Position.Y.ToString() + "\n");
			currentManipulatedTask = (e.OriginalSource as FrameworkElement).DataContext as ToDoTask;
		}

		private void ListItem_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
		{
			//Debug.WriteLine("ListItem ManipulationDelta");
			//Debug.WriteLine("ManipulationOrigin: " + "X: " + e.Position.X.ToString() + " Y: " + e.Position.Y.ToString() + "\n");
		}

		private async void ListItem_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
		{
			if (e.Cumulative.Translation.X > 200)//the distance of sliding to right is long enough.
			{
				currentManipulatedTask.IsDone = true;
				if (currentManipulatedTask.IsSelected)
				{
					currentManipulatedTask.IsSelected = false;
					//search the first undone task and set it to be selected.
					if (GetFirstUnDoneTask() != null)
					{
						GetFirstUnDoneTask().IsSelected = true;
						//update the first undone task in the DB after the current task marked done
						await App.Connection.UpdateAsync(GetFirstUnDoneTask());
					}
					else
					{
						(Application.Current as App).PomToDoSheet.SelectedTask = null;
					}
				}
				//update the current task in DB after the task marked done
				await App.Connection.UpdateAsync(currentManipulatedTask);
			}
			else if (e.Cumulative.Translation.X < -200)//the distance of sliding to left is long enough
			{
				currentManipulatedTask.IsDone = false;
				if ((Application.Current as App).PomToDoSheet.SelectedTask == null)
				{
					(Application.Current as App).PomToDoSheet.SelectedTask = currentManipulatedTask;
					currentManipulatedTask.IsSelected = true;
				}
				//update the current task after the task marked undone
				await App.Connection.UpdateAsync(currentManipulatedTask);
			}
		}

		private void OnChecked(object sender, RoutedEventArgs e)
		{
		  (Application.Current as App).PomToDoSheet.SelectedTask =  (e.OriginalSource as FrameworkElement).DataContext as ToDoTask;
		}

		private async void OnRemoveTask(object sender, RoutedEventArgs e)
		{
			if ((Application.Current as App).PomToDoSheet.SelectedTask != null)
			{
				//delete the selected task in the DB.
				await App.Connection.DeleteAsync((Application.Current as App).PomToDoSheet.SelectedTask);

				//remove the selected task
				if ((Application.Current as App).PomToDoSheet.SelectedTask.IsUnplanned)
				{
					(Application.Current as App).PomToDoSheet.RemoveUnplannedTask((Application.Current as App).PomToDoSheet.SelectedTask);
					//set the first undone task of the left to-do tasks to be selected
					if (GetFirstUnDoneTask() != null)
					{
						GetFirstUnDoneTask().IsSelected = true;
						//update the first undone task in the DB after the selected task deleted
						await App.Connection.UpdateAsync(GetFirstUnDoneTask());
					}
					else
					{
						(Application.Current as App).PomToDoSheet.SelectedTask = null;
					}
				}
				else
				{
					(Application.Current as App).PomToDoSheet.RemoveToDoTask((Application.Current as App).PomToDoSheet.SelectedTask);
					//set the first undone task of the left to-do tasks to be selected
					if (GetFirstUnDoneTask() != null)
					{
						GetFirstUnDoneTask().IsSelected = true;
						//update the first undone task in the DB after the selected task deleted
						await App.Connection.UpdateAsync(GetFirstUnDoneTask());
					}
					else
					{
						(Application.Current as App).PomToDoSheet.SelectedTask = null;
					}
				}
			}
		}

		private void OnAddTask(object sender, RoutedEventArgs e)
		{
			isEdit = false;
			gdAddTask.Visibility = Visibility.Visible;
			cbUnplanned.IsChecked = false;
			rbNormal.IsChecked = true;
			rsPoms.Value = 3;
			tbDescription.Focus(FocusState.Programmatic);
		}

		private void OnEditTask(object sender, RoutedEventArgs e)
		{
			isEdit = true;
			gdAddTask.Visibility = Visibility.Visible;
			cbUnplanned.IsChecked = (Application.Current as App).PomToDoSheet.SelectedTask.IsUnplanned;
			rsPoms.Value = (Application.Current as App).PomToDoSheet.SelectedTask.EstimatedPoms;
			
			if ((Application.Current as App).PomToDoSheet.SelectedTask.TaskColor.Equals("Brown"))
				rbNormal.IsChecked = true;
			else if ((Application.Current as App).PomToDoSheet.SelectedTask.TaskColor.Equals("Red"))
				rbHigh.IsChecked = true;
			else if ((Application.Current as App).PomToDoSheet.SelectedTask.TaskColor.Equals("Green"))
				rbLow.IsChecked = true;
			tbDescription.Text = (Application.Current as App).PomToDoSheet.SelectedTask.Description;
		}

		private ToDoTask GetFirstUnDoneTask()
		{
			foreach(ToDoTask todayToDo in (Application.Current as App).PomToDoSheet.ToDoTaskList)
			{
				if (!todayToDo.IsDone)
					return todayToDo;
			}
			foreach (ToDoTask unplannedToDo in (Application.Current as App).PomToDoSheet.UnplannedTaskList)
			{
				if (!unplannedToDo.IsDone)
					return unplannedToDo;
			}
			return null;
		}

		private async void AddTask_OKClick(object sender, RoutedEventArgs e)
		{
			bool isUnplanned = (bool)cbUnplanned.IsChecked;
			string taskColor = "";
			if (rbNormal.IsChecked == true)
				taskColor = "Brown";
			else if (rbHigh.IsChecked == true)
				taskColor = "Red";
			else if (rbLow.IsChecked == true)
				taskColor = "Green";
			string taskDescription = tbDescription.Text;
			int estimatedPoms = (int)rsPoms.Value;

			if (!isEdit)
			{
				ToDoTask newAddedTask = new ToDoTask() {Date=DateTime.Today, IsUnplanned = isUnplanned, TaskColor = taskColor, Description = taskDescription, 
				EstimatedPoms = estimatedPoms, PomsList = new ObservableCollection<string>(), PomsBytes = new byte[estimatedPoms]};
				for (int i = 0; i < estimatedPoms; i++)
				{
					newAddedTask.PomsList.Add("White");
				}

				if (GetFirstUnDoneTask() == null)
					newAddedTask.IsSelected = true;
				if (isUnplanned)
					(Application.Current as App).PomToDoSheet.AddUnplannedTask(newAddedTask);
				else
					(Application.Current as App).PomToDoSheet.AddToDoTask(newAddedTask);

				//insert the new task to DB.
				await App.Connection.InsertAsync(newAddedTask);
			}
			else
			{
				(Application.Current as App).PomToDoSheet.SelectedTask.Description = taskDescription;
				(Application.Current as App).PomToDoSheet.SelectedTask.TaskColor = taskColor;
				
				//Adjust the Unplanned task.
				if ((Application.Current as App).PomToDoSheet.SelectedTask.IsUnplanned && !isUnplanned)
				{
					(Application.Current as App).PomToDoSheet.AddToDoTask((Application.Current as App).PomToDoSheet.SelectedTask);
					(Application.Current as App).PomToDoSheet.RemoveUnplannedTask((Application.Current as App).PomToDoSheet.SelectedTask);
				}
				else if (!((Application.Current as App).PomToDoSheet.SelectedTask.IsUnplanned) && isUnplanned)
				{
					(Application.Current as App).PomToDoSheet.AddUnplannedTask((Application.Current as App).PomToDoSheet.SelectedTask);
					(Application.Current as App).PomToDoSheet.RemoveToDoTask((Application.Current as App).PomToDoSheet.SelectedTask);
				}
				(Application.Current as App).PomToDoSheet.SelectedTask.IsUnplanned = isUnplanned;

				//Adjust the estimated poms.
				if (estimatedPoms > (Application.Current as App).PomToDoSheet.SelectedTask.EstimatedPoms)
				{
					for (int i = 0; i < (rsPoms.Value - (Application.Current as App).PomToDoSheet.SelectedTask.EstimatedPoms); i++)
					{
						(Application.Current as App).PomToDoSheet.SelectedTask.PomsList.Add("White");
					}
				}
				else if (estimatedPoms < (Application.Current as App).PomToDoSheet.SelectedTask.EstimatedPoms)
				{
					for (int i = ((Application.Current as App).PomToDoSheet.SelectedTask.EstimatedPoms); i > rsPoms.Value; i--)
					{
						(Application.Current as App).PomToDoSheet.SelectedTask.PomsList.RemoveAt(i - 1);
					}
				}
				(Application.Current as App).PomToDoSheet.SelectedTask.EstimatedPoms = estimatedPoms;
			}

			//update the selected task in the DB.
			await App.Connection.UpdateAsync((Application.Current as App).PomToDoSheet.SelectedTask);

			gdAddTask.Visibility = Visibility.Collapsed;
		}

		private void AddTask_CancelClick(object sender, RoutedEventArgs e)
		{
			gdAddTask.Visibility = Visibility.Collapsed;
		}

		private void OnTextGotFocus(object sender, RoutedEventArgs e)
		{
			//barBottom.Visibility = Visibility.Collapsed;
		}

		private void OnItemClick(object sender, ItemClickEventArgs e)
		{
			//(e.ClickedItem as ToDoTask).IsSelected = true;
		}

		private async void OnSave_Click(object sender, RoutedEventArgs e)
		{
			//try
			//{
			//	await App.Connection.InsertAllAsync((Application.Current as App).PomToDoSheet.ToDoTaskList);
			//	await App.Connection.InsertAllAsync((Application.Current as App).PomToDoSheet.UnplannedTaskList);
			//}
			//catch (Exception)
			//{
			//	MessageDialog dialog = new MessageDialog("Insert ToDoTask Error, try again!");
			//	dialog.ShowAsync();
			//}
		}

		private async void OnClear_Click(object sender, RoutedEventArgs e)
		{
			(Application.Current as App).PomToDoSheet.ClearAllDoneTask();
			try
			{
				List<ToDoTask> todoList = await App.Connection.Table<ToDoTask>().ToListAsync();
				foreach (ToDoTask _task in todoList)
				{
					if(_task.IsDone)
						await App.Connection.DeleteAsync(_task);
				}
			}
			catch (Exception)
			{
				MessageDialog dialog = new MessageDialog("Delete TodDoTask in the DB error!");
				dialog.ShowAsync();
			}
		}
	}
}
