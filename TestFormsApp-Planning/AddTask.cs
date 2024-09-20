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


        List<Product> _products;

        
        public AddTask()
        {
            InitializeComponent();
        
            _products = new List<Product>();
  

            using (var context = new ScheduleDBContext())
            {
                context.Products.ToList().ForEach(product =>
                {
                    _products.Add(product);

                });

            }
       
            comboBox1.DataSource = _products;
            comboBox1.DisplayMember = "Product_Name";
            comboBox1.ValueMember = "Product_Id";
        }

       


        private async void button1_Click(object sender, EventArgs e)
        {
            string TaskName = textBox1.Text;
            string customer = textBox2.Text;
            DateTime StartTime = dateTimePicker1.Value;
            int Id = (int) comboBox1.SelectedValue;
            decimal qty = numericUpDown1.Value;
      
            Entities.Order order = new Entities.Order();
            order.OrderNo = TaskName;

            order.ProductId = Id;
            order.Status = OrderStatus.PENDING;
            order.CustomerName = customer;
            order.ExpectedDeliveryDate = StartTime;
            order.Qty = double.Parse(qty.ToString());
            
            

            using (var context = new ScheduleDBContext())
            {
                context.Orders.Add(order);
                await context.SaveChangesAsync();

            }
            MessageBox.Show("Operation added Successfully");
        }
        
    }
}
