namespace finals
{
    partial class JOURNAL
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
            this.lviewJournalEntries = new System.Windows.Forms.ListView();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label1 = new AntdUI.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnSaveEntry = new AntdUI.Button();
            this.btnDeleteEntry = new AntdUI.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tbxEntryTitle = new System.Windows.Forms.TextBox();
            this.tbxDateWritten = new AntdUI.Label();
            this.lblEntryTitle = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.tbxJournalContent = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblAuthorNameForJournal = new System.Windows.Forms.Label();
            this.btnAddJournalEntry = new AntdUI.Button();
            this.panel1.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.panel1.Controls.Add(this.lviewJournalEntries);
            this.panel1.Controls.Add(this.panel10);
            this.panel1.Controls.Add(this.panel9);
            this.panel1.Location = new System.Drawing.Point(27, 136);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(254, 478);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.JOURNAL_MouseDown);
            // 
            // lviewJournalEntries
            // 
            this.lviewJournalEntries.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.lviewJournalEntries.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lviewJournalEntries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lviewJournalEntries.Font = new System.Drawing.Font("Pixeltype", 22F);
            this.lviewJournalEntries.ForeColor = System.Drawing.Color.White;
            this.lviewJournalEntries.HideSelection = false;
            this.lviewJournalEntries.Location = new System.Drawing.Point(0, 43);
            this.lviewJournalEntries.Name = "lviewJournalEntries";
            this.lviewJournalEntries.Size = new System.Drawing.Size(254, 387);
            this.lviewJournalEntries.TabIndex = 10;
            this.lviewJournalEntries.UseCompatibleStateImageBehavior = false;
            this.lviewJournalEntries.SelectedIndexChanged += new System.EventHandler(this.lviewJournalEntries_SelectedIndexChanged);
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.label1);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(254, 43);
            this.panel10.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Pixeltype", 22F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 43);
            this.label1.TabIndex = 6;
            this.label1.Text = "Entries";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.btnSaveEntry);
            this.panel9.Controls.Add(this.btnDeleteEntry);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel9.Location = new System.Drawing.Point(0, 430);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(254, 48);
            this.panel9.TabIndex = 5;
            // 
            // btnSaveEntry
            // 
            this.btnSaveEntry.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.btnSaveEntry.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSaveEntry.Font = new System.Drawing.Font("Pixeltype", 22F);
            this.btnSaveEntry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSaveEntry.Location = new System.Drawing.Point(138, 0);
            this.btnSaveEntry.Name = "btnSaveEntry";
            this.btnSaveEntry.Size = new System.Drawing.Size(116, 48);
            this.btnSaveEntry.TabIndex = 8;
            this.btnSaveEntry.Text = "Save";
            this.btnSaveEntry.Click += new System.EventHandler(this.btnSaveEntry_Click);
            // 
            // btnDeleteEntry
            // 
            this.btnDeleteEntry.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.btnDeleteEntry.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDeleteEntry.Font = new System.Drawing.Font("Pixeltype", 22F);
            this.btnDeleteEntry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDeleteEntry.Location = new System.Drawing.Point(0, 0);
            this.btnDeleteEntry.Name = "btnDeleteEntry";
            this.btnDeleteEntry.Size = new System.Drawing.Size(116, 48);
            this.btnDeleteEntry.TabIndex = 7;
            this.btnDeleteEntry.Text = "Delete\r\n";
            this.btnDeleteEntry.Click += new System.EventHandler(this.btnDeleteEntry_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.lblEntryTitle);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 23);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(722, 48);
            this.panel3.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.panel6.Controls.Add(this.tbxEntryTitle);
            this.panel6.Controls.Add(this.tbxDateWritten);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(722, 60);
            this.panel6.TabIndex = 3;
            // 
            // tbxEntryTitle
            // 
            this.tbxEntryTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.tbxEntryTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxEntryTitle.Font = new System.Drawing.Font("Pixeltype", 28F);
            this.tbxEntryTitle.ForeColor = System.Drawing.Color.White;
            this.tbxEntryTitle.Location = new System.Drawing.Point(19, 7);
            this.tbxEntryTitle.Name = "tbxEntryTitle";
            this.tbxEntryTitle.Size = new System.Drawing.Size(424, 30);
            this.tbxEntryTitle.TabIndex = 0;
            this.tbxEntryTitle.Text = "Enter Title";
            // 
            // tbxDateWritten
            // 
            this.tbxDateWritten.Dock = System.Windows.Forms.DockStyle.Right;
            this.tbxDateWritten.Font = new System.Drawing.Font("Pixeltype", 22F);
            this.tbxDateWritten.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tbxDateWritten.Location = new System.Drawing.Point(449, 0);
            this.tbxDateWritten.Name = "tbxDateWritten";
            this.tbxDateWritten.Size = new System.Drawing.Size(273, 60);
            this.tbxDateWritten.TabIndex = 1;
            this.tbxDateWritten.Text = "";
            this.tbxDateWritten.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEntryTitle
            // 
            this.lblEntryTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.lblEntryTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblEntryTitle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblEntryTitle.Font = new System.Drawing.Font("Pixeltype", 33F);
            this.lblEntryTitle.ForeColor = System.Drawing.Color.White;
            this.lblEntryTitle.Location = new System.Drawing.Point(0, 13);
            this.lblEntryTitle.Name = "lblEntryTitle";
            this.lblEntryTitle.Size = new System.Drawing.Size(722, 35);
            this.lblEntryTitle.TabIndex = 0;
            this.lblEntryTitle.Text = "(Insert Entry\'s title ";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 524);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(722, 25);
            this.panel4.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(722, 23);
            this.panel5.TabIndex = 5;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 71);
            this.panel7.Margin = new System.Windows.Forms.Padding(2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(19, 453);
            this.panel7.TabIndex = 6;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(703, 71);
            this.panel8.Margin = new System.Windows.Forms.Padding(2);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(19, 453);
            this.panel8.TabIndex = 7;
            // 
            // tbxJournalContent
            // 
            this.tbxJournalContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.tbxJournalContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxJournalContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxJournalContent.Font = new System.Drawing.Font("Pixeltype", 18F);
            this.tbxJournalContent.ForeColor = System.Drawing.Color.White;
            this.tbxJournalContent.Location = new System.Drawing.Point(19, 71);
            this.tbxJournalContent.Multiline = true;
            this.tbxJournalContent.Name = "tbxJournalContent";
            this.tbxJournalContent.Size = new System.Drawing.Size(684, 453);
            this.tbxJournalContent.TabIndex = 8;
            this.tbxJournalContent.Text = "Write something....";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.panel2.Controls.Add(this.tbxJournalContent);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Location = new System.Drawing.Point(313, 65);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(722, 549);
            this.panel2.TabIndex = 1;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.JOURNAL_MouseDown);
            // 
            // lblAuthorNameForJournal
            // 
            this.lblAuthorNameForJournal.AutoSize = true;
            this.lblAuthorNameForJournal.Font = new System.Drawing.Font("Pixeltype", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuthorNameForJournal.ForeColor = System.Drawing.Color.White;
            this.lblAuthorNameForJournal.Location = new System.Drawing.Point(12, 15);
            this.lblAuthorNameForJournal.Name = "lblAuthorNameForJournal";
            this.lblAuthorNameForJournal.Size = new System.Drawing.Size(485, 37);
            this.lblAuthorNameForJournal.TabIndex = 2;
            this.lblAuthorNameForJournal.Text = "(insert author)\'s journal";
            this.lblAuthorNameForJournal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.JOURNAL_MouseDown);
            // 
            // btnAddJournalEntry
            // 
            this.btnAddJournalEntry.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.btnAddJournalEntry.Font = new System.Drawing.Font("Pixeltype", 22F);
            this.btnAddJournalEntry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAddJournalEntry.Icon = global::Cozify.Properties.Resources.Plus;
            this.btnAddJournalEntry.Location = new System.Drawing.Point(27, 65);
            this.btnAddJournalEntry.Name = "btnAddJournalEntry";
            this.btnAddJournalEntry.Size = new System.Drawing.Size(254, 60);
            this.btnAddJournalEntry.TabIndex = 4;
            this.btnAddJournalEntry.Text = "Write Something!";
            this.btnAddJournalEntry.Click += new System.EventHandler(this.btnAddJournalEntry_Click);
            this.btnAddJournalEntry.MouseDown += new System.Windows.Forms.MouseEventHandler(this.JOURNAL_MouseDown);
            // 
            // JOURNAL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.ClientSize = new System.Drawing.Size(1067, 648);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnAddJournalEntry);
            this.Controls.Add(this.lblAuthorNameForJournal);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "JOURNAL";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.JOURNAL_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.JOURNAL_MouseDown);
            this.panel1.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lviewJournalEntries;
        private System.Windows.Forms.Panel panel10;
        private AntdUI.Label label1;
        private System.Windows.Forms.Panel panel9;
        private AntdUI.Button btnSaveEntry;
        private AntdUI.Button btnDeleteEntry;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel6;
        private AntdUI.Label tbxDateWritten;
        private System.Windows.Forms.TextBox tbxEntryTitle;
        private System.Windows.Forms.TextBox lblEntryTitle;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox tbxJournalContent;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblAuthorNameForJournal;
        private AntdUI.Button btnAddJournalEntry;
    }
}