namespace Cozify
{
    partial class Admin
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
            this.btnAdminClearAccData = new AntdUI.Button();
            this.btnAdminDeleteAcc = new AntdUI.Button();
            this.btnAdminUpdateAcc = new AntdUI.Button();
            this.btnSaveList = new System.Windows.Forms.Button();
            this.dgvAdmin = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdmin)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.panel1.Controls.Add(this.dgvAdmin);
            this.panel1.Location = new System.Drawing.Point(166, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(677, 457);
            this.panel1.TabIndex = 1;
            // 
            // btnAdminClearAccData
            // 
            this.btnAdminClearAccData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdminClearAccData.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.btnAdminClearAccData.Font = new System.Drawing.Font("Pixeltype", 22F);
            this.btnAdminClearAccData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAdminClearAccData.Location = new System.Drawing.Point(12, 66);
            this.btnAdminClearAccData.Name = "btnAdminClearAccData";
            this.btnAdminClearAccData.Size = new System.Drawing.Size(141, 65);
            this.btnAdminClearAccData.TabIndex = 13;
            this.btnAdminClearAccData.Text = "Clear Data";
            this.btnAdminClearAccData.Click += new System.EventHandler(this.btnAdminClearAccData_Click);
            // 
            // btnAdminDeleteAcc
            // 
            this.btnAdminDeleteAcc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdminDeleteAcc.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.btnAdminDeleteAcc.Font = new System.Drawing.Font("Pixeltype", 22F);
            this.btnAdminDeleteAcc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAdminDeleteAcc.Location = new System.Drawing.Point(12, 137);
            this.btnAdminDeleteAcc.Name = "btnAdminDeleteAcc";
            this.btnAdminDeleteAcc.Size = new System.Drawing.Size(141, 65);
            this.btnAdminDeleteAcc.TabIndex = 12;
            this.btnAdminDeleteAcc.Text = "Delete\r\n Account";
            this.btnAdminDeleteAcc.Click += new System.EventHandler(this.btnAdminDeleteAcc_Click);
            // 
            // btnAdminUpdateAcc
            // 
            this.btnAdminUpdateAcc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdminUpdateAcc.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.btnAdminUpdateAcc.Font = new System.Drawing.Font("Pixeltype", 22F);
            this.btnAdminUpdateAcc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAdminUpdateAcc.Location = new System.Drawing.Point(12, 208);
            this.btnAdminUpdateAcc.Name = "btnAdminUpdateAcc";
            this.btnAdminUpdateAcc.Size = new System.Drawing.Size(141, 65);
            this.btnAdminUpdateAcc.TabIndex = 14;
            this.btnAdminUpdateAcc.Text = "Update";
            this.btnAdminUpdateAcc.Click += new System.EventHandler(this.btnAdminUpdateAcc_Click);
            // 
            // btnSaveList
            // 
            this.btnSaveList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.btnSaveList.Image = global::Cozify.Properties.Resources.Mail;
            this.btnSaveList.Location = new System.Drawing.Point(51, 463);
            this.btnSaveList.Name = "btnSaveList";
            this.btnSaveList.Size = new System.Drawing.Size(62, 60);
            this.btnSaveList.TabIndex = 15;
            this.btnSaveList.UseVisualStyleBackColor = true;
            this.btnSaveList.Click += new System.EventHandler(this.btnSaveList_Click);
            // 
            // dgvAdmin
            // 
            this.dgvAdmin.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.dgvAdmin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAdmin.Location = new System.Drawing.Point(0, 0);
            this.dgvAdmin.Name = "dgvAdmin";
            this.dgvAdmin.RowHeadersWidth = 51;
            this.dgvAdmin.RowTemplate.Height = 24;
            this.dgvAdmin.Size = new System.Drawing.Size(677, 457);
            this.dgvAdmin.TabIndex = 0;
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.ClientSize = new System.Drawing.Size(862, 553);
            this.Controls.Add(this.btnSaveList);
            this.Controls.Add(this.btnAdminUpdateAcc);
            this.Controls.Add(this.btnAdminClearAccData);
            this.Controls.Add(this.btnAdminDeleteAcc);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdmin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private AntdUI.Button btnAdminClearAccData;
        private AntdUI.Button btnAdminDeleteAcc;
        private AntdUI.Button btnAdminUpdateAcc;
        private System.Windows.Forms.Button btnSaveList;
        private System.Windows.Forms.DataGridView dgvAdmin;
    }
}