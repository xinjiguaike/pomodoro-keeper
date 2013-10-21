/***********************************************************************
 * Module:  ActivityInventory.cs
 * Author:  Rudy
 * Purpose: Definition of the Class ActivityInventory
 ***********************************************************************/

using System;
using System.Collections.Generic;
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
    public class ActivityInventory
    {
        private const int MaxCount = 100;
      
        private int TaskCount
        {
            get
           ;
            set
           ;
        }

        private string Title
        {
            get
           ;
            set
           ;
        }

        public List<InventoryTask> InventoryTaskList;

        /// <pdGenerated>default getter</pdGenerated>
        public List<InventoryTask> GetInventroyTask()
        {
            if (InventoryTaskList == null)
                InventoryTaskList = new List<InventoryTask>();
            return InventoryTaskList;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetInventroyTask(List<InventoryTask> newInventoryTaskList)
        {
            RemoveAllInventroyTask();
            foreach (InventoryTask oInventoryTask in newInventoryTaskList)
                AddInventroyTask(oInventoryTask);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddInventroyTask(InventoryTask newInventoryTask)
        {
            if (newInventoryTask == null)
                return;
            if (this.InventoryTaskList == null)
                this.InventoryTaskList = new List<InventoryTask>();
            if (!this.InventoryTaskList.Contains(newInventoryTask))
                this.InventoryTaskList.Add(newInventoryTask);
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveInventroyTask(InventoryTask oldInventoryTask)
        {
            if (oldInventoryTask == null)
                return;
            if (this.InventoryTaskList != null)
                if (this.InventoryTaskList.Contains(oldInventoryTask))
                    this.InventoryTaskList.Remove(oldInventoryTask);
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllInventroyTask()
        {
            if (InventoryTaskList != null)
                InventoryTaskList.Clear();
        }           
    }
}
    