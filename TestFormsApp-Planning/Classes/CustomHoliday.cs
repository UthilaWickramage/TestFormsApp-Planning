using MindFusion.HolidayProviders;
using MindFusion.Scheduling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFormsApp_Planning.Classes
{
    public class CustomHoliday:Appointment
    {
        public int HolidayId { get; set; }
        public string HolidayName { get; set; }
        public DateTime HolidayDateTime { get; set; }
        public string ContactName { get; set; }

    }
}
