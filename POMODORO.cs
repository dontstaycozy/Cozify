using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Data.OleDb;
using Cozify;

namespace finals
{
    public partial class POMODORO : BaseForm
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Users\fredwil\Desktop\Cozify Project\CozifyUsers.accdb";

        private SoundPlayer alarm;
        private Timer pomoTimer;
        private int timeLeft;
        private bool isSession = true;
        private bool isPlaying = false;
        private int elapsedWorkTime = 0;  // Tracks total work time
        private int elapsedBreakTime = 0; // Tracks total break time

        public POMODORO()
        {
            InitializeComponent();
            this.MouseDown += POMODORO_MouseDown;
            pomoTimer = new Timer();
            pomoTimer.Interval = 1000;
            pomoTimer.Tick += Timer_Tick;
            alarm = new SoundPlayer(Cozify.Properties.Resources.alarmsound);
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

        private void SavePomodoroSession(bool completed, int workTime, int breakTime)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO [Pomodoro Table] (Username, WorkTime, BreakTime, Completed, TimeSpent, SessionDate) VALUES (?, ?, ?, ?, ?, ?);";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    int totalTimeSpent = (workTime + breakTime);

                    cmd.Parameters.Add("?", OleDbType.VarChar).Value = GlobalUser.LoggedInUsername;
                    cmd.Parameters.Add("?", OleDbType.Integer).Value = workTime*60;
                    cmd.Parameters.Add("?", OleDbType.Integer).Value = breakTime*60;
                    cmd.Parameters.Add("?", OleDbType.Boolean).Value = completed;
                    cmd.Parameters.Add("?", OleDbType.Integer).Value = totalTimeSpent * 60;
                    cmd.Parameters.Add("?", OleDbType.Date).Value = DateTime.Now;

                    cmd.ExecuteNonQuery();
                }
            }
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
            else
            {
                pomoTimer.Stop();
                using (var ms = new MemoryStream(Cozify.Properties.Resources.Play_Button))
                {
                    btnStartPomo.Image = Image.FromStream(ms);
                }
            }
        }

        private string GetBreakMessage()
        {
            string[] breakMessages = { "Take a break!", "Drink water!", "Go do some stretches!", "Relax your eyes!", "Stand up and walk around!" };

            Random randomMessages = new Random();
            return breakMessages[randomMessages.Next(breakMessages.Length)];
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
                alarm.Play();
                pomoTimer.Stop();

                if (isSession)
                {
                    elapsedWorkTime += (int)numSession.Value;
                }
                else
                {
                    elapsedBreakTime += (int)numBreak.Value;
                }

                if (!isSession)
                {
                    SavePomodoroSession(true, elapsedWorkTime, elapsedBreakTime);
                    elapsedWorkTime = 0;
                    elapsedBreakTime = 0;
                }

                isSession = !isSession;
                PomoMSG.Text = isSession ? "Break Over! Time to work!" : GetBreakMessage();
                timeLeft = isSession ? (int)numSession.Value * 60 : (int)numBreak.Value * 60;
                pomoTimer.Start();
            }
        }

        private void btnResetPomo_Click(object sender, EventArgs e)
        {
            pomoTimer.Stop();

            if (elapsedWorkTime > 0 || elapsedBreakTime > 0)
            {
                SavePomodoroSession(false, elapsedWorkTime, elapsedBreakTime);
                elapsedWorkTime = 0;
                elapsedBreakTime = 0;
            }

            isSession = true;
            timeLeft = (int)numSession.Value * 60;
            lblTimer.Text = $"{timeLeft / 60:D2}:{timeLeft % 60:D2}";
            titlePomo.Text = "Pomodoro Timer";
        }
    }
}
