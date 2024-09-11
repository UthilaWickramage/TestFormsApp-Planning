using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFormsApp_Planning.Classes
{
    public class ScheduledOrder
    {
        public int OrderId { get; set; }
        public string Title { get; set; }
        public string Customer { get; set; }

        public double Qty { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public DateTime DeliveryDate { get; set; }

        public double DurationInHours { get; set; }

        public string ProductName { get; set; }

        public Product Product { get; set; }


        public string WorkstationName { get; set; }

        public WorkStation WorkStation { get; set; }

    }
}
