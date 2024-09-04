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
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            label2 = new Label();
            checkBox1 = new CheckBox();
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
            button1 = new Button();
            button4 = new Button();
            button2 = new MindFusion.UI.WinForms.Button();
            button3 = new MindFusion.UI.WinForms.Button();
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
            splitContainer1.Panel2.Controls.Add(button1);
            splitContainer1.Panel2.Controls.Add(button4);
            splitContainer1.Panel2.Controls.Add(button2);
            splitContainer1.Panel2.Controls.Add(button3);
            splitContainer1.Size = new Size(1362, 804);
            splitContainer1.SplitterDistance = 539;
            splitContainer1.TabIndex = 7;
            // 
            // panel2
            // 
            panel2.BackColor = Color.AliceBlue;
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(checkBox1);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 389);
            panel2.Name = "panel2";
            panel2.Size = new Size(1362, 150);
            panel2.TabIndex = 0;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ImageAlign = ContentAlignment.BottomCenter;
            label9.Location = new Point(76, 63);
            label9.Name = "label9";
            label9.Size = new Size(116, 28);
            label9.TabIndex = 15;
            label9.Text = "Glass Mugs";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ImageAlign = ContentAlignment.BottomCenter;
            label8.Location = new Point(435, 63);
            label8.Name = "label8";
            label8.Size = new Size(42, 28);
            label8.TabIndex = 14;
            label8.Text = "100";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ImageAlign = ContentAlignment.BottomCenter;
            label7.Location = new Point(749, 63);
            label7.Name = "label7";
            label7.Size = new Size(187, 28);
            label7.TabIndex = 13;
            label7.Text = "Glass Manufacturer";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ImageAlign = ContentAlignment.BottomCenter;
            label6.Location = new Point(1115, 63);
            label6.Name = "label6";
            label6.Size = new Size(118, 28);
            label6.TabIndex = 12;
            label6.Text = "2024-09-24";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ImageAlign = ContentAlignment.BottomCenter;
            label5.Location = new Point(976, 63);
            label5.Name = "label5";
            label5.Size = new Size(133, 28);
            label5.TabIndex = 11;
            label5.Text = "Delivery Date:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ImageAlign = ContentAlignment.BottomCenter;
            label4.Location = new Point(643, 63);
            label4.Name = "label4";
            label4.Size = new Size(100, 28);
            label4.TabIndex = 10;
            label4.Text = "Customer:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ImageAlign = ContentAlignment.BottomCenter;
            label3.Location = new Point(337, 63);
            label3.Name = "label3";
            label3.Size = new Size(92, 28);
            label3.TabIndex = 9;
            label3.Text = "Quantity:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ImageAlign = ContentAlignment.BottomCenter;
            label1.Location = new Point(12, 63);
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
            label2.Size = new Size(66, 28);
            label2.TabIndex = 7;
            label2.Text = "Order";
            // 
            // checkBox1
            // 
            checkBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(1220, 3);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(138, 24);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "View Full Screen";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // calendar1
            // 
            calendar1.AllowDrop = true;
            calendar1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            calendar1.ContactNameFormat = "F";
            calendar1.CurrentView = MindFusion.Scheduling.WinForms.CalendarView.ResourceView;
            calendar1.Date = new DateTime(2024, 8, 27, 0, 0, 0, 0);
            calendar1.EnableDragCreate = true;
            calendar1.EndDate = new DateTime(2024, 9, 26, 0, 0, 0, 0);
            calendar1.GroupType = MindFusion.Scheduling.WinForms.GroupType.GroupByContacts;
            calendar1.ItemSettings.MoveBandSize = 2;
            calendar1.LicenseKey = null;
            calendar1.Location = new Point(0, 0);
            calendar1.Name = "calendar1";
            calendar1.ResourceViewSettings.SnapUnit = MindFusion.Scheduling.WinForms.TimeUnit.Hour;
            calendar1.ShowToolTips = true;
            calendar1.Size = new Size(1362, 386);
            calendar1.TabIndex = 0;
            calendar1.Theme = MindFusion.Scheduling.WinForms.ThemeType.Vista;
            calendar1.DateClick += calendar1_DateClick;
            calendar1.ItemModified += calendar1_ItemModified;
            calendar1.ItemDrawing += calendar1_ItemDrawing;
            calendar1.Draw += calendar1_Draw;
            calendar1.DragDrop += calendar1_DragDrop;
            calendar1.DragOver += calendar1_DragOver;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.Controls.Add(dataGridView1);
            panel3.Location = new Point(12, 12);
            panel3.Name = "panel3";
            panel3.Size = new Size(1120, 236);
            panel3.TabIndex = 7;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowDrop = true;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, pendingOrderTitleDataGridViewTextBoxColumn, pendingOrderDescriptionDataGridViewTextBoxColumn, pendingOrderQtyDataGridViewTextBoxColumn, clientDataGridViewTextBoxColumn, expectedDeliveryDateDataGridViewTextBoxColumn });
            dataGridView1.DataSource = pendingOrderBindingSource;
            dataGridView1.Dock = DockStyle.Top;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1120, 233);
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
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(1138, 12);
            button1.Name = "button1";
            button1.Size = new Size(221, 54);
            button1.TabIndex = 4;
            button1.Text = "Create Holiday";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button4.Location = new Point(1138, 194);
            button4.Name = "button4";
            button4.Size = new Size(221, 54);
            button4.TabIndex = 5;
            button4.Text = "Save New Orders";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.BackgroundBrush = new MindFusion.Drawing.SolidBrush("#FFF0F0F0");
            button2.BackgroundBrushDisabled = new MindFusion.Drawing.SolidBrush("#FFDEDEDE");
            button2.BackgroundBrushDown = new MindFusion.Drawing.SolidBrush("#FFAEAEAE");
            button2.BackgroundBrushOver = new MindFusion.Drawing.SolidBrush("#FFC5C5C5");
            button2.BorderBrush = new MindFusion.Drawing.SolidBrush("#FFA6A6A6");
            button2.BorderBrushDisabled = new MindFusion.Drawing.SolidBrush("#FFA6A6A6");
            button2.BorderBrushDown = new MindFusion.Drawing.SolidBrush("#FF777777");
            button2.BorderBrushOver = new MindFusion.Drawing.SolidBrush("#FFA6A6A6");
            button2.BorderThickness = 0;
            button2.ForegroundBrush = new MindFusion.Drawing.SolidBrush("#FF000000");
            button2.ForegroundBrushDisabled = new MindFusion.Drawing.SolidBrush("#FF777777");
            button2.ForegroundBrushDown = new MindFusion.Drawing.SolidBrush("#FF000000");
            button2.ForegroundBrushOver = new MindFusion.Drawing.SolidBrush("#FF000000");
            button2.Location = new Point(1138, 72);
            button2.Name = "button2";
            button2.Size = new Size(221, 54);
            button2.TabIndex = 2;
            button2.Text = "Create Order";
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
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
            button3.Location = new Point(1138, 133);
            button3.Name = "button3";
            button3.Size = new Size(221, 54);
            button3.TabIndex = 3;
            button3.Text = "Create WorkStation";
            button3.Click += button3_Click;
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
        private CheckBox checkBox1;
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
    }
}