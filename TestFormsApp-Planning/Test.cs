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
using optMainTheme;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools.Win32API;
using TestFormsApp_Planning.Classes;
using TestFormsApp_Planning.Helpers;
using Order = Entities.Order;

namespace TestFormsApp_Planning
{
    public partial class Scheduler : Form
    {
        private List<Entities.WorkStation> machines = new List<Entities.WorkStation>();
        private List<Entities.Holiday> holidays = new List<Entities.Holiday>();
        private List<Entities.CustomDay> CustomDays = new List<Entities.CustomDay>();


        BindingList<Classes.Operation> uniqueOrderList = new BindingList<Classes.Operation>();
        BindingList<Classes.Operation> uniqueScheduledOrderList = new BindingList<Classes.Operation>();
        List<Classes.Operation> scheduledOrderList = new List<Classes.Operation>();
        List<Classes.Operation> orderList = new List<Classes.Operation>();




        Stack<Classes.Operation> removedOrderList = new Stack<Classes.Operation>();
        private static readonly ILog logger = LogManager.GetLogger(typeof(Scheduler));
        private ScheduleUtil _util;

        private Stack<OrderAllocation> UnsavedOrderAllocations = new Stack<OrderAllocation>();
        private Stack<OrderAllocation> UndoneOrderAllocations = new Stack<OrderAllocation>();
        private DateTime _pointedDate;
        private Item lastClickedItem;
        private DateTime lastClickTime = DateTime.MinValue;
        private ToolTip toolTip;
        bool isDraggingOver = false;  // Indicate the drag is in progress
        ToolTip toolTip2;
        Point client;
        DateTime SplitHereClickedDateTime;
        OrderAllocation SplitHereSelectedItem;
        private DataGridViewRow _dataGridView1clickedRow;
        private DataGridViewRow _dataGridView2clickedRow;

