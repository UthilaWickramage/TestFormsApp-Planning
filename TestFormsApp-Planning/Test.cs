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
using Syncfusion.Windows.Forms.Tools.Win32API;
using TestFormsApp_Planning.Classes;
using TestFormsApp_Planning.Helpers;
using Order = Entities.Order;

namespace TestFormsApp_Planning
{
    public partial class Scheduler : Form
    {
        private List<Entities.WorkStation> machines = new List<Entities.WorkStation>();
        private List<Entities.Order> tasks = new List<Entities.Order>();
        private List<Entities.Holiday> holidays = new List<Entities.Holiday>();
        private List<Entities.CustomDay> CustomDays = new List<Entities.CustomDay>();
        BindingList<Classes.ScheduledOrder> scheduledOrderList = new BindingList<Classes.ScheduledOrder>();
        BindingList<Classes.Order> orderList = new BindingList<Classes.Order>();
        Stack<Classes.Order> removedOrderList = new Stack<Classes.Order>();

        BindingList<Entities.Order> dataSource1;
        BindingList<Order> dataSource2;
        private ScheduleUtil _util;
        private List<OrderAllocation> OrderAllocations = new List<OrderAllocation>();
        private Stack<OrderAllocation> UnsavedOrderAllocations = new Stack<OrderAllocation>();
        private Stack<OrderAllocation> UndoneOrderAllocations = new Stack<OrderAllocation>();
        private DateTime _pointedDate;
        private Item lastClickedItem;
        private DateTime lastClickTime = DateTime.MinValue;
        private ToolTip toolTip;
        private int index = 0;
        bool isDraggingOver = false;  // Indicate the drag is in progress
        ToolTip toolTip2;
        Point client;

        public Scheduler()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            calendar1.ResourceViewSettings.LaneSize = 25;
            loadContacts();
            //loadTasks();
            loadHolidays();
            loadOrders();
            LoadCustomDays();
            this.ShowInTaskbar = true;
            loadScheduledOrders();
            _util = new ScheduleUtil(holidays);
        
            calendar1.CustomDraw = CustomDrawElements.ResourceViewCell;
            
            calendar1.Draw += new EventHandler<DrawEventArgs>(this.calendar1_Draw);
            setupToolTips();
            calendar1.Schedule.UndoEnabled = true;
            redo.Enabled = false;
            undo.Enabled = false;
            calendar1.ShowToolTips = false;
            toolTip2 = new ToolTip();
            toolTip2.AutoPopDelay = 100;
            toolTip2.InitialDelay = 100;
            toolTip2.ReshowDelay = 100;
            toolTip2.ShowAlways = false;
            
            // Add resources
        }

        private void setupToolTips()
        {
            toolTip = new ToolTip();

            // Set ToolTip properties
            toolTip.AutoPopDelay = 3000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;

            // Set ToolTips for buttons
            toolTip.SetToolTip(button5, "Maximize the Schedule View");
            toolTip.SetToolTip(button1, "Create a Holiday");
            toolTip.SetToolTip(button2, "Schedule an Order");
            toolTip.SetToolTip(button3, "Create Workstation");
            toolTip.SetToolTip(button4, "Save Changes");
            toolTip.SetToolTip(redo, "Redo Changes");
            toolTip.SetToolTip(undo, "Undo Changes");
            // fullScreenBtnTT.SetToolTip(button2, "This is a tooltip for button2");
        }

        private void loadOrders()
        {
            dataGridView1.Rows.Clear();
            using (var context = new ScheduleDBContext())
            {
                var orders = context.Orders
                                        .Include(o => o.Product)
                                        .Where(o => o.Status == OrderStatus.PENDING)
                                        .Select(o => new
                                        {
                                            OrderId = o.OrderId,
                                            Title = o.OrderTitle,
                                            Description = o.OrderDescription,
                                            ProductName = o.Product.Product_Name,
                                            Customer = o.CustomerName,
                                            Qty = o.Qty,
                                            DeliveryDate = o.ExpectedDeliveryDate,
                                            Product = o.Product
                                        })
                                        .ToList();
                dataGridView1.AutoGenerateColumns = false;

                foreach (var order in orders)
                {
                    Classes.Order o = new Classes.Order();
                    o.OrderId = order.OrderId;
                    o.Customer = order.Customer;
                    o.ProductName = order.ProductName;
                    o.Qty = order.Qty;
                    o.Product = order.Product;
                    o.DeliveryDate = order.DeliveryDate;
                    o.Description = order.Description;
                    o.Title = order.Title;
                    orderList.Add(o);
                }
                dataGridView1.DataSource = orderList;

            }
        }

