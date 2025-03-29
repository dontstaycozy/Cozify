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
            this.listView1 = new System.Windows.Forms.ListView();
            this.dgvJournalEntries = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblAuthorNameForJournal = new System.Windows.Forms.Label();
            this.btnAddJournalEntry = new AntdUI.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblEntryTitle = new System.Windows.Forms.TextBox();
            this.btnSaveEntry = new AntdUI.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new AntdUI.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJournalEntries)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Controls.Add(this.dgvJournalEntries);
            this.panel1.Location = new System.Drawing.Point(27, 136);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(254, 478);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.JOURNAL_MouseDown);
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(254, 478);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // dgvJournalEntries
            // 
            this.dgvJournalEntries.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.dgvJournalEntries.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvJournalEntries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJournalEntries.Location = new System.Drawing.Point(3, 3);
            this.dgvJournalEntries.Name = "dgvJournalEntries";
            this.dgvJournalEntries.RowHeadersWidth = 51;
            this.dgvJournalEntries.RowTemplate.Height = 24;
            this.dgvJournalEntries.Size = new System.Drawing.Size(251, 475);
            this.dgvJournalEntries.TabIndex = 0;
            this.dgvJournalEntries.MouseDown += new System.Windows.Forms.MouseEventHandler(this.JOURNAL_MouseDown);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
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
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.lblEntryTitle);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(722, 48);
            this.panel3.TabIndex = 2;
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
            // btnSaveEntry
            // 
            this.btnSaveEntry.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.btnSaveEntry.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSaveEntry.Font = new System.Drawing.Font("Pixeltype", 22F);
            this.btnSaveEntry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSaveEntry.Location = new System.Drawing.Point(606, 0);
            this.btnSaveEntry.Name = "btnSaveEntry";
            this.btnSaveEntry.Size = new System.Drawing.Size(116, 48);
            this.btnSaveEntry.TabIndex = 5;
            this.btnSaveEntry.Text = "Save";
            this.btnSaveEntry.Click += new System.EventHandler(this.btnSaveEntry_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.panel4.Controls.Add(this.btnSaveEntry);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 501);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(722, 48);
            this.panel4.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 48);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(722, 23);
            this.panel5.TabIndex = 5;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.textBox1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(722, 48);
            this.panel6.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Pixeltype", 28F);
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(3, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(716, 30);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "(Insert Entry\'s title ";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 71);
            this.panel7.Margin = new System.Windows.Forms.Padding(2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(19, 430);
            this.panel7.TabIndex = 6;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(703, 71);
            this.panel8.Margin = new System.Windows.Forms.Padding(2);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(19, 430);
            this.panel8.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Font = new System.Drawing.Font("Pixeltype", 18F);
            this.textBox2.ForeColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(19, 71);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(684, 430);
            this.textBox2.TabIndex = 8;
            this.textBox2.Text = "RANDOM BAGGAGE AND DIARY NETRIES HERE ONG";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("Pixeltype", 22F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(449, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 48);
            this.label1.TabIndex = 1;
            this.label1.Text = "March 23, 2025";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // JOURNAL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.ClientSize = new System.Drawing.Size(1067, 648);
            this.Controls.Add(this.btnAddJournalEntry);
            this.Controls.Add(this.lblAuthorNameForJournal);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "JOURNAL";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.JOURNAL_MouseDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJournalEntries)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblAuthorNameForJournal;
        private System.Windows.Forms.DataGridView dgvJournalEntries;
        private AntdUI.Button btnAddJournalEntry;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox lblEntryTitle;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private AntdUI.Button btnSaveEntry;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox textBox1;
        private AntdUI.Label label1;
    }
}