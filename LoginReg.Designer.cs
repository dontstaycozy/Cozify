namespace Cozify
{
    partial class LoginReg
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
            this.label4 = new AntdUI.Label();
            this.label3 = new AntdUI.Label();
            this.btnLogin = new AntdUI.Button();
            this.tbxPasswordLogin = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbxUsernameLogin = new System.Windows.Forms.TextBox();
            this.btnRevealLoginPass = new System.Windows.Forms.Button();
            this.btnGoBackToRegister = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Pixeltype", 20F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label4.Location = new System.Drawing.Point(112, 452);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 23);
            this.label4.TabIndex = 26;
            this.label4.Text = "Password";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Pixeltype", 20F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label3.Location = new System.Drawing.Point(112, 339);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 23);
            this.label3.TabIndex = 25;
            this.label3.Text = "Username";
            // 
            // btnLogin
            // 
            this.btnLogin.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(204)))), ((int)(((byte)(219)))));
            this.btnLogin.Font = new System.Drawing.Font("Pixeltype", 22F);
            this.btnLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnLogin.Location = new System.Drawing.Point(166, 567);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(262, 60);
            this.btnLogin.TabIndex = 24;
            this.btnLogin.Text = "Login";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // tbxPasswordLogin
            // 
            this.tbxPasswordLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(204)))), ((int)(((byte)(219)))));
            this.tbxPasswordLogin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxPasswordLogin.Font = new System.Drawing.Font("Pixeltype", 22F);
            this.tbxPasswordLogin.ForeColor = System.Drawing.Color.White;
            this.tbxPasswordLogin.Location = new System.Drawing.Point(11, 19);
            this.tbxPasswordLogin.Margin = new System.Windows.Forms.Padding(1);
            this.tbxPasswordLogin.Name = "tbxPasswordLogin";
            this.tbxPasswordLogin.Size = new System.Drawing.Size(347, 23);
            this.tbxPasswordLogin.TabIndex = 31;
            this.tbxPasswordLogin.UseSystemPasswordChar = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(204)))), ((int)(((byte)(219)))));
            this.panel1.Controls.Add(this.tbxPasswordLogin);
            this.panel1.Location = new System.Drawing.Point(112, 479);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(374, 62);
            this.panel1.TabIndex = 32;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(204)))), ((int)(((byte)(219)))));
            this.panel2.Controls.Add(this.tbxUsernameLogin);
            this.panel2.Location = new System.Drawing.Point(112, 367);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(374, 62);
            this.panel2.TabIndex = 33;
            // 
            // tbxUsernameLogin
            // 
            this.tbxUsernameLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(204)))), ((int)(((byte)(219)))));
            this.tbxUsernameLogin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxUsernameLogin.Font = new System.Drawing.Font("Pixeltype", 22F);
            this.tbxUsernameLogin.ForeColor = System.Drawing.Color.White;
            this.tbxUsernameLogin.Location = new System.Drawing.Point(11, 19);
            this.tbxUsernameLogin.Margin = new System.Windows.Forms.Padding(1);
            this.tbxUsernameLogin.Name = "tbxUsernameLogin";
            this.tbxUsernameLogin.Size = new System.Drawing.Size(347, 23);
            this.tbxUsernameLogin.TabIndex = 31;
            // 
            // btnRevealLoginPass
            // 
            this.btnRevealLoginPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRevealLoginPass.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRevealLoginPass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRevealLoginPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRevealLoginPass.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRevealLoginPass.Image = global::Cozify.Properties.Resources.Closed_Eye;
            this.btnRevealLoginPass.Location = new System.Drawing.Point(405, 433);
            this.btnRevealLoginPass.Margin = new System.Windows.Forms.Padding(1);
            this.btnRevealLoginPass.Name = "btnRevealLoginPass";
            this.btnRevealLoginPass.Size = new System.Drawing.Size(81, 44);
            this.btnRevealLoginPass.TabIndex = 30;
            this.btnRevealLoginPass.UseVisualStyleBackColor = false;
            this.btnRevealLoginPass.Click += new System.EventHandler(this.btnRevealLoginPass_Click);
            // 
            // btnGoBackToRegister
            // 
            this.btnGoBackToRegister.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnGoBackToRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoBackToRegister.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnGoBackToRegister.Image = global::Cozify.Properties.Resources.Open_Door1;
            this.btnGoBackToRegister.Location = new System.Drawing.Point(8, 8);
            this.btnGoBackToRegister.Margin = new System.Windows.Forms.Padding(1);
            this.btnGoBackToRegister.Name = "btnGoBackToRegister";
            this.btnGoBackToRegister.Size = new System.Drawing.Size(58, 62);
            this.btnGoBackToRegister.TabIndex = 28;
            this.btnGoBackToRegister.UseVisualStyleBackColor = false;
            this.btnGoBackToRegister.Click += new System.EventHandler(this.btnGoBackToRegister_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cozify.Properties.Resources._004208_theres_a_cat_on_my_hat;
            this.pictureBox1.Location = new System.Drawing.Point(123, 86);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(358, 204);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // LoginReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(580, 639);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnRevealLoginPass);
            this.Controls.Add(this.btnGoBackToRegister);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginReg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginReg";
            this.Load += new System.EventHandler(this.LoginReg_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private AntdUI.Label label4;
        private AntdUI.Label label3;
        private AntdUI.Button btnLogin;
        private System.Windows.Forms.Button btnGoBackToRegister;
        private System.Windows.Forms.Button btnRevealLoginPass;
        private System.Windows.Forms.TextBox tbxPasswordLogin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbxUsernameLogin;
    }
}