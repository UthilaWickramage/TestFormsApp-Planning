using Entities;
using MindFusion.HolidayProviders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestFormsApp_Planning.Classes;
using TestFormsApp_Planning.Helpers;

namespace TestFormsApp_Planning
{
    public partial class AddTask : Form
    {
        private OrderAllocation _tsa;
        private List<Entities.Holiday> _holidays;
        List<WorkStation> _machines;
        private ScheduleUtil _util;
        public AddTask(List<Entities.Holiday> holidays)
        {
            InitializeComponent();
            _holidays = holidays;
            _util = new ScheduleUtil(_holidays);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dddd, dd MMM yyyy - hh:mm tt";
            _machines = new List<WorkStation>();
            using (var context = new ScheduleDBContext())
            {
                context.WorkStations.ToList().ForEach(machine =>
                {
                    _machines.Add(machine);

                });
            }

            comboBox1.DataSource = _machines;
            comboBox1.DisplayMember = "WorkStationName";
            comboBox1.ValueMember = "WorkStationId";
        }

        public AddTask(OrderAllocation tsa, List<Entities.Holiday> holidays)
        {
            InitializeComponent();
            _holidays = holidays;
            _machines = new List<WorkStation>();
            _util = new ScheduleUtil(_holidays);

            using (var context = new ScheduleDBContext())
            {
                context.WorkStations.ToList().ForEach(contact =>
                {
                    _machines.Add(contact);

                });

            }
            _tsa = tsa;
            dateTimePicker1.Value = _tsa.StartTime;
            comboBox1.DataSource = _machines;
            comboBox1.DisplayMember = "WorkStationName";
            comboBox1.ValueMember = "WorkStationId";
        }

       

        //private TimeSpan ConvertDecimalDaysToTimeSpan(decimal decimalDays)
        //{
        //    // Calculate the total hours, minutes, and seconds from the decimal value of days
        //    int days = (int)decimalDays;
        //    int hours = (int)((decimalDays - days) * 24);
        //    int minutes = (int)(((decimalDays - days) * 24 - hours) * 60);
        //    int seconds = (int)((((decimalDays - days) * 24 - hours) * 60 - minutes) * 60);

        //    return new TimeSpan(days, hours, minutes, seconds);
        //}

        //private DateTime CalculateEndDateConsideringHolidays(DateTime startTime, DateTime endTime, int duration)
        //{


        //    // Calculate the initial duration between startTime and endTime
        //    int initialDays = (endTime - startTime).Days;

        //    // Calculate the total number of days needed, considering holidays
        //    DateTime adjustedEndTime = endTime;

        //    while ((adjustedEndTime - startTime).Days == duration)
        //    {

        //        // Check if the current endTime falls on a weekend or a holiday
        //        bool isHolidayOrWeekend = _holidays
        //            .Any(holiday => IsDateInRange(holiday.HolidayDate, startTime, adjustedEndTime) && holiday.HolidayDate.Date == adjustedEndTime.Date) ||
        //            adjustedEndTime.DayOfWeek == DayOfWeek.Saturday ||
        //            adjustedEndTime.DayOfWeek == DayOfWeek.Sunday;

        //        if (isHolidayOrWeekend)
        //        {
        //            // Extend the endTime by one day if it falls on a holiday or weekend
        //            adjustedEndTime = adjustedEndTime.AddDays(1);
        //        }
        //        else
        //        {
        //            // If not a holiday or weekend, check if duration is met
        //            if ((adjustedEndTime - startTime).Days == duration)
        //            {
        //                break;
        //            }
        //        }


        //        //// Check if the current endTime overlaps with any holidays
        //        //var holidaysInRange = _holidays
        //        //    .Where(holiday => IsDateInRange(holiday.HolidayDate, startTime, adjustedEndTime))
        //        //    .Select(holiday => holiday.HolidayDate)
        //        //    .Distinct()
        //        //    .OrderBy(date => date)
        //        //    .ToList();

        //        //// If there are holidays within the range, extend the endTime
        //        //if (holidaysInRange.Any())
        //        //{
        //        //    foreach (var holiday in holidaysInRange)
        //        //    {
        //        //        if (adjustedEndTime.Date >= holiday.Date)
        //        //        {
        //        //            // Extend the endTime by one day for each holiday
        //        //            adjustedEndTime = adjustedEndTime.AddDays(1);
        //        //        }
        //        //    }
        //        //}
        //        //else
        //        //{
        //        //    // If no holidays, just extend the endTime to meet the duration
        //        //    adjustedEndTime = adjustedEndTime.AddDays(1);
        //        //}
        //    }

        //    return adjustedEndTime;
        //}

      
    

        private async void button1_Click(object sender, EventArgs e)
        {
            string TaskName = textBox1.Text;
            DateTime StartTime = dateTimePicker1.Value;
            int Id = (int)comboBox1.SelectedValue;
            decimal qty = numericUpDown1.Value;


            var machine =  _machines.Where(m => m.WorkStationId == Id).FirstOrDefault();
            
           
            var capacity =  decimal.Parse(machine.CapacityPerHour);
            decimal durationInHours = qty / capacity;
            MessageBox.Show(durationInHours.ToString());
            decimal Days = durationInHours / 8;
            MessageBox.Show(Days.ToString());
            DateTime endDate = StartTime.AddDays(double.Parse(Days.ToString()));

            DateTime endTime = _util.CalculateEndDateConsideringHolidays(StartTime, endDate, double.Parse(Days.ToString()));


            TimeSpan visibleStart = TimeSpan.FromHours(8); // 8 AM visible start
            TimeSpan visibleEnd = TimeSpan.FromHours(16);

            DateTime visibleStartDateTime = _util.MapToVisibleRange(StartTime, visibleStart, visibleEnd);
            DateTime visibleEndDateTime = _util.MapToVisibleRange(endTime, visibleStart, visibleEnd);

            MessageBox.Show(visibleStartDateTime.ToString()+" To "+visibleEndDateTime.ToString());
            
            //OrderAllocation tsa = new OrderAllocation();
            Entities.Order task = new Entities.Order();
            task.StartTime = StartTime;
            task.EndTime = endTime;
            task.VisibleStartTime = visibleStartDateTime;
            task.VisibleEndTime = visibleEndDateTime;   
            task.OrderTitle = TaskName;
            task.OrderDescription = TaskName;
            task.MachineId = Id;
            task.Qty = qty.ToString();
            task.DurationInHours = double.Parse(durationInHours.ToString());

            using (var context = new ScheduleDBContext())
            {
                context.Orders.Add(task);
                await context.SaveChangesAsync();

            }
            MessageBox.Show("Order added Successfully");
        }
        
    }
}
