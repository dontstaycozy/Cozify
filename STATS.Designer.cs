namespace Cozify
{
    partial class STATS
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblRating = new AntdUI.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pbxRating = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTimesLaunchedCozify = new System.Windows.Forms.Label();
            this.lblTimeSpentCozify = new System.Windows.Forms.Label();
            this.lblNoOfJournalEntries = new System.Windows.Forms.Label();
            this.lblPomoSessionsCompelted = new System.Windows.Forms.Label();
            this.lblTotalTimeSpentPomo = new System.Windows.Forms.Label();
            this.lblTasksAdded = new System.Windows.Forms.Label();
            this.lblTotalTasksCompleted = new System.Windows.Forms.Label();
            this.lblTotalHabitsAdded = new System.Windows.Forms.Label();
            this.lblStatUser = new System.Windows.Forms.Label();
            this.btnDeleteAcc = new AntdUI.Button();
            this.btnClearAcc = new AntdUI.Button();
            this.btnShowStats = new AntdUI.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRating)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(27, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(823, 446);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(474, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(349, 446);
            this.panel2.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblRating);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 296);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(349, 150);
            this.panel4.TabIndex = 3;
            // 
            // lblRating
            // 
            this.lblRating.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRating.Font = new System.Drawing.Font("Pixeltype", 25F);
            this.lblRating.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblRating.Location = new System.Drawing.Point(0, 0);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(349, 41);
            this.lblRating.TabIndex = 0;
            this.lblRating.Text = "label1";
            this.lblRating.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pbxRating);
            this.panel3.Location = new System.Drawing.Point(0, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(349, 313);
            this.panel3.TabIndex = 2;
            // 
            // pbxRating
            // 
            this.pbxRating.Image = global::Cozify.Properties.Resources.ALL_OF_THE_WEIRDEST_ANIMAL_CAFÉS_IN_SEOUL;
            this.pbxRating.Location = new System.Drawing.Point(-194, -35);
            this.pbxRating.Name = "pbxRating";
            this.pbxRating.Size = new System.Drawing.Size(585, 333);
            this.pbxRating.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxRating.TabIndex = 3;
            this.pbxRating.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblTimesLaunchedCozify, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTimeSpentCozify, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblNoOfJournalEntries, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalTimeSpentPomo, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalHabitsAdded, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblTasksAdded, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalTasksCompleted, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblPomoSessionsCompelted, 0, 8);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 12;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(476, 446);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblTimesLaunchedCozify
            // 
            this.lblTimesLaunchedCozify.AutoSize = true;
            this.lblTimesLaunchedCozify.Font = new System.Drawing.Font("Pixeltype", 20F);
            this.lblTimesLaunchedCozify.ForeColor = System.Drawing.Color.White;
            this.lblTimesLaunchedCozify.Location = new System.Drawing.Point(3, 40);
            this.lblTimesLaunchedCozify.Name = "lblTimesLaunchedCozify";
            this.lblTimesLaunchedCozify.Size = new System.Drawing.Size(372, 21);
            this.lblTimesLaunchedCozify.TabIndex = 12;
            this.lblTimesLaunchedCozify.Text = "Number of times Cozify is launched:";
            // 
            // lblTimeSpentCozify
            // 
            this.lblTimeSpentCozify.AutoSize = true;
            this.lblTimeSpentCozify.Font = new System.Drawing.Font("Pixeltype", 20F);
            this.lblTimeSpentCozify.ForeColor = System.Drawing.Color.White;
            this.lblTimeSpentCozify.Location = new System.Drawing.Point(3, 0);
            this.lblTimeSpentCozify.Name = "lblTimeSpentCozify";
            this.lblTimeSpentCozify.Size = new System.Drawing.Size(262, 21);
            this.lblTimeSpentCozify.TabIndex = 11;
            this.lblTimeSpentCozify.Text = "Time spent using Cozify: ";
            // 
            // lblNoOfJournalEntries
            // 
            this.lblNoOfJournalEntries.AutoSize = true;
            this.lblNoOfJournalEntries.Font = new System.Drawing.Font("Pixeltype", 20F);
            this.lblNoOfJournalEntries.ForeColor = System.Drawing.Color.White;
            this.lblNoOfJournalEntries.Location = new System.Drawing.Point(3, 120);
            this.lblNoOfJournalEntries.Name = "lblNoOfJournalEntries";
            this.lblNoOfJournalEntries.Size = new System.Drawing.Size(261, 21);
            this.lblNoOfJournalEntries.TabIndex = 24;
            this.lblNoOfJournalEntries.Text = "Journal Entries Written:";
            // 
            // lblPomoSessionsCompelted
            // 
            this.lblPomoSessionsCompelted.AutoSize = true;
            this.lblPomoSessionsCompelted.Font = new System.Drawing.Font("Pixeltype", 20F);
            this.lblPomoSessionsCompelted.ForeColor = System.Drawing.Color.White;
            this.lblPomoSessionsCompelted.Location = new System.Drawing.Point(3, 320);
            this.lblPomoSessionsCompelted.Name = "lblPomoSessionsCompelted";
            this.lblPomoSessionsCompelted.Size = new System.Drawing.Size(222, 21);
            this.lblPomoSessionsCompelted.TabIndex = 35;
            this.lblPomoSessionsCompelted.Text = "Sessions completed:";
            // 
            // lblTotalTimeSpentPomo
            // 
            this.lblTotalTimeSpentPomo.AutoSize = true;
            this.lblTotalTimeSpentPomo.Font = new System.Drawing.Font("Pixeltype", 20F);
            this.lblTotalTimeSpentPomo.ForeColor = System.Drawing.Color.White;
            this.lblTotalTimeSpentPomo.Location = new System.Drawing.Point(3, 400);
            this.lblTotalTimeSpentPomo.Name = "lblTotalTimeSpentPomo";
            this.lblTotalTimeSpentPomo.Size = new System.Drawing.Size(304, 21);
            this.lblTotalTimeSpentPomo.TabIndex = 36;
            this.lblTotalTimeSpentPomo.Text = "Total time spent on Pomdoro:";
            // 
            // lblTasksAdded
            // 
            this.lblTasksAdded.AutoSize = true;
            this.lblTasksAdded.Font = new System.Drawing.Font("Pixeltype", 20F);
            this.lblTasksAdded.ForeColor = System.Drawing.Color.White;
            this.lblTasksAdded.Location = new System.Drawing.Point(3, 240);
            this.lblTasksAdded.Name = "lblTasksAdded";
            this.lblTasksAdded.Size = new System.Drawing.Size(203, 21);
            this.lblTasksAdded.TabIndex = 29;
            this.lblTasksAdded.Text = "Total tasks added:";
            // 
            // lblTotalTasksCompleted
            // 
            this.lblTotalTasksCompleted.AutoSize = true;
            this.lblTotalTasksCompleted.Font = new System.Drawing.Font("Pixeltype", 20F);
            this.lblTotalTasksCompleted.ForeColor = System.Drawing.Color.White;
            this.lblTotalTasksCompleted.Location = new System.Drawing.Point(3, 280);
            this.lblTotalTasksCompleted.Name = "lblTotalTasksCompleted";
            this.lblTotalTasksCompleted.Size = new System.Drawing.Size(246, 21);
            this.lblTotalTasksCompleted.TabIndex = 30;
            this.lblTotalTasksCompleted.Text = "Total Tasks completed:";
            // 
            // lblTotalHabitsAdded
            // 
            this.lblTotalHabitsAdded.AutoSize = true;
            this.lblTotalHabitsAdded.Font = new System.Drawing.Font("Pixeltype", 20F);
            this.lblTotalHabitsAdded.ForeColor = System.Drawing.Color.White;
            this.lblTotalHabitsAdded.Location = new System.Drawing.Point(3, 200);
            this.lblTotalHabitsAdded.Name = "lblTotalHabitsAdded";
            this.lblTotalHabitsAdded.Size = new System.Drawing.Size(213, 21);
            this.lblTotalHabitsAdded.TabIndex = 34;
            this.lblTotalHabitsAdded.Text = "Total Habits added: ";
            // 
            // lblStatUser
            // 
            this.lblStatUser.AutoSize = true;
            this.lblStatUser.Font = new System.Drawing.Font("Pixeltype", 26F);
            this.lblStatUser.ForeColor = System.Drawing.Color.White;
            this.lblStatUser.Location = new System.Drawing.Point(22, 21);
            this.lblStatUser.Name = "lblStatUser";
            this.lblStatUser.Size = new System.Drawing.Size(279, 27);
            this.lblStatUser.TabIndex = 2;
            this.lblStatUser.Text = "Username\'s Activity";
            // 
            // btnDeleteAcc
            // 
            this.btnDeleteAcc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteAcc.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.btnDeleteAcc.Font = new System.Drawing.Font("Pixeltype", 22F);
            this.btnDeleteAcc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDeleteAcc.Location = new System.Drawing.Point(721, 523);
            this.btnDeleteAcc.Name = "btnDeleteAcc";
            this.btnDeleteAcc.Size = new System.Drawing.Size(129, 65);
            this.btnDeleteAcc.TabIndex = 9;
            this.btnDeleteAcc.Text = "Delete\r\n Account";
            this.btnDeleteAcc.Click += new System.EventHandler(this.btnDeleteAcc_Click);
            // 
            // btnClearAcc
            // 
            this.btnClearAcc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearAcc.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.btnClearAcc.Font = new System.Drawing.Font("Pixeltype", 22F);
            this.btnClearAcc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClearAcc.Location = new System.Drawing.Point(574, 523);
            this.btnClearAcc.Name = "btnClearAcc";
            this.btnClearAcc.Size = new System.Drawing.Size(141, 65);
            this.btnClearAcc.TabIndex = 10;
            this.btnClearAcc.Text = "Clear Data";
            this.btnClearAcc.Click += new System.EventHandler(this.btnClearAcc_Click);
            // 
            // btnShowStats
            // 
            this.btnShowStats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowStats.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.btnShowStats.Font = new System.Drawing.Font("Pixeltype", 22F);
            this.btnShowStats.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnShowStats.Location = new System.Drawing.Point(427, 523);
            this.btnShowStats.Name = "btnShowStats";
            this.btnShowStats.Size = new System.Drawing.Size(141, 65);
            this.btnShowStats.TabIndex = 11;
            this.btnShowStats.Text = "Show Stats";
            this.btnShowStats.Click += new System.EventHandler(this.btnShowStats_Click);
            // 
            // STATS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.ClientSize = new System.Drawing.Size(880, 600);
            this.Controls.Add(this.btnShowStats);
            this.Controls.Add(this.btnClearAcc);
            this.Controls.Add(this.btnDeleteAcc);
            this.Controls.Add(this.lblStatUser);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "STATS";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "STATS";
            this.Load += new System.EventHandler(this.STATS_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxRating)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblStatUser;
        private AntdUI.Button btnDeleteAcc;
        private AntdUI.Button btnClearAcc;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblTimeSpentCozify;
        private System.Windows.Forms.Label lblTimesLaunchedCozify;
        private AntdUI.Button btnShowStats;
        private System.Windows.Forms.Label lblTotalTasksCompleted;
        private System.Windows.Forms.Label lblTasksAdded;
        private System.Windows.Forms.Label lblNoOfJournalEntries;
        private System.Windows.Forms.Label lblTotalTimeSpentPomo;
        private System.Windows.Forms.Label lblTotalHabitsAdded;
        private System.Windows.Forms.Label lblPomoSessionsCompelted;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pbxRating;
        private AntdUI.Label lblRating;
    }
}