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
using Windows.UI.Popups;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace PomodoroKeeper.PomodoroViews
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class ToDoPage : PomodoroKeeper.Common.LayoutAwarePage
    {
        public ToDoPage()
        {
            this.InitializeComponent();
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

        private void onDoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(TimerPage));
        }

        private void onTapped(object sender, TappedRoutedEventArgs e)
        {
            //Frame rootFrame = Window.Current.Content as Frame;
           // rootFrame.Navigate(typeof(TimerPage));
        }

        private void onDrop(object sender, DragEventArgs e)
        {
            MessageDialog msgDlg = new MessageDialog("Drop");
            msgDlg.ShowAsync();
        }

        private void onDragLeave(object sender, DragEventArgs e)
        {
            MessageDialog msgDlg = new MessageDialog("DragLeave");
            msgDlg.ShowAsync();
        }

        private void onDragOver(object sender, DragEventArgs e)
        {
            MessageDialog msgDlg = new MessageDialog("DragOver");
            msgDlg.ShowAsync();
        }

        private void onDragEnter(object sender, DragEventArgs e)
        {
            MessageDialog msgDlg = new MessageDialog("DragEnter");
            msgDlg.ShowAsync();
        }

        //private void onRightTapped(object sender, RightTappedRoutedEventArgs e)
        //{
        //    MessageDialog msgDlg = new MessageDialog("RightTapped");
        //    msgDlg.ShowAsync();
        //}

        private void onHolding(object sender, HoldingRoutedEventArgs e)
        {
            MessageDialog msgDlg = new MessageDialog("Holding");
            msgDlg.ShowAsync();
        }

        private void OnItemClick(object sender, ItemClickEventArgs e)
        {
            (Application.Current as App).SelectedTask = lvToDo.SelectedItem as ToDoTask;// e.ClickedItem as ToDoTask;
        }
    }
}
