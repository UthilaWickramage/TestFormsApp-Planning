
using Entities;
using MindFusion.HolidayProviders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestFormsApp_Planning.Classes;

namespace TestFormsApp_Planning
{
    public partial class AddHoliday : Form
    {

        public AddHoliday()
        {
            InitializeComponent();
            List<Machine> contacts = new List<Machine>();
            using (var context = new Entities.ScheduleDBContext())
            {
                context.Machines.ToList().ForEach(contact =>
                {
                    contacts.Add(contact);

                });

            }

            comboBox1.DataSource = contacts;

            comboBox1.DisplayMember = "MachineName";
            comboBox1.ValueMember = "MachineId";
        }

       

        private async void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            DateTime dateTime = dateTimePicker1.Value;
            int Id = (int) comboBox1.SelectedValue;

            using (var context = new Entities.ScheduleDBContext())
            {
                Entities.Holiday holiday = new Entities.Holiday()
                {
                    HolidayName = name,
                    HolidayDate = dateTime,
                    MachineId = Id
                };
                context.Holidays.Add(holiday);
                await context.SaveChangesAsync();
            }
        }

      
    }
}
