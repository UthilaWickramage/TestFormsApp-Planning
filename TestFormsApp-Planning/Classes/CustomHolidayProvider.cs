using MindFusion.HolidayProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFormsApp_Planning.Classes
{
    public class CustomHolidayProvider:HolidayProvider
    {
        private List<Holiday> Holidays;

        public CustomHolidayProvider()
        {
            Holidays = new List<Holiday>();
        }
        public void Add(Holiday holiday)
        {
            Holidays.Add(holiday);
        }

        public List<Holiday> GetHolidays()
        {
            return Holidays;
        }

        public override Holiday[] GetHolidays(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        public override Holiday[] GetHolidays(int year)
        {
            throw new NotImplementedException();
        }
    }
}
