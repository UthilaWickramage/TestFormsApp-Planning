using System;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Entities;
using Microsoft.EntityFrameworkCore;
using MindFusion.HolidayProviders;
using MindFusion.Scheduling;
using MindFusion.Scheduling.WinForms;
using TestFormsApp_Planning.Classes;

namespace TestFormsApp_Planning
{
    public partial class Scheduler : Form
    {
        private List<Entities.Machine> machines = new List<Entities.Machine>();
        private List<Entities.Task> tasks = new List<Entities.Task>();
        private List<Entities.Holiday> holidays = new List<Entities.Holiday>();
        private CustomHolidayProvider holidayProvider;
        DateTime _startTime;
        DateTime _endTime;
        bool isDragging;
        public Scheduler()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            calendar1.ResourceViewSettings.LaneSize = 25;
            holidayProvider = new CustomHolidayProvider();
            loadContacts();
            loadTasks();
            loadHolidays();

            // Add resources
        }

        private void loadHolidays()
        {

            using (var context = new ScheduleDBContext())
            {

                context.Holidays.ToList().ForEach(h =>
                {
                    holidays.Add(h);
                });


            }
        }

        private void loadContacts()
        {
            calendar1.Contacts.Clear();

            using (var context = new ScheduleDBContext())
            {
                machines = context.Machines.ToList();
                foreach (var machine in machines)
                {
                    MindFusion.Scheduling.Contact calenderMachine = new MindFusion.Scheduling.Contact();
                    calenderMachine.FirstName = machine.MachineName;
                    calenderMachine.Id = machine.MachineName;
                    calenderMachine.Name = machine.MachineName;
                    calendar1.Contacts.Add(calenderMachine);
                }
            }
            loadTasks();
        }

        private void loadTasks()
        {
            calendar1.Schedule.Items.Clear();

            using (var context = new ScheduleDBContext())
            {
                tasks = context.Tasks.Include(t => t.Machine).ToList();
                foreach (var task in tasks)
                {
                    MindFusion.Scheduling.Contact contact = calendar1.Contacts.Where(a => a.Name.Trim() == task.Machine.MachineName.Trim()).FirstOrDefault();

                    contact.Name = task.Machine.MachineName;
                    contact.Id = task.Machine.MachineId.ToString();
                    TaskAllocation tsa = new TaskAllocation();
                    tsa.TaskName = task.TaskName;
                    tsa.HeaderText = task.TaskName;
                    tsa.StartTime = task.StartTime;
                    tsa.EndTime = task.EndTime;
                    tsa.Id = task.TaskId.ToString();
                    tsa.Contacts.Add(contact);
                   
                    calendar1.Schedule.Items.Add(tsa);

                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddTask form = new AddTask(holidays);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormClosed += (s, args) => loadTasks();

            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var context = new ScheduleDBContext())
            {
                var form = new AddContact(context);
                form.StartPosition = FormStartPosition.CenterScreen;
                form.FormClosed += (s, args) => loadContacts();

                form.Show();
            }


            //var resource1 = new Machine();
            //resource1.Name = "Computer 1";
            //resource1.FirstName = "Computer 1";
            //resource1.Id = "Computer 1";
            //calendar1.Machines.Add(resource1);
        }

        private void calendar1_DateClick(object sender, MindFusion.Scheduling.WinForms.ResourceDateEventArgs e)
        {

            TaskAllocation tsa = new TaskAllocation();
            tsa.StartTime = e.Date;
            AddTask form = new AddTask(tsa,holidays);
            form.FormClosed += (s, args) => loadTasks();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
        }

        private async void calendar1_ItemModified(object sender, MindFusion.Scheduling.WinForms.ItemModifiedEventArgs e)
        {
            //DialogResult result = MessageBox.Show(
            //        "Are you sure you want to modify the start time to "+e.Item.StartTime+ " and end time to " +e.Item.EndTime+" ?",  // Message
            //        "Save Modification",                            // Title
            //        MessageBoxButtons.OKCancel,                       // Buttons (Yes and No)
            //        MessageBoxIcon.Warning                         // Icon (Warning)
            //        );

            using (var context = new ScheduleDBContext())
            {
                foreach (var task in tasks)
                {
                    if (task.TaskName.ToString() == e.Item.HeaderText)
                    {
                        //MessageBox.Show("Task Name " + task.TaskId + "item id " + e.Item.Task.Name);
                        task.StartTime = e.Item.StartTime;
                        task.EndTime = e.Item.EndTime;
                        context.Tasks.Update(task);
                        await context.SaveChangesAsync();

                        break;
                    }

                }
                //MessageBox.Show("New Start Time is: " + e.Item.StartTime + " & New End time is: " + e.Item.EndTime);
            }

        }

        


        private void button1_Click_1(object sender, EventArgs e)
        {
            var form = new AddHoliday();
            form.StartPosition = FormStartPosition.CenterScreen;
            // form.FormClosed += (s, args) => loadContacts();
            
            form.Show();
        }

        private void calendar1_ItemDrawing(object sender, MindFusion.Scheduling.WinForms.DrawEventArgs e)
        {
            
        }

        private void calendar1_Draw(object sender, DrawEventArgs e)
        {
            MessageBox.Show("This is called");
            if (e.Element == CustomDrawElements.CellHeader)
            {
                MessageBox.Show("This is called");

                Rectangle bounds = e.Bounds;
                if (e.Date.Date == DateTime.Today)
                {
                    using (Brush brush = new SolidBrush(Color.FromArgb(100, Color.White)))
                    {
                        e.Graphics.FillRectangle(brush, bounds);
                    }

                    using (Pen pen = new Pen(Color.Red, 3))
                    {
                        pen.Alignment = PenAlignment.Inset;
                        e.Graphics.DrawRectangle(pen, bounds);
                    }
                }
                else
                {
                    if (holidays != null && holidays.Count > 0)
                    {
                        bool isHoliday = false;
                        foreach (Entities.Holiday holiday in holidays)
                        {
                            if (holiday.HolidayDate <= e.Date.Date)
                            {
                                isHoliday = true;
                                break;
                            }
                        }

                        if (isHoliday)
                        {
                            using (Brush brush = new SolidBrush(Color.FromArgb(128, Color.LightSteelBlue)))
                            {
                                e.Graphics.FillRectangle(brush, bounds);
                            }

                            using (Pen pen = new Pen(Color.FromArgb(192, Color.SlateGray)))
                            {
                                Rectangle borderBounds = bounds;
                                borderBounds.Width -= 1;
                                borderBounds.Height -= 1;
                                e.Graphics.DrawRectangle(pen, borderBounds);
                            }

                            using (StringFormat format = new StringFormat())
                            {
                                format.Alignment = StringAlignment.Center;
                                format.LineAlignment = StringAlignment.Center;

                                using (Brush brush = new SolidBrush(Color.FromArgb(192, 0, 0)))
                                {
                                    e.Graphics.DrawString(e.Text, e.Style.HeaderFont, brush,
                                        new RectangleF(bounds.X, bounds.Y, bounds.Width, bounds.Height), format);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
