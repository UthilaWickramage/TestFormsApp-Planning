using Entities;
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
       public Contact Contact { get; set; }
        public DateTime VisibleStartTime { get; set; }

        public DateTime VisibleEndTime { get; set; }

        public string Customer {  get; set; }

        public Operation_Type Operation_Type { get; set; }

        public WorkStation WorkStation { get; set; }

        public string ProductName { get; set; }
        public Order Order { get; set; }
        public string Qty { get; set; }
        public double DurationInHours { get; set; }

        public DateTime deliveryDate { get; set; }
    }
}
