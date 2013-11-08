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

        public bool IsUnplanned { get; set; }

        public int CompletedPomos { get; set; }

        public int AbandonedPoms { get; set; }

        public int RunningPomIndex { get; set; }

        private int _internalInterrupts;
        private int _externalInterrupts;
        private double _taskOpacity;
        private bool _bDone;
        private string _taskColor;
        private bool _bSelected;

        public bool IsSelected
        {
            get { return _bSelected; }
            set
            {
                _bSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }

        public string TaskColor
        {
            get { return _taskColor; }
            set
            {
                _taskColor = value;
                OnPropertyChanged("TaskColor");
            }
        }


        public bool IsDone
        {
            get { return _bDone; }
            set
            {
                _bDone = value;
                OnPropertyChanged("IsDone");
            }
        }

        public int InternalInterrupts
        {
            get { return _internalInterrupts; }
            set
            {
                _internalInterrupts = value;
                OnPropertyChanged("InternalInterrupts");
            }
        }
        public int ExternalInterrupts
        {
            get { return _externalInterrupts; }
            set
            {
                _externalInterrupts = value;
                OnPropertyChanged("ExternalInterrupts");
            }
        }
   
        public double TaskOpacity
        {
            get { return _taskOpacity; }
            set
            {
                _taskOpacity = value;
                OnPropertyChanged("TaskOpacity");
            }
        }
        
        public ObservableCollection<string> PomsList{ get; set; }

        public ToDoTask(int nEstimatedPoms)
        {
            EstimatedPoms = nEstimatedPoms;
            PomsList = new ObservableCollection<string>();
            for (int i = 0; i < EstimatedPoms; i++)
            {
                PomsList.Add("White");
            }
            TaskOpacity = 1;
        }
    } 
}