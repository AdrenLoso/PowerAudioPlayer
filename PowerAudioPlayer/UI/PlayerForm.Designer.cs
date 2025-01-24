using PowerAudioPlayer.UI.CustomControls;
using Un4seen.Bass;

namespace PowerAudioPlayer
{
    partial class PlayerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerForm));
            tmrPlayer = new System.Windows.Forms.Timer(components);
            tmrLyrics = new System.Windows.Forms.Timer(components);
            toolTip = new ToolTip(components);
            btnPlay = new Button();
            btnPause = new Button();
            btnStop = new Button();
            btnNext = new Button();
            lblDisplayTitle = new Label();
            btnPrevious = new Button();
            trbPosition = new WinFormsExtendedControls.SelRangeTrackBar();
            trbVolume = new TrackBar();
            lblTitle = new Label();
            lblAlbum = new Label();
            lblArtist = new Label();
            lblInfo = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            lblPosition = new Label();
            lblVolume = new Label();
            statusStrip = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            lblStatus1 = new ToolStripStatusLabel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            menuStrip1 = new MenuStrip();
            tsmiFile = new ToolStripMenuItem();
            tsmiAddFile = new ToolStripMenuItem();
            tsmiAddFolder = new ToolStripMenuItem();
            tsmiAddURL = new ToolStripMenuItem();
            tsmiPlayControl = new ToolStripMenuItem();
            tsmiPlay = new ToolStripMenuItem();
            tsmiPause = new ToolStripMenuItem();
            tsmiStop = new ToolStripMenuItem();
            tsmiNext = new ToolStripMenuItem();
            tsmiPrevious = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            tsmiPlayMode = new ToolStripMenuItem();
            tsemiOrderPlay = new WinFormsExtendedControls.ToolStripEnhancedMenuItem();
            tsemiShufflePlay = new WinFormsExtendedControls.ToolStripEnhancedMenuItem();
            tsemiTrackLoop = new WinFormsExtendedControls.ToolStripEnhancedMenuItem();
            tsemiPlaylistLoop = new WinFormsExtendedControls.ToolStripEnhancedMenuItem();
            tsmiABRepeat = new ToolStripMenuItem();
            tsmiView = new ToolStripMenuItem();
            tsmiSettingsForm = new ToolStripMenuItem();
            tsmiMediaLibraryForm = new ToolStripMenuItem();
            tsmiSoundEffectForm = new ToolStripMenuItem();
            tsmiSupportedFormatForm = new ToolStripMenuItem();
            tsmiLyricsForm = new ToolStripMenuItem();
            tsmiPlaylistEditorForm = new ToolStripMenuItem();
            tsmiMisc = new ToolStripMenuItem();
            tsmiCreateDesktopShortcut = new ToolStripMenuItem();
            tsmiAbout = new ToolStripMenuItem();
            tsmiAlbumPictureForm = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)trbPosition).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trbVolume).BeginInit();
            tableLayoutPanel3.SuspendLayout();
            statusStrip.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tmrPlayer
            // 
            tmrPlayer.Interval = 200;
            tmrPlayer.Tick += tmrPlayer_Tick;
            // 
            // tmrLyrics
            // 
            tmrLyrics.Interval = 200;
            tmrLyrics.Tick += tmrLyrics_Tick;
            // 
            // btnPlay
            // 
            btnPlay.FlatAppearance.MouseOverBackColor = Color.Red;
            btnPlay.Image = Resources.Play;
            btnPlay.Location = new Point(33, 3);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(24, 24);
            btnPlay.TabIndex = 1;
            toolTip.SetToolTip(btnPlay, "播放");
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // btnPause
            // 
            btnPause.Image = Resources.Pause;
            btnPause.Location = new Point(63, 3);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(24, 24);
            btnPause.TabIndex = 2;
            toolTip.SetToolTip(btnPause, "暂停");
            btnPause.UseVisualStyleBackColor = true;
            btnPause.Click += btnPause_Click;
            // 
            // btnStop
            // 
            btnStop.Image = Resources.Stop;
            btnStop.Location = new Point(93, 3);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(24, 24);
            btnStop.TabIndex = 3;
            toolTip.SetToolTip(btnStop, "停止");
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnNext
            // 
            btnNext.Image = Resources.Next;
            btnNext.Location = new Point(123, 3);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(24, 24);
            btnNext.TabIndex = 4;
            toolTip.SetToolTip(btnNext, "下一个");
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // lblDisplayTitle
            // 
            lblDisplayTitle.AutoEllipsis = true;
            tableLayoutPanel1.SetColumnSpan(lblDisplayTitle, 2);
            lblDisplayTitle.Dock = DockStyle.Fill;
            lblDisplayTitle.Location = new Point(3, 0);
            lblDisplayTitle.Name = "lblDisplayTitle";
            lblDisplayTitle.Size = new Size(438, 17);
            lblDisplayTitle.TabIndex = 0;
            lblDisplayTitle.Text = "PowerAudioPlayer";
            lblDisplayTitle.TextAlign = ContentAlignment.MiddleCenter;
            toolTip.SetToolTip(lblDisplayTitle, "标题");
            lblDisplayTitle.UseMnemonic = false;
            lblDisplayTitle.DoubleClick += lblDisplayTitle_DoubleClick;
            // 
            // btnPrevious
            // 
            btnPrevious.Image = Resources.Previous;
            btnPrevious.Location = new Point(3, 3);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(24, 24);
            btnPrevious.TabIndex = 0;
            toolTip.SetToolTip(btnPrevious, "上一个");
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // trbPosition
            // 
            trbPosition.AutoSize = false;
            trbPosition.Dock = DockStyle.Fill;
            trbPosition.Enabled = false;
            trbPosition.EnableSelRange = false;
            trbPosition.Location = new Point(92, 3);
            trbPosition.Name = "trbPosition";
            trbPosition.SelEnd = 0;
            trbPosition.SelStart = 0;
            trbPosition.Size = new Size(211, 29);
            trbPosition.TabIndex = 1;
            trbPosition.TickStyle = TickStyle.None;
            toolTip.SetToolTip(trbPosition, "位置");
            trbPosition.Scroll += trbPosition_Scroll;
            trbPosition.MouseDown += trbPosition_MouseDown;
            // 
            // trbVolume
            // 
            trbVolume.AutoSize = false;
            trbVolume.Dock = DockStyle.Fill;
            trbVolume.LargeChange = 2;
            trbVolume.Location = new Point(348, 3);
            trbVolume.Maximum = 100;
            trbVolume.Name = "trbVolume";
            trbVolume.Size = new Size(87, 29);
            trbVolume.TabIndex = 2;
            trbVolume.TickFrequency = 5;
            trbVolume.TickStyle = TickStyle.None;
            toolTip.SetToolTip(trbVolume, "音量");
            trbVolume.Value = 50;
            trbVolume.Scroll += trbVolume_Scroll;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(4, 28);
            lblTitle.Margin = new Padding(3);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(0, 17);
            lblTitle.TabIndex = 1;
            lblTitle.UseMnemonic = false;
            lblTitle.DoubleClick += lbl_DoubleClick;
            // 
            // lblAlbum
            // 
            lblAlbum.AutoSize = true;
            lblAlbum.Location = new Point(4, 76);
            lblAlbum.Margin = new Padding(3);
            lblAlbum.Name = "lblAlbum";
            lblAlbum.Size = new Size(0, 17);
            lblAlbum.TabIndex = 3;
            lblAlbum.UseMnemonic = false;
            lblAlbum.DoubleClick += lbl_DoubleClick;
            // 
            // lblArtist
            // 
            lblArtist.AutoSize = true;
            lblArtist.Location = new Point(4, 52);
            lblArtist.Margin = new Padding(3);
            lblArtist.Name = "lblArtist";
            lblArtist.Size = new Size(0, 17);
            lblArtist.TabIndex = 2;
            lblArtist.UseMnemonic = false;
            lblArtist.DoubleClick += lbl_DoubleClick;
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Location = new Point(4, 4);
            lblInfo.Margin = new Padding(3);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(0, 17);
            lblInfo.TabIndex = 0;
            lblInfo.UseMnemonic = false;
            lblInfo.DoubleClick += lbl_DoubleClick;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.AutoSize = true;
            tableLayoutPanel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel3.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.Controls.Add(lblInfo, 0, 0);
            tableLayoutPanel3.Controls.Add(lblArtist, 0, 2);
            tableLayoutPanel3.Controls.Add(lblTitle, 0, 1);
            tableLayoutPanel3.Controls.Add(lblAlbum, 0, 3);
            tableLayoutPanel3.Location = new Point(3, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 4;
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.Size = new Size(8, 97);
            tableLayoutPanel3.TabIndex = 73;
            // 
            // lblPosition
            // 
            lblPosition.AutoSize = true;
            lblPosition.Dock = DockStyle.Fill;
            lblPosition.Location = new Point(3, 0);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(83, 35);
            lblPosition.TabIndex = 0;
            lblPosition.Text = "00:00 / 00:00";
            lblPosition.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblVolume
            // 
            lblVolume.AutoSize = true;
            lblVolume.Dock = DockStyle.Fill;
            lblVolume.Location = new Point(309, 0);
            lblVolume.Name = "lblVolume";
            lblVolume.Size = new Size(33, 35);
            lblVolume.TabIndex = 3;
            lblVolume.Text = "50%";
            lblVolume.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { lblStatus, lblStatus1 });
            statusStrip.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            statusStrip.Location = new Point(0, 240);
            statusStrip.Name = "statusStrip";
            statusStrip.ShowItemToolTips = true;
            statusStrip.Size = new Size(444, 26);
            statusStrip.SizingGrip = false;
            statusStrip.TabIndex = 76;
            statusStrip.Text = "statusStrip";
            // 
            // lblStatus
            // 
            lblStatus.ImageScaling = ToolStripItemImageScaling.None;
            lblStatus.Margin = new Padding(3, 3, 3, 2);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(32, 21);
            lblStatus.Text = "停止";
            // 
            // lblStatus1
            // 
            lblStatus1.BorderSides = ToolStripStatusLabelBorderSides.Left;
            lblStatus1.Name = "lblStatus1";
            lblStatus1.Size = new Size(36, 21);
            lblStatus1.Text = "就绪";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 1);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 3);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 2);
            tableLayoutPanel1.Controls.Add(lblDisplayTitle, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 25);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(444, 215);
            tableLayoutPanel1.TabIndex = 77;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            tableLayoutPanel1.SetColumnSpan(panel1, 2);
            panel1.Controls.Add(tableLayoutPanel3);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 20);
            panel1.Name = "panel1";
            panel1.Size = new Size(438, 115);
            panel1.TabIndex = 81;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(flowLayoutPanel1, 2);
            flowLayoutPanel1.Controls.Add(btnPrevious);
            flowLayoutPanel1.Controls.Add(btnPlay);
            flowLayoutPanel1.Controls.Add(btnPause);
            flowLayoutPanel1.Controls.Add(btnStop);
            flowLayoutPanel1.Controls.Add(btnNext);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(3, 182);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(438, 30);
            flowLayoutPanel1.TabIndex = 78;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel1.SetColumnSpan(tableLayoutPanel2, 2);
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel2.Controls.Add(lblPosition, 0, 0);
            tableLayoutPanel2.Controls.Add(trbPosition, 1, 0);
            tableLayoutPanel2.Controls.Add(lblVolume, 2, 0);
            tableLayoutPanel2.Controls.Add(trbVolume, 3, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 141);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(438, 35);
            tableLayoutPanel2.TabIndex = 78;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { tsmiFile, tsmiPlayControl, tsmiView, tsmiMisc });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(444, 25);
            menuStrip1.TabIndex = 80;
            menuStrip1.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            tsmiFile.DropDownItems.AddRange(new ToolStripItem[] { tsmiAddFile, tsmiAddFolder, tsmiAddURL });
            tsmiFile.Name = "tsmiFile";
            tsmiFile.Size = new Size(44, 21);
            tsmiFile.Text = "文件";
            // 
            // tsmiAddFile
            // 
            tsmiAddFile.Image = Resources.Add;
            tsmiAddFile.Name = "tsmiAddFile";
            tsmiAddFile.Size = new Size(136, 22);
            tsmiAddFile.Text = "添加文件";
            tsmiAddFile.Click += tsmiAddFile_Click;
            // 
            // tsmiAddFolder
            // 
            tsmiAddFolder.Name = "tsmiAddFolder";
            tsmiAddFolder.Size = new Size(136, 22);
            tsmiAddFolder.Text = "添加文件夹";
            tsmiAddFolder.Click += tsmiAddFolder_Click;
            // 
            // tsmiAddURL
            // 
            tsmiAddURL.Name = "tsmiAddURL";
            tsmiAddURL.Size = new Size(136, 22);
            tsmiAddURL.Text = "添加URL";
            tsmiAddURL.Click += tsmiAddURL_Click;
            // 
            // tsmiPlayControl
            // 
            tsmiPlayControl.DropDownItems.AddRange(new ToolStripItem[] { tsmiPlay, tsmiPause, tsmiStop, tsmiNext, tsmiPrevious, toolStripMenuItem1, tsmiPlayMode, tsmiABRepeat });
            tsmiPlayControl.Name = "tsmiPlayControl";
            tsmiPlayControl.Size = new Size(44, 21);
            tsmiPlayControl.Text = "控制";
            // 
            // tsmiPlay
            // 
            tsmiPlay.Image = Resources.Play;
            tsmiPlay.Name = "tsmiPlay";
            tsmiPlay.Size = new Size(124, 22);
            tsmiPlay.Text = "播放";
            tsmiPlay.Click += btnPlay_Click;
            // 
            // tsmiPause
            // 
            tsmiPause.Image = Resources.Pause;
            tsmiPause.Name = "tsmiPause";
            tsmiPause.Size = new Size(124, 22);
            tsmiPause.Text = "暂停";
            tsmiPause.Click += btnPause_Click;
            // 
            // tsmiStop
            // 
            tsmiStop.Image = Resources.Stop;
            tsmiStop.Name = "tsmiStop";
            tsmiStop.Size = new Size(124, 22);
            tsmiStop.Text = "停止";
            tsmiStop.Click += btnStop_Click;
            // 
            // tsmiNext
            // 
            tsmiNext.Image = Resources.Next;
            tsmiNext.Name = "tsmiNext";
            tsmiNext.Size = new Size(124, 22);
            tsmiNext.Text = "下一个";
            tsmiNext.Click += btnNext_Click;
            // 
            // tsmiPrevious
            // 
            tsmiPrevious.Image = Resources.Previous;
            tsmiPrevious.Name = "tsmiPrevious";
            tsmiPrevious.Size = new Size(124, 22);
            tsmiPrevious.Text = "上一个";
            tsmiPrevious.Click += btnPrevious_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(121, 6);
            // 
            // tsmiPlayMode
            // 
            tsmiPlayMode.DropDownItems.AddRange(new ToolStripItem[] { tsemiOrderPlay, tsemiShufflePlay, tsemiTrackLoop, tsemiPlaylistLoop });
            tsmiPlayMode.Name = "tsmiPlayMode";
            tsmiPlayMode.Size = new Size(124, 22);
            tsmiPlayMode.Text = "播放模式";
            // 
            // tsemiOrderPlay
            // 
            tsemiOrderPlay.AssociatedEnumValue = null;
            tsemiOrderPlay.CheckOnClick = true;
            tsemiOrderPlay.Name = "tsemiOrderPlay";
            tsemiOrderPlay.RadioButtonGroupName = "PlayMode";
            tsemiOrderPlay.Size = new Size(148, 22);
            tsemiOrderPlay.Text = "顺序播放";
            // 
            // tsemiShufflePlay
            // 
            tsemiShufflePlay.AssociatedEnumValue = null;
            tsemiShufflePlay.CheckOnClick = true;
            tsemiShufflePlay.Name = "tsemiShufflePlay";
            tsemiShufflePlay.RadioButtonGroupName = "PlayMode";
            tsemiShufflePlay.Size = new Size(148, 22);
            tsemiShufflePlay.Text = "随机播放";
            // 
            // tsemiTrackLoop
            // 
            tsemiTrackLoop.AssociatedEnumValue = null;
            tsemiTrackLoop.CheckOnClick = true;
            tsemiTrackLoop.Name = "tsemiTrackLoop";
            tsemiTrackLoop.RadioButtonGroupName = "PlayMode";
            tsemiTrackLoop.Size = new Size(148, 22);
            tsemiTrackLoop.Text = "单个循环";
            // 
            // tsemiPlaylistLoop
            // 
            tsemiPlaylistLoop.AssociatedEnumValue = null;
            tsemiPlaylistLoop.CheckOnClick = true;
            tsemiPlaylistLoop.Name = "tsemiPlaylistLoop";
            tsemiPlaylistLoop.RadioButtonGroupName = "PlayMode";
            tsemiPlaylistLoop.Size = new Size(148, 22);
            tsemiPlaylistLoop.Text = "播放列表循环";
            // 
            // tsmiABRepeat
            // 
            tsmiABRepeat.Name = "tsmiABRepeat";
            tsmiABRepeat.Size = new Size(124, 22);
            tsmiABRepeat.Text = "A-B重复";
            tsmiABRepeat.Click += tsmiABRepeat_Click;
            // 
            // tsmiView
            // 
            tsmiView.DropDownItems.AddRange(new ToolStripItem[] { tsmiSettingsForm, tsmiMediaLibraryForm, tsmiSoundEffectForm, tsmiLyricsForm, tsmiPlaylistEditorForm, tsmiAlbumPictureForm, tsmiSupportedFormatForm });
            tsmiView.Name = "tsmiView";
            tsmiView.Size = new Size(44, 21);
            tsmiView.Text = "视图";
            // 
            // tsmiSettingsForm
            // 
            tsmiSettingsForm.Image = Resources.Settings;
            tsmiSettingsForm.Name = "tsmiSettingsForm";
            tsmiSettingsForm.Size = new Size(180, 22);
            tsmiSettingsForm.Text = "设置";
            tsmiSettingsForm.Click += tsbtnSettings_Click;
            // 
            // tsmiMediaLibraryForm
            // 
            tsmiMediaLibraryForm.Image = Resources.Library;
            tsmiMediaLibraryForm.Name = "tsmiMediaLibraryForm";
            tsmiMediaLibraryForm.Size = new Size(180, 22);
            tsmiMediaLibraryForm.Text = "媒体库";
            tsmiMediaLibraryForm.Click += tsbtnMediaLibraryForm_Click;
            // 
            // tsmiSoundEffectForm
            // 
            tsmiSoundEffectForm.Image = Resources.Equalizer;
            tsmiSoundEffectForm.Name = "tsmiSoundEffectForm";
            tsmiSoundEffectForm.Size = new Size(180, 22);
            tsmiSoundEffectForm.Text = "声音效果";
            tsmiSoundEffectForm.Click += tsbtnSoundEffect_Click;
            // 
            // tsmiSupportedFormatForm
            // 
            tsmiSupportedFormatForm.Name = "tsmiSupportedFormatForm";
            tsmiSupportedFormatForm.Size = new Size(180, 22);
            tsmiSupportedFormatForm.Text = "支持的格式列表";
            tsmiSupportedFormatForm.Click += tsmiSupportedFormat_Click;
            // 
            // tsmiLyricsForm
            // 
            tsmiLyricsForm.Image = Resources.Lyrics;
            tsmiLyricsForm.Name = "tsmiLyricsForm";
            tsmiLyricsForm.Size = new Size(180, 22);
            tsmiLyricsForm.Text = "歌词";
            tsmiLyricsForm.Click += tsmiLyricsForm_Click;
            // 
            // tsmiPlaylistEditorForm
            // 
            tsmiPlaylistEditorForm.Image = Resources.PlaylistEditor;
            tsmiPlaylistEditorForm.Name = "tsmiPlaylistEditorForm";
            tsmiPlaylistEditorForm.Size = new Size(180, 22);
            tsmiPlaylistEditorForm.Text = "播放列表编辑器";
            tsmiPlaylistEditorForm.Click += tsmiPlaylistEditorForm_Click;
            // 
            // tsmiMisc
            // 
            tsmiMisc.DropDownItems.AddRange(new ToolStripItem[] { tsmiCreateDesktopShortcut, tsmiAbout });
            tsmiMisc.Name = "tsmiMisc";
            tsmiMisc.Size = new Size(44, 21);
            tsmiMisc.Text = "杂项";
            // 
            // tsmiCreateDesktopShortcut
            // 
            tsmiCreateDesktopShortcut.Name = "tsmiCreateDesktopShortcut";
            tsmiCreateDesktopShortcut.Size = new Size(148, 22);
            tsmiCreateDesktopShortcut.Text = "创建快捷方式";
            tsmiCreateDesktopShortcut.Click += tsmiCreateDesktopShortcut_Click;
            // 
            // tsmiAbout
            // 
            tsmiAbout.Name = "tsmiAbout";
            tsmiAbout.Size = new Size(148, 22);
            tsmiAbout.Text = "关于";
            tsmiAbout.Click += tsmiAbout_Click;
            // 
            // tsmiAlbumPictureForm
            // 
            tsmiAlbumPictureForm.Image = Resources.Picture;
            tsmiAlbumPictureForm.Name = "tsmiAlbumPictureForm";
            tsmiAlbumPictureForm.Size = new Size(180, 22);
            tsmiAlbumPictureForm.Text = "专辑图片";
            tsmiAlbumPictureForm.Click += tsmiAlbumPictureForm_Click;
            // 
            // PlayerForm
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            ClientSize = new Size(444, 266);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "PlayerForm";
            StartPosition = FormStartPosition.Manual;
            Text = "PowerAudioPlayer";
            FormClosing += PlayerForm_FormClosing;
            Shown += PlayerForm_Shown;
            DragDrop += PlayerForm_DragDrop;
            DragEnter += PlayerForm_DragEnter;
            MouseWheel += PlayerForm_MouseWheel;
            ((System.ComponentModel.ISupportInitialize)trbPosition).EndInit();
            ((System.ComponentModel.ISupportInitialize)trbVolume).EndInit();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Timer tmrPlayer;
        private System.Windows.Forms.Timer tmrLyrics;
        private ToolTip toolTip;
        private Button btnPlay;
        private Button btnPause;
        private Button btnStop;
        private Button btnNext;
        private Label lblDisplayTitle;
        private Label lblTitle;
        private Label lblAlbum;
        private Label lblArtist;
        private Button btnPrevious;
        private Label lblInfo;
        private TableLayoutPanel tableLayoutPanel3;
        private Label lblPosition;
        private Label lblVolume;
        private TrackBar trbVolume;
        private WinFormsExtendedControls.SelRangeTrackBar trbPosition;
        private ToolStripMenuItem tsmiAbout;
       
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblStatus;
        private ToolStripStatusLabel lblStatus1;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem tsmiFile;
        private ToolStripMenuItem tsmiPlayControl;
        private ToolStripMenuItem tsmiView;
        private ToolStripMenuItem tsmiMisc;
        private ToolStripMenuItem tsmiAddFile;
        private ToolStripMenuItem tsmiAddFolder;
        private ToolStripMenuItem tsmiAddURL;
        private ToolStripMenuItem tsmiPlay;
        private ToolStripMenuItem tsmiPause;
        private ToolStripMenuItem tsmiStop;
        private ToolStripMenuItem tsmiNext;
        private ToolStripMenuItem tsmiPrevious;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem tsmiPlayMode;
        private ToolStripMenuItem tsmiCreateDesktopShortcut;
        private WinFormsExtendedControls.ToolStripEnhancedMenuItem tsemiOrderPlay;
        private WinFormsExtendedControls.ToolStripEnhancedMenuItem tsemiShufflePlay;
        private WinFormsExtendedControls.ToolStripEnhancedMenuItem tsemiTrackLoop;
        private WinFormsExtendedControls.ToolStripEnhancedMenuItem tsemiPlaylistLoop;
        private ToolStripMenuItem tsmiABRepeat;
        private ToolStripMenuItem tsmiSettingsForm;
        private ToolStripMenuItem tsmiMediaLibraryForm;
        private ToolStripMenuItem tsmiSoundEffectForm;
        private ToolStripMenuItem tsmiSupportedFormatForm;
        private ToolStripMenuItem tsmiLyricsForm;
        private ToolStripMenuItem tsmiPlaylistEditorForm;
        private Panel panel1;
        private ToolStripMenuItem tsmiAlbumPictureForm;
    }
}