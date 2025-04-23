using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; // Required for file operations

namespace Cozify
{
    public partial class MusicPlayer : BaseForm
    {
        public MusicPlayer()
        {
            InitializeComponent();
        }
        //dgvTracksInPlaylist = tracks in playlist
        //lvwPlaylists = playlists

        private void MusicPlayer_Load(object sender, EventArgs e)
        {
            //LoadUserPlaylists(); // Load playlists when the form loads
            //LoadUserTracks(); //load the tracks
        }


        private void btnMakePlaylist_Click(object sender, EventArgs e)
        {
            //// Prompt the user for a playlist name.
            //string playlistName = Microsoft.VisualBasic.Interaction.InputBox("Enter playlist name:", "Create Playlist", "");
            //if (!string.IsNullOrEmpty(playlistName)) //check if the playlist name is not null or empty
            //{
            //    // Get the username of the logged-in user.
            //    string username = GlobalUser.LoggedInUsername;

            //    // Add the playlist to the database.
            //    int newPlaylistId = db.AddPlaylist(username, playlistName); //returns the id

            //    if (newPlaylistId != -1)
            //    {
            //        // If the playlist was added successfully, update the ListView.
            //        ListViewItem item = new ListViewItem(playlistName);
            //        item.Tag = newPlaylistId; // Store the PlaylistID in the Tag property.
            //        lvwPlaylists.Items.Add(item);
            //        MessageBox.Show("Playlist created successfully!");
            //    }
            //    else
            //    {
            //        MessageBox.Show("Failed to create playlist.");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Playlist name cannot be empty.");
            //}
        }

        private void btnSavePlaylist_Click(object sender, EventArgs e)
        {
            //if (lvwPlaylists.SelectedItems.Count > 0)
            //{
            //    int playlistId = (int)lvwPlaylists.SelectedItems[0].Tag; // Get PlaylistID from the Tag
            //    // Clear the current tracks in the playlist display
            //    dgvTracksInPlaylist.Rows.Clear();

            //    DataTable tracks = db.GetTracksInPlaylist(playlistId); //get the tracks
            //    if (tracks != null)
            //    {
            //        // Iterate through the tracks and add them to the DataGridView.
            //        foreach (DataRow row in tracks.Rows)
            //        {
            //            int trackId = Convert.ToInt32(row["TrackID"]);
            //            string title = row["Title"].ToString();
            //            string artist = row["Artist"].ToString();
            //            string filePath = row["FilePath"].ToString();

            //            dgvTracksInPlaylist.Rows.Add(trackId, title, artist, filePath);
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Error loading tracks for the playlist.");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Please select a playlist to load.");
            //}
        }

        private void btnDeletePlaylist_Click(object sender, EventArgs e)
        {
            //if (lvwPlaylists.SelectedItems.Count > 0)
            //{
            //    int playlistId = (int)lvwPlaylists.SelectedItems[0].Tag; // Get PlaylistID
            //    string playlistName = lvwPlaylists.SelectedItems[0].Text;

            //    DialogResult result = MessageBox.Show($"Are you sure you want to delete the playlist '{playlistName}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //    if (result == DialogResult.Yes)
            //    {
            //        if (db.DeletePlaylist(playlistId))
            //        {
            //            lvwPlaylists.SelectedItems[0].Remove(); // Remove from ListView
            //            dgvTracksInPlaylist.Rows.Clear(); // Clear displayed tracks
            //            MessageBox.Show("Playlist deleted successfully.");
            //        }
            //        else
            //        {
            //            MessageBox.Show("Failed to delete playlist.");
            //        }
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Please select a playlist to delete.");
            //}
        }

        private void btnDeleteTrack_Click(object sender, EventArgs e)
        {
            //if (lvwPlaylists.SelectedItems.Count > 0 && dgvTracksInPlaylist.SelectedRows.Count > 0)
            //{
            //    int playlistId = (int)lvwPlaylists.SelectedItems[0].Tag;
            //    int trackId = Convert.ToInt32(dgvTracksInPlaylist.SelectedRows[0].Cells["TrackID"].Value); // Ensure "TrackID" is the correct column name

            //    string trackTitle = dgvTracksInPlaylist.SelectedRows[0].Cells["Title"].Value.ToString(); // Get track title for confirmation

            //    DialogResult result = MessageBox.Show($"Are you sure you want to remove the track '{trackTitle}' from this playlist?", "Confirm Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //    if (result == DialogResult.Yes)
            //    {
            //        if (db.DeleteTrackFromPlaylist(playlistId, trackId))
            //        {
            //            dgvTracksInPlaylist.Rows.RemoveAt(dgvTracksInPlaylist.SelectedRows[0].Index); // Remove from DataGridView
            //            MessageBox.Show("Track removed from playlist.");
            //        }
            //        else
            //        {
            //            MessageBox.Show("Failed to remove track from playlist.");
            //        }
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Please select a playlist and a track to remove.");
            //}
        }

