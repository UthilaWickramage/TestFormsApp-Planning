namespace TestFormsApp_Planning
{
    partial class AddTask
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
            dockPanel1 = new MindFusion.UI.WinForms.DockPanel();
            panel1 = new Panel();
            numericUpDown1 = new NumericUpDown();
            label1 = new Label();
            label5 = new Label();
            comboBox1 = new ComboBox();
            button1 = new MindFusion.UI.WinForms.Button();
            label4 = new Label();
            label3 = new Label();
            dateTimePicker1 = new DateTimePicker();
            textBox1 = new TextBox();
            label2 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // dockPanel1
            // 
            dockPanel1.DockControl = null;
            dockPanel1.DockSize = new SizeF(0F, 0F);
            dockPanel1.DockStyle = DockStyle.None;
            dockPanel1.Location = new Point(0, 0);
            dockPanel1.MeasureLocation = new Point(0, 0);
            dockPanel1.MeasureSize = new Size(0, 0);
            dockPanel1.Name = "dockPanel1";
            dockPanel1.OldDockParent = null;
            dockPanel1.OldDockSize = new SizeF(0F, 0F);
            dockPanel1.OldDockStyle = DockStyle.None;
            dockPanel1.OldForm = null;
            dockPanel1.OldLocation = new Point(0, 0);
            dockPanel1.OldRootDockStyle = DockStyle.None;
            dockPanel1.Size = new Size(94, 29);
            dockPanel1.TabIndex = 0;
            dockPanel1.TempMeasureSize = new SizeF(0F, 0F);
            dockPanel1.TempSize = new SizeF(0F, 0F);
            dockPanel1.Text = "dockPanel1";
            // 
            // panel1
            // 
            panel1.Controls.Add(numericUpDown1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(dateTimePicker1);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(612, 450);
            panel1.TabIndex = 1;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(144, 224);
            numericUpDown1.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(279, 27);
            numericUpDown1.TabIndex = 18;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 90);
            label1.Name = "label1";
            label1.Size = new Size(109, 28);
            label1.TabIndex = 17;
            label1.Text = "Task Name:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(12, 292);
            label5.Name = "label5";
            label5.Size = new Size(99, 28);
            label5.TabIndex = 16;
            label5.Text = "Resource :";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(144, 292);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(279, 28);
            comboBox1.TabIndex = 15;
            // 
            // button1
            // 
            button1.BackgroundBrush = new MindFusion.Drawing.SolidBrush("#FFF0F0F0");
            button1.BackgroundBrushDisabled = new MindFusion.Drawing.SolidBrush("#FFDEDEDE");
            button1.BackgroundBrushDown = new MindFusion.Drawing.SolidBrush("#FFAEAEAE");
            button1.BackgroundBrushOver = new MindFusion.Drawing.SolidBrush("#FFC5C5C5");
            button1.BorderBrush = new MindFusion.Drawing.SolidBrush("#FFA6A6A6");
            button1.BorderBrushDisabled = new MindFusion.Drawing.SolidBrush("#FFA6A6A6");
            button1.BorderBrushDown = new MindFusion.Drawing.SolidBrush("#FF777777");
            button1.BorderBrushOver = new MindFusion.Drawing.SolidBrush("#FFA6A6A6");
            button1.BorderThickness = 0;
            button1.ForegroundBrush = new MindFusion.Drawing.SolidBrush("#FF000000");
            button1.ForegroundBrushDisabled = new MindFusion.Drawing.SolidBrush("#FF777777");
            button1.ForegroundBrushDown = new MindFusion.Drawing.SolidBrush("#FF000000");
            button1.ForegroundBrushOver = new MindFusion.Drawing.SolidBrush("#FF000000");
            button1.Location = new Point(342, 383);
            button1.Name = "button1";
            button1.Size = new Size(218, 42);
            button1.TabIndex = 14;
            button1.Text = "Add Task";
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 219);
            label4.Name = "label4";
            label4.Size = new Size(92, 28);
            label4.TabIndex = 12;
            label4.Text = "Quantity:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 149);
            label3.Name = "label3";
            label3.Size = new Size(109, 28);
            label3.TabIndex = 11;
            label3.Text = "Start Time :";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(144, 153);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker1.Size = new Size(279, 27);
            dateTimePicker1.TabIndex = 10;
            dateTimePicker1.Value = new DateTime(2024, 9, 2, 0, 0, 0, 0);
            // 
            // textBox1
            // 
            textBox1.Location = new Point(144, 90);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(416, 27);
            textBox1.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(170, 41);
            label2.TabIndex = 8;
            label2.Text = "Add a Task";
            // 
            // AddTask
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(612, 450);
            Controls.Add(panel1);
            Controls.Add(dockPanel1);
            Name = "AddTask";
            Text = "AddTask";
            Load += AddTask_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private MindFusion.UI.WinForms.DockPanel dockPanel1;
        private Panel panel1;
        private Label label4;
        private Label label3;
        private DateTimePicker dateTimePicker1;
        private TextBox textBox1;
        private Label label2;
        private MindFusion.UI.WinForms.Button button1;
        private Label label5;
        private ComboBox comboBox1;
        private Label label1;
        private NumericUpDown numericUpDown1;
    }
}