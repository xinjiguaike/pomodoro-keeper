/***********************************************************************
 * Module:  ToDoTask.cs
 * Author:  Rudy
 * Purpose: Definition of the Class ToDoTask
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
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace PomodoroKeeper.Model
{
    public class ToDoTask : InventoryTask, INotifyPropertyChanged
    {
        public int EstimatedPoms { get; set; }

        public string TaskColor { get; set; }

        public bool IsDone { get; set; }

        public bool IsSelected { get; set; }

        public bool IsUnplanned { get; set; }

        public int CompletedPomos { get; set; }

        public int AbandonedPoms { get; set; }

        private int _internalInterrupts;
        public int InternalInterrupts
        {
            get { return _internalInterrupts; }
            set
            {
                _internalInterrupts = value;
                OnPropertyChanged("InternalInterrupts");
            }
        }

        private int _externalInterrupts;
        public int ExternalInterrupts
        {
            get { return _externalInterrupts; }
            set
            {
                _externalInterrupts = value;
                OnPropertyChanged("ExternalInterrupts");
            }
        }

        private double _taskOpacity;
        public double TaskOpacity
        {
            get { return _taskOpacity; }
            set
            {
                _taskOpacity = value;
                OnPropertyChanged("TaskOpacity");
            }
        }

        public int Progress { get; set; }

        public ObservableCollection<string> PomsList{ get; set; }

        public ToDoTask(int nEstimatedPoms)
        {
            EstimatedPoms = nEstimatedPoms;
            PomsList = new ObservableCollection<string>();
            for (int i = 0; i < EstimatedPoms; i++)
            {
                PomsList.Add("Green");
            }
            TaskOpacity = 1;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    } 
}