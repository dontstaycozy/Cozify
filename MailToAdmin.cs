using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace Cozify
{
    public partial class MailToAdmin: BaseForm
    {
        public MailToAdmin()
        {
            InitializeComponent();
        }

        private void MailToAdmin_Load(object sender, EventArgs e)
        {
            lblUserMailConcern.Text = GlobalUser.LoggedInUsername + "'s Mail to Admin";
        }

        private void btnSendMail_Click(object sender, EventArgs e)
        {
            string message = tbxMessage.Text.Trim();
            string ClientEmaile = tbxEmailClient.Text.Trim();
            // Check if input fields are filled
            if (string.IsNullOrWhiteSpace(ClientEmaile) || string.IsNullOrWhiteSpace(message))
            {
                MessageBox.Show("Please enter both sender email and message.", "Mail Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            db.SendMailToAdmin(ClientEmaile, message);
            MessageBox.Show("Mail sent successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
