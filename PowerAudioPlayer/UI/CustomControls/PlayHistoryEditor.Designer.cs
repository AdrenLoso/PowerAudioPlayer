namespace PowerAudioPlayer.UI.CustomControls
{
    partial class PlayHistoryEditor
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
            lvHistory = new BrightIdeasSoftware.FastObjectListView();
            contextMenuStrip = new ContextMenuStrip(components);
            tsmiPlay = new ToolStripMenuItem();
            tsmiLineUp = new ToolStripMenuItem();
            tsmiRemove = new ToolStripMenuItem();
            tsmiClear = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            tsmiFileInfo = new ToolStripMenuItem();
            tsmiExplorer = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            lblItemTotalCount = new ToolStripStatusLabel();
            lblTotalPlayTimesCount = new ToolStripStatusLabel();
            lblTotalPlayTime = new ToolStripStatusLabel();
            tsmiSelectedCount = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)lvHistory).BeginInit();
            contextMenuStrip.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // lvHistory
            // 
            lvHistory.ContextMenuStrip = contextMenuStrip;
            lvHistory.Dock = DockStyle.Fill;
            lvHistory.FullRowSelect = true;
            lvHistory.GridLines = true;
            lvHistory.Location = new Point(0, 0);
            lvHistory.Name = "lvHistory";
            lvHistory.ShowCommandMenuOnRightClick = true;
            lvHistory.ShowGroups = false;
            lvHistory.Size = new Size(512, 416);
            lvHistory.TabIndex = 0;
            lvHistory.UseFiltering = true;
            lvHistory.View = View.Details;
            lvHistory.VirtualMode = true;
            lvHistory.DoubleClick += lvHistory_DoubleClick;
            lvHistory.KeyDown += lvHistory_KeyDown;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { tsmiSelectedCount, toolStripSeparator2, tsmiPlay, tsmiLineUp, tsmiRemove, tsmiClear, toolStripSeparator1, tsmiFileInfo, tsmiExplorer });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new Size(209, 192);
            contextMenuStrip.Opening += contextMenuStrip_Opening;
            // 
            // tsmiPlay
            // 
            tsmiPlay.Name = "tsmiPlay";
            tsmiPlay.Size = new Size(208, 22);
            tsmiPlay.Text = "播放";
            // 
            // tsmiLineUp
            // 
            tsmiLineUp.Name = "tsmiLineUp";
            tsmiLineUp.Size = new Size(208, 22);
            tsmiLineUp.Text = "排队";
            tsmiLineUp.Click += tsmiLineUp_Click;
            // 
            // tsmiRemove
            // 
            tsmiRemove.Name = "tsmiRemove";
            tsmiRemove.Size = new Size(208, 22);
            tsmiRemove.Text = "移除";
            tsmiRemove.Click += tsmiRemove_Click;
            // 
            // tsmiClear
            // 
            tsmiClear.Name = "tsmiClear";
            tsmiClear.Size = new Size(208, 22);
            tsmiClear.Text = "清空";
            tsmiClear.Click += tsmiClear_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(205, 6);
            // 
            // tsmiFileInfo
            // 
            tsmiFileInfo.Name = "tsmiFileInfo";
            tsmiFileInfo.Size = new Size(208, 22);
            tsmiFileInfo.Text = "查看文件信息";
            tsmiFileInfo.Click += tsmiFileInfo_Click;
            // 
            // tsmiExplorer
            // 
            tsmiExplorer.Name = "tsmiExplorer";
            tsmiExplorer.Size = new Size(208, 22);
            tsmiExplorer.Text = "在文件资源管理器中查看";
            tsmiExplorer.Click += tsmiExplorer_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblItemTotalCount, lblTotalPlayTimesCount, lblTotalPlayTime });
            statusStrip1.Location = new Point(0, 416);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(512, 26);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblItemTotalCount
            // 
            lblItemTotalCount.BorderSides = ToolStripStatusLabelBorderSides.Right;
            lblItemTotalCount.Name = "lblItemTotalCount";
            lblItemTotalCount.Size = new Size(19, 21);
            lblItemTotalCount.Text = "0";
            // 
            // lblTotalPlayTimesCount
            // 
            lblTotalPlayTimesCount.Name = "lblTotalPlayTimesCount";
            lblTotalPlayTimesCount.Size = new Size(15, 21);
            lblTotalPlayTimesCount.Text = "0";
            // 
            // lblTotalPlayTime
            // 
            lblTotalPlayTime.Name = "lblTotalPlayTime";
            lblTotalPlayTime.Size = new Size(39, 21);
            lblTotalPlayTime.Text = "00:00";
            // 
            // tsmiSelectedCount
            // 
            tsmiSelectedCount.Enabled = false;
            tsmiSelectedCount.Name = "tsmiSelectedCount";
            tsmiSelectedCount.Size = new Size(208, 22);
            tsmiSelectedCount.Text = "toolStripMenuItem1";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(205, 6);
            // 
            // PlayHistoryEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lvHistory);
            Controls.Add(statusStrip1);
            Name = "PlayHistoryEditor";
            Size = new Size(512, 442);
            ((System.ComponentModel.ISupportInitialize)lvHistory).EndInit();
            contextMenuStrip.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private BrightIdeasSoftware.FastObjectListView lvHistory;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem tsmiPlay;
        private ToolStripMenuItem tsmiRemove;
        private ToolStripMenuItem tsmiClear;
        private ToolStripMenuItem tsmiFileInfo;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem tsmiExplorer;
        private ToolStripMenuItem tsmiLineUp;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblItemTotalCount;
        private ToolStripStatusLabel lblTotalPlayTimesCount;
        private ToolStripStatusLabel lblTotalPlayTime;
        private ToolStripMenuItem tsmiSelectedCount;
        private ToolStripSeparator toolStripSeparator2;
    }
}
