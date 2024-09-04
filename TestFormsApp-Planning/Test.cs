using System;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
using Microsoft.EntityFrameworkCore;
using MindFusion.HolidayProviders;
using MindFusion.Scheduling;
using MindFusion.Scheduling.WinForms;
using TestFormsApp_Planning.Classes;
using TestFormsApp_Planning.Helpers;

namespace TestFormsApp_Planning
{
    public partial class Scheduler : Form
    {
        private List<Entities.WorkStation> machines = new List<Entities.WorkStation>();
        private List<Entities.Order> tasks = new List<Entities.Order>();
        private List<Entities.Holiday> holidays = new List<Entities.Holiday>();
        BindingList<PendingOrder> dataSource1;
        private ScheduleUtil _util;
        private List<OrderAllocation> OrderAllocations = new List<OrderAllocation>();
        private List<OrderAllocation> UnsavedOrderAllocations = new List<OrderAllocation>();

        public Scheduler()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            calendar1.ResourceViewSettings.LaneSize = 25;
            loadContacts();
            //loadTasks();
            loadHolidays();


            loadProducts();
            _util = new ScheduleUtil(holidays);
            dataGridView1.DataSource = dataSource1;
            AddToOrdersToView();
            // Add resources
        }

        private void loadProducts()
        {
            using (var context = new ScheduleDBContext())
            {
                var orderList = context.PendingOrders.ToList();
                dataSource1 = new BindingList<PendingOrder>(orderList);
                dataGridView1.AutoGenerateColumns = false;
            }
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
                machines = context.WorkStations.ToList();
                foreach (var machine in machines)
                {
                    MindFusion.Scheduling.Contact calenderMachine = new MindFusion.Scheduling.Contact();
                    calenderMachine.FirstName = machine.WorkStationName;
                    calenderMachine.Id = machine.WorkStationName;
                    calenderMachine.Name = machine.WorkStationName;
                    calendar1.Contacts.Add(calenderMachine);
                }
            }
            loadTasks();
        }

        private void loadTasks()
        {
            MessageBox.Show("Load tasks called");

            using (var context = new ScheduleDBContext())
            {
                tasks = context.Orders.Include(t => t.Machine).ToList();
                foreach (var task in tasks)
                {
                    MindFusion.Scheduling.Contact contact = calendar1.Contacts.Where(a => a.Name.Trim() == task.Machine.WorkStationName.Trim()).FirstOrDefault();

                    contact.Name = task.Machine.WorkStationName;
                    contact.Id = task.Machine.WorkStationId.ToString();
                    OrderAllocation tsa = new OrderAllocation();
                    tsa.OrderTitle = task.OrderTitle;
                    tsa.HeaderText = task.OrderTitle;
                    tsa.StartTime = task.StartTime;
                    tsa.EndTime = task.EndTime;
                    tsa.Id = task.OrderId.ToString();
                    tsa.Contacts.Add(contact);

                    OrderAllocations.Add(tsa);
                }
            }

        }

        private void AddToOrdersToView()
        {
            MessageBox.Show("Add to Orders called called");

            foreach (var orderAllocation in OrderAllocations)
            {
                calendar1.Schedule.Items.Add(orderAllocation);
            }
            foreach (var orderAllocation in UnsavedOrderAllocations)
            {
                calendar1.Schedule.Items.Add(orderAllocation);
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


            //var resource1 = new WorkStation();
            //resource1.Name = "Computer 1";
            //resource1.FirstName = "Computer 1";
            //resource1.Id = "Computer 1";
            //calendar1.Machines.Add(resource1);
        }

        private void calendar1_DateClick(object sender, MindFusion.Scheduling.WinForms.ResourceDateEventArgs e)
        {

            OrderAllocation tsa = new OrderAllocation();
            tsa.StartTime = e.Date;
            AddTask form = new AddTask(tsa, holidays);
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

            foreach (var task in tasks)
            {
                if (task.OrderTitle.ToString() == e.Item.HeaderText)
                {
                    task.StartTime = e.Item.StartTime;
                    task.EndTime = e.Item.EndTime;
                }
            }


            //using (var context = new ScheduleDBContext())
            //{
            //    foreach (var task in tasks)
            //    {
            //        if (task.TaskName.ToString() == e.Item.HeaderText)
            //        {
            //            //MessageBox.Show("Order Name " + task.OrderAllocationId + "item id " + e.Item.Order.Name);
            //            task.StartTime = e.Item.StartTime;
            //            task.EndTime = e.Item.EndTime;
            //            context.Tasks.Update(task);
            //            await context.SaveChangesAsync();

            //            break;
            //        }

            //    }
            //    //MessageBox.Show("New Start Time is: " + e.Item.StartTime + " & New End time is: " + e.Item.EndTime);
            //}

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

        private async void button4_Click(object sender, EventArgs e)
        {
            using (var context = new ScheduleDBContext())
            {
                foreach (var orderAllocation in UnsavedOrderAllocations)
                {
                    Order order = new Order
                    {
                        OrderTitle = orderAllocation.OrderTitle,
                        OrderDescription = orderAllocation.OrderDescription,
                        StartTime = orderAllocation.StartTime,
                        EndTime = orderAllocation.EndTime,
                        VisibleEndTime = orderAllocation.VisibleEndTime,
                        VisibleStartTime = orderAllocation.VisibleStartTime,
                        DurationInHours = orderAllocation.DurationInHours,
                        Qty = orderAllocation.Qty,
                        MachineId = orderAllocation.WorkstationId
                    };

                    context.Orders.Add(order);
                    await context.SaveChangesAsync();
                    MessageBox.Show("New Orders Saved Successfully");
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                splitContainer1.Panel2Collapsed = true;
            }
            else
            {
                splitContainer1.Panel2Collapsed = false;
            }
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1 && e.Button == MouseButtons.Left)
            {
                var hitTest = dataGridView1.HitTest(e.X, e.Y);
                if (hitTest.RowIndex >= 0)
                {
                    var row = dataGridView1.Rows[hitTest.RowIndex];
                    var dataItem = (PendingOrder)row.DataBoundItem;

                    if (dataItem != null)
                    {
                        calendar1.DoDragDrop(dataItem, DragDropEffects.Move);
                    }
                }
            }
        }

    

        private async void calendar1_DragDrop(object sender, DragEventArgs e)
        {
            Point dropPoint = calendar1.PointToClient(new Point(e.X, e.Y));
            try
            {
                PendingOrder order = (PendingOrder)e.Data.GetData(typeof(PendingOrder));

                DateTime dropDateTime = calendar1.GetDateAt(dropPoint);
                MessageBox.Show(dropDateTime.ToString() + "   " + order.PendingOrderTitle);
                Contact contact = calendar1.GetContactAt(dropPoint);
                WorkStation workStation;

                OrderAllocation orderAllocation = new OrderAllocation();
                DateTime StartTime = new DateTime(dropDateTime.Year, dropDateTime.Month, dropDateTime.Day, 0, 0, 0);
                orderAllocation.StartTime = StartTime;
                orderAllocation.OrderTitle = order.PendingOrderTitle;
                orderAllocation.HeaderText = order.PendingOrderTitle;

                //  orderAllocation.EndTime = task.EndTime;
                orderAllocation.Id = order.PendingOrderTitle.ToString();
                orderAllocation.Contacts.Add(contact);

                using (var context = new ScheduleDBContext())
                {
                   
                   workStation = await context.WorkStations.Where(w=>w.WorkStationName == contact.Name).FirstOrDefaultAsync();
                }

                var capacity = decimal.Parse(workStation.CapacityPerHour);
                decimal durationInHours = order.PendingOrderQty / capacity;
                //MessageBox.Show(durationInHours.ToString());
                decimal Days = durationInHours / 8;
                //MessageBox.Show(Days.ToString());
                DateTime endDate = StartTime.AddDays(double.Parse(Days.ToString()));

                DateTime endTime = _util.CalculateEndDateConsideringHolidays(StartTime, endDate, double.Parse(Days.ToString()));


                TimeSpan visibleStart = TimeSpan.FromHours(8); // 8 AM visible start
                TimeSpan visibleEnd = TimeSpan.FromHours(16);

                DateTime visibleStartDateTime = _util.MapToVisibleRange(StartTime, visibleStart, visibleEnd);
                DateTime visibleEndDateTime = _util.MapToVisibleRange(endTime, visibleStart, visibleEnd);

                orderAllocation.EndTime = endTime;
                orderAllocation.VisibleStartTime = visibleStartDateTime;
                orderAllocation.VisibleEndTime = visibleEndDateTime;
                orderAllocation.Qty = order.PendingOrderQty.ToString();
                orderAllocation.OrderDescription = order.PendingOrderDescription;
                orderAllocation.DurationInHours = double.Parse(durationInHours.ToString());
                orderAllocation.WorkstationId = workStation.WorkStationId;
               // calendar1.Schedule.Items.Add(orderAllocation);
                UnsavedOrderAllocations.Add(orderAllocation);
                AddToOrdersToView();
               // calendar1.Invalidate();
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.ToString());
            }
                
           
        }

        private void calendar1_DragOver(object sender, DragEventArgs e)
        {
            
            if (e.Data.GetDataPresent(typeof(PendingOrder)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }




        //private Rectangle dragBoxFromMouseDown;
        //private object valueFromMouseDown;


        //private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        //{
        //    // Get the index of the item the mouse is below.
        //    var hittestInfo = dataGridView1.HitTest(e.X, e.Y);

        //    if (hittestInfo.RowIndex != -1 && hittestInfo.ColumnIndex != -1)
        //    {
        //        valueFromMouseDown = dataGridView1.Rows[hittestInfo.RowIndex].Cells[hittestInfo.ColumnIndex].Value;
        //        if (valueFromMouseDown != null)
        //        {
        //            // Remember the point where the mouse down occurred. 
        //            // The DragSize indicates the size that the mouse can move 
        //            // before a drag event should be started.                
        //            Size dragSize = SystemInformation.DragSize;

        //            // Create a rectangle using the DragSize, with the mouse position being
        //            // at the center of the rectangle.
        //            dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);
        //        }
        //    }
        //    else
        //        // Reset the rectangle if the mouse is not over an item in the ListBox.
        //        dragBoxFromMouseDown = Rectangle.Empty;
        //}

        ////private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        ////{
        ////    if (e.Button == MouseButtons.Left)
        ////    {
        ////        // Hit test to see if a row is clicked
        ////        var hitTest = dataGridView1.HitTest(e.X, e.Y);
        ////        if (hitTest.RowIndex >= 0)
        ////        {
        ////            // Start the drag operation
        ////            dataGridView1.DoDragDrop(dataGridView1.Rows[hitTest.RowIndex], DragDropEffects.Move);
        ////        }
        ////    }
        ////}

        //private void dataGridView2_DragOver(object sender, DragEventArgs e)
        //{
        //    e.Effect = DragDropEffects.Copy;
        //}

        //private void dataGridView1_MouseMove_1(object sender, MouseEventArgs e)
        //{
        //    if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
        //    {
        //        // If the mouse moves outside the rectangle, start the drag.
        //        if (dragBoxFromMouseDown != Rectangle.Empty && !dragBoxFromMouseDown.Contains(e.X, e.Y))
        //        {
        //            // Proceed with the drag and drop, passing in the list item.                    
        //            DragDropEffects dropEffect = dataGridView1.DoDragDrop(valueFromMouseDown, DragDropEffects.Copy);
        //        }
        //    }
        //}



        //private void dataGridView2_DragDrop(object sender, DragEventArgs e)
        //{
        //    // The mouse locations are relative to the screen, so they must be 
        //    // converted to client coordinates.
        //    Point clientPoint = dataGridView2.PointToClient(new Point(e.X, e.Y));

        //    // If the drag operation was a copy then add the row to the other control.
        //    if (e.Effect == DragDropEffects.Copy)
        //    {
        //        string cellvalue = e.Data.GetData(typeof(string)) as string;
        //        var hittest = dataGridView2.HitTest(clientPoint.X, clientPoint.Y);
        //        if (hittest.ColumnIndex != -1
        //            && hittest.RowIndex != -1)
        //            dataGridView2[hittest.ColumnIndex, hittest.RowIndex].Value = cellvalue;

        //    }
        //}

        //private void dataGridView2_DragEnter(object sender, DragEventArgs e)
        //{
        //    MessageBox.Show("Dragged and Enter");
        //    e.Effect = DragDropEffects.Copy;
        //}



        //private void dataGridView1_DragEnter(object sender, DragEventArgs e)
        //{
        //    if (e.Data.GetDataPresent(typeof(DataGridViewRow)))
        //    {
        //        e.Effect = DragDropEffects.Move;
        //    }
        //    else
        //    {
        //        e.Effect = DragDropEffects.None;
        //    }
        //}
    }
}
