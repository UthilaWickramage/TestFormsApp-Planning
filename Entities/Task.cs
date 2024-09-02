using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartTime   { get; set; }
        public DateTime EndTime { get; set; }

        public string Capacity { get; set; }
        public double Duration { get; set; }
        public Machine Machine { get; set; }
        public int MachineId { get; set; }
    }
}
