namespace PowerAudioPlayer.UI.CustomControls
{
    partial class PlaylistEditor
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            backgroundWorker = new System.ComponentModel.BackgroundWorker();
            msPl = new MenuStrip();
            tsmPlay = new ToolStripMenuItem();
            tsmiPlay = new ToolStripMenuItem();
            tsmilu = new ToolStripMenuItem();
            tsmiSendTo = new ToolStripMenuItem();
            tsmiSendToMediaLibrary = new ToolStripMenuItem();
            tsmiAdd = new ToolStripMenuItem();
            tsmiAddFile = new ToolStripMenuItem();
            tsmiAddFolder = new ToolStripMenuItem();
            tsmiAddURL = new ToolStripMenuItem();
            tsmiRemove = new ToolStripMenuItem();
            tsmiRemoveSelected = new ToolStripMenuItem();
            tsmiClear = new ToolStripMenuItem();
            tsmiKeep = new ToolStripMenuItem();
            tsmiPlaylist = new ToolStripMenuItem();
            tsmiImport = new ToolStripMenuItem();
            tsmiImportFromFile = new ToolStripMenuItem();
            tsmiImportFormActivePlaylist = new ToolStripMenuItem();
            tsmiExport = new ToolStripMenuItem();
            statusStrip = new StatusStrip();
            lblTotalCount = new ToolStripStatusLabel();
            lblTotalLength = new ToolStripStatusLabel();
            columnHeader3 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader1 = new ColumnHeader();
            lvPlaylist = new BrightIdeasSoftware.FastObjectListView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            tsmiSelectedCount = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            tsmiPlay1 = new ToolStripMenuItem();
            tsmilu1 = new ToolStripMenuItem();
            tsmiSendToMediaLibrary1 = new ToolStripMenuItem();
            tsmiMediaExplorer = new ToolStripMenuItem();
            tsmiFileInfo = new ToolStripMenuItem();
            tsmiRemoveSelected1 = new ToolStripMenuItem();
            sbFilter = new WinFormsExtendedControls.SearchBox();
            msPl.SuspendLayout();
            statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lvPlaylist).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // backgroundWorker
            // 
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
            // 
            // msPl
            // 
            msPl.Items.AddRange(new ToolStripItem[] { tsmPlay, tsmiSendTo, tsmiAdd, tsmiRemove, tsmiPlaylist });
            msPl.Location = new Point(0, 0);
            msPl.Name = "msPl";
            msPl.Padding = new Padding(6, 1, 0, 1);
            msPl.Size = new Size(560, 24);
            msPl.TabIndex = 32;
            msPl.Text = "menuStrip2";
            // 
            // tsmPlay
            // 
            tsmPlay.DropDownItems.AddRange(new ToolStripItem[] { tsmiPlay, tsmilu });
            tsmPlay.Image = Resources.Play;
            tsmPlay.Name = "tsmPlay";
            tsmPlay.Size = new Size(60, 22);
            tsmPlay.Text = "播放";
            // 
            // tsmiPlay
            // 
            tsmiPlay.Name = "tsmiPlay";
            tsmiPlay.Size = new Size(100, 22);
            tsmiPlay.Text = "播放";
            tsmiPlay.Click += tsmiPlay_Click;
            // 
            // tsmilu
            // 
            tsmilu.Name = "tsmilu";
            tsmilu.Size = new Size(100, 22);
            tsmilu.Text = "排队";
            tsmilu.Click += tsmilu_Click;
            // 
            // tsmiSendTo
            // 
            tsmiSendTo.DropDownItems.AddRange(new ToolStripItem[] { tsmiSendToMediaLibrary });
            tsmiSendTo.Name = "tsmiSendTo";
            tsmiSendTo.Size = new Size(56, 22);
            tsmiSendTo.Text = "发送到";
            // 
            // tsmiSendToMediaLibrary
            // 
            tsmiSendToMediaLibrary.Name = "tsmiSendToMediaLibrary";
            tsmiSendToMediaLibrary.Size = new Size(112, 22);
            tsmiSendToMediaLibrary.Text = "媒体库";
            tsmiSendToMediaLibrary.Click += tsmiSendToMediaLibrary_Click;
            // 
            // tsmiAdd
            // 
            tsmiAdd.DropDownItems.AddRange(new ToolStripItem[] { tsmiAddFile, tsmiAddFolder, tsmiAddURL });
            tsmiAdd.Image = Resources.Add;
            tsmiAdd.Name = "tsmiAdd";
            tsmiAdd.Size = new Size(60, 22);
            tsmiAdd.Text = "添加";
            // 
            // tsmiAddFile
            // 
            tsmiAddFile.Name = "tsmiAddFile";
            tsmiAddFile.Size = new Size(180, 22);
            tsmiAddFile.Text = "添加文件";
            tsmiAddFile.Click += tsmiAddFile_Click;
            // 
            // tsmiAddFolder
            // 
            tsmiAddFolder.Name = "tsmiAddFolder";
            tsmiAddFolder.Size = new Size(180, 22);
            tsmiAddFolder.Text = "添加文件夹";
            tsmiAddFolder.Click += tsmiAddFolder_Click;
            // 
            // tsmiAddURL
            // 
            tsmiAddURL.Name = "tsmiAddURL";
            tsmiAddURL.Size = new Size(180, 22);
            tsmiAddURL.Text = "添加URL";
            tsmiAddURL.Click += tsmiAddURL_Click;
            // 
            // tsmiRemove
            // 
            tsmiRemove.DropDownItems.AddRange(new ToolStripItem[] { tsmiRemoveSelected, tsmiClear, tsmiKeep });
            tsmiRemove.Image = Resources.Remove;
            tsmiRemove.Name = "tsmiRemove";
            tsmiRemove.Size = new Size(60, 22);
            tsmiRemove.Text = "移除";
            // 
            // tsmiRemoveSelected
            // 
            tsmiRemoveSelected.Name = "tsmiRemoveSelected";
            tsmiRemoveSelected.Size = new Size(148, 22);
            tsmiRemoveSelected.Text = "移除选中项目";
            tsmiRemoveSelected.Click += tsmiRemoveSelected_Click;
            // 
            // tsmiClear
            // 
            tsmiClear.Name = "tsmiClear";
            tsmiClear.Size = new Size(148, 22);
            tsmiClear.Text = "清空";
            tsmiClear.Click += tsmiClear_Click;
            // 
            // tsmiKeep
            // 
            tsmiKeep.Name = "tsmiKeep";
            tsmiKeep.Size = new Size(148, 22);
            tsmiKeep.Text = "保留选中项目";
            tsmiKeep.Click += tsmiKeep_Click;
            // 
            // tsmiPlaylist
            // 
            tsmiPlaylist.DropDownItems.AddRange(new ToolStripItem[] { tsmiImport, tsmiExport });
            tsmiPlaylist.Image = Resources.Playlist;
            tsmiPlaylist.Name = "tsmiPlaylist";
            tsmiPlaylist.Size = new Size(84, 22);
            tsmiPlaylist.Text = "播放列表";
            // 
            // tsmiImport
            // 
            tsmiImport.DropDownItems.AddRange(new ToolStripItem[] { tsmiImportFromFile, tsmiImportFormActivePlaylist });
            tsmiImport.Name = "tsmiImport";
            tsmiImport.Size = new Size(148, 22);
            tsmiImport.Text = "导入播放列表";
            // 
            // tsmiImportFromFile
            // 
            tsmiImportFromFile.Name = "tsmiImportFromFile";
            tsmiImportFromFile.Size = new Size(172, 22);
            tsmiImportFromFile.Text = "从文件";
            tsmiImportFromFile.Click += tsmiImportFromFile_Click;
            // 
            // tsmiImportFormActivePlaylist
            // 
            tsmiImportFormActivePlaylist.Name = "tsmiImportFormActivePlaylist";
            tsmiImportFormActivePlaylist.Size = new Size(172, 22);
            tsmiImportFormActivePlaylist.Text = "从活动的播放列表";
            tsmiImportFormActivePlaylist.Click += tsmiImportFormActivePlaylist_Click;
            // 
            // tsmiExport
            // 
            tsmiExport.Name = "tsmiExport";
            tsmiExport.Size = new Size(148, 22);
            tsmiExport.Text = "导出播放列表";
            tsmiExport.Click += tsmiExport_Click;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { lblTotalCount, lblTotalLength });
            statusStrip.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            statusStrip.Location = new Point(0, 510);
            statusStrip.Name = "statusStrip";
            statusStrip.ShowItemToolTips = true;
            statusStrip.Size = new Size(560, 26);
            statusStrip.SizingGrip = false;
            statusStrip.TabIndex = 30;
            statusStrip.Text = "statusStrip";
            // 
            // lblTotalCount
            // 
            lblTotalCount.Font = new Font("Microsoft YaHei UI", 9F);
            lblTotalCount.Name = "lblTotalCount";
            lblTotalCount.Size = new Size(15, 21);
            lblTotalCount.Text = "0";
            // 
            // lblTotalLength
            // 
            lblTotalLength.BorderSides = ToolStripStatusLabelBorderSides.Left;
            lblTotalLength.Font = new Font("Microsoft YaHei UI", 9F);
            lblTotalLength.Name = "lblTotalLength";
            lblTotalLength.Size = new Size(43, 21);
            lblTotalLength.Text = "00:00";
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "时间";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "显示标题";
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "#";
            // 
            // lvPlaylist
            // 
            lvPlaylist.ContextMenuStrip = contextMenuStrip1;
            lvPlaylist.Dock = DockStyle.Fill;
            lvPlaylist.EmptyListMsg = "无文件。使用菜单添加一些文件或将文件拖放到此处。";
            lvPlaylist.FullRowSelect = true;
            lvPlaylist.GridLines = true;
            lvPlaylist.Location = new Point(0, 54);
            lvPlaylist.Name = "lvPlaylist";
            lvPlaylist.OverlayText.Text = "";
            lvPlaylist.SelectColumnsOnRightClick = false;
            lvPlaylist.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            lvPlaylist.ShowCommandMenuOnRightClick = true;
            lvPlaylist.ShowGroups = false;
            lvPlaylist.Size = new Size(560, 456);
            lvPlaylist.TabIndex = 31;
            lvPlaylist.UseFiltering = true;
            lvPlaylist.View = View.Details;
            lvPlaylist.VirtualMode = true;
            lvPlaylist.DoubleClick += lvPlaylist_DoubleClick;
            lvPlaylist.KeyDown += lvPlaylist_KeyDown;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { tsmiSelectedCount, toolStripSeparator1, tsmiPlay1, tsmilu1, tsmiSendToMediaLibrary1, tsmiMediaExplorer, tsmiFileInfo, tsmiRemoveSelected1 });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(209, 164);
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            // 
            // tsmiSelectedCount
            // 
            tsmiSelectedCount.Enabled = false;
            tsmiSelectedCount.Name = "tsmiSelectedCount";
            tsmiSelectedCount.Size = new Size(208, 22);
            tsmiSelectedCount.Text = "toolStripMenuItem1";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(205, 6);
            // 
            // tsmiPlay1
            // 
            tsmiPlay1.Name = "tsmiPlay1";
            tsmiPlay1.Size = new Size(208, 22);
            tsmiPlay1.Text = "播放";
            tsmiPlay1.Click += tsmiPlay_Click;
            // 
            // tsmilu1
            // 
            tsmilu1.Name = "tsmilu1";
            tsmilu1.Size = new Size(208, 22);
            tsmilu1.Text = "排队";
            tsmilu1.Click += tsmilu_Click;
            // 
            // tsmiSendToMediaLibrary1
            // 
            tsmiSendToMediaLibrary1.Name = "tsmiSendToMediaLibrary1";
            tsmiSendToMediaLibrary1.Size = new Size(208, 22);
            tsmiSendToMediaLibrary1.Text = "发送到媒体库";
            tsmiSendToMediaLibrary1.Click += tsmiSendToMediaLibrary_Click;
            // 
            // tsmiMediaExplorer
            // 
            tsmiMediaExplorer.Name = "tsmiMediaExplorer";
            tsmiMediaExplorer.Size = new Size(208, 22);
            tsmiMediaExplorer.Text = "在文件资源管理器中查看";
            tsmiMediaExplorer.Click += tsmiMediaExplorer_Click;
            // 
            // tsmiFileInfo
            // 
            tsmiFileInfo.Name = "tsmiFileInfo";
            tsmiFileInfo.Size = new Size(208, 22);
            tsmiFileInfo.Text = "查看文件信息";
            tsmiFileInfo.Click += tsmiFileInfo_Click;
            // 
            // tsmiRemoveSelected1
            // 
            tsmiRemoveSelected1.Image = Resources.Remove;
            tsmiRemoveSelected1.Name = "tsmiRemoveSelected1";
            tsmiRemoveSelected1.Size = new Size(208, 22);
            tsmiRemoveSelected1.Text = "移除选中项目";
            tsmiRemoveSelected1.Click += tsmiRemoveSelected_Click;
            // 
            // sbFilter
            // 
            sbFilter.Dock = DockStyle.Top;
            sbFilter.Location = new Point(0, 24);
            sbFilter.MaxLength = 32767;
            sbFilter.Name = "sbFilter";
            sbFilter.PlaceHolderText = "键入搜索内容";
            sbFilter.Size = new Size(560, 30);
            sbFilter.TabIndex = 33;
            sbFilter.TextAlign = HorizontalAlignment.Left;
            sbFilter.SearchStart += sbFilter_SearchStart;
            // 
            // PlaylistEditor
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lvPlaylist);
            Controls.Add(sbFilter);
            Controls.Add(msPl);
            Controls.Add(statusStrip);
            Margin = new Padding(4, 3, 4, 3);
            Name = "PlaylistEditor";
            Size = new Size(560, 536);
            DragDrop += PlaylistEditor_DragDrop;
            DragEnter += PlaylistEditor_DragEnter;
            msPl.ResumeLayout(false);
            msPl.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)lvPlaylist).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private ToolStripStatusLabel lblTotalLength;
        private ToolStripStatusLabel lblTotalCount;
        private StatusStrip statusStrip;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader1;
        private MenuStrip msPl;
        private ToolStripMenuItem tsmPlay;
        private ToolStripMenuItem tsmiPlay;
        private ToolStripMenuItem tsmilu;
        private ToolStripMenuItem tsmiSendTo;
        private ToolStripMenuItem tsmiSendToMediaLibrary;
        private ToolStripMenuItem tsmiAdd;
        private ToolStripMenuItem tsmiAddFile;
        private ToolStripMenuItem tsmiAddFolder;
        private ToolStripMenuItem tsmiAddURL;
        private ToolStripMenuItem tsmiRemove;
        private ToolStripMenuItem tsmiRemoveSelected;
        private ToolStripMenuItem tsmiClear;
        private ToolStripMenuItem tsmiKeep;
        private ToolStripMenuItem tsmiPlaylist;
        private ToolStripMenuItem tsmiImport;
        private ToolStripMenuItem tsmiImportFromFile;
        private ToolStripMenuItem tsmiImportFormActivePlaylist;
        private ToolStripMenuItem tsmiExport;
        private BrightIdeasSoftware.FastObjectListView lvPlaylist;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem tsmiPlay1;
        private ToolStripMenuItem tsmilu1;
        private ToolStripMenuItem tsmiSendToMediaLibrary1;
        private ToolStripMenuItem tsmiRemoveSelected1;
        private ToolStripMenuItem tsmiSelectedCount;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem tsmiMediaExplorer;
        private ToolStripMenuItem tsmiFileInfo;
        private WinFormsExtendedControls.SearchBox sbFilter;
    }
}
