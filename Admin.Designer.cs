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
            this.dgvAdminView = new System.Windows.Forms.DataGridView();
            this.btnAdminClearAccData = new AntdUI.Button();
            this.btnAdminDeleteAcc = new AntdUI.Button();
            this.btnAdminUpdateAcc = new AntdUI.Button();
            this.btnGoBackToLogin = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdminView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.panel1.Controls.Add(this.dgvAdminView);
            this.panel1.Location = new System.Drawing.Point(166, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(677, 457);
            this.panel1.TabIndex = 1;
            // 
            // dgvAdminView
            // 
            this.dgvAdminView.AllowUserToAddRows = false;
            this.dgvAdminView.AllowUserToResizeColumns = false;
            this.dgvAdminView.AllowUserToResizeRows = false;
            this.dgvAdminView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAdminView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.dgvAdminView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvAdminView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdminView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAdminView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.dgvAdminView.Location = new System.Drawing.Point(0, 0);
            this.dgvAdminView.Name = "dgvAdminView";
            this.dgvAdminView.RowHeadersWidth = 51;
            this.dgvAdminView.RowTemplate.Height = 24;
            this.dgvAdminView.Size = new System.Drawing.Size(677, 457);
            this.dgvAdminView.TabIndex = 0;
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
            // btnGoBackToLogin
            // 
            this.btnGoBackToLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.btnGoBackToLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoBackToLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.btnGoBackToLogin.Image = global::Cozify.Properties.Resources.Open_Door1;
            this.btnGoBackToLogin.Location = new System.Drawing.Point(54, 461);
            this.btnGoBackToLogin.Margin = new System.Windows.Forms.Padding(1);
            this.btnGoBackToLogin.Name = "btnGoBackToLogin";
            this.btnGoBackToLogin.Size = new System.Drawing.Size(58, 62);
            this.btnGoBackToLogin.TabIndex = 29;
            this.btnGoBackToLogin.UseVisualStyleBackColor = false;
            this.btnGoBackToLogin.Click += new System.EventHandler(this.btnGoBackToLogin_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.ClientSize = new System.Drawing.Size(862, 553);
            this.Controls.Add(this.btnGoBackToLogin);
            this.Controls.Add(this.btnAdminUpdateAcc);
            this.Controls.Add(this.btnAdminClearAccData);
            this.Controls.Add(this.btnAdminDeleteAcc);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin";
            this.Load += new System.EventHandler(this.Admin_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdminView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private AntdUI.Button btnAdminClearAccData;
        private AntdUI.Button btnAdminDeleteAcc;
        private AntdUI.Button btnAdminUpdateAcc;
        private System.Windows.Forms.DataGridView dgvAdminView;
        private System.Windows.Forms.Button btnGoBackToLogin;
    }
}