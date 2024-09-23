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
    public partial class SplitAt : Form
    {
        public double qty { get; private set; }
        private decimal oldQty;

        public SplitAt(decimal qty, string operationType)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            numericUpDown1.Maximum = qty;
            numericUpDown1.Minimum = 0;
            label4.Text = qty.ToString();
            label5.Text = operationType;
            oldQty= qty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(numericUpDown1.Value < oldQty && numericUpDown1.Value > 0)
            {
                qty = double.Parse(numericUpDown1.Value.ToString());
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter a valid quantity");
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
