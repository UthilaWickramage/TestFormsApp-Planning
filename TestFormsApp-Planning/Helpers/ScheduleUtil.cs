using Entities;
using MindFusion.Scheduling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        public DateTime MapToVisibleRange(List<CustomDay> CustomDays, DateTime dateTime, Contact contact)
        {
            TimeSpan originalTime = dateTime.TimeOfDay;
            TimeSpan visibleStartDefault = TimeSpan.FromHours(8); // 8 AM visible start
            TimeSpan visibleEndDefault = TimeSpan.FromHours(16);
            TimeSpan dayStart = TimeSpan.FromHours(0); // Start of 24-hour day
            TimeSpan dayEnd = TimeSpan.FromHours(24);  // End of 24-hour day


            // Calculate proportion in the 24-hour range
            double proportion = (originalTime.TotalMinutes - dayStart.TotalMinutes) / (dayEnd.TotalMinutes - dayStart.TotalMinutes);

            //DateTime CustomStartTime = DateTime.MinValue;
            //DateTime CustomEndTime = DateTime.MinValue;
            //foreach (CustomDay d in CustomDays) {
            //    if (d.StartTime.Date == dateTime)
            //    {
            //        CustomStartTime = d.StartTime;
            //        CustomEndTime = d.EndTime;
            //        break;
            //    }
            //}
            TimeSpan visibleDuration = TimeSpan.MinValue;
            TimeSpan visibleTime = TimeSpan.MinValue;
            var customDay = CustomDays.FirstOrDefault(day => day.StartTime.Date == dateTime.Date && contact.Name == day.WorkStation.WorkStationName);
            if (customDay != null)
            {
                visibleDuration = TimeSpan.FromHours(customDay.EndTime.Hour) - TimeSpan.FromHours(customDay.StartTime.Hour);
                visibleTime = customDay.StartTime.TimeOfDay + TimeSpan.FromMinutes(proportion * visibleDuration.TotalMinutes);

            }
            else
            {
                visibleDuration = visibleEndDefault - visibleStartDefault;
                visibleTime = visibleStartDefault + TimeSpan.FromMinutes(proportion * visibleDuration.TotalMinutes);

            }
            //TimeSpan visibleDuration = TimeSpan.MinValue;
            //TimeSpan visibleTime = TimeSpan.MinValue;

            //if (CustomStartTime != DateTime.MinValue && CustomEndTime != DateTime.MinValue)
            //{
            //    visibleDuration = TimeSpan.FromHours(CustomEndTime.Hour)-TimeSpan.FromHours(CustomStartTime.Hour);
            //    visibleTime = CustomStartTime.TimeOfDay + TimeSpan.FromMinutes(proportion * visibleDuration.TotalMinutes);

            //}
            //else
            //{
            //     visibleDuration = visibleEndDefault - visibleStartDefault;
            //     visibleTime = visibleStartDefault + TimeSpan.FromMinutes(proportion * visibleDuration.TotalMinutes);

            //}
            // Map proportion to the visible time range

            return dateTime.Date + visibleTime; // Preserve the date part
        }

        public double CalculateDays(DateTime StartDateTime, double durationInMinutes, Contact contact, List<CustomDay> customDays)
        {
            TimeSpan visibleStartDefault = TimeSpan.FromHours(8); // 8 AM visible start
            TimeSpan visibleEndDefault = TimeSpan.FromHours(16);
            double defaultMinutes = visibleEndDefault.TotalHours-visibleStartDefault.TotalHours;
            double minutesLeft = durationInMinutes;
            DateTime currentDate = StartDateTime;
            double days = 0;

            while (minutesLeft > 0) // Keep looping until all minutes are consumed
            {
                if (IsHoliday(currentDate) || IsWeekend(currentDate))
                {
                    currentDate = currentDate.AddDays(1);
                    continue;
                }
                // Check if there's a custom working day for the current date
                CustomDay customDay = customDays.FirstOrDefault(d => d.StartTime.Date == currentDate.Date && d.WorkStation.WorkStationName == contact.Name);

                if (customDay != null)
                {
                    // Custom working hours for this day
                    double customDayMinutes = customDay.EndTime.TimeOfDay.TotalHours - customDay.StartTime.TimeOfDay.TotalHours;

                    if (minutesLeft <= customDayMinutes)
                    {
                        // If the remaining time fits within the custom working hours of the current day
                        days += minutesLeft / customDayMinutes;
                        minutesLeft = 0;
                    }
                    else
                    {
                        // Otherwise, use up the entire custom day
                        days++;
                        minutesLeft -= customDayMinutes;
                    }
                }
                else
                {
                    // No custom day, use default working hours (8 AM to 4 PM)
                    if (minutesLeft <= defaultMinutes)
                    {
                        // If remaining time fits within default working hours
                        days += minutesLeft / defaultMinutes;
                        minutesLeft = 0;
                    }
                    else
                    {
                        // Use up a full default day
                        days++;
                        minutesLeft -= defaultMinutes;
                    }
                }

                // Move to the next day
                currentDate = currentDate.AddDays(1);
            }

            return days;

            //foreach (CustomDay d in customDays)
            //{
            //    if (StartDateTime.Date == d.StartTime.Date)
            //    {
            //       double diff =  d.EndTime.TimeOfDay.TotalMinutes-d.StartTime.TimeOfDay.TotalMinutes;
            //        if(minutesLeft <= diff)
            //        {
            //           days+= minutesLeft / diff;
            //            break;
            //        }
            //        else
            //        {
            //            days++;
            //            minutesLeft -= diff;
            //        }
            //    }
            //    else
            //    {
            //        days++;
            //        minutesLeft -= defaultMinutes;
            //    }
            //    StartDateTime = StartDateTime.AddDays(1);
            //}
            //return days;

        }
        public DateTime CalculateEndDateConsideringHolidays(DateTime startTime, decimal duration)
        {


            //DateTime adjustedEndTime = startTime;
            //decimal hoursAdded = 0;


            //while (hoursAdded < duration)
            //{

            //    if (IsWeekend(adjustedEndTime) || IsHoliday(adjustedEndTime))
            //    {
            //        adjustedEndTime = adjustedEndTime.AddDays(1);

            //    }
            //    else
            //    {
            //        CustomDay customDay = customDays.FirstOrDefault(day => day.StartTime.Date == adjustedEndTime.Date&& day.WorkStation.WorkStationName==contact.Name);
            //        if (customDay != null)
            //        {
            //            int diff = customDay.EndTime.Hour - customDay.StartTime.Hour;
            //            hoursAdded += diff;
            //        }
            //        else
            //        {
            //            hoursAdded += 8;
            //        }
            //        //customDays.ForEach(day =>
            //        //{
            //        //    if (day.StartTime.Date == adjustedEndTime.Date)
            //        //    {

            //        //    }
            //        //    else
            //        //    {

            //        //    }
            //        //});
            //    }
            //}
            //MessageBox.Show("Hours Added : "+hoursAdded.ToString());
            //return adjustedEndTime.AddHours(double.Parse(hoursAdded.ToString()));

            //DateTime adjustedEndTime = startTime;
            //decimal hoursAdded = 0;

            //while (hoursAdded < duration)
            //{
            //    // Skip weekends and holidays
            //    if (IsWeekend(adjustedEndTime) || IsHoliday(adjustedEndTime))
            //    {
            //        adjustedEndTime = adjustedEndTime.AddDays(1);
            //        continue;
            //    }

            //    // Check if there is a custom working day
            //    CustomDay customDay = customDays.FirstOrDefault(day => day.StartTime.Date == adjustedEndTime.Date&& day.WorkStation.WorkStationName==contact.Name);
            //    if (customDay != null)
            //    {
            //        int availableHours = customDay.EndTime.Hour - customDay.StartTime.Hour;
            //        hoursAdded += availableHours;

            //    }
            //    else
            //    {
            //        // Default to 8 working hours
            //        hoursAdded += 8;
            //        adjustedEndTime = adjustedEndTime.AddDays(1);
            //    }

            //    // Move to the next day if needed
            //    if (hoursAdded < duration)
            //    {
            //        adjustedEndTime = adjustedEndTime.AddDays(1);
            //    }
            //}
            //MessageBox.Show("Hours Added : "+hoursAdded.ToString());
            //// Add the remaining hours to the adjustedEndTime
            //return adjustedEndTime.AddHours(double.Parse(hoursAdded.ToString()));

            DateTime adjustedEndTime = startTime.AddDays(double.Parse(duration.ToString()));
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
        //public bool isHoliday(DateTime tstartDate, OrderAllocation tsk)
        //{
        //    if (tstartDate.DayOfWeek == DayOfWeek.Saturday || tstartDate.DayOfWeek == DayOfWeek.Sunday)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        if (_holidays.Where(a => a.HolidayDate.Date == tstartDate.Date).FirstOrDefault() != null)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
    }
}
