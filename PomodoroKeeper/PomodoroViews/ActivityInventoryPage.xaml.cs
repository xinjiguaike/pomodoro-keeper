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
using PomodoroKeeper.Model;
using Controls.Toolkit;
// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace PomodoroKeeper.PomodoroViews
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class ActivityInventoryPage : PomodoroKeeper.Common.LayoutAwarePage
    {
        public static ObservableCollection<InventoryTask> InventoryList;

        static ActivityInventoryPage()
        {
            InventoryList = new ObservableCollection<InventoryTask>();
            InventoryList.Add(new InventoryTask() { Description = "Go Shopping" });
            InventoryList.Add(new InventoryTask() { Description = "Play Billiards" });
            InventoryList.Add(new InventoryTask() { Description = "Watch the football game" });
        }

        public ActivityInventoryPage()
        {
            this.InitializeComponent();
            lvInventory.ItemsSource = InventoryList;
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
		
		private void GoToToday(object sender, RoutedEventArgs e)
		{
            ObservableCollection<InventoryTask> listSeclected = new ObservableCollection<InventoryTask>();
            foreach (InventoryTask selectedTask in lvInventory.SelectedItems)
            {
                listSeclected.Add(selectedTask);
            }

            foreach (InventoryTask inventoryTask in listSeclected)
            {
                ToDoTask newToDoTask = new ToDoTask(3) {Description = inventoryTask.Description, Priority = inventoryTask.Priority };
                (Application.Current as App).PomToDoSheet.AddToDoTask(newToDoTask);
                InventoryList.Remove(inventoryTask);
            }
            
            App.NavigateToPage(typeof(ToDoPage));
		}

        private void NewTask_Click(object sender, RoutedEventArgs e)
        {
            ctbNewTask.IsOpen = true;
        }

        private void OnNewTask_OkButtonClick(object sender, RoutedEventArgs e)
        {
            InventoryList.Add(new InventoryTask() { Description = ctbNewTask.Text });
            ctbNewTask.Text = null;
            
        }
    }
}
