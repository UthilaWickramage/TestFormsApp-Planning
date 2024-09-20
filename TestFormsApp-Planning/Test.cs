using System;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
using log4net;
using log4net.Config;
using log4net.Repository.Hierarchy;
using Microsoft.EntityFrameworkCore;
using MindFusion.Drawing;
using MindFusion.Excel;
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


        BindingList<Classes.Operation> uniqueOrderList = new BindingList<Classes.Operation>();
        BindingList<Classes.Operation> uniqueScheduledOrderList = new BindingList<Classes.Operation>();
        List<Classes.Operation> scheduledOrderList = new List<Classes.Operation>();
        List<Classes.Operation> orderList = new List<Classes.Operation>();

        private List<OrderAllocation> OrderAllocations = new List<OrderAllocation>();
        private List<OrderAllocation> NewOrderAllocations = new List<OrderAllocation>();



        Stack<Classes.Operation> removedOrderList = new Stack<Classes.Operation>();
        private static readonly ILog logger = LogManager.GetLogger(typeof(Scheduler));
        private ScheduleUtil _util;

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
        private DataGridViewRow _dataGridView1clickedRow;
        private DataGridViewRow _dataGridView2clickedRow;

        public Scheduler()
        {
            InitializeComponent();
            XmlConfigurator.Configure(new System.IO.FileInfo("log4net.config"));

            logger.Info("Application started.");
            this.StartPosition = FormStartPosition.CenterScreen;
          
            loadContacts();
            loadHolidays();
            loadOrders();
            LoadCustomDays();
            this.ShowInTaskbar = true;
            //loadScheduledOrders();
            _util = new ScheduleUtil(holidays);

            calendar1.CustomDraw = CustomDrawElements.ResourceViewCell;

            calendar1.Draw += new EventHandler<DrawEventArgs>(this.calendar1_Draw);
            setupToolTips();
            calendar1.Schedule.UndoEnabled = true;
            redo.Enabled = false;
            undo.Enabled = false;
            calendar1.ShowToolTips = true;


            // Add resources
        }

        private void setupToolTips()
        {
            toolTip2 = new ToolTip();
            toolTip2.AutoPopDelay = 100;
            toolTip2.InitialDelay = 100;
            toolTip2.ReshowDelay = 100;
            toolTip2.ShowAlways = false;
            toolTip = new ToolTip();

            // Set ToolTip properties
            toolTip.AutoPopDelay = 3000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;

            // Set ToolTips for buttons
            toolTip.SetToolTip(button5, "Maximize the Schedule View");
            toolTip.SetToolTip(button1, "Create a Holiday");
            toolTip.SetToolTip(button2, "Schedule an Operation");
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
                var orders = context.Orders.Include(o => o.Product).ThenInclude(p => p.OutputRates).ToList();

                dataGridView1.AutoGenerateColumns = false;

                foreach (var order in orders)
                {
                    foreach (var output_rates in order.Product.OutputRates)
                    {
                        var workstation = context.WorkStations.Find(output_rates.WorkstationId);
                        var operation_type = context.OperationTypes.Find(output_rates.OperationTypeId);
                        Classes.Operation o = new Classes.Operation();
                        o.OperationId = output_rates.Output_Rate_Id;
                        o.Customer = order.CustomerName;
                        o.ProductName = order.Product.Product_Name;
                        o.Qty = order.Qty;
                        o.OperationType = operation_type.Operation_Type_Name;
                        o.DeliveryDate = order.ExpectedDeliveryDate;
                        o.OrderNo = order.OrderNo;
                        o.Capacity = output_rates.Rate;
                        o.Product = order.Product;
                        o.WorkStation = workstation;
                        o.Order = order;
                        o.Operation_Type = operation_type;

                        var r = context.ScheduleDetails.Where(s => s.OrderId == order.OrderId && s.OperationTypeId == operation_type.Operation_Type_Id).ToList();

                        if (r.Count == 0)
                        {
                            orderList.Add(o);

                        }
                        else
                        {
                            //we consider list here because we might need to implement the split order functionality
                            List<ScheduledOperationDetails> sod = new List<ScheduledOperationDetails>();
                            foreach (var item in r)
                            {
                                ScheduledOperationDetails s = new ScheduledOperationDetails()
                                {
                                    ScheduledOperationDetailsId = item.ScheduleDetailsId,
                                    DurationInHours = item.DurationInHours,
                                    StartTime = item.StartTime,
                                    EndTime = item.EndTime,
                                    VisibleEndTime = item.VisibleEndTime,
                                    VisibleStartTime = item.VisibleStartTime,
                                    Qty = item.Qty,
                                };
                                sod.Add(s);
                            }
                            o.ScheduledOperationDetails = sod;
                            scheduledOrderList.Add(o);
                        }
                    }

                }

                foreach (var order in orderList)
                {

                    // Check if an entry with the same ProductId and OperationTypeId exists
                    if (!uniqueOrderList.Any(o => o.Product.Product_Id == order.Product.Product_Id &&
                                                  o.Operation_Type.Operation_Type_Id == order.Operation_Type.Operation_Type_Id

                                                  ))
                    {
                        uniqueOrderList.Add(order);
                    }
                }

                foreach (var order in scheduledOrderList)
                {

                    // Check if an entry with the same ProductId and OperationTypeId exists
                    if (!uniqueScheduledOrderList.Any(o => o.Product.Product_Id == order.Product.Product_Id &&
                                                  o.Operation_Type.Operation_Type_Id == order.Operation_Type.Operation_Type_Id

                                                  ))
                    {
                        uniqueScheduledOrderList.Add(order);
                    }
                }
                dataGridView1.DataSource = uniqueOrderList;
                dataGridView2.DataSource = uniqueScheduledOrderList;

            }
        }




        private void LoadCustomDays()
        {
            using (var context = new ScheduleDBContext())
            {
                context.CustomDays.Include(c => c.WorkStation).ToList().ForEach(d =>
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
            //AddToOrdersToView();
        }

        private void loadTasks()
        {
            using (var context = new ScheduleDBContext())
            {
                var scheduledOperations = context.ScheduleDetails.ToList();
                foreach (var scheduledOperation in scheduledOperations)
                {
                    var or = context.Orders.Include(o=>o.Product).Where(o=>o.OrderId == scheduledOperation.OrderId).FirstOrDefault();
                    var ws = context.WorkStations.Find(scheduledOperation.WorkStationId);
                    var ot = context.OperationTypes.Find(scheduledOperation.OperationTypeId);
                    MindFusion.Scheduling.Contact contact = calendar1.Contacts.Where(a => a.Name.Trim() == ws.WorkStationName.Trim()).FirstOrDefault();

                    contact.Name = ws.WorkStationName;
                    contact.Id = ws.WorkStationId.ToString();
                    OrderAllocation tsa = new OrderAllocation();
                    tsa.OrderAllocationId = scheduledOperation.OrderId;
                    tsa.OrderTitle = or.OrderNo;
                    tsa.HeaderText = or.OrderNo;
                    tsa.StartTime = scheduledOperation.StartTime;
                    tsa.EndTime = scheduledOperation.EndTime;
                    tsa.VisibleEndTime = scheduledOperation.VisibleEndTime;
                    tsa.VisibleStartTime = scheduledOperation.VisibleStartTime;
                    tsa.Qty = scheduledOperation.Qty.ToString();
                    tsa.DurationInHours = scheduledOperation.DurationInHours;
                    tsa.deliveryDate = or.ExpectedDeliveryDate;
                    tsa.Customer = or.CustomerName;
                    tsa.Operation_Type = scheduledOperation.OperationType;
                    tsa.ProductName = or.Product.Product_Name;
                    tsa.Id = scheduledOperation.ScheduleDetailsId.ToString();
                    tsa.Contacts.Add(contact);
                    tsa.Style.FillColor = System.Drawing.Color.Red;
                    tsa.Style.LineColor = System.Drawing.Color.Red;
                  
                    calendar1.Schedule.Items.Add(tsa);
                }
            }

        }

        //private void AddToOrdersToView()
        //{
        //    calendar1.Schedule.Items.Clear();
        //    foreach (var orderAllocation in OrderAllocations)
        //    {
        //        calendar1.Schedule.Items.Add(orderAllocation);
        //    }
        //    foreach (var orderAllocation in UnsavedOrderAllocations)
        //    {
        //        calendar1.Schedule.Items.Add(orderAllocation);
        //    }
        //}

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
                MessageBox.Show("Please click on a valid date");
            }
        }

        private async void calendar1_ItemModified(object sender, MindFusion.Scheduling.WinForms.ItemModifiedEventArgs e)
        {

            MessageBox.Show(e.Item.StartTime.ToString());
            MessageBox.Show(e.Item.Contacts.FirstOrDefault().Name);
            bool isFoundOrder = false;
            OrderAllocation modifiedOrderAllocation = null;
            foreach (var orderAllocation in OrderAllocations)
            {
                if (orderAllocation.Id.ToString() == e.Item.Id)
                {
                    modifiedOrderAllocation = orderAllocation;
                    OrderAllocations.Remove(orderAllocation);
                    isFoundOrder = true;
                    break;
                }
            }

            if (!isFoundOrder)
            {
                foreach (var orderAllocation in NewOrderAllocations)
                {
                    if (orderAllocation.Id.ToString() == e.Item.Id)
                    {
                        modifiedOrderAllocation = orderAllocation;
                        NewOrderAllocations.Remove(orderAllocation);
                        isFoundOrder = true;
                        break;
                    }
                }
            }

            if (modifiedOrderAllocation != null)
            {
                MessageBox.Show(modifiedOrderAllocation.Qty);
                double days = _util.CalculateDays(e.Item.StartTime, double.Parse(modifiedOrderAllocation.DurationInHours.ToString()), e.Item.Contacts.FirstOrDefault(), CustomDays);
                DateTime endTime = _util.CalculateEndDateConsideringHolidays(e.Item.StartTime, decimal.Parse(days.ToString()));
                DateTime visibleStartDateTime = _util.MapToVisibleRange(CustomDays, e.Item.StartTime, e.Item.Contacts.FirstOrDefault());
                DateTime visibleEndDateTime = _util.MapToVisibleRange(CustomDays, endTime, e.Item.Contacts.FirstOrDefault());

                modifiedOrderAllocation.StartTime = e.Item.StartTime;
                modifiedOrderAllocation.EndTime = endTime;
                modifiedOrderAllocation.VisibleStartTime = visibleStartDateTime;
                modifiedOrderAllocation.VisibleEndTime = visibleEndDateTime;

                if (isFoundOrder)
                {
                    NewOrderAllocations.Add(modifiedOrderAllocation);
                }
                else
                {
                    OrderAllocations.Add(modifiedOrderAllocation);

                }
                UnsavedOrderAllocations.Push(modifiedOrderAllocation);
                undo.Enabled = true;
                toolStripMenuItem2.Enabled = true;
                //AddToOrdersToView();

            }

        }

        private async void calendar1_DragDrop(object sender, DragEventArgs e)
        {
            Point dropPoint = calendar1.PointToClient(new Point(e.X, e.Y));
            try
            {
                Classes.Operation order = (Classes.Operation)e.Data.GetData(typeof(Classes.Operation));

                DateTime dropDateTime = calendar1.GetDateAt(dropPoint);
                Contact contact = calendar1.GetContactAt(dropPoint);

                var result = orderList
                .Where(o => o.Product.Product_Id == order.Product.Product_Id && o.Operation_Type.Operation_Type_Id == order.Operation_Type.Operation_Type_Id);

                var r = result.Where(r => r.WorkStation.WorkStationId.ToString() == contact.Id).FirstOrDefault();

                if (r == null)
                {
                    MessageBox.Show("Invalid Workstation");
                    return;
                }

                var c = orderList.Where(o => o.Product.Product_Id == order.Product.Product_Id && o.Operation_Type.Operation_Type_Id == order.Operation_Type.Operation_Type_Id && o.WorkStation.WorkStationId.ToString() == contact.Id).FirstOrDefault();

                OrderAllocation orderAllocation = new OrderAllocation();
                DateTime StartTime = new DateTime(dropDateTime.Year, dropDateTime.Month, dropDateTime.Day, 0, 0, 0);
                orderAllocation.StartTime = StartTime;
                orderAllocation.OrderTitle = order.OrderNo;
                orderAllocation.HeaderText = order.OrderNo;


                //orderAllocation.Id = order.Order.ToString();
                //orderAllocation.OrderAllocationId = order.OrderNo;
                orderAllocation.Contacts.Add(contact);


                var capacity = decimal.Parse(c.Capacity.ToString());
                decimal durationInHours = (decimal.Parse(order.Qty.ToString()) / capacity);

                double days = _util.CalculateDays(StartTime, double.Parse(durationInHours.ToString()), contact, CustomDays);
                DateTime endTime = _util.CalculateEndDateConsideringHolidays(StartTime, decimal.Parse(days.ToString()));

                DateTime visibleStartDateTime = _util.MapToVisibleRange(CustomDays, StartTime, contact);
                DateTime visibleEndDateTime = _util.MapToVisibleRange(CustomDays, endTime, contact);

                orderAllocation.EndTime = endTime;
                orderAllocation.VisibleStartTime = visibleStartDateTime;
                orderAllocation.VisibleEndTime = visibleEndDateTime;
                orderAllocation.Qty = order.Qty.ToString();
                orderAllocation.DurationInHours = double.Parse(durationInHours.ToString());
                orderAllocation.Customer = order.Customer;
                orderAllocation.deliveryDate = order.DeliveryDate;
                orderAllocation.Contact = contact;
                orderAllocation.Operation_Type = order.Operation_Type;
                orderAllocation.WorkStation = order.WorkStation;
                orderAllocation.Order = order.Order;
                orderAllocation.Style.FillColor = System.Drawing.Color.Red;
                orderAllocation.Style.LineColor = System.Drawing.Color.Red;
                calendar1.Schedule.Items.Add(orderAllocation);
                calendar1.Invalidate();
                undo.Enabled = true;
                undoToolStripMenuItem.Enabled = true;
                int rowIndex = dataGridView1.CurrentRow.Index;
                RemoveRow(rowIndex);
                isDraggingOver = false;
                calendar1.Invalidate();

            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.ToString());
            }


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
                foreach (OrderAllocation oa in calendar1.Schedule.Items)
                {
                    var scheduleDetails = await context.ScheduleDetails.FirstOrDefaultAsync(s => s.OrderId == oa.OrderAllocationId);

                    if (scheduleDetails is null)
                    {
                        ScheduleDetails details = new ScheduleDetails
                        {

                            StartTime = oa.StartTime,
                            EndTime = oa.EndTime,
                            VisibleStartTime = oa.VisibleStartTime,
                            VisibleEndTime = oa.VisibleEndTime,
                            DurationInHours = oa.DurationInHours,
                            WorkStationId = oa.WorkStation.WorkStationId,
                            OperationTypeId = oa.Operation_Type.Operation_Type_Id,
                            OrderId = oa.Order.OrderId,

                            Qty = double.Parse(oa.Qty),


                        };

                        context.ScheduleDetails.Add(details);

                        var o = await context.Orders.FindAsync(oa.OrderAllocationId);
                        if (o != null)
                        {
                            o.Status = OrderStatus.SCHEDULED;
                            context.Orders.Update(o);
                        }


                    }
                    else
                    {
                        scheduleDetails.StartTime = oa.StartTime;
                        scheduleDetails.EndTime = oa.EndTime;
                        context.ScheduleDetails.Update(scheduleDetails);
                        await context.SaveChangesAsync();
                    }
                }

                await context.SaveChangesAsync();

            }
            undo.Enabled = false;
            redoToolStripMenuItem.Enabled = false;
            undoToolStripMenuItem.Enabled = false;
            redo.Enabled = false;
            MessageBox.Show("Changes Saved Successfully");
        }


        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1 && e.Button == MouseButtons.Left)
            {
                var hitTest = dataGridView1.HitTest(e.X, e.Y);
                if (hitTest.RowIndex >= 0)
                {
                    var row = dataGridView1.Rows[hitTest.RowIndex];
                    var dataItem = (Classes.Operation)row.DataBoundItem;
                    //MessageBox.Show(dataItem.Title);
                    if (dataItem != null)
                    {
                        calendar1.DoDragDrop(dataItem, DragDropEffects.Move);
                    }
                }
            }

            if (e.Button == MouseButtons.Right)
            {
                // Use HitTest to determine where the click occurred
                var hit = dataGridView1.HitTest(e.X, e.Y);

                // Check if the click is on a valid row
                if (hit.RowIndex >= 0)
                {
                    // Store the clicked row for use in the context menu item click event
                    _dataGridView1clickedRow = dataGridView1.Rows[hit.RowIndex];

                    // Optionally select the clicked row
                    dataGridView1.ClearSelection();
                    _dataGridView1clickedRow.Selected = true;

                    // Show the context menu at the mouse position
                    contextMenuStrip1.Show(dataGridView1, e.Location);
                }
            }



        }

        private void calendar1_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Classes.Operation)))
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
            ////label10.Text = orderAllocation.WorkStationName;
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

            if (timeSinceLastClick <= 500 && lastClickedItem == e.Item)
            {
                calendar1.AllowDrag = true;
            }
            else
            {
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
                button5.BackColor = System.Drawing.Color.DodgerBlue;
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
                button5.BackColor = System.Drawing.Color.MediumSeaGreen;
                toolTip.SetToolTip(button5, "View the Operation List");

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

            //AddToOrdersToView();
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

            // AddToOrdersToView();
        }

        private void calendar1_ItemTooltipDisplaying(object sender, ItemTooltipEventArgs e)
        {

          
                OrderAllocation item = (OrderAllocation)e.Item;

                string t = $"Order No: {item.OrderTitle}\n" +
                       $"Customer: {item.Customer}\n" +
                          $"Product: {item.ProductName}\n" +
                           $"Delivery Date: {new DateOnly(item.deliveryDate.Year,item.deliveryDate.Month,item.deliveryDate.Day)}\n" +
                        
                           "--------------------------------\n" +
                        
                            $"Operation Type: {item.Operation_Type.Operation_Type_Name}\n" +
                 $"Duration: {item.DurationInHours}\n" +
                   $"Qty: {item.Qty}\n" +
                    $"Start Time: {item.VisibleStartTime}\n" +
                              $"End Time: {item.VisibleEndTime}\n";

                e.Tooltip = t;
           
           

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

            //AddToOrdersToView();
            calendar1.Invalidate();
            calendar1.Update();


        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OrderAllocation orderAllocation = null;
            if (UndoneOrderAllocations.Count > 0)
            {
                orderAllocation = UndoneOrderAllocations.Pop();
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

            //AddToOrdersToView();

        }


        private void RemoveRow(int rowIndex)
        {
            if (rowIndex >= 0 && rowIndex < dataGridView1.Rows.Count)
            {
                // Store the row in the stack before removing it
                var cellValue = dataGridView1.Rows[rowIndex].Cells[0].Value;

                //removedRows.Push(row);

                //foreach(var order in uniqueOrderList)
                //{
                //    if(order.Title == cellValue)
                //    {
                //        uniqueOrderList.Remove(order);
                //        removedOrderList.Push(order);
                //        break;
                //    }
                //}
                //dataGridView1.DataSource = uniqueOrderList;

            }
        }

        private void RemoveRow()
        {
            if (uniqueOrderList.Count > 0)
            {
                Classes.Operation order = uniqueOrderList.LastOrDefault();
                if (order != null)
                {
                    removedOrderList.Push(order);
                    uniqueOrderList.Remove(order);
                    dataGridView1.DataSource = uniqueOrderList;
                }

            }
        }


        private void UndoRemoveRow()
        {
            if (removedOrderList.Count > 0)
            {
                Classes.Operation order = removedOrderList.Pop();
                if (order != null)
                {
                    uniqueOrderList.Add(order);
                    dataGridView1.DataSource = uniqueOrderList;
                }

            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (_dataGridView1clickedRow != null)
            {

                string orderNo = _dataGridView1clickedRow.Cells[0].Value.ToString();
                FullOrder fullOrder = new FullOrder(uniqueOrderList, uniqueScheduledOrderList, machines,orderNo);
                fullOrder.Text = "Order No :" + orderNo;
        

                _dataGridView1clickedRow = null;
                fullOrder.Show();

            }
            else if (_dataGridView2clickedRow != null)
            {

                string orderNo = _dataGridView2clickedRow.Cells[0].Value.ToString();
         
                FullOrder fullOrder = new FullOrder(uniqueOrderList, uniqueScheduledOrderList, machines, orderNo);
                fullOrder.Text = "Order No :" + orderNo;
                _dataGridView2clickedRow = null;
                fullOrder.Show();

            }
        }


     
        private void dataGridView2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Use HitTest to determine where the click occurred
                var hit = dataGridView2.HitTest(e.X, e.Y);

                // Check if the click is on a valid row
                if (hit.RowIndex >= 0)
                {
                    // Store the clicked row for use in the context menu item click event
                    _dataGridView2clickedRow = dataGridView2.Rows[hit.RowIndex];

                    // Optionally select the clicked row
                    dataGridView2.ClearSelection();
                    _dataGridView2clickedRow.Selected = true;

                    // Show the context menu at the mouse position
                    contextMenuStrip1.Show(dataGridView2, e.Location);
                }
            }
        }
    }
}
