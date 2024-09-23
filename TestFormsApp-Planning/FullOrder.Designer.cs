namespace TestFormsApp_Planning
{
    partial class FullOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FullOrder));
            calendar1 = new MindFusion.Scheduling.WinForms.Calendar();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            splitContainer1 = new SplitContainer();
            label10 = new Label();
            label9 = new Label();
            dataGridView2 = new DataGridView();
            orderNoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            customerDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            qtyDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            productNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            deliveryDateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            operationTypeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            operationBindingSource = new BindingSource(components);
            operationBindingSource1 = new BindingSource(components);
            tabControlAdv1 = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            tabPageAdv1 = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            dataGridView1 = new DataGridView();
            orderNoDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            customerDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            qtyDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            ProductName = new DataGridViewTextBoxColumn();
            deliveryDateDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            operationTypeDataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            tabPageAdv2 = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            ((System.ComponentModel.ISupportInitialize)calendar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)operationBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)operationBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tabControlAdv1).BeginInit();
            tabControlAdv1.SuspendLayout();
            tabPageAdv1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPageAdv2.SuspendLayout();
            SuspendLayout();
            // 
            // calendar1
            // 
            calendar1.ContactNameFormat = "F";
            calendar1.CurrentView = MindFusion.Scheduling.WinForms.CalendarView.ResourceView;
            calendar1.CustomDraw = MindFusion.Scheduling.WinForms.CustomDrawElements.ResourceViewCell;
            calendar1.Date = new DateTime(2024, 8, 20, 0, 0, 0, 0);
            calendar1.EndDate = new DateTime(2024, 10, 20, 0, 0, 0, 0);
            calendar1.GroupType = MindFusion.Scheduling.WinForms.GroupType.GroupByContacts;
            calendar1.LicenseKey = null;
            calendar1.Location = new Point(6, 3);
            calendar1.Name = "calendar1";
            calendar1.ResourceViewSettings.AllowResizeRowHeaders = MindFusion.Scheduling.WinForms.State.Enabled;
            calendar1.ResourceViewSettings.LaneSize = 25;
            calendar1.ResourceViewSettings.MaxItemSize = 0;
            calendar1.ResourceViewSettings.RowHeaderSize = 150;
            calendar1.ResourceViewSettings.Style = (MindFusion.Scheduling.Style)resources.GetObject("calendar1.ResourceViewSettings.Style");
            calendar1.ShowToolTips = true;
            calendar1.Size = new Size(904, 363);
            calendar1.TabIndex = 0;
            calendar1.Theme = MindFusion.Scheduling.WinForms.ThemeType.Vista;
            calendar1.ItemTooltipDisplaying += calendar1_ItemTooltipDisplaying;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(6, 35);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 2;
            label1.Text = "Order No :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(115, 35);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 3;
            label2.Text = "10000";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(6, 82);
            label3.Name = "label3";
            label3.Size = new Size(85, 20);
            label3.TabIndex = 4;
            label3.Text = "Customer :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(115, 82);
            label4.Name = "label4";
            label4.Size = new Size(72, 20);
            label4.TabIndex = 5;
            label4.Text = "Customer";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(6, 139);
            label5.Name = "label5";
            label5.Size = new Size(72, 20);
            label5.TabIndex = 6;
            label5.Text = "Product :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(115, 139);
            label6.Name = "label6";
            label6.Size = new Size(64, 20);
            label6.TabIndex = 7;
            label6.Text = "Toy Cars";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.Location = new Point(7, 232);
            label7.Name = "label7";
            label7.Size = new Size(108, 20);
            label7.TabIndex = 8;
            label7.Text = "Delivery Date:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(115, 232);
            label8.Name = "label8";
            label8.Size = new Size(85, 20);
            label8.TabIndex = 9;
            label8.Text = "2024-09-24";
            // 
            // splitContainer1
            // splitContainer1
            // 
            splitContainer1.Location = new Point(6, 12);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = SystemColors.ControlDarkDark;
            splitContainer1.Panel1.Controls.Add(label10);
            splitContainer1.Panel1.Controls.Add(label9);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(label8);
            splitContainer1.Panel1.Controls.Add(label7);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(label4);
            splitContainer1.Panel1.Controls.Add(label6);
            splitContainer1.Panel1.Controls.Add(label5);
            splitContainer1.Panel1.Controls.Add(label3);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(calendar1);
            splitContainer1.Size = new Size(1150, 369);
            splitContainer1.SplitterDistance = 233;
            splitContainer1.TabIndex = 10;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(115, 188);
            label10.Name = "label10";
            label10.Size = new Size(33, 20);
            label10.TabIndex = 11;
            label10.Text = "100";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label9.Location = new Point(7, 188);
            label9.Name = "label9";
            label9.Size = new Size(42, 20);
            label9.TabIndex = 10;
            label9.Text = "Qty :";
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { orderNoDataGridViewTextBoxColumn, customerDataGridViewTextBoxColumn, qtyDataGridViewTextBoxColumn, productNameDataGridViewTextBoxColumn, deliveryDateDataGridViewTextBoxColumn, operationTypeDataGridViewTextBoxColumn });
            dataGridView2.DataSource = operationBindingSource;
            dataGridView2.Dock = DockStyle.Fill;
            dataGridView2.Location = new Point(0, 0);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(1157, 175);
            dataGridView2.TabIndex = 0;
            // 
            // orderNoDataGridViewTextBoxColumn
            // 
            orderNoDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            orderNoDataGridViewTextBoxColumn.DataPropertyName = "OrderNo";
            orderNoDataGridViewTextBoxColumn.HeaderText = "OrderNo";
            orderNoDataGridViewTextBoxColumn.MinimumWidth = 6;
            orderNoDataGridViewTextBoxColumn.Name = "orderNoDataGridViewTextBoxColumn";
            // 
            // customerDataGridViewTextBoxColumn
            // 
            customerDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            customerDataGridViewTextBoxColumn.DataPropertyName = "Customer";
            customerDataGridViewTextBoxColumn.HeaderText = "Customer";
            customerDataGridViewTextBoxColumn.MinimumWidth = 6;
            customerDataGridViewTextBoxColumn.Name = "customerDataGridViewTextBoxColumn";
            // 
            // qtyDataGridViewTextBoxColumn
            // 
            qtyDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            qtyDataGridViewTextBoxColumn.DataPropertyName = "Qty";
            qtyDataGridViewTextBoxColumn.HeaderText = "Qty";
            qtyDataGridViewTextBoxColumn.MinimumWidth = 6;
            qtyDataGridViewTextBoxColumn.Name = "qtyDataGridViewTextBoxColumn";
            // 
            // productNameDataGridViewTextBoxColumn
            // 
            productNameDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            productNameDataGridViewTextBoxColumn.DataPropertyName = "ProductName";
            productNameDataGridViewTextBoxColumn.HeaderText = "Product";
            productNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            productNameDataGridViewTextBoxColumn.Name = "productNameDataGridViewTextBoxColumn";
            // 
            // deliveryDateDataGridViewTextBoxColumn
            // 
            deliveryDateDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            deliveryDateDataGridViewTextBoxColumn.DataPropertyName = "DeliveryDate";
            deliveryDateDataGridViewTextBoxColumn.HeaderText = "DeliveryDate";
            deliveryDateDataGridViewTextBoxColumn.MinimumWidth = 6;
            deliveryDateDataGridViewTextBoxColumn.Name = "deliveryDateDataGridViewTextBoxColumn";
            // 
            // operationTypeDataGridViewTextBoxColumn
            // 
            operationTypeDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            operationTypeDataGridViewTextBoxColumn.DataPropertyName = "OperationType";
            operationTypeDataGridViewTextBoxColumn.HeaderText = "OperationType";
            operationTypeDataGridViewTextBoxColumn.MinimumWidth = 6;
            operationTypeDataGridViewTextBoxColumn.Name = "operationTypeDataGridViewTextBoxColumn";
            // 
            // operationBindingSource
            // 
            operationBindingSource.DataSource = typeof(Classes.Operation);
            // 
            // operationBindingSource1
            // 
            operationBindingSource1.DataSource = typeof(Classes.Operation);
            // 
            // tabControlAdv1
            // 
            tabControlAdv1.BackColor = SystemColors.ControlDark;
            tabControlAdv1.BeforeTouchSize = new Size(1160, 209);
            tabControlAdv1.Controls.Add(tabPageAdv1);
            tabControlAdv1.Controls.Add(tabPageAdv2);
            tabControlAdv1.Dock = DockStyle.Bottom;
            tabControlAdv1.Location = new Point(0, 384);
            tabControlAdv1.Name = "tabControlAdv1";
            tabControlAdv1.Size = new Size(1160, 209);
            tabControlAdv1.TabIndex = 11;
            // 
            // tabPageAdv1
            // 
            tabPageAdv1.BackColor = SystemColors.ActiveCaption;
            tabPageAdv1.Controls.Add(dataGridView1);
            tabPageAdv1.Image = null;
            tabPageAdv1.ImageSize = new Size(20, 20);
            tabPageAdv1.Location = new Point(1, 33);
            tabPageAdv1.Name = "tabPageAdv1";
            tabPageAdv1.ShowCloseButton = true;
            tabPageAdv1.Size = new Size(1157, 175);
            tabPageAdv1.TabIndex = 1;
            tabPageAdv1.Text = "Unscheduled Operations";
            tabPageAdv1.ThemesEnabled = false;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.BackgroundColor = SystemColors.ControlDarkDark;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { orderNoDataGridViewTextBoxColumn1, customerDataGridViewTextBoxColumn1, qtyDataGridViewTextBoxColumn1, ProductName, deliveryDateDataGridViewTextBoxColumn1, operationTypeDataGridViewTextBoxColumn2 });
            dataGridView1.DataSource = operationBindingSource1;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1157, 175);
            dataGridView1.TabIndex = 1;
            // 
            // orderNoDataGridViewTextBoxColumn1
            // 
            orderNoDataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            orderNoDataGridViewTextBoxColumn1.DataPropertyName = "OrderNo";
            orderNoDataGridViewTextBoxColumn1.HeaderText = "OrderNo";
            orderNoDataGridViewTextBoxColumn1.MinimumWidth = 6;
            orderNoDataGridViewTextBoxColumn1.Name = "orderNoDataGridViewTextBoxColumn1";
            // 
            // customerDataGridViewTextBoxColumn1
            // 
            customerDataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            customerDataGridViewTextBoxColumn1.DataPropertyName = "Customer";
            customerDataGridViewTextBoxColumn1.HeaderText = "Customer";
            customerDataGridViewTextBoxColumn1.MinimumWidth = 6;
            customerDataGridViewTextBoxColumn1.Name = "customerDataGridViewTextBoxColumn1";
            // 
            // qtyDataGridViewTextBoxColumn1
            // 
            qtyDataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            qtyDataGridViewTextBoxColumn1.DataPropertyName = "Qty";
            qtyDataGridViewTextBoxColumn1.HeaderText = "Qty";
            qtyDataGridViewTextBoxColumn1.MinimumWidth = 6;
            qtyDataGridViewTextBoxColumn1.Name = "qtyDataGridViewTextBoxColumn1";
            // 
            // ProductName
            // 
            ProductName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ProductName.DataPropertyName = "ProductName";
            ProductName.HeaderText = "Product";
            ProductName.MinimumWidth = 6;
            ProductName.Name = "ProductName";
            // 
            // deliveryDateDataGridViewTextBoxColumn1
            // 
            deliveryDateDataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            deliveryDateDataGridViewTextBoxColumn1.DataPropertyName = "DeliveryDate";
            deliveryDateDataGridViewTextBoxColumn1.HeaderText = "DeliveryDate";
            deliveryDateDataGridViewTextBoxColumn1.MinimumWidth = 6;
            deliveryDateDataGridViewTextBoxColumn1.Name = "deliveryDateDataGridViewTextBoxColumn1";
            // 
            // operationTypeDataGridViewTextBoxColumn2
            // 
            operationTypeDataGridViewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            operationTypeDataGridViewTextBoxColumn2.DataPropertyName = "OperationType";
            operationTypeDataGridViewTextBoxColumn2.HeaderText = "OperationType";
            operationTypeDataGridViewTextBoxColumn2.MinimumWidth = 6;
            operationTypeDataGridViewTextBoxColumn2.Name = "operationTypeDataGridViewTextBoxColumn2";
            // 
            // tabPageAdv2
            // 
            tabPageAdv2.Controls.Add(dataGridView2);
            tabPageAdv2.Image = null;
            tabPageAdv2.ImageSize = new Size(20, 20);
            tabPageAdv2.Location = new Point(1, 33);
            tabPageAdv2.Name = "tabPageAdv2";
            tabPageAdv2.ShowCloseButton = true;
            tabPageAdv2.Size = new Size(1157, 175);
            tabPageAdv2.TabIndex = 2;
            tabPageAdv2.Text = "Scheduled Operations";
            tabPageAdv2.ThemesEnabled = false;
            // 
            // FullOrder
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(1160, 593);
            Controls.Add(tabControlAdv1);
            Controls.Add(splitContainer1);
            MaximizeBox = false;
            Name = "FullOrder";
            StartPosition = FormStartPosition.CenterScreen;
            Text = " ";
            ((System.ComponentModel.ISupportInitialize)calendar1).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)operationBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)operationBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)tabControlAdv1).EndInit();
            tabControlAdv1.ResumeLayout(false);
            tabPageAdv1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabPageAdv2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private MindFusion.Scheduling.WinForms.Calendar calendar1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private SplitContainer splitContainer1;
        private Label label10;
        private Label label9;
        private DataGridView dataGridView2;
        private BindingSource operationBindingSource;
        private BindingSource operationBindingSource1;
        private DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn orderNoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn customerDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn deliveryDateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn operationTypeDataGridViewTextBoxColumn;
        private Syncfusion.Windows.Forms.Tools.TabControlAdv tabControlAdv1;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageAdv1;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageAdv2;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn orderNoDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn customerDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn ProductName;
        private DataGridViewTextBoxColumn deliveryDateDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn operationTypeDataGridViewTextBoxColumn2;
    }
}