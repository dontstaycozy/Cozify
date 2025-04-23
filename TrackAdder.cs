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
    public partial class TrackAdder : BaseForm
    {
        public string NewTitle { get; set; }
        public string NewArtist { get; set; }
        public string NewFilePath { get; set; }

        public TrackAdder()
        {
            InitializeComponent();
        }
        //this has tbxTrackAddTitle, tbxTrackAddArtist, tbxTrackAddFile (idk how to for this honestly i have no idea), btnTrackAdd

        private void btnCloseAdd_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnTrackAdd_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(tbxTrackAddTitle.Text) ||
            //    string.IsNullOrWhiteSpace(tbxTrackAddFile.Text))
            //{
            //    MessageBox.Show("Please provide title and select a file.");
            //    return;
            //}

            //if (!File.Exists(tbxTrackAddFile.Text))
            //{
            //    MessageBox.Show("The selected file does not exist.");
            //    return;
            //}

            //// Basic audio file validation
            //string ext = Path.GetExtension(tbxTrackAddFile.Text).ToLower();
            //if (ext != ".mp3" && ext != ".wav") // Add other supported formats
            //{
            //    MessageBox.Show("Please select a valid audio file (.mp3, .wav)");
            //    return;
            //}

            //NewTitle = tbxTrackAddTitle.Text;
            //NewArtist = string.IsNullOrWhiteSpace(tbxTrackAddArtist.Text) ?
            //           "Unknown Artist" : tbxTrackAddArtist.Text;
            //NewFilePath = tbxTrackAddFile.Text;

            //this.DialogResult = DialogResult.OK;
            //this.Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e) //for the file browse
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "Audio Files (*.mp3;*.wav)|*.mp3;*.wav|All files (*.*)|*.*"; //filter
            //openFileDialog.Title = "Select Audio File";

            //if (openFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    tbxTrackAddFile.Text = openFileDialog.FileName; //set the textbox
            //}
        }
    }
}
