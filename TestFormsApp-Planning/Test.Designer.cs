namespace TestFormsApp_Planning
{
    partial class Scheduler
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Scheduler));
            panel1 = new Panel();
            splitter1 = new Splitter();
            splitContainer1 = new SplitContainer();
            panel2 = new Panel();
            redo = new Button();
            undo = new Button();
            button5 = new Button();
            button4 = new Button();
            button1 = new Button();
            button3 = new MindFusion.UI.WinForms.Button();
            button2 = new MindFusion.UI.WinForms.Button();
            label18 = new Label();
            label19 = new Label();
            label16 = new Label();
            label17 = new Label();
            label14 = new Label();
            label15 = new Label();
            label12 = new Label();
            label13 = new Label();
            label10 = new Label();
            label11 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            label2 = new Label();
            calendar1 = new MindFusion.Scheduling.WinForms.Calendar();
            contextMenuStrip1 = new ContextMenuStrip(components);
            toolStripMenuItem1 = new ToolStripMenuItem();
            createOrderToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            createWorkstationToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            createHolidayToolStripMenuItem = new ToolStripMenuItem();
            undoToolStripMenuItem = new ToolStripMenuItem();
            redoToolStripMenuItem = new ToolStripMenuItem();
            preferencesToolStripMenuItem = new ToolStripMenuItem();
            panel3 = new Panel();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            dataGridView1 = new DataGridView();
            Title = new DataGridViewTextBoxColumn();
            Description = new DataGridViewTextBoxColumn();
            Customer = new DataGridViewTextBoxColumn();
            Qty = new DataGridViewTextBoxColumn();
            ProductName = new DataGridViewTextBoxColumn();
            DeliveryDate = new DataGridViewTextBoxColumn();
            tabPage2 = new TabPage();
            dataGridView2 = new DataGridView();
            orderIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            titleDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            customerDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            qtyDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            startTimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            endTimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            deliveryDateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            durationInHoursDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            productNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            productDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            workstationNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            workStationDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            scheduledOrderBindingSource = new BindingSource(components);
            orderBindingSource = new BindingSource(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)calendar1).BeginInit();
            contextMenuStrip1.SuspendLayout();
            panel3.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)scheduledOrderBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)orderBindingSource).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(splitter1);
            panel1.Controls.Add(splitContainer1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1362, 804);
            panel1.TabIndex = 0;
            // 
            // splitter1
            // 
            splitter1.Location = new Point(0, 0);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(4, 804);
            splitter1.TabIndex = 6;
            splitter1.TabStop = false;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panel2);
            splitContainer1.Panel1.Controls.Add(calendar1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.MintCream;
            splitContainer1.Panel2.Controls.Add(panel3);
            splitContainer1.Size = new Size(1362, 804);
            splitContainer1.SplitterDistance = 576;
            splitContainer1.TabIndex = 7;
            // 
            // panel2
            // 
            panel2.BackColor = Color.AliceBlue;
            panel2.Controls.Add(redo);
            panel2.Controls.Add(undo);
            panel2.Controls.Add(button5);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(label18);
            panel2.Controls.Add(label19);
            panel2.Controls.Add(label16);
            panel2.Controls.Add(label17);
            panel2.Controls.Add(label14);
            panel2.Controls.Add(label15);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 426);
            panel2.Name = "panel2";
            panel2.Size = new Size(1362, 150);
            panel2.TabIndex = 0;
            // 
            // redo
            // 
            redo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            redo.BackColor = Color.FromArgb(224, 224, 224);
            redo.FlatStyle = FlatStyle.Popup;
            redo.Image = Properties.Resources.icons8_redo_25;
            redo.Location = new Point(1048, 4);
            redo.Name = "redo";
            redo.Size = new Size(40, 40);
            redo.TabIndex = 29;
            redo.UseVisualStyleBackColor = false;
            redo.Click += redo_Click;
            // 
            // undo
            // 
            undo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            undo.BackColor = Color.FromArgb(224, 224, 224);
            undo.FlatStyle = FlatStyle.Flat;
            undo.Image = Properties.Resources.icons8_undo_25;
            undo.Location = new Point(1091, 4);
            undo.Name = "undo";
            undo.Size = new Size(40, 40);
            undo.TabIndex = 28;
            undo.UseVisualStyleBackColor = false;
            undo.Click += undo_Click;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button5.BackColor = Color.DodgerBlue;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Image = Properties.Resources.icons8_full_screen_24;
            button5.Location = new Point(1319, 4);
            button5.Name = "button5";
            button5.Size = new Size(40, 40);
            button5.TabIndex = 26;
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button4.BackColor = Color.FromArgb(224, 224, 224);
            button4.FlatStyle = FlatStyle.Flat;
            button4.Image = Properties.Resources.icons8_save_25;
            button4.Location = new Point(1136, 3);
            button4.Name = "button4";
            button4.Size = new Size(47, 41);
            button4.TabIndex = 5;
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.BackColor = Color.FromArgb(224, 224, 224);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = Properties.Resources.icons8_create_25;
            button1.Location = new Point(1275, 4);
            button1.Name = "button1";
            button1.Size = new Size(40, 40);
            button1.TabIndex = 4;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button3.BackColor = Color.FromArgb(224, 224, 224);
            button3.BackgroundBrush = new MindFusion.Drawing.SolidBrush("#FFF0F0F0");
            button3.BackgroundBrushDisabled = new MindFusion.Drawing.SolidBrush("#FFDEDEDE");
            button3.BackgroundBrushDown = new MindFusion.Drawing.SolidBrush("#FFAEAEAE");
            button3.BackgroundBrushOver = new MindFusion.Drawing.SolidBrush("#FFC5C5C5");
            button3.BorderBrush = new MindFusion.Drawing.SolidBrush("#FFA6A6A6");
            button3.BorderBrushDisabled = new MindFusion.Drawing.SolidBrush("#FFA6A6A6");
            button3.BorderBrushDown = new MindFusion.Drawing.SolidBrush("#FF777777");
            button3.BorderBrushOver = new MindFusion.Drawing.SolidBrush("#FFA6A6A6");
            button3.BorderThickness = 0;
            button3.ForegroundBrush = new MindFusion.Drawing.SolidBrush("#FF000000");
            button3.ForegroundBrushDisabled = new MindFusion.Drawing.SolidBrush("#FF777777");
            button3.ForegroundBrushDown = new MindFusion.Drawing.SolidBrush("#FF000000");
            button3.ForegroundBrushOver = new MindFusion.Drawing.SolidBrush("#FF000000");
            button3.Image = Properties.Resources.icons8_machine_25;
            button3.Location = new Point(1187, 4);
            button3.Name = "button3";
            button3.Size = new Size(40, 40);
            button3.TabIndex = 3;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.BackColor = Color.FromArgb(224, 224, 224);
            button2.BackgroundBrush = new MindFusion.Drawing.SolidBrush("#FFF0F0F0");
            button2.BackgroundBrushDisabled = new MindFusion.Drawing.SolidBrush("#FFDEDEDE");
            button2.BackgroundBrushDown = new MindFusion.Drawing.SolidBrush("#FFAEAEAE");
            button2.BackgroundBrushOver = new MindFusion.Drawing.SolidBrush("#FFC5C5C5");
            button2.BorderBrush = new MindFusion.Drawing.SolidBrush("#FFA6A6A6");
            button2.BorderBrushDisabled = new MindFusion.Drawing.SolidBrush("#FFA6A6A6");
            button2.BorderBrushDown = new MindFusion.Drawing.SolidBrush("#FF777777");
            button2.BorderBrushOver = new MindFusion.Drawing.SolidBrush("#FFA6A6A6");
            button2.BorderThickness = 1;
            button2.ForegroundBrush = new MindFusion.Drawing.SolidBrush("#FF000000");
            button2.ForegroundBrushDisabled = new MindFusion.Drawing.SolidBrush("#FF777777");
            button2.ForegroundBrushDown = new MindFusion.Drawing.SolidBrush("#FF000000");
            button2.ForegroundBrushOver = new MindFusion.Drawing.SolidBrush("#FF000000");
            button2.Image = Properties.Resources.icons8_new_order_25;
            button2.Location = new Point(1231, 4);
            button2.Name = "button2";
            button2.Size = new Size(40, 40);
            button2.TabIndex = 2;
            button2.Click += button2_Click;
            // 
            // label18
            // 
            label18.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label18.ImageAlign = ContentAlignment.BottomCenter;
            label18.Location = new Point(1230, 103);
            label18.Name = "label18";
            label18.Size = new Size(118, 28);
            label18.TabIndex = 25;
            label18.Text = "2024-09-24";
            // 
            // label19
            // 
            label19.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label19.ImageAlign = ContentAlignment.BottomCenter;
            label19.Location = new Point(1100, 103);
            label19.Name = "label19";
            label19.Size = new Size(96, 28);
            label19.TabIndex = 24;
            label19.Text = "End Time:";
            // 
            // label16
            // 
            label16.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.ImageAlign = ContentAlignment.BottomCenter;
            label16.Location = new Point(703, 63);
            label16.Name = "label16";
            label16.Size = new Size(31, 28);
            label16.TabIndex = 23;
            label16.Text = "10";
            // 
            // label17
            // 
            label17.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label17.ImageAlign = ContentAlignment.BottomCenter;
            label17.Location = new Point(522, 63);
            label17.Name = "label17";
            label17.Size = new Size(175, 28);
            label17.TabIndex = 22;
            label17.Text = "Production Hours :";
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.ImageAlign = ContentAlignment.BottomCenter;
            label14.Location = new Point(912, 103);
            label14.Name = "label14";
            label14.Size = new Size(118, 28);
            label14.TabIndex = 21;
            label14.Text = "2024-09-24";
            // 
            // label15
            // 
            label15.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.ImageAlign = ContentAlignment.BottomCenter;
            label15.Location = new Point(813, 103);
            label15.Name = "label15";
            label15.Size = new Size(95, 28);
            label15.TabIndex = 20;
            label15.Text = "End Date:";
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ImageAlign = ContentAlignment.BottomCenter;
            label12.Location = new Point(912, 63);
            label12.Name = "label12";
            label12.Size = new Size(118, 28);
            label12.TabIndex = 19;
            label12.Text = "2024-09-24";
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.ImageAlign = ContentAlignment.BottomCenter;
            label13.Location = new Point(812, 63);
            label13.Name = "label13";
            label13.Size = new Size(103, 28);
            label13.TabIndex = 18;
            label13.Text = "Start Date:";
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ImageAlign = ContentAlignment.BottomCenter;
            label10.Location = new Point(151, 103);
            label10.Name = "label10";
            label10.Size = new Size(78, 28);
            label10.TabIndex = 17;
            label10.Text = "Sewing";
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.ImageAlign = ContentAlignment.BottomCenter;
            label11.Location = new Point(17, 103);
            label11.Name = "label11";
            label11.Size = new Size(128, 28);
            label11.TabIndex = 16;
            label11.Text = "Workstation :";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ImageAlign = ContentAlignment.BottomCenter;
            label9.Location = new Point(81, 63);
            label9.Name = "label9";
            label9.Size = new Size(116, 28);
            label9.TabIndex = 15;
            label9.Text = "Glass Mugs";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ImageAlign = ContentAlignment.BottomCenter;
            label8.Location = new Point(364, 63);
            label8.Name = "label8";
            label8.Size = new Size(42, 28);
            label8.TabIndex = 14;
            label8.Text = "100";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ImageAlign = ContentAlignment.BottomCenter;
            label7.Location = new Point(449, 103);
            label7.Name = "label7";
            label7.Size = new Size(187, 28);
            label7.TabIndex = 13;
            label7.Text = "Glass Manufacturer";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ImageAlign = ContentAlignment.BottomCenter;
            label6.Location = new Point(1231, 65);
            label6.Name = "label6";
            label6.Size = new Size(118, 28);
            label6.TabIndex = 12;
            label6.Text = "2024-09-24";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ImageAlign = ContentAlignment.BottomCenter;
            label5.Location = new Point(1100, 65);
            label5.Name = "label5";
            label5.Size = new Size(133, 28);
            label5.TabIndex = 11;
            label5.Text = "Delivery Date:";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ImageAlign = ContentAlignment.BottomCenter;
            label4.Location = new Point(343, 103);
            label4.Name = "label4";
            label4.Size = new Size(100, 28);
            label4.TabIndex = 10;
            label4.Text = "Customer:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ImageAlign = ContentAlignment.BottomCenter;
            label3.Location = new Point(266, 63);
            label3.Name = "label3";
            label3.Size = new Size(92, 28);
            label3.TabIndex = 9;
            label3.Text = "Quantity:";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ImageAlign = ContentAlignment.BottomCenter;
            label1.Location = new Point(17, 63);
            label1.Name = "label1";
            label1.Size = new Size(58, 28);
            label1.TabIndex = 8;
            label1.Text = "Title :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ImageAlign = ContentAlignment.BottomCenter;
            label2.Location = new Point(12, 14);
            label2.Name = "label2";
            label2.Size = new Size(138, 28);
            label2.TabIndex = 7;
            label2.Text = "Order Detials";
            // 
            // calendar1
            // 
            calendar1.AllowDrag = false;
            calendar1.AllowDrop = true;
            calendar1.AllowInplaceCreate = false;
            calendar1.AllowInplaceEdit = false;
            calendar1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            calendar1.ContactNameFormat = "F";
            calendar1.ContextMenuStrip = contextMenuStrip1;
            calendar1.CurrentView = MindFusion.Scheduling.WinForms.CalendarView.ResourceView;
            calendar1.CustomDraw = MindFusion.Scheduling.WinForms.CustomDrawElements.ResourceViewCell;
            calendar1.Date = new DateTime(2024, 8, 27, 0, 0, 0, 0);
            calendar1.EndDate = new DateTime(2024, 12, 31, 0, 0, 0, 0);
            calendar1.GroupType = MindFusion.Scheduling.WinForms.GroupType.GroupByContacts;
            calendar1.ItemSettings.MoveBandSize = 2;
            calendar1.LicenseKey = null;
            calendar1.Location = new Point(0, 0);
            calendar1.Name = "calendar1";
            calendar1.ResourceViewSettings.SnapUnit = MindFusion.Scheduling.WinForms.TimeUnit.Hour;
            calendar1.ShowToolTips = true;
            calendar1.Size = new Size(1362, 423);
            calendar1.TabIndex = 0;
            calendar1.Theme = MindFusion.Scheduling.WinForms.ThemeType.Vista;
            calendar1.DateClick += calendar1_DateClick;
            calendar1.ItemClick += calendar1_ItemClick;
            calendar1.ItemModified += calendar1_ItemModified;
            calendar1.ItemDrawing += calendar1_ItemDrawing;
            calendar1.ItemTooltipDisplaying += calendar1_ItemTooltipDisplaying;
            calendar1.ItemSelecting += calendar1_ItemSelecting;
            calendar1.DragDrop += calendar1_DragDrop;
            calendar1.DragOver += calendar1_DragOver;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripMenuItem3, toolStripMenuItem2, undoToolStripMenuItem, redoToolStripMenuItem, preferencesToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(168, 160);
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { createOrderToolStripMenuItem });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(167, 26);
            toolStripMenuItem1.Text = "Orders";
            // 
            // createOrderToolStripMenuItem
            // 
            createOrderToolStripMenuItem.Name = "createOrderToolStripMenuItem";
            createOrderToolStripMenuItem.Size = new Size(177, 26);
            createOrderToolStripMenuItem.Text = "Create Order";
            createOrderToolStripMenuItem.Click += createOrderToolStripMenuItem_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.DropDownItems.AddRange(new ToolStripItem[] { createWorkstationToolStripMenuItem });
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(167, 26);
            toolStripMenuItem3.Text = "Workstations";
            // 
            // createWorkstationToolStripMenuItem
            // 
            createWorkstationToolStripMenuItem.Name = "createWorkstationToolStripMenuItem";
            createWorkstationToolStripMenuItem.Size = new Size(218, 26);
            createWorkstationToolStripMenuItem.Text = "Create Workstation";
            createWorkstationToolStripMenuItem.Click += createWorkstationToolStripMenuItem_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.DropDownItems.AddRange(new ToolStripItem[] { createHolidayToolStripMenuItem });
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(167, 26);
            toolStripMenuItem2.Text = "Holidays";
            toolStripMenuItem2.Click += toolStripMenuItem2_Click;
            // 
            // createHolidayToolStripMenuItem
            // 
            createHolidayToolStripMenuItem.Name = "createHolidayToolStripMenuItem";
            createHolidayToolStripMenuItem.Size = new Size(191, 26);
            createHolidayToolStripMenuItem.Text = "Create Holiday";
            createHolidayToolStripMenuItem.Click += createHolidayToolStripMenuItem_Click;
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Enabled = false;
            undoToolStripMenuItem.Image = Properties.Resources.icons8_undo_25;
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.Size = new Size(167, 26);
            undoToolStripMenuItem.Text = "Undo";
            undoToolStripMenuItem.Click += undoToolStripMenuItem_Click;
            // 
            // redoToolStripMenuItem
            // 
            redoToolStripMenuItem.Enabled = false;
            redoToolStripMenuItem.Image = Properties.Resources.icons8_redo_25;
            redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            redoToolStripMenuItem.Size = new Size(167, 26);
            redoToolStripMenuItem.Text = "Redo";
            redoToolStripMenuItem.Click += redoToolStripMenuItem_Click;
            // 
            // preferencesToolStripMenuItem
            // 
            preferencesToolStripMenuItem.Image = Properties.Resources.icons8_settings_50;
            preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            preferencesToolStripMenuItem.Size = new Size(167, 26);
            preferencesToolStripMenuItem.Text = "Preferences";
            // 
            // panel3
            // 
            panel3.Controls.Add(tabControl1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1362, 224);
            panel3.TabIndex = 7;
            // 
            // tabControl1
            // 
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.HotTrack = true;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1362, 224);
            tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Location = new Point(4, 32);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1354, 188);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Pending Orders";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowDrop = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Title, Description, Customer, Qty, ProductName, DeliveryDate });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1348, 182);
            dataGridView1.TabIndex = 6;
            dataGridView1.MouseDown += dataGridView1_MouseDown;
            // 
            // Title
            // 
            Title.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Title.DataPropertyName = "Title";
            Title.HeaderText = "Order";
            Title.MinimumWidth = 6;
            Title.Name = "Title";
            // 
            // Description
            // 
            Description.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Description.DataPropertyName = "Description";
            Description.HeaderText = "Description";
            Description.MinimumWidth = 6;
            Description.Name = "Description";
            // 
            // Customer
            // 
            Customer.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Customer.DataPropertyName = "Customer";
            Customer.HeaderText = "Customer";
            Customer.MinimumWidth = 6;
            Customer.Name = "Customer";
            // 
            // Qty
            // 
            Qty.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Qty.DataPropertyName = "Qty";
            Qty.HeaderText = "Qty";
            Qty.MinimumWidth = 6;
            Qty.Name = "Qty";
            // 
            // ProductName
            // 
            ProductName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ProductName.DataPropertyName = "ProductName";
            ProductName.HeaderText = "Product";
            ProductName.MinimumWidth = 6;
            ProductName.Name = "ProductName";
            // 
            // DeliveryDate
            // 
            DeliveryDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DeliveryDate.DataPropertyName = "DeliveryDate";
            DeliveryDate.HeaderText = "Delivery Date";
            DeliveryDate.MinimumWidth = 6;
            DeliveryDate.Name = "DeliveryDate";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dataGridView2);
            tabPage2.Location = new Point(4, 32);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1354, 188);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Schedule Orders";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { orderIdDataGridViewTextBoxColumn, titleDataGridViewTextBoxColumn, customerDataGridViewTextBoxColumn, qtyDataGridViewTextBoxColumn, startTimeDataGridViewTextBoxColumn, endTimeDataGridViewTextBoxColumn, deliveryDateDataGridViewTextBoxColumn, durationInHoursDataGridViewTextBoxColumn, productNameDataGridViewTextBoxColumn, productDataGridViewTextBoxColumn, workstationNameDataGridViewTextBoxColumn, workStationDataGridViewTextBoxColumn });
            dataGridView2.DataSource = scheduledOrderBindingSource;
            dataGridView2.Dock = DockStyle.Fill;
            dataGridView2.Location = new Point(3, 3);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(1348, 182);
            dataGridView2.TabIndex = 0;
            // 
            // orderIdDataGridViewTextBoxColumn
            // 
            orderIdDataGridViewTextBoxColumn.DataPropertyName = "OrderId";
            orderIdDataGridViewTextBoxColumn.HeaderText = "OrderId";
            orderIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            orderIdDataGridViewTextBoxColumn.Name = "orderIdDataGridViewTextBoxColumn";
            orderIdDataGridViewTextBoxColumn.ReadOnly = true;
            orderIdDataGridViewTextBoxColumn.Visible = false;
            orderIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            titleDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            titleDataGridViewTextBoxColumn.HeaderText = "Order";
            titleDataGridViewTextBoxColumn.MinimumWidth = 6;
            titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            titleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // customerDataGridViewTextBoxColumn
            // 
            customerDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            customerDataGridViewTextBoxColumn.DataPropertyName = "Customer";
            customerDataGridViewTextBoxColumn.HeaderText = "Customer";
            customerDataGridViewTextBoxColumn.MinimumWidth = 6;
            customerDataGridViewTextBoxColumn.Name = "customerDataGridViewTextBoxColumn";
            customerDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qtyDataGridViewTextBoxColumn
            // 
            qtyDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            qtyDataGridViewTextBoxColumn.DataPropertyName = "Qty";
            qtyDataGridViewTextBoxColumn.HeaderText = "Qty";
            qtyDataGridViewTextBoxColumn.MinimumWidth = 6;
            qtyDataGridViewTextBoxColumn.Name = "qtyDataGridViewTextBoxColumn";
            qtyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // startTimeDataGridViewTextBoxColumn
            // 
            startTimeDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            startTimeDataGridViewTextBoxColumn.DataPropertyName = "StartTime";
            startTimeDataGridViewTextBoxColumn.HeaderText = "Start Time";
            startTimeDataGridViewTextBoxColumn.MinimumWidth = 6;
            startTimeDataGridViewTextBoxColumn.Name = "startTimeDataGridViewTextBoxColumn";
            startTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // endTimeDataGridViewTextBoxColumn
            // 
            endTimeDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            endTimeDataGridViewTextBoxColumn.DataPropertyName = "EndTime";
            endTimeDataGridViewTextBoxColumn.HeaderText = "End Time";
            endTimeDataGridViewTextBoxColumn.MinimumWidth = 6;
            endTimeDataGridViewTextBoxColumn.Name = "endTimeDataGridViewTextBoxColumn";
            endTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // deliveryDateDataGridViewTextBoxColumn
            // 
            deliveryDateDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            deliveryDateDataGridViewTextBoxColumn.DataPropertyName = "DeliveryDate";
            deliveryDateDataGridViewTextBoxColumn.HeaderText = "Delivery Date";
            deliveryDateDataGridViewTextBoxColumn.MinimumWidth = 6;
            deliveryDateDataGridViewTextBoxColumn.Name = "deliveryDateDataGridViewTextBoxColumn";
            deliveryDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // durationInHoursDataGridViewTextBoxColumn
            // 
            durationInHoursDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            durationInHoursDataGridViewTextBoxColumn.DataPropertyName = "DurationInHours";
            durationInHoursDataGridViewTextBoxColumn.HeaderText = "Duration In Hours";
            durationInHoursDataGridViewTextBoxColumn.MinimumWidth = 6;
            durationInHoursDataGridViewTextBoxColumn.Name = "durationInHoursDataGridViewTextBoxColumn";
            durationInHoursDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // productNameDataGridViewTextBoxColumn
            // 
            productNameDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            productNameDataGridViewTextBoxColumn.DataPropertyName = "ProductName";
            productNameDataGridViewTextBoxColumn.HeaderText = "Product";
            productNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            productNameDataGridViewTextBoxColumn.Name = "productNameDataGridViewTextBoxColumn";
            productNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // productDataGridViewTextBoxColumn
            // 
            productDataGridViewTextBoxColumn.DataPropertyName = "Product";
            productDataGridViewTextBoxColumn.HeaderText = "Product";
            productDataGridViewTextBoxColumn.MinimumWidth = 6;
            productDataGridViewTextBoxColumn.Name = "productDataGridViewTextBoxColumn";
            productDataGridViewTextBoxColumn.ReadOnly = true;
            productDataGridViewTextBoxColumn.Visible = false;
            productDataGridViewTextBoxColumn.Width = 125;
            // 
            // workstationNameDataGridViewTextBoxColumn
            // 
            workstationNameDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            workstationNameDataGridViewTextBoxColumn.DataPropertyName = "WorkstationName";
            workstationNameDataGridViewTextBoxColumn.HeaderText = "Workstation";
            workstationNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            workstationNameDataGridViewTextBoxColumn.Name = "workstationNameDataGridViewTextBoxColumn";
            workstationNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // workStationDataGridViewTextBoxColumn
            // 
            workStationDataGridViewTextBoxColumn.DataPropertyName = "WorkStation";
            workStationDataGridViewTextBoxColumn.HeaderText = "WorkStation";
            workStationDataGridViewTextBoxColumn.MinimumWidth = 6;
            workStationDataGridViewTextBoxColumn.Name = "workStationDataGridViewTextBoxColumn";
            workStationDataGridViewTextBoxColumn.ReadOnly = true;
            workStationDataGridViewTextBoxColumn.Visible = false;
            workStationDataGridViewTextBoxColumn.Width = 125;
            // 
            // scheduledOrderBindingSource
            // 
            scheduledOrderBindingSource.DataSource = typeof(Classes.ScheduledOrder);
            // 
            // orderBindingSource
            // 
            orderBindingSource.DataSource = typeof(Entities.Order);
            // 
            // Scheduler
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1362, 804);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Scheduler";
            Text = "Scheduler";
            panel1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)calendar1).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)scheduledOrderBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)orderBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private MindFusion.Scheduling.WinForms.Calendar calendar1;
        private MindFusion.UI.WinForms.Button button2;
        private MindFusion.UI.WinForms.Button button3;
        private Button button1;
        private Button button4;
        private Splitter splitter1;
        private SplitContainer splitContainer1;
        private Panel panel2;
        private DataGridView dataGridView1;
        private Panel panel3;
        private DataGridViewTextBoxColumn pendingOrderTitleDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn pendingOrderDescriptionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn pendingOrderQtyDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn clientDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn expectedDeliveryDateDataGridViewTextBoxColumn;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label1;
        private Label label2;
        private Label label10;
        private Label label11;
        private Label label16;
        private Label label17;
        private Label label14;
        private Label label15;
        private Label label12;
        private Label label13;
        private Label label18;
        private Label label19;
        private Button button5;
        private Button undo;
        private Button redo;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem createOrderToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem redoToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem createWorkstationToolStripMenuItem;
        private ToolStripMenuItem createHolidayToolStripMenuItem;
        private ToolStripMenuItem preferencesToolStripMenuItem;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn orderDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn visibleStartTimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn visibleEndTimeDataGridViewTextBoxColumn;
        private BindingSource orderBindingSource;
        private DataGridViewTextBoxColumn Product;
        private DataGridViewTextBoxColumn Title;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewTextBoxColumn Customer;
        private DataGridViewTextBoxColumn Qty;
        private DataGridViewTextBoxColumn ProductName;
        private DataGridViewTextBoxColumn DeliveryDate;
        private DataGridViewTextBoxColumn orderIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn customerDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn startTimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn endTimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn deliveryDateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn durationInHoursDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn productDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn workstationNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn workStationDataGridViewTextBoxColumn;
        private BindingSource scheduledOrderBindingSource;
    }
}