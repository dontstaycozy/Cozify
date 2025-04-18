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
using Cozify;

namespace finals
{
    public partial class HABIT_CHECKER: BaseForm
    {
        public HABIT_CHECKER()
        {
            InitializeComponent();
            this.MouseDown += HABIT_CHECKER_MouseDown;
        }

        private void HABIT_CHECKER_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0xA1, 0x2, 0);
            }
        }

        private void HABIT_CHECKER_Load_1(object sender, EventArgs e)
        {
            tblHabitChecker.Controls.Clear();
            tblHabitChecker.RowStyles.Clear();
            tblHabitChecker.RowCount = 0;
            db.LoadHabits(tblHabitChecker);
            for (int i = 0; i < tblHabitChecker.RowCount; i++)
            {
                RebindDeleteButton(i);
            }
            lblUserHabits.Text = GlobalUser.LoggedInUsername + "'s Habits";
        }

        private void btnAddHabit_Click(object sender, EventArgs e)
        {
            db.AddHabitRow(tblHabitChecker, "", false, false, false, false, false, false, false);
            RebindDeleteButton(tblHabitChecker.RowCount - 1);
        }

        // rebind the delete button event after adding a row
        private void RebindDeleteButton(int rowIndex)
        {
            Control control = tblHabitChecker.GetControlFromPosition(0, rowIndex);
            if (control is Button btnDelete)
            {
                btnDelete.Click += (s, e) => DeleteHabitRow(rowIndex);
            }
        }
        // delete the row and rebind the delete button event for the remaining rows
        private void DeleteHabitRow(int rowIndex)
        {
            db.DeleteHabitRow(tblHabitChecker, rowIndex);
        }

        private void btnSaveHabits_Click(object sender, EventArgs e)
        {
            db.SaveHabitChecker(tblHabitChecker);
        }

        private void btnClearHabits_Click(object sender, EventArgs e)
        {
            tblHabitChecker.Controls.Clear();
            tblHabitChecker.RowStyles.Clear();
            tblHabitChecker.RowCount = 0;
        }
    }
}
