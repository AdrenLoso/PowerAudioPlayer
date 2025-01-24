namespace PowerAudioPlayer.UI
{
    partial class AlbumPictureForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlbumPictureForm));
            skpbAlbumPicture = new CustomControls.SKPictureBox();
            SuspendLayout();
            // 
            // skpbAlbumPicture
            // 
            skpbAlbumPicture.BackColor = SystemColors.Control;
            skpbAlbumPicture.Dock = DockStyle.Fill;
            skpbAlbumPicture.Image = null;
            skpbAlbumPicture.Location = new Point(0, 0);
            skpbAlbumPicture.Margin = new Padding(4, 4, 4, 4);
            skpbAlbumPicture.Name = "skpbAlbumPicture";
            skpbAlbumPicture.Size = new Size(184, 161);
            skpbAlbumPicture.SizeMode = CustomControls.SKPictureBoxSizeMode.Zoom;
            skpbAlbumPicture.TabIndex = 0;
            skpbAlbumPicture.VSync = true;
            // 
            // AlbumPictureForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(184, 161);
            Controls.Add(skpbAlbumPicture);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AlbumPictureForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "专辑图片";
            FormClosing += AlbumPictureForm_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        private CustomControls.SKPictureBox skpbAlbumPicture;
    }
}