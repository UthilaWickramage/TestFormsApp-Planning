using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Machine
    {
        [Key]
        public int MachineId { get; set; }

        public string MachineName { get; set; }

        public string CapacityPerDay { get; set; }

        public virtual List<Task> Tasks { get; set; }

        public virtual List<Holiday> Holidays { get; set; }
    }
}
