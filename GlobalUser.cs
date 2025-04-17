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
using System.Collections;
using System.Diagnostics;
using System.Net.NetworkInformation;

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

        public void DeleteAcc()
        {
            string username = GlobalUser.LoggedInUsername;

            DialogResult result = MessageBox.Show("Are you sure you want to delete your account? This action cannot be undone.",
                                                  "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    string deleteJournalsQuery = "DELETE FROM [Journal Table] WHERE Username = ?";
                    string deletePomodoroQuery = "DELETE FROM [Pomodoro Table] WHERE Username = ?";
                    string deleteHabitsQuery = "DELETE FROM [Habit Checker Table] WHERE Username = ?";
                    string deleteToDoQuery = "DELETE FROM [ToDo List Table] WHERE Username = ?";
                    string deleteUserQuery = "DELETE FROM [Users Table] WHERE Username = ?";

                    using (OleDbCommand cmd1 = new OleDbCommand(deleteJournalsQuery, conn))
                    {
                        cmd1.Parameters.AddWithValue("?", username);
                        cmd1.ExecuteNonQuery();
                    }

                    using (OleDbCommand cmd2 = new OleDbCommand(deletePomodoroQuery, conn))
                    {
                        cmd2.Parameters.AddWithValue("?", username);
                        cmd2.ExecuteNonQuery();
                    }

                    using (OleDbCommand cmd3 = new OleDbCommand(deleteUserQuery, conn))
                    {
                        cmd3.Parameters.AddWithValue("?", username);
                        cmd3.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Your account has been deleted successfully.", "Account Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                foreach (Form form in Application.OpenForms)
                {
                    if (form is MAIN_HUB)
                    {
                        form.Close();
                        break;
                    }
                }

                // Log the user out and return to login screen
                GlobalUser.LoggedInUsername = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while deleting the account:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ClearData()
        {
            string username = GlobalUser.LoggedInUsername;

            DialogResult result = MessageBox.Show("Are you sure you want to clear your account? This action cannot be undone.",
                                                  "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.Yes)
                return;

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    string deleteJournalsQuery = "DELETE FROM [Journal Table] WHERE Username = ?";
                    string deletePomodoroQuery = "DELETE FROM [Pomodoro Table] WHERE Username = ?";
                    string deleteHabitsQuery = "DELETE FROM [Habit Checker Table] WHERE Username = ?";
                    string deleteToDoQuery = "DELETE FROM [ToDo List Table] WHERE Username = ?";

                    using (OleDbCommand cmd1 = new OleDbCommand(deleteJournalsQuery, conn))
                    using (OleDbCommand cmd2 = new OleDbCommand(deletePomodoroQuery, conn))
                    using (OleDbCommand cmd3 = new OleDbCommand(deleteHabitsQuery, conn))
                    using (OleDbCommand cmd4 = new OleDbCommand(deleteToDoQuery, conn))
                    {
                        cmd1.Parameters.AddWithValue("?", username);
                        cmd2.Parameters.AddWithValue("?", username);
                        cmd3.Parameters.AddWithValue("?", username);
                        cmd4.Parameters.AddWithValue("?", username);

                        cmd1.ExecuteNonQuery();
                        cmd2.ExecuteNonQuery();
                        cmd3.ExecuteNonQuery();
                        cmd4.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Your account has been cleared successfully.", "Account Cleared", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while clearing the account:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //login and register stuff
        public void Register(string username, string password)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    // Check if user exists
                    string checkUserQuery = "SELECT COUNT(*) FROM [Users Table] WHERE Username = ?";
                    using (OleDbCommand cmd = new OleDbCommand(checkUserQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        int userExists = (int)cmd.ExecuteScalar();

                        if (userExists > 0)
                        {
                            MessageBox.Show("Username already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Insert new user with explicit parameter types
                    string insertQuery = @"
                INSERT INTO [Users Table] 
                (Username, [Password], CreatedAt, TimeSpentUsingCozify, NoOfTimesCozifyOpened, LastActive) 
                VALUES (?, ?, ?, ?, ?, ?)";

                    using (OleDbCommand cmd = new OleDbCommand(insertQuery, conn))
                    {
                        // Add parameters with explicit types
                        cmd.Parameters.Add("@username", OleDbType.VarChar).Value = username;
                        cmd.Parameters.Add("@password", OleDbType.VarChar).Value = password;

                        // Use proper date format without spaces
                        cmd.Parameters.Add("@createdAt", OleDbType.Date).Value = DateTime.Now;

                        // Numeric defaults
                        cmd.Parameters.Add("@timeSpent", OleDbType.Double).Value = 0.0;
                        cmd.Parameters.Add("@launches", OleDbType.Integer).Value = 0;
                        cmd.Parameters.Add("@lastActive", OleDbType.Date).Value = DateTime.Now;

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Registration failed - no rows affected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (OleDbException dbEx)
            {
                MessageBox.Show($"Database error: {dbEx.Message}\n\nPlease check your database structure.",
                              "Database Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
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

        //journal stuff

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

        public int JournalCount()
        {
            int count = 0;

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM [Journal Table] WHERE Username = ?";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", GlobalUser.LoggedInUsername);
                    return Convert.ToInt32(cmd.ExecuteScalar());
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

        public class HabitMetaData
        {
            public DateTime HabitDateAdded { get; set; }
            public bool IsDeleted { get; set; }
        }

        public void AddHabitRow(TableLayoutPanel tblHabitChecker, string habitText, bool sun, bool mon, bool tues, bool wed, bool thurs, bool fri, bool sat, DateTime? dateAdded = null)
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
                Text = habitText,
                Tag = new HabitMetaData
                {
                    HabitDateAdded = dateAdded ?? DateTime.Now,
                    IsDeleted = false
                }
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
                string query = @"SELECT HabitName, Sunday, Monday, Tuesday, Wednesday, 
                        Thursday, Friday, Saturday, HabitDateAdded
                        FROM [Habit Checker Table] 
                        WHERE Username = ? 
                        AND isHabitDeleted = False
                        ORDER BY HabitDateAdded DESC";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.Add("@username", OleDbType.VarChar).Value = GlobalUser.LoggedInUsername;

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader["HabitName"].ToString();
                            bool[] days = new bool[7];
                            for (int i = 0; i < 7; i++)
                            {
                                days[i] = Convert.ToBoolean(reader[i + 1]);
                            }
                            DateTime dateAdded = Convert.ToDateTime(reader["HabitDateAdded"]);

                            AddHabitRow(tblHabitChecker, name, days[0], days[1], days[2],
                                       days[3], days[4], days[5], days[6], dateAdded);
                        }
                    }
                }
            }
        }

        public int HabitCount()
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT COUNT(*) 
                FROM [Habit Checker Table] 
                WHERE Username = ?";


                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", GlobalUser.LoggedInUsername);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        /*
                 
                1. Weekly or Monthly Analytics
                If you want to say something like:

                “You added 4 new habits this week!”

                You’ll need the HabitDateAdded value and compare it with the current date.

                2. Show “Recently Added Habits”
                Display to the user which habits they just added in the past few days.

                csharp
                Copy
                Edit
                if ((DateTime.Now - dateAdded).TotalDays <= 7)
                {
                            // mark it as recently added
                        }
                3. Streak Tracking (future)
                You can use HabitDateAdded to calculate:

                How long a habit has existed

                When a habit streak started or reset

                4. Sorting Habits by Date
                You could list habits from newest to oldest for better UI/UX.

                5. User Feedback
                You could show messages like:

                "You’ve been building habits since April 8, 2025!"
                
        */
        public void SaveHabitChecker(TableLayoutPanel tblHabitChecker)
        {
            Debug.WriteLine("SaveHabitChecker called");
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    // Get all existing habits for this user
                    var existingHabits = new List<(string Name, DateTime DateAdded)>();
                    string getExistingQuery = @"SELECT HabitName, HabitDateAdded 
                                      FROM [Habit Checker Table] 
                                      WHERE Username = ?";

                    using (OleDbCommand cmd = new OleDbCommand(getExistingQuery, conn))
                    {
                        cmd.Parameters.Add("@username", OleDbType.VarChar).Value = GlobalUser.LoggedInUsername;
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                existingHabits.Add((reader["HabitName"].ToString(),
                                                  Convert.ToDateTime(reader["HabitDateAdded"])));
                            }
                        }
                    }

                    // Process all habits in the UI
                    int savedCount = 0;
                    foreach (Control control in tblHabitChecker.Controls)
                    {
                        if (control is TextBox txtHabit && tblHabitChecker.GetColumn(txtHabit) == 1)
                        {
                            int rowIndex = tblHabitChecker.GetRow(txtHabit);
                            string habit = txtHabit.Text;
                            var meta = txtHabit.Tag as HabitMetaData;
                            if (meta == null) continue;

                            bool[] checkedDays = new bool[7];
                            for (int i = 0; i < 7; i++)
                            {
                                Control chk = tblHabitChecker.GetControlFromPosition(i + 2, rowIndex);
                                checkedDays[i] = chk is CheckBox box && box.Checked;
                            }

                            // Check if this habit exists in database
                            bool existsInDb = existingHabits.Any(h =>
                                h.Name.Equals(habit, StringComparison.OrdinalIgnoreCase) &&
                                h.DateAdded == meta.HabitDateAdded);

                            if (existsInDb)
                            {
                                // Update existing habit
                                string updateQuery = @"UPDATE [Habit Checker Table] 
                                            SET Sunday = ?, Monday = ?, Tuesday = ?,
                                                Wednesday = ?, Thursday = ?, Friday = ?,
                                                Saturday = ?, isHabitDeleted = ?
                                            WHERE Username = ? 
                                            AND HabitName = ?
                                            AND HabitDateAdded = ?";

                                using (OleDbCommand cmd = new OleDbCommand(updateQuery, conn))
                                {
                                    // Add day parameters
                                    for (int i = 0; i < 7; i++)
                                    {
                                        cmd.Parameters.Add($"@day{i}", OleDbType.Boolean).Value = checkedDays[i];
                                    }

                                    cmd.Parameters.Add("@isDeleted", OleDbType.Boolean).Value = meta.IsDeleted;
                                    cmd.Parameters.Add("@username", OleDbType.VarChar).Value = GlobalUser.LoggedInUsername;
                                    cmd.Parameters.Add("@habitName", OleDbType.VarChar).Value = habit;
                                    cmd.Parameters.Add("@dateAdded", OleDbType.Date).Value = meta.HabitDateAdded;

                                    cmd.ExecuteNonQuery();
                                    savedCount++;
                                }
                            }
                            else
                            {
                                // Insert new habit
                                string insertQuery = @"INSERT INTO [Habit Checker Table] 
                                            (Username, HabitName, Sunday, Monday, Tuesday,
                                             Wednesday, Thursday, Friday, Saturday, 
                                             HabitDateAdded, isHabitDeleted)
                                            VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

                                using (OleDbCommand cmd = new OleDbCommand(insertQuery, conn))
                                {
                                    cmd.Parameters.Add("@username", OleDbType.VarChar).Value = GlobalUser.LoggedInUsername;
                                    cmd.Parameters.Add("@habitName", OleDbType.VarChar).Value = habit;

                                    // Add day parameters
                                    for (int i = 0; i < 7; i++)
                                    {
                                        cmd.Parameters.Add($"@day{i}", OleDbType.Boolean).Value = checkedDays[i];
                                    }

                                    cmd.Parameters.Add("@dateAdded", OleDbType.Date).Value = meta.HabitDateAdded;
                                    cmd.Parameters.Add("@isDeleted", OleDbType.Boolean).Value = meta.IsDeleted;

                                    cmd.ExecuteNonQuery();
                                    savedCount++;
                                }
                            }
                        }
                    }

                    // Mark habits not in UI as deleted
                    foreach (var habit in existingHabits)
                    {
                        bool existsInUI = false;
                        foreach (Control control in tblHabitChecker.Controls)
                        {
                            if (control is TextBox txtHabit &&
                                tblHabitChecker.GetColumn(txtHabit) == 1 &&
                                txtHabit.Text.Equals(habit.Name, StringComparison.OrdinalIgnoreCase) &&
                                (txtHabit.Tag as HabitMetaData)?.HabitDateAdded == habit.DateAdded)
                            {
                                existsInUI = true;
                                break;
                            }
                        }

                        if (!existsInUI)
                        {
                            string markDeletedQuery = @"UPDATE [Habit Checker Table] 
                                              SET isHabitDeleted = True
                                              WHERE Username = ? 
                                              AND HabitName = ?
                                              AND HabitDateAdded = ?";

                            using (OleDbCommand cmd = new OleDbCommand(markDeletedQuery, conn))
                            {
                                cmd.Parameters.Add("@username", OleDbType.VarChar).Value = GlobalUser.LoggedInUsername;
                                cmd.Parameters.Add("@habitName", OleDbType.VarChar).Value = habit.Name;
                                cmd.Parameters.Add("@dateAdded", OleDbType.Date).Value = habit.DateAdded;
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    Debug.WriteLine($"Saved {savedCount} habits");
                    MessageBox.Show($"Successfully saved {savedCount} habits", "Saved",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Save error: {ex}");
                MessageBox.Show($"Failed to save habits: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteHabitRow(TableLayoutPanel tblHabitChecker, int rowIndex)
        {
            var txtHabit = tblHabitChecker.GetControlFromPosition(1, rowIndex) as TextBox;
            if (txtHabit?.Tag is HabitMetaData meta)
            {
                // Mark as deleted in the metadata
                meta.IsDeleted = true;

                // Remove from UI
                for (int col = 0; col < tblHabitChecker.ColumnCount; col++)
                {
                    var control = tblHabitChecker.GetControlFromPosition(col, rowIndex);
                    if (control != null)
                    {
                        tblHabitChecker.Controls.Remove(control);
                        control.Dispose();
                    }
                }

                // Shift remaining rows up
                for (int r = rowIndex + 1; r < tblHabitChecker.RowCount; r++)
                {
                    for (int c = 0; c < tblHabitChecker.ColumnCount; c++)
                    {
                        var control = tblHabitChecker.GetControlFromPosition(c, r);
                        if (control != null) tblHabitChecker.SetRow(control, r - 1);
                    }
                }

                if (tblHabitChecker.RowCount > 0)
                {
                    tblHabitChecker.RowCount--;
                }

                if (tblHabitChecker.RowStyles.Count > rowIndex)
                    tblHabitChecker.RowStyles.RemoveAt(rowIndex);

                // Save changes to database
                SaveHabitChecker(tblHabitChecker);
            }
        }

        //To DO List
        public class TaskMetaData
        {
            public DateTime TaskDateAdded { get; set; }
            public DateTime? TaskDateCompleted { get; set; }
            public bool IsDeleted { get; set; }
        }

        public void AddToDoRow(TableLayoutPanel tblToDoList, string TaskText, bool isDone, DateTime dateAdded, DateTime? dateCompleted = null, bool isDeleted = false)
        {
            tblToDoList.RowCount++;
            int rowIndex = tblToDoList.RowCount - 1;

            CheckBox chkDone = new CheckBox
            {
                Checked = isDone,
                Anchor = AnchorStyles.None,
                Tag = new TaskMetaData
                {
                    TaskDateAdded = dateAdded,
                    TaskDateCompleted = dateCompleted,
                    IsDeleted = isDeleted
                }
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
                Text = TaskText,
                Tag = dateAdded // Store creation date for reference
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

        public void LoadToDoList(TableLayoutPanel tblToDoList, bool includeDeleted = false)
        {
            tblToDoList.Controls.Clear();
            tblToDoList.RowCount = 0;

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT Activity, isDone, TaskDateAdded, TaskDateCompleted, isTaskDeleted 
                        FROM [ToDo List Table] 
                        WHERE Username = ?";

                if (!includeDeleted)
                {
                    query += " AND isTaskDeleted = False";
                }

                query += " ORDER BY TaskDateAdded DESC";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.Add("@username", OleDbType.VarChar).Value = GlobalUser.LoggedInUsername;

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string activity = reader["Activity"].ToString();
                            bool isDone = Convert.ToBoolean(reader["isDone"]);
                            DateTime dateAdded = Convert.ToDateTime(reader["TaskDateAdded"]);
                            DateTime? dateCompleted = reader.IsDBNull(3) ? null : (DateTime?)reader["TaskDateCompleted"];
                            bool isDeleted = includeDeleted && Convert.ToBoolean(reader["isTaskDeleted"]);

                            AddToDoRow(tblToDoList, activity, isDone, dateAdded, dateCompleted, isDeleted);
                        }
                    }
                }
            }
        }

        public int ToDoCount(bool includeDeleted = false)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT COUNT(*) 
                        FROM [ToDo List Table] 
                        WHERE Username = ?";

                if (!includeDeleted)
                {
                    query += " AND isTaskDeleted = False";
                }

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.Add("@username", OleDbType.VarChar).Value = GlobalUser.LoggedInUsername;
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public int CompleteToDoCount(bool countCompleted, bool includeDeleted = false)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT COUNT(*) 
                        FROM [ToDo List Table] 
                        WHERE Username = ? 
                        AND isDone = ?";

                if (!includeDeleted)
                {
                    query += " AND isTaskDeleted = False";
                }

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.Add("@username", OleDbType.VarChar).Value = GlobalUser.LoggedInUsername;
                    cmd.Parameters.Add("@isDone", OleDbType.Boolean).Value = countCompleted;
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public void SaveToDoList(TableLayoutPanel tblToDoList)
        {
            Debug.WriteLine("SaveToDoList called");
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    // Get all existing tasks (including deleted ones)
                    var existingTasks = new List<(string Activity, DateTime DateAdded)>();
                    string getExistingQuery = @"SELECT Activity, TaskDateAdded 
                                      FROM [ToDo List Table] 
                                      WHERE Username = ?";

                    using (OleDbCommand cmd = new OleDbCommand(getExistingQuery, conn))
                    {
                        cmd.Parameters.Add("@username", OleDbType.VarChar).Value = GlobalUser.LoggedInUsername;
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                existingTasks.Add((reader["Activity"].ToString(),
                                                Convert.ToDateTime(reader["TaskDateAdded"])));
                            }
                        }
                    }

                    // Process all tasks in the UI
                    int savedCount = 0;
                    foreach (Control control in tblToDoList.Controls)
                    {
                        if (control is CheckBox chkDone)
                        {
                            int rowIndex = tblToDoList.GetRow(chkDone);
                            var txtTask = tblToDoList.GetControlFromPosition(1, rowIndex) as TextBox;
                            if (txtTask == null) continue;

                            var meta = chkDone.Tag as TaskMetaData;
                            if (meta == null) continue;

                            // Update completion date if newly checked
                            if (chkDone.Checked && meta.TaskDateCompleted == null)
                            {
                                meta.TaskDateCompleted = DateTime.Now;
                            }

                            // Check if task exists in database
                            bool existsInDb = existingTasks.Any(t =>
                                t.Activity.Equals(txtTask.Text, StringComparison.OrdinalIgnoreCase) &&
                                t.DateAdded == meta.TaskDateAdded);

                            if (existsInDb)
                            {
                                // Update existing task
                                string updateQuery = @"UPDATE [ToDo List Table] 
                                            SET isDone = ?, 
                                                TaskDateCompleted = ?,
                                                isTaskDeleted = ?
                                            WHERE Username = ? 
                                            AND Activity = ?
                                            AND TaskDateAdded = ?";

                                using (OleDbCommand cmd = new OleDbCommand(updateQuery, conn))
                                {
                                    cmd.Parameters.Add("@isDone", OleDbType.Boolean).Value = chkDone.Checked;
                                    cmd.Parameters.Add("@dateCompleted", OleDbType.Date).Value =
                                        meta.TaskDateCompleted.HasValue ?
                                        (object)meta.TaskDateCompleted.Value :
                                        DBNull.Value;
                                    cmd.Parameters.Add("@isDeleted", OleDbType.Boolean).Value = meta.IsDeleted;
                                    cmd.Parameters.Add("@username", OleDbType.VarChar).Value = GlobalUser.LoggedInUsername;
                                    cmd.Parameters.Add("@activity", OleDbType.VarChar).Value = txtTask.Text;
                                    cmd.Parameters.Add("@dateAdded", OleDbType.Date).Value = meta.TaskDateAdded;

                                    cmd.ExecuteNonQuery();
                                    savedCount++;
                                }
                            }
                            else
                            {
                                // Insert new task
                                string insertQuery = @"INSERT INTO [ToDo List Table] 
                                            (Username, Activity, isDone, TaskDateAdded, 
                                             TaskDateCompleted, isTaskDeleted)
                                            VALUES (?, ?, ?, ?, ?, ?)";

                                using (OleDbCommand cmd = new OleDbCommand(insertQuery, conn))
                                {
                                    cmd.Parameters.Add("@username", OleDbType.VarChar).Value = GlobalUser.LoggedInUsername;
                                    cmd.Parameters.Add("@activity", OleDbType.VarChar).Value = txtTask.Text;
                                    cmd.Parameters.Add("@isDone", OleDbType.Boolean).Value = chkDone.Checked;
                                    cmd.Parameters.Add("@dateAdded", OleDbType.Date).Value = meta.TaskDateAdded;
                                    cmd.Parameters.Add("@dateCompleted", OleDbType.Date).Value =
                                        meta.TaskDateCompleted.HasValue ?
                                        (object)meta.TaskDateCompleted.Value :
                                        DBNull.Value;
                                    cmd.Parameters.Add("@isDeleted", OleDbType.Boolean).Value = meta.IsDeleted;

                                    cmd.ExecuteNonQuery();
                                    savedCount++;
                                }
                            }
                        }
                    }

                    // Mark tasks not in UI as deleted
                    foreach (var task in existingTasks)
                    {
                        bool existsInUI = false;
                        foreach (Control control in tblToDoList.Controls)
                        {
                            if (control is TextBox txtBox &&
                                tblToDoList.GetColumn(txtBox) == 1 &&
                                txtBox.Text.Equals(task.Activity, StringComparison.OrdinalIgnoreCase) &&
                                (tblToDoList.GetControlFromPosition(2, tblToDoList.GetRow(txtBox))?.Tag as TaskMetaData)?.TaskDateAdded == task.DateAdded)
                            {
                                existsInUI = true;
                                break;
                            }
                        }

                        if (!existsInUI)
                        {
                            string markDeletedQuery = @"UPDATE [ToDo List Table] 
                                              SET isTaskDeleted = True
                                              WHERE Username = ? 
                                              AND Activity = ?
                                              AND TaskDateAdded = ?";

                            using (OleDbCommand cmd = new OleDbCommand(markDeletedQuery, conn))
                            {
                                cmd.Parameters.Add("@username", OleDbType.VarChar).Value = GlobalUser.LoggedInUsername;
                                cmd.Parameters.Add("@activity", OleDbType.VarChar).Value = task.Activity;
                                cmd.Parameters.Add("@dateAdded", OleDbType.Date).Value = task.DateAdded;
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    Debug.WriteLine($"Saved {savedCount} tasks");
                    MessageBox.Show($"Successfully saved {savedCount} tasks", "Saved",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Save error: {ex}");
                MessageBox.Show($"Failed to save tasks: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteToDoRow(TableLayoutPanel tblToDoList, int rowIndex)
        {
            var chkDone = tblToDoList.GetControlFromPosition(2, rowIndex) as CheckBox;
            var txtTask = tblToDoList.GetControlFromPosition(1, rowIndex) as TextBox;

            if (chkDone?.Tag is TaskMetaData meta && txtTask != null)
            {
                try
                {
                    using (OleDbConnection conn = new OleDbConnection(connectionString))
                    {
                        conn.Open();
                        string query = @"UPDATE [ToDo List Table] 
                               SET isTaskDeleted = True
                               WHERE Username = ? 
                               AND Activity = ?
                               AND TaskDateAdded = ?";

                        using (OleDbCommand cmd = new OleDbCommand(query, conn))
                        {
                            cmd.Parameters.Add("@username", OleDbType.VarChar).Value = GlobalUser.LoggedInUsername;
                            cmd.Parameters.Add("@activity", OleDbType.VarChar).Value = txtTask.Text;
                            cmd.Parameters.Add("@dateAdded", OleDbType.Date).Value = meta.TaskDateAdded;

                            int rowsAffected = cmd.ExecuteNonQuery();
                            Debug.WriteLine($"Marked {rowsAffected} task(s) as deleted");

                            if (rowsAffected > 0)
                            {
                                // Remove from UI
                                tblToDoList.Controls.Remove(chkDone);
                                tblToDoList.Controls.Remove(txtTask);
                                var btnDelete = tblToDoList.GetControlFromPosition(0, rowIndex);
                                if (btnDelete != null) tblToDoList.Controls.Remove(btnDelete);

                                // Shift remaining rows up
                                for (int r = rowIndex + 1; r < tblToDoList.RowCount; r++)
                                {
                                    for (int c = 0; c < tblToDoList.ColumnCount; c++)
                                    {
                                        var control = tblToDoList.GetControlFromPosition(c, r);
                                        if (control != null) tblToDoList.SetRow(control, r - 1);
                                    }
                                }

                                if (tblToDoList.RowCount > 0)
                                {
                                    tblToDoList.RowCount--;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Delete error: {ex}");
                    MessageBox.Show($"Failed to delete task: {ex.Message}", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // Stats/Activity of user
        //note: work on this later
        public void LoadUserStats(Label UserTimeSpent, Label TimesLaunched, Label LastActive)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT TimeSpentUsingCozify, NoOfTimesCozifyOpened, LastActive FROM [Users Table] WHERE Username = ?";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", GlobalUser.LoggedInUsername);

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                double timeSpent = reader.IsDBNull(0) ? 0 : Convert.ToDouble(reader.GetValue(0));
                                int timesOpened = reader.IsDBNull(1) ? 0 : Convert.ToInt32(reader.GetValue(1));
                                string lastActive = reader.IsDBNull(2)
                                    ? "Never active"
                                    : reader.GetDateTime(2).ToString("MMM dd, h:mm tt");

                                UserTimeSpent.Text = $"Time spent: {timeSpent:F2} hrs";
                                TimesLaunched.Text = $"Times Cozify launched: {timesOpened}";
                                LastActive.Text = $"Last active: {lastActive}";
                            }
                            else
                            {
                                throw new Exception("User not found in the database.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading stats: {ex.Message}\n\nPlease check database structure.");
                UserTimeSpent.Text = "Time Spent: 0 hours";
                TimesLaunched.Text = "Times Cozify launched: 0";
                LastActive.Text = "Last active: Never active";
            }
        }

        private double UserSessionSeconds = 0;
        private Timer UserSessionTimer;

        public void SessionStartTime()
        {
            UserSessionSeconds = 0;

            UserSessionTimer = new Timer();
            UserSessionTimer.Interval = 1000; // 1 second interval
            UserSessionTimer.Tick += (sender, e) => UserSessionSeconds++;
            UserSessionTimer.Start();
        }

        public void StopSessionTimer()
        {
            if (UserSessionSeconds <= 0)
            {
                UserSessionSeconds = 0;
                return;
            }

            double hoursSpent = UserSessionSeconds / 3600.0;
            Debug.WriteLine($"Preparing to save session data: {hoursSpent:F4} hours");

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    // First verify user exists
                    string checkUserQuery = "SELECT COUNT(*) FROM [Users Table] WHERE Username = ?";
                    using (OleDbCommand checkCmd = new OleDbCommand(checkUserQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("?", GlobalUser.LoggedInUsername);
                        int userCount = (int)checkCmd.ExecuteScalar();

                        if (userCount == 0)
                        {
                            MessageBox.Show($"User '{GlobalUser.LoggedInUsername}' not found in database",
                                          "Update Failed",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Proceed with update
                    string updateQuery = @"
                        UPDATE [Users Table]
                        SET 
                            TimeSpentUsingCozify = TimeSpentUsingCozify + ?,
                            LastActive = ?,
                            NoOfTimesCozifyOpened = NoOfTimesCozifyOpened + 1
                        WHERE Username = ?";

                    using (OleDbCommand cmd = new OleDbCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("?", hoursSpent);
                        cmd.Parameters.AddWithValue("?", DateTime.Now);
                        cmd.Parameters.AddWithValue("?", GlobalUser.LoggedInUsername);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        Debug.WriteLine($"Rows affected: {rowsAffected}");

                        if (rowsAffected > 0)
                        {
                            Debug.WriteLine($"Successfully updated user {GlobalUser.LoggedInUsername}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Update failed: {ex}");
                MessageBox.Show($"Failed to save session data:\n{ex.Message}",
                               "Database Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
            finally
            {
                if (UserSessionTimer != null)
                {
                    UserSessionTimer.Stop();
                    UserSessionTimer.Dispose();
                    UserSessionTimer = null;
                }
                UserSessionSeconds = 0;
            }
        }

    }
}
