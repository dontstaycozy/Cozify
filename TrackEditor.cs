using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Cozify
{
    public partial class TrackEditor : BaseForm
    {
        public string NewTitle { get; set; }
        public string NewArtist { get; set; }
        public string NewFilePath { get; set; } // this is for the file path, but I don't know how to implement it in the form
        private int trackId;

        public TrackEditor(int trackId, string title, string artist) //constructor
        {
            InitializeComponent();
            this.trackId = trackId;
            tbxTrackEditTitle.Text = title;
            tbxTrackEditArtist.Text = artist;
        }
        // this has tbxTrackEditTitle, tbxTrackEditArtist, tbxTrackEditFile (idk how to for this honestly i have no idea), btnTrackEdit
        private void btnCloseEdit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnTrackEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxTrackEditTitle.Text) || string.IsNullOrWhiteSpace(tbxTrackEditArtist.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            NewTitle = tbxTrackEditTitle.Text;
            NewArtist = tbxTrackEditArtist.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {

        }

    }
}
