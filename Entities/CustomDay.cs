using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CustomDay
    {
        public int CustomDay_Id { get; set; }

        public string Description { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

       public int WorkstationId { get; set; }
        public WorkStation WorkStation { get; set; }
    }
}
