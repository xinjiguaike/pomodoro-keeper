/***********************************************************************
 * Module:  Class3.cs
 * Author:  Rudy
 * Purpose: Definition of the Class Class3
 ***********************************************************************/

using System;

public class ActivityInventory
{
   public bool AddTask()
   {
      // TODO: implement
      return false;
   }
   
   public bool RemoveTask()
   {
      // TODO: implement
      return false;
   }

   public System.Collections.ArrayList inventroyTask;
   
   /// <pdGenerated>default getter</pdGenerated>
   public System.Collections.ArrayList GetInventroyTask()
   {
      if (inventroyTask == null)
         inventroyTask = new System.Collections.ArrayList();
      return inventroyTask;
   }
   
   /// <pdGenerated>default setter</pdGenerated>
   public void SetInventroyTask(System.Collections.ArrayList newInventroyTask)
   {
      RemoveAllInventroyTask();
      foreach (InventroyTask oInventroyTask in newInventroyTask)
         AddInventroyTask(oInventroyTask);
   }
   
   /// <pdGenerated>default Add</pdGenerated>
   public void AddInventroyTask(InventroyTask newInventroyTask)
   {
      if (newInventroyTask == null)
         return;
      if (this.inventroyTask == null)
         this.inventroyTask = new System.Collections.ArrayList();
      if (!this.inventroyTask.Contains(newInventroyTask))
         this.inventroyTask.Add(newInventroyTask);
   }
   
   /// <pdGenerated>default Remove</pdGenerated>
   public void RemoveInventroyTask(InventroyTask oldInventroyTask)
   {
      if (oldInventroyTask == null)
         return;
      if (this.inventroyTask != null)
         if (this.inventroyTask.Contains(oldInventroyTask))
            this.inventroyTask.Remove(oldInventroyTask);
   }
   
   /// <pdGenerated>default removeAll</pdGenerated>
   public void RemoveAllInventroyTask()
   {
      if (inventroyTask != null)
         inventroyTask.Clear();
   }

   private int nMaxCount = 100;

   private int nTaskCount
   {
      get
      ;
      set
      ;
   }
   
   private Array<InventoryTask> TaskList
   {
      get
      ;
      set
      ;
   }
   
   private string strTitle
   {
      get
      ;
      set
      ;
   }

}