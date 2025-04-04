using Cozify;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finals
{
    public partial class JOURNAL: BaseForm
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Users\fredwil\Desktop\Cozify Project\CozifyUsers.accdb";

        public JOURNAL()
        {
            InitializeComponent();
            this.MouseDown += JOURNAL_MouseDown;
        }

        private void JOURNAL_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0xA1, 0x2, 0); // Dragging action
            }
        }
        private void JOURNAL_Load(object sender, EventArgs e)
        {
            lviewJournalEntries.View = View.List;
            lblAuthorNameForJournal.Text = GlobalUser.LoggedInUsername + "'s Journal";
            LoadJournalEntries();

            tbxDateWritten.Text = DateTime.Now.ToString("MMMM d, yyyy");
        }
        private void LoadJournalEntries()
        {
            lviewJournalEntries.Items.Clear();
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
                            lviewJournalEntries.Items.Add(new ListViewItem(title));
                        }
                    }
                }
            }
        }

        private void btnAddJournalEntry_Click(object sender, EventArgs e)
        {
            lviewJournalEntries.SelectedItems.Clear(); // Clear any selected item

            string defaultTitle = "Enter Title";
            tbxEntryTitle.Text = defaultTitle; // Set title placeholder
            tbxJournalContent.Text = "Write something...."; // Set content placeholder
            tbxDateWritten.Text = DateTime.Now.ToString("MMMM d, yyyy"); // Set today's date

            // Add the new entry to the ListView if it doesn't already exist
            if (!lviewJournalEntries.Items.Cast<ListViewItem>().Any(item => item.Text == defaultTitle))
            {
                lviewJournalEntries.Items.Add(new ListViewItem(defaultTitle));
            }

            tbxEntryTitle.Focus(); // Move focus to the title field for editing
        }

        private void btnSaveEntry_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxEntryTitle.Text) || string.IsNullOrWhiteSpace(tbxJournalContent.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string newTitle = tbxEntryTitle.Text.Trim();
            string newContent = tbxJournalContent.Text.Trim();

            DateTime entryDate;
            if (!DateTime.TryParseExact(tbxDateWritten.Text, new[] { "MM/dd/yyyy", "MMMM d, yyyy" },
                System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out entryDate))
            {
                MessageBox.Show("Invalid date format. Please enter a valid date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string originalTitle = lviewJournalEntries.SelectedItems.Count > 0 ? lviewJournalEntries.SelectedItems[0].Text : null;

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

            MessageBox.Show("Journal entry saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadJournalEntries();
        }


        private void lviewJournalEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lviewJournalEntries.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lviewJournalEntries.SelectedItems[0];
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
                                tbxDateWritten.Text = entryDate.ToString("MM/dd/yyyy");
                                tbxEntryTitle.Text = selectedTitle;
                                tbxJournalContent.Text = reader["Content"].ToString();
                            }
                        }
                    }
                }
            }
        }


        private void btnDeleteEntry_Click(object sender, EventArgs e)
        {
            if (lviewJournalEntries.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select an entry to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string entryTitle = lviewJournalEntries.SelectedItems[0].Text;

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
            LoadJournalEntries();
        }
    }
}
