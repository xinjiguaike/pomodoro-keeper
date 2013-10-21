/***********************************************************************
 * Module:  ToDoTask.cs
 * Author:  Rudy
 * Purpose: Definition of the Class ToDoTask
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class ToDoTask : InventoryTask
    {
        

        public int EstimatedPoms
        {
            get
           ;
            set
           ;
        }

        public string TaskColor
        {
            get
           ;
            set
           ;
        }

        public bool IsDone
        {
            get
           ;
            set
           ;
        }

        public bool IsUnplanned
        {
            get
           ;
            set
           ;
        }

        public int CompletedPomos
        {
            get
           ;
            set
           ;
        }

        public int AbandonedPoms
        {
            get
           ;
            set
           ;
        }

        public int InternalInterrupts
        {
            get
           ;
            set
           ;
        }

        public int ExternalInterruputs
        {
            get
           ;
            set
           ;
        }

        public int Progress
        {
            get
           ;
            set
           ;
        }

        public ObservableCollection<string> PomsList;

        //public void InitializPomsList()
        //{ 
        //   PomsList = new ObservableCollection<string>();
        //   for (int i = 0; i < EstimatedPoms; i++)
        //   {
        //       PomsList.Add("Green");
        //   }
               
        //}

        public ToDoTask(int nEstimatedPoms)
        {
            EstimatedPoms = nEstimatedPoms;
            PomsList = new ObservableCollection<string>();
            for (int i = 0; i < EstimatedPoms; i++)
            {
                PomsList.Add("Green");
            }
        }
    } 
}