namespace PowerAudioPlayer.UI.CustomControls.SettingsPages
{
    partial class DataFileSettingsPage
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
            lblMsg = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnExploreFolder = new Button();
            btnExport = new Button();
            btnImport = new Button();
            btnClearCurrentUser = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            pbUserAvatar = new PictureBox();
            btnSetSavePath = new Button();
            flowLayoutPanel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbUserAvatar).BeginInit();
            SuspendLayout();
            // 
            // lblMsg
            // 
            lblMsg.AutoSize = true;
            lblMsg.Dock = DockStyle.Fill;
            flowLayoutPanel1.SetFlowBreak(lblMsg, true);
            lblMsg.Location = new Point(3, 0);
            lblMsg.Name = "lblMsg";
            lblMsg.Size = new Size(34, 17);
            lblMsg.TabIndex = 0;
            lblMsg.Text = "Msg";
            lblMsg.UseMnemonic = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(lblMsg);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(374, 17);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // btnExploreFolder
            // 
            btnExploreFolder.AutoSize = true;
            btnExploreFolder.Dock = DockStyle.Fill;
            btnExploreFolder.Location = new Point(103, 3);
            btnExploreFolder.Name = "btnExploreFolder";
            btnExploreFolder.Size = new Size(268, 27);
            btnExploreFolder.TabIndex = 1;
            btnExploreFolder.Text = "浏览文件夹";
            btnExploreFolder.UseVisualStyleBackColor = true;
            btnExploreFolder.Click += btnExploreFolder_Click;
            // 
            // btnExport
            // 
            btnExport.AutoSize = true;
            btnExport.Dock = DockStyle.Fill;
            btnExport.Location = new Point(103, 36);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(268, 27);
            btnExport.TabIndex = 2;
            btnExport.Text = "导出数据文件";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // btnImport
            // 
            btnImport.AutoSize = true;
            btnImport.Dock = DockStyle.Fill;
            btnImport.Location = new Point(103, 69);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(268, 27);
            btnImport.TabIndex = 3;
            btnImport.Text = "导入数据文件";
            btnImport.UseVisualStyleBackColor = true;
            btnImport.Click += btnImport_Click;
            // 
            // btnClearCurrentUser
            // 
            btnClearCurrentUser.AutoSize = true;
            btnClearCurrentUser.Dock = DockStyle.Fill;
            btnClearCurrentUser.Location = new Point(103, 102);
            btnClearCurrentUser.Name = "btnClearCurrentUser";
            btnClearCurrentUser.Size = new Size(268, 27);
            btnClearCurrentUser.TabIndex = 4;
            btnClearCurrentUser.Text = "清空数据文件";
            btnClearCurrentUser.UseVisualStyleBackColor = true;
            btnClearCurrentUser.Click += btnClearCurrentUser_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(pbUserAvatar, 0, 0);
            tableLayoutPanel1.Controls.Add(btnClearCurrentUser, 1, 3);
            tableLayoutPanel1.Controls.Add(btnExploreFolder, 1, 0);
            tableLayoutPanel1.Controls.Add(btnImport, 1, 2);
            tableLayoutPanel1.Controls.Add(btnExport, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 17);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Size = new Size(374, 132);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // pbUserAvatar
            // 
            pbUserAvatar.BorderStyle = BorderStyle.FixedSingle;
            pbUserAvatar.Location = new Point(3, 3);
            pbUserAvatar.Name = "pbUserAvatar";
            tableLayoutPanel1.SetRowSpan(pbUserAvatar, 4);
            pbUserAvatar.Size = new Size(94, 94);
            pbUserAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            pbUserAvatar.TabIndex = 0;
            pbUserAvatar.TabStop = false;
            // 
            // btnSetSavePath
            // 
            btnSetSavePath.AutoSize = true;
            btnSetSavePath.Dock = DockStyle.Top;
            btnSetSavePath.Location = new Point(0, 149);
            btnSetSavePath.Name = "btnSetSavePath";
            btnSetSavePath.Size = new Size(374, 27);
            btnSetSavePath.TabIndex = 6;
            btnSetSavePath.Text = "*设置数据文件保存路径";
            btnSetSavePath.UseVisualStyleBackColor = true;
            btnSetSavePath.Click += btnSetSavePath_Click;
            // 
            // DataFileSettingsPage
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnSetSavePath);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(flowLayoutPanel1);
            Name = "DataFileSettingsPage";
            Size = new Size(374, 402);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbUserAvatar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMsg;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnExploreFolder;
        private Button btnExport;
        private Button btnImport;
        private Button btnClearCurrentUser;
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pbUserAvatar;
        private Button btnSetSavePath;
    }
}
