namespace finals
{
    partial class MAIN_HUB
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
            this.components = new System.ComponentModel.Container();
            this.WelcomeLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlTime = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDate = new System.Windows.Forms.Label();
            this.toolTip_ToDo = new System.Windows.Forms.ToolTip(this.components);
            this.btnToDoMain = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnJournal = new System.Windows.Forms.Button();
            this.btnPomo = new System.Windows.Forms.Button();
            this.btnHabitChecker = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnMiniMainHub = new System.Windows.Forms.Button();
            this.btnMaxMainHub = new System.Windows.Forms.Button();
            this.btnExitMainHub = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnHelpMainHub = new System.Windows.Forms.Button();
            this.pnlPicContainer = new System.Windows.Forms.Panel();
            this.PicBox1 = new System.Windows.Forms.PictureBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnZenMode = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lblClock = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnStatistics = new System.Windows.Forms.Button();
            this.pnlMusicDock = new System.Windows.Forms.Panel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.lblSongAndArtist = new AntdUI.Label();
            this.lblMusicPlaylist = new AntdUI.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.trkBarVolumeSlider = new System.Windows.Forms.TrackBar();
            this.btnPrevTrack = new System.Windows.Forms.Button();
            this.btnPlayORStopTrack = new System.Windows.Forms.Button();
            this.btnNextTrack = new System.Windows.Forms.Button();
            this.btnLoopTracks = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.btnMusicLib = new System.Windows.Forms.Button();
            this.pnlTime.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.pnlPicContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox1)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel8.SuspendLayout();
            this.pnlMusicDock.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkBarVolumeSlider)).BeginInit();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // WelcomeLabel
            // 
            this.WelcomeLabel.AutoSize = true;
            this.WelcomeLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.WelcomeLabel.Font = new System.Drawing.Font("Pixeltype", 36F);
            this.WelcomeLabel.ForeColor = System.Drawing.Color.White;
            this.WelcomeLabel.Location = new System.Drawing.Point(0, 0);
            this.WelcomeLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.WelcomeLabel.Name = "WelcomeLabel";
            this.WelcomeLabel.Size = new System.Drawing.Size(424, 37);
            this.WelcomeLabel.TabIndex = 0;
            this.WelcomeLabel.Text = "(insert name)\'s space";
            this.WelcomeLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MAIN_HUB_MouseDown);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.MainHubClock);
            // 
            // pnlTime
            // 
            this.pnlTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTime.BackColor = System.Drawing.Color.Transparent;
            this.pnlTime.Controls.Add(this.tableLayoutPanel3);
            this.pnlTime.Font = new System.Drawing.Font("Pixeltype", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlTime.Location = new System.Drawing.Point(971, 801);
            this.pnlTime.Margin = new System.Windows.Forms.Padding(1);
            this.pnlTime.Name = "pnlTime";
            this.pnlTime.Size = new System.Drawing.Size(149, 72);
            this.pnlTime.TabIndex = 8;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.lblDate, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(149, 72);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblDate.Font = new System.Drawing.Font("Pixeltype", 20F);
            this.lblDate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDate.Location = new System.Drawing.Point(3, 51);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(143, 21);
            this.lblDate.TabIndex = 17;
            this.lblDate.Text = "date";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnToDoMain
            // 
            this.btnToDoMain.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnToDoMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnToDoMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToDoMain.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnToDoMain.Image = global::Cozify.Properties.Resources.Checked_Checkbox2;
            this.btnToDoMain.Location = new System.Drawing.Point(1, 1);
            this.btnToDoMain.Margin = new System.Windows.Forms.Padding(1);
            this.btnToDoMain.Name = "btnToDoMain";
            this.btnToDoMain.Size = new System.Drawing.Size(66, 58);
            this.btnToDoMain.TabIndex = 4;
            this.toolTip_ToDo.SetToolTip(this.btnToDoMain, "To Do List for your tasks");
            this.btnToDoMain.UseVisualStyleBackColor = false;
            this.btnToDoMain.Click += new System.EventHandler(this.btnToDoMain_Click);
            this.btnToDoMain.MouseHover += new System.EventHandler(this.ChecklistToolTip_Show);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.Location = new System.Drawing.Point(1319, 542);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(68, 244);
            this.panel1.TabIndex = 19;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btnJournal, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnToDoMain, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnPomo, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnHabitChecker, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1319, 542);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(68, 244);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnJournal
            // 
            this.btnJournal.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnJournal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnJournal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJournal.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnJournal.Image = global::Cozify.Properties.Resources.Journal;
            this.btnJournal.Location = new System.Drawing.Point(1, 121);
            this.btnJournal.Margin = new System.Windows.Forms.Padding(1);
            this.btnJournal.Name = "btnJournal";
            this.btnJournal.Size = new System.Drawing.Size(66, 58);
            this.btnJournal.TabIndex = 7;
            this.btnJournal.Text = " ";
            this.btnJournal.UseVisualStyleBackColor = false;
            this.btnJournal.Click += new System.EventHandler(this.btnJournal_Click);
            // 
            // btnPomo
            // 
            this.btnPomo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnPomo.BackgroundImage = global::Cozify.Properties.Resources.Tomato;
            this.btnPomo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPomo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPomo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPomo.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnPomo.Location = new System.Drawing.Point(1, 61);
            this.btnPomo.Margin = new System.Windows.Forms.Padding(1);
            this.btnPomo.Name = "btnPomo";
            this.btnPomo.Size = new System.Drawing.Size(66, 58);
            this.btnPomo.TabIndex = 15;
            this.btnPomo.UseVisualStyleBackColor = false;
            this.btnPomo.Click += new System.EventHandler(this.btnPomo_Click);
            // 
            // btnHabitChecker
            // 
            this.btnHabitChecker.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnHabitChecker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHabitChecker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHabitChecker.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnHabitChecker.Image = global::Cozify.Properties.Resources.Clipboard;
            this.btnHabitChecker.Location = new System.Drawing.Point(1, 181);
            this.btnHabitChecker.Margin = new System.Windows.Forms.Padding(1);
            this.btnHabitChecker.Name = "btnHabitChecker";
            this.btnHabitChecker.Size = new System.Drawing.Size(66, 62);
            this.btnHabitChecker.TabIndex = 6;
            this.btnHabitChecker.UseVisualStyleBackColor = false;
            this.btnHabitChecker.Click += new System.EventHandler(this.btnHabitChecker_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.btnLogOut);
            this.panel2.Location = new System.Drawing.Point(19, 798);
            this.panel2.Margin = new System.Windows.Forms.Padding(10);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(68, 72);
            this.panel2.TabIndex = 20;
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnLogOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOut.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnLogOut.Image = global::Cozify.Properties.Resources.Logout;
            this.btnLogOut.Location = new System.Drawing.Point(5, 5);
            this.btnLogOut.Margin = new System.Windows.Forms.Padding(1);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(58, 62);
            this.btnLogOut.TabIndex = 12;
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.tableLayoutPanel2);
            this.panel3.Location = new System.Drawing.Point(1193, 10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(191, 61);
            this.panel3.TabIndex = 21;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.btnMiniMainHub, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnMaxMainHub, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnExitMainHub, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(182, 58);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btnMiniMainHub
            // 
            this.btnMiniMainHub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMiniMainHub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMiniMainHub.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnMiniMainHub.Image = global::Cozify.Properties.Resources.Minimize_Window_1;
            this.btnMiniMainHub.Location = new System.Drawing.Point(1, 1);
            this.btnMiniMainHub.Margin = new System.Windows.Forms.Padding(1);
            this.btnMiniMainHub.Name = "btnMiniMainHub";
            this.btnMiniMainHub.Size = new System.Drawing.Size(58, 56);
            this.btnMiniMainHub.TabIndex = 2;
            this.btnMiniMainHub.UseVisualStyleBackColor = true;
            this.btnMiniMainHub.Click += new System.EventHandler(this.btnMiniMainHub_Click);
            // 
            // btnMaxMainHub
            // 
            this.btnMaxMainHub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMaxMainHub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaxMainHub.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnMaxMainHub.Image = global::Cozify.Properties.Resources.Maximize_Window_2;
            this.btnMaxMainHub.Location = new System.Drawing.Point(61, 1);
            this.btnMaxMainHub.Margin = new System.Windows.Forms.Padding(1);
            this.btnMaxMainHub.Name = "btnMaxMainHub";
            this.btnMaxMainHub.Size = new System.Drawing.Size(58, 56);
            this.btnMaxMainHub.TabIndex = 17;
            this.btnMaxMainHub.UseVisualStyleBackColor = true;
            this.btnMaxMainHub.Click += new System.EventHandler(this.btnMaxMainHub_Click);
            // 
            // btnExitMainHub
            // 
            this.btnExitMainHub.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnExitMainHub.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExitMainHub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExitMainHub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExitMainHub.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnExitMainHub.Image = global::Cozify.Properties.Resources.Close_1;
            this.btnExitMainHub.Location = new System.Drawing.Point(121, 1);
            this.btnExitMainHub.Margin = new System.Windows.Forms.Padding(1);
            this.btnExitMainHub.Name = "btnExitMainHub";
            this.btnExitMainHub.Size = new System.Drawing.Size(60, 56);
            this.btnExitMainHub.TabIndex = 3;
            this.btnExitMainHub.UseVisualStyleBackColor = false;
            this.btnExitMainHub.Click += new System.EventHandler(this.btnExitMainHub_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel4.Controls.Add(this.WelcomeLabel);
            this.panel4.Location = new System.Drawing.Point(23, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(697, 53);
            this.panel4.TabIndex = 22;
            this.panel4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MAIN_HUB_MouseDown);
            // 
            // panel5
            // 
            this.panel5.AutoSize = true;
            this.panel5.Controls.Add(this.btnHelpMainHub);
            this.panel5.Location = new System.Drawing.Point(7, 141);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(70, 65);
            this.panel5.TabIndex = 23;
            // 
            // btnHelpMainHub
            // 
            this.btnHelpMainHub.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnHelpMainHub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHelpMainHub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelpMainHub.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnHelpMainHub.Image = global::Cozify.Properties.Resources.Help;
            this.btnHelpMainHub.Location = new System.Drawing.Point(0, 0);
            this.btnHelpMainHub.Margin = new System.Windows.Forms.Padding(1);
            this.btnHelpMainHub.Name = "btnHelpMainHub";
            this.btnHelpMainHub.Size = new System.Drawing.Size(70, 65);
            this.btnHelpMainHub.TabIndex = 18;
            this.btnHelpMainHub.UseVisualStyleBackColor = false;
            this.btnHelpMainHub.Click += new System.EventHandler(this.btnHelpMainHub_Click);
            // 
            // pnlPicContainer
            // 
            this.pnlPicContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPicContainer.Controls.Add(this.PicBox1);
            this.pnlPicContainer.Location = new System.Drawing.Point(87, 77);
            this.pnlPicContainer.Name = "pnlPicContainer";
            this.pnlPicContainer.Size = new System.Drawing.Size(1226, 693);
            this.pnlPicContainer.TabIndex = 24;
            // 
            // PicBox1
            // 
            this.PicBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicBox1.Image = global::Cozify.Properties.Resources.rainy_shop;
            this.PicBox1.Location = new System.Drawing.Point(0, 0);
            this.PicBox1.Margin = new System.Windows.Forms.Padding(4);
            this.PicBox1.Name = "PicBox1";
            this.PicBox1.Size = new System.Drawing.Size(1226, 693);
            this.PicBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicBox1.TabIndex = 9;
            this.PicBox1.TabStop = false;
            this.PicBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MAIN_HUB_MouseDown);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnZenMode);
            this.panel6.Location = new System.Drawing.Point(7, 77);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(69, 58);
            this.panel6.TabIndex = 25;
            // 
            // btnZenMode
            // 
            this.btnZenMode.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnZenMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnZenMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZenMode.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnZenMode.Image = global::Cozify.Properties.Resources.Lotus;
            this.btnZenMode.Location = new System.Drawing.Point(0, 0);
            this.btnZenMode.Margin = new System.Windows.Forms.Padding(1);
            this.btnZenMode.Name = "btnZenMode";
            this.btnZenMode.Size = new System.Drawing.Size(69, 58);
            this.btnZenMode.TabIndex = 10;
            this.btnZenMode.UseVisualStyleBackColor = false;
            this.btnZenMode.Click += new System.EventHandler(this.btnZenMode_Click);
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.BackColor = System.Drawing.Color.Transparent;
            this.panel7.Controls.Add(this.tableLayoutPanel4);
            this.panel7.Font = new System.Drawing.Font("Pixeltype", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel7.Location = new System.Drawing.Point(1121, 801);
            this.panel7.Margin = new System.Windows.Forms.Padding(1);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(268, 82);
            this.panel7.TabIndex = 26;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.lblClock, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(268, 79);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // lblClock
            // 
            this.lblClock.AutoSize = true;
            this.lblClock.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblClock.Font = new System.Drawing.Font("Pixeltype", 50F);
            this.lblClock.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblClock.Location = new System.Drawing.Point(3, 26);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(262, 53);
            this.lblClock.TabIndex = 18;
            this.lblClock.Text = "00:00 pm";
            this.lblClock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.btnStatistics);
            this.panel8.Location = new System.Drawing.Point(7, 210);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(69, 58);
            this.panel8.TabIndex = 27;
            // 
            // btnStatistics
            // 
            this.btnStatistics.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStatistics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatistics.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnStatistics.Image = global::Cozify.Properties.Resources.Cat_Profile;
            this.btnStatistics.Location = new System.Drawing.Point(0, 0);
            this.btnStatistics.Margin = new System.Windows.Forms.Padding(1);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(69, 58);
            this.btnStatistics.TabIndex = 10;
            this.btnStatistics.UseVisualStyleBackColor = false;
            this.btnStatistics.Click += new System.EventHandler(this.btnStatistics_Click);
            // 
            // pnlMusicDock
            // 
            this.pnlMusicDock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlMusicDock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.pnlMusicDock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMusicDock.Controls.Add(this.tableLayoutPanel5);
            this.pnlMusicDock.Controls.Add(this.panel9);
            this.pnlMusicDock.Location = new System.Drawing.Point(126, 783);
            this.pnlMusicDock.Name = "pnlMusicDock";
            this.pnlMusicDock.Size = new System.Drawing.Size(799, 90);
            this.pnlMusicDock.TabIndex = 28;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.lblSongAndArtist, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.lblMusicPlaylist, 0, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(16, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(347, 78);
            this.tableLayoutPanel5.TabIndex = 41;
            // 
            // lblSongAndArtist
            // 
            this.lblSongAndArtist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSongAndArtist.Font = new System.Drawing.Font("Pixeltype", 19F);
            this.lblSongAndArtist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblSongAndArtist.Location = new System.Drawing.Point(3, 37);
            this.lblSongAndArtist.Name = "lblSongAndArtist";
            this.lblSongAndArtist.Size = new System.Drawing.Size(341, 38);
            this.lblSongAndArtist.TabIndex = 43;
            this.lblSongAndArtist.Text = "Purple Cat - Swingin\'";
            // 
            // lblMusicPlaylist
            // 
            this.lblMusicPlaylist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMusicPlaylist.Font = new System.Drawing.Font("Pixeltype", 22F);
            this.lblMusicPlaylist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblMusicPlaylist.Location = new System.Drawing.Point(3, 3);
            this.lblMusicPlaylist.Name = "lblMusicPlaylist";
            this.lblMusicPlaylist.Size = new System.Drawing.Size(341, 28);
            this.lblMusicPlaylist.TabIndex = 42;
            this.lblMusicPlaylist.Text = "Cozify Study Music Vol. 1";
            this.lblMusicPlaylist.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.pictureBox1);
            this.panel9.Controls.Add(this.trkBarVolumeSlider);
            this.panel9.Controls.Add(this.btnPrevTrack);
            this.panel9.Controls.Add(this.btnPlayORStopTrack);
            this.panel9.Controls.Add(this.btnNextTrack);
            this.panel9.Controls.Add(this.btnLoopTracks);
            this.panel9.Location = new System.Drawing.Point(379, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(408, 80);
            this.panel9.TabIndex = 42;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cozify.Properties.Resources.Voice;
            this.pictureBox1.Location = new System.Drawing.Point(98, 58);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 27);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 49;
            this.pictureBox1.TabStop = false;
            // 
            // trkBarVolumeSlider
            // 
            this.trkBarVolumeSlider.AutoSize = false;
            this.trkBarVolumeSlider.Location = new System.Drawing.Point(125, 60);
            this.trkBarVolumeSlider.Name = "trkBarVolumeSlider";
            this.trkBarVolumeSlider.Size = new System.Drawing.Size(190, 25);
            this.trkBarVolumeSlider.TabIndex = 48;
            this.trkBarVolumeSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trkBarVolumeSlider.Scroll += new System.EventHandler(this.trkBarVolumeSlider_Scroll);
            // 
            // btnPrevTrack
            // 
            this.btnPrevTrack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.btnPrevTrack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevTrack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.btnPrevTrack.Image = global::Cozify.Properties.Resources.Previous_Page;
            this.btnPrevTrack.Location = new System.Drawing.Point(108, -1);
            this.btnPrevTrack.Margin = new System.Windows.Forms.Padding(1);
            this.btnPrevTrack.Name = "btnPrevTrack";
            this.btnPrevTrack.Size = new System.Drawing.Size(64, 59);
            this.btnPrevTrack.TabIndex = 47;
            this.btnPrevTrack.UseVisualStyleBackColor = false;
            this.btnPrevTrack.Click += new System.EventHandler(this.btnPrevTrack_Click);
            // 
            // btnPlayORStopTrack
            // 
            this.btnPlayORStopTrack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.btnPlayORStopTrack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayORStopTrack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.btnPlayORStopTrack.Image = global::Cozify.Properties.Resources.Circled_Play2;
            this.btnPlayORStopTrack.Location = new System.Drawing.Point(186, -2);
            this.btnPlayORStopTrack.Margin = new System.Windows.Forms.Padding(1);
            this.btnPlayORStopTrack.Name = "btnPlayORStopTrack";
            this.btnPlayORStopTrack.Size = new System.Drawing.Size(64, 59);
            this.btnPlayORStopTrack.TabIndex = 44;
            this.btnPlayORStopTrack.UseVisualStyleBackColor = false;
            this.btnPlayORStopTrack.Click += new System.EventHandler(this.btnPlayORStopTrack_Click);
            // 
            // btnNextTrack
            // 
            this.btnNextTrack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.btnNextTrack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextTrack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.btnNextTrack.Image = global::Cozify.Properties.Resources.Next_page;
            this.btnNextTrack.Location = new System.Drawing.Point(261, -1);
            this.btnNextTrack.Margin = new System.Windows.Forms.Padding(1);
            this.btnNextTrack.Name = "btnNextTrack";
            this.btnNextTrack.Size = new System.Drawing.Size(64, 59);
            this.btnNextTrack.TabIndex = 43;
            this.btnNextTrack.UseVisualStyleBackColor = false;
            this.btnNextTrack.Click += new System.EventHandler(this.btnNextTrack_Click);
            // 
            // btnLoopTracks
            // 
            this.btnLoopTracks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.btnLoopTracks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoopTracks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(91)))));
            this.btnLoopTracks.Image = global::Cozify.Properties.Resources.Repeat;
            this.btnLoopTracks.Location = new System.Drawing.Point(336, 6);
            this.btnLoopTracks.Margin = new System.Windows.Forms.Padding(1);
            this.btnLoopTracks.Name = "btnLoopTracks";
            this.btnLoopTracks.Size = new System.Drawing.Size(61, 37);
            this.btnLoopTracks.TabIndex = 42;
            this.btnLoopTracks.UseVisualStyleBackColor = false;
            this.btnLoopTracks.Click += new System.EventHandler(this.btnLoopTracks_Click);
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.btnMusicLib);
            this.panel10.Location = new System.Drawing.Point(7, 274);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(69, 58);
            this.panel10.TabIndex = 48;
            // 
            // btnMusicLib
            // 
            this.btnMusicLib.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnMusicLib.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMusicLib.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMusicLib.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnMusicLib.Image = global::Cozify.Properties.Resources.Music_Library1;
            this.btnMusicLib.Location = new System.Drawing.Point(0, 0);
            this.btnMusicLib.Margin = new System.Windows.Forms.Padding(1);
            this.btnMusicLib.Name = "btnMusicLib";
            this.btnMusicLib.Size = new System.Drawing.Size(69, 58);
            this.btnMusicLib.TabIndex = 47;
            this.btnMusicLib.UseVisualStyleBackColor = false;
            this.btnMusicLib.Click += new System.EventHandler(this.btnMusicLib_Click_1);
            // 
            // MAIN_HUB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1399, 889);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.pnlMusicDock);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.pnlTime);
            this.Controls.Add(this.pnlPicContainer);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "MAIN_HUB";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.MAIN_HUB_Load);
            this.Resize += new System.EventHandler(this.MAIN_HUB_Resize);
            this.pnlTime.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.pnlPicContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicBox1)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.pnlMusicDock.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkBarVolumeSlider)).EndInit();
            this.panel10.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label WelcomeLabel;
        private System.Windows.Forms.Button btnExitMainHub;
        private System.Windows.Forms.Button btnHabitChecker;
        private System.Windows.Forms.Button btnPomo;
        private System.Windows.Forms.Button btnToDoMain;
        private System.Windows.Forms.Button btnJournal;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox PicBox1;
        private System.Windows.Forms.Panel pnlTime;
        private System.Windows.Forms.Button btnZenMode;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.ToolTip toolTip_ToDo;
        private System.Windows.Forms.Button btnMiniMainHub;
        private System.Windows.Forms.Button btnMaxMainHub;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel pnlPicContainer;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button btnHelpMainHub;
        private System.Windows.Forms.Button btnStatistics;
        private System.Windows.Forms.Panel pnlMusicDock;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private AntdUI.Label lblSongAndArtist;
        private AntdUI.Label lblMusicPlaylist;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button btnPlayORStopTrack;
        private System.Windows.Forms.Button btnNextTrack;
        private System.Windows.Forms.Button btnLoopTracks;
        private System.Windows.Forms.Button btnPrevTrack;
        private System.Windows.Forms.Button btnMusicLib;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.TrackBar trkBarVolumeSlider;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}