using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestFormsApp_Planning
{
    public partial class SetCustomHours : Form
    {
        private WorkStation _workstation;
        List<WorkStation> _workstations;
        private DateTime _date;
        public SetCustomHours()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd MMM yyyy";
            dateTimePicker1.ShowUpDown = true;

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "hh:mm tt";
            dateTimePicker2.ShowUpDown = true;

            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.CustomFormat = "hh:mm tt";
            dateTimePicker3.ShowUpDown = true;

        }

        public SetCustomHours(List<WorkStation> workstations, WorkStation workStation, DateTime dateTime)
        {
            InitializeComponent();
            _workstation = workStation;
            _date = dateTime;
            _workstations = workstations;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd MMM yyyy";
            dateTimePicker1.ShowUpDown = true;

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "hh:mm tt";
            dateTimePicker2.ShowUpDown = true;

            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.CustomFormat = "hh:mm tt";
            dateTimePicker3.ShowUpDown = true;

            comboBox1.DataSource = _workstations;
            comboBox1.DisplayMember = "WorkStationName";
            comboBox1.ValueMember = "WorkStationId";

            comboBox1.SelectedIndex = workStation.WorkStationId - 1;
            comboBox1.SelectedItem = workStation.WorkStationName;

            dateTimePicker1.Value = _date;

            dateTimePicker1.Enabled = false;
            dateTimePicker2.Value = new DateTime(_date.Year,_date.Month,_date.Day,8,0,0);
            dateTimePicker3.Value = new DateTime(_date.Year, _date.Month, _date.Day, 16, 0, 0);

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            DateTime startTime = dateTimePicker2.Value;
            DateTime endTime = dateTimePicker3.Value;

            double hours = (endTime - startTime).TotalHours;
            textBox1.Text = hours.ToString();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime startTime = dateTimePicker2.Value;
            DateTime endTime = dateTimePicker3.Value;

            double hours = (endTime - startTime).TotalHours;
            textBox1.Text = hours.ToString();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex + 1;
         string description = textBox2.Text;
            if (description.Length < 0)
            {
                description = "Default Reason";
            }
            DateTime startTime = dateTimePicker2.Value;
            DateTime endTime = dateTimePicker3.Value;
            
            using(var context = new ScheduleDBContext())
            {
                CustomDay custom = new CustomDay()
                {
                    Description = description,
                    StartTime = startTime,
                    EndTime = endTime,
                    WorkstationId = index
                };

                context.CustomDays.Add(custom);
                await context.SaveChangesAsync();

            }
            MessageBox.Show("Custom Day added successfully");
        }
    }
}
