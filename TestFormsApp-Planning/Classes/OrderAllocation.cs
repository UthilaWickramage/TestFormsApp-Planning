﻿using MindFusion.Scheduling;
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
        public string OrderDescription { get; set; }
      
        public DateTime VisibleStartTime { get; set; }

        public DateTime VisibleEndTime { get; set; }

        public string Customer {  get; set; }

        public string WorkStationName { get; set; }
        public int WorkstationId { get; set; }
        public string Qty { get; set; }
        public double DurationInHours { get; set; }

        public DateTime deliveryDate { get; set; }
    }
}