        private void btnEditTrack_Click(object sender, EventArgs e)
        {
            //if (dgvTracksInPlaylist.SelectedRows.Count > 0)
            //{
            //    int trackId = Convert.ToInt32(dgvTracksInPlaylist.SelectedRows[0].Cells["TrackID"].Value);
            //    string currentTitle = dgvTracksInPlaylist.SelectedRows[0].Cells["Title"].Value.ToString();
            //    string currentArtist = dgvTracksInPlaylist.SelectedRows[0].Cells["Artist"].Value.ToString();

            //    // Open the TrackEditor form, passing the current track details.
            //    TrackEditor trackEditor = new TrackEditor(trackId, currentTitle, currentArtist);
            //    if (trackEditor.ShowDialog() == DialogResult.OK) // Show as dialog, and check the result
            //    {
            //        // If the user clicked "Save" in the TrackEditor form, update the DataGridView.
            //        string newTitle = trackEditor.NewTitle;
            //        string newArtist = trackEditor.NewArtist;

            //        if (db.EditTrack(trackId, newTitle, newArtist))
            //        {
            //            dgvTracksInPlaylist.SelectedRows[0].Cells["Title"].Value = newTitle;
            //            dgvTracksInPlaylist.SelectedRows[0].Cells["Artist"].Value = newArtist;
            //            MessageBox.Show("Track edited successfully.");
            //        }
            //        else
            //        {
            //            MessageBox.Show("Failed to edit track.");
            //        }


            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Please select a track to edit.");
            //}
        }

        private void btnAddTrack_Click(object sender, EventArgs e)
        {
            //if (lvwPlaylists.SelectedItems.Count > 0)
            //{
            //    int playlistId = (int)lvwPlaylists.SelectedItems[0].Tag;
            //    TrackAdder trackAdder = new TrackAdder();
            //    if (trackAdder.ShowDialog() == DialogResult.OK)
            //    {
            //        string title = trackAdder.NewTitle;
            //        string artist = trackAdder.NewArtist;
            //        string filePath = trackAdder.NewFilePath;
            //        string username = GlobalUser.LoggedInUsername;

            //        // First add the track to MusicTracks
            //        if (db.AddTrack(username, title, artist, filePath))
            //        {
            //            // Get the ID of the newly added track
            //            int newTrackId = db.GetLastInsertId();

            //            if (newTrackId != -1)
            //            {
            //                // Add to playlist
            //                if (db.AddTrackToPlaylist(playlistId, newTrackId))
            //                {
            //                    MessageBox.Show("Track added to playlist successfully.");
            //                    LoadTracksInPlaylist(playlistId);
            //                }
            //                else
            //                {
            //                    MessageBox.Show("Failed to add track to playlist.");
            //                }
            //            }
            //            else
            //            {
            //                MessageBox.Show("Could not retrieve new track ID.");
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show("Failed to add track to library.");
            //        }
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Please select a playlist to add the track to.");
            //}
        }

        private void LoadUserPlaylists()
        {
            //string username = GlobalUser.LoggedInUsername;
            //DataTable playlists = db.GetUserPlaylists(username); //get user's playlists

            //if (playlists != null)
            //{
            //    lvwPlaylists.Items.Clear(); // Clear any existing items
            //    foreach (DataRow row in playlists.Rows)
            //    {
            //        int playlistId = Convert.ToInt32(row["PlaylistID"]);
            //        string playlistName = row["PlaylistName"].ToString();
            //        ListViewItem item = new ListViewItem(playlistName);
            //        item.Tag = playlistId; // Store the PlaylistID in the Tag.
            //        lvwPlaylists.Items.Add(item);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Failed to load playlists.");
            //}
        }

        private void LoadTracksInPlaylist(int playlistId)
        {
            //dgvTracksInPlaylist.Rows.Clear();
            //DataTable tracks = db.GetTracksInPlaylist(playlistId);
            //if (tracks != null)
            //{
            //    // Iterate through the tracks and add them to the DataGridView.
            //    foreach (DataRow row in tracks.Rows)
            //    {
            //        int trackId = Convert.ToInt32(row["TrackID"]);
            //        string title = row["Title"].ToString();
            //        string artist = row["Artist"].ToString();
            //        string filePath = row["FilePath"].ToString();

            //        dgvTracksInPlaylist.Rows.Add(trackId, title, artist, artist, filePath);
            //    }
            //}
        }

        private void LoadUserTracks()
        {
            //string username = GlobalUser.LoggedInUsername;
            //DataTable tracks = db.GetUserTracks(username);

            //if (tracks != null)
            //{
            //    // dgvAllTracks.Rows.Clear;
            //    // foreach(DataRow row in tracks.Rows){
            //    //     int trackId = Convert.ToInt32(row["TrackID"]);
            //    //     string title = row["Title"].ToString();
            //    //     string artist = row["Artist"].ToString();
            //    //     string filePath = row["FilePath"].ToString();
            //    //     dgvAllTracks.Rows.Add(trackId, title, artist, filePath);
            //    // }
            //}
        }
    }
}

