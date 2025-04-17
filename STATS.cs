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
using System.Data.OleDb;
using finals;

namespace Cozify
{
/*stuff to work on NOTE: DISREGARD THIS FOR NOW, LETS FOCUS ON THE USER ACTIVITY

1. Pomodoro Tracker
    Pomodoro sessions per day/week/month
    Total time spent using Pomodoro timer

2. To-Do List
    Number of tasks completed vs. total added
    Daily/weekly/monthly task completion rate

3. Habit Checker
    Habits marked as done per day/week/month
    Habit completion streaks
*/

/*
    labels i have rn for user's activitiy are: 
     
        lblTimeSpentCozify
        lblTimeLaunchedCozify
        lblTracksNumber
        lblLastActive
        lblNumberOfEntries
        lblWordCountAvgPerEntry
        lblTasksAdded
        lblTotalTasksCompleted
        lblOldestTaskAge
        lblTotalHabitsAdded
        lblTotalTimeSpentPomo
        lblPomoSessionsCompelted
     
    */
public partial class STATS : BaseForm
{
    public STATS()
    {
        InitializeComponent();
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

    private void STATS_Load(object sender, EventArgs e)
    {
            db.LoadUserStats(lblTimeSpentCozify, lblTimesLaunchedCozify, lblLastActive);

            int totalToDoCount = db.ToDoCount();
            int completedToDoCount = db.CompleteToDoCount(true);
            int journalCount = db.JournalCount();

            lblNoOfJournalEntries.Text = $"Journal Entries Written: {journalCount}";
            lblTasksAdded.Text = $"To-Do List Entries: {totalToDoCount}";
            lblTotalTasksCompleted.Text = $"Total Completed Tasks: {completedToDoCount}";
            lblStatUser.Text = $"{GlobalUser.LoggedInUsername}'s Activity";
        }

    private void btnShowStats_Click(object sender, EventArgs e)
    {

    }
}
}
