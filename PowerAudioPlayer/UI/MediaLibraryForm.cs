using Microsoft.VisualBasic;
using PowerAudioPlayer.Controllers;
using PowerAudioPlayer.Controllers.Helper;
using PowerAudioPlayer.Model;
using System.ComponentModel;
using WinFormsExtendedControls.ExtendedForms;

namespace PowerAudioPlayer.UI
{
    public partial class MediaLibraryForm : Form
    {
        private readonly WindowStateManager windowStateManager;
        private DoWorkEventHandler doWorkEvent = (object? sender, DoWorkEventArgs e) => { };
        private bool isUpdatingMediaLibrary = false;

        public MediaLibraryForm()
        {
            InitializeComponent();
            RefreshPlaylistList();
            windowStateManager = new WindowStateManager(this);
            windowStateManager.LoadState();
            lblWelcome.Text = Player.GetString("MsgWelcomeMediaLibrary");
            lblWelcome.BringToFront();
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case Player.WM_UPDATEMEDIALIBRARY:
                    UpdateMediaLibrary();
                    break;
                case Player.WM_REFRESHHISTORYVIEW:
                    playHistoryEditor.RefreshItem();
                    break;
            }
            base.WndProc(ref m);
        }

        private void UpdateMediaLibrary()
        {
            if (!isUpdatingMediaLibrary)
            {
                isUpdatingMediaLibrary = true;
                doWorkEvent = (object? sender, DoWorkEventArgs e) =>
                {
                    var progressDialog = new ProgressDialog() { Marquee = true, ShowTimeRemaining = false, Title = Player.GetString("Working"), CancelButton = false };
                    progressDialog.Show();
                    progressDialog.Line1 = Player.GetString("MsgMsgUpdateMediaLibrary");
                    MediaLibraryHelper.UpdateMediaLibrary();
                    progressDialog.Close();
                };
                backgroundWorker.DoWork += doWorkEvent;
                backgroundWorker.RunWorkerAsync();
                mediaLibraryEditor.Enabled = false;
            }
        }

        private void RefreshPlaylistList()
        {
            tvTreeView.Nodes[1].Nodes.Clear();
            for (int i = 0; i < PlaylistHelper.Count; i++)
            {
                if (PlaylistHelper.Playlists[i].IsActive)
                    continue;
                TreeNode node = new TreeNode(PlaylistHelper.Playlists[i].Name);
                node.Tag = i;
                tvTreeView.Nodes[1].Nodes.Add(node);
            }
        }

        private void EditPlaylist(int index = -1)
        {
            if (index == -1) return;
            playlistEditor.EditPlaylistIndex = index;
            playlistEditor.BringToFront();
        }

        private void tvTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (playlistEditor.IsWorking)
            {
                if(MessageBox.Show(Player.GetString("MsgCancelTip"), Application.ProductName ?? string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }
            if (e.Button == MouseButtons.Left)
            {
                tvTreeView.SelectedNode = e.Node;
                if (e.Node.Level == 1)
                {
                    if (e.Node.Parent?.Name == "nodePlaylist")
                    {
                        EditPlaylist(Convert.ToInt32(e.Node.Tag));
                    }
                    else if (e.Node.Parent?.Name == "nodeMedia")
                    {
                        mediaLibraryEditor.BringToFront();
                        mediaLibraryEditor.SetMode(false, Enum.Parse<ViewType>((string?)e.Node.Tag ?? string.Empty));
                    }
                }
                else
                {
                    if (e.Node.Name == "nodeMedia")
                    {
                        mediaLibraryEditor.BringToFront();
                        mediaLibraryEditor.SetMode(true);
                    }
                    else if (e.Node.Name == "nodePlayHistory")
                    {
                        playHistoryEditor.BringToFront();
                    }
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                Point ClickPoint = new Point(e.X, e.Y);
                TreeNode? CurrentNode = tvTreeView.GetNodeAt(ClickPoint);
                if (CurrentNode != null)
                {
                    tvTreeView.SelectedNode = CurrentNode;
                }
                if (e.Node.Level == 1 && e.Node.Parent?.Name == "nodePlaylist")
                {
                    if (e.Node.Tag != null)
                    {
                        e.Node.ContextMenuStrip = cmsPlaylistNode;
                    }
                }
            }
        }

        private void playlistEditor_PlayItem(object sender, EventArgs e)
        {
            if (Owner != null)
            {
                PlaylistHelper.CopyToActivePlaylist(playlistEditor.EditPlaylistIndex);
                NativeAPI.SendMessage(Owner.Handle, Player.WM_PLAY, PlaylistHelper.Playlists[playlistEditor.EditPlaylistIndex].Items.IndexOf(playlistEditor.SelectedItem), 1);
                NativeAPI.SendMessage(Owner.Handle, Player.WM_LOCATETO, 0, 0);
            }
        }

        private void playlistEditor_LineUpItem(object sender, EventArgs e)
        {
            if (Owner != null)
            {
                PlaylistHelper.ActivePlaylist.Items.AddRange(playlistEditor.SelectedItems);
                NativeAPI.SendMessage(Owner.Handle, Player.WM_REFRESHPLAYLISTVIEW, 0, 0);
            }
        }

        private void tsmiNewPlaylist_Click(object sender, EventArgs e)
        {
            var ib = new WinFormsExtendedControls.ExtendedForms.InputDialog { WindowTitle = Application.ProductName ?? string.Empty, MainInstruction = Player.GetString("MsgAddPlaylist") };
            if (ib.ShowDialog() == DialogResult.OK && ib.Input != "")
            {
                if (PlaylistHelper.Add(new Playlist(ib.Input)) != -1)
                    RefreshPlaylistList();
                else
                    MessageBox.Show(Player.GetString("MsgListNameInvaildate"), null, 0, MessageBoxIcon.Error);
            }
        }

        private void tsmiRenamePlaylist_Click(object sender, EventArgs e)
        {
            TreeNode? node = tvTreeView.SelectedNode;
            if (node == null) return;
            int playlistIndex = Convert.ToInt32(node.Tag);
            if (node.Parent?.Name == "nodePlaylist" || node.Level == 1)
            {
                var ib = new WinFormsExtendedControls.ExtendedForms.InputDialog { WindowTitle = Application.ProductName ?? string.Empty, MainInstruction = Player.GetString("MsgRenamePlaylist", PlaylistHelper.Playlists[playlistIndex].Name) };
                if (ib.ShowDialog() == DialogResult.OK && ib.Input != "")
                {
                    if (PlaylistHelper.Rename(ib.Input, playlistIndex))
                        RefreshPlaylistList();
                    else
                        MessageBox.Show(Player.GetString("MsgListNameInvaildate"), null, 0, MessageBoxIcon.Error);
                }
            }
        }
        private void tsmiRemovePlaylist_Click(object sender, EventArgs e)
        {
            TreeNode? node = tvTreeView.SelectedNode;
            if (node == null) return;
            int playlistIndex = Convert.ToInt32(node.Tag);
            if (node.Parent?.Name == "nodePlaylist" || node.Level == 1)
            {
                if (playlistIndex == playlistEditor.EditPlaylistIndex)
                {
                    playlistEditor.EditPlaylistIndex = 0;
                    lblWelcome.BringToFront();
                }
                PlaylistHelper.Remove(playlistIndex);
                RefreshPlaylistList();
            }
        }

        private void tsmiPlayPlaylist_Click(object sender, EventArgs e)
        {
            TreeNode? node = tvTreeView.SelectedNode;
            if (node == null) return;
            int playlistIndex = Convert.ToInt32(node.Tag);
            if ((node.Parent?.Name == "nodePlaylist" || node.Level == 1) && Owner != null)
            {
                PlaylistHelper.CopyToActivePlaylist(playlistIndex);
                NativeAPI.SendMessage(Owner.Handle, Player.WM_PLAY, 0, 1);
                NativeAPI.SendMessage(Owner.Handle, Player.WM_LOCATETO, 0, 0);
            }
        }

        private void tsmiLineUpPlaylist_Click(object sender, EventArgs e)
        {
            TreeNode? node = tvTreeView.SelectedNode;
            if (node == null) return;
            int playlistIndex = Convert.ToInt32(node.Tag);
            if ((node.Parent?.Name == "nodePlaylist" || node.Level == 1) && Owner != null)
            {
                PlaylistHelper.ActivePlaylist.Items.AddRange(PlaylistHelper.Playlists[playlistIndex].Items);
                NativeAPI.SendMessage(Owner.Handle, Player.WM_REFRESHPLAYLISTVIEW, 0, 0);
            }
        }

        private void tsmiImportActivePlaylist_Click(object sender, EventArgs e)
        {
            if (PlaylistHelper.ActivePlaylist.Count != 0)
            {
                var ib = new InputDialog { WindowTitle = Application.ProductName ?? string.Empty, MainInstruction = Player.GetString("MsgAddPlaylist") };
                if (ib.ShowDialog() == DialogResult.OK && ib.Input != "")
                {
                    if (PlaylistHelper.Add(new Playlist(ib.Input) { Items = PlaylistHelper.ActivePlaylist.Items }) != -1)
                    {
                        RefreshPlaylistList();
                    }
                    else
                    {
                        MessageBox.Show(Player.GetString("MsgListNameInvaildate"), null, 0, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void tsmiSendPlToMediaLibrary_Click(object sender, EventArgs e)
        {
            TreeNode? node = tvTreeView.SelectedNode;
            if (node == null) return;
            int playlistIndex = Convert.ToInt32(node.Tag);
            if (node.Parent?.Name == "nodePlaylist" || node.Level == 1)
            {
                foreach (var item in PlaylistHelper.Playlists[playlistIndex].Items)
                {
                    MediaLibraryHelper.Add(item.File);
                }
            }
        }

        private void MediaLibraryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                windowStateManager.SaveState();
            Hide();
            e.Cancel = true;
        }

        private void mediaLibraryEditor_LineUpItem(object sender, EventArgs e)
        {
            if (mediaLibraryEditor.SelectedItems.Count != 0 && Owner != null)
            {
                PlaylistHelper.ActivePlaylist.Items.AddRange(ItemConvertHelper.ConvertAudioInfoListToPlaylistItemList(mediaLibraryEditor.SelectedItems.ToList()));
                NativeAPI.SendMessage(Owner.Handle, Player.WM_REFRESHPLAYLISTVIEW, 0, 0);
            }
        }

        private void mediaLibraryEditor_LineUpKeyWord(object sender, EventArgs e)
        {
            if (mediaLibraryEditor.Result.Count != 0 && !mediaLibraryEditor.AllMode && Owner != null)
            {
                PlaylistHelper.ActivePlaylist.Items.AddRange(ItemConvertHelper.ConvertAudioInfoListToPlaylistItemList(mediaLibraryEditor.Result.Values.ToList()));
                NativeAPI.SendMessage(Owner.Handle, Player.WM_REFRESHPLAYLISTVIEW, 0, 0);
            }
        }

        private void mediaLibraryEditor_PlayItem(object sender, EventArgs e)
        {
            if (mediaLibraryEditor.AllMode)
            {
                PlaylistHelper.CopyToActivePlaylist(MediaLibraryHelper.Library.Values.Select(x => new PlaylistItem(x.File, AudioInfoHelper.GetDisplayTitle(x), x.Length)).ToList());
            }
            else
            {
                PlaylistHelper.CopyToActivePlaylist(ItemConvertHelper.ConvertMediaLibraryItemListToPlaylistItemList(mediaLibraryEditor.Result));
            }
            if (Owner != null)
            {
                NativeAPI.SendMessage(Owner.Handle, Player.WM_PLAY, PlaylistHelper.ActivePlaylist.Items.FindIndex(x => x.File.Equals(mediaLibraryEditor.SelectedItem.File, StringComparison.Ordinal)), 1);
                NativeAPI.SendMessage(Owner.Handle, Player.WM_LOCATETO, 0, 0);
            }
        }

        private void mediaLibraryEditor_PlayKeyWord(object sender, EventArgs e)
        {
            PlaylistHelper.CopyToActivePlaylist(ItemConvertHelper.ConvertMediaLibraryItemListToPlaylistItemList(mediaLibraryEditor.Result));
            if (Owner != null)
            {
                NativeAPI.SendMessage(Owner.Handle, Player.WM_PLAY, 0, 1);
                NativeAPI.SendMessage(Owner.Handle, Player.WM_LOCATETO, 0, 0);
            }
        }

        private void mediaLibraryEditor_SendToNewPlaylistItem(object sender, EventArgs e)
        {
            RefreshPlaylistList();
        }

        private void mediaLibraryEditor_SendToNewPlaylistKeyWord(object sender, EventArgs e)
        {
            RefreshPlaylistList();
        }

        private void playHistoryEditor_PlayItem(object sender, EventArgs e)
        {
            PlaylistHelper.CopyToActivePlaylist(ItemConvertHelper.ConvertPlayHistoryItemListToPlaylistItemList(PlayHistoryHelper.History.Values.ToList()));
            if (Owner != null)
            {
                NativeAPI.SendMessage(Owner.Handle, Player.WM_PLAY, PlaylistHelper.ActivePlaylist.Items.FindIndex(x => x.File.Equals(playHistoryEditor.SelectedItemV2.File, StringComparison.Ordinal)), 1);
            }
        }

        private void playHistoryEditor_LineUpItem(object sender, EventArgs e)
        {
            if (playHistoryEditor.SelectedItems.Count != 0 && Owner != null)
            {
                PlaylistHelper.ActivePlaylist.Items.AddRange(playHistoryEditor.SelectedItemsV2);
                NativeAPI.SendMessage(Owner.Handle, Player.WM_REFRESHPLAYLISTVIEW, 0, 0);
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            mediaLibraryEditor.Enabled = true;
            isUpdatingMediaLibrary = false;
        }

        private void tvTreeView_KeyDown(object sender, KeyEventArgs e)
        {
            if (tvTreeView.SelectedNode != null && tvTreeView.SelectedNode.Level == 1 && tvTreeView.SelectedNode.Parent?.Name == "nodePlaylist")
            {
                if (e.KeyCode == Keys.F2)
                    tsmiRenamePlaylist_Click(sender, new());
                else if (e.KeyCode == Keys.Delete)
                    tsmiRemovePlaylist_Click(sender, new());
            }
        }
    }
}