using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFormsApp_Planning.Classes;

namespace TestFormsApp_Planning.Helpers
{
    public class ScheduleUtil
    {
        private List<Entities.Holiday> _holidays;

        public ScheduleUtil(List<Entities.Holiday> holidays)
        {
            _holidays = holidays;
        }
        public DateTime MapToVisibleRange(DateTime dateTime, TimeSpan visibleStart, TimeSpan visibleEnd)
        {
            TimeSpan originalTime = dateTime.TimeOfDay;
            TimeSpan dayStart = TimeSpan.FromHours(0); // Start of 24-hour day
            TimeSpan dayEnd = TimeSpan.FromHours(24);  // End of 24-hour day

            // Calculate proportion in the 24-hour range
            double proportion = (originalTime.TotalMinutes - dayStart.TotalMinutes) / (dayEnd.TotalMinutes - dayStart.TotalMinutes);

            // Map proportion to the visible time range
            TimeSpan visibleDuration = visibleEnd - visibleStart;
            TimeSpan visibleTime = visibleStart + TimeSpan.FromMinutes(proportion * visibleDuration.TotalMinutes);

            return dateTime.Date + visibleTime; // Preserve the date part
        }

        public DateTime CalculateEndDateConsideringHolidays(DateTime startTime, DateTime endTime, double duration)
        {
            DateTime adjustedEndTime = endTime;
            DateTime currentDate = startTime;
            int daysAdded = 0;

            while (daysAdded < duration)
            {
                // Check if the current endTime is a weekend or holiday
                if (IsWeekend(currentDate) || IsHoliday(currentDate))
                {
                    // If it's a weekend or holiday, just move to the next day
                    adjustedEndTime = adjustedEndTime.AddDays(1);
                }
                else
                {
                    // Count only valid working days
                    daysAdded++;
                }

                // Move to the next day
                currentDate = currentDate.AddDays(1);
            }

            return adjustedEndTime;
        }

        public bool IsWeekend(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }

        public bool IsHoliday(DateTime date)
        {
            return _holidays.Any(holiday => holiday.HolidayDate.Date == date.Date);
        }
        public bool isHoliday(DateTime tstartDate, OrderAllocation tsk)
        {
            if (tstartDate.DayOfWeek == DayOfWeek.Saturday || tstartDate.DayOfWeek == DayOfWeek.Sunday)
            {
                return true;
            }
            else
            {
                if (_holidays.Where(a => a.HolidayDate.Date == tstartDate.Date).FirstOrDefault() != null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
