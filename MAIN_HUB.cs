using Cozify;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//add music player, add analytics and monitoring, add admin account
namespace finals
{
    public partial class MAIN_HUB: Form
    {
        private HABIT_CHECKER habitChecker;
        private TO_DO_LIST toDo;
        private JOURNAL journal;
        private Guide guide;
        private POMODORO pomo;
        private STATS sTAT;
        private bool isFocused = false;
        private Form activeFeature = null;

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        public MAIN_HUB()
        {
            InitializeComponent();
            this.MouseDown += MAIN_HUB_MouseDown;
        }
        private void MAIN_HUB_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0xA1, 0x2, 0); // Dragging action
            }
        }

        private void btnMaxMainHub_Click(object sender, EventArgs e)
        {

            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Maximized;

        }

        private void btnMiniMainHub_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnExitMainHub_Click(object sender, EventArgs e)
        {
            this.btnExitMainHub.FlatAppearance.MouseOverBackColor = Color.Transparent;
            Application.Exit();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            if (habitChecker != null && !habitChecker.IsDisposed) habitChecker.Close();
            if (toDo != null && !toDo.IsDisposed) toDo.Close();
            if (journal != null && !journal.IsDisposed) journal.Close();
            if (guide != null && !guide.IsDisposed) guide.Close();
            if (pomo != null && !pomo.IsDisposed) pomo.Close();
            if (sTAT != null && !sTAT.IsDisposed) sTAT.Close();
            this.Close();
            //LOGIN lOGIN = new LOGIN();
            //lOGIN.Show();
        }

        private void MAIN_HUB_Load(object sender, EventArgs e)
        {
            WelcomeLabel.Text = GlobalUser.LoggedInUsername + "'s space";
            this.Resize += MAIN_HUB_Resize;
            //MainHub.TopMost = true; // Set the form to be topmost
            Centering();
        }

        private void Centering()
        {
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            // Center the Music Dock at the bot
            int pnlMusicDock_X = (formWidth - pnlMusicDock.Width) / 2;
            int pnlMusicDock_Y = formHeight - pnlMusicDock.Height - 6;
            pnlMusicDock.Location = new Point(pnlMusicDock_X, pnlMusicDock_Y);

        }
        private void MAIN_HUB_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                // Minimize the active feature if it exists
                if (activeFeature != null && !activeFeature.IsDisposed)
                {
                    activeFeature.WindowState = FormWindowState.Minimized;
                }
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                // Restore the active feature if it exists
                if (activeFeature != null && !activeFeature.IsDisposed)
                {
                    activeFeature.WindowState = FormWindowState.Normal;
                }
            }
            Centering();
        }

        private void MainHubClock(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("hh:mm tt");
            lblDate.Text = DateTime.Now.ToString("dddd, MMMM dd");
        }
        private void btnHabitChecker_Click(object sender, EventArgs e)
        {
            if (habitChecker == null || habitChecker.IsDisposed)
            {
                habitChecker = new HABIT_CHECKER();
                habitChecker.FormClosed += HabitChecker_FormClosed;
                habitChecker.Show();
                habitChecker.TopMost = true;

                activeFeature = habitChecker;

            }
            else
            {
                habitChecker.Close();
                activeFeature = null;
            }
            
        }

        private void HabitChecker_FormClosed(object sender, FormClosedEventArgs e)
        {
            habitChecker = null;
            activeFeature = null;
        }


        private void btnToDoMain_Click(object sender, EventArgs e)
        {
            if (toDo == null || toDo.IsDisposed)
            {
                toDo = new TO_DO_LIST();
                toDo.FormClosed += ToDo_FormClosed;
                toDo.Show();
                toDo.TopMost = true;

                activeFeature = toDo;
            }
            else
            {
                toDo.Close();
                activeFeature = null;
            }
        }

        private void ToDo_FormClosed(object sender, FormClosedEventArgs e)
        {
            toDo = null;
        }

        private void btnJournal_Click(object sender, EventArgs e)
        {
            if (journal == null || journal.IsDisposed)
            {
                journal = new JOURNAL();
                journal.FormClosed += Journal_FormClosed;
                journal.Show();
                journal.TopMost = true;

                activeFeature = journal;
            }
            else
            {
                journal.Close();
                activeFeature = null;
            }
        }

        private void Journal_FormClosed(object sender, FormClosedEventArgs e)
        {
            journal = null;
            activeFeature = null;
        }


        private void btnPomo_Click(object sender, EventArgs e)
        {
            if (pomo == null || pomo.IsDisposed)
            {
                pomo = new POMODORO();
                pomo.FormClosed += Pomo_FormClosed;
                pomo.Show();
                pomo.TopMost = true;
                activeFeature = pomo;
            }
            else
            {
                pomo.Close();
                activeFeature = null;
            }
        }

        private void Pomo_FormClosed(object sender, FormClosedEventArgs e)
        {
            pomo = null;
            activeFeature = null;
        }

        private void btnZenMode_Click(object sender, EventArgs e)
        {
            isFocused = !isFocused; // Toggle state

            btnHabitChecker.Visible = !isFocused;
            btnJournal.Visible = !isFocused;
            btnPomo.Visible = !isFocused;
            btnToDoMain.Visible = !isFocused;   
            btnPomo.Visible = !isFocused;
            btnHelpMainHub.Visible = !isFocused;
            btnMiniMainHub.Visible = !isFocused;
            btnExitMainHub.Visible = !isFocused;
            btnMaxMainHub.Visible = !isFocused;
            btnLogOut.Visible = !isFocused;
            lblClock.Visible = !isFocused;
            lblDate.Visible = !isFocused;
            btnStatistics.Visible = !isFocused;

        }

        private void btnHelpMainHub_Click(object sender, EventArgs e)
        {
            if (guide == null || guide.IsDisposed)
            {
                guide = new Guide();
                guide.FormClosed += Pomo_FormClosed;
                guide.Show();
                guide.TopMost = true;

                activeFeature = guide;
            }
            else
            {
                guide.Close();
                activeFeature = null;
            }
           // 
        }
        private void Guide_FormClosed(object sender, FormClosedEventArgs e)
        {
            guide = null;
            activeFeature = null;
        }

        private void ChecklistToolTip_Show(object sender, EventArgs e)
        {
            ToolTip ToDoTooltip = new ToolTip();
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            if (sTAT == null || sTAT.IsDisposed)
            {
                sTAT = new STATS();
                sTAT.FormClosed += Statistics_FormClosed;
                sTAT.Show();
                sTAT.TopMost = true;
                activeFeature = sTAT;
            }
            else
            {
                sTAT.Close();
                activeFeature = null;
            }
        }

        private void Statistics_FormClosed(object sender, FormClosedEventArgs e)
        {
            sTAT = null;
            activeFeature = null;
        }
    }
}
