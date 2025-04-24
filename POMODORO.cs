using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;
using Cozify;
using static Cozify.dbHelper;

namespace finals
{
    public partial class POMODORO : BaseForm
    {
        private readonly SoundPlayer alarm;
        private readonly Timer pomoTimer;
        private int timeLeft;
        private bool isSession = true;
        private int elapsedWorkTime = 0;
        private int elapsedBreakTime = 0;
        private PomodoroStats pomodoroStats;

        public static class PomodoroSettings
        {
            public static int LastWorkTime { get; set; } = 25;
            public static int LastBreakTime { get; set; } = 5;
            public static PomodoroStats Stats { get; set; } = new PomodoroStats();
        }
        public POMODORO()
        {
            InitializeComponent();

            // Restore settings
            numSession.Value = PomodoroSettings.LastWorkTime;
            numBreak.Value = PomodoroSettings.LastBreakTime;
            pomodoroStats = PomodoroSettings.Stats ?? new PomodoroStats();

            // Initialize timer
            pomoTimer = new Timer { Interval = 1000 };
            pomoTimer.Tick += Timer_Tick;

            // Initialize alarm
            alarm = new SoundPlayer(Cozify.Properties.Resources.alarmsound);

            // Set initial display
            ResetTimerDisplay();
        }

        private void POMODORO_Load(object sender, EventArgs e)
        {
            Centering();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--;
                UpdateTimerDisplay();
            }
            else
            {
                HandleTimerCompletion();
            }
        }

        private void StartTimer()
        {
            if ((int)numSession.Value == 0 || (int)numBreak.Value == 0)
            {
                PomoMSG.Text = "Enter a valid time!";
                return;
            }

            timeLeft = isSession ? (int)numSession.Value * 60 : (int)numBreak.Value * 60;
            pomoTimer.Start();
            UpdateButtonState(true);
            PomoMSG.Text = "You got this! ><";
        }

        private void StopTimer(bool saveSession)
        {
            pomoTimer.Stop();
            if (saveSession && (elapsedWorkTime > 0 || elapsedBreakTime > 0))
            {
                SavePomodoroSession(false, elapsedWorkTime, elapsedBreakTime);
            }
            UpdateButtonState(false);
        }

        private void ResetTimer()
        {
            StopTimer(false);
            isSession = true;
            elapsedWorkTime = 0;
            elapsedBreakTime = 0;
            timeLeft = (int)numSession.Value * 60;
            ResetTimerDisplay();
            titlePomo.Text = "Pomodoro Timer";
        }

        private void HandleTimerCompletion()
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
            timeLeft = isSession ? (int)numSession.Value * 60 : (int)numBreak.Value * 60;
            pomoTimer.Start();
        }

        private void UpdateButtonState(bool isRunning)
        {
            var resource = isRunning
                ? Cozify.Properties.Resources.Pause_Button
                : Cozify.Properties.Resources.Play_Button;

            using (var ms = new MemoryStream(resource))
            {
                btnStartPomo.Image = Image.FromStream(ms);
            }
        }

        private void UpdateTimerDisplay()
        {
            lblTimer.Text = $"{timeLeft / 60:D2}:{timeLeft % 60:D2}";
        }

        private void ResetTimerDisplay()
        {
            timeLeft = (int)numSession.Value * 60;
            UpdateTimerDisplay();
        }

        private void Centering()
        {
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;
            tblLayoutPomo.Location = new Point(
                (formWidth - tblLayoutPomo.Width) / 2,
                formHeight - tblLayoutPomo.Height - 6);
        }

        private string GetBreakMessage()
        {
            string[] breakMessages =
            {
                "Take a break!", "Drink water!",
                "Go do some stretches!",
                "Relax your eyes =.=",
                "Take a walk :>"
            };
            return breakMessages[new Random().Next(breakMessages.Length)];
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            StopTimer(true);
            SaveCurrentSettings();
            alarm?.Dispose();
            pomoTimer?.Dispose();
            base.OnFormClosing(e);
        }

        private void btnStartPomo_Click(object sender, EventArgs e)
        {
            if (!pomoTimer.Enabled)
            {
                StartTimer();
            }
            else
            {
                StopTimer(true);
            }
        }

        private void btnResetPomo_Click(object sender, EventArgs e)
        {
            ResetTimer();
        }

        private void SavePomodoroSession(bool completed, int workTime, int breakTime)
        {
            db.SavePomodoroSession(completed, workTime, breakTime, ref pomodoroStats);
        }

        private void SaveCurrentSettings()
        {
            PomodoroSettings.LastWorkTime = (int)numSession.Value;
            PomodoroSettings.LastBreakTime = (int)numBreak.Value;
            PomodoroSettings.Stats = pomodoroStats;
        }

        public void ForceStopTimer()
        {
            StopTimer(true);
        }
    }
}