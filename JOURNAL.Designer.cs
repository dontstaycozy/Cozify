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
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJournalEntries)).BeginInit();
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
    }
}