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
using System.Globalization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Net;
using System.Net.Mail;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic;
namespace Cozify//database helper
{
    public static class GlobalUser
    {
        public static string LoggedInUsername { get; set; }
    }

    public class dbHelper
    {
        private static readonly string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = C:\\Users\\fredwil\\Desktop\\Cozify Project\\CozifyUsers.accdb";

        private OleDbConnection myConn;
        private OleDbDataAdapter da;
        private OleDbCommand cmd;
        private DataSet ds;

        public void connectionTest()
        {
            try
            {
                using (myConn = new OleDbConnection(connectionString))
                {
                    myConn.Open();
                    MessageBox.Show("Connected successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection failed: {ex.Message}");
            }
        }

        public void DeleteAcc()
        {
            string username = GlobalUser.LoggedInUsername;

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete your account? This action cannot be undone.",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    // Delete all user data from related tables
                    string[] deleteQueries = {
                        "DELETE FROM [Journal Table] WHERE Username = ?",
                        "DELETE FROM [Pomodoro Table] WHERE Username = ?",
                        "DELETE FROM [Habit Checker Table] WHERE Username = ?",
                        "DELETE FROM [ToDo List Table] WHERE Username = ?",
                        "DELETE FROM [Users Table] WHERE Username = ?"
                    };

                    foreach (string query in deleteQueries)
                    {
                        using (OleDbCommand cmd = new OleDbCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("?", username);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Your account has been deleted successfully.",
                        "Account Deleted",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Close application and return to login
                    GlobalUser.LoggedInUsername = null;
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting the account:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        public void ClearData()
        {
            string username = GlobalUser.LoggedInUsername;

            DialogResult result = MessageBox.Show(
                "Are you sure you want to clear your account? This action cannot be undone.",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    // Clear data from all feature tables
                    string[] clearQueries = {
                        "DELETE FROM [Journal Table] WHERE Username = ?",
                        "DELETE FROM [Pomodoro Table] WHERE Username = ?",
                        "DELETE FROM [Habit Checker Table] WHERE Username = ?",
                        "DELETE FROM [ToDo List Table] WHERE Username = ?"
                    };

                    foreach (string query in clearQueries)
                    {
                        using (OleDbCommand cmd = new OleDbCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("?", username);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Your account has been cleared successfully.",
                        "Account Cleared",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while clearing the account:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        //admin
        public void LoadUserInfos(DataGridView dgv) //idk what to do here for now
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Username, Password, CreatedAt FROM [Users Table]";

                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dgv.DataSource = table;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user data: {ex.Message}");
            }
        }

        public void AdminDeleteAcc(string username)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    // Delete all user data from related tables
                    string[] deleteQueries = {
                        "DELETE FROM [Journal Table] WHERE Username = ?",
                        "DELETE FROM [Pomodoro Table] WHERE Username = ?",
                        "DELETE FROM [Habit Checker Table] WHERE Username = ?",
                        "DELETE FROM [ToDo List Table] WHERE Username = ?",
                        "DELETE FROM [Users Table] WHERE Username = ?"
                    };

                    foreach (string query in deleteQueries)
                    {
                        using (OleDbCommand cmd = new OleDbCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("?", username);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show($"Account '{username}' and its data were deleted successfully.",
                        "Deleted",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting user:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public void AdminClearData(List<string> usernames)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    foreach (string username in usernames)
                    {
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
                }

                MessageBox.Show("Selected accounts' data were cleared successfully.", "Cleared", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error clearing selected account data:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void UpdateAccountData(string username, string newPassword)// update account data
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE [Users Table] SET [Password] = ? WHERE [Username] = ?";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", newPassword);
                        cmd.Parameters.AddWithValue("?", username);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating password: {ex.Message}");
            }
        }

        //send email to admin stuyff

        public void SendMailToAdmin(string clientEmail, string message)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(clientEmail);
                mail.To.Add("totallycomfy.6969@gmail.com");
                mail.Subject = $"Message from client: {clientEmail}";
                mail.Body = message;

                // Configure SMTP client for Gmail
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("totallycomfy.6969@gmail.com", "emmh etxp rvtw aram"),
                    EnableSsl = true
                };

                smtpClient.Send(mail);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to send email: " + ex.Message);
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

                    // Check if username exists
                    string checkUserQuery = "SELECT COUNT(*) FROM [Users Table] WHERE Username = ?";
                    using (OleDbCommand cmd = new OleDbCommand(checkUserQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        int userExists = (int)cmd.ExecuteScalar();

                        if (userExists > 0)
                        {
                            MessageBox.Show("Username already exists!", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Insert new user
                    string insertQuery = @"
                        INSERT INTO [Users Table] 
                        (Username, [Password], CreatedAt, TimeSpentUsingCozify, NoOfTimesCozifyOpened) 
                        VALUES (?, ?, ?, ?, ?)";

                    using (OleDbCommand cmd = new OleDbCommand(insertQuery, conn))
                    {
                        cmd.Parameters.Add("@username", OleDbType.VarChar).Value = username;
                        cmd.Parameters.Add("@password", OleDbType.VarChar).Value = password;
                        cmd.Parameters.Add("@createdAt", OleDbType.Date).Value = DateTime.Now;
                        cmd.Parameters.Add("@timeSpent", OleDbType.Double).Value = 0.0;
                        cmd.Parameters.Add("@launches", OleDbType.Integer).Value = 0;

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Registration successful!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Registration failed - no rows affected", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (OleDbException dbEx)
            {
                MessageBox.Show($"Database error: {dbEx.Message}\n\nPlease check your database structure.",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Login(string usernameLogin, string passwordLogin)
        {
            try
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
                            MessageBox.Show("Login Successful!", "Welcome",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            GlobalUser.LoggedInUsername = usernameLogin;
                            new MAIN_HUB().Show();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Username or Password!", "Login Failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login error: {ex.Message}");
            }
        }

        //journal stuff

        public void LoadJournal(ListView journalListView, bool showDeleted = false)
        {
            journalListView.Items.Clear();
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT Title, EntryDate, isJournalDeleted 
                        FROM [Journal Table] 
                        WHERE Username = ?";

                if (!showDeleted)
                {
                    query += " AND isJournalDeleted = False";
                }

                query += " ORDER BY EntryDate DESC";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.Add("@username", OleDbType.VarChar).Value = GlobalUser.LoggedInUsername;

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string title = reader["Title"].ToString();
                            bool isDeleted = Convert.ToBoolean(reader["isJournalDeleted"]);

                            if (!isDeleted || showDeleted)
                            {
                                var item = new ListViewItem(title);
                                item.Tag = isDeleted; // Store deletion status in Tag
                                if (isDeleted) item.ForeColor = Color.Gray; // Visual indicator for deleted items
                                journalListView.Items.Add(item);
                            }
                        }
                    }
                }
            }
        }

        public int JournalCount(bool includeDeleted = false)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT COUNT(*) 
                        FROM [Journal Table] 
                        WHERE Username = ?";

                if (!includeDeleted)
                {
                    query += " AND isJournalDeleted = False";
                }

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.Add("@username", OleDbType.VarChar).Value = GlobalUser.LoggedInUsername;
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
                    string checkQuery = "SELECT COUNT(*) FROM [Journal Table] WHERE Username = ? AND Title = ? AND isJournalDeleted = False";
                    using (OleDbCommand checkCmd = new OleDbCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.Add("@username", OleDbType.VarChar).Value = GlobalUser.LoggedInUsername;
                        checkCmd.Parameters.Add("@title", OleDbType.VarChar).Value = newTitle;
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("An entry with this title already exists. Please use a different title.",
                                          "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                string query;
                if (originalTitle != null)
                {
                    query = @"UPDATE [Journal Table] 
                     SET Title = ?, Content = ?, EntryDate = ?, isJournalDeleted = False 
                     WHERE Username = ? AND Title = ?";
                }
                else
                {
                    query = @"INSERT INTO [Journal Table] 
                     (Title, Content, EntryDate, Username, isJournalDeleted) 
                     VALUES (?, ?, ?, ?, False)";
                }

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.Add("@title", OleDbType.VarChar).Value = newTitle;
                    cmd.Parameters.Add("@content", OleDbType.VarChar).Value = newContent;
                    cmd.Parameters.Add("@entryDate", OleDbType.Date).Value = entryDate;
                    cmd.Parameters.Add("@username", OleDbType.VarChar).Value = GlobalUser.LoggedInUsername;

                    if (originalTitle != null)
                    {
                        cmd.Parameters.Add("@originalTitle", OleDbType.VarChar).Value = originalTitle;
                    }

                    int rowsAffected = cmd.ExecuteNonQuery();
                    Debug.WriteLine($"Saved journal entry. Rows affected: {rowsAffected}");
                }
            }
        }

        public void DeleteJournalEntry(string entryTitle)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string deleteQuery = @"UPDATE [Journal Table] 
                             SET isJournalDeleted = True 
                             WHERE Username = ? AND Title = ?";

                using (OleDbCommand cmd = new OleDbCommand(deleteQuery, conn))
                {
                    cmd.Parameters.Add("@username", OleDbType.VarChar).Value = GlobalUser.LoggedInUsername;
                    cmd.Parameters.Add("@title", OleDbType.VarChar).Value = entryTitle;

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Journal entry moved to trash.", "Deleted",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Journal entry not found.", "Error",
                                      MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
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
                    string query = @"SELECT EntryDate, Content, isJournalDeleted 
                           FROM [Journal Table] 
                           WHERE Username = ? AND Title = ?";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.Add("@username", OleDbType.VarChar).Value = GlobalUser.LoggedInUsername;
                        cmd.Parameters.Add("@title", OleDbType.VarChar).Value = selectedTitle;

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                bool isDeleted = Convert.ToBoolean(reader["isJournalDeleted"]);
                                if (isDeleted)
                                {
                                    MessageBox.Show("This entry has been deleted. Restore it to edit.",
                                                  "Deleted Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }

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
            public DateTime WeekStartDate { get; set; }
            public bool IsDeleted { get; set; }
        }
        
        public void AddHabitRow(TableLayoutPanel tblHabitChecker, string habitText, bool sun, bool mon, bool tues, bool wed, bool thurs, bool fri, bool sat, DateTime selectedWeekStart, DateTime? dateAdded = null)
        {
            tblHabitChecker.RowCount++;
            int rowIndex = tblHabitChecker.RowCount - 1;

            // Calculate the start of the current week (Sunday)
            DateTime currentWeekStart = GetStartOfWeek(DateTime.Now);

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
                    WeekStartDate = selectedWeekStart, // Use the passed parameter
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

        private DateTime GetStartOfWeek(DateTime date)
        {
            int diff = (7 + (date.DayOfWeek - DayOfWeek.Sunday)) % 7;
            return date.AddDays(-1 * diff).Date;
        }


        public void LoadHabits(TableLayoutPanel tblHabitChecker, DateTime weekStartDate)
        {
            try
            {
                // Clear existing controls safely
                tblHabitChecker.SuspendLayout();
                tblHabitChecker.Controls.Clear();
                tblHabitChecker.RowStyles.Clear();
                tblHabitChecker.RowCount = 0;

                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT HabitName, Sunday, Monday, Tuesday, Wednesday, 
                          Thursday, Friday, Saturday, HabitDateAdded, WeekStartDate
                          FROM [Habit Checker Table] 
                          WHERE Username = ? 
                          AND isHabitDeleted = False
                          AND WeekStartDate = ?
                          ORDER BY HabitDateAdded DESC";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.Add("@username", OleDbType.VarChar).Value = GlobalUser.LoggedInUsername;
                        cmd.Parameters.Add("@weekStart", OleDbType.Date).Value = weekStartDate;

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string name = reader["HabitName"].ToString().Trim();
                                bool[] days = new bool[7];
                                for (int i = 0; i < 7; i++)
                                {
                                    days[i] = Convert.ToBoolean(reader[i + 1]);
                                }
                                DateTime dateAdded = Convert.ToDateTime(reader["HabitDateAdded"]);
                                DateTime weekStart = Convert.ToDateTime(reader["WeekStartDate"]);

                                AddHabitRow(tblHabitChecker, name, days[0], days[1], days[2],
                                           days[3], days[4], days[5], days[6], dateAdded, weekStart);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading habits: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                tblHabitChecker.ResumeLayout(true);
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

        public void SaveHabitChecker(TableLayoutPanel tblHabitChecker, DateTime weekStartDate)
        {
            Debug.WriteLine("SaveHabitChecker called");
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    // Get all existing habits for this user and week
                    var existingHabits = new List<(string Name, DateTime DateAdded, DateTime WeekStart)>();

                    string getExistingQuery = @"SELECT HabitName, HabitDateAdded, WeekStartDate 
                  FROM [Habit Checker Table] 
                  WHERE Username = ?
                  AND WeekStartDate = ?
                  AND isHabitDeleted = False";

                    using (OleDbCommand cmd = new OleDbCommand(getExistingQuery, conn))
                    {
                        cmd.Parameters.Add("@username", OleDbType.VarChar).Value = GlobalUser.LoggedInUsername;
                        cmd.Parameters.Add("@weekStart", OleDbType.Date).Value = weekStartDate;

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                existingHabits.Add((
                                    reader["HabitName"].ToString(),
                                    Convert.ToDateTime(reader["HabitDateAdded"]),
                                    Convert.ToDateTime(reader["WeekStartDate"])
                                ));
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
                            string habit = txtHabit.Text.Trim();
                            var meta = txtHabit.Tag as HabitMetaData;
                            if (meta == null) continue;

                            bool[] checkedDays = new bool[7];
                            for (int i = 0; i < 7; i++)
                            {
                                Control chk = tblHabitChecker.GetControlFromPosition(i + 2, rowIndex);
                                checkedDays[i] = chk is CheckBox box && box.Checked;
                            }

                            // Improved existence check
                            bool existsInDb = existingHabits.Any(h =>
                                string.Equals(h.Name, habit, StringComparison.OrdinalIgnoreCase) &&
                                h.WeekStart == weekStartDate);


                            if (existsInDb)
                            {
                                // Update existing habit
                                string updateQuery = @"UPDATE [Habit Checker Table]
                                                        SET Sunday = ?, Monday = ?, Tuesday = ?,
                                                            Wednesday = ?, Thursday = ?, Friday = ?,
                                                            Saturday = ?
                                                        WHERE Username = ?
                                                        AND HabitName = ?
                                                        AND WeekStartDate = ?";

                                using (OleDbCommand cmd = new OleDbCommand(updateQuery, conn))
                                {
                                    // Add day parameters
                                    for (int i = 0; i < 7; i++)
                                    {
                                        cmd.Parameters.Add($"@day{i}", OleDbType.Boolean).Value = checkedDays[i];
                                    }

                                    cmd.Parameters.Add("@username", OleDbType.VarChar).Value = GlobalUser.LoggedInUsername;
                                    cmd.Parameters.Add("@habitName", OleDbType.VarChar).Value = habit;
                                    cmd.Parameters.Add("@weekStart", OleDbType.Date).Value = weekStartDate;

                                    int rowsAffected = cmd.ExecuteNonQuery();
                                    if (rowsAffected > 0) savedCount++;
                                }
                            }
                            else
                            {
                                // Insert new habit only if it doesn't exist
                                if (!string.IsNullOrWhiteSpace(habit))
                                {
                                    string insertQuery = @"INSERT INTO [Habit Checker Table] 
                                (Username, HabitName, Sunday, Monday, Tuesday,
                                 Wednesday, Thursday, Friday, Saturday, 
                                 HabitDateAdded, WeekStartDate, isHabitDeleted)
                                VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

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
                                        cmd.Parameters.Add("@weekStart", OleDbType.Date).Value = weekStartDate;
                                        cmd.Parameters.Add("@isDeleted", OleDbType.Boolean).Value = false;

                                        cmd.ExecuteNonQuery();
                                        savedCount++;
                                    }
                                }
                            }
                        }
                    }

                    Debug.WriteLine($"Saved {savedCount} habits");
                    if (savedCount > 0)
                    {
                        MessageBox.Show($"Successfully saved {savedCount} habits", "Saved",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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
                try
                {
                    // Get the exact habit details before deletion
                    string habitName = txtHabit.Text.Trim();
                    DateTime dateAdded = meta.HabitDateAdded;
                    DateTime weekStart = meta.WeekStartDate;

                    // Mark as deleted in database
                    using (OleDbConnection conn = new OleDbConnection(connectionString))
                    {
                        conn.Open();
                        string deleteQuery = @"UPDATE [Habit Checker Table] 
                                    SET isHabitDeleted = True
                                    WHERE Username = ? 
                                    AND TRIM(HabitName) = ?
                                    AND HabitDateAdded = ?
                                    AND WeekStartDate = ?";

                        using (OleDbCommand cmd = new OleDbCommand(deleteQuery, conn))
                        {
                            cmd.Parameters.Add("@username", OleDbType.VarChar).Value = GlobalUser.LoggedInUsername;
                            cmd.Parameters.Add("@habitName", OleDbType.VarChar).Value = habitName;
                            cmd.Parameters.Add("@dateAdded", OleDbType.Date).Value = dateAdded;
                            cmd.Parameters.Add("@weekStart", OleDbType.Date).Value = weekStart;

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected == 0)
                            {
                                MessageBox.Show("Habit not found in database. It may have already been deleted.",
                                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }

                    // Remove from UI
                    RemoveHabitRowFromUI(tblHabitChecker, rowIndex);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting habit: {ex.Message}\n\nPlease try again.",
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RemoveHabitRowFromUI(TableLayoutPanel tblHabitChecker, int rowIndex)
        {
            try
            {
                // Suspend layout to prevent flickering
                tblHabitChecker.SuspendLayout();

                // Collect all controls in the row
                var controlsToRemove = new List<Control>();
                for (int col = 0; col < tblHabitChecker.ColumnCount; col++)
                {
                    var control = tblHabitChecker.GetControlFromPosition(col, rowIndex);
                    if (control != null)
                    {
                        controlsToRemove.Add(control);
                    }
                }

                // Remove controls from table
                foreach (var control in controlsToRemove)
                {
                    tblHabitChecker.Controls.Remove(control);
                }

                // Shift remaining rows up
                for (int r = rowIndex + 1; r < tblHabitChecker.RowCount; r++)
                {
                    for (int c = 0; c < tblHabitChecker.ColumnCount; c++)
                    {
                        var control = tblHabitChecker.GetControlFromPosition(c, r);
                        if (control != null)
                        {
                            tblHabitChecker.SetRow(control, r - 1);
                        }
                    }
                }

                // Adjust row count and styles
                tblHabitChecker.RowCount--;
                if (tblHabitChecker.RowStyles.Count > rowIndex)
                {
                    tblHabitChecker.RowStyles.RemoveAt(rowIndex);
                }

                // Dispose controls after we're done with them
                foreach (var control in controlsToRemove)
                {
                    control.Dispose();
                }
            }
            finally
            {
                // Always resume layout
                tblHabitChecker.ResumeLayout(true);
                tblHabitChecker.PerformLayout();
            }
        }
        // Habit Streak analytics:

        public class HabitStreak
        {
            public string HabitName { get; set; }
            public int CurrentStreak { get; set; }
            public int LongestStreak { get; set; }
            public DateTime? LastCompletedDate { get; set; }
            public Dictionary<DateTime, bool> CompletionHistory { get; set; } = new Dictionary<DateTime, bool>();
        }

        public class StreakAnalyticsData
        {
            public List<HabitStreak> HabitStreaks { get; set; } = new List<HabitStreak>();
            public int TotalCurrentStreak { get; set; }
            public int TotalLongestStreak { get; set; }
        }

        public StreakAnalyticsData GetHabitStreakData(string username)
        {
            var streakData = new StreakAnalyticsData();
            var allHabits = new List<(string Name, DateTime Date, bool Completed)>();

            // Get all habit completion data from database
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = @"
            SELECT HabitName, WeekStartDate, 
                   Sunday, Monday, Tuesday, Wednesday, 
                   Thursday, Friday, Saturday
            FROM [Habit Checker Table] 
            WHERE Username = ? 
            AND isHabitDeleted = False
            ORDER BY WeekStartDate";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", username);

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string habitName = reader["HabitName"].ToString();
                            DateTime weekStart = Convert.ToDateTime(reader["WeekStartDate"]);

                            // Add each day's completion status
                            for (int i = 0; i < 7; i++)
                            {
                                DateTime dayDate = weekStart.AddDays(i);
                                bool completed = Convert.ToBoolean(reader[i + 2]); // Sunday is column 2
                                allHabits.Add((habitName, dayDate, completed));
                            }
                        }
                    }
                }
            }

            // Group by habit and calculate streaks
            var habitsGrouped = allHabits.GroupBy(h => h.Name);

            foreach (var habitGroup in habitsGrouped)
            {
                var habitStreak = new HabitStreak { HabitName = habitGroup.Key };
                var orderedDates = habitGroup.OrderBy(h => h.Date).ToList();

                int currentStreak = 0;
                int longestStreak = 0;
                DateTime? lastCompletedDate = null;

                foreach (var entry in orderedDates)
                {
                    if (entry.Completed)
                    {
                        currentStreak++;
                        longestStreak = Math.Max(longestStreak, currentStreak);
                        lastCompletedDate = entry.Date;
                        habitStreak.CompletionHistory[entry.Date] = true;
                    }
                    else
                    {
                        currentStreak = 0;
                        habitStreak.CompletionHistory[entry.Date] = false;
                    }
                }

                habitStreak.CurrentStreak = currentStreak;
                habitStreak.LongestStreak = longestStreak;
                habitStreak.LastCompletedDate = lastCompletedDate;
                streakData.HabitStreaks.Add(habitStreak);
            }

            // Calculate totals
            if (streakData.HabitStreaks.Any())
            {
                streakData.TotalCurrentStreak = streakData.HabitStreaks.Min(h => h.CurrentStreak);
                streakData.TotalLongestStreak = streakData.HabitStreaks.Max(h => h.LongestStreak);
            }

            return streakData;
        }
        //To DO List
        public class TaskMetaData
        {
            public DateTime TaskDateAdded { get; set; }
            public DateTime? TaskDateCompleted { get; set; }
            public bool IsDeleted { get; set; }
        }

        public void AddToDoRow(TableLayoutPanel tblToDoList, string TaskText, bool isDone,
                      DateTime dateAdded, DateTime? dateCompleted = null, bool isDeleted = false)
        {
            if (!isDeleted)
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
                    Tag = dateAdded // Store creation date
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
                    FlatStyle = FlatStyle.Flat,
                    Tag = rowIndex
                };
                btnDelete.Click += (s, e) => DeleteToDoRow(tblToDoList, rowIndex);
                tblToDoList.Controls.Add(btnDelete, 0, rowIndex);
            }
        }

        public void LoadToDoList(TableLayoutPanel tblToDoList, bool showDeleted = false)
        {
            tblToDoList.Controls.Clear();
            tblToDoList.RowCount = 0;

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT Activity, isDone, TaskDateAdded, TaskDateCompleted, isTaskDeleted 
                        FROM [ToDo List Table] 
                        WHERE Username = ?";

                if (!showDeleted)
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
                            bool isDeleted = Convert.ToBoolean(reader["isTaskDeleted"]);

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
            int savedCount = 0; // Initialize counter for saved tasks

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    // First get all existing tasks for this user
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
                                                TaskDateCompleted = ?
                                            WHERE Username = ? 
                                            AND Activity = ?
                                            AND TaskDateAdded = ?";

                                using (OleDbCommand cmd = new OleDbCommand(updateQuery, conn))
                                {
                                    cmd.Parameters.Add("@isDone", OleDbType.Boolean).Value = chkDone.Checked;
                                    cmd.Parameters.Add("@dateCompleted", OleDbType.Date).Value =
                                        meta.TaskDateCompleted ?? (object)DBNull.Value;
                                    cmd.Parameters.Add("@username", OleDbType.VarChar).Value = GlobalUser.LoggedInUsername;
                                    cmd.Parameters.Add("@activity", OleDbType.VarChar).Value = txtTask.Text;
                                    cmd.Parameters.Add("@dateAdded", OleDbType.Date).Value = meta.TaskDateAdded;

                                    int rowsAffected = cmd.ExecuteNonQuery();
                                    if (rowsAffected > 0) savedCount++;
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
                                        meta.TaskDateCompleted ?? (object)DBNull.Value;
                                    cmd.Parameters.Add("@isDeleted", OleDbType.Boolean).Value = false;

                                    int rowsAffected = cmd.ExecuteNonQuery();
                                    if (rowsAffected > 0) savedCount++;
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
                }

                Debug.WriteLine($"Saved {savedCount} tasks");
                MessageBox.Show($"Successfully saved {savedCount} tasks", "Saved",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            var txtTask = tblToDoList.GetControlFromPosition(1, rowIndex) as TextBox;
            var chkDone = tblToDoList.GetControlFromPosition(2, rowIndex) as CheckBox;

            if (txtTask != null && chkDone?.Tag is TaskMetaData meta)
            {
                // Confirm deletion
                var confirm = MessageBox.Show($"Delete task '{txtTask.Text}'?", "Confirm Delete",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes) return;

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
                            if (rowsAffected > 0)
                            {
                                // Remove from UI
                                RemoveHabitRowTable(tblToDoList, rowIndex);
                                MessageBox.Show("Task moved to trash", "Deleted",
                                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting task: {ex.Message}", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //TO-DO LIST ANALYUTICS:
        public class DailyTaskData
        {
            public DateTime Date { get; set; }
            public int TotalTasks { get; set; }       // Total tasks created that day
            public int CompletedTasks { get; set; }   // Tasks marked done that day
            public int PendingTasks => TotalTasks - CompletedTasks;
        }
        public List<DailyTaskData> GetThisWeeksTaskData(string username)
        {
            var weeklyData = new List<DailyTaskData>();

            // Calculate week range (Sunday to Saturday)
            DateTime weekStart = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
            DateTime weekEnd = weekStart.AddDays(6);

            // Debug output to verify date range
            Console.WriteLine($"Querying tasks between {weekStart:yyyy-MM-dd} and {weekEnd:yyyy-MM-dd}");

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                // Alternative query that works better with Access
                string query = @"
            SELECT 
                TaskDateAdded,
                isDone
            FROM [ToDo List Table] 
            WHERE Username = ?
            AND isTaskDeleted = False
            AND TaskDateAdded BETWEEN ? AND ?";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", username);
                    cmd.Parameters.AddWithValue("?", weekStart);
                    cmd.Parameters.AddWithValue("?", weekEnd);

                    var rawData = new List<(DateTime Date, bool IsDone)>();

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rawData.Add((
                                Convert.ToDateTime(reader["TaskDateAdded"]),
                                Convert.ToBoolean(reader["isDone"])
                            ));
                        }
                    }

                    // Group by date and calculate counts
                    weeklyData = rawData
                        .GroupBy(x => x.Date.Date)
                        .Select(g => new DailyTaskData
                        {
                            Date = g.Key,
                            TotalTasks = g.Count(),
                            CompletedTasks = g.Count(x => x.IsDone)
                        })
                        .ToList();
                }
            }

            // Ensure all days of the week are represented
            for (DateTime date = weekStart; date <= weekEnd; date = date.AddDays(1))
            {
                if (!weeklyData.Any(d => d.Date.Date == date.Date))
                {
                    weeklyData.Add(new DailyTaskData
                    {
                        Date = date,
                        TotalTasks = 0,
                        CompletedTasks = 0
                    });
                }
            }

            // Debug output to verify retrieved data
            Console.WriteLine("Retrieved data:");
            foreach (var day in weeklyData.OrderBy(d => d.Date))
            {
                Console.WriteLine($"{day.Date:yyyy-MM-dd (ddd)}: {day.CompletedTasks} completed");
            }

            return weeklyData.OrderBy(d => d.Date).ToList();
        }
        private void RemoveHabitRowTable(TableLayoutPanel table, int rowIndex)
        {
            // Remove all controls from the row
            for (int col = 0; col < table.ColumnCount; col++)
            {
                var control = table.GetControlFromPosition(col, rowIndex);
                if (control != null)
                {
                    table.Controls.Remove(control);
                    control.Dispose();
                }
            }

            // Shift rows up
            for (int r = rowIndex + 1; r < table.RowCount; r++)
            {
                for (int c = 0; c < table.ColumnCount; c++)
                {
                    var control = table.GetControlFromPosition(c, r);
                    if (control != null)
                    {
                        table.SetRow(control, r - 1);
                    }
                }
            }

            if (table.RowCount > 0)
            {
                table.RowCount--;
            }
        }

        // pomodoro
        public class PomodoroStats
        {
            public int TotalCompletedSessions { get; set; }
            public int TotalTimeSpentSeconds { get; set; } // in seconds

        }

        public int GetTotalCompletedSessions(string username)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM [Pomodoro Table] WHERE Username = ? AND Completed = true;";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.Add("?", OleDbType.VarChar).Value = username;
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public int GetTotalTimeSpent(string username)
        {using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT SUM(TimeSpent) FROM [Pomodoro Table] WHERE Username = ?;";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.Add("?", OleDbType.VarChar).Value = username;
                    object result = cmd.ExecuteScalar();
                    return result != DBNull.Value ? Convert.ToInt32(result) : 0;
                }
            }
        }

        public void SavePomodoroSession(bool completed, int workTime, int breakTime, ref PomodoroStats stats)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO [Pomodoro Table] (Username, WorkTime, BreakTime, Completed, TimeSpent, SessionDate) VALUES (?, ?, ?, ?, ?, ?);";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    int totalTimeSpent = (workTime + breakTime) * 60;

                    // Update stats
                    if (completed) stats.TotalCompletedSessions++;
                    stats.TotalTimeSpentSeconds += totalTimeSpent;

                    cmd.Parameters.Add("?", OleDbType.VarChar).Value = GlobalUser.LoggedInUsername;
                    cmd.Parameters.Add("?", OleDbType.Integer).Value = workTime * 60;
                    cmd.Parameters.Add("?", OleDbType.Integer).Value = breakTime * 60;
                    cmd.Parameters.Add("?", OleDbType.Boolean).Value = completed;
                    cmd.Parameters.Add("?", OleDbType.Integer).Value = totalTimeSpent;
                    cmd.Parameters.Add("?", OleDbType.Date).Value = DateTime.Now;

                    cmd.ExecuteNonQuery();
                }
            }
        }


        //POMODORO ANALYTICS

        public List<DailyPomodoroData> GetDailyPomodoroData(string username)
        {
            List<DailyPomodoroData> dailyData = new List<DailyPomodoroData>();

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = @"
        SELECT 
            SessionDate, 
            Completed, 
            WorkTime, 
            BreakTime 
        FROM [Pomodoro Table] 
        WHERE Username = ?
        ORDER BY SessionDate";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.Add("?", OleDbType.VarChar).Value = username;

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        var tempData = new Dictionary<DateTime, DailyPomodoroData>();

                        while (reader.Read())
                        {
                            DateTime date = Convert.ToDateTime(reader["SessionDate"]).Date; // Get just the date part
                            int work = Convert.ToInt32(reader["WorkTime"]) / 60;
                            int brk = Convert.ToInt32(reader["BreakTime"]) / 60;
                            bool completed = Convert.ToBoolean(reader["Completed"]);

                            if (!tempData.ContainsKey(date))
                            {
                                tempData[date] = new DailyPomodoroData
                                {
                                    Date = date,
                                    CompletedSessions = 0,
                                    WorkMinutes = 0,
                                    BreakMinutes = 0
                                };
                            }

                            if (completed) tempData[date].CompletedSessions++;
                            tempData[date].WorkMinutes += work;
                            tempData[date].BreakMinutes += brk;
                        }

                        dailyData = tempData.Values.OrderBy(d => d.Date).ToList();
                    }
                }
            }

            return dailyData;
        }

        public class DailyPomodoroData
        {
            public DateTime Date { get; set; }
            public int CompletedSessions { get; set; }
            public int WorkMinutes { get; set; }
            public int BreakMinutes { get; set; }
        }

        // Stats/Activity of user
        public void InitializeUserStats(string username)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    // Check if user exists in stats table
                    string checkQuery = "SELECT COUNT(*) FROM [Users Table] WHERE Username = ?";
                    using (OleDbCommand checkCmd = new OleDbCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("?", username);
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count == 0)
                        {
                            // Insert new record with default values (without LastActive)
                            string insertQuery = @"
                        INSERT INTO [Users Table] 
                        (Username, TimeSpentUsingCozify, NoOfTimesCozifyOpened)
                        VALUES (?, 0, 0)";

                            using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, conn))
                            {
                                insertCmd.Parameters.AddWithValue("?", username);
                                insertCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error initializing user stats: {ex}");
            }
        }

