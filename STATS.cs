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
    public partial class STATS : BaseForm
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Users\fredwil\Desktop\Cozify Project\CozifyUsers.accdb";
        public STATS()
        {
            InitializeComponent();
        }

        private void btnDeleteAcc_Click(object sender, EventArgs e)
        {
            string username = GlobalUser.LoggedInUsername;

            DialogResult result = MessageBox.Show("Are you sure you want to delete your account? This action cannot be undone.",
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
                this.Hide();
                LoginReg loginReg = new LoginReg();
                loginReg.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while deleting the account:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
