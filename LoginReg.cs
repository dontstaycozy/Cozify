using finals;
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
using System.Data.OleDb;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Cozify
{
    public partial class LoginReg: Form
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Users\fredwil\Desktop\Cozify Project\CozifyUsers.accdb";

        public LoginReg()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usernameLogin = tbxUsernameLogin.Text.Trim();
            string passwordLogin = tbxPasswordLogin.Text.Trim();

            /*/if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/
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
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username or Password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void centering()
        {
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            int picbx1 = (formWidth - pictureBox1.Width) / 2;
            int tbx1 = (formWidth - panel1.Width) / 2;
            int tbx2 = (formWidth - panel2.Width) / 2;
            int regbtn = (formWidth - btnLogin.Width) / 2;
        }

        private void LoginReg_Load(object sender, EventArgs e)
        {
            centering();
        }

        private void btnGoBackToRegister_Click(object sender, EventArgs e)
        {
            LOGIN lOGIN = new LOGIN();
            lOGIN.Show();
            this.Close();
        }

        private void btnRevealLoginPass_Click(object sender, EventArgs e)
        {
            tbxPasswordLogin.UseSystemPasswordChar = !tbxPasswordLogin.UseSystemPasswordChar;

            if (tbxPasswordLogin.UseSystemPasswordChar)
            {
                using (var ms = new MemoryStream(Cozify.Properties.Resources.EyeOpen))
                {
                    btnRevealLoginPass.Image = Image.FromStream(ms);
                }
                tbxPasswordLogin.Font = new Font("Pixeltype", 20f, FontStyle.Regular);
            }
            else
            {
                using (var ms = new MemoryStream(Cozify.Properties.Resources.ClosedEye))
                {
                    btnRevealLoginPass.Image = Image.FromStream(ms);
                }
                
            }
        }
    }
}