        // Rate giver
        private bool IsDateInThisWeek(DateTime date)
        {
            var startOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
            var endOfWeek = startOfWeek.AddDays(6);
            return date >= startOfWeek && date <= endOfWeek;
        }

        public string GetWeeklyProductivityRating(string username)
        {
            int totalScore = 0;

            // Get Pomodoro data for this week
            var pomodoroList = GetDailyPomodoroData(username)
                .Where(d => IsDateInThisWeek(d.Date))
                .ToList();

            int pomodoroSessions = pomodoroList.Sum(d => d.CompletedSessions);
            int workMinutes = pomodoroList.Sum(d => d.WorkMinutes);
            totalScore += pomodoroSessions * 2;
            totalScore += workMinutes / 30;

            // Get Task data for this week
            var taskList = GetThisWeeksTaskData(username);
            int completedTasks = taskList.Sum(d => d.CompletedTasks);
            totalScore += completedTasks * 3;

            // Get Habit streak data
            var habitStreak = GetHabitStreakData(username);
            int currentStreakSum = habitStreak.HabitStreaks.Sum(h => h.CurrentStreak);
            totalScore += currentStreakSum;

            if (totalScore >= 90)
                return "🔥 Super Productive!";
            else if (totalScore >= 60)
                return "💪 Doing Great!";
            else if (totalScore >= 30)
                return "🙂 Keep Going!";
            else
                return "😴 Time to Refocus!";
        }

