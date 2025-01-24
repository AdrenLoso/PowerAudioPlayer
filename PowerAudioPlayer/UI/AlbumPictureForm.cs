using PowerAudioPlayer.Controllers;

namespace PowerAudioPlayer.UI
{
    public partial class AlbumPictureForm : Form
    {
        private readonly WindowStateManager windowStateManager;

        public AlbumPictureForm()
        {
            InitializeComponent();
            windowStateManager = new WindowStateManager(this);
            windowStateManager.LoadState();
        }

        private void AlbumPictureForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                windowStateManager.SaveState();
            Hide();
            e.Cancel = true;
        }

        public void SetAlbumPicture(Image? image)
        {
            skpbAlbumPicture.Image = image;
        }

        public void ClearAlbumPicture()
        {
            skpbAlbumPicture.Image = null;
        }
    }
}