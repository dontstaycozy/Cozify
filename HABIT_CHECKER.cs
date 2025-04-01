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
    public partial class HABIT_CHECKER: Form
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Users\fredwil\Desktop\Cozify Project\CozifyUsers.accdb";

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();


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
            LoadHabits();
            lblUserHabits.Text = GlobalUser.LoggedInUsername + "'s Habits";
        }

        private void btnAddHabit_Click(object sender, EventArgs e)
        {
            AddHabitRow("", false, false, false, false, false, false, false);
        }

        private void LoadHabits()
        {
            tblHabitChecker.Controls.Clear();
            tblHabitChecker.RowStyles.Clear();
            tblHabitChecker.RowCount = 0;

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT HabitName, Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday FROM [Habit Checker Table] WHERE Username = ?;";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", GlobalUser.LoggedInUsername);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string habit = reader.GetString(0);
                            bool isDoneSun = reader.GetBoolean(1);
                            bool isDoneMon = reader.GetBoolean(2);
                            bool isDoneTues = reader.GetBoolean(3);
                            bool isDoneWed = reader.GetBoolean(4);
                            bool isDoneThurs = reader.GetBoolean(5);
                            bool isDoneFri = reader.GetBoolean(6);
                            bool isDoneSat = reader.GetBoolean(7);
                            AddHabitRow(habit, isDoneSun, isDoneMon, isDoneTues, isDoneWed, isDoneThurs, isDoneFri, isDoneSat);
                        }
                    }
                }
            }
        }
        private void btnSaveHabits_Click(object sender, EventArgs e)
        {
            SaveHabits();
        }
        private void SaveHabits()
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string deleteQuery = "DELETE FROM [Habit Checker Table] WHERE Username = ?;";
                using (OleDbCommand cmd = new OleDbCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", GlobalUser.LoggedInUsername);
                    cmd.ExecuteNonQuery();
                }

                string insertQuery = "INSERT INTO [Habit Checker Table] (Username, HabitName, Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?);";

                foreach (Control control in tblHabitChecker.Controls)
                {
                    if (control is TextBox txtHabit)
                    {
                        int rowIndex = tblHabitChecker.GetRow(txtHabit);
                        if (tblHabitChecker.GetColumn(txtHabit) != 1)
                        {
                            continue;
                        }
                        string habit = txtHabit.Text;
                        bool[] isDoneValues = new bool[7];

                        for (int i = 0; i < 7; i++)
                        {
                            Control chkControl = tblHabitChecker.GetControlFromPosition(i + 2, rowIndex);
                            if (chkControl is CheckBox chkDay)
                            {
                                isDoneValues[i] = chkDay.Checked;
                            }
                        }
                        using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, conn))
                        {
                            insertCmd.Parameters.AddWithValue("?", GlobalUser.LoggedInUsername);
                            insertCmd.Parameters.AddWithValue("?", habit);
                            insertCmd.Parameters.AddWithValue("?", isDoneValues[0]);
                            insertCmd.Parameters.AddWithValue("?", isDoneValues[1]);
                            insertCmd.Parameters.AddWithValue("?", isDoneValues[2]);
                            insertCmd.Parameters.AddWithValue("?", isDoneValues[3]);
                            insertCmd.Parameters.AddWithValue("?", isDoneValues[4]);
                            insertCmd.Parameters.AddWithValue("?", isDoneValues[5]);
                            insertCmd.Parameters.AddWithValue("?", isDoneValues[6]);

                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private void AddHabitRow(string habitsText, bool isDoneSun, bool isDoneMon, bool isDoneTues, bool isDoneWed, bool isDoneThurs, bool isDoneFri, bool isDoneSat)
        {

            tblHabitChecker.RowCount++;
            int rowIndex = tblHabitChecker.RowCount-1;

            TextBox txtHabit = new TextBox
            {
                BorderStyle = BorderStyle.None,
                BackColor = Color.FromArgb(52, 73, 91),
                ForeColor = Color.White,
                Font = new Font("Pixeltype", 23F, FontStyle.Regular),
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                TextAlign = HorizontalAlignment.Left,
                Text = habitsText
            };
            tblHabitChecker.Controls.Add(txtHabit, 1, rowIndex);

            bool[] isDoneValues = { isDoneSun, isDoneMon, isDoneTues, isDoneWed, isDoneThurs, isDoneFri, isDoneSat };

            for (int i = 0; i < 7; i++)
            {
                CheckBox chkDay = new CheckBox
                {
                    Anchor = AnchorStyles.None,
                    AutoSize = false,
                    Size = new Size(30, 30),
                    Margin = new Padding(20, 5, 20, 5),
                    Checked = isDoneValues[i]
                };
                tblHabitChecker.Controls.Add(chkDay, i + 2, rowIndex);
            }

            Button btnDelete = new Button
            {
                Text = "X",
                BackColor = Color.FromArgb(40, 56, 69),
                ForeColor = Color.White,
                Font = new Font("Pixeltype", 12F, FontStyle.Regular),
                Size = new Size(20, 20),
                Anchor = AnchorStyles.None,
                FlatStyle = FlatStyle.Flat
            };

            btnDelete.Click += (s, e) => DeleteHabitRow(rowIndex);
            tblHabitChecker.Controls.Add(btnDelete, 0, rowIndex);
            txtHabit.Focus();
        }

        private void DeleteHabitRow(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= tblHabitChecker.RowCount)
                return;

            // Remove controls in the specified row
            for (int i = 0; i < tblHabitChecker.ColumnCount; i++)
            {
                Control control = tblHabitChecker.GetControlFromPosition(i, rowIndex);
                if (control != null)
                {
                    tblHabitChecker.Controls.Remove(control);
                    control.Dispose();
                }
            }

            // Move all rows up
            for (int i = rowIndex + 1; i < tblHabitChecker.RowCount; i++)
            {
                for (int j = 0; j < tblHabitChecker.ColumnCount; j++)
                {
                    Control control = tblHabitChecker.GetControlFromPosition(j, i);
                    if (control != null)
                        tblHabitChecker.SetRow(control, i - 1);
                }
            }

            tblHabitChecker.RowCount--;
        }

        
    }
}
