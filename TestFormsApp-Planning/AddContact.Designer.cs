namespace TestFormsApp_Planning
{
    partial class AddContact
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
            numericUpDown1 = new NumericUpDown();
            label3 = new Label();
            button1 = new MindFusion.UI.WinForms.Button();
            textBox1 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Lavender;
            panel1.Controls.Add(numericUpDown1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(703, 237);
            panel1.TabIndex = 0;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(198, 148);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(493, 27);
            numericUpDown1.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 148);
            label3.Name = "label3";
            label3.Size = new Size(172, 28);
            label3.TabIndex = 4;
            label3.Text = "Capacity Per Hour:";
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
            button1.Location = new Point(516, 186);
            button1.Name = "button1";
            button1.Size = new Size(175, 44);
            button1.TabIndex = 3;
            button1.Text = "Add WorkStation";
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(198, 92);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(493, 27);
            textBox1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(283, 41);
            label2.TabIndex = 1;
            label2.Text = "Add a Workstation";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 89);
            label1.Name = "label1";
            label1.Size = new Size(187, 28);
            label1.TabIndex = 0;
            label1.Text = "WorkStation Name :";
            // 
            // AddContact
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(703, 237);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "AddContact";
            Text = "Add Workstation";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private Label label1;
        private TextBox textBox1;
        private MindFusion.UI.WinForms.Button button1;
        private NumericUpDown numericUpDown1;
        private Label label3;
    }
}