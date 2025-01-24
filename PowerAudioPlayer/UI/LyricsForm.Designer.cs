namespace PowerAudioPlayer.UI
{
    partial class LyricsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LyricsForm));
            lyricsView = new CustomControls.LyricsView();
            SuspendLayout();
            // 
            // lyricsView
            // 
            lyricsView.Dock = DockStyle.Fill;
            lyricsView.Location = new Point(0, 0);
            lyricsView.Name = "lyricsView";
            lyricsView.Size = new Size(365, 392);
            lyricsView.TabIndex = 0;
            // 
            // LyricsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(365, 392);
            Controls.Add(lyricsView);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimizeBox = false;
            Name = "LyricsForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "歌词";
            FormClosing += LyricsForm_FormClosing;
            ForeColorChanged += LyricsForm_ForeColorChanged;
            ResumeLayout(false);
        }

        #endregion

        private CustomControls.LyricsView lyricsView;
    }
}