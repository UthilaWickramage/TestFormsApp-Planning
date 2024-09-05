using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFormsApp_Planning.Classes
{
    public class SchedulerItemState
    {
        public int OrderAllocationId { get; set; }
        public string OrderTitle { get; set; }
        public string OrderDescription { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public DateTime VisibleStartTime { get; set; }

        public DateTime VisibleEndTime { get; set; }

        public string Customer { get; set; }

        public string WorkStationName { get; set; }
        public int WorkstationId { get; set; }
        public string Qty { get; set; }
        public double DurationInHours { get; set; }

        public DateTime deliveryDate { get; set; }

        public SchedulerItemState(OrderAllocation item)
        {
            OrderAllocationId = item.OrderAllocationId;
            OrderTitle = item.OrderTitle;
            OrderDescription = item.OrderDescription;
            StartTime = item.StartTime;
            EndTime = item.EndTime;
            VisibleStartTime = item.VisibleStartTime;
            VisibleEndTime = item.VisibleEndTime;
            Customer = item.Customer;
            WorkstationId = item.WorkstationId;
            Qty = item.Qty;
            DurationInHours = item.DurationInHours;
            deliveryDate = item.deliveryDate;
            WorkStationName = item.WorkStationName;

        }

    }
}
