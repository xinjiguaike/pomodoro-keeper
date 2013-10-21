/***********************************************************************
 * Module:  Class5.cs
 * Author:  Rudy
 * Purpose: Definition of the Class Class5
 ***********************************************************************/

using System;

public class ToDoSheet
{
   public Array<ToDoTask> get_ToDoList()
   ;
   
   public void set_ToDoList(Array<ToDoTask> value)
   ;

   public System.Collections.ArrayList toDoTask;
   
   /// <pdGenerated>default getter</pdGenerated>
   public System.Collections.ArrayList GetToDoTask()
   {
      if (toDoTask == null)
         toDoTask = new System.Collections.ArrayList();
      return toDoTask;
   }
   
   /// <pdGenerated>default setter</pdGenerated>
   public void SetToDoTask(System.Collections.ArrayList newToDoTask)
   {
      RemoveAllToDoTask();
      foreach (ToDoTask oToDoTask in newToDoTask)
         AddToDoTask(oToDoTask);
   }
   
   /// <pdGenerated>default Add</pdGenerated>
   public void AddToDoTask(ToDoTask newToDoTask)
   {
      if (newToDoTask == null)
         return;
      if (this.toDoTask == null)
         this.toDoTask = new System.Collections.ArrayList();
      if (!this.toDoTask.Contains(newToDoTask))
         this.toDoTask.Add(newToDoTask);
   }
   
   /// <pdGenerated>default Remove</pdGenerated>
   public void RemoveToDoTask(ToDoTask oldToDoTask)
   {
      if (oldToDoTask == null)
         return;
      if (this.toDoTask != null)
         if (this.toDoTask.Contains(oldToDoTask))
            this.toDoTask.Remove(oldToDoTask);
   }
   
   /// <pdGenerated>default removeAll</pdGenerated>
   public void RemoveAllToDoTask()
   {
      if (toDoTask != null)
         toDoTask.Clear();
   }

   private DateTime Date
   {
      get
      ;
      set
      ;
   }
   
   private int nDoneTasks
   {
      get
      ;
      set
      ;
   }
   
   private int nToDoTasks
   {
      get
      ;
      set
      ;
   }
   
   private int nCompletedPoms
   {
      get
      ;
      set
      ;
   }

}