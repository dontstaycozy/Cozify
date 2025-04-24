using System;
using System.Windows.Forms;

namespace Cozify
{
    public partial class MailToAdmin : BaseForm
    {
        public MailToAdmin()
        {
            InitializeComponent();
        }

        private void MailToAdmin_Load(object sender, EventArgs e)
        {
            lblUserMailConcern.Text = "E-mail the admin!";
        }

        private void btnSendMail_Click(object sender, EventArgs e)
        {
            string clientEmail = tbxEmailClient.Text.Trim();
            string message = tbxMessage.Text.Trim();

            if (string.IsNullOrWhiteSpace(clientEmail) || string.IsNullOrWhiteSpace(message))
            {
                MessageBox.Show("Please enter both sender email and message.", "Mail Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            db.SendMailToAdmin(clientEmail, message);
            MessageBox.Show("Mail sent successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCloseMail_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
