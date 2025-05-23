﻿using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Cozify;

namespace finals
{
    public partial class HABIT_CHECKER : BaseForm
    {
        private DateTime selectedWeekStart;

        public HABIT_CHECKER()
        {
            InitializeComponent();
            this.MouseDown += HABIT_CHECKER_MouseDown;
            selectedWeekStart = GetStartOfWeek(DateTime.Now);
            UpdateWeekDisplay();
        }

        private void HABIT_CHECKER_Load_1(object sender, EventArgs e)
        {
            LoadHabitsForSelectedWeek();
            lblUserHabits.Text = $"{GlobalUser.LoggedInUsername}'s Habits";
        }

        private DateTime GetStartOfWeek(DateTime date)
        {
            int diff = (7 + (date.DayOfWeek - DayOfWeek.Sunday)) % 7;
            return date.AddDays(-diff).Date;
        }

        private void UpdateWeekDisplay()
        {
            lblWeekDisplay.Text = $"{selectedWeekStart:MMM dd} - {selectedWeekStart.AddDays(6):MMM dd, yyyy}";
        }

        private void btnPreviousWeek_Click(object sender, EventArgs e)
        {
            selectedWeekStart = selectedWeekStart.AddDays(-7);
            UpdateWeekDisplay();
            LoadHabitsForSelectedWeek();
        }

        private void btnNextWeek_Click(object sender, EventArgs e)
        {
            selectedWeekStart = selectedWeekStart.AddDays(7);
            UpdateWeekDisplay();
            LoadHabitsForSelectedWeek();
        }

        private void btnCurrentWeek_Click(object sender, EventArgs e)
        {
            selectedWeekStart = GetStartOfWeek(DateTime.Now);
            UpdateWeekDisplay();
            LoadHabitsForSelectedWeek();
        }

        private void LoadHabitsForSelectedWeek()
        {
            tblHabitChecker.Controls.Clear();
            tblHabitChecker.RowStyles.Clear();
            tblHabitChecker.RowCount = 0;

            db.LoadHabits(tblHabitChecker, selectedWeekStart);

            for (int i = 0; i < tblHabitChecker.RowCount; i++)
            {
                RebindDeleteButton(i);
            }
        }
        private void btnAddHabit_Click(object sender, EventArgs e)
        {
            db.AddHabitRow(tblHabitChecker, "", false, false, false, false, false, false, false, selectedWeekStart);
            RebindDeleteButton(tblHabitChecker.RowCount - 1);
        }

        private void btnClearHabits_Click(object sender, EventArgs e)
        {
            tblHabitChecker.Controls.Clear();
            tblHabitChecker.RowStyles.Clear();
            tblHabitChecker.RowCount = 0;
        }

        private void btnSaveHabits_Click(object sender, EventArgs e)
        {
            db.SaveHabitChecker(tblHabitChecker, selectedWeekStart);
        }

        private void DeleteHabitRow(int rowIndex)
        {
            if (MessageBox.Show("Are you sure you want to delete this habit?",
                                "Confirm Delete",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                db.DeleteHabitRow(tblHabitChecker, rowIndex);
                db.LoadHabits(tblHabitChecker, selectedWeekStart);
            }
        }

        private void RebindDeleteButton(int rowIndex)
        {
            Control control = tblHabitChecker.GetControlFromPosition(0, rowIndex);
            if (control is Button btnDelete)
            {
                btnDelete.Click += (s, e) => DeleteHabitRow(rowIndex);
            }
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void HABIT_CHECKER_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0xA1, 0x2, 0);
            }
        }
    }
}
