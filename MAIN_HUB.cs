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

//note: need calendar, free draw for journal, and a way to add music
//note: need to add a way to add a habit checker
//note: need to add a way to add a to do list
//note: need to add a way to add a pomo timer
//note: need to add a way to add a zen mode
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
            this.Close();
            LOGIN lOGIN = new LOGIN();
        }

        private void MAIN_HUB_Load(object sender, EventArgs e)
        {
            WelcomeLabel.Text = GlobalUser.LoggedInUsername + "'s space";
            this.Resize += MAIN_HUB_Resize;
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
                foreach (Form form in Application.OpenForms)
                {
                    if (form != this)
                    {
                        form.WindowState = FormWindowState.Minimized;
                    }
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
            }
            else
            {
                habitChecker.Close();
            }
            
        }

        private void HabitChecker_FormClosed(object sender, FormClosedEventArgs e)
        {
            habitChecker = null;
        }


        private void btnToDoMain_Click(object sender, EventArgs e)
        {
            if (toDo == null || toDo.IsDisposed)
            {
                toDo = new TO_DO_LIST();
                toDo.FormClosed += ToDo_FormClosed;
                toDo.Show();
                toDo.TopMost = true;
            }
            else
            {
                toDo.Close();
            }
           // 
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
            }
            else
            {
                journal.Close();
            }
            //
        }

        private void Journal_FormClosed(object sender, FormClosedEventArgs e)
        {
            journal = null;
        }


        private void btnPomo_Click(object sender, EventArgs e)
        {
            if (pomo == null || pomo.IsDisposed)
            {
                pomo = new POMODORO();
                pomo.FormClosed += Pomo_FormClosed;
                pomo.Show();
                pomo.TopMost = true;
            }
            else
            {
                pomo.Close();
            }
            //
        }

        private void Pomo_FormClosed(object sender, FormClosedEventArgs e)
        {
            pomo = null;
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
            }
            else
            {
                guide.Close();
            }
           // 
        }
        private void Guide_FormClosed(object sender, FormClosedEventArgs e)
        {
            guide = null;
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
            }
            else
            {
                sTAT.Close();
            }
        }

        private void Statistics_FormClosed(object sender, FormClosedEventArgs e)
        {
            sTAT = null;
        }
    }
}
