using Cozify;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using NAudio.CoreAudioApi;

//add music player, add analytics and monitoring, add admin account
namespace finals
{
    public partial class MAIN_HUB : BaseForm
    {
        private HABIT_CHECKER habitChecker;
        private TO_DO_LIST toDo;
        private JOURNAL journal;
        private Guide guide;
        private POMODORO pomo;
        private STATS sTAT;
        private MailToAdmin mailToAdmin;

        private bool isFocused = false;
        private Form activeFeature = null;
        private bool sessionActive = false;

        private string _currentPlaylistDirectory;
        private List<string> _currentPlaylistTracks = new List<string>();
        private int _currentTrackIndex = 0;
        private IWavePlayer _wavePlayer;
        private AudioFileReader _audioFileReader;
        private bool _isPlaying = false;
        private float _volume = 1.0f;
        private bool _isLooping = false;

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        public MAIN_HUB()
        {
            InitializeComponent();
            this.MouseDown += MAIN_HUB_MouseDown;

            Application.ApplicationExit += (sender, e) =>
            {
                if (sessionActive)
                {
                    db.StopSessionTimer();
                    sessionActive = false;
                }
            };

            // Volume Slider Init
            trkBarVolumeSlider.Minimum = 0;
            trkBarVolumeSlider.Maximum = 100;
            trkBarVolumeSlider.Value = (int)(_volume * 100);
            trkBarVolumeSlider.TickFrequency = 10;
            trkBarVolumeSlider.LargeChange = 10;
            trkBarVolumeSlider.SmallChange = 1;
        }

        private void MAIN_HUB_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0xA1, 0x2, 0);
            }
        }

        // Window Controls
        private void btnMaxMainHub_Click(object sender, EventArgs e)
        {
            this.WindowState = (this.WindowState == FormWindowState.Maximized)
                ? FormWindowState.Normal
                : FormWindowState.Maximized;
        }

        private void btnMiniMainHub_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;

        private void btnExitMainHub_Click(object sender, EventArgs e)
        {
            this.btnExitMainHub.FlatAppearance.MouseOverBackColor = Color.Transparent;
            StopPlayback();
            Application.Exit();
        }


        private void btnLogOut_Click(object sender, EventArgs e)
        {
            try
            {
                // Close all opened feature forms
                foreach (Form feature in new Form[] { habitChecker, toDo, journal, guide, pomo, sTAT })
                    if (feature != null && !feature.IsDisposed) feature.Close();

                if (sessionActive)
                {
                    db.StopSessionTimer();
                    sessionActive = false;
                }

                this.Hide();
                new LOGIN().Show();
                StopPlayback();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during logout: {ex.Message}");
                Debug.WriteLine($"Logout error: {ex}");
            }
        }

        private void MAIN_HUB_Load(object sender, EventArgs e)
        {
            try
            {
                WelcomeLabel.Text = $"{GlobalUser.LoggedInUsername}'s space";
                this.Resize += MAIN_HUB_Resize;

                if (!sessionActive)
                {
                    db.SessionStartTime();
                    sessionActive = true;
                    Debug.WriteLine("Session timer started");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing session: {ex.Message}");
                Debug.WriteLine($"Session start error: {ex}");
            }
        }

        private void MAIN_HUB_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (sessionActive)
                {
                    db.StopSessionTimer();
                    sessionActive = false;
                    Debug.WriteLine("Session timer stopped");
                    StopPlayback();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error stopping session timer: {ex}");
            }
        }


        private void MAIN_HUB_Resize(object sender, EventArgs e)
        {
            if (activeFeature != null && !activeFeature.IsDisposed)
                activeFeature.WindowState = this.WindowState;
        }

        private void MainHubClock(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("hh:mm tt");
            lblDate.Text = DateTime.Now.ToString("dddd, MMMM dd");
        }
        private void btnHabitChecker_Click(object sender, EventArgs e)
        {
            if (habitChecker == null || habitChecker.IsDisposed)
            {
                habitChecker = new HABIT_CHECKER();
                habitChecker.FormClosed += HabitChecker_FormClosed;
                habitChecker.Show();
                habitChecker.TopMost = true;

                activeFeature = habitChecker;

            }
            else
            {
                habitChecker.Close();
                activeFeature = null;
            }

        }

        private void HabitChecker_FormClosed(object sender, FormClosedEventArgs e)
        {
            habitChecker = null;
            activeFeature = null;
        }


        private void btnToDoMain_Click(object sender, EventArgs e)
        {
            if (toDo == null || toDo.IsDisposed)
            {
                toDo = new TO_DO_LIST();
                toDo.FormClosed += ToDo_FormClosed;
                toDo.Show();
                toDo.TopMost = true;

                activeFeature = toDo;
            }
            else
            {
                toDo.Close();
                activeFeature = null;
            }
        }

        private void ToDo_FormClosed(object sender, FormClosedEventArgs e)
        {
            toDo = null;
        }

        private void btnJournal_Click(object sender, EventArgs e)
        {
            if (journal == null || journal.IsDisposed)
            {
                journal = new JOURNAL();
                journal.FormClosed += Journal_FormClosed;
                journal.Show();
                journal.TopMost = true;

                activeFeature = journal;
            }
            else
            {
                journal.Close();
                activeFeature = null;
            }
        }

        private void Journal_FormClosed(object sender, FormClosedEventArgs e)
        {
            journal = null;
            activeFeature = null;
        }


        private void btnPomo_Click(object sender, EventArgs e)
        {
            if (pomo == null || pomo.IsDisposed)
            {
                pomo = new POMODORO();
                pomo.FormClosed += (s, args) =>
                {
                    pomo = null;
                    activeFeature = null;
                };
                pomo.Show();
                pomo.TopMost = true;
                activeFeature = pomo;
            }
            else
            {
                pomo.Close();
                activeFeature = null;
            }
        }

        private void Pomo_FormClosed(object sender, FormClosedEventArgs e)
        {
            pomo = null;
            activeFeature = null;
        }

        private void btnZenMode_Click(object sender, EventArgs e)
        {
            isFocused = !isFocused; // Toggle state

            btnHabitChecker.Visible = !isFocused;
            btnJournal.Visible = !isFocused;
            btnPomo.Visible = !isFocused;
            btnToDoMain.Visible = !isFocused;
            btnPomo.Visible = !isFocused;
            btnHelpMainHub.Visible = !isFocused;
            btnMiniMainHub.Visible = !isFocused;
            btnExitMainHub.Visible = !isFocused;
            btnMaxMainHub.Visible = !isFocused;
            btnLogOut.Visible = !isFocused;
            lblClock.Visible = !isFocused;
            lblDate.Visible = !isFocused;
            btnStatistics.Visible = !isFocused;
            btnSendMessageToAdmin.Visible = !isFocused;
            btnMusicLib.Visible = !isFocused;

        }

        private void btnHelpMainHub_Click(object sender, EventArgs e)
        {
            if (guide == null || guide.IsDisposed)
            {
                guide = new Guide();
                guide.FormClosed += Pomo_FormClosed;
                guide.Show();
                guide.TopMost = true;

                activeFeature = guide;
            }
            else
            {
                guide.Close();
                activeFeature = null;
            }
        }
        private void Guide_FormClosed(object sender, FormClosedEventArgs e)
        {
            guide = null;
            activeFeature = null;
        }

        private void ChecklistToolTip_Show(object sender, EventArgs e)
        {
            ToolTip ToDoTooltip = new ToolTip();
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            if (sTAT == null || sTAT.IsDisposed)
            {
                sTAT = new STATS();
                sTAT.FormClosed += Statistics_FormClosed;
                sTAT.Show();
                sTAT.TopMost = true;
                activeFeature = sTAT;
            }
            else
            {
                sTAT.Close();
                activeFeature = null;
            }
        }

        private void Statistics_FormClosed(object sender, FormClosedEventArgs e)
        {
            sTAT = null;
            activeFeature = null;
        }

        private void btnPlayORStopTrack_Click(object sender, EventArgs e)
        {
            if (_currentPlaylistTracks.Count == 0)
                return;

            if (!_isPlaying) 
            {
                if (_wavePlayer == null)
                {
                    PlayTrack(_currentTrackIndex);
                }
                else
                {
                    _wavePlayer.Play();
                    _isPlaying = true;
                }
                using (var ms = new MemoryStream(Cozify.Properties.Resources.Pause_Button))
                {
                    btnPlayORStopTrack.Image = Image.FromStream(ms);
                }
            }
            else // If currently playing, pause
            {
                _wavePlayer?.Pause();
                _isPlaying = false;
                using (var ms = new MemoryStream(Cozify.Properties.Resources.Play_Button))
                {
                    btnPlayORStopTrack.Image = Image.FromStream(ms);
                }
            }
        }
        private void PlayTrack(int index)
        {
            if (index < 0 || index >= _currentPlaylistTracks.Count)
            {
                MessageBox.Show("Invalid track index.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                _wavePlayer?.Dispose();
                _audioFileReader?.Dispose();

                _audioFileReader = new AudioFileReader(_currentPlaylistTracks[index]);
                _wavePlayer = new WaveOut();
                _wavePlayer.Init(_audioFileReader);
                _wavePlayer.PlaybackStopped += OnPlaybackStopped; 
                _wavePlayer.Play();
                _isPlaying = true;
                using (var ms = new MemoryStream(Cozify.Properties.Resources.Pause_Button))
                {
                    btnPlayORStopTrack.Image = Image.FromStream(ms);
                }
                UpdateNowPlaying(index);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error playing track: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _isPlaying = false;
                using (var ms = new MemoryStream(Cozify.Properties.Resources.Play_Button))
                {
                    btnPlayORStopTrack.Image = Image.FromStream(ms);
                }
            }
        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (e.Exception == null)
            {
                _isPlaying = false;
                _wavePlayer?.Dispose();
                _audioFileReader?.Dispose();

                _currentTrackIndex++;

                if (_currentTrackIndex < _currentPlaylistTracks.Count)
                {
                    PlayTrack(_currentTrackIndex);
                }
                else if (_isLooping && _currentPlaylistTracks.Count > 0)
                {
                    _currentTrackIndex = 0;
                    PlayTrack(_currentTrackIndex);
                }
                else
                {
                    UpdateNowPlaying(-1);
                    using (var ms = new MemoryStream(Cozify.Properties.Resources.Play_Button))
                    {
                        btnPlayORStopTrack.Image = Image.FromStream(ms);
                    }
                }
            }
            else
            {
                MessageBox.Show($"Error during playback: {e.Exception.Message}",
                               "Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }

        private void btnNextTrack_Click(object sender, EventArgs e)
        {
            if (_currentPlaylistTracks.Count == 0)
                return;

            StopPlayback();
            _currentTrackIndex++;
            if (_currentTrackIndex >= _currentPlaylistTracks.Count)
            {
                _currentTrackIndex = 0;
            }
            PlayTrack(_currentTrackIndex);
        }

        private void btnPrevTrack_Click(object sender, EventArgs e)
        {
            if (_currentPlaylistTracks.Count == 0)
                return;
            StopPlayback();
            _currentTrackIndex--;
            if (_currentTrackIndex < 0)
            {
                _currentTrackIndex = _currentPlaylistTracks.Count - 1;
            }
            PlayTrack(_currentTrackIndex);
        }

        private void btnMusicLib_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            folderDialog.Description = "Select the folder containing your music files (mp3, wav).";
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                _currentPlaylistDirectory = folderDialog.SelectedPath;
                LoadPlaylist();
            }
        }
        private void LoadPlaylist()
        {
            _currentPlaylistTracks.Clear();
            _currentTrackIndex = 0;

            string[] supportedExtensions = { ".mp3", ".wav" };
            string[] files = Directory.GetFiles(_currentPlaylistDirectory)
                                      .Where(file => supportedExtensions.Contains(Path.GetExtension(file).ToLower()))
                                      .ToArray();

            if (files.Length > 0)
            {
                _currentPlaylistTracks = files.OrderBy(f => Path.GetFileName(f)).ToList();
                UpdateNowPlaying(_currentTrackIndex);
            }
            else
            {
                MessageBox.Show("No mp3 or wav files found in the selected folder.", "No Music Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void trkBarVolumeSlider_Scroll(object sender, EventArgs e)
        {
            _volume = trkBarVolumeSlider.Value / 100.0f;
            if (_wavePlayer != null)
                _wavePlayer.Volume = _volume;
            this.Text = "Volume: " + (int)(_volume * 100);
        }

        private void UpdateNowPlaying(int index)
        {
            if (index >= 0 && index < _currentPlaylistTracks.Count)
            {
                string fileName = Path.GetFileNameWithoutExtension(_currentPlaylistTracks[index]);
                lblSongAndArtist.Text = fileName;
            }
            else
            {
                lblSongAndArtist.Text = "None";
            }
        }
        private void btnLoopTracks_Click(object sender, EventArgs e)
        {
            _isLooping = !_isLooping;
            if (_isLooping)
            {
                using (MemoryStream ms = new MemoryStream(Cozify.Properties.Resources.RepeatActivated))
                {
                    btnLoopTracks.Image = Image.FromStream(ms);
                }
            }
            else
            {
                using (var ms = new MemoryStream(Cozify.Properties.Resources.Repeat))
                {
                    btnLoopTracks.Image = Image.FromStream(ms);
                }
            }
        }
        private void StopPlayback()
        {
            _wavePlayer?.Stop();
            _wavePlayer?.Dispose();
            _audioFileReader?.Dispose();
            _wavePlayer = null;
            _audioFileReader = null;
            _isPlaying = false;
            using (var ms = new MemoryStream(Cozify.Properties.Resources.Play_Button))
            {
                btnPlayORStopTrack.Image = Image.FromStream(ms);
            }
        }

        private void btnSendMessageToAdmin_Click(object sender, EventArgs e)
        {
            if (mailToAdmin == null || mailToAdmin.IsDisposed)
            {
                mailToAdmin = new MailToAdmin();
                mailToAdmin.FormClosed += MailToAdmin_Closed;
                mailToAdmin.Show();
                mailToAdmin.TopMost = true;
                activeFeature = mailToAdmin;
            }
            else
            {
                mailToAdmin.Close();
                activeFeature = null;
            }
        }

        private void MailToAdmin_Closed(object sender, FormClosedEventArgs e)
        {
            mailToAdmin = null;
            activeFeature = null;
        }
    }
}
