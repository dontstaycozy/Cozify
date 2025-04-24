namespace finals
{
    partial class POMODORO
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
            this.label2 = new AntdUI.Label();
            this.numBreak = new System.Windows.Forms.NumericUpDown();
            this.label1 = new AntdUI.Label();
            this.numSession = new System.Windows.Forms.NumericUpDown();
            this.label6 = new AntdUI.Label();
            this.titlePomo = new AntdUI.Label();
            this.tblLayoutPomo = new System.Windows.Forms.TableLayoutPanel();
            this.btnResetPomo = new System.Windows.Forms.Button();
            this.btnStartPomo = new System.Windows.Forms.Button();
            this.lblTimer = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PomoMSG = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBreak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSession)).BeginInit();
            this.tblLayoutPomo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.numBreak);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.numSession);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(25, 226);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(387, 139);
            this.panel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Pixeltype", 23F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(161, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 35);
            this.label2.TabIndex = 11;
            this.label2.Text = "minute breaks";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numBreak
            // 
            this.numBreak.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.numBreak.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numBreak.Font = new System.Drawing.Font("Pixeltype", 25F);
            this.numBreak.ForeColor = System.Drawing.SystemColors.Window;
            this.numBreak.Location = new System.Drawing.Point(110, 71);
            this.numBreak.Name = "numBreak";
            this.numBreak.Size = new System.Drawing.Size(53, 30);
            this.numBreak.TabIndex = 10;
            this.numBreak.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Pixeltype", 23F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(19, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 35);
            this.label1.TabIndex = 9;
            this.label1.Text = "with";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numSession
            // 
            this.numSession.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.numSession.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numSession.Font = new System.Drawing.Font("Pixeltype", 25F);
            this.numSession.ForeColor = System.Drawing.SystemColors.Window;
            this.numSession.Location = new System.Drawing.Point(56, 21);
            this.numSession.Name = "numSession";
            this.numSession.Size = new System.Drawing.Size(55, 30);
            this.numSession.TabIndex = 8;
            this.numSession.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Pixeltype", 23F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label6.Location = new System.Drawing.Point(117, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(221, 35);
            this.label6.TabIndex = 7;
            this.label6.Text = "minute sessions";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // titlePomo
            // 
            this.titlePomo.Font = new System.Drawing.Font("Pixeltype", 25F);
            this.titlePomo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.titlePomo.Location = new System.Drawing.Point(12, 34);
            this.titlePomo.Name = "titlePomo";
            this.titlePomo.Size = new System.Drawing.Size(275, 35);
            this.titlePomo.TabIndex = 12;
            this.titlePomo.Text = "Pomodoro Timer";
            // 
            // tblLayoutPomo
            // 
            this.tblLayoutPomo.ColumnCount = 2;
            this.tblLayoutPomo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLayoutPomo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLayoutPomo.Controls.Add(this.btnResetPomo, 0, 0);
            this.tblLayoutPomo.Controls.Add(this.btnStartPomo, 1, 0);
            this.tblLayoutPomo.Location = new System.Drawing.Point(160, 387);
            this.tblLayoutPomo.Name = "tblLayoutPomo";
            this.tblLayoutPomo.RowCount = 1;
            this.tblLayoutPomo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayoutPomo.Size = new System.Drawing.Size(127, 67);
            this.tblLayoutPomo.TabIndex = 15;
            // 
            // btnResetPomo
            // 
            this.btnResetPomo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnResetPomo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetPomo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.btnResetPomo.Image = global::Cozify.Properties.Resources.Reset;
            this.btnResetPomo.Location = new System.Drawing.Point(3, 3);
            this.btnResetPomo.Name = "btnResetPomo";
            this.btnResetPomo.Size = new System.Drawing.Size(57, 61);
            this.btnResetPomo.TabIndex = 13;
            this.btnResetPomo.UseVisualStyleBackColor = true;
            this.btnResetPomo.Click += new System.EventHandler(this.btnResetPomo_Click);
            // 
            // btnStartPomo
            // 
            this.btnStartPomo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStartPomo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartPomo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.btnStartPomo.Image = global::Cozify.Properties.Resources.Circled_Play1;
            this.btnStartPomo.Location = new System.Drawing.Point(66, 3);
            this.btnStartPomo.Name = "btnStartPomo";
            this.btnStartPomo.Size = new System.Drawing.Size(58, 61);
            this.btnStartPomo.TabIndex = 14;
            this.btnStartPomo.UseVisualStyleBackColor = true;
            this.btnStartPomo.Click += new System.EventHandler(this.btnStartPomo_Click);
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Pixeltype", 30F);
            this.lblTimer.ForeColor = System.Drawing.Color.White;
            this.lblTimer.Location = new System.Drawing.Point(303, 34);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(109, 31);
            this.lblTimer.TabIndex = 16;
            this.lblTimer.Text = "00: 00";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cozify.Properties.Resources.bits_8bits;
            this.pictureBox1.Location = new System.Drawing.Point(277, 101);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(111, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // PomoMSG
            // 
            this.PomoMSG.AutoSize = true;
            this.PomoMSG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PomoMSG.Font = new System.Drawing.Font("Pixeltype", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PomoMSG.ForeColor = System.Drawing.Color.White;
            this.PomoMSG.Location = new System.Drawing.Point(0, 0);
            this.PomoMSG.Name = "PomoMSG";
            this.PomoMSG.Size = new System.Drawing.Size(197, 26);
            this.PomoMSG.TabIndex = 18;
            this.PomoMSG.Text = "You got this!  ><";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.PomoMSG);
            this.panel2.Location = new System.Drawing.Point(44, 101);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 100);
            this.panel2.TabIndex = 19;
            // 
            // POMODORO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.ClientSize = new System.Drawing.Size(440, 477);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.tblLayoutPomo);
            this.Controls.Add(this.titlePomo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "POMODORO";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "POMODORO";
            this.Load += new System.EventHandler(this.POMODORO_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numBreak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSession)).EndInit();
            this.tblLayoutPomo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

                }

                #endregion
        private System.Windows.Forms.Panel panel1;
        private AntdUI.Label label6;
        private AntdUI.Label label1;
        private System.Windows.Forms.NumericUpDown numSession;
        private AntdUI.Label label2;
        private System.Windows.Forms.NumericUpDown numBreak;
        private AntdUI.Label titlePomo;
        private System.Windows.Forms.Button btnResetPomo;
        private System.Windows.Forms.Button btnStartPomo;
        private System.Windows.Forms.TableLayoutPanel tblLayoutPomo;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label PomoMSG;
        private System.Windows.Forms.Panel panel2;
    }
}