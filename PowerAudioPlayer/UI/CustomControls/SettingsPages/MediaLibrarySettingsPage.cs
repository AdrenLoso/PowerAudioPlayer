﻿using BrightIdeasSoftware;
using Microsoft.WindowsAPICodePack.Dialogs.Controls;
using Microsoft.WindowsAPICodePack.Dialogs;
using PowerAudioPlayer.Controllers;
using PowerAudioPlayer.Controllers.Helper;
using System.ComponentModel;
using PowerAudioPlayer.Controllers.Utils;

namespace PowerAudioPlayer.UI.CustomControls.SettingsPages
{
    public partial class MediaLibrarySettingsPage : UserControl
    {
        OLVColumn olvColumn1 = new OLVColumn(Player.GetString("Directory"), "Directory");
        OLVColumn olvColumn2 = new OLVColumn(Player.GetString("Action"), "") { ButtonSizing = OLVColumn.ButtonSizingMode.CellBounds, IsButton = true, AspectGetter = delegate (object rowObject) { return Player.GetString("Delete"); } };

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Form? Owner
        {
            get; set;
        }

        public MediaLibrarySettingsPage()
        {
            InitializeComponent();

            cbMediaLibraryAutoRemove.DataBindings.Add("Checked", Settings.Default, "MediaLibraryAutoRemove", true, DataSourceUpdateMode.OnPropertyChanged);
            cbMediaLibraryStartUpRefresh.DataBindings.Add("Checked", Settings.Default, "MediaLibraryStartUpUpdate", true, DataSourceUpdateMode.OnPropertyChanged);
            cbPlaylistEditorShowFileNameColumn.DataBindings.Add("Checked", Settings.Default, "PlaylistEditorShowFileNameColumn", true, DataSourceUpdateMode.OnPropertyChanged);
            cbRecordPlayHistroy.DataBindings.Add("Checked", Settings.Default, "RecordPlayHistroy", true, DataSourceUpdateMode.OnPropertyChanged);


            lvMediaLibraryDirs.Columns.AddRange([olvColumn1, olvColumn2]);
            if (!MiscUtils.IsDesignMode())
                lvMediaLibraryDirs.SetObjects(Settings.Default.MediaLibraryDirectories);
        }

        private void btnAddDir_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog commonOpenFileDialog = new CommonOpenFileDialog();
            CommonFileDialogCheckBox checkBox = new CommonFileDialogCheckBox();
            checkBox.Text = Player.GetString("IncludingSubDir");
            commonOpenFileDialog.Controls.Add(checkBox);
            commonOpenFileDialog.IsFolderPicker = true;
            if (commonOpenFileDialog.ShowDialog() == CommonFileDialogResult.Ok && commonOpenFileDialog.FileName != null)
            {
                if (!Settings.Default.MediaLibraryDirectories.Exists(x => x.Directory.Equals(commonOpenFileDialog.FileName)))
                    Settings.Default.MediaLibraryDirectories.Add(new MediaLibraryDirectory(commonOpenFileDialog.FileName));
                lvMediaLibraryDirs.SetObjects(Settings.Default.MediaLibraryDirectories);
            }
        }

        private void lvMediaLibraryDirs_ButtonClick(object sender, CellClickEventArgs e)
        {
            Settings.Default.MediaLibraryDirectories.Remove((MediaLibraryDirectory)e.Model);
            lvMediaLibraryDirs.SetObjects(Settings.Default.MediaLibraryDirectories);
        }

        private void btnRefreshMediaLibrary_Click(object sender, EventArgs e)
        {
            if (Owner != null)
                NativeAPI.SendMessage(Owner.Handle, Player.WM_UPDATEMEDIALIBRARY, 0, 0);
        }

        private void btnCleanUpMediaLibrary_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Player.GetString("MsgCleanUpMediaLibrary"), Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int removeCount = MediaLibraryHelper.CleanUpMediaLibrary();
                MessageBox.Show(Player.GetString("MsgCleanUpMediaLibraryOK", removeCount), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSaveMediaLibrary_Click(object sender, EventArgs e)
        {
            MediaLibraryHelper.SaveMediaLibrary();
        }

        private void btnClearMediaLibrary_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Player.GetString("MsgClearMediaLibrary"), Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                MediaLibraryHelper.ClearMediaLibrary();
            }
        }

        private void cbRecordPlayHistroy_CheckedChanged(object sender, EventArgs e)
        {
            //if(!cbRecordPlayHistroy.Checked && PlayHistoryHelper.Count > 0)
            //{
            //    DialogResult result = MessageBox.Show(Player.GetString("MsgClearPlayHistory"), Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            //    if (result == DialogResult.Yes)
            //    {
            //        PlayHistoryHelper.ClearHistory();
            //    }
            //    else if (result == DialogResult.Cancel)
            //    {
            //        cbRecordPlayHistroy.Checked = true;
            //    }
            //}
        }
    }
}