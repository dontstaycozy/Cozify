using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using finals;

namespace Cozify
{
    public partial class STATS : BaseForm
    {
        public STATS()
        {
            InitializeComponent();
        }

        private void STATS_Load(object sender, EventArgs e)
        {
            db.LoadUserStats(lblTimeSpentCozify, lblTimesLaunchedCozify);

            int totalToDoCount = db.ToDoCount(true);
            int totalCompletedToDoCount = db.CompleteToDoCount(true, true);
            int journalCount = db.JournalCount(true);
            int habitcount = db.HabitCount();
            int completedSessions = db.GetTotalCompletedSessions(GlobalUser.LoggedInUsername);
            int totalSeconds = db.GetTotalTimeSpent(GlobalUser.LoggedInUsername);

            lblStatUser.Text = $"{GlobalUser.LoggedInUsername}'s Activity";
            lblNoOfJournalEntries.Text = $"Journal Entries Written: {journalCount}";
            lblTasksAdded.Text = $"To-Do List Entries: {totalToDoCount}";
            lblTotalTasksCompleted.Text = $"Total Completed Tasks: {totalCompletedToDoCount}";
            lblTotalHabitsAdded.Text = $"Total Habits Added: {habitcount}";
            lblPomoSessionsCompelted.Text = $"Pomodoro Sessions Completed: {completedSessions}";
            lblTotalTimeSpentPomo.Text = $"Total Time Spent Using Pomodoro: {totalSeconds / 60} minutes";
            string ProductivityRating = db.GetWeeklyProductivityRating(GlobalUser.LoggedInUsername);
            lblRating.Text = $"Weekly Productivity Rating: {ProductivityRating}";
        }

        private void btnDeleteAcc_Click(object sender, EventArgs e)
        {
            db.DeleteAcc();
            this.Hide();

            LoginReg loginReg = new LoginReg();
            loginReg.Show();
        }
        private void btnClearAcc_Click(object sender, EventArgs e)
        {
            db.ClearData();
        }

        private void btnShowStats_Click(object sender, EventArgs e)
        {
            this.Hide();

            ANALYTICS aNALYTICS = new ANALYTICS();
            aNALYTICS.Show();
        }
    }
}
