using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;

namespace CreateResources
{
    class Program
    {
        static void Main(string[] args)
        {
            ResourceWriter rw = new ResourceWriter("pomRes_en.resources");

            rw.AddResource("NO_TASK_WARNING", "You should add at least one task before starting!");
            rw.AddResource("BREAK_FINISH", "Break finished!");
            rw.AddResource("TIME_TO_BREAK", "It's time to have a break!");
            rw.AddResource("START_POM", "Start Pomodoro");
            rw.AddResource("ABANDON_POM", "Abandon Pomodoro");

            rw.Generate();
            rw.Close();
        }
    }
}