        public void LoadUserStats(Label UserTimeSpent, Label TimesLaunched)
        {
            try
            {
                InitializeUserStats(GlobalUser.LoggedInUsername);

                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT TimeSpentUsingCozify, NoOfTimesCozifyOpened FROM [Users Table] WHERE Username = ?";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", GlobalUser.LoggedInUsername);

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                double timeSpent = reader.IsDBNull(0) ? 0 : Convert.ToDouble(reader.GetValue(0));
                                int timesOpened = reader.IsDBNull(1) ? 0 : Convert.ToInt32(reader.GetValue(1));

                                // Format time with appropriate decimal places
                                string timeFormat = timeSpent < 0.1 ? "F4" : "F2";
                                UserTimeSpent.Text = $"Time spent: {timeSpent.ToString(timeFormat)} hrs";
                                TimesLaunched.Text = $"Times Cozify launched: {timesOpened}";
                            }
                            else
                            {
                                UserTimeSpent.Text = "Time Spent: 0 hours";
                                TimesLaunched.Text = "Times Cozify launched: 0";
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
            }
        }

        private DateTime sessionStartTime;

        public void SessionStartTime()
        {
            sessionStartTime = DateTime.Now;
        }

        public void StopSessionTimer()
        {
            try
            {
                TimeSpan sessionDuration = DateTime.Now - sessionStartTime;
                double hoursSpent = sessionDuration.TotalHours;

                if (hoursSpent <= 0)
                {
                    Debug.WriteLine("Session duration was 0 or negative, not saving");
                    return;
                }

                Debug.WriteLine($"Preparing to save session data: {hoursSpent:F6} hours");

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
                            InitializeUserStats(GlobalUser.LoggedInUsername);
                        }
                    }

                    // Updated query without LastActive
                    string updateQuery = @"
                UPDATE [Users Table]
                SET 
                    TimeSpentUsingCozify = TimeSpentUsingCozify + ?,
                    NoOfTimesCozifyOpened = NoOfTimesCozifyOpened + 1
                WHERE Username = ?";

                    using (OleDbCommand cmd = new OleDbCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("?", hoursSpent);
                        cmd.Parameters.AddWithValue("?", GlobalUser.LoggedInUsername);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        Debug.WriteLine($"Rows affected: {rowsAffected}");

                        if (rowsAffected == 0)
                        {
                            Debug.WriteLine("Warning: No rows were updated");
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
        }
    }
}
