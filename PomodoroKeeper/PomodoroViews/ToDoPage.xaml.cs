using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using PomodoroKeeper.Model;
using System.Collections.ObjectModel;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace PomodoroKeeper.PomodoroViews
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class ToDoPage : PomodoroKeeper.Common.LayoutAwarePage
    {
        public static ToDoSheet PomToDoSheet;
        static ToDoPage()
        {
            PomToDoSheet = new ToDoSheet() { Date = DateTime.Today};
            PomToDoSheet.AddToDoTask(new ToDoTask(3) { Description = "Go To Market", TaskColor = "Red", InternalInterrupts = 5});
            PomToDoSheet.AddToDoTask(new ToDoTask(5) { Description = "Clean House", TaskColor = "Green"});
            PomToDoSheet.AddToDoTask(new ToDoTask(0) { Description = "Make a Plan"});
            PomToDoSheet.AddUnplannedTask(new ToDoTask(5) { Description = "Drink Coffee", TaskColor = "Blue"});

            PomToDoSheet.AddToDoTask(new ToDoTask(5) { Description = "Make a Plan 2"});
            PomToDoSheet.AddUnplannedTask(new ToDoTask(2) { Description = "Drink Coffee 2", TaskColor = "Yellow"});
            PomToDoSheet.AddToDoTask(new ToDoTask(3) { Description = "Make a Plan 3"});
            PomToDoSheet.AddUnplannedTask(new ToDoTask(4) { Description = "Drink Coffee 3", TaskColor = "Pink"});
            PomToDoSheet.AddToDoTask(new ToDoTask(5) { Description = "Make a Plan 4" });
            PomToDoSheet.AddUnplannedTask(new ToDoTask(3) { Description = "Drink Coffee 4", TaskColor = "Gray"});
        }

        public ToDoPage()
        {
            this.InitializeComponent();
            lvToDo.ItemsSource = PomToDoSheet.ToDoTaskList;
            lvUrgent.ItemsSource = PomToDoSheet.UnplannedTaskList;
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
    }
}
