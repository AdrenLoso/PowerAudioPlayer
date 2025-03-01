using BrightIdeasSoftware;
using PowerAudioPlayer.Controllers;
using PowerAudioPlayer.Controllers.Helper;
using PowerAudioPlayer.Controllers.Utils;
using PowerAudioPlayer.Model;
using System.ComponentModel;
using System.IO;

namespace PowerAudioPlayer.UI.CustomControls
{
    public partial class PlayHistoryEditor : UserControl
    {
        private readonly OLVColumn olvColumn1 = new OLVColumn(Player.GetString("LastPlaybackTime"), "LastPlaybackTime") { Width = 130, MinimumWidth = 10 };
        private readonly OLVColumn olvColumn2 = new OLVColumn(Player.GetString("PlayCount"), "PlayCount") { Width = 70, MinimumWidth = 10 };
        private readonly OLVColumn olvColumn3 = new OLVColumn(Player.GetString("DisplayTitle"), "DisplayTitle") { Width = 430, MinimumWidth = 20 };
        private readonly OLVColumn olvColumn4 = new OLVColumn(Player.GetString("Length"), "Length") { Width = 70, MinimumWidth = 10, AspectGetter = delegate (object rowObject) { return TimeFormatter.Format(((PlayHistoryItem)rowObject).Length); } };
        private readonly OLVColumn olvColumn5 = new OLVColumn(Player.GetString("FileName"), "File") { Width = 430, MinimumWidth = 20, AspectGetter = delegate (object rowObject) { return Path.GetFileName(((PlayHistoryItem)rowObject).File); } };

        public event EventHandler? PlayItem;
        public event EventHandler? LineUpItem;

        [Browsable(false)]
        public IList<PlayHistoryItem> SelectedItems { get => lvHistory.SelectedObjects.Cast<PlayHistoryItem>().ToList(); }

        [Browsable(false)]
        public PlayHistoryItem SelectedItem { get => (PlayHistoryItem)lvHistory.SelectedObject; }

        [Browsable(false)]
        public IList<PlaylistItem> SelectedItemsV2 { get => ItemConvertHelper.ConvertPlayHistoryItemListToPlaylistItemList(lvHistory.SelectedObjects.Cast<PlayHistoryItem>().ToList()); }

        [Browsable(false)]
        public PlaylistItem SelectedItemV2 { get => ItemConvertHelper.ConvertPlayHistoryItemToPlaylistItem((PlayHistoryItem)lvHistory.SelectedObject); }

        public PlayHistoryEditor()
        {
            InitializeComponent();
            lvHistory.Columns.AddRange([olvColumn1, olvColumn2, olvColumn3, olvColumn4, olvColumn5]);
            lvHistory.SetObjects(PlayHistoryHelper.History.Values);
            lvHistory.Sort(olvColumn1, SortOrder.Descending);
            RefreshStatus();
        }

        public void RefreshItem()
        {
            lvHistory.SetObjects(PlayHistoryHelper.History.Values);
            RefreshStatus();
        }

        private void lvHistory_DoubleClick(object sender, EventArgs e)
        {
            if (lvHistory.SelectedIndex != -1)
                PlayItem?.Invoke(sender, e);
        }

        private void tsmiFileInfo_Click(object sender, EventArgs e)
        {
            if (lvHistory.SelectedIndex != -1)
                new InformationForm() { Tag = SelectedItem.File }.ShowDialog();
        }

        private void tsmiExplorer_Click(object sender, EventArgs e)
        {
            if (lvHistory.SelectedIndex != -1)
                MiscUtils.ExploreFile(SelectedItem.File);
        }

        private void tsmiRemove_Click(object sender, EventArgs e)
        {
            foreach (var item in SelectedItems)
            {
                PlayHistoryHelper.Remove(item.File);
            }
            RefreshItem();
        }

        private void tsmiClear_Click(object sender, EventArgs e)
        {
            PlayHistoryHelper.ClearHistory();
            RefreshItem();
        }

        private void tsmiLineUp_Click(object sender, EventArgs e)
        {
            if (lvHistory.SelectedIndex != -1)
                LineUpItem?.Invoke(sender, e);
        }

        private void lvHistory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                tsmiRemove_Click(sender, new());
            }
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (lvHistory.SelectedObjects.Count > 1)
            {
                tsmiFileInfo.Enabled = false;
                tsmiExplorer.Enabled = false;
            }
            tsmiSelectedCount.Text = Player.GetString("SelectedCount", lvHistory.SelectedObjects.Count.ToString());
        }

        public void RefreshStatus()
        {
            try
            {
                lblItemTotalCount.Text = PlayHistoryHelper.Count.ToString();
                lblTotalPlayTime.Text = TimeFormatter.Format(PlayHistoryHelper.TotalLengthWithTimesPlayed, TimeUnit.Seconds, @"hh\:mm\:ss");
                lblTotalPlayTimesCount.Text = PlayHistoryHelper.TotalPlayTimesCount.ToString();
                
            }
            catch
            {
                lblItemTotalCount.Text = "0";
                lblTotalPlayTimesCount.Text = "0";
                lblTotalPlayTimesCount.Text = "00:00";
            }
        }
    }
}