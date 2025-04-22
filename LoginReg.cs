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
    public partial class LoginReg : BaseForm
    {
        

        public LoginReg()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usernameLogin = tbxUsernameLogin.Text.Trim();
            string passwordLogin = tbxPasswordLogin.Text.Trim();

            // Check if input fields are filled
            if (string.IsNullOrWhiteSpace(usernameLogin) || string.IsNullOrWhiteSpace(passwordLogin))
            {
                MessageBox.Show("Please enter both username and password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Admin login shortcut
            if (usernameLogin == "admin" && passwordLogin == "admin123")
            {
                Admin adminForm = new Admin();
                adminForm.Show();
                this.Hide();
                return;
            }

            db.Login(usernameLogin, passwordLogin);

            this.Hide();
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

        private void btnForgetPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}