using MindFusion.Scheduling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFormsApp_Planning.Classes
{
    public class OrderAllocation:Appointment
    {
        public int OrderAllocationId { get; set; }
        public string OrderTitle { get; set; }


       
    }
}
