using PowerAudioPlayer.Controllers.Helper;

namespace PowerAudioPlayer.Model
{
    public class PlayerChannelInfo
    {
        public int freq;
        public int chans;
        public AudioType type;

        public override string ToString()
        {
            return string.Format("{0}, {1}Hz, {2}", AudioInfoHelper.AudioTypeToString(type), freq, AudioInfoHelper.ChannelNumberToString(chans));
        }
    }
}
