using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public string OrderTitle { get; set; }
        public string OrderDescription { get; set; }
        public DateTime StartTime   { get; set; }
        public DateTime EndTime { get; set; }

        public DateTime VisibleStartTime { get; set; }

        public DateTime VisibleEndTime { get; set; }

        public string Qty { get; set; }
        public double DurationInHours { get; set; }
        public WorkStation Machine { get; set; }
        public int MachineId { get; set; }
    }
}
