using Cozify;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class JOURNAL: BaseForm
    {
        public JOURNAL()
        {
            InitializeComponent();
            this.MouseDown += JOURNAL_MouseDown;
        }

        private void JOURNAL_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0xA1, 0x2, 0); // Dragging action
            }
        }
        private void JOURNAL_Load(object sender, EventArgs e)
        {
            lviewJournalEntries.View = View.List;
            lblAuthorNameForJournal.Text = GlobalUser.LoggedInUsername + "'s Journal";
            LoadJournalEntries();

            tbxDateWritten.Text = DateTime.Now.ToString("MM/dd/yyyy");
        }
        private void LoadJournalEntries()
        {
            db.LoadJournal(lviewJournalEntries);
        }

        private void btnAddJournalEntry_Click(object sender, EventArgs e)
        {
            lviewJournalEntries.SelectedItems.Clear(); // Clear any selected item

            string defaultTitle = "Enter Title";
            tbxEntryTitle.Text = defaultTitle; // Set title placeholder
            tbxJournalContent.Text = "Write something...."; // Set content placeholder
            tbxDateWritten.Text = DateTime.Now.ToString("MM/dd/yyyy"); // Set today's date

            // Add the new entry to the ListView if it doesn't already exist
            if (!lviewJournalEntries.Items.Cast<ListViewItem>().Any(item => item.Text == defaultTitle))
            {
                lviewJournalEntries.Items.Add(new ListViewItem(defaultTitle));
            }

            tbxEntryTitle.Focus(); // Move focus to the title field for editing
        }

        private void btnSaveEntry_Click(object sender, EventArgs e)
        {
            string newTitle = tbxEntryTitle.Text.Trim();
            string newContent = tbxJournalContent.Text.Trim();
            string dateText = tbxDateWritten.Text;
            string originalTitle = lviewJournalEntries.SelectedItems.Count > 0 ? lviewJournalEntries.SelectedItems[0].Text : null;

            db.SaveJournal(newTitle, newContent, dateText, originalTitle);

            MessageBox.Show("Journal entry saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadJournalEntries();
            string defaultTitle = "Enter Title";
            tbxEntryTitle.Text = defaultTitle;
            tbxJournalContent.Text = "Write something....";
            tbxDateWritten.Text = DateTime.Now.ToString("MM/dd/yyyy");
            tbxEntryTitle.Focus();

        }


        private void lviewJournalEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            db.lvview(lviewJournalEntries, tbxEntryTitle, tbxJournalContent, tbxDateWritten);
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

            tbxEntryTitle.Text = "Enter Title";
            tbxJournalContent.Text = "Write something....";
            tbxDateWritten.Text = DateTime.Now.ToString("MM/dd/yyyy");
        }
    }
}
