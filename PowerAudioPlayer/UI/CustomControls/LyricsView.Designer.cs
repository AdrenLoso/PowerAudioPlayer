namespace PowerAudioPlayer.UI.CustomControls
{
    partial class LyricsView
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
            surface = new SkiaSharp.Views.Desktop.SKGLControl();
            contextMenuStrip = new ContextMenuStrip(components);
            tsmiCopyCurrentLine = new ToolStripMenuItem();
            tsmiCopyAlline = new ToolStripMenuItem();
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // surface
            // 
            surface.ContextMenuStrip = contextMenuStrip;
            surface.Dock = DockStyle.Fill;
            surface.Location = new Point(0, 0);
            surface.Name = "surface";
            surface.Size = new Size(270, 345);
            surface.TabIndex = 0;
            surface.Text = "skControl1";
            surface.PaintSurface += surface_PaintSurface;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { tsmiCopyCurrentLine, tsmiCopyAlline });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new Size(181, 70);
            // 
            // tsmiCopyCurrentLine
            // 
            tsmiCopyCurrentLine.Name = "tsmiCopyCurrentLine";
            tsmiCopyCurrentLine.Size = new Size(180, 22);
            tsmiCopyCurrentLine.Text = "复制当前歌词";
            tsmiCopyCurrentLine.Click += tsmiCopyCurrentLine_Click;
            // 
            // tsmiCopyAlline
            // 
            tsmiCopyAlline.Name = "tsmiCopyAlline";
            tsmiCopyAlline.Size = new Size(180, 22);
            tsmiCopyAlline.Text = "复制全部歌词";
            tsmiCopyAlline.Click += tsmiCopyAlline_Click;
            // 
            // LyricsView
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(surface);
            Name = "LyricsView";
            Size = new Size(270, 345);
            SizeChanged += LyricsView_SizeChanged;
            contextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SkiaSharp.Views.Desktop.SKGLControl surface;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem tsmiCopyCurrentLine;
        private ToolStripMenuItem tsmiCopyAlline;
    }
}
