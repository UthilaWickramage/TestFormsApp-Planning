using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class SpecialDay
    {
        public int SpecialDayId { get; set; }

        public string SpecialDayDescription { get; set; }


        public DateTime SpecialDayStartTime { get; set; }
        public DateTime SpecialDayEndTime { get; set; }

        public int SpecialDayCapacityPerHour { get; set; }

        public WorkStation WorkStation { get; set; }
    }
}
