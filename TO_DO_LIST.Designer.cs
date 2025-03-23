namespace finals
{
    partial class TO_DO_LIST
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClearList = new System.Windows.Forms.Button();
            this.btnAddToDoEntry = new AntdUI.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(12, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(327, 528);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(303, 90);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Pixeltype", 24F);
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "To Do List:";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TO_DO_LIST_MouseDown);
            // 
            // btnClearList
            // 
            this.btnClearList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.btnClearList.Image = global::Cozify.Properties.Resources.Broom;
            this.btnClearList.Location = new System.Drawing.Point(12, 601);
            this.btnClearList.Name = "btnClearList";
            this.btnClearList.Size = new System.Drawing.Size(56, 60);
            this.btnClearList.TabIndex = 6;
            this.btnClearList.UseVisualStyleBackColor = true;
            this.btnClearList.Click += new System.EventHandler(this.btnClearList_Click);
            // 
            // btnAddToDoEntry
            // 
            this.btnAddToDoEntry.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.btnAddToDoEntry.Font = new System.Drawing.Font("Pixeltype", 25F);
            this.btnAddToDoEntry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAddToDoEntry.Icon = global::Cozify.Properties.Resources.Plus;
            this.btnAddToDoEntry.Location = new System.Drawing.Point(74, 601);
            this.btnAddToDoEntry.Name = "btnAddToDoEntry";
            this.btnAddToDoEntry.Size = new System.Drawing.Size(265, 60);
            this.btnAddToDoEntry.TabIndex = 5;
            this.btnAddToDoEntry.Text = "Add";
            this.btnAddToDoEntry.Click += new System.EventHandler(this.btnAddToDoEntry_Click);
            // 
            // TO_DO_LIST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.ClientSize = new System.Drawing.Size(351, 673);
            this.Controls.Add(this.btnClearList);
            this.Controls.Add(this.btnAddToDoEntry);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TO_DO_LIST";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form5";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TO_DO_LIST_MouseDown);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private AntdUI.Button btnAddToDoEntry;
        private System.Windows.Forms.Button btnClearList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}