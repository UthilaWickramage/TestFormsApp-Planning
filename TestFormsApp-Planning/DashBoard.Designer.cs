namespace TestFormsApp_Planning
{
    partial class DashBoard
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
            splitContainer1 = new SplitContainer();
            panel1 = new Panel();
            checkBox1 = new CheckBox();
            calendar1 = new MindFusion.Scheduling.WinForms.Calendar();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)calendar1).BeginInit();
            SuspendLayout();
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
            splitContainer1.Panel1.Controls.Add(panel1);
            splitContainer1.Panel1.Controls.Add(calendar1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.Pink;
            splitContainer1.Size = new Size(1093, 670);
            splitContainer1.SplitterDistance = 463;
            splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(checkBox1);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 334);
            panel1.Name = "panel1";
            panel1.Size = new Size(1093, 129);
            panel1.TabIndex = 1;
            // 
            // checkBox1
            // 
            checkBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(949, 3);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(138, 24);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "View Full Screen";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // calendar1
            // 
            calendar1.CurrentView = MindFusion.Scheduling.WinForms.CalendarView.ResourceView;
            calendar1.Date = new DateTime(2024, 9, 3, 0, 0, 0, 0);
            calendar1.Dock = DockStyle.Fill;
            calendar1.EndDate = new DateTime(2024, 10, 3, 0, 0, 0, 0);
            calendar1.LicenseKey = null;
            calendar1.Location = new Point(0, 0);
            calendar1.Name = "calendar1";
            calendar1.Size = new Size(1093, 463);
            calendar1.TabIndex = 0;
            // 
            // DashBoard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1093, 670);
            Controls.Add(splitContainer1);
            Name = "DashBoard";
            Text = "DashBoard";
            splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)calendar1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private MindFusion.Scheduling.WinForms.Calendar calendar1;
        private Panel panel1;
        private CheckBox checkBox1;
    }
}