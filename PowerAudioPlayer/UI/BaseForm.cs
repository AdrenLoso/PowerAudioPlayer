using PowerAudioPlayer.Controllers;

namespace PowerAudioPlayer.UI
{
    public class BaseForm : Form
    {
        public BaseForm()
        {
            int backdropType = NativeAPI.DWMSBT_TRANSIENTWINDOW;
            NativeAPI.DwmSetWindowAttribute(Handle, NativeAPI.DWMWA_SYSTEMBACKDROP_TYPE, ref backdropType, sizeof(int));
        }
    }
}