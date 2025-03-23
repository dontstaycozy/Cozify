using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace finals
{
    public partial class POMODORO : Form
    {
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        private Timer pomoTimer;
        private int timeLeft;
        private bool isSession = true;
        private bool isPlaying = false;
        public POMODORO()
        {
            InitializeComponent();
            this.MouseDown += POMODORO_MouseDown;
            pomoTimer = new Timer();
            pomoTimer.Interval = 1000;
            pomoTimer.Tick += Timer_Tick;
        }
        private void POMODORO_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0xA1, 0x2, 0); // Dragging action
            }
        }
        private void Centering()
        {
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            int pnlMusicDock_X = (formWidth - tblLayoutPomo.Width) / 2;
            int pnlMusicDock_Y = formHeight - tblLayoutPomo.Height - 6;
            tblLayoutPomo.Location = new Point(pnlMusicDock_X, pnlMusicDock_Y);

        }

        private void POMODORO_Load(object sender, EventArgs e)
        {
            Centering();
        }

        private void btnStartPomo_Click(object sender, EventArgs e)
        {
            if (!pomoTimer.Enabled)
            {
                int sessionMinutes = (int)numSession.Value;
                int breakMinutes = (int)numBreak.Value;

                if (sessionMinutes == 0 || breakMinutes == 0)
                {
                    PomoMSG.Text = "Enter a valid time!";
                    return;
                }

                PomoMSG.Text = "You got this! ><";
                timeLeft = isSession ? sessionMinutes * 60 : breakMinutes * 60;
                pomoTimer.Start();

                isPlaying = true;
                using (var ms = new MemoryStream(Cozify.Properties.Resources.Pause_Button))
                {
                    btnStartPomo.Image = Image.FromStream(ms);
                }
            }
            else // Stop the timer
            {
                pomoTimer.Stop();
                using (var ms = new MemoryStream(Cozify.Properties.Resources.Play_Button))
                {
                    btnStartPomo.Image = Image.FromStream(ms);
                }
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--;
                lblTimer.Text = $"{timeLeft / 60:D2}:{timeLeft % 60:D2}";
            }
            else
            {
                pomoTimer.Stop();
                isSession = !isSession;
                PomoMSG.Text = isSession ? "Break Over! Time to work!" : "Take a break!";
                timeLeft = isSession ? (int)numSession.Value * 60 : (int)numBreak.Value * 60;
                pomoTimer.Start();
            }
        }

        private void btnResetPomo_Click(object sender, EventArgs e)
        {
            pomoTimer.Stop();
            isSession = true;
            timeLeft = (int)numSession.Value * 60;
            lblTimer.Text = $"{timeLeft / 60:D2}:{timeLeft % 60:D2}";
            titlePomo.Text = "Pomodoro Timer";
        }
    }
}
