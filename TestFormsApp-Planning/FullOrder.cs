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

        public FullOrder(BindingList<Operation> unScheduledList, BindingList<Operation> scheduledList, List<WorkStation> workstations, string OrderNo)
        {
            InitializeComponent();
            _unScheduledList = unScheduledList;
            _scheduledList = scheduledList;
            _workStations = workstations;
            _OrderNo = OrderNo;
            loadContacts();
            loadTasks();
            loadOrderDetails();
            FillDataGridViews();
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
            var list = _scheduledList.Where(l => l.OrderNo == _OrderNo).ToList();
          
            foreach (Operation op in list)
            {
                foreach (var d in op.ScheduledOperationDetails)
                {
                    if (earliest > d.StartTime)
                    {
                        earliest = d.StartTime;
                    }
                    MindFusion.Scheduling.Contact contact = calendar1.Contacts.Where(a => a.Id.Trim() == op.WorkStation.WorkStationId.ToString()).FirstOrDefault();
                 
                    contact.Name = op.WorkStation.WorkStationName;
                    contact.Id = op.WorkStation.WorkStationId.ToString();
                
                    OrderAllocation oa = new OrderAllocation();
                    oa.OrderAllocationId = op.Order.OrderId;

                    oa.OrderTitle = op.OrderNo;
                    oa.HeaderText = op.OrderNo;
                    oa.StartTime = d.StartTime;
                    oa.EndTime = d.EndTime;
                    oa.VisibleEndTime = d.VisibleEndTime;
                    oa.VisibleStartTime = d.VisibleStartTime;
                    oa.Qty = d.Qty.ToString();
                    oa.DurationInHours = d.DurationInHours;
                    oa.deliveryDate = op.DeliveryDate;
                    oa.Customer = op.Customer;
                    oa.Id = d.ScheduledOperationDetailsId.ToString();
                    oa.Contacts.Add(contact);
                    oa.Operation_Type = op.Operation_Type;
                    oa.ProductName = op.Product.Product_Name;
                    oa.Style.FillColor = System.Drawing.Color.Red;
                    oa.Style.LineColor = System.Drawing.Color.Red;
                    calendar1.Schedule.Items.Add(oa);
                }
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
