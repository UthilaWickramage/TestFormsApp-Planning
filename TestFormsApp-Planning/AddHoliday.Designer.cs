namespace TestFormsApp_Planning
{
    partial class AddHoliday
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
            panel1 = new Panel();
            comboBox1 = new ComboBox();
            label4 = new Label();
            button1 = new MindFusion.UI.WinForms.Button();
            dateTimePicker1 = new DateTimePicker();
            textBox1 = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Lavender;
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(dateTimePicker1);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(650, 370);
            panel1.TabIndex = 0;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(146, 229);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(441, 28);
            comboBox1.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 227);
            label4.Name = "label4";
            label4.Size = new Size(130, 28);
            label4.TabIndex = 7;
            label4.Text = "WorkStation :";
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
            button1.Location = new Point(402, 294);
            button1.Name = "button1";
            button1.Size = new Size(185, 37);
            button1.TabIndex = 5;
            button1.Text = "Save";
            button1.Click += button1_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(146, 160);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(441, 27);
            dateTimePicker1.TabIndex = 4;
            dateTimePicker1.Value = new DateTime(2024, 9, 2, 0, 0, 0, 0);
            // 
            // textBox1
            // 
            textBox1.Location = new Point(146, 86);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(441, 27);
            textBox1.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 160);
            label3.Name = "label3";
            label3.Size = new Size(62, 28);
            label3.TabIndex = 2;
            label3.Text = "Date :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 82);
            label2.Name = "label2";
            label2.Size = new Size(89, 28);
            label2.TabIndex = 1;
            label2.Text = "Holiday :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(191, 38);
            label1.TabIndex = 0;
            label1.Text = "Add a Holiday";
            // 
            // AddHoliday
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(650, 370);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "AddHoliday";
            Text = "Add Holiday";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox textBox1;
        private Label label3;
        private Label label2;
        private Label label1;
        private MindFusion.UI.WinForms.Button button1;
        private DateTimePicker dateTimePicker1;
        private Label label4;
        private ComboBox comboBox1;
    }
}