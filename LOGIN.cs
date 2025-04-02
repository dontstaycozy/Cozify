using Cozify;
using Cozify.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
using System.Data.OleDb;
using Vanara.PInvoke;

namespace finals
{
    public partial class LOGIN : Form
    {


        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = C:\\Users\\fredwil\\Desktop\\Cozify Project\\CozifyUsers.accdb";
        OleDbConnection myConn;
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;

        private void connectiontest_Click(object sender, EventArgs e)
        {
            myConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\\Users\\fredwil\\Desktop\\Cozify Project\\CozifyUsers.accdb");
            ds = new DataSet();
            myConn.Open();
            System.Windows.Forms.MessageBox.Show("Connected successfully!");
            myConn.Close();

        }
        public LOGIN()
        {
            InitializeComponent();
        }


        private void btnLoginExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRevealPass_Click_1(object sender, EventArgs e)
        {
            tbxPassword.UseSystemPasswordChar = !tbxPassword.UseSystemPasswordChar;

            if (tbxPassword.UseSystemPasswordChar)
            {

                using (var ms = new MemoryStream(Cozify.Properties.Resources.ClosedEye))
                {
                    btnRevealPass.Image = Image.FromStream(ms);
                }
                tbxPassword.Font = new Font("Pixeltype", 20f, FontStyle.Regular);

            }
            else
            {
                using (var ms = new MemoryStream(Cozify.Properties.Resources.EyeOpen))
                {
                    btnRevealPass.Image = Image.FromStream(ms);
                }

            }
        }

        private void btnRevealPassConfirm_Click_1(object sender, EventArgs e)
        {
            tbxPasswordConfirm.UseSystemPasswordChar = !tbxPasswordConfirm.UseSystemPasswordChar;

            if (tbxPasswordConfirm.UseSystemPasswordChar)
            {
                using (var ms = new MemoryStream(Cozify.Properties.Resources.ClosedEye))
                {
                    btnRevealPassConfirm.Image = Image.FromStream(ms);
                }
                tbxPasswordConfirm.Font = new Font("Pixeltype", 20f, FontStyle.Regular);
            }
            else
            {
                using (var ms = new MemoryStream(Cozify.Properties.Resources.EyeOpen))
                {
                    btnRevealPassConfirm.Image = Image.FromStream(ms);
                }
            }
        }

        private void btnRegisterLogin_Click(object sender, EventArgs e)
        {

            string username = tbxUsernameReg.Text.Trim();
            string password = tbxPassword.Text.Trim();
            string passwordConfirm = tbxPasswordConfirm.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in all fields.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password != passwordConfirm)
            {
                MessageBox.Show("Passwords do not match!", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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

                // Redirect to Login
                LoginReg loginReg = new LoginReg();
                loginReg.Show();
                this.Hide();
            }
        }

        private void lnklblLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginReg loginReg = new LoginReg();
            loginReg.Show();
            this.Hide();
        }


    }
}