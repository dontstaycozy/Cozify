using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Cozify;
using static Cozify.dbHelper;

namespace finals
{
    public partial class POMODORO : BaseForm
    {
        private SoundPlayer alarm;
        private Timer pomoTimer;
        private int timeLeft;
        private bool isSession = true;
        private bool isPlaying = false;
        private int elapsedWorkTime = 0;
        private int elapsedBreakTime = 0;

        private PomodoroStats pomodoroStats = new PomodoroStats();

        public static class PomodoroSettings
        {
            public static int LastWorkTime { get; set; } = 25;
            public static int LastBreakTime { get; set; } = 5;
            public static PomodoroStats Stats { get; set; } = new PomodoroStats();
        }

        public POMODORO()
        {
            InitializeComponent();

            // Restore previous settings
            numSession.Value = PomodoroSettings.LastWorkTime;
            numBreak.Value = PomodoroSettings.LastBreakTime;
            pomodoroStats = PomodoroSettings.Stats ?? new PomodoroStats();

            // Setup timer and alarm
            pomoTimer = new Timer();
            pomoTimer.Interval = 1000;
            pomoTimer.Tick += Timer_Tick;

            alarm = new SoundPlayer(Cozify.Properties.Resources.alarmsound);
        }

        private void POMODORO_Load(object sender, EventArgs e)
        {
            Centering();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            PomodoroSettings.LastWorkTime = (int)numSession.Value;
            PomodoroSettings.LastBreakTime = (int)numBreak.Value;
            PomodoroSettings.Stats = pomodoroStats;

            base.OnFormClosing(e);
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
                    elapsedWorkTime += (int)numSession.Value;
                else
                    elapsedBreakTime += (int)numBreak.Value;

                if (!isSession)
                {
                    SavePomodoroSession(true, elapsedWorkTime, elapsedBreakTime);
                    elapsedWorkTime = 0;
                    elapsedBreakTime = 0;
                }

                isSession = !isSession;
                PomoMSG.Text = isSession ? "Break Over! Time to work!" : GetBreakMessage();

                timeLeft = isSession
                    ? (int)numSession.Value * 60
                    : (int)numBreak.Value * 60;

                pomoTimer.Start();
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

        private void Centering()
        {
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            int pnlMusicDock_X = (formWidth - tblLayoutPomo.Width) / 2;
            int pnlMusicDock_Y = formHeight - tblLayoutPomo.Height - 6;

            tblLayoutPomo.Location = new Point(pnlMusicDock_X, pnlMusicDock_Y);
        }

        private void SavePomodoroSession(bool completed, int workTime, int breakTime)
        {
            db.SavePomodoroSession(completed, workTime, breakTime, ref pomodoroStats);
        }

        private string GetBreakMessage()
        {
            string[] breakMessages =
            {
                "Take a break!",
                "Drink water!",
                "Go do some stretches!",
                "Relax your eyes =.=",
                "Take a walk :>"
            };

            Random randomMessages = new Random();
            return breakMessages[randomMessages.Next(breakMessages.Length)];
        }
    }
}
