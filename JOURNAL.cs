using Cozify;
using System;
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
    public partial class JOURNAL : BaseForm
    {

        public JOURNAL()
        {
            InitializeComponent();
            this.MouseDown += JOURNAL_MouseDown;

        }

        private void JOURNAL_Load(object sender, EventArgs e)
        {
            lviewJournalEntries.View = View.List;
            lblAuthorNameForJournal.Text = $"{GlobalUser.LoggedInUsername}'s Journal";
            tbxDateWritten.Text = DateTime.Now.ToString("MM/dd/yyyy");

            LoadJournalEntries();
        }

        private void JOURNAL_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0xA1, 0x2, 0); // Dragging action
            }
        }

        private void LoadJournalEntries()
        {
            db.LoadJournal(lviewJournalEntries);
        }

        private void lviewJournalEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            db.lvview(lviewJournalEntries, tbxEntryTitle, tbxJournalContent, tbxDateWritten);
        }

        private void btnAddJournalEntry_Click(object sender, EventArgs e)
        {
            lviewJournalEntries.SelectedItems.Clear();
            ResetJournalFields();
            tbxEntryTitle.Focus();
            tbxEntryTitle.SelectAll();
        }

        private void ResetJournalFields()
        {
            tbxEntryTitle.Text = "Enter Title";
            tbxJournalContent.Text = "Write something...";
            tbxDateWritten.Text = DateTime.Now.ToString("MM/dd/yyyy");
            tbxEntryTitle.Focus();
            tbxEntryTitle.SelectAll();
        }

        private void btnSaveEntry_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxEntryTitle.Text) ||
                tbxEntryTitle.Text == "Enter Title")
            {
                MessageBox.Show("Please enter a valid title!", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbxEntryTitle.Focus();
                return;
            }

            string newTitle = tbxEntryTitle.Text.Trim();
            string newContent = tbxJournalContent.Text.Trim();
            string dateText = tbxDateWritten.Text;

            bool isEditing = lviewJournalEntries.SelectedItems.Count > 0;
            string originalTitle = isEditing ? lviewJournalEntries.SelectedItems[0].Text : null;

            db.SaveJournal(newTitle, newContent, dateText, originalTitle);

            MessageBox.Show("Journal entry saved successfully!", "Success",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadJournalEntries();

            var savedItem = lviewJournalEntries.Items.Cast<ListViewItem>()
                              .FirstOrDefault(item => item.Text == newTitle);
            if (savedItem != null)
            {
                savedItem.Selected = true;
                savedItem.EnsureVisible();
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

            db.DeleteJournalEntry(entryTitle);
            LoadJournalEntries();
            ResetJournalFields();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
    }
}
