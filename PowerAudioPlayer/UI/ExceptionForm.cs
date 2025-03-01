using PowerAudioPlayer.Controllers;
using PowerAudioPlayer.Controllers.Helper;
using System.Diagnostics;
using System.IO;
using System.Media;
using System.ComponentModel;
using PowerAudioPlayer.Controllers.Utils;

namespace PowerAudioPlayer.UI
{
    public partial class ExceptionForm : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Exception exception { set; get; } = new Exception();

        public ExceptionForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            string dumpFile = Path.Combine(Path.GetTempPath(), Process.GetCurrentProcess().ProcessName + "_" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".dmp");
            MiniDumpHelper.Write(dumpFile);
            linkLabel.Text = dumpFile;
            textBox.Text = Player.GetString("ErrorMessage", exception.GetType().Name, exception.Message, exception.Data.ToString(), exception.StackTrace, exception.Source, exception.TargetSite?.ToString(), Environment.Version.ToString(), Environment.CommandLine, MiscUtils.RunCommandExeAndReturnOutput("systeminfo.exe", ""));
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MiscUtils.ExploreFile(linkLabel.Text);
        }

        private void ExceptionForm_Load(object sender, EventArgs e)
        {
            SystemSounds.Hand.Play();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void ExceptionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(exception.HResult);
        }
    }
}