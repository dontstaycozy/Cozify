using finals;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Cozify
{
    public partial class LoginReg : BaseForm
    {
        public LoginReg()
        {
            InitializeComponent();
        }

        private void LoginReg_Load(object sender, EventArgs e)
        {
            CenterContent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbxUsernameLogin.Text.Trim();
            string password = tbxPasswordLogin.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (username == "admin" && password == "admin123")
            {
                new Admin().Show();
                this.Hide();
                return;
            }

            db.Login(username, password);
            this.Hide();
        }

        private void btnGoBackToRegister_Click(object sender, EventArgs e)
        {
            new LOGIN().Show();
            this.Close();
        }

        private void btnRevealLoginPass_Click(object sender, EventArgs e)
        {
            tbxPasswordLogin.UseSystemPasswordChar = !tbxPasswordLogin.UseSystemPasswordChar;

            using (var ms = new MemoryStream(tbxPasswordLogin.UseSystemPasswordChar
                ? Cozify.Properties.Resources.EyeOpen
                : Cozify.Properties.Resources.ClosedEye))
            {
                btnRevealLoginPass.Image = Image.FromStream(ms);
            }

            tbxPasswordLogin.Font = new Font("Pixeltype", 20f, FontStyle.Regular);
        }

        private void btnForgetPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new MailToAdmin().Show();
        }


        private void CenterContent()
        {
            int formWidth = this.ClientSize.Width;

            int picX = (formWidth - pictureBox1.Width) / 2;
            int panel1X = (formWidth - panel1.Width) / 2;
            int panel2X = (formWidth - panel2.Width) / 2;
            int btnX = (formWidth - btnLogin.Width) / 2;
        }
    }
}
