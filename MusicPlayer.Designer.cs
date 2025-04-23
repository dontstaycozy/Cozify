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
            this.dgvTracksInPlaylist = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lvwPlaylists = new System.Windows.Forms.ListView();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label1 = new AntdUI.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnDeletePlaylist = new AntdUI.Button();
            this.btnSavePlaylist = new AntdUI.Button();
            this.btnEditTrack = new AntdUI.Button();
            this.btnAddTrack = new AntdUI.Button();
            this.btnMakePlaylist = new AntdUI.Button();
            this.btnDeleteTrack = new AntdUI.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTracksInPlaylist)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.panel1.Controls.Add(this.dgvTracksInPlaylist);
            this.panel1.Location = new System.Drawing.Point(330, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(754, 477);
            this.panel1.TabIndex = 1;
            // 
            // dgvTracksInPlaylist
            // 
            this.dgvTracksInPlaylist.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.dgvTracksInPlaylist.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTracksInPlaylist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTracksInPlaylist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTracksInPlaylist.Location = new System.Drawing.Point(0, 0);
            this.dgvTracksInPlaylist.Name = "dgvTracksInPlaylist";
            this.dgvTracksInPlaylist.RowHeadersWidth = 51;
            this.dgvTracksInPlaylist.RowTemplate.Height = 24;
            this.dgvTracksInPlaylist.Size = new System.Drawing.Size(754, 477);
            this.dgvTracksInPlaylist.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.panel2.Controls.Add(this.lvwPlaylists);
            this.panel2.Controls.Add(this.panel10);
            this.panel2.Controls.Add(this.panel9);
            this.panel2.Location = new System.Drawing.Point(38, 124);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(254, 479);
            this.panel2.TabIndex = 15;
            // 
            // lvwPlaylists
            // 
            this.lvwPlaylists.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.lvwPlaylists.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvwPlaylists.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwPlaylists.Font = new System.Drawing.Font("Pixeltype", 22F);
            this.lvwPlaylists.ForeColor = System.Drawing.Color.White;
            this.lvwPlaylists.HideSelection = false;
            this.lvwPlaylists.Location = new System.Drawing.Point(0, 43);
            this.lvwPlaylists.Name = "lvwPlaylists";
            this.lvwPlaylists.Size = new System.Drawing.Size(254, 388);
            this.lvwPlaylists.TabIndex = 10;
            this.lvwPlaylists.UseCompatibleStateImageBehavior = false;
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
            this.label1.Text = "Playlists";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.btnDeletePlaylist);
            this.panel9.Controls.Add(this.btnSavePlaylist);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel9.Location = new System.Drawing.Point(0, 431);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(254, 48);
            this.panel9.TabIndex = 5;
            // 
            // btnDeletePlaylist
            // 
            this.btnDeletePlaylist.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.btnDeletePlaylist.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDeletePlaylist.Font = new System.Drawing.Font("Pixeltype", 22F);
            this.btnDeletePlaylist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDeletePlaylist.Location = new System.Drawing.Point(138, 0);
            this.btnDeletePlaylist.Name = "btnDeletePlaylist";
            this.btnDeletePlaylist.Size = new System.Drawing.Size(116, 48);
            this.btnDeletePlaylist.TabIndex = 8;
            this.btnDeletePlaylist.Text = "Delete";
            this.btnDeletePlaylist.Click += new System.EventHandler(this.btnDeletePlaylist_Click);
            // 
            // btnSavePlaylist
            // 
            this.btnSavePlaylist.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.btnSavePlaylist.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSavePlaylist.Font = new System.Drawing.Font("Pixeltype", 22F);
            this.btnSavePlaylist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSavePlaylist.Location = new System.Drawing.Point(0, 0);
            this.btnSavePlaylist.Name = "btnSavePlaylist";
            this.btnSavePlaylist.Size = new System.Drawing.Size(116, 48);
            this.btnSavePlaylist.TabIndex = 7;
            this.btnSavePlaylist.Text = "Save";
            this.btnSavePlaylist.Click += new System.EventHandler(this.btnSavePlaylist_Click);
            // 
            // btnEditTrack
            // 
            this.btnEditTrack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditTrack.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.btnEditTrack.Font = new System.Drawing.Font("Pixeltype", 22F);
            this.btnEditTrack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnEditTrack.Location = new System.Drawing.Point(796, 538);
            this.btnEditTrack.Name = "btnEditTrack";
            this.btnEditTrack.Size = new System.Drawing.Size(141, 65);
            this.btnEditTrack.TabIndex = 16;
            this.btnEditTrack.Text = "Edit";
            this.btnEditTrack.Click += new System.EventHandler(this.btnEditTrack_Click);
            // 
            // btnAddTrack
            // 
            this.btnAddTrack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddTrack.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.btnAddTrack.Font = new System.Drawing.Font("Pixeltype", 22F);
            this.btnAddTrack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAddTrack.Location = new System.Drawing.Point(943, 538);
            this.btnAddTrack.Name = "btnAddTrack";
            this.btnAddTrack.Size = new System.Drawing.Size(141, 65);
            this.btnAddTrack.TabIndex = 17;
            this.btnAddTrack.Text = "Add Track";
            this.btnAddTrack.Click += new System.EventHandler(this.btnAddTrack_Click);
            // 
            // btnMakePlaylist
            // 
            this.btnMakePlaylist.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.btnMakePlaylist.Font = new System.Drawing.Font("Pixeltype", 22F);
            this.btnMakePlaylist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnMakePlaylist.Icon = global::Cozify.Properties.Resources.Plus;
            this.btnMakePlaylist.Location = new System.Drawing.Point(38, 41);
            this.btnMakePlaylist.Name = "btnMakePlaylist";
            this.btnMakePlaylist.Size = new System.Drawing.Size(254, 60);
            this.btnMakePlaylist.TabIndex = 18;
            this.btnMakePlaylist.Text = "Create Playlist";
            this.btnMakePlaylist.Click += new System.EventHandler(this.btnMakePlaylist_Click);
            // 
            // btnDeleteTrack
            // 
            this.btnDeleteTrack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteTrack.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.btnDeleteTrack.Font = new System.Drawing.Font("Pixeltype", 22F);
            this.btnDeleteTrack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDeleteTrack.Location = new System.Drawing.Point(649, 538);
            this.btnDeleteTrack.Name = "btnDeleteTrack";
            this.btnDeleteTrack.Size = new System.Drawing.Size(141, 65);
            this.btnDeleteTrack.TabIndex = 19;
            this.btnDeleteTrack.Text = "Delete";
            this.btnDeleteTrack.Click += new System.EventHandler(this.btnDeleteTrack_Click);
            // 
            // MusicPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.ClientSize = new System.Drawing.Size(1119, 626);
            this.Controls.Add(this.btnDeleteTrack);
            this.Controls.Add(this.btnMakePlaylist);
            this.Controls.Add(this.btnAddTrack);
            this.Controls.Add(this.btnEditTrack);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(800, 450);
            this.Name = "MusicPlayer";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MusicPlayer";
            this.Load += new System.EventHandler(this.MusicPlayer_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTracksInPlaylist)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lvwPlaylists;
        private System.Windows.Forms.Panel panel10;
        private AntdUI.Label label1;
        private System.Windows.Forms.Panel panel9;
        private AntdUI.Button btnDeletePlaylist;
        private AntdUI.Button btnSavePlaylist;
        private System.Windows.Forms.DataGridView dgvTracksInPlaylist;
        private AntdUI.Button btnEditTrack;
        private AntdUI.Button btnAddTrack;
        private AntdUI.Button btnMakePlaylist;
        private AntdUI.Button btnDeleteTrack;
    }
}