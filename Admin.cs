using finals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cozify
{
    public partial class Admin: BaseForm
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            db.LoadUserInfos(dgvAdminView);
        }

        private void btnAdminClearAccData_Click(object sender, EventArgs e)
        {
            if (dgvAdminView.SelectedRows.Count > 0)
            {
                List<string> usernamesToClear = new List<string>();

                foreach (DataGridViewRow row in dgvAdminView.SelectedRows)
                {
                    string username = row.Cells["Username"].Value.ToString();
                    usernamesToClear.Add(username);
                }

                DialogResult result = MessageBox.Show("Are you sure you want to clear data for the selected accounts?",
                                                      "Confirm Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    db.AdminClearData(usernamesToClear);
                    db.LoadUserInfos(dgvAdminView);
                }
            }
            else
            {
                MessageBox.Show("Please select at least one account to clear data.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnAdminDeleteAcc_Click(object sender, EventArgs e) // clicking on the button will delete the account instead in the datagridview (prompt if they want to delete or not)
        {
            if (dgvAdminView.SelectedRows.Count > 0)
            {
                string username = dgvAdminView.SelectedRows[0].Cells["Username"].Value.ToString();

                DialogResult result = MessageBox.Show($"Delete account '{username}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    db.AdminDeleteAcc(username);
                    db.LoadUserInfos(dgvAdminView);
                }
            }
        }

        private void btnAdminUpdateAcc_Click(object sender, EventArgs e)// change the account data in the datagridview (prompt if they want to update or not)
        {
            if (dgvAdminView.SelectedRows.Count > 0)
            {
                int rowIndex = dgvAdminView.CurrentCell.RowIndex;

                string username = dgvAdminView.Rows[rowIndex].Cells["Username"].Value.ToString();
                string newPassword = dgvAdminView.Rows[rowIndex].Cells["Password"].Value.ToString();

                DialogResult result = MessageBox.Show($"Update password for '{username}' to '{newPassword}'?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    db.UpdateAccountData(username, newPassword);
                    db.LoadUserInfos(dgvAdminView); // refresh view
                }
            }
        }

        private void btnGoBackToLogin_Click(object sender, EventArgs e) //log out
        {
            this.Hide();
            LOGIN loginForm = new LOGIN();
            loginForm.Show();
        }
    }
}
