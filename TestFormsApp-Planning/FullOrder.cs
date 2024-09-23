using Entities;
using MindFusion.Scheduling;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestFormsApp_Planning.Classes;

namespace TestFormsApp_Planning
{
    public partial class FullOrder : Form
    {
        BindingList<Operation> _unScheduledList;
        BindingList<Operation> _scheduledList;
        List<WorkStation> _workStations;
        string _OrderNo;
        ItemCollection _itemCollection;

        public FullOrder(ItemCollection itemCollection,BindingList<Operation> unScheduledList, BindingList<Operation> scheduledList, List<WorkStation> workstations, string OrderNo)
        {
            InitializeComponent();
            optMainTheme.optMainTheme mt = new optMainTheme.optMainTheme();
            calendar1.ApplyTheme(mt);
            _unScheduledList = unScheduledList;
            _scheduledList = scheduledList;
            _workStations = workstations;
            _OrderNo = OrderNo;
            _itemCollection  = itemCollection;
            loadContacts();
            loadTasks();
            loadOrderDetails();
            FillDataGridViews();
            dataGridView1.DefaultCellStyle.BackColor = Color.DarkGray;           // Row background color
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;           // Row text color
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;   // Row selection background color
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;      // Row selection text color

            // Customize the column headers' style
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);  // Font style for header text

            // Optionally customize row headers if they are shown (optional)
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.DarkGray;   // Row header background color
            dataGridView1.RowHeadersDefaultCellStyle.ForeColor = Color.Black;           // Row header text color

            // Disable column headers visual styles (to apply custom styles completely)
            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView2.DefaultCellStyle.BackColor = Color.DarkGray;           // Row background color
            dataGridView2.DefaultCellStyle.ForeColor = Color.Black;           // Row text color
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;   // Row selection background color
            dataGridView2.DefaultCellStyle.SelectionForeColor = Color.White;      // Row selection text color
            dataGridView2.BackgroundColor = SystemColors.ControlDarkDark;
            // Customize the column headers' style
            //dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;   // Header background color
            //dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;           // Header text color
            //dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);  // Font style for header text

            // Optionally customize row headers if they are shown (optional)
            dataGridView2.RowHeadersDefaultCellStyle.BackColor = Color.DarkGray;   // Row header background color
            dataGridView2.RowHeadersDefaultCellStyle.ForeColor = Color.Black;           // Row header text color
            // Disable column headers visual styles (to apply custom styles completely)
            dataGridView2.EnableHeadersVisualStyles = false;
        }

        private void FillDataGridViews()
        {
            var list = _scheduledList.Where(l => l.OrderNo == _OrderNo).ToList();
            BindingList<Operation> bindingList = new BindingList<Operation>(list);

            var list2 = _unScheduledList.Where(l => l.OrderNo == _OrderNo).ToList();
            BindingList<Operation> bindingList2 = new BindingList<Operation>(list2);


            dataGridView1.DataSource = bindingList2;
            dataGridView2.DataSource = bindingList;
        }
        private void loadOrderDetails()
        {
            var order = _scheduledList.Where(l => l.OrderNo == _OrderNo).FirstOrDefault();

            if (order != null)
            {
                label2.Text = order.OrderNo;
                label4.Text = order.Customer;
                label6.Text = order.Product.Product_Name;
                label10.Text = order.Qty.ToString();
                DateTime d = order.DeliveryDate;
                label8.Text = new DateOnly(d.Year, d.Month, d.Day).ToString();
            }
        }

        private void loadTasks()
        {
            DateTime earliest = DateTime.Now;
            var list = _itemCollection.Where(l => l.HeaderText == _OrderNo).ToList();
       
            foreach (OrderAllocation oa in list)
            {
             
                if (earliest > oa.StartTime)
                   {
                    earliest = oa.StartTime;
                   }
                
                MindFusion.Scheduling.Contact contact = calendar1.Contacts.FirstOrDefault(c => c.Id == oa.Contact.Id);

                if (contact != null)
                {
                    oa.Contacts.Add(contact);
                }
                oa.Style.FillColor = Color.Red;
                oa.Style.LineColor = Color.Red;
                calendar1.Schedule.Items.Add(oa);

            }

            calendar1.Date = earliest;

        }

        private void loadContacts()
        {
            
            foreach (var item in _workStations)
            {
                    Contact contact = new Contact();
                    contact.FirstName = item.WorkStationName;
                    contact.Name = item.WorkStationName;
                    contact.Id = item.WorkStationId.ToString();
                    calendar1.Contacts.Add(contact);
               
            }
        }

       
        private void calendar1_ItemTooltipDisplaying(object sender, MindFusion.Scheduling.WinForms.ItemTooltipEventArgs e)
        {

            OrderAllocation item = (OrderAllocation)e.Item;

            string t = $"Order No: {item.OrderTitle}\n" +
                   $"Customer: {item.Customer}\n" +
                      $"Product: {item.ProductName}\n" +
                       $"Delivery Date: {new DateOnly(item.deliveryDate.Year, item.deliveryDate.Month, item.deliveryDate.Day)}\n" +

                       "--------------------------------\n" +

                        $"Operation Type: {item.Operation_Type.Operation_Type_Name}\n" +
             $"Duration: {item.DurationInHours}\n" +
               $"Qty: {item.Qty}\n" +
                $"Start Time: {item.VisibleStartTime}\n" +
                          $"End Time: {item.VisibleEndTime}\n";

            e.Tooltip = t;
        }
    }
}
