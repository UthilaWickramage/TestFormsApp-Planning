using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestFormsApp_Planning
{
    public partial class AddContact : Form
    {
        private readonly ScheduleDBContext _dbContext;

        public AddContact()
        {
        }

        public AddContact(ScheduleDBContext dBContext)
        {
            InitializeComponent();
            _dbContext = dBContext;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            using (var _dbContext = new ScheduleDBContext())
            {
                string nameText = textBox1.Text;
                string value = numericUpDown1.Value.ToString();

                if (nameText.Length > 0)
                {
                    WorkStation machine = new WorkStation();
                    machine.WorkStationName = nameText;
                    machine.CapacityPerHour = value;
                    _dbContext.WorkStations.Add(machine);
                    await _dbContext.SaveChangesAsync();
                    MessageBox.Show("WorkStation Added Successfully");
                }
            }
        }

        
    }
}
