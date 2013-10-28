/***********************************************************************
 * Module:  Timer.cs
 * Author:  Rudy
 * Purpose: Definition of the Class Timer
 ***********************************************************************/

using System;
using System.Collections.Generic;
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
    public class Timer: INotifyPropertyChanged
    {
        public ToDoTask CurrentTask;

        private DateTime TimeCounter { get; set; }

        private Enum Status { get; set; }

        private int PomodoringTime { get; set; }

        private int BreakingTime { get; set; }

        private string _strHour;
        private string _strMinute;
        private string _strStartContent;

        public string TimerHour
        {
            
            get { return _strHour;}
            set 
            {
                _strHour = value;
                OnPropertyChanged("TimerHour");
            }
        }
        public string TimerMinute
        {
            get { return _strMinute; }
            set
            {
                _strMinute = value;
                OnPropertyChanged("TimerMinute");
            }
        }

        public string TimerStartContent
        {
            get { return _strStartContent; }
            set
            {
                _strStartContent = value;
                OnPropertyChanged("TimerStartContent");
            }
        }

        private bool _bWaiting;
        public bool IsWaiting
        {

            get { return _bWaiting; }
            set
            {
                _bWaiting = value;
                OnPropertyChanged("IsWaiting");
            }
        }
   
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    } 
}