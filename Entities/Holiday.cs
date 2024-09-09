using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Holiday
    {
        [Key]
        public int HolidayId { get; set; }

        public string HolidayName { get; set; } 

        public DateTime HolidayDate { get; set; }

    }

}
