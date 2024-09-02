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
            panel1 = new Panel();
            button1 = new Button();
            button3 = new MindFusion.UI.WinForms.Button();
            button2 = new MindFusion.UI.WinForms.Button();
            calendar1 = new MindFusion.Scheduling.WinForms.Calendar();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)calendar1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button1);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(calendar1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1104, 584);
            panel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(412, 455);
            button1.Name = "button1";
            button1.Size = new Size(221, 54);
            button1.TabIndex = 4;
            button1.Text = "Create Holiday";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
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
            button3.Location = new Point(639, 455);
            button3.Name = "button3";
            button3.Size = new Size(236, 54);
            button3.TabIndex = 3;
            button3.Text = "Create Machine";
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
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
            button2.Location = new Point(881, 455);
            button2.Name = "button2";
            button2.Size = new Size(211, 54);
            button2.TabIndex = 2;
            button2.Text = "Create Task";
            button2.Click += button2_Click;
            // 
            // calendar1
            // 
            calendar1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            calendar1.ContactNameFormat = "F";
            calendar1.CurrentView = MindFusion.Scheduling.WinForms.CalendarView.ResourceView;
            calendar1.Date = new DateTime(2024, 8, 27, 0, 0, 0, 0);
            calendar1.EndDate = new DateTime(2024, 9, 26, 0, 0, 0, 0);
            calendar1.GroupType = MindFusion.Scheduling.WinForms.GroupType.GroupByContacts;
            calendar1.ItemSettings.MoveBandSize = 2;
            calendar1.LicenseKey = null;
            calendar1.Location = new Point(-12, 0);
            calendar1.Name = "calendar1";
            calendar1.ShowToolTips = true;
            calendar1.Size = new Size(1104, 431);
            calendar1.TabIndex = 0;
            calendar1.Theme = MindFusion.Scheduling.WinForms.ThemeType.Light;
            calendar1.DateClick += calendar1_DateClick;
            calendar1.ItemModified += calendar1_ItemModified;
            calendar1.ItemDrawing += calendar1_ItemDrawing;
            calendar1.Draw += calendar1_Draw;
            // 
            // Scheduler
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1104, 584);
            Controls.Add(panel1);
            Name = "Scheduler";
            Text = "Scheduler";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)calendar1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private MindFusion.Scheduling.WinForms.Calendar calendar1;
        private MindFusion.UI.WinForms.Button button2;
        private MindFusion.UI.WinForms.Button button3;
        private Button button1;
    }
}