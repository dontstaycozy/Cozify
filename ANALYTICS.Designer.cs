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
            this.btn = new AntdUI.Button();
            this.pnlChartContainer = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnHabitStreak
            // 
            this.btnHabitStreak.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHabitStreak.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.btnHabitStreak.Font = new System.Drawing.Font("Pixeltype", 22F);
            this.btnHabitStreak.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnHabitStreak.Location = new System.Drawing.Point(411, 462);
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
            this.btnPomoUsage.Location = new System.Drawing.Point(26, 462);
            this.btnPomoUsage.Name = "btnPomoUsage";
            this.btnPomoUsage.Size = new System.Drawing.Size(217, 65);
            this.btnPomoUsage.TabIndex = 13;
            this.btnPomoUsage.Text = "Pomodoro Usage";
            this.btnPomoUsage.Click += new System.EventHandler(this.btnPomoUsage_Click);
            // 
            // btn
            // 
            this.btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.btn.Font = new System.Drawing.Font("Pixeltype", 22F);
            this.btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn.Location = new System.Drawing.Point(249, 462);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(156, 65);
            this.btn.TabIndex = 14;
            this.btn.Text = "Tasks Done";
            this.btn.Click += new System.EventHandler(this.btnTasksDoneWeek);
            // 
            // pnlChartContainer
            // 
            this.pnlChartContainer.Location = new System.Drawing.Point(12, 12);
            this.pnlChartContainer.Name = "pnlChartContainer";
            this.pnlChartContainer.Size = new System.Drawing.Size(822, 444);
            this.pnlChartContainer.TabIndex = 15;
            // 
            // ANALYTICS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.ClientSize = new System.Drawing.Size(846, 539);
            this.Controls.Add(this.pnlChartContainer);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.btnPomoUsage);
            this.Controls.Add(this.btnHabitStreak);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ANALYTICS";
            this.Text = "ANALYTICS";
            this.ResumeLayout(false);

        }

        #endregion
        private AntdUI.Button btnHabitStreak;
        private AntdUI.Button btnPomoUsage;
        private AntdUI.Button btn;
        private System.Windows.Forms.Panel pnlChartContainer;
    }
}