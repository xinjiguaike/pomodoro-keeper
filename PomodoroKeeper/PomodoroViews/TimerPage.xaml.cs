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
using Windows.UI.Popups;
using System.ComponentModel;
using NotificationsExtensions.ToastContent;
using Windows.UI.Notifications;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace PomodoroKeeper.PomodoroViews
{
	/// <summary>
	/// A basic page that provides characteristics common to most applications.
	/// </summary>
	public sealed partial class TimerPage : PomodoroKeeper.Common.LayoutAwarePage
	{
		private const int INDEX_MINUTE_FACTOR = 0;//The factor of transferring the index to minutes num.

		private static int nMinute;
		private static int nSecond;
		public static Timer pomTimer = new Timer() {};
		private static double lapsedSeconds = 0;

		public static ToDoTask CurrentTask = (Application.Current as App).PomToDoSheet.SelectedTask;
		private static DispatcherTimer dspTimer;
		//private static Uri uriTick = new Uri("ms-appx:///Sounds/ding.wav");
		//private MediaElement meTick = new MediaElement() { Source = uriTick};
		static TimerPage()
		{
			dspTimer = new DispatcherTimer();
			dspTimer.Interval = TimeSpan.FromSeconds(1);
			dspTimer.Tick += Dispatcher_OnTick;
			pomTimer.SetPomContent((Application.Current as App).ResLoader);
		}
		
		public TimerPage()
		{
			this.InitializeComponent();
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

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			tbHour.DataContext = pomTimer;
			tbMinute.DataContext = pomTimer;
			btnStartPom.DataContext = pomTimer;
			spPageTitle.DataContext = pomTimer;
			spWaitingPageTitle.DataContext = pomTimer;
			gdPomdoring.DataContext = pomTimer;
			gdWaiting.DataContext = pomTimer;
			pbarPomingProgressbar.DataContext = pomTimer;
			pbarBreakingProgressbar.DataContext = pomTimer;
			gdInterrupts.DataContext = pomTimer;

			tbInternal.DataContext = CurrentTask;
			tbExternal.DataContext = CurrentTask;
			tbTitle.DataContext = CurrentTask;
			
			//if (pomTimer.TimerStartContent == null)
			//	pomTimer.TimerStartContent = (Application.Current as App).ResLoader.GetString("START_POM");
			
			base.OnNavigatedTo(e);	
		}

		private async void StartPom_Click(object sender, RoutedEventArgs e)
		{
			
			if (pomTimer.PomStatus == Status.Running)
			{   
				//meTick.Stop();
				dspTimer.Stop();
				CurrentTask.TaskOpacity = 1;
				pomTimer.PomProgress = 0;
				pomTimer.IsWaiting = true;
				pomTimer.PomStatus = Status.Waitting;
				pomTimer.SetPomContent((Application.Current as App).ResLoader);

				CurrentTask.PomsList[CurrentTask.RunningPomIndex] = "Yellow";
				CurrentTask.PomsBytes[CurrentTask.RunningPomIndex] = 1;
				CurrentTask.RunningPomIndex += 1;
				//update the current task in the DB after task abandoned
				await App.Connection.UpdateAsync(CurrentTask);
			}
			else
			{
				if ((Application.Current as App).PomToDoSheet.SelectedTask == null)
				{
					MessageDialog msgDialog = new MessageDialog((Application.Current as App).ResLoader.GetString("NO_TASK_WARNING"));
					msgDialog.Commands.Add(new UICommand("OK", null));
					await msgDialog.ShowAsync();
					return;
				}
				nMinute = ((Application.Current as App).LocalPomSettings.PomIndex + 4) * INDEX_MINUTE_FACTOR;
				nSecond = 10;
				pomTimer.TimerMinute = nMinute.ToString();
				pomTimer.TimerSecond = "10";
				pomTimer.IsWaiting = false;
				pomTimer.IsBreaking = false;
				pomTimer.BreakProgress = 0;
				CurrentTask = (Application.Current as App).PomToDoSheet.SelectedTask;
				tbInternal.DataContext = CurrentTask;
				tbExternal.DataContext = CurrentTask;
				tbTitle.DataContext = CurrentTask;

				//Start Timing
				lapsedSeconds = 0;
				dspTimer.Start();

				pomTimer.PomStatus = Status.Running;
				pomTimer.SetPomContent((Application.Current as App).ResLoader);
			}
			
		}

		private async static void Dispatcher_OnTick(object sender, object e)
		{
			//meTick.Play();
			if(nMinute == 0 && nSecond == 0)
			{
				//meTick.Stop();
				pomTimer.PomStatus = Status.Waitting;
				pomTimer.SetPomContent((Application.Current as App).ResLoader);

				pomTimer.IsWaiting = true;
				pomTimer.PomProgress = 0;
				dspTimer.Stop();
				MessageDialog msgDialog = new MessageDialog("");
				if (pomTimer.IsBreaking)// Break Finished
				{
					pomTimer.BreakProgress = 0;
					pomTimer.IsBreaking = false;
					pomTimer.PomStatus = Status.Waitting;

					SendToast((Application.Current as App).ResLoader.GetString("BREAK_FINISH"));

					msgDialog.Content = (Application.Current as App).ResLoader.GetString("BREAK_FINISH");
					msgDialog.Commands.Add(new UICommand("OK", null));
					await msgDialog.ShowAsync();
				}
				else //Poming Finsihed
				{
					CurrentTask.TaskOpacity = 1;
					CurrentTask.PomsList[CurrentTask.RunningPomIndex] = "Red";
					CurrentTask.PomsBytes[CurrentTask.RunningPomIndex] = 2;
					CurrentTask.RunningPomIndex += 1;
					//update the current task in the DB after poming finished
					await App.Connection.UpdateAsync(CurrentTask);

					SendToast((Application.Current as App).ResLoader.GetString("TIME_TO_BREAK"));

					msgDialog.Content = (Application.Current as App).ResLoader.GetString("TIME_TO_BREAK");//"It's time to break!";
					msgDialog.DefaultCommandIndex = 0;
					msgDialog.CancelCommandIndex = 1;
					msgDialog.Commands.Add(new UICommand("OK", new UICommandInvokedHandler(OnUICommand)));
					msgDialog.Commands.Add(new UICommand("Cancel", new UICommandInvokedHandler(OnUICommand)));
					await msgDialog.ShowAsync();
				}
			}
			else
			{
				if (nSecond % 2 == 0)
				{
					CurrentTask.TaskOpacity = 0.5; 
				}
				else
				{
					CurrentTask.TaskOpacity = 1; 
				}

				if (nSecond == 0)
				{
					nSecond = 59;
					pomTimer.TimerSecond = nSecond.ToString();
						
					nMinute -= 1;
					if (nMinute < 10)
						pomTimer.TimerMinute = "0" + nMinute.ToString();
					else
						pomTimer.TimerMinute = nMinute.ToString();
				}
				else
				{
					nSecond -= 1;
					if (nSecond < 10)
						pomTimer.TimerSecond = "0" + nSecond.ToString();
					else
						pomTimer.TimerSecond = nSecond.ToString();
				}

				lapsedSeconds += 1;
				if (pomTimer.IsBreaking)
				{
					pomTimer.BreakProgress = (lapsedSeconds / (((Application.Current as App).LocalPomSettings.BreakIndex + 1) * INDEX_MINUTE_FACTOR)) * (100 / 60);
				}
				else
				{
					pomTimer.PomProgress = (lapsedSeconds / (((Application.Current as App).LocalPomSettings.PomIndex + 4) * INDEX_MINUTE_FACTOR)) * (100 / 60);
				}
				
			}
		}

		private static void OnUICommand(IUICommand cmd)
		{
			if (cmd.Label.Equals("OK"))
			{
				pomTimer.PomStatus = Status.Breaking;
				pomTimer.IsBreaking = true;
				nMinute = ((Application.Current as App).LocalPomSettings.BreakIndex + 1) * INDEX_MINUTE_FACTOR;
				nSecond = 0;
				pomTimer.IsWaiting = false;
				pomTimer.TimerMinute = nMinute.ToString();
				pomTimer.TimerSecond = "00";

				//Start Timing
				lapsedSeconds = 0;
				dspTimer.Start();
			}
		}

		private async void Internal_Click(object sender, RoutedEventArgs e)
		{
			CurrentTask.InternalInterrupts += 1;
			await App.Connection.UpdateAsync(CurrentTask);
		}

		private async void External_Click(object sender, RoutedEventArgs e)
		{
			CurrentTask.ExternalInterrupts += 1;
			await App.Connection.UpdateAsync(CurrentTask);
		}

		private static void SendToast(string toastText/*object sender, RoutedEventArgs e*/)
		{
			IToastNotificationContent toastContent = null;

			IToastText01 templateContent = ToastContentFactory.CreateToastText01();
			templateContent.Audio.Content = ToastAudioContent.IM;
			templateContent.Duration = ToastDuration.Short;
			templateContent.TextBodyWrap.Text = toastText; 

			toastContent = templateContent;

			ToastNotification toast = toastContent.CreateNotification();
			ToastNotificationManager.CreateToastNotifier().Show(toast);
		}
	}
}
