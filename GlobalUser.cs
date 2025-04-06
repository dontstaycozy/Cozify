using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using finals;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace Cozify//database helper
{
    public static class GlobalUser
    {
        public static string LoggedInUsername { get; set; }
    }

    public class dbHelper
    {
        private static readonly string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = C:\\Users\\fredwil\\Desktop\\Cozify Project\\CozifyUsers.accdb";
        OleDbConnection myConn;
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;


        public void connectionTest()
        {
            myConn = new OleDbConnection(connectionString);
            ds = new DataSet();
            myConn.Open();
            MessageBox.Show("Connected successfully!");
            myConn.Close();
        }
        //login and register stuff
        public void Register(string username, string password)
        {
            // Check if username already exists
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                /*// Check if user exists
                string checkUserQuery = "SELECT COUNT(*) FROM Users WHERE Username = ?";
                using (OleDbCommand cmd = new OleDbCommand(checkUserQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", username);
                    int userExists = (int)cmd.ExecuteScalar();

                    if (userExists > 0)
                    {
                        MessageBox.Show("Username already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }*/

                // Insert new user
                string insertQuery = "INSERT INTO [Users Table] (Username, [Password], CreatedAt) VALUES (?, ?, ?)";
                using (OleDbCommand cmd = new OleDbCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", username);
                    cmd.Parameters.AddWithValue("?", password); // NOTE: You should hash passwords for security!
                    cmd.Parameters.AddWithValue("?", DateTime.Now.ToString("yyyy - MM - dd"));

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Login(string usernameLogin, string passwordLogin)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT COUNT(*) FROM [Users Table] WHERE Username = ? AND [Password] = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", usernameLogin);
                    cmd.Parameters.AddWithValue("?", passwordLogin);

                    int userExists = (int)cmd.ExecuteScalar();

                    if (userExists > 0)
                    {
                        MessageBox.Show("Login Successful!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GlobalUser.LoggedInUsername = usernameLogin;
                        MAIN_HUB mainHub = new MAIN_HUB();
                        mainHub.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username or Password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LoginReg loginReg = new LoginReg();
                        loginReg.Show();
                    }
                }
            }
        }

        public void LoadJournal(ListView journalListView)
        {
            journalListView.Items.Clear();
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Title FROM [Journal Table] WHERE Username = ? ORDER BY EntryDate DESC;";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", GlobalUser.LoggedInUsername);

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string title = reader["Title"].ToString();
                            journalListView.Items.Add(new ListViewItem(title));
                        }
                    }
                }
            }
        }
        public void SaveJournal(string newTitle, string newContent, string dateText, string originalTitle = null)
        {
            if (string.IsNullOrWhiteSpace(newTitle) || string.IsNullOrWhiteSpace(newContent))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime entryDate;
            if (!DateTime.TryParseExact(dateText, new[] { "MM/dd/yyyy", "MMMM d, yyyy" },
                System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out entryDate))
            {
                MessageBox.Show("Invalid date format. Please enter a valid date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                if (originalTitle != null && originalTitle != newTitle)
                {
                    string checkQuery = "SELECT COUNT(*) FROM [Journal Table] WHERE Username = ? AND Title = ?";
                    using (OleDbCommand checkCmd = new OleDbCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("?", GlobalUser.LoggedInUsername);
                        checkCmd.Parameters.AddWithValue("?", newTitle);
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("An entry with this title already exists. Please use a different title.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                string query;
                if (originalTitle != null)
                {
                    query = "UPDATE [Journal Table] SET Title = ?, Content = ?, EntryDate = ? WHERE Username = ? AND Title = ?";
                }
                else
                {
                    query = "INSERT INTO [Journal Table] (Title, Content, EntryDate, Username) VALUES (?, ?, ?, ?)";
                }

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", newTitle);
                    cmd.Parameters.AddWithValue("?", newContent);
                    cmd.Parameters.AddWithValue("?", entryDate.ToString("MM/dd/yyyy"));
                    cmd.Parameters.AddWithValue("?", GlobalUser.LoggedInUsername);

                    if (originalTitle != null) cmd.Parameters.AddWithValue("?", originalTitle);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteJournalEntry(string entryTitle)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string deleteQuery = "DELETE FROM [Journal Table] WHERE Username = ? AND Title = ?";

                using (OleDbCommand cmd = new OleDbCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", GlobalUser.LoggedInUsername);
                    cmd.Parameters.AddWithValue("?", entryTitle);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Journal entry deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void lvview(ListView journalListView, TextBox tbxTitle, TextBox tbxContent, AntdUI.Label tbxDate)
        {
            if (journalListView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = journalListView.SelectedItems[0];
                string selectedTitle = selectedItem.Text;

                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT EntryDate, Content FROM [Journal Table] WHERE Username = ? AND Title = ?;";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", GlobalUser.LoggedInUsername);
                        cmd.Parameters.AddWithValue("?", selectedTitle);

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                DateTime entryDate = Convert.ToDateTime(reader["EntryDate"]);
                                tbxDate.Text = entryDate.ToString("MM/dd/yyyy");
                                tbxTitle.Text = selectedTitle;
                                tbxContent.Text = reader["Content"].ToString();
                            }
                        }
                    }
                }
            }
        }

        // Habit Checker

        public void AddHabitRow(TableLayoutPanel tblHabitChecker, string habitText, bool sun, bool mon, bool tues, bool wed, bool thurs, bool fri, bool sat)
        {
            tblHabitChecker.RowCount++;
            int rowIndex = tblHabitChecker.RowCount - 1;

            TextBox txtHabit = new TextBox
            {
                BorderStyle = BorderStyle.None,
                BackColor = Color.FromArgb(52, 73, 91),
                ForeColor = Color.White,
                Font = new Font("Pixeltype", 23F, FontStyle.Regular),
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                TextAlign = HorizontalAlignment.Left,
                Text = habitText
            };
            tblHabitChecker.Controls.Add(txtHabit, 1, rowIndex);

            bool[] values = { sun, mon, tues, wed, thurs, fri, sat };
            for (int i = 0; i < 7; i++)
            {
                CheckBox chk = new CheckBox
                {
                    Anchor = AnchorStyles.None,
                    AutoSize = false,
                    Size = new Size(30, 30),
                    Margin = new Padding(20, 5, 20, 5),
                    Checked = values[i]
                };
                tblHabitChecker.Controls.Add(chk, i + 2, rowIndex);
            }

            Button btnDelete = new Button
            {
                Text = "X",
                BackColor = Color.FromArgb(40, 56, 69),
                ForeColor = Color.White,
                Font = new Font("Pixeltype", 12F, FontStyle.Regular),
                Size = new Size(20, 20),
                Anchor = AnchorStyles.None,
                FlatStyle = FlatStyle.Flat,
                Tag = rowIndex
            };
            tblHabitChecker.Controls.Add(btnDelete, 0, rowIndex);
        }
        
        public void LoadHabits(TableLayoutPanel tblHabitChecker)
        {
            tblHabitChecker.Controls.Clear();
            tblHabitChecker.RowStyles.Clear();
            tblHabitChecker.RowCount = 0;

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT HabitName, Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday FROM [Habit Checker Table] WHERE Username = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", GlobalUser.LoggedInUsername);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader.GetString(0);
                            bool[] days = new bool[7];
                            for (int i = 0; i < 7; i++)
                                days[i] = reader.GetBoolean(i + 1);

                            AddHabitRow(tblHabitChecker, name, days[0], days[1], days[2], days[3], days[4], days[5], days[6]);
                        }
                    }
                }
            }
        }
        
        public void SaveHabitChecker(TableLayoutPanel tblHabitChecker)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                string deleteQuery = "DELETE FROM [Habit Checker Table] WHERE Username = ?";
                using (OleDbCommand deleteCmd = new OleDbCommand(deleteQuery, conn))
                {
                    deleteCmd.Parameters.AddWithValue("?", GlobalUser.LoggedInUsername);
                    deleteCmd.ExecuteNonQuery();
                }

                string insertQuery = "INSERT INTO [Habit Checker Table] (Username, HabitName, Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)";

                foreach (Control control in tblHabitChecker.Controls)
                {
                    if (control is TextBox txtHabit)
                    {
                        int rowIndex = tblHabitChecker.GetRow(txtHabit);
                        if (tblHabitChecker.GetColumn(txtHabit) != 1) continue;

                        string habit = txtHabit.Text;
                        bool[] checkedDays = new bool[7];
                        for (int i = 0; i < 7; i++)
                        {
                            Control chk = tblHabitChecker.GetControlFromPosition(i + 2, rowIndex);
                            checkedDays[i] = chk is CheckBox box && box.Checked;
                        }

                        using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, conn))
                        {
                            insertCmd.Parameters.AddWithValue("?", GlobalUser.LoggedInUsername);
                            insertCmd.Parameters.AddWithValue("?", habit);
                            foreach (bool val in checkedDays)
                                insertCmd.Parameters.AddWithValue("?", val);

                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        

        // To Do List

        public void AddToDoRow(TableLayoutPanel tblToDoList, string TaskText, bool isDone)
        {
            tblToDoList.RowCount++;
            int rowIndex = tblToDoList.RowCount - 1;

            CheckBox chkDone = new CheckBox
            {
                Checked = isDone,
                Anchor = AnchorStyles.None
            };
            tblToDoList.Controls.Add(chkDone, 2, rowIndex);

            TextBox txtTask = new TextBox
            {
                BorderStyle = BorderStyle.None,
                BackColor = Color.FromArgb(52, 73, 91),
                ForeColor = Color.White,
                Font = new Font("Pixeltype", 20F, FontStyle.Regular),
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                TextAlign = HorizontalAlignment.Left,
                Text = TaskText
            };
            tblToDoList.Controls.Add(txtTask, 1, rowIndex);

            Button btnDelete = new Button
            {
                Text = "X",
                BackColor = Color.FromArgb(40, 56, 69),
                ForeColor = Color.White,
                Font = new Font("Pixeltype", 12F, FontStyle.Regular),
                Size = new Size(23, 23),
                Anchor = AnchorStyles.None,
                FlatStyle = FlatStyle.Flat
            };
            tblToDoList.Controls.Add(btnDelete, 0, rowIndex);

        }

        public void LoadToDoList(TableLayoutPanel tblToDoList)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Activity, isDone FROM [ToDo List Table] WHERE Username = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", GlobalUser.LoggedInUsername);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string activity = reader["Activity"].ToString();
                            bool isDone = reader.GetBoolean(1);
                            AddToDoRow(tblToDoList, activity, isDone);
                        }
                    }
                }
            }
        }

        public void SaveToDoList(TableLayoutPanel tblToDoList)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM [ToDo List Table] WHERE Username = ?;";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", GlobalUser.LoggedInUsername);
                    cmd.ExecuteNonQuery();
                }
                query = "INSERT INTO [ToDo List Table] (Username, Activity, isDone) VALUES (?, ?, ?);";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    foreach (Control control in tblToDoList.Controls)
                    {
                        if (control is CheckBox chkDone)
                        {
                            int rowIndex = tblToDoList.GetRow(chkDone);
                            Control txtTask = tblToDoList.GetControlFromPosition(1, rowIndex);
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("?", GlobalUser.LoggedInUsername);
                            cmd.Parameters.AddWithValue("?", txtTask.Text);
                            cmd.Parameters.AddWithValue("?", chkDone.Checked);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        // pomodoro

        public void SavePomodoroSession(bool completed, int workTime, int breakTime)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO [Pomodoro Table] (Username, WorkTime, BreakTime, Completed, TimeSpent, SessionDate) VALUES (?, ?, ?, ?, ?, ?);";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    int totalTimeSpent = (workTime + breakTime);

                    cmd.Parameters.Add("?", OleDbType.VarChar).Value = GlobalUser.LoggedInUsername;
                    cmd.Parameters.Add("?", OleDbType.Integer).Value = workTime * 60;
                    cmd.Parameters.Add("?", OleDbType.Integer).Value = breakTime * 60;
                    cmd.Parameters.Add("?", OleDbType.Boolean).Value = completed;
                    cmd.Parameters.Add("?", OleDbType.Integer).Value = totalTimeSpent * 60;
                    cmd.Parameters.Add("?", OleDbType.Date).Value = DateTime.Now;

                    cmd.ExecuteNonQuery();
                }
            }
        }

    }

}
