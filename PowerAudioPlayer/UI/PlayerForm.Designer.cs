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
            trbPosition = new WinFormsExtendedControls.SelRangeTrackBar();
            btnPrevious = new Button();
            btnPlay = new Button();
            btnPause = new Button();
            btnStop = new Button();
            btnNext = new Button();
            trbVolume = new TrackBar();
            lblDisplayTitle = new Label();
            statusStrip = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            lblStatus1 = new ToolStripStatusLabel();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            lblPosition = new ToolStripStatusLabel();
            lblVolume = new ToolStripStatusLabel();
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
            tsmiLyricsForm = new ToolStripMenuItem();
            tsmiPlaylistEditorForm = new ToolStripMenuItem();
            tsmiAlbumPictureForm = new ToolStripMenuItem();
            tsmiSupportedFormatForm = new ToolStripMenuItem();
            tsmiMisc = new ToolStripMenuItem();
            tsmiCreateDesktopShortcut = new ToolStripMenuItem();
            tsmiAbout = new ToolStripMenuItem();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            pbAssocIcon = new PictureBox();
            lblAlbum = new Label();
            lblArtist = new Label();
            lblTitle = new Label();
            lblInfo = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            pictureBox1 = new PictureBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)trbPosition).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trbVolume).BeginInit();
            statusStrip.SuspendLayout();
            menuStrip1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbAssocIcon).BeginInit();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            flowLayoutPanel1.SuspendLayout();
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
            // trbPosition
            // 
            trbPosition.AutoSize = false;
            tableLayoutPanel2.SetColumnSpan(trbPosition, 2);
            trbPosition.Dock = DockStyle.Fill;
            trbPosition.Enabled = false;
            trbPosition.EnableSelRange = false;
            trbPosition.Location = new Point(3, 3);
            trbPosition.Name = "trbPosition";
            trbPosition.SelEnd = 0;
            trbPosition.SelStart = 0;
            trbPosition.Size = new Size(299, 22);
            trbPosition.TabIndex = 83;
            trbPosition.TickStyle = TickStyle.None;
            toolTip.SetToolTip(trbPosition, "位置");
            trbPosition.Scroll += trbPosition_Scroll;
            // 
            // btnPrevious
            // 
            btnPrevious.FlatAppearance.BorderSize = 0;
            btnPrevious.FlatStyle = FlatStyle.Flat;
            btnPrevious.Image = Resources.Previous;
            btnPrevious.Location = new Point(3, 3);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(24, 24);
            btnPrevious.TabIndex = 88;
            toolTip.SetToolTip(btnPrevious, "上一个");
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // btnPlay
            // 
            btnPlay.FlatAppearance.BorderSize = 0;
            btnPlay.FlatStyle = FlatStyle.Flat;
            btnPlay.Image = Resources.Play;
            btnPlay.Location = new Point(33, 3);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(24, 24);
            btnPlay.TabIndex = 89;
            toolTip.SetToolTip(btnPlay, "播放");
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // btnPause
            // 
            btnPause.FlatAppearance.BorderSize = 0;
            btnPause.FlatStyle = FlatStyle.Flat;
            btnPause.Image = Resources.Pause;
            btnPause.Location = new Point(63, 3);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(24, 24);
            btnPause.TabIndex = 90;
            toolTip.SetToolTip(btnPause, "暂停");
            btnPause.UseVisualStyleBackColor = true;
            btnPause.Click += btnPause_Click;
            // 
            // btnStop
            // 
            btnStop.FlatAppearance.BorderSize = 0;
            btnStop.FlatStyle = FlatStyle.Flat;
            btnStop.Image = Resources.Stop;
            btnStop.Location = new Point(93, 3);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(24, 24);
            btnStop.TabIndex = 91;
            toolTip.SetToolTip(btnStop, "停止");
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnNext
            // 
            btnNext.FlatAppearance.BorderSize = 0;
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.Image = Resources.Next;
            btnNext.Location = new Point(123, 3);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(24, 24);
            btnNext.TabIndex = 92;
            toolTip.SetToolTip(btnNext, "下一个");
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // trbVolume
            // 
            trbVolume.AutoSize = false;
            trbVolume.Dock = DockStyle.Top;
            trbVolume.LargeChange = 2;
            trbVolume.Location = new Point(34, 3);
            trbVolume.Maximum = 100;
            trbVolume.Name = "trbVolume";
            trbVolume.Size = new Size(59, 24);
            trbVolume.TabIndex = 92;
            trbVolume.TickFrequency = 5;
            trbVolume.TickStyle = TickStyle.None;
            toolTip.SetToolTip(trbVolume, "音量");
            trbVolume.Value = 50;
            trbVolume.Scroll += trbVolume_Scroll;
            // 
            // lblDisplayTitle
            // 
            lblDisplayTitle.AutoEllipsis = true;
            lblDisplayTitle.Dock = DockStyle.Top;
            lblDisplayTitle.Location = new Point(0, 0);
            lblDisplayTitle.Name = "lblDisplayTitle";
            lblDisplayTitle.Size = new Size(299, 17);
            lblDisplayTitle.TabIndex = 99;
            lblDisplayTitle.Text = "PowerAudioPlayer";
            lblDisplayTitle.TextAlign = ContentAlignment.MiddleCenter;
            toolTip.SetToolTip(lblDisplayTitle, "标题");
            lblDisplayTitle.UseMnemonic = false;
            lblDisplayTitle.MouseCaptureChanged += lblDisplayTitle_DoubleClick;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { lblStatus, lblStatus1, toolStripStatusLabel1, lblPosition, lblVolume });
            statusStrip.Location = new Point(0, 232);
            statusStrip.Name = "statusStrip";
            statusStrip.ShowItemToolTips = true;
            statusStrip.Size = new Size(305, 26);
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
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(97, 21);
            toolStripStatusLabel1.Spring = true;
            // 
            // lblPosition
            // 
            lblPosition.BorderSides = ToolStripStatusLabelBorderSides.Right;
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(79, 21);
            lblPosition.Text = "00:00/00:00";
            // 
            // lblVolume
            // 
            lblVolume.Name = "lblVolume";
            lblVolume.Size = new Size(40, 21);
            lblVolume.Text = "100%";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { tsmiFile, tsmiPlayControl, tsmiView, tsmiMisc });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(305, 25);
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
            tsmiSettingsForm.Size = new Size(160, 22);
            tsmiSettingsForm.Text = "设置";
            tsmiSettingsForm.Click += tsbtnSettings_Click;
            // 
            // tsmiMediaLibraryForm
            // 
            tsmiMediaLibraryForm.Image = Resources.Library;
            tsmiMediaLibraryForm.Name = "tsmiMediaLibraryForm";
            tsmiMediaLibraryForm.Size = new Size(160, 22);
            tsmiMediaLibraryForm.Text = "媒体库";
            tsmiMediaLibraryForm.Click += tsbtnMediaLibraryForm_Click;
            // 
            // tsmiSoundEffectForm
            // 
            tsmiSoundEffectForm.Image = Resources.Equalizer;
            tsmiSoundEffectForm.Name = "tsmiSoundEffectForm";
            tsmiSoundEffectForm.Size = new Size(160, 22);
            tsmiSoundEffectForm.Text = "声音效果";
            tsmiSoundEffectForm.Click += tsbtnSoundEffect_Click;
            // 
            // tsmiLyricsForm
            // 
            tsmiLyricsForm.Image = Resources.Lyrics;
            tsmiLyricsForm.Name = "tsmiLyricsForm";
            tsmiLyricsForm.Size = new Size(160, 22);
            tsmiLyricsForm.Text = "歌词";
            tsmiLyricsForm.Click += tsmiLyricsForm_Click;
            // 
            // tsmiPlaylistEditorForm
            // 
            tsmiPlaylistEditorForm.Image = Resources.PlaylistEditor;
            tsmiPlaylistEditorForm.Name = "tsmiPlaylistEditorForm";
            tsmiPlaylistEditorForm.Size = new Size(160, 22);
            tsmiPlaylistEditorForm.Text = "播放列表编辑器";
            tsmiPlaylistEditorForm.Click += tsmiPlaylistEditorForm_Click;
            // 
            // tsmiAlbumPictureForm
            // 
            tsmiAlbumPictureForm.Image = Resources.Picture;
            tsmiAlbumPictureForm.Name = "tsmiAlbumPictureForm";
            tsmiAlbumPictureForm.Size = new Size(160, 22);
            tsmiAlbumPictureForm.Text = "专辑图片";
            tsmiAlbumPictureForm.Click += tsmiAlbumPictureForm_Click;
            // 
            // tsmiSupportedFormatForm
            // 
            tsmiSupportedFormatForm.Name = "tsmiSupportedFormatForm";
            tsmiSupportedFormatForm.Size = new Size(160, 22);
            tsmiSupportedFormatForm.Text = "支持的格式列表";
            tsmiSupportedFormatForm.Click += tsmiSupportedFormat_Click;
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
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66.6666641F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel2.Controls.Add(panel1, 0, 2);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 1, 1);
            tableLayoutPanel2.Controls.Add(flowLayoutPanel1, 0, 1);
            tableLayoutPanel2.Controls.Add(trbPosition, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 25);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(305, 207);
            tableLayoutPanel2.TabIndex = 92;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            tableLayoutPanel2.SetColumnSpan(panel1, 2);
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Controls.Add(lblDisplayTitle);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 68);
            panel1.Name = "panel1";
            panel1.Size = new Size(299, 136);
            panel1.TabIndex = 99;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(pbAssocIcon, 0, 0);
            tableLayoutPanel1.Controls.Add(lblAlbum, 2, 3);
            tableLayoutPanel1.Controls.Add(lblArtist, 2, 1);
            tableLayoutPanel1.Controls.Add(lblTitle, 2, 2);
            tableLayoutPanel1.Controls.Add(lblInfo, 1, 0);
            tableLayoutPanel1.Controls.Add(label2, 1, 1);
            tableLayoutPanel1.Controls.Add(label3, 1, 2);
            tableLayoutPanel1.Controls.Add(label4, 1, 3);
            tableLayoutPanel1.Location = new Point(7, 24);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(140, 98);
            tableLayoutPanel1.TabIndex = 98;
            // 
            // pbAssocIcon
            // 
            pbAssocIcon.Dock = DockStyle.Fill;
            pbAssocIcon.Location = new Point(4, 4);
            pbAssocIcon.Name = "pbAssocIcon";
            tableLayoutPanel1.SetRowSpan(pbAssocIcon, 5);
            pbAssocIcon.Size = new Size(34, 90);
            pbAssocIcon.SizeMode = PictureBoxSizeMode.CenterImage;
            pbAssocIcon.TabIndex = 101;
            pbAssocIcon.TabStop = false;
            // 
            // lblAlbum
            // 
            lblAlbum.AutoSize = true;
            lblAlbum.Dock = DockStyle.Fill;
            lblAlbum.Location = new Point(96, 76);
            lblAlbum.Margin = new Padding(3);
            lblAlbum.Name = "lblAlbum";
            lblAlbum.Size = new Size(40, 17);
            lblAlbum.TabIndex = 94;
            lblAlbum.Text = " ";
            lblAlbum.TextAlign = ContentAlignment.MiddleLeft;
            lblAlbum.UseMnemonic = false;
            lblAlbum.DoubleClick += lbl_DoubleClick;
            // 
            // lblArtist
            // 
            lblArtist.AutoSize = true;
            lblArtist.Dock = DockStyle.Fill;
            lblArtist.Location = new Point(96, 28);
            lblArtist.Margin = new Padding(3);
            lblArtist.Name = "lblArtist";
            lblArtist.Size = new Size(40, 17);
            lblArtist.TabIndex = 93;
            lblArtist.Text = " ";
            lblArtist.TextAlign = ContentAlignment.MiddleLeft;
            lblArtist.UseMnemonic = false;
            lblArtist.DoubleClick += lbl_DoubleClick;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Location = new Point(96, 52);
            lblTitle.Margin = new Padding(3);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(40, 17);
            lblTitle.TabIndex = 92;
            lblTitle.Text = " ";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            lblTitle.UseMnemonic = false;
            lblTitle.DoubleClick += lbl_DoubleClick;
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(lblInfo, 2);
            lblInfo.Dock = DockStyle.Fill;
            lblInfo.Location = new Point(45, 4);
            lblInfo.Margin = new Padding(3);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(91, 17);
            lblInfo.TabIndex = 91;
            lblInfo.Text = " ";
            lblInfo.UseMnemonic = false;
            lblInfo.DoubleClick += lbl_DoubleClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(45, 25);
            label2.Name = "label2";
            label2.Size = new Size(44, 23);
            label2.TabIndex = 96;
            label2.Text = "艺术家";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(45, 49);
            label3.Name = "label3";
            label3.Size = new Size(44, 23);
            label3.TabIndex = 97;
            label3.Text = "标题";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(45, 73);
            label4.Name = "label4";
            label4.Size = new Size(44, 23);
            label4.TabIndex = 98;
            label4.Text = "专辑";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.AutoSize = true;
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(trbVolume, 1, 0);
            tableLayoutPanel3.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Top;
            tableLayoutPanel3.Location = new Point(206, 31);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Size = new Size(96, 31);
            tableLayoutPanel3.TabIndex = 95;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Resources.Vol;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(25, 25);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 91;
            pictureBox1.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(btnPrevious);
            flowLayoutPanel1.Controls.Add(btnPlay);
            flowLayoutPanel1.Controls.Add(btnPause);
            flowLayoutPanel1.Controls.Add(btnStop);
            flowLayoutPanel1.Controls.Add(btnNext);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.Location = new Point(3, 31);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(197, 30);
            flowLayoutPanel1.TabIndex = 94;
            // 
            // PlayerForm
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoScroll = true;
            AutoSize = true;
            ClientSize = new Size(305, 258);
            Controls.Add(tableLayoutPanel2);
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
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbAssocIcon).EndInit();
            tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Timer tmrPlayer;
        private System.Windows.Forms.Timer tmrLyrics;
        private ToolTip toolTip;
        private ToolStripMenuItem tsmiAbout;
       
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblStatus;
        private ToolStripStatusLabel lblStatus1;
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
        private ToolStripMenuItem tsmiAlbumPictureForm;
        private ToolStripStatusLabel lblPosition;
        private ToolStripStatusLabel lblVolume;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TrackBar trbVolume;
        private PictureBox pictureBox1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnPrevious;
        private Button btnPlay;
        private Button btnPause;
        private Button btnStop;
        private Button btnNext;
        private WinFormsExtendedControls.SelRangeTrackBar trbPosition;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label2;
        private Label label3;
        private Label lblDisplayTitle;
        private Label lblAlbum;
        private Label lblArtist;
        private Label lblTitle;
        private Label lblInfo;
        private Label label4;
        private PictureBox pbAssocIcon;
    }
}