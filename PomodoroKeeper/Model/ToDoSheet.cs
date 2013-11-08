/***********************************************************************
 * Module:  Class5.cs
 * Author:  Rudy
 * Purpose: Definition of the Class Class5
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace PomodoroKeeper.Model
{
    public class ToDoSheet: INotifyPropertyChanged
    {
        public ObservableCollection<ToDoTask> ToDoTaskList;
        public ObservableCollection<ToDoTask> UnplannedTaskList;
        private ToDoTask _selectedTask;
        public ToDoTask SelectedTask
        {
            get { return _selectedTask;}
            set
            {
                _selectedTask = value;
                OnPropertyChanged("SelectedTask");
            }
        }

        //========= ToDoTask List==========
        #region
        /// <pdGenerated>default getter</pdGenerated>
        public ObservableCollection<ToDoTask> GetToDoTask()
        {
            if (ToDoTaskList == null)
                ToDoTaskList = new ObservableCollection<ToDoTask>();
            return ToDoTaskList;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetToDoTask(ObservableCollection<ToDoTask> newToDoTaskList)
        {
            RemoveAllToDoTask();
            foreach (ToDoTask oToDoTask in newToDoTaskList)
                AddToDoTask(oToDoTask);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddToDoTask(ToDoTask newToDoTask)
        {
            if (newToDoTask == null)
                return;
            if (this.ToDoTaskList == null)
                this.ToDoTaskList = new ObservableCollection<ToDoTask>();
            if (!this.ToDoTaskList.Contains(newToDoTask))
                this.ToDoTaskList.Add(newToDoTask);
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveToDoTask(ToDoTask oldToDoTask)
        {
            if (oldToDoTask == null)
                return;
            if (this.ToDoTaskList != null)
                if (this.ToDoTaskList.Contains(oldToDoTask))
                    this.ToDoTaskList.Remove(oldToDoTask);
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllToDoTask()
        {
            if (ToDoTaskList != null)
                ToDoTaskList.Clear();
        }
        #endregion


        //========= UnplannedTask List==========
        #region
        /// <pdGenerated>default getter</pdGenerated>
        public ObservableCollection<ToDoTask> GetUnplannedTask()
        {
            if (UnplannedTaskList == null)
                UnplannedTaskList = new ObservableCollection<ToDoTask>();
            return UnplannedTaskList;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetUnplannedTask(ObservableCollection<ToDoTask> newUnplannedTaskList)
        {
            RemoveAllUnplannedTask();
            foreach (ToDoTask oUnplannedTask in newUnplannedTaskList)
                AddToDoTask(oUnplannedTask);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddUnplannedTask(ToDoTask newUnplannedTask)
        {
            if (newUnplannedTask == null)
                return;
            if (this.UnplannedTaskList == null)
                this.UnplannedTaskList = new ObservableCollection<ToDoTask>();
            if (!this.UnplannedTaskList.Contains(newUnplannedTask))
                this.UnplannedTaskList.Add(newUnplannedTask);
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveUnplannedTask(ToDoTask oldUnplannedTask)
        {
            if (oldUnplannedTask == null)
                return;
            if (this.UnplannedTaskList != null)
                if (this.UnplannedTaskList.Contains(oldUnplannedTask))
                    this.UnplannedTaskList.Remove(oldUnplannedTask);
        }
        
        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllUnplannedTask()
        {
            if (UnplannedTaskList != null)
                UnplannedTaskList.Clear();
        }
        #endregion

        public DateTime Date { get; set; }

        private int NumDoneTasks { get; set; }

        private int NumToDoTasks { get; set; }

        private int CompletedPoms { get; set; }

        public ToDoSheet()
        {
            ToDoTaskList = new ObservableCollection<ToDoTask>();
            UnplannedTaskList = new ObservableCollection<ToDoTask>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    } 
}