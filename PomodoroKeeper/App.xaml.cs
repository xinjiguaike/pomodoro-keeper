﻿using System;
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
using System.ComponentModel;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=234227

namespace PomodoroKeeper
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application//, INotifyPropertyChanged
    {
        /// Global Data for all pages to share.
        public ToDoSheet PomToDoSheet;
        public ToDoTask SelectedTask;
        //private double _currentTask2;
        //public double CurrentTask2
        //{
        //    get { return _currentTask2; }
        //    set
        //    {
        //        _currentTask2 = value;
        //        OnPropertyChanged("CurrentTask2");
        //    }
        //}

        //public event PropertyChangedEventHandler PropertyChanged;
        //public void OnPropertyChanged(string propertyName)
        //{
        //    if (PropertyChanged != null)
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //}

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            // Initializes the global data.
            PomToDoSheet = new ToDoSheet() { Date = DateTime.Today };
            PomToDoSheet.AddToDoTask(new ToDoTask(3) { Description = "Go To Market", TaskColor = "Red" });
            PomToDoSheet.AddToDoTask(new ToDoTask(5) { Description = "Clean House", TaskColor = "Green" });
            PomToDoSheet.AddToDoTask(new ToDoTask(2) { Description = "Make a Plan" });
            PomToDoSheet.AddUnplannedTask(new ToDoTask(4) { Description = "Drink Coffee", TaskColor = "Blue" });

            PomToDoSheet.AddUnplannedTask(new ToDoTask(2) { Description = "Play Basketball", TaskColor = "Yellow" });
            PomToDoSheet.AddToDoTask(new ToDoTask(1) { Description = "Probation Plan Review" });
            PomToDoSheet.AddUnplannedTask(new ToDoTask(4) { Description = "Have a look", TaskColor = "Pink" });
            PomToDoSheet.AddToDoTask(new ToDoTask(5) { Description = "Apply for the citizen card" });
            PomToDoSheet.AddUnplannedTask(new ToDoTask(3) { Description = "Go to sleep", TaskColor = "Gray" });

            //CurrentTask = new ToDoTask(0);

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
        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
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
            deferral.Complete();
        }
    }
}