        private void loadScheduledOrders()
        {
            using (var context = new ScheduleDBContext())
            {
                var orders = context.Orders
                    .Include(o => o.Product)
                                        .Include(o => o.ScheduleDetails)

                                        .Where(o => o.Status == OrderStatus.SCHEDULED)
                                        .Select(o => new
                                        {
                                            OrderId = o.OrderId,
                                            Title = o.OrderTitle,
                                            ProductName = o.Product.Product_Name,
                                            Customer = o.CustomerName,
                                            Qty = o.Qty,
                                            DeliveryDate = o.ExpectedDeliveryDate,
                                            Product = o.Product,
                                            StartTime = o.ScheduleDetails.VisibleStartTime,
                                            EndTime = o.ScheduleDetails.VisibleEndTime,
                                            DurationInHours = o.ScheduleDetails.DurationInHours,
                                            Workstation = o.ScheduleDetails.WorkStation,
                                            WorkstationName = o.ScheduleDetails.WorkStation.WorkStationName
                                        })
                                        .ToList();
                dataGridView2.AutoGenerateColumns = true;

                foreach (var order in orders)
                {
                    Classes.ScheduledOrder o = new Classes.ScheduledOrder();
                    o.OrderId = order.OrderId;
                    o.Customer = order.Customer;
                    o.ProductName = order.ProductName;
                    o.Qty = order.Qty;
                    o.Product = order.Product;
                    o.DeliveryDate = order.DeliveryDate;
                    o.StartTime = order.StartTime;
                    o.EndTime = order.EndTime;
                    o.WorkStation = order.Workstation;
                    o.WorkstationName = order.WorkstationName;
                    o.DurationInHours = order.DurationInHours;
                    o.Title = order.Title;
                    scheduledOrderList.Add(o);
                }
                dataGridView2.DataSource = scheduledOrderList;
            }
        }

        private void LoadCustomDays()
        {
            using (var context = new ScheduleDBContext())
            {
                context.CustomDays.Include(c=>c.WorkStation).ToList().ForEach(d =>
                {
                    CustomDays.Add(d);
                });
            }
            calendar1.Refresh();
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
            calendar1.Refresh();
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
                    calenderMachine.Id = machine.WorkStationId.ToString();
                    calenderMachine.Name = machine.WorkStationName;
                    calendar1.Contacts.Add(calenderMachine);
                }
            }
            loadTasks();
            AddToOrdersToView();
        }

        private void loadTasks()
        {
            // MessageBox.Show("Load tasks called");

            using (var context = new ScheduleDBContext())
            {
                tasks = context.Orders.Where(o => o.Status == OrderStatus.SCHEDULED).Include(t => t.ScheduleDetails).ThenInclude(s => s.WorkStation).ToList();
                foreach (var task in tasks)
                {
                    MindFusion.Scheduling.Contact contact = calendar1.Contacts.Where(a => a.Name.Trim() == task.ScheduleDetails.WorkStation.WorkStationName.Trim()).FirstOrDefault();

                    contact.Name = task.ScheduleDetails.WorkStation.WorkStationName;
                    contact.Id = task.ScheduleDetails.WorkStationId.ToString();
                    OrderAllocation tsa = new OrderAllocation();
                    tsa.OrderTitle = task.OrderTitle;
                    tsa.HeaderText = task.OrderTitle;
                    tsa.StartTime = task.ScheduleDetails.StartTime;
                    tsa.EndTime = task.ScheduleDetails.EndTime;
                    tsa.VisibleEndTime = task.ScheduleDetails.VisibleEndTime;
                    tsa.VisibleStartTime = task.ScheduleDetails.VisibleStartTime;
                    tsa.Qty = task.Qty.ToString();
                    tsa.DurationInHours = task.ScheduleDetails.DurationInHours;
                    tsa.WorkStationName = contact.Name;
                    tsa.deliveryDate = task.ExpectedDeliveryDate;
                    tsa.Customer = task.CustomerName;
                    tsa.Id = task.OrderId.ToString();
                    tsa.Contacts.Add(contact);

                    OrderAllocations.Add(tsa);
                }
            }

        }

        private void AddToOrdersToView()
        {
            calendar1.Schedule.Items.Clear();
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
            AddTask form = new AddTask();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormClosed += (s, args) => loadOrders();
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
        }

        private void calendar1_DateClick(object sender, MindFusion.Scheduling.WinForms.ResourceDateEventArgs e)
        {

            var resource = calendar1.GetResourceAt(e.Bounds.X, e.Bounds.Y);
            if (resource != null)
            {
                var r = new WorkStation()
                {
                    WorkStationId = int.Parse(resource.Id),
                    WorkStationName = resource.Name,
                };

                SetCustomHours form = new SetCustomHours(machines, r, e.Date);
                form.FormClosed += (s, args) => LoadCustomDays();
                form.StartPosition = FormStartPosition.CenterScreen;
                form.Show();
            }
            else
            {
                MessageBox.Show("Pleas click on a valid date");
            }
        }

        private async void calendar1_ItemModified(object sender, MindFusion.Scheduling.WinForms.ItemModifiedEventArgs e)
        {
            //DialogResult result = MessageBox.Show(
            //        "Are you sure you want to modify the start time to "+e.Item.StartTime+ " and end time to " +e.Item.EndTime+" ?",  // Message
            //        "Save Modification",                            // Title
            //        MessageBoxButtons.OKCancel,                       // Buttons (Yes and No)
            //        MessageBoxIcon.Warning                         // Icon (Warning)
            //        );

            //foreach (var task in tasks)
            //{
            //    if (task.OrderTitle.ToString() == e.Item.HeaderText)
            //    {
            //        task.ScheduleDetails.StartTime = e.Item.StartTime;
            //        task.ScheduleDetails.EndTime = e.Item.EndTime;

                   
            //    }
            //}

           
            foreach(var orderAllocation in OrderAllocations)
            {
                if (orderAllocation.OrderTitle.ToString() == e.Item.HeaderText)
              {
                   orderAllocation.StartTime = e.Item.StartTime;
              orderAllocation.EndTime = e.Item.EndTime;
                    UnsavedOrderAllocations.Push(orderAllocation);
                    undo.Enabled = true;
                    MessageBox.Show(orderAllocation.EndTime.ToString());
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
            form.FormClosed += (s, args) => loadHolidays();
            
            form.Show();
        }

        private void calendar1_ItemDrawing(object sender, MindFusion.Scheduling.WinForms.DrawEventArgs e)
        {

        }

        private void calendar1_Draw(object sender, DrawEventArgs e)
        {
            DateTime cellDate = e.Date;
            Resource resource = e.Resource;
            if (e.Element == CustomDrawElements.ResourceViewCell)
            {
                // Get the current cell's date


                // Example: highlight the 10th of September 2024
                // DateTime highlightDate = new DateTime(2024, 9, 10);

                

                foreach (var day in CustomDays)
                {
                    if (cellDate.Date == day.StartTime.Date && resource.Name == day.WorkStation.WorkStationName)
                    {
                        // Fill the cell background with a custom color (e.g., yellow)
                        e.Graphics.FillRectangle(Brushes.LightBlue, e.Bounds);

                        // Optionally, draw the default border or other styles
                        //e.Graphics.DrawRectangle(Pens., e.Bounds);

                        // Mark the event as handled, so the control doesn't apply default drawing
                        e.Handled = true;
                    }
                }

                foreach (var holiday in holidays)
                {
                    if (cellDate.Date == holiday.HolidayDate)
                    {
                        // Fill the cell background with a custom color (e.g., yellow)
                        e.Graphics.FillRectangle(Brushes.LightPink, e.Bounds);

                        // Optionally, draw the default border or other styles
                        //e.Graphics.DrawRectangle(Pens., e.Bounds);

                        // Mark the event as handled, so the control doesn't apply default drawing
                        e.Handled = true;
                    }
                }


            }
            //MessageBox.Show("This is called");
            if (e.Element == CustomDrawElements.ResourceViewCell && isDraggingOver)
            {

                if (_pointedDate != DateTime.MinValue)
                {

                    DateTime cellStart = e.Date + e.StartTime;
                    DateTime cellEnd = e.Date + e.EndTime;


                    Contact contact = calendar1.GetContactAt(client);

                    if (e.Resource == contact)
                    {
                        Rectangle bounds = e.Bounds;
                        bounds.Width -= 1;
                        bounds.Height -= 1;

                        // Fill the cell
                        if (cellStart <= _pointedDate && _pointedDate < cellEnd)
                        {
                            // It is the first cell
                            e.Graphics.FillRectangle(Brushes.LightGreen, bounds);

                            // Draw lines on the left, top and right
                            bounds.Y += 1;
                            bounds.Height -= 1;
                            e.Graphics.DrawLines(Pens.Green,
                                new Point[]
                            {
                                new Point(bounds.Left, bounds.Bottom),
                                new Point(bounds.Left, bounds.Top),
                                new Point(bounds.Right, bounds.Top),
                                new Point(bounds.Right, bounds.Bottom)
                            });

                            // Draw the time interval
                            //string interval = cellStart.ToString("hh:mm tt");
                            // e.Graphics.DrawString(interval, Font, Brushes.Black,
                            //bounds.Left + 2, bounds.Top + 2);
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
                    var scheduleDetails = await context.ScheduleDetails.FirstOrDefaultAsync(s => s.OrderId == orderAllocation.OrderAllocationId);
                    
                    if(scheduleDetails is null)
                    {
                        ScheduleDetails details = new ScheduleDetails
                        {
                            OrderId = orderAllocation.OrderAllocationId,
                            StartTime = orderAllocation.StartTime,
                            EndTime = orderAllocation.EndTime,
                            VisibleStartTime = orderAllocation.VisibleStartTime,
                            VisibleEndTime = orderAllocation.VisibleEndTime,
                            DurationInHours = orderAllocation.DurationInHours,
                            WorkStationId = orderAllocation.WorkstationId
                        };

                        context.ScheduleDetails.Add(details);

                        var o = await context.Orders.FindAsync(orderAllocation.OrderAllocationId);
                        if (o != null)
                        {
                            o.Status = OrderStatus.SCHEDULED;
                            context.Orders.Update(o);
                        }

                        
                    }
                    else
                    {
                        scheduleDetails.StartTime = orderAllocation.StartTime;
                        scheduleDetails.EndTime = orderAllocation.EndTime;
                        context.ScheduleDetails.Update(scheduleDetails);
                        await context.SaveChangesAsync();
                    }

                    await context.SaveChangesAsync();
                    OrderAllocations.Add(orderAllocation);
                }

                //foreach(var task in tasks)
                //{
                //    context.Orders.Add(task);
                //    await context.SaveChangesAsync();
                //}
                
                UnsavedOrderAllocations.Clear();
                UndoneOrderAllocations.Clear();
                
                MessageBox.Show(UnsavedOrderAllocations.Count.ToString());
                undo.Enabled = false;
                redoToolStripMenuItem.Enabled = false;
                undoToolStripMenuItem.Enabled = false;
                redo.Enabled = false;
                MessageBox.Show("Changes Saved Successfully");
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
                    var dataItem = (Classes.Order)row.DataBoundItem;
                    //MessageBox.Show(dataItem.Title);
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
                Classes.Order order = (Classes.Order)e.Data.GetData(typeof(Classes.Order));

                DateTime dropDateTime = calendar1.GetDateAt(dropPoint);
                // MessageBox.Show(dropDateTime.ToString() + "   " + order.PendingOrderTitle);
                Contact contact = calendar1.GetContactAt(dropPoint);
                WorkStation workStation;

                OrderAllocation orderAllocation = new OrderAllocation();
                DateTime StartTime = new DateTime(dropDateTime.Year, dropDateTime.Month, dropDateTime.Day, 0, 0, 0);
                orderAllocation.StartTime = StartTime;
                orderAllocation.OrderTitle = order.Title;
                orderAllocation.HeaderText = order.Title;

                //orderAllocation.EndTime = task.EndTime;
                orderAllocation.Id = order.Title.ToString();
                orderAllocation.OrderAllocationId = order.OrderId;
                orderAllocation.Contacts.Add(contact);

                using (var context = new ScheduleDBContext())
                {
                    try
                    {
                        workStation = await context.WorkStations.Where(w => w.WorkStationName == contact.Name).FirstOrDefaultAsync();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No Date Selected");
                        return;
                    }


                }

                var capacity = decimal.Parse(order.Product.CapacityInHour.ToString());
                decimal durationInMinutes = (decimal.Parse(order.Qty.ToString()) / capacity);

                double days =  _util.CalculateDays(StartTime,double.Parse(durationInMinutes.ToString()),contact,CustomDays);
                //MessageBox.Show("Days: "+days);
                DateTime endTime = _util.CalculateEndDateConsideringHolidays(StartTime,decimal.Parse(days.ToString()));
                //MessageBox.Show("End time: " + endTime);
                

                DateTime visibleStartDateTime = _util.MapToVisibleRange(CustomDays, StartTime,contact);
                DateTime visibleEndDateTime = _util.MapToVisibleRange(CustomDays, endTime,contact);

                orderAllocation.EndTime = endTime;
                orderAllocation.VisibleStartTime = visibleStartDateTime;
                orderAllocation.VisibleEndTime = visibleEndDateTime;
                orderAllocation.Qty = order.Qty.ToString();
                orderAllocation.OrderDescription = order.Description;
                orderAllocation.DurationInHours = double.Parse(durationInMinutes.ToString());
                orderAllocation.WorkstationId = workStation.WorkStationId;
                orderAllocation.Customer = order.Customer;
                orderAllocation.WorkStationName = workStation.WorkStationName;
                orderAllocation.deliveryDate = order.DeliveryDate;
                calendar1.Schedule.Items.Add(orderAllocation);
                UnsavedOrderAllocations.Push(orderAllocation);
                AddToOrdersToView();
                undo.Enabled = true;
                undoToolStripMenuItem.Enabled = true;
               int rowIndex =  dataGridView1.CurrentRow.Index;
                RemoveRow(rowIndex);
                index++;
                var addItemCommand = new AddItemCommand(calendar1.Schedule, orderAllocation, index);

                // Execute the command
                calendar1.Schedule.ExecuteCommand(addItemCommand);
                isDraggingOver = false;
                calendar1.Invalidate();

            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

      

        private void calendar1_DragOver(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(typeof(Classes.Order)))
            {
                client = calendar1.PointToClient(new Point(e.X, e.Y));

                _pointedDate = calendar1.GetDateAt(client);
                isDraggingOver = true;  // Indicate the drag is in progress

                e.Effect = DragDropEffects.Move;
                calendar1.Invalidate();
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }



        private void calendar1_ItemSelecting(object sender, ItemConfirmEventArgs e)
        {
            var orderItem = e.Item as OrderAllocation;

            OrderAllocation orderAllocation = (OrderAllocation)e.Item;
            label9.Text = orderAllocation.OrderTitle;
            label8.Text = orderAllocation.Qty;
            label7.Text = orderAllocation.Customer;
            label10.Text = orderAllocation.WorkStationName;
            label16.Text = orderAllocation.DurationInHours.ToString();
            DateOnly date1 = new DateOnly(orderAllocation.deliveryDate.Year, orderAllocation.deliveryDate.Month, orderAllocation.deliveryDate.Day);
            DateOnly date2 = new DateOnly(orderAllocation.VisibleStartTime.Year, orderAllocation.VisibleStartTime.Month, orderAllocation.VisibleStartTime.Day);
            DateOnly date3 = new DateOnly(orderAllocation.VisibleEndTime.Year, orderAllocation.VisibleEndTime.Month, orderAllocation.VisibleEndTime.Day);
            TimeOnly endTime = new TimeOnly(orderAllocation.VisibleEndTime.Hour, orderAllocation.VisibleEndTime.Minute);
            label6.Text = date1.ToString();
            label12.Text = date2.ToString();
            label14.Text = date3.ToString();
            label18.Text = endTime.ToString();
        }



        private void calendar1_ItemClick(object sender, ItemMouseEventArgs e)
        {
            var currentTime = DateTime.Now;
            var timeSinceLastClick = (currentTime - lastClickTime).TotalMilliseconds;

            // If the time between two clicks is within 500 ms, it's considered a double-click
            if (timeSinceLastClick <= 500 && lastClickedItem == e.Item)
            {
                // This is a double-click, enable dragging
                calendar1.AllowDrag = true;
            }
            else
            {
                // This is a single click, disable dragging
                calendar1.AllowDrag = false;
            }
        }

        bool isCollapsed = false;
        private void button5_Click(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                isCollapsed = false;
                splitContainer1.Panel2Collapsed = false;
                button5.BackColor = Color.DodgerBlue;
                button5.Image = Properties.Resources.icons8_full_screen_24;
                button5.FlatStyle = FlatStyle.Flat;
                button5.FlatAppearance.BorderSize = 0;
                toolTip.SetToolTip(button5, "Maximize the Schedule View");

            }
            else
            {
                isCollapsed = true;
                splitContainer1.Panel2Collapsed = true;
                button5.FlatStyle = FlatStyle.Flat;
                button5.FlatAppearance.BorderSize = 0;
                button5.BackColor = Color.MediumSeaGreen;
                toolTip.SetToolTip(button5, "View the Order List");

                button5.Image = Properties.Resources.icons8_exit_full_screen_25__1_;

            }
        }

        private void undo_Click(object sender, EventArgs e)
        {


            OrderAllocation orderAllocation = null;
            if (UnsavedOrderAllocations.Count > 0)
            {
                orderAllocation = UnsavedOrderAllocations.Pop();
            }
            else
            {
                //redo.Enabled = false;
            }

            if (orderAllocation != null)
            {
                UndoneOrderAllocations.Push(orderAllocation);
                redo.Enabled = true;
                redoToolStripMenuItem.Enabled = true;
                UndoRemoveRow();
                if (UnsavedOrderAllocations.Count == 0)
                {
                    undo.Enabled = false;
                    undoToolStripMenuItem.Enabled = false;
                }
            }

            AddToOrdersToView();
            calendar1.Invalidate();
            calendar1.Update();
        }

        private void redo_Click(object sender, EventArgs e)
        {
            OrderAllocation orderAllocation = null;
            if (UndoneOrderAllocations.Count > 0)
            {
                orderAllocation = UndoneOrderAllocations.Pop();
                //button6.Enabled = false;
            }
            else
            {
                //redo.Enabled = false;
            }

            if (orderAllocation != null)
            {
                UnsavedOrderAllocations.Push(orderAllocation);
                undo.Enabled = true;
                undoToolStripMenuItem.Enabled = true;
                RemoveRow();
                if (UndoneOrderAllocations.Count == 0)
                {
                    redo.Enabled = false;
                    redoToolStripMenuItem.Enabled = false;
                }
            }

            AddToOrdersToView();
        }

        private void calendar1_ItemTooltipDisplaying(object sender, ItemTooltipEventArgs e)
        {

            if (e.Item != null)
            {
                OrderAllocation item = (OrderAllocation)e.Item;

                string tooltipString = $"Title: {item.OrderTitle}\n" +
                              $"Start Time: {item.VisibleStartTime}\n" +
                              $"End Time: {item.VisibleEndTime}\n" +
                              $"Description: {item.OrderDescription}\n" +
                              $"Workstation: {item.WorkStationName}\n" +
                 $"Customer: {item.Customer}\n" +
                 $"Duration In Hours: {item.DurationInHours}\n" +
                   $"Qty: {item.Qty}\n" +
                     $"Delivery Date: {item.deliveryDate}\n";
                toolTip2.SetToolTip(calendar1, tooltipString);
            }
            else
            {

            }

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void createOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTask form = new AddTask();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormClosed += (s, args) => loadOrders();
            form.Show();
        }

        private void removeOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void createWorkstationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var context = new ScheduleDBContext())
            {
                var form = new AddContact(context);
                form.StartPosition = FormStartPosition.CenterScreen;
                form.FormClosed += (s, args) => loadContacts();

                form.Show();
            }
        }

        private void createHolidayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AddHoliday();
            form.StartPosition = FormStartPosition.CenterScreen;

            form.Show();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {


            OrderAllocation orderAllocation = null;
            if (UnsavedOrderAllocations.Count > 0)
            {
                orderAllocation = UnsavedOrderAllocations.Pop();
            }
            else
            {
                //redo.Enabled = false;
            }

            if (orderAllocation != null)
            {
                UndoneOrderAllocations.Push(orderAllocation);
                redo.Enabled = true;
                redoToolStripMenuItem.Enabled = true;
                UndoRemoveRow();
                if (UnsavedOrderAllocations.Count == 0)
                {
                    undo.Enabled = false;
                    undoToolStripMenuItem.Enabled = false;
                }
            }

            AddToOrdersToView();
            calendar1.Invalidate();
            calendar1.Update();

            //OrderAllocation orderAllocation = null;
            //if (UnsavedOrderAllocations.Count > 0)
            //{
            //    orderAllocation = UnsavedOrderAllocations.Pop();
            //}
            //else
            //{
            //    //redo.Enabled = false;
            //}

            //if (orderAllocation != null)
            //{
            //    UndoneOrderAllocations.Push(orderAllocation);
            //    redo.Enabled = true;
            //    if (UnsavedOrderAllocations.Count == 0)
            //    {
            //        undo.Enabled = false;
            //    }
            //}

            //AddToOrdersToView();
            //calendar1.Invalidate();
            //calendar1.Update();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OrderAllocation orderAllocation = null;
            if (UndoneOrderAllocations.Count > 0)
            {
                orderAllocation = UndoneOrderAllocations.Pop();
                //button6.Enabled = false;
            }
            else
            {
                //redo.Enabled = false;
            }

            if (orderAllocation != null)
            {
                UnsavedOrderAllocations.Push(orderAllocation);
                undo.Enabled = true;
                undoToolStripMenuItem.Enabled = true;
                RemoveRow();
                if (UndoneOrderAllocations.Count == 0)
                {
                    redo.Enabled = false;
                    redoToolStripMenuItem.Enabled = false;
                }
            }

            AddToOrdersToView();
            //OrderAllocation orderAllocation = null;
            //if (UndoneOrderAllocations.Count > 0)
            //{
            //    orderAllocation = UndoneOrderAllocations.Pop();
            //    //button6.Enabled = false;
            //}
            //else
            //{
            //    //redo.Enabled = false;
            //}

            //if (orderAllocation != null)
            //{
            //    UnsavedOrderAllocations.Push(orderAllocation);
            //    undo.Enabled = true;
            //    undoToolStripMenuItem.Enabled = true;
            //    RemoveRow();
            //    if (UndoneOrderAllocations.Count == 0)
            //    {
            //        redo.Enabled = false;
            //    }
            //}

            //AddToOrdersToView();
        }


        private void RemoveRow(int rowIndex)
        {
            if (rowIndex >= 0 && rowIndex < dataGridView1.Rows.Count)
            {
                // Store the row in the stack before removing it
                var cellValue = dataGridView1.Rows[rowIndex].Cells[0].Value;

                //removedRows.Push(row);
       
                foreach(var order in orderList)
                {
                    if(order.Title == cellValue)
                    {
                        orderList.Remove(order);
                        removedOrderList.Push(order);
                        break;
                    }
                }
                dataGridView1.DataSource = orderList;
                // Remove the row
                //dataGridView1.Rows.RemoveAt(rowIndex);
            }
        }

        private void RemoveRow()
        {
            if (orderList.Count > 0)
            {
                Classes.Order order = orderList.LastOrDefault();
                if (order != null)
                {
                    removedOrderList.Push(order);
                    orderList.Remove(order);
                    dataGridView1.DataSource = orderList;
                }

            }
        }


        private void UndoRemoveRow()
        {
            if (removedOrderList.Count > 0)
            {
                Classes.Order order = removedOrderList.Pop();
                if(order != null)
                {
                    orderList.Add(order);
                    dataGridView1.DataSource = orderList;
                }

            }
        }

    }
}
