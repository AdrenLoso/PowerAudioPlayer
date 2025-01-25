using Microsoft.WindowsAPICodePack.Dialogs.Controls;
using Microsoft.WindowsAPICodePack.Dialogs;
using Microsoft.WindowsAPICodePack.Taskbar;
using PowerAudioPlayer.Controllers;
using PowerAudioPlayer.Controllers.Helper;
using PowerAudioPlayer.Controllers.PlayerCore;
using PowerAudioPlayer.Model;
using PowerAudioPlayer.UI;
using System.IO;
using Clipboard = System.Windows.Forms.Clipboard;
using DataFormats = System.Windows.Forms.DataFormats;
using DragDropEffects = System.Windows.Forms.DragDropEffects;
using DragEventArgs = System.Windows.Forms.DragEventArgs;
using MessageBox = System.Windows.Forms.MessageBox;
using SaveFileDialog = System.Windows.Forms.SaveFileDialog;
using Utils = PowerAudioPlayer.Controllers.Utils;
using Newtonsoft.Json;

namespace PowerAudioPlayer
{
    public partial class PlayerForm : Form
    {
        private readonly ThumbnailToolBarButton tbtnPrevious = new ThumbnailToolBarButton(Resources.Previousi, Player.GetString("SPrevious"));
        private readonly ThumbnailToolBarButton tbtnPlay = new ThumbnailToolBarButton(Resources.Playi, Player.GetString("Play"));
        private readonly ThumbnailToolBarButton tbtnPause = new ThumbnailToolBarButton(Resources.Pausei, Player.GetString("Pause"));
        private readonly ThumbnailToolBarButton tbtnStop = new ThumbnailToolBarButton(Resources.Stopi, Player.GetString("Stop"));
        private readonly ThumbnailToolBarButton tbtnNext = new ThumbnailToolBarButton(Resources.Nexti, Player.GetString("SNext"));
        private readonly WindowStateManager windowStateManager;
        private SoundEffectForm? soundEffectForm = null;
        private MediaLibraryForm mediaLibraryForm = new MediaLibraryForm();
        private PlaylistEditorForm playlistEditorForm = new PlaylistEditorForm();
        private LyricsForm lyricsForm = new LyricsForm();
        private AlbumPictureForm albumPictureForm = new AlbumPictureForm();
        

        public PlayerForm()
        {
            InitializeComponent();
            InitBinding();
            windowStateManager = new WindowStateManager(this);
            windowStateManager.LoadState();
            InitializeThumbnailButtons();
            InitializeForms();
            if (Settings.Default.MediaLibraryStartUpUpdate)
                NativeAPI.SendMessage(mediaLibraryForm.Handle, Player.WM_REFRESHMEDIALIBRARY, 0, 0);
        }

        private void InitializeThumbnailButtons()
        {
            tbtnPrevious.Click += (sender, e) => btnPrevious_Click(sender ?? this, EventArgs.Empty);
            tbtnPlay.Click += (sender, e) => btnPlay_Click(sender ?? this, EventArgs.Empty);
            tbtnPause.Click += (sender, e) => btnPause_Click(sender ?? this, EventArgs.Empty);
            tbtnStop.Click += (sender, e) => btnStop_Click(sender ?? this, EventArgs.Empty);
            tbtnNext.Click += (sender, e) => btnNext_Click(sender ?? this, EventArgs.Empty);
        }

        private void InitializeForms()
        {
            playlistEditorForm.Owner = this;
            lyricsForm.Owner = this;
            mediaLibraryForm.Owner = this;
            albumPictureForm.Owner = this;
            try
            {
                if (!string.IsNullOrEmpty(Settings.Default.WindowsOpenStatus))
                {
                    Dictionary<string, bool> windowsOpenStatus = JsonConvert.DeserializeObject<Dictionary<string, bool>>(Settings.Default.WindowsOpenStatus) ?? [];
                    if (windowsOpenStatus.ContainsKey(mediaLibraryForm.Name))
                        mediaLibraryForm.Visible = windowsOpenStatus[mediaLibraryForm.Name];
                    if (windowsOpenStatus.ContainsKey(lyricsForm.Name))
                        lyricsForm.Visible = windowsOpenStatus[lyricsForm.Name];
                    if (windowsOpenStatus.ContainsKey(playlistEditorForm.Name))
                        playlistEditorForm.Visible = windowsOpenStatus[playlistEditorForm.Name];
                    if (windowsOpenStatus.ContainsKey(albumPictureForm.Name))
                        albumPictureForm.Visible = windowsOpenStatus[albumPictureForm.Name];
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                playlistEditorForm.Show();
                lyricsForm.Show();
                albumPictureForm.Show();
            }
        }

        #region Player Control Method
        private void ReadConfig()
        {
            Player.Core.SetVolume(Settings.Default.Volume);
            trbVolume.Value = Settings.Default.Volume;
            UpdateControls();
        }

        private void Play(int index)
        {
            if (PlaylistHelper.ActivePlaylist.IsOutOfRange(index)) return;

            lblStatus1.Text = Player.GetString("MsgReady");
            Player.ResetABRepeat();
            UpdateABRepeatToolTip();
            Player.Core.Open(PlaylistHelper.ActivePlaylist.Items[index].File);

            if (!Player.Core.IsOpened())
            {
                lblStatus1.Text = Player.GetString("MsgPlayErrorWithArg", PlaylistHelper.ActivePlaylist.Items[index].DisplayTitle);
                if (!Settings.Default.StopPlayingWhenError) Play(index + 1);
                return;
            }

            if (!Player.Core.IsSoundFontLoaded())
                lblStatus1.Text = Player.GetString("MsgMIDISoundFontNotSelected");

            Player.playIndex = index;
            Player.Core.Play();
            UpdateAudioInfo(PlaylistHelper.ActivePlaylist.Items[index].File);
            lblDisplayTitle.Text = PlaylistHelper.ActivePlaylist.Items[index].DisplayTitle;

            tmrPlayer.Start();
            LoadLyrics();
            UpdateControls();
            if (Settings.Default.RecordPlayHistroy)
            {
                PlayHistoryHelper.Add(PlaylistHelper.ActivePlaylist.Items[index]);
                NativeAPI.SendMessage(mediaLibraryForm.Handle, Player.WM_REFRESHHISTORYVIEW, 0, 0);
            }
        }

        private void UpdateAudioInfo(string file)
        {
            AudioInfo audioInfo = AudioInfoHelper.GetAudioInfo(file);
            //picAlbum.Image = AudioInfoHelper.GetAudioPicture(file);
            albumPictureForm.SetAlbumPicture(AudioInfoHelper.GetAudioPicture(file));
            if (audioInfo != null)
            {
                lblTitle.Text = !string.IsNullOrEmpty(audioInfo.Tag.Title) ? audioInfo.Tag.Title : string.Empty;
                lblArtist.Text = !string.IsNullOrEmpty(audioInfo.Tag.Artist) ? audioInfo.Tag.Artist : string.Empty;
                lblAlbum.Text = !string.IsNullOrEmpty(audioInfo.Tag.Album) ? audioInfo.Tag.Album : string.Empty;
                lblInfo.Text = Player.Core.GetChannelInfo().ToString();
            }
        }

        private void Stop()
        {
            tmrPlayer.Stop();
            tmrLyrics.Stop();
            NativeAPI.SendMessage(lyricsForm.Handle, Player.WM_CLEARLRC, 0, 0);
            Player.Core.Stop();
            UpdateControls();
        }

        private void LoadLyrics()
        {
            NativeAPI.SendMessage(lyricsForm.Handle, Player.WM_LOADLYRICS, 0, 0);
            tmrLyrics.Start();
        }

        private void HandleCommandLine(string[] cmd) { }

        #endregion

        #region UI Method
        private void InitBinding()
        {
            Binding binding = new Binding("Text", Settings.Default, "Volume", true, DataSourceUpdateMode.OnPropertyChanged);
            binding.Format += (sender, e) => e.Value = $"{e.Value}%";
            lblVolume.DataBindings.Add(binding);

            AddRadioCheckedBinding(tsemiOrderPlay, Settings.Default, "PlayMode", PlayMode.OrderPlay);
            AddRadioCheckedBinding(tsemiShufflePlay, Settings.Default, "PlayMode", PlayMode.ShufflePlay);
            AddRadioCheckedBinding(tsemiTrackLoop, Settings.Default, "PlayMode", PlayMode.TrackLoop);
            AddRadioCheckedBinding(tsemiPlaylistLoop, Settings.Default, "PlayMode", PlayMode.PlaylistLoop);
        }

        private void AddRadioCheckedBinding<T>(WinFormsExtendedControls.ToolStripEnhancedMenuItem radio, object dataSource, string dataMember, T trueValue)
        {
            var binding = new Binding(nameof(WinFormsExtendedControls.ToolStripEnhancedMenuItem.Checked), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
            binding.Parse += (s, a) => { if (a.Value is bool value && value) a.Value = trueValue; };
            binding.Format += (s, a) => a.Value = a.Value is T value && value.Equals(trueValue);
            radio.DataBindings.Add(binding);
        }

        private void UpdateControls()
        {
            if (Player.Core.GetChannelStatus() == PlayerChannelStatus.Stopped || !Player.Core.IsOpened())
            {
                ResetControls();
            }
            else
            {
                UpdatePlayingControls();
            }
        }

        private void ResetControls()
        {
            Text = Application.ProductName;
            lblPosition.Text = "00:00 / 00:00";
            trbPosition.Enabled = false;
            trbPosition.Maximum = 0;
            lblAlbum.Text = string.Empty;
            lblArtist.Text = string.Empty;
            lblTitle.Text = string.Empty;
            lblDisplayTitle.Text = Application.ProductName;
            lblInfo.Text = string.Empty;
            albumPictureForm.ClearAlbumPicture();
            lblStatus.Text = Player.GetString("Stop");
            SetTaskbarOverlayIcon(null, lblStatus.Text);
            SetTaskbarProgressState(TaskbarProgressBarState.NoProgress);
        }

        private void UpdatePlayingControls()
        {
            lblPosition.Text = $"{Utils.FormatTimeSecond(Player.Core.GetPositionSecond())}/{Utils.FormatTimeSecond(Player.Core.GetLengthSecond())}({((double)Player.Core.GetPositionMillisecond() / Player.Core.GetLengthMillisecond()):P1})";
            trbPosition.Maximum = Player.Core.GetLengthMillisecond();
            if (Player.Core.GetChannelStatus() == PlayerChannelStatus.Playing)
            {
                try
                {
                    trbPosition.Value = Player.Core.GetPositionMillisecond();
                    trbPosition.Enabled = true;
                }
                catch
                {
                    trbPosition.Enabled = false;
                }
                lblStatus.Text = Player.GetString("Play");
                SetTaskbarOverlayIcon(Resources.Playi, lblStatus.Text);
                SetTaskbarProgressState(TaskbarProgressBarState.Normal);
            }
            else
            {
                trbPosition.Enabled = false;
                lblStatus.Text = Player.GetString("Pause");
                SetTaskbarOverlayIcon(Resources.Pausei, lblStatus.Text);
                SetTaskbarProgressState(TaskbarProgressBarState.Paused);
            }
            Text = $"[{lblStatus.Text}]{lblDisplayTitle.Text} - {Application.ProductName}";
            try
            {
                SetTaskbarProgressValue(trbPosition.Value, trbPosition.Maximum);
            }
            catch
            {
                SetTaskbarProgressValue(0, 0);
            }
        }

        private void UpdateABRepeatToolTip()
        {
            if (Player.abRepeatMode == ABRepeatMode.ASelected)
            {
                lblStatus1.Text = Player.GetString("MsgABRepeatSelectedA");
                trbPosition.EnableSelRange = true;
                trbPosition.SelStart = trbPosition.Value;
            }
            else if (Player.abRepeatMode == ABRepeatMode.ABRepeat)
            {
                lblStatus1.Text = Player.GetString("MsgReady");
                tsmiABRepeat.Checked = true;
                trbPosition.SelEnd = trbPosition.Value;
            }
            else
            {
                lblStatus1.Text = Player.GetString("MsgReady");
                tsmiABRepeat.Checked = false;
                trbPosition.EnableSelRange = false;
            }
        }

        private void InitTrackbarControlButton()
        {
            TaskbarManager.Instance.ThumbnailToolBars?.AddButtons(Handle, tbtnPrevious, tbtnPlay, tbtnPause, tbtnStop, tbtnNext);
        }

        private void SetTaskbarProgressState(TaskbarProgressBarState state)
        {
            if (Settings.Default.EnableTrackbarProgress)
                TaskbarManager.Instance.SetProgressState(state);
            else
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
        }

        private void SetTaskbarProgressValue(int currentValue, int? maximumValue)
        {
            if (Settings.Default.EnableTrackbarProgress)
                TaskbarManager.Instance.SetProgressValue(currentValue, maximumValue);
            else
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
        }

        private void SetTaskbarOverlayIcon(Icon? icon, string accessibilityText)
        {
            if (Settings.Default.ShowStatusInTaskbarIcon)
                TaskbarManager.Instance.SetOverlayIcon(icon, accessibilityText);
            else
                TaskbarManager.Instance.SetOverlayIcon(null, "");
        }
        #endregion

        #region Events

        private void tmrPlayer_Tick(object sender, EventArgs e)
        {
            if (Player.Core.IsEnded())
            {
                HandlePlaybackEnd();
            }
            Player.ContinueABRepeat();
            UpdateControls();
        }

        private void HandlePlaybackEnd()
        {
            if (Settings.Default.PlayMode == PlayMode.TrackLoop)
            {
                Play(Player.playIndex);
                return;
            }
            tmrPlayer.Stop();
            tmrLyrics.Stop();
            switch (Settings.Default.PlayMode)
            {
                case PlayMode.OrderPlay:
                    if (Player.playIndex >= PlaylistHelper.ActivePlaylist.Count - 1)
                    {
                        Player.Core.Close();
                        UpdateControls();
                    }
                    else
                    {
                        btnNext_Click(new object(), new EventArgs());
                    }
                    break;
                case PlayMode.PlaylistLoop:
                    if (Player.playIndex >= PlaylistHelper.ActivePlaylist.Count - 1)
                        Play(0);
                    else
                        btnNext_Click(new object(), new EventArgs());
                    break;
                case PlayMode.ShufflePlay:
                    Play(new Random().Next(0, PlaylistHelper.ActivePlaylist.Count));
                    break;
            }
        }

        private void trbVolume_Scroll(object sender, EventArgs e)
        {
            Player.Core.SetVolume(trbVolume.Value);
            Settings.Default.Volume = trbVolume.Value;
        }

        private void tmrLyrics_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Player.playIndex != -1 && Player.Core.GetChannelStatus() == PlayerChannelStatus.Playing)
                    NativeAPI.SendMessage(lyricsForm.Handle, Player.WM_LRCROLL, Player.Core.GetPositionMillisecond(), 0);
            }
            catch
            {
                NativeAPI.SendMessage(lyricsForm.Handle, Player.WM_CLEARLRC, 0, 0);
            }
        }

        private void trbPosition_Scroll(object sender, EventArgs e)
        {
            if (Player.Core.GetChannelStatus() == PlayerChannelStatus.Playing)
                Player.Core.SetPositionMillisecond(trbPosition.Value);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (Settings.Default.PlayMode == PlayMode.ShufflePlay)
                Play(new Random().Next(0, PlaylistHelper.ActivePlaylist.Count));
            else
                Play(Player.playIndex - 1);
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (Player.playIndex == -1 && PlaylistHelper.ActivePlaylist.Count > 0)
            {
                Play(0);
                return;
            }
            if (Player.Core.GetChannelStatus() == PlayerChannelStatus.Paused)
            {
                Player.Core.Play();
                tmrPlayer.Start();
            }
            else if (Player.Core.GetChannelStatus() == PlayerChannelStatus.Stopped)
            {
                Play(Player.playIndex);
            }
            else
            {
                Player.ResetABRepeat();
                UpdateABRepeatToolTip();
                Player.Core.SetPositionMillisecond(0);
            }
            UpdateControls();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (Player.playIndex == -1 && PlaylistHelper.ActivePlaylist.Count > 0)
            {
                Play(0);
                return;
            }
            if (Player.Core.GetChannelStatus() == PlayerChannelStatus.Paused)
            {
                Player.Core.Play();
                tmrPlayer.Start();
            }
            else if (Player.Core.GetChannelStatus() == PlayerChannelStatus.Stopped)
            {
                Play(Player.playIndex);
            }
            else
            {
                Player.Core.Pause();
                tmrPlayer.Stop();
            }
            UpdateControls();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Player.ResetABRepeat();
            UpdateABRepeatToolTip();
            Stop();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (((PlayMode)Settings.Default.PlayMode) == PlayMode.ShufflePlay)
                btnPrevious_Click(sender, e);
            else
                Play(Player.playIndex + 1);
        }

        private void PlayerForm_Shown(object sender, EventArgs e)
        {
            ReadConfig();
            if (Settings.Default.EnableTrackbarControlButton)
                InitTrackbarControlButton();

            if (Environment.GetCommandLineArgs().Length > 1 && PlaylistHelper.ActivePlaylist.Count > 0)
                Play(0);
        }

        private void tsbtnSettings_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm { Owner = this };
            settingsForm.ShowDialog();
        }

        private void tsmiExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = Player.GetString("FilterPlaylist"),
                FileName = $"{PlaylistHelper.ActivePlaylist.Name}.json"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                PlaylistHelper.SavePlaylist(saveFileDialog.FileName);
            }
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case Player.WM_PLAY:
                    Play(Convert.ToInt32(m.WParam));
                    if (m.LParam == 1)
                        NativeAPI.SendMessage(playlistEditorForm.Handle, Player.WM_REFRESHPLAYLISTVIEW, 0, 0);
                    break;
                case Player.WM_REFRESHPLAYLISTVIEW:
                    NativeAPI.SendMessage(playlistEditorForm.Handle, Player.WM_REFRESHPLAYLISTVIEW, 0, 0);
                    break;
                case Player.WM_LOCATETO:
                    NativeAPI.SendMessage(playlistEditorForm.Handle, Player.WM_LOCATETO, 0, 0);
                    break;
                case Player.WM_REFRESHMEDIALIBRARY:
                    NativeAPI.SendMessage(mediaLibraryForm.Handle, Player.WM_REFRESHMEDIALIBRARY, 0, 0);
                    break;
                case Player.WM_HANDLECOMMANDLINE:
                    HandleCommandLine(Environment.GetCommandLineArgs());
                    break;
                case NativeAPI.WM_COPYDATA:
                    HandleCopyData(m);
                    break;
                case NativeAPI.WM_APPCOMMAND:
                    HandleAppCommand(m);
                    break;
            }

            base.WndProc(ref m);
        }

        private void HandleCopyData(Message m)
        {
            NativeAPI.COPYDATASTRUCT cdata = (NativeAPI.COPYDATASTRUCT?)m.GetLParam(typeof(NativeAPI.COPYDATASTRUCT)) ?? default;
            var args = Utils.SegmentCommandLine(cdata.lpData);
            args[0] = string.Empty;
            if (args.Length > 1)
            {
                PlaylistHelper.ActivePlaylist.Items.Clear();
                foreach (var f in args)
                {
                    if (!string.IsNullOrEmpty(f))
                        PlaylistHelper.ActivePlaylist.Items.Add(PlaylistItem.FormFile(f));
                }
                NativeAPI.SendMessage(playlistEditorForm.Handle, Player.WM_REFRESHPLAYLISTVIEW, 0, 0);
                Play(0);
            }
        }

        private void HandleAppCommand(Message m)
        {
            if (Settings.Default.ResponseAppCommand)
            {
                int cmd = (int)((uint)m.LParam >> 16 & ~0xf000);
                switch (cmd)
                {
                    case NativeAPI.APPCOMMAND_MEDIA_PREVIOUSTRACK:
                        btnPrevious_Click(new(), new());
                        break;
                    case NativeAPI.APPCOMMAND_MEDIA_NEXTTRACK:
                        btnNext_Click(new(), new());
                        break;
                    case NativeAPI.APPCOMMAND_MEDIA_PAUSE:
                        btnPause_Click(new(), new());
                        break;
                    case NativeAPI.APPCOMMAND_MEDIA_PLAY:
                        btnPlay_Click(new(), new());
                        break;
                    case NativeAPI.APPCOMMAND_MEDIA_PLAY_PAUSE:
                        btnPause_Click(new(), new());
                        break;
                    case NativeAPI.APPCOMMAND_MEDIA_STOP:
                        btnStop_Click(new(), new());
                        break;
                    case NativeAPI.APPCOMMAND_VOLUME_DOWN:
                        try
                        {
                            trbVolume.Value -= 4;
                            trbVolume_Scroll(new(), new());
                        }
                        catch
                        {
                            trbVolume.Value = 100;
                        }
                        break;
                    case NativeAPI.APPCOMMAND_VOLUME_UP:
                        try
                        {
                            trbVolume.Value += 4;
                            trbVolume_Scroll(new(), new());
                        }
                        catch
                        {
                            trbVolume.Value = 100;
                        }
                        break;
                }
            }
        }

        private void PlayerForm_MouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                trbVolume.Value += e.Delta > 0 ? 2 : -2;
                trbVolume_Scroll(sender, new EventArgs());
            }
            catch
            {
                trbVolume.Value = e.Delta > 0 ? 100 : 0;
            }
        }

        private void PlayerForm_DragDrop(object sender, DragEventArgs e)
        {
            string[]? files = (string[]?)e.Data?.GetData(DataFormats.FileDrop, false);
            if (files != null)
            {
                string[]? allFileFilter = Player.Core.GetAllSupportedFileArray();
                List<PlaylistItem> items = new List<PlaylistItem>();
                foreach (var file in files)
                {
                    string ext = Path.GetExtension(file).ToLower();
                    if (ext == ".sf2" || ext == ".sf2pack" || ext == ".sf3")
                    {
                        Player.Core.SetMIDISoundFont(file);
                        Settings.Default.MIDISoundFont = file;
                    }
                    else if (allFileFilter.Contains("*" + ext) || allFileFilter.Length == 0)
                    {
                        items.Add(PlaylistItem.FormFile(file));
                    }
                }
                if (items.Count > 0)
                {
                    PlaylistHelper.ActivePlaylist.Clear();
                    PlaylistHelper.ActivePlaylist.Items.AddRange(items);
                    NativeAPI.SendMessage(playlistEditorForm.Handle, Player.WM_REFRESHPLAYLISTVIEW, 0, 0);
                    Play(0);
                }
            }
        }

        private void PlayerForm_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.All : DragDropEffects.None;
        }

        private void tsbtnAPRepeat_Click(object sender, EventArgs e)
        {
            if (Player.Core.GetChannelStatus() == PlayerChannelStatus.Stopped || Player.Core.GetChannelStatus() == PlayerChannelStatus.Paused)
                return;
            Player.DoABRepeat();
            UpdateABRepeatToolTip();
        }

        private void tsbtnSoundEffect_Click(object sender, EventArgs e)
        {
            if (soundEffectForm == null)
            {
                soundEffectForm = new SoundEffectForm { Owner = this };
                soundEffectForm.FormClosed += (s, e) => soundEffectForm = null;
                soundEffectForm.Show();
            }
            else
            {
                soundEffectForm.Close();
                soundEffectForm = null;
            }
        }

        private void lbl_DoubleClick(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(((Label)sender).Text);
            MessageBox.Show(Player.GetString("MsgCopyed", ((Label)sender).Text), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tsbtnMediaLibraryForm_Click(object sender, EventArgs e)
        {
            if (mediaLibraryForm.Visible)
            {
                mediaLibraryForm.Hide();
            }
            else
            {
                mediaLibraryForm.Show();
            }
        }

        private void PlayerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                windowStateManager.SaveState();
            Dictionary<string, bool> windowsOpenStatus = new Dictionary<string, bool>
            {
                { mediaLibraryForm.Name, mediaLibraryForm.Visible },
                { lyricsForm.Name, lyricsForm.Visible },
                { playlistEditorForm.Name, playlistEditorForm.Visible },
                { albumPictureForm.Name, albumPictureForm.Visible }
            };
            Settings.Default.WindowsOpenStatus = JsonConvert.SerializeObject(windowsOpenStatus);
            mediaLibraryForm.Close();
            playlistEditorForm.Close();
            lyricsForm.Close();
            albumPictureForm.Close();
            mediaLibraryForm.Dispose();
            playlistEditorForm.Dispose();
            lyricsForm.Dispose();
            albumPictureForm.Dispose();
            e.Cancel = false;
        }

        private void lblDisplayTitle_DoubleClick(object sender, EventArgs e)
        {
            if (Player.playIndex != -1)
                new InformationForm { Tag = PlaylistHelper.ActivePlaylist.Items[Player.playIndex].File }.ShowDialog();
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        private void tsmiSupportedFormat_Click(object sender, EventArgs e)
        {
            new SupportrdFormatForm().ShowDialog();
        }

        private void tsmiCreateDesktopShortcut_Click(object sender, EventArgs e)
        {
            Utils.CreateShortcut(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), Application.ProductName + ".lnk"), Application.ExecutablePath, "");
        }

        private void tsmiABRepeat_Click(object sender, EventArgs e)
        {
            if (Player.Core.GetChannelStatus() == PlayerChannelStatus.Stopped || Player.Core.GetChannelStatus() == PlayerChannelStatus.Paused)
                return;
            Player.DoABRepeat();
            UpdateABRepeatToolTip();
        }

        private void trbPosition_MouseDown(object sender, MouseEventArgs e)
        {
            if (Player.abRepeatMode == ABRepeatMode.ASelected && e.Button == MouseButtons.Right)
            {
                Player.DoABRepeat();
                UpdateABRepeatToolTip();
            }
        }

        private void tsmiLyricsForm_Click(object sender, EventArgs e)
        {
            if (lyricsForm.Visible)
            {
                lyricsForm.Hide();
            }
            else
            {
                lyricsForm.Show();
            }
        }

        private void tsmiPlaylistEditorForm_Click(object sender, EventArgs e)
        {
            if (playlistEditorForm.Visible)
            {
                playlistEditorForm.Hide();
            }
            else
            {
                playlistEditorForm.Show();
            }
        }

        private void tsmiAddFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Multiselect = true,
                Filter = Player.Core.GetAllSupportedFileFilter(Player.GetString("AllSupportedFileFilter"), Player.GetString("AllFiles"))
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.FileNames.Length > 0)
                {
                    PlaylistHelper.ActivePlaylist.Items.Clear();
                    foreach (var f in openFileDialog.FileNames)
                    {
                        if (!string.IsNullOrEmpty(f))
                            PlaylistHelper.ActivePlaylist.Items.Add(PlaylistItem.FormFile(f));
                    }
                    NativeAPI.SendMessage(playlistEditorForm.Handle, Player.WM_REFRESHPLAYLISTVIEW, 0, 0);
                    Play(0);
                }
            }
        }

        private void tsmiAddFolder_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog commonOpenFileDialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true
            };
            CommonFileDialogCheckBox checkBox = new CommonFileDialogCheckBox
            {
                Text = Player.GetString("IncludingSubDir")
            };
            commonOpenFileDialog.Controls.Add(checkBox);
            if (commonOpenFileDialog.ShowDialog() == CommonFileDialogResult.Ok && commonOpenFileDialog.FileName != null)
            {
                PlaylistHelper.ActivePlaylist.Items.Clear();
                string[] supportedExtensions = Player.Core.GetAllSupportedFileArray();
                IEnumerable<string> files = Utils.SearchFiles(commonOpenFileDialog.FileName, supportedExtensions, checkBox.IsChecked);
                foreach (string file in files)
                {
                    PlaylistHelper.ActivePlaylist.Items.Add(PlaylistItem.FormFile(file));
                }
                NativeAPI.SendMessage(playlistEditorForm.Handle, Player.WM_REFRESHPLAYLISTVIEW, 0, 0);
                if (files.Any())
                    Play(0);
            }
        }

        private void tsmiAddURL_Click(object sender, EventArgs e)
        {

        }

        private void tsmiAlbumPictureForm_Click(object sender, EventArgs e)
        {
            if (albumPictureForm.Visible)
            {
                albumPictureForm.Hide();
            }
            else
            {
                albumPictureForm.Show();
            }
        }
        #endregion
    }
}