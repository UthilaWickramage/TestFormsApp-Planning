using MindFusion.Scheduling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFormsApp_Planning.Classes
{
    public class TaskAllocation:Appointment
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }


       
    }
}
