﻿using System;
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

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace PomodoroKeeper.PomodoroViews
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class TimerPage : PomodoroKeeper.Common.LayoutAwarePage
    {
        private static Timer pomTimer = new Timer() { TimerHour="25", TimerMinute="00"}; 
        private static int nHour = 25;
        private static int nMinute = 0;
        private static DispatcherTimer dspTimer;
        //private static Uri uriTick = new Uri("ms-appx:///Sounds/ding.wav");
        //private MediaElement meTick = new MediaElement() { Source = uriTick};
        static TimerPage()
        {
            dspTimer = new DispatcherTimer();
            dspTimer.Interval = TimeSpan.FromSeconds(1);
            dspTimer.Tick += new EventHandler<object>(Dispatcher_OnTick);
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

            if (pomTimer.TimerStartContent == null)
                pomTimer.TimerStartContent = "Start Pomodoro";
            
            base.OnNavigatedTo(e);    
        }

        private void StartPom_Click(object sender, RoutedEventArgs e)
        {

            if (pomTimer.TimerStartContent.Equals("Start Pomodoro"))
            {
                dspTimer.Start();
                pomTimer.TimerStartContent = "Abandon Pomodoro";
            }
            else if (pomTimer.TimerStartContent.Equals("Abandon Pomodoro"))
            {
                //meTick.Stop();
                dspTimer.Stop();
                pomTimer.TimerStartContent = "Start Pomodoro";
                nHour = 25;
                nMinute = 0;
                pomTimer.TimerHour = "25";
                pomTimer.TimerMinute = "00";
            }
            
        }

        private static void Dispatcher_OnTick(object sender, object e)
        {
            //meTick.Play();
            if(nHour == 0 && nMinute == 0)
            {
                //meTick.Stop();
                pomTimer.TimerStartContent = "Start Pomodoro";
                dspTimer.Stop();
                MessageDialog msgDialog = new MessageDialog("It's time to break!");
                msgDialog.ShowAsync();
            }
            else
            {
                if (nMinute == 0)
                {
                    nMinute = 59;
                    pomTimer.TimerMinute = nMinute.ToString();
                        
                    nHour -= 1;
                    if (nHour < 10)
                        pomTimer.TimerHour = "0" + nHour.ToString();
                    else
                        pomTimer.TimerHour = nHour.ToString();
                }
                else
                {
                    nMinute -= 1;
                    if (nMinute < 10)
                        pomTimer.TimerMinute = "0" + nMinute.ToString();
                    else
                        pomTimer.TimerMinute = nMinute.ToString();
                }
            }
        }

        private void Internal_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void External_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
