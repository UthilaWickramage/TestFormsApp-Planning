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
            panel1 = new Panel();
            splitter1 = new Splitter();
            splitContainer1 = new SplitContainer();
            panel2 = new Panel();
            button7 = new Button();
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
            panel3 = new Panel();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            pendingOrderTitleDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            pendingOrderDescriptionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            pendingOrderQtyDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            clientDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            expectedDeliveryDateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            pendingOrderBindingSource = new BindingSource(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)calendar1).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pendingOrderBindingSource).BeginInit();
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
            panel2.Controls.Add(button7);
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
            // button7
            // 
            button7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button7.BackColor = Color.FromArgb(224, 224, 224);
            button7.FlatStyle = FlatStyle.Flat;
            button7.Image = Properties.Resources.icons8_undo_25;
            button7.Location = new Point(1091, 4);
            button7.Name = "button7";
            button7.Size = new Size(40, 40);
            button7.TabIndex = 28;
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
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
            calendar1.CurrentView = MindFusion.Scheduling.WinForms.CalendarView.ResourceView;
            calendar1.CustomDraw = MindFusion.Scheduling.WinForms.CustomDrawElements.ResourceViewCell;
            calendar1.Date = new DateTime(2024, 8, 27, 0, 0, 0, 0);
            calendar1.EndDate = new DateTime(2024, 9, 26, 0, 0, 0, 0);
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
            calendar1.ItemSelecting += calendar1_ItemSelecting;
            calendar1.DragDrop += calendar1_DragDrop;
            calendar1.DragOver += calendar1_DragOver;
            // 
            // panel3
            // 
            panel3.Controls.Add(dataGridView1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1362, 224);
            panel3.TabIndex = 7;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowDrop = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, pendingOrderTitleDataGridViewTextBoxColumn, pendingOrderDescriptionDataGridViewTextBoxColumn, pendingOrderQtyDataGridViewTextBoxColumn, clientDataGridViewTextBoxColumn, expectedDeliveryDateDataGridViewTextBoxColumn });
            dataGridView1.DataSource = pendingOrderBindingSource;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1362, 224);
            dataGridView1.TabIndex = 6;
            dataGridView1.MouseDown += dataGridView1_MouseDown;
            // 
            // Column1
            // 
            Column1.DataPropertyName = "PendingOrderId";
            Column1.HeaderText = "Column1";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Visible = false;
            Column1.Width = 125;
            // 
            // pendingOrderTitleDataGridViewTextBoxColumn
            // 
            pendingOrderTitleDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            pendingOrderTitleDataGridViewTextBoxColumn.DataPropertyName = "PendingOrderTitle";
            pendingOrderTitleDataGridViewTextBoxColumn.HeaderText = "Title";
            pendingOrderTitleDataGridViewTextBoxColumn.MinimumWidth = 6;
            pendingOrderTitleDataGridViewTextBoxColumn.Name = "pendingOrderTitleDataGridViewTextBoxColumn";
            // 
            // pendingOrderDescriptionDataGridViewTextBoxColumn
            // 
            pendingOrderDescriptionDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            pendingOrderDescriptionDataGridViewTextBoxColumn.DataPropertyName = "PendingOrderDescription";
            pendingOrderDescriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            pendingOrderDescriptionDataGridViewTextBoxColumn.MinimumWidth = 6;
            pendingOrderDescriptionDataGridViewTextBoxColumn.Name = "pendingOrderDescriptionDataGridViewTextBoxColumn";
            // 
            // pendingOrderQtyDataGridViewTextBoxColumn
            // 
            pendingOrderQtyDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            pendingOrderQtyDataGridViewTextBoxColumn.DataPropertyName = "PendingOrderQty";
            pendingOrderQtyDataGridViewTextBoxColumn.HeaderText = "Qty";
            pendingOrderQtyDataGridViewTextBoxColumn.MinimumWidth = 6;
            pendingOrderQtyDataGridViewTextBoxColumn.Name = "pendingOrderQtyDataGridViewTextBoxColumn";
            // 
            // clientDataGridViewTextBoxColumn
            // 
            clientDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            clientDataGridViewTextBoxColumn.DataPropertyName = "Client";
            clientDataGridViewTextBoxColumn.HeaderText = "Customer";
            clientDataGridViewTextBoxColumn.MinimumWidth = 6;
            clientDataGridViewTextBoxColumn.Name = "clientDataGridViewTextBoxColumn";
            // 
            // expectedDeliveryDateDataGridViewTextBoxColumn
            // 
            expectedDeliveryDateDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            expectedDeliveryDateDataGridViewTextBoxColumn.DataPropertyName = "ExpectedDeliveryDate";
            expectedDeliveryDateDataGridViewTextBoxColumn.HeaderText = "Delivery Date";
            expectedDeliveryDateDataGridViewTextBoxColumn.MinimumWidth = 6;
            expectedDeliveryDateDataGridViewTextBoxColumn.Name = "expectedDeliveryDateDataGridViewTextBoxColumn";
            // 
            // pendingOrderBindingSource
            // 
            pendingOrderBindingSource.DataSource = typeof(Entities.PendingOrder);
            // 
            // Scheduler
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1362, 804);
            Controls.Add(panel1);
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
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pendingOrderBindingSource).EndInit();
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
        private BindingSource pendingOrderBindingSource;
        private DataGridViewTextBoxColumn Column1;
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
        private Button button7;
    }
}