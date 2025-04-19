namespace Cozify
{
    partial class MusicPlayer
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
            this.lviewPlaylist = new System.Windows.Forms.ListView();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label1 = new AntdUI.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnSaveEntry = new AntdUI.Button();
            this.btnDeleteEntry = new AntdUI.Button();
            this.button2 = new AntdUI.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button3 = new AntdUI.Button();
            this.btnAddJournalEntry = new AntdUI.Button();
            this.button1 = new AntdUI.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(330, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(754, 477);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.panel2.Controls.Add(this.lviewPlaylist);
            this.panel2.Controls.Add(this.panel10);
            this.panel2.Controls.Add(this.panel9);
            this.panel2.Location = new System.Drawing.Point(38, 124);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(254, 479);
            this.panel2.TabIndex = 15;
            // 
            // lviewPlaylist
            // 
            this.lviewPlaylist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.lviewPlaylist.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lviewPlaylist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lviewPlaylist.Font = new System.Drawing.Font("Pixeltype", 22F);
            this.lviewPlaylist.ForeColor = System.Drawing.Color.White;
            this.lviewPlaylist.HideSelection = false;
            this.lviewPlaylist.Location = new System.Drawing.Point(0, 43);
            this.lviewPlaylist.Name = "lviewPlaylist";
            this.lviewPlaylist.Size = new System.Drawing.Size(254, 388);
            this.lviewPlaylist.TabIndex = 10;
            this.lviewPlaylist.UseCompatibleStateImageBehavior = false;
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
            this.panel9.Location = new System.Drawing.Point(0, 431);
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
            this.btnSaveEntry.Text = "Delete";
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
            this.btnDeleteEntry.Text = "Save";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.button2.Font = new System.Drawing.Font("Pixeltype", 22F);
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button2.Location = new System.Drawing.Point(796, 538);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(141, 65);
            this.button2.TabIndex = 16;
            this.button2.Text = "Edit";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(754, 477);
            this.dataGridView1.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.button3.Font = new System.Drawing.Font("Pixeltype", 22F);
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button3.Location = new System.Drawing.Point(943, 538);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(141, 65);
            this.button3.TabIndex = 17;
            this.button3.Text = "Add Track";
            // 
            // btnAddJournalEntry
            // 
            this.btnAddJournalEntry.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.btnAddJournalEntry.Font = new System.Drawing.Font("Pixeltype", 22F);
            this.btnAddJournalEntry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAddJournalEntry.Icon = global::Cozify.Properties.Resources.Plus;
            this.btnAddJournalEntry.Location = new System.Drawing.Point(38, 41);
            this.btnAddJournalEntry.Name = "btnAddJournalEntry";
            this.btnAddJournalEntry.Size = new System.Drawing.Size(254, 60);
            this.btnAddJournalEntry.TabIndex = 18;
            this.btnAddJournalEntry.Text = "Create Playlist";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.button1.Font = new System.Drawing.Font("Pixeltype", 22F);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button1.Location = new System.Drawing.Point(649, 538);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 65);
            this.button1.TabIndex = 19;
            this.button1.Text = "Delete";
            // 
            // MusicPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.ClientSize = new System.Drawing.Size(1119, 626);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAddJournalEntry);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(800, 450);
            this.Name = "MusicPlayer";
            this.Text = "MusicPlayer";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lviewPlaylist;
        private System.Windows.Forms.Panel panel10;
        private AntdUI.Label label1;
        private System.Windows.Forms.Panel panel9;
        private AntdUI.Button btnSaveEntry;
        private AntdUI.Button btnDeleteEntry;
        private System.Windows.Forms.DataGridView dataGridView1;
        private AntdUI.Button button2;
        private AntdUI.Button button3;
        private AntdUI.Button btnAddJournalEntry;
        private AntdUI.Button button1;
    }
}