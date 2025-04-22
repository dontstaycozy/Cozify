namespace Cozify
{
    partial class ANALYTICS
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
            this.btnHabitStreak = new AntdUI.Button();
            this.btnPomoUsage = new AntdUI.Button();
            this.btnTasksDoneThisWeek = new AntdUI.Button();
            this.pnlChartContainer = new System.Windows.Forms.Panel();
            this.btnCloseAnalytics = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnHabitStreak
            // 
            this.btnHabitStreak.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHabitStreak.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.btnHabitStreak.Font = new System.Drawing.Font("Pixeltype", 22F);
            this.btnHabitStreak.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnHabitStreak.Location = new System.Drawing.Point(764, 573);
            this.btnHabitStreak.Name = "btnHabitStreak";
            this.btnHabitStreak.Size = new System.Drawing.Size(170, 65);
            this.btnHabitStreak.TabIndex = 12;
            this.btnHabitStreak.Text = "Habit Streak";
            this.btnHabitStreak.Click += new System.EventHandler(this.btnHabitStreak_Click);
            // 
            // btnPomoUsage
            // 
            this.btnPomoUsage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPomoUsage.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.btnPomoUsage.Font = new System.Drawing.Font("Pixeltype", 22F);
            this.btnPomoUsage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnPomoUsage.Location = new System.Drawing.Point(379, 573);
            this.btnPomoUsage.Name = "btnPomoUsage";
            this.btnPomoUsage.Size = new System.Drawing.Size(217, 65);
            this.btnPomoUsage.TabIndex = 13;
            this.btnPomoUsage.Text = "Pomodoro Usage";
            this.btnPomoUsage.Click += new System.EventHandler(this.btnPomoUsage_Click);
            // 
            // btnTasksDoneThisWeek
            // 
            this.btnTasksDoneThisWeek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTasksDoneThisWeek.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.btnTasksDoneThisWeek.Font = new System.Drawing.Font("Pixeltype", 22F);
            this.btnTasksDoneThisWeek.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnTasksDoneThisWeek.Location = new System.Drawing.Point(602, 573);
            this.btnTasksDoneThisWeek.Name = "btnTasksDoneThisWeek";
            this.btnTasksDoneThisWeek.Size = new System.Drawing.Size(156, 65);
            this.btnTasksDoneThisWeek.TabIndex = 14;
            this.btnTasksDoneThisWeek.Text = "Tasks Done";
            this.btnTasksDoneThisWeek.Click += new System.EventHandler(this.btnTasksDoneThisWeek_Click);
            // 
            // pnlChartContainer
            // 
            this.pnlChartContainer.Location = new System.Drawing.Point(26, 21);
            this.pnlChartContainer.Name = "pnlChartContainer";
            this.pnlChartContainer.Size = new System.Drawing.Size(908, 525);
            this.pnlChartContainer.TabIndex = 15;
            // 
            // btnCloseAnalytics
            // 
            this.btnCloseAnalytics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.btnCloseAnalytics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseAnalytics.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.btnCloseAnalytics.Image = global::Cozify.Properties.Resources.Back_Arrow;
            this.btnCloseAnalytics.Location = new System.Drawing.Point(26, 568);
            this.btnCloseAnalytics.Margin = new System.Windows.Forms.Padding(1);
            this.btnCloseAnalytics.Name = "btnCloseAnalytics";
            this.btnCloseAnalytics.Size = new System.Drawing.Size(81, 70);
            this.btnCloseAnalytics.TabIndex = 25;
            this.btnCloseAnalytics.UseVisualStyleBackColor = false;
            this.btnCloseAnalytics.Click += new System.EventHandler(this.btnCloseAnalytics_Click);
            // 
            // ANALYTICS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.ClientSize = new System.Drawing.Size(962, 650);
            this.Controls.Add(this.btnCloseAnalytics);
            this.Controls.Add(this.pnlChartContainer);
            this.Controls.Add(this.btnTasksDoneThisWeek);
            this.Controls.Add(this.btnPomoUsage);
            this.Controls.Add(this.btnHabitStreak);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ANALYTICS";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ANALYTICS";
            this.ResumeLayout(false);

        }

        #endregion
        private AntdUI.Button btnHabitStreak;
        private AntdUI.Button btnPomoUsage;
        private AntdUI.Button btnTasksDoneThisWeek;
        private System.Windows.Forms.Panel pnlChartContainer;
        private System.Windows.Forms.Button btnCloseAnalytics;
    }
}