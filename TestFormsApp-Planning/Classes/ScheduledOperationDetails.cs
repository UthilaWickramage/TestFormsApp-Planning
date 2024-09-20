using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFormsApp_Planning.Classes
{
    public class ScheduledOperationDetails
    {
        public int ScheduledOperationDetailsId { get; set; }
        public double Qty { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public DateTime VisibleStartTime { get; set; }

        public DateTime VisibleEndTime { get; set; }

        public double DurationInHours { get; set; }

    
    }
}
