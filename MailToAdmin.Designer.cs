namespace Cozify
{
    partial class MailToAdmin
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
            this.tbxMessage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxEmailClient = new System.Windows.Forms.TextBox();
            this.lblUserMailConcern = new AntdUI.Label();
            this.btnSendMail = new AntdUI.Button();
            this.label2 = new AntdUI.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbxMessage);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbxEmailClient);
            this.panel1.Location = new System.Drawing.Point(26, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(807, 443);
            this.panel1.TabIndex = 3;
            // 
            // tbxMessage
            // 
            this.tbxMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.tbxMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxMessage.Font = new System.Drawing.Font("Pixeltype", 23F);
            this.tbxMessage.ForeColor = System.Drawing.Color.White;
            this.tbxMessage.Location = new System.Drawing.Point(25, 119);
            this.tbxMessage.Multiline = true;
            this.tbxMessage.Name = "tbxMessage";
            this.tbxMessage.Size = new System.Drawing.Size(761, 297);
            this.tbxMessage.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Pixeltype", 22F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(21, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Email:";
            // 
            // tbxEmailClient
            // 
            this.tbxEmailClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.tbxEmailClient.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxEmailClient.Font = new System.Drawing.Font("Pixeltype", 25F);
            this.tbxEmailClient.ForeColor = System.Drawing.Color.White;
            this.tbxEmailClient.Location = new System.Drawing.Point(98, 22);
            this.tbxEmailClient.Name = "tbxEmailClient";
            this.tbxEmailClient.Size = new System.Drawing.Size(512, 27);
            this.tbxEmailClient.TabIndex = 3;
            // 
            // lblUserMailConcern
            // 
            this.lblUserMailConcern.Font = new System.Drawing.Font("Pixeltype", 32F);
            this.lblUserMailConcern.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblUserMailConcern.Location = new System.Drawing.Point(26, 12);
            this.lblUserMailConcern.Name = "lblUserMailConcern";
            this.lblUserMailConcern.Size = new System.Drawing.Size(821, 51);
            this.lblUserMailConcern.TabIndex = 4;
            this.lblUserMailConcern.Text = "";
            // 
            // btnSendMail
            // 
            this.btnSendMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendMail.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.btnSendMail.Font = new System.Drawing.Font("Pixeltype", 22F);
            this.btnSendMail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSendMail.Location = new System.Drawing.Point(692, 518);
            this.btnSendMail.Name = "btnSendMail";
            this.btnSendMail.Size = new System.Drawing.Size(141, 65);
            this.btnSendMail.TabIndex = 15;
            this.btnSendMail.Text = "Send";
            this.btnSendMail.Click += new System.EventHandler(this.btnSendMail_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Pixeltype", 22F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(25, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(761, 51);
            this.label2.TabIndex = 8;
            this.label2.Text = "What is your concern?";
            // 
            // MailToAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.ClientSize = new System.Drawing.Size(859, 595);
            this.Controls.Add(this.btnSendMail);
            this.Controls.Add(this.lblUserMailConcern);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MailToAdmin";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MailToAdmin";
            this.Load += new System.EventHandler(this.MailToAdmin_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbxMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxEmailClient;
        private AntdUI.Label lblUserMailConcern;
        private AntdUI.Button btnSendMail;
        private AntdUI.Label label2;
    }
}