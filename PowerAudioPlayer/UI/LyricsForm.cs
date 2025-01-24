using PowerAudioPlayer.Controllers;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;
using PowerAudioPlayer.Model;
using PowerAudioPlayer.Controllers.Helper;

namespace PowerAudioPlayer.UI
{
    public partial class LyricsForm : Form
    {
        private readonly WindowStateManager windowStateManager;
        public LyricsForm()
        {
            InitializeComponent();
            windowStateManager = new WindowStateManager(this);
            windowStateManager.LoadState();
            lyricsView.DataBindings.Add("HighlightColor", Settings.Default, "LyricsHighlightColor", true, DataSourceUpdateMode.OnPropertyChanged);
            lyricsView.DataBindings.Add("LineMargin", Settings.Default, "LyricsItemsMargin", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case Player.WM_LOADLYRICS:
                    LoadLyrics();
                    break;
                case Player.WM_CLEARLRC:
                    lyricsView.ClearLyrics();
                    break;
                case Player.WM_LRCROLL:
                    ScrollLyrics(m.WParam);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        private void ScrollLyrics(double nowTime)
        {
            lyricsView.RollTo(nowTime);
        }

        private void LoadLyrics()
        {
            string lrc = string.Empty;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            lyricsView.ClearLyrics();
            if (Player.Core.GetChannelInfo().type == AudioType.MIDI)
            {
                lrc = Player.Core.GetMIDILyrics();
            }
            else
            {
                int index = Player.playIndex;
                if (index != -1)
                {
                    string file = Path.GetDirectoryName(PlaylistHelper.ActivePlaylist.Items[Player.playIndex].File) + "\\" + Path.GetFileNameWithoutExtension(PlaylistHelper.ActivePlaylist.Items[Player.playIndex].File) + ".lrc";
                    if (File.Exists(file))
                    {
                        using FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read);
                        using StreamReader sr = new StreamReader(fs);
                        string? line;
                        while ((line = sr.ReadLine()) != null)
                            if (line != "" && Regex.IsMatch(line, @"\[(\d+:\d+\.\d+)\]"))
                                lrc += line + "\n\n\n\n";
                    }
                }
            }
            lyricsView.LoadLyrics(lrc);
        }

        private void LyricsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                windowStateManager.SaveState();
            Hide();
            e.Cancel = true;
        }

        private void LyricsForm_ForeColorChanged(object sender, EventArgs e)
        {
            lyricsView.ForeColor = ForeColor;
        }
    }
}