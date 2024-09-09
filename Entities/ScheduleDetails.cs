using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ScheduleDetails
    {
        public int ScheduleDetailsId { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public DateTime VisibleStartTime { get; set; }

        public DateTime VisibleEndTime { get; set; }

        public double DurationInHours { get; set; }
        public int WorkStationId {  get; set; }

        public WorkStation WorkStation { get; set; }




    }
}
