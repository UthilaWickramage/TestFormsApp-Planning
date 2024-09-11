namespace TestFormsApp_Planning
{
    partial class SetCustomHours
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetCustomHours));
            panel1 = new Panel();
            button1 = new Button();
            textBox1 = new TextBox();
            dateTimePicker3 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            dateTimePicker1 = new DateTimePicker();
            comboBox1 = new ComboBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label7 = new Label();
            textBox2 = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.AliceBlue;
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(dateTimePicker3);
            panel1.Controls.Add(dateTimePicker2);
            panel1.Controls.Add(dateTimePicker1);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(652, 523);
            panel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(445, 461);
            button1.Name = "button1";
            button1.Size = new Size(154, 39);
            button1.TabIndex = 11;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Enabled = false;
            textBox1.Location = new Point(179, 321);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(420, 27);
            textBox1.TabIndex = 10;
            textBox1.Text = "8";
            // 
            // dateTimePicker3
            // 
            dateTimePicker3.Location = new Point(179, 260);
            dateTimePicker3.Name = "dateTimePicker3";
            dateTimePicker3.Size = new Size(420, 27);
            dateTimePicker3.TabIndex = 9;
            dateTimePicker3.Value = new DateTime(2024, 9, 10, 16, 0, 0, 0);
            dateTimePicker3.ValueChanged += dateTimePicker3_ValueChanged;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(179, 192);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(420, 27);
            dateTimePicker2.TabIndex = 8;
            dateTimePicker2.Value = new DateTime(2024, 9, 10, 8, 0, 0, 0);
            dateTimePicker2.ValueChanged += dateTimePicker2_ValueChanged;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(179, 135);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(420, 27);
            dateTimePicker1.TabIndex = 7;
            dateTimePicker1.Value = new DateTime(2024, 9, 10, 0, 0, 0, 0);
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(179, 78);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(420, 28);
            comboBox1.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(12, 316);
            label6.Name = "label6";
            label6.Size = new Size(128, 28);
            label6.TabIndex = 5;
            label6.Text = "No of Hours :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(12, 258);
            label5.Name = "label5";
            label5.Size = new Size(101, 28);
            label5.TabIndex = 4;
            label5.Text = "End Time :";
            label5.Click += label5_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(12, 190);
            label4.Name = "label4";
            label4.Size = new Size(109, 28);
            label4.TabIndex = 3;
            label4.Text = "Start Time :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(12, 133);
            label3.Name = "label3";
            label3.Size = new Size(62, 28);
            label3.TabIndex = 2;
            label3.Text = "Date :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(12, 78);
            label2.Name = "label2";
            label2.Size = new Size(128, 28);
            label2.TabIndex = 1;
            label2.Text = "Workstation :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(265, 41);
            label1.TabIndex = 0;
            label1.Text = "Set Custom Hours";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(12, 382);
            label7.Name = "label7";
            label7.Size = new Size(126, 28);
            label7.TabIndex = 12;
            label7.Text = "Description : ";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(179, 383);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(420, 27);
            textBox2.TabIndex = 13;
            // 
            // SetCustomHours
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(652, 523);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SetCustomHours";
            Text = "SetCustomHours";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label6;
        private Button button1;
        private TextBox textBox1;
        private DateTimePicker dateTimePicker3;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private ComboBox comboBox1;
        private TextBox textBox2;
        private Label label7;
    }
}