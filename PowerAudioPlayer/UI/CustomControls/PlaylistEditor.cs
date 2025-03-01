using BrightIdeasSoftware;
using Microsoft.WindowsAPICodePack.Dialogs.Controls;
using Microsoft.WindowsAPICodePack.Dialogs;
using PowerAudioPlayer.Controllers;
using PowerAudioPlayer.Model;
using System.ComponentModel;
using System.IO;
using PowerAudioPlayer.Controllers.Helper;
using WinFormsExtendedControls.ExtendedForms;
using PowerAudioPlayer.Controllers.Utils;

namespace PowerAudioPlayer.UI.CustomControls
{
    public partial class PlaylistEditor : UserControl
    {
        private readonly OLVColumn olvColumn1 = new OLVColumn(Player.GetString("DisplayTitle"), "DisplayTitle") { Width = 430, MinimumWidth = 20 };
        private readonly OLVColumn olvColumn2 = new OLVColumn(Player.GetString("Length"), "Length") { Width = 70, MinimumWidth = 10, AspectGetter = delegate (object rowObject) { return TimeFormatter.Format(((PlaylistItem)rowObject).Length); } };
        private readonly OLVColumn olvColumn3 = new OLVColumn(Player.GetString("FileName"), "File") { Width = 420, MinimumWidth = 20, AspectGetter = delegate (object rowObject) { return Path.GetFileName(((PlaylistItem)rowObject).File); } };
        private DoWorkEventHandler doWorkEvent = (object? sender, DoWorkEventArgs e) => { };
        private int workingPlaylistIndex = -1;
        public event EventHandler? PlayItem;
        public event EventHandler? LineUpItem;
        public event EventHandler? WorkStart;
        public event EventHandler? WorkComplete;

        public new bool DesignMode
        {
            get => MiscUtils.IsDesignMode();
        }

        private bool _isEditActivePlaylist = false;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsEditActivePlaylist
        {
            get
            {
                return _isEditActivePlaylist;
            }
            set
            {
                tsmiImportFormActivePlaylist.Visible = !value;
                tsmiSendTo.Visible = !value;
                tsmiSendToMediaLibrary1.Visible = !value;
                tsmilu1.Visible = !value;
                tsmPlay.Visible = !value;
                _isEditActivePlaylist = value;
                if (value)
                    _editPlaylistIndex = PlaylistHelper.ActivePlaylistIndex;
                RefreshStatus();
            }
        }

        private int _editPlaylistIndex = 0;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int EditPlaylistIndex
        {
            get { return _editPlaylistIndex; }
            set
            {
                _editPlaylistIndex = value;
                if (DesignMode)
                {
                    lvPlaylist.SetObjects(null);
                }
                else
                {
                    RefreshItems();
                }
            }
        }

        public bool IsWorking 
        {
            get => backgroundWorker.IsBusy;
        }

        [Browsable(false)]
        public IList<PlaylistItem> SelectedItems { get => lvPlaylist.SelectedObjects.Cast<PlaylistItem>().ToList(); }

        [Browsable(false)]
        public PlaylistItem SelectedItem { get => (PlaylistItem)lvPlaylist.SelectedObject; }

        public PlaylistEditor()
        {
            InitializeComponent();
            if (Settings.Default.PlaylistEditorShowFileNameColumn)
                lvPlaylist.Columns.AddRange([olvColumn1, olvColumn2, olvColumn3]);
            else
                lvPlaylist.Columns.AddRange([olvColumn1, olvColumn2]);
            TextOverlay? textOverlay = lvPlaylist.EmptyListMsgOverlay as TextOverlay;
            if (textOverlay != null)
            {
                textOverlay.BackColor = BackColor;
                textOverlay.TextColor = ForeColor;
                textOverlay.Font = Font;
                textOverlay.BorderColor = Color.Empty;
                textOverlay.BorderWidth = 0;
                textOverlay.CornerRounding = 0;
            }
            if (!DesignMode)
            {
                lvPlaylist.SetObjects(PlaylistHelper.Playlists[_editPlaylistIndex].Items);
            }
        }

        public void RefreshItems()
        {
            if (backgroundWorker.IsBusy)
            {
                backgroundWorker.CancelAsync();
            }
            lvPlaylist.AdditionalFilter = null;
            sbFilter.Text = string.Empty;
            lvPlaylist.SetObjects(PlaylistHelper.Playlists[_editPlaylistIndex].Items);
            lvPlaylist.Refresh();
            RefreshStatus();

        }

        public void RefreshStatus()
        {
            try
            {
                lblTotalCount.Text = PlaylistHelper.Playlists[_editPlaylistIndex].Count.ToString();
                lblTotalLength.Text = TimeFormatter.Format(PlaylistHelper.Playlists[_editPlaylistIndex].TotalLength, TimeUnit.Seconds, @"hh\:mm\:ss");
            }
            catch
            {
                lblTotalCount.Text = "0";
                lblTotalLength.Text = "0";
            }
        }

        public void EnsureVisible(int index)
        {
            if (index != -1)
            {
                lvPlaylist.EnsureVisible(index);
            }
        }

        public void EnsureVisible(PlaylistItem item)
        {
            lvPlaylist.SelectedObject = item;
        }

        private void EnableControls(bool enable)
        {
            lvPlaylist.Enabled = enable;
            msPl.Enabled = enable;
            sbFilter.Enabled = enable;
        }

        private void lvPlaylist_DoubleClick(object sender, EventArgs e)
        {
            PlayItem?.Invoke(this, e);
        }

        private void tsmiPlay_Click(object sender, EventArgs e)
        {
            PlayItem?.Invoke(this, e);
        }

        private void tsmilu_Click(object sender, EventArgs e)
        {
            LineUpItem?.Invoke(this, e);
        }

        private void tsmiSendToMediaLibrary_Click(object sender, EventArgs e)
        {
            foreach (PlaylistItem item in lvPlaylist.SelectedObjects)
            {
                MediaLibraryHelper.Add(item.File);
            }
        }

        private void tsmiAddFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = Player.Core.GetAllSupportedFileFilter(Player.GetString("AllSupportedFileFilter"), Player.GetString("AllFiles"));
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                doWorkEvent = (object? sender, DoWorkEventArgs e) =>
                {
                    if (e.Argument != null)
                    {
                        string[] files = (string[])e.Argument;
                        var progressDialog = new ProgressDialog() { ShowTimeRemaining = true, Title = Player.GetString("Working"), CancelButton = true };
                        progressDialog.Show();
                        progressDialog.Line1 = Player.GetString("MsgAddingFiles");
                        progressDialog.Maximum = files.Length;
                        foreach (string file in files)
                        {
                            if (backgroundWorker.CancellationPending || progressDialog.HasUserCancelled)
                            {
                                break;
                            }
                            PlaylistHelper.Playlists[workingPlaylistIndex].Add(file);
                            progressDialog.Line2 = Path.GetFileName(file);
                            progressDialog.Value++;
                        }
                    }
                };
                backgroundWorker.DoWork += doWorkEvent;
                workingPlaylistIndex = _editPlaylistIndex;
                backgroundWorker.RunWorkerAsync(openFileDialog.FileNames);
                EnableControls(false);
                WorkStart?.Invoke(this, e);
            }
        }

        private void tsmiAddFolder_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog commonOpenFileDialog = new CommonOpenFileDialog();
            CommonFileDialogCheckBox checkBox = new CommonFileDialogCheckBox();
            checkBox.Text = Player.GetString("IncludingSubDir");
            commonOpenFileDialog.Controls.Add(checkBox);
            commonOpenFileDialog.IsFolderPicker = true;
            if (commonOpenFileDialog.ShowDialog() == CommonFileDialogResult.Ok && commonOpenFileDialog.FileName != null)
            {
                doWorkEvent = (object? sender, DoWorkEventArgs e) =>
                {
                    if (e.Argument != null)
                    {
                        var progressDialog = new ProgressDialog() {ShowTimeRemaining = false, Title = Player.GetString("Working"), Marquee = true, CancelButton = true };
                        progressDialog.Show();
                        progressDialog.Line1 = Player.GetString("MsgAddingFiles");
                        var args = (FileSearchArgs)e.Argument;
                        FileSearcher.SearchFiles(args.Directory, Player.Core.GetAllSupportedFileArray(), args.SearchSubDir, file =>
                        {
                            if (backgroundWorker.CancellationPending || progressDialog.HasUserCancelled)
                            {
                                return false;
                            }
                            progressDialog.Line2 = Path.GetFileName(file);
                            PlaylistHelper.Playlists[workingPlaylistIndex].Add(file);
                            return true;
                        });

                        progressDialog.Close();
                    }
                };
                backgroundWorker.DoWork += doWorkEvent;
                workingPlaylistIndex = _editPlaylistIndex;
                backgroundWorker.RunWorkerAsync(new FileSearchArgs(commonOpenFileDialog.FileName, checkBox.IsChecked));
                EnableControls(false);
                WorkStart?.Invoke(this, e);
            }
        }

        private void tsmiAddURL_Click(object sender, EventArgs e)
        {
            var ib = new InputDialog { WindowTitle = Application.ProductName ?? "", MainInstruction = Player.GetString("MsgAddURL") };
            if (ib.ShowDialog() == DialogResult.OK && ib.Input != "")
            {
                PlaylistHelper.Playlists[_editPlaylistIndex].Add(ib.Input);
                RefreshItems();
            }
        }

        private void tsmiRemoveSelected_Click(object sender, EventArgs e)
        {
            foreach (PlaylistItem item in lvPlaylist.SelectedObjects)
            {
                PlaylistHelper.Playlists[_editPlaylistIndex].Remove(item);
            }
            RefreshItems();
        }

        private void tsmiClear_Click(object sender, EventArgs e)
        {
            PlaylistHelper.Playlists[_editPlaylistIndex].Clear();
            RefreshItems();
        }

        private void tsmiKeep_Click(object sender, EventArgs e)
        {
            foreach (PlaylistItem item in PlaylistHelper.Playlists[_editPlaylistIndex].Items)
            {
                if (lvPlaylist.SelectedObjects.IndexOf(item) != -1)
                    continue;
                PlaylistHelper.Playlists[_editPlaylistIndex].Remove(item);
            }
            RefreshItems();
        }

        private void tsmiImportFromFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = Player.GetString("FilterPlaylist");
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                PlaylistHelper.ReplacePlaylist(openFileDialog.FileName, EditPlaylistIndex);
            }
            RefreshItems();
        }

        private void tsmiImportFormActivePlaylist_Click(object sender, EventArgs e)
        {
            PlaylistHelper.CopyToPlaylist(PlaylistHelper.ActivePlaylist.Items, _editPlaylistIndex);
            RefreshItems();
        }

        private void tsmiExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = Player.GetString("FilterPlaylist");
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                PlaylistHelper.SavePlaylist(saveFileDialog.FileName, EditPlaylistIndex);
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            WorkComplete?.Invoke(this, e);
            backgroundWorker.DoWork -= doWorkEvent;
            RefreshItems();
            EnableControls(true);
            workingPlaylistIndex = 0;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if(lvPlaylist.SelectedObjects.Count > 1)
            {
                tsmiFileInfo.Enabled = false;
                tsmiMediaExplorer.Enabled = false;
            }
            tsmiSelectedCount.Text = Player.GetString("SelectedCount", lvPlaylist.SelectedObjects.Count.ToString());
        }

        private void tsmiMediaExplorer_Click(object sender, EventArgs e)
        {
            if (lvPlaylist.SelectedObjects.Count > 0)
            {
                MiscUtils.ExploreFile(SelectedItem.File);
            }
        }

        private void tsmiFileInfo_Click(object sender, EventArgs e)
        {
            if (lvPlaylist.SelectedObjects.Count > 0)
            {
                new InformationForm() { Tag = SelectedItem.File }.ShowDialog();
            }
        }

        private void PlaylistEditor_DragDrop(object sender, DragEventArgs e)
        {
            string[]? files = (string[]?)e.Data?.GetData(DataFormats.FileDrop, false);
            if (files != null)
            {
                string[]? allFileFilter = Player.Core.GetAllSupportedFileArray();
                List<PlaylistItem> items = new List<PlaylistItem>();
                foreach (var file in files)
                {
                    string ext = Path.GetExtension(file).ToLower();
                    if (allFileFilter.Contains("*" + ext))
                    {
                        items.Add(PlaylistItem.FormFile(file));
                    }
                }
                if (items.Count > 0)
                {
                    PlaylistHelper.Playlists[_editPlaylistIndex].Items.AddRange(items);
                    RefreshItems();
                }
            }
        }

        private void PlaylistEditor_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void lvPlaylist_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                tsmiRemoveSelected_Click(sender, e);
            }
        }

        private void sbFilter_SearchStart(object sender, EventArgs e)
        {
            TextMatchFilter? filter = null;
            if (!string.IsNullOrEmpty(sbFilter.Text))
            {
                filter = TextMatchFilter.Contains(lvPlaylist, sbFilter.Text);
                lvPlaylist.DefaultRenderer ??= new HighlightTextRenderer(filter);

            }
            lvPlaylist.AdditionalFilter = filter;


        }
    }
}