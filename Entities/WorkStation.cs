using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class WorkStation
    {
        [Key]
        public int WorkStationId { get; set; }

        public string WorkStationName { get; set; }

        public string CapacityPerHour { get; set; }

        public virtual List<Order> Orders { get; set; }

        public virtual List<Holiday> Holidays { get; set; }

        public virtual List<SpecialDay> SpecialDays { get; set; }
    }
}