        public Scheduler()
        {
            InitializeComponent();

            XmlConfigurator.Configure(new System.IO.FileInfo("log4net.config"));
            optMainTheme.optMainTheme mt = new optMainTheme.optMainTheme();
            calendar1.ApplyTheme(mt);

            logger.Info("Application started.");
            this.StartPosition = FormStartPosition.CenterScreen;
            dataGridView1.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DodgerBlue;   // Row selection background color
            dataGridView1.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridView2.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DodgerBlue;   // Row selection background color
            dataGridView2.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
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
            this.WindowState = FormWindowState.Maximized; // Maximize window

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
                Console.WriteLine(orders.Count);
                Console.WriteLine(orders);
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
                                                  o.Operation_Type.Operation_Type_Id == order.Operation_Type.Operation_Type_Id &&
                                                  o.WorkStation.WorkStationId == order.WorkStation.WorkStationId

                                                  ))
                    {
                        uniqueOrderList.Add(order);
                    }
                }

                foreach (var order in scheduledOrderList)
                {

                    // Check if an entry with the same ProductId and OperationTypeId exists
                    if (!uniqueScheduledOrderList.Any(o => o.Product.Product_Id == order.Product.Product_Id &&
                                                  o.Operation_Type.Operation_Type_Id == order.Operation_Type.Operation_Type_Id &&
                                                  o.WorkStation.WorkStationId == order.WorkStation.WorkStationId

                                                  ))
                    {
                        uniqueScheduledOrderList.Add(order);
                    }
                }

                loadDataToDataGridView1();
                loadDataToDataGridView2();
               

            }
        }

        private void loadDataToDataGridView1()
        {

            dataGridView1.DataSource = uniqueOrderList;

          
        }

        private void loadDataToDataGridView2()
        {
            dataGridView2.DataSource = uniqueScheduledOrderList;
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
                    var or = context.Orders.Include(o => o.Product).Where(o => o.OrderId == scheduledOperation.OrderId).FirstOrDefault();
                    var ws = context.WorkStations.Find(scheduledOperation.WorkStationId);
                    var ot = context.OperationTypes.Find(scheduledOperation.OperationTypeId);
                    var outputRateRecord = context.OutputRates.Where(o => o.WorkstationId == ws.WorkStationId && o.OperationTypeId == ot.Operation_Type_Id && o.ProductId == or.ProductId).FirstOrDefault();
                    MindFusion.Scheduling.Contact contact = calendar1.Contacts.Where(a => a.Name.Trim() == ws.WorkStationName.Trim()).FirstOrDefault();

                    contact.Name = ws.WorkStationName;
                    contact.Id = ws.WorkStationId.ToString();
                    OrderAllocation tsa = new OrderAllocation();
                    tsa.OrderAllocationId = scheduledOperation.ScheduleDetailsId;
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
                    tsa.CapacityOfWorkstaiton = outputRateRecord.Rate;
                    tsa.Operation_Type = scheduledOperation.OperationType;
                    tsa.ProductName = or.Product.Product_Name;
                    tsa.Id = scheduledOperation.ScheduleDetailsId.ToString();
                    tsa.Order = or;
                    tsa.WorkStation = ws;
                    tsa.Operation_Type = ot;
                    tsa.Contact = contact;
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
            if (e.Button == MouseButtons.Left)
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

        }

        private async void calendar1_ItemModified(object sender, MindFusion.Scheduling.WinForms.ItemModifiedEventArgs e)
        {
            OrderAllocation oa = (OrderAllocation)e.Item;
            


            calendar1.Schedule.Items.Remove(oa);

            var isEmptyDay = calendar1.Schedule.Items.Any(i => i != oa && i.EndTime.Date == oa.StartTime.Date && i.Contacts.FirstOrDefault() == oa.Contacts.FirstOrDefault());


            if (!isEmptyDay)
            {

                DialogResult result = MessageBox.Show(
                    "Do you want to move this to start of the day", // Message
                    "Confirmation",            // Title
                    MessageBoxButtons.YesNo,    // Buttons (Yes and No)
                    MessageBoxIcon.Question     // Icon (Question mark)
                    );

                if (result == DialogResult.Yes)
                {
                    DateTime newStartTime = new DateTime(oa.StartTime.Year, oa.StartTime.Month, oa.StartTime.Day, 0, 0, 0);
                    oa.StartTime = newStartTime;
                }
            }


            double days = _util.CalculateDays(oa.StartTime, double.Parse(oa.DurationInHours.ToString()), oa.Contacts.FirstOrDefault(), CustomDays);
            DateTime endTime = _util.CalculateEndDateConsideringHolidays(oa.StartTime, decimal.Parse(days.ToString()));
            DateTime visibleStartDateTime = _util.MapToVisibleRange(CustomDays, oa.StartTime, oa.Contacts.FirstOrDefault());
            DateTime visibleEndDateTime = _util.MapToVisibleRange(CustomDays, endTime, oa.Contacts.FirstOrDefault());

            oa.EndTime = endTime;
            oa.VisibleStartTime = visibleStartDateTime;
            oa.VisibleEndTime = visibleEndDateTime;

            calendar1.Schedule.Items.Add(oa);


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
                DateTime StartTime;
                if (r == null)
                {
                    MessageBox.Show("Invalid Workstation");
                    calendar1.Invalidate();
                    return;
                }

                var isEmptyDay = calendar1.Schedule.Items.Any(i => i.EndTime.Date == dropDateTime.Date && i.Contacts.FirstOrDefault() == contact);


                if (!isEmptyDay)
                {

                    DialogResult dr = MessageBox.Show(
                        "Do you want to move this to start of the day", // Message
                        "Confirmation",            // Title
                        MessageBoxButtons.YesNo,    // Buttons (Yes and No)
                        MessageBoxIcon.Question     // Icon (Question mark)
                        );

                    if (dr == DialogResult.Yes)
                    {
                        StartTime = new DateTime(dropDateTime.Year, dropDateTime.Month, dropDateTime.Day, 0, 0, 0);

                    }
                    else
                    {
                        StartTime = new DateTime(dropDateTime.Year, dropDateTime.Month, dropDateTime.Day, dropDateTime.Hour, dropDateTime.Minute, dropDateTime.Second);

                    }
                }
                else
                {
                    StartTime = new DateTime(dropDateTime.Year, dropDateTime.Month, dropDateTime.Day, dropDateTime.Hour, dropDateTime.Minute, dropDateTime.Second);

                }




                var c = orderList.Where(o => o.Product.Product_Id == order.Product.Product_Id && o.Operation_Type.Operation_Type_Id == order.Operation_Type.Operation_Type_Id && o.WorkStation.WorkStationId.ToString() == contact.Id).FirstOrDefault();




                OrderAllocation orderAllocation = new OrderAllocation();

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


                // Method to adjust overlapping items based on a new time range.

                // Example usage in your main code where the new item is being added.
                //AdjustOverlappingItems(StartTime, endTime, orderAllocation, visibleStartDateTime, visibleEndDateTime);




                orderAllocation.EndTime = endTime;
                orderAllocation.VisibleEndTime = visibleEndDateTime;
                orderAllocation.VisibleStartTime = visibleStartDateTime;

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
                orderAllocation.CapacityOfWorkstaiton = c.Capacity;
                orderAllocation.WorkStation = order.WorkStation;
                orderAllocation.Operation_Type = order.Operation_Type;
                orderAllocation.Order = order.Order;

                OverlapUtil util = new OverlapUtil();

                //calendar1.Schedule.GetAllItems(DateTime.MinValue,DateTime. contact);

                //util.FindOverlappingItemBefore();

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
        List<OrderAllocation> alreadyChecked = new List<OrderAllocation>();

        private void AdjustOverlappingItems(DateTime startTime, DateTime endTime, OrderAllocation newOrderAllocation, DateTime visibleStartTime, DateTime visibleEndTime)
        {
            alreadyChecked.Add(newOrderAllocation);
            List<OrderAllocation> overlappingItemsAfter = new List<OrderAllocation>();
            List<OrderAllocation> overlappingItemsBefore = new List<OrderAllocation>();

            // Find all overlapping items based on the new item's time.
            foreach (OrderAllocation oa in calendar1.Schedule.Items)
            {
                // Check if the existing item's time range overlaps with the new item.


                if ((startTime < oa.EndTime && endTime > oa.StartTime) && oa.Contacts.FirstOrDefault() == newOrderAllocation.Contacts.FirstOrDefault())
                {
                    if (oa.StartTime >= startTime)
                    {
                        overlappingItemsAfter.Add(oa);
                    }
                    else
                    {
                        overlappingItemsBefore.Add(oa);
                    }
                }
            }

            if (overlappingItemsAfter.Count != 0 || overlappingItemsBefore.Count != 0)
            {
                // Remove overlapping items from the calendar temporarily.
                foreach (OrderAllocation oa in overlappingItemsAfter.Concat(overlappingItemsBefore))
                {
                    calendar1.Schedule.Items.Remove(oa);
                }


                // Sort overlapping items.
                overlappingItemsAfter = overlappingItemsAfter.OrderBy(oa => oa.StartTime).ToList();
                overlappingItemsBefore = overlappingItemsBefore.OrderBy(oa => oa.StartTime).ToList();
                DateTime afterCurrentDT;

                // Handle items that start before the new item.
                if (overlappingItemsBefore.Count > 0)
                {
                    DateTime beforeCurrentDT = overlappingItemsBefore[0].StartTime;

                    foreach (OrderAllocation oa in overlappingItemsBefore)
                    {
                        oa.StartTime = beforeCurrentDT;

                        // Calculate new end time based on duration.
                        double d = _util.CalculateDays(oa.StartTime, double.Parse(oa.DurationInHours.ToString()), oa.Contacts.FirstOrDefault(), CustomDays);
                        DateTime et = _util.CalculateEndDateConsideringHolidays(oa.StartTime, decimal.Parse(d.ToString()));

                        // Map to visible range.
                        DateTime vst = _util.MapToVisibleRange(CustomDays, oa.StartTime, oa.Contacts.FirstOrDefault());
                        DateTime vet = _util.MapToVisibleRange(CustomDays, et, oa.Contacts.FirstOrDefault());

                        oa.EndTime = et;
                        oa.VisibleStartTime = vst;
                        oa.VisibleEndTime = vet;
                        MessageBox.Show(oa.StartTime + " " + oa.EndTime);

                        // Add the updated item back to the calendar.
                        calendar1.Schedule.Items.Add(oa);

                        // Update beforeCurrentDT to the new end time.
                        beforeCurrentDT = et;
                    }

                    // Update the new order allocation with the new start time after shifting previous items.
                    newOrderAllocation.StartTime = beforeCurrentDT;

                    // Calculate new end time for the new item.
                    double d1 = _util.CalculateDays(newOrderAllocation.StartTime, double.Parse(newOrderAllocation.DurationInHours.ToString()), newOrderAllocation.Contacts.FirstOrDefault(), CustomDays);
                    DateTime et1 = _util.CalculateEndDateConsideringHolidays(newOrderAllocation.StartTime, decimal.Parse(d1.ToString()));

                    // Map to visible range.
                    DateTime vst1 = _util.MapToVisibleRange(CustomDays, newOrderAllocation.StartTime, newOrderAllocation.Contacts.FirstOrDefault());
                    DateTime vet1 = _util.MapToVisibleRange(CustomDays, et1, newOrderAllocation.Contacts.FirstOrDefault());

                    newOrderAllocation.EndTime = et1;
                    newOrderAllocation.VisibleStartTime = vst1;
                    newOrderAllocation.VisibleEndTime = vet1;

                    afterCurrentDT = et1;
                }
                else
                {
                    afterCurrentDT = endTime;
                    newOrderAllocation.EndTime = endTime;
                    newOrderAllocation.VisibleEndTime = visibleEndTime;
                    newOrderAllocation.VisibleStartTime = visibleStartTime;
                }

                OrderAllocation lastItem = null;
                // Handle items that start after the new item.
                foreach (OrderAllocation oa in overlappingItemsAfter)
                {
                    // Update start time based on the end time of the last processed item.
                    oa.StartTime = afterCurrentDT;

                    // Calculate new end time based on duration.
                    double d = _util.CalculateDays(oa.StartTime, double.Parse(oa.DurationInHours.ToString()), oa.Contacts.FirstOrDefault(), CustomDays);
                    DateTime et = _util.CalculateEndDateConsideringHolidays(oa.StartTime, decimal.Parse(d.ToString()));

                    // Map to visible range.
                    DateTime vst = _util.MapToVisibleRange(CustomDays, oa.StartTime, oa.Contacts.FirstOrDefault());
                    DateTime vet = _util.MapToVisibleRange(CustomDays, et, oa.Contacts.FirstOrDefault());

                    oa.EndTime = et;
                    oa.VisibleStartTime = vst;
                    oa.VisibleEndTime = vet;
                    // MessageBox.Show(oa.StartTime + " " + oa.EndTime + " "+ oa.DurationInHours);

                    // Add the updated item back to the calendar.
                    calendar1.Schedule.Items.Add(oa);

                    // Update afterCurrentDT for the next item.
                    afterCurrentDT = et;
                    lastItem = oa;

                }

                if (!alreadyChecked.Any(a => a == lastItem))
                {

                    AdjustOverlappingItems(lastItem.StartTime, afterCurrentDT, lastItem, visibleStartTime, visibleEndTime);

                }
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
                    var scheduleDetails = await context.ScheduleDetails.FirstOrDefaultAsync(s => s.ScheduleDetailsId == oa.OrderAllocationId);

                    if (scheduleDetails == null)
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



                    }
                    else
                    {

                        scheduleDetails.Qty = double.Parse(oa.Qty);
                        scheduleDetails.DurationInHours = oa.DurationInHours;
                        scheduleDetails.StartTime = oa.StartTime;
                        scheduleDetails.EndTime = oa.EndTime;
                        scheduleDetails.VisibleStartTime = oa.VisibleStartTime;
                        scheduleDetails.VisibleEndTime = oa.VisibleEndTime;
                        context.ScheduleDetails.Update(scheduleDetails);
                        await context.SaveChangesAsync();
                    }
                }

                await context.SaveChangesAsync();

            }

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

            if (e.Button == MouseButtons.Right)
            {
                Point clickLocation = calendar1.PointToClient(Cursor.Position);

                SplitHereClickedDateTime = calendar1.GetDateAt(clickLocation);
                SplitHereSelectedItem = (OrderAllocation)e.Item;


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

        }

        private void redo_Click(object sender, EventArgs e)
        {

        }

        private void calendar1_ItemTooltipDisplaying(object sender, ItemTooltipEventArgs e)
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
                FullOrder fullOrder = new FullOrder(calendar1.Schedule.Items, uniqueOrderList, uniqueScheduledOrderList, machines, orderNo);
                fullOrder.Text = "Order No :" + orderNo;


                _dataGridView1clickedRow = null;
                fullOrder.Show();

            }
            else if (_dataGridView2clickedRow != null)
            {

                string orderNo = _dataGridView2clickedRow.Cells[0].Value.ToString();

                FullOrder fullOrder = new FullOrder(calendar1.Schedule.Items, uniqueOrderList, uniqueScheduledOrderList, machines, orderNo);
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

        private void splitHereToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void splitByQuantityToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void splitByQuantityToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            double inputQty = 0;

            using (SplitAt sa = new SplitAt(decimal.Parse(SplitHereSelectedItem.Qty), SplitHereSelectedItem.Operation_Type.Operation_Type_Name))
            {
                if (sa.ShowDialog() == DialogResult.OK)
                {
                    inputQty = sa.qty;
                }
                else
                {
                    return;
                }

            }
            double otherNewQty = double.Parse(SplitHereSelectedItem.Qty) - inputQty;

            MindFusion.Scheduling.Contact contact = calendar1.Contacts.FirstOrDefault(c => c.Id == SplitHereSelectedItem.Contact.Id);


            double durationInHours = (double.Parse(inputQty.ToString()) / SplitHereSelectedItem.CapacityOfWorkstaiton);

            double days = _util.CalculateDays(SplitHereSelectedItem.StartTime, durationInHours, contact, CustomDays);

            DateTime endTime = _util.CalculateEndDateConsideringHolidays(SplitHereSelectedItem.StartTime, decimal.Parse(days.ToString()));

            DateTime visibleEndDateTime = _util.MapToVisibleRange(CustomDays, endTime, contact);

            double durationInHoursNew = (double.Parse(otherNewQty.ToString()) / SplitHereSelectedItem.CapacityOfWorkstaiton);

            double daysNew = _util.CalculateDays(endTime, durationInHoursNew, contact, CustomDays);

            DateTime endTimeNew = _util.CalculateEndDateConsideringHolidays(endTime, decimal.Parse(daysNew.ToString()));

            DateTime visibleStartDateTimeNew = _util.MapToVisibleRange(CustomDays, endTime, contact);

            DateTime visibleEndDateTimeNew = _util.MapToVisibleRange(CustomDays, endTimeNew, contact);


            OrderAllocation oa = new OrderAllocation();
            oa.OrderAllocationId = -1;
            oa.OrderTitle = SplitHereSelectedItem.OrderTitle;
            oa.HeaderText = SplitHereSelectedItem.OrderTitle;
            oa.StartTime = endTime;
            oa.EndTime = endTimeNew;
            oa.VisibleEndTime = visibleEndDateTimeNew;
            oa.VisibleStartTime = visibleStartDateTimeNew;
            oa.Qty = otherNewQty.ToString();
            oa.DurationInHours = durationInHoursNew;
            oa.deliveryDate = SplitHereSelectedItem.deliveryDate;
            oa.Customer = SplitHereSelectedItem.Customer;
            oa.Operation_Type = SplitHereSelectedItem.Operation_Type;
            oa.WorkStation = SplitHereSelectedItem.WorkStation;
            oa.Order = SplitHereSelectedItem.Order;
            oa.ProductName = SplitHereSelectedItem.ProductName;
            oa.Id = SplitHereSelectedItem.OrderAllocationId.ToString();
            oa.Contact = contact;
            oa.CapacityOfWorkstaiton = SplitHereSelectedItem.CapacityOfWorkstaiton;

            if (contact != null)
            {
                oa.Contacts.Add(contact);
            }
            oa.Style.FillColor = System.Drawing.Color.Red;
            oa.Style.LineColor = System.Drawing.Color.Red;


            SplitHereSelectedItem.Qty = inputQty.ToString();
            SplitHereSelectedItem.DurationInHours = durationInHours;
            SplitHereSelectedItem.StartTime = SplitHereSelectedItem.StartTime;
            SplitHereSelectedItem.EndTime = endTime;
            SplitHereSelectedItem.VisibleStartTime = SplitHereSelectedItem.VisibleStartTime;
            SplitHereSelectedItem.VisibleEndTime = visibleEndDateTime;

            calendar1.Schedule.Items.Remove(SplitHereSelectedItem);

            calendar1.Schedule.Items.Add(oa);
            calendar1.Schedule.Items.Add(SplitHereSelectedItem);
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage tabPage = tabControl1.TabPages[e.Index];

            // Get the bounds of the tab
            Rectangle tabRect = tabControl1.GetTabRect(e.Index);

            // Set colors (background and text)
            System.Drawing.Color tabBackColor = e.State == DrawItemState.Selected ? System.Drawing.Color.DarkBlue : System.Drawing.Color.LightGray; // Background color for selected/unselected tab
            System.Drawing.Color tabTextColor = e.State == DrawItemState.Selected ? System.Drawing.Color.White : System.Drawing.Color.Black; // Text color for selected/unselected tab

            // Fill the tab background
            using (System.Drawing.Brush brush = new System.Drawing.SolidBrush(tabBackColor))
            {
                e.Graphics.FillRectangle(brush, tabRect);
            }

            // Draw the tab text
            TextRenderer.DrawText(e.Graphics, tabPage.Text, tabControl1.Font, tabRect, tabTextColor, TextFormatFlags.Left);

        }

       
    }
}
