using Cozify;
using Cozify.Properties;
using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finals
{
    public partial class LOGIN : BaseForm
    {
        public LOGIN()
        {
            InitializeComponent();
        }

        private void connectiontest_Click(object sender, EventArgs e)
        {
            db.connectionTest();
        }

        private void btnLoginExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRevealPass_Click_1(object sender, EventArgs e)
        {
            tbxPassword.UseSystemPasswordChar = !tbxPassword.UseSystemPasswordChar;

            using (var ms = new MemoryStream(tbxPassword.UseSystemPasswordChar
                ? Resources.ClosedEye
                : Resources.EyeOpen))
            {
                btnRevealPass.Image = Image.FromStream(ms);
            }

            if (tbxPassword.UseSystemPasswordChar)
            {
                tbxPassword.Font = new Font("Pixeltype", 20f, FontStyle.Regular);
            }
        }

        private void btnRevealPassConfirm_Click_1(object sender, EventArgs e)
        {
            tbxPasswordConfirm.UseSystemPasswordChar = !tbxPasswordConfirm.UseSystemPasswordChar;

            using (var ms = new MemoryStream(tbxPasswordConfirm.UseSystemPasswordChar
                ? Resources.ClosedEye
                : Resources.EyeOpen))
            {
                btnRevealPassConfirm.Image = Image.FromStream(ms);
            }

            if (tbxPasswordConfirm.UseSystemPasswordChar)
            {
                tbxPasswordConfirm.Font = new Font("Pixeltype", 20f, FontStyle.Regular);
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

                MAIN_HUB mainHub = new MAIN_HUB();
                mainHub.Show();
                return;
            }

            db.Register(username, password);

            LoginReg loginReg = new LoginReg();
            loginReg.Show();
            this.Hide();
        }

        private void lnklblLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginReg loginReg = new LoginReg();
            loginReg.Show();
            this.Hide();
        }
    }
}
