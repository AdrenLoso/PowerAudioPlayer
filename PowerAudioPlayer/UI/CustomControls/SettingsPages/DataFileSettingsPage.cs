using PowerAudioPlayer.Controllers;
using PowerAudioPlayer.Controllers.Utils;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;

namespace PowerAudioPlayer.UI.CustomControls.SettingsPages
{
    public partial class DataFileSettingsPage : UserControl
    {
        public DataFileSettingsPage()
        {
            InitializeComponent();
            if (Player.GetDataFilePath() == DataFilePath.Program)
            {
                lblMsg.Text = Player.GetString("MsgDataFile2", Player.GetExactDataFilePath());
                pbUserAvatar.Visible = false;
            }
            else
            {
                lblMsg.Text = Player.GetString("MsgDataFile1", MiscUtils.GetCurrentUserFullName(), Player.GetExactDataFilePath());
            }
            pbUserAvatar.Load(MiscUtils.GetCurrentUserAvatarPath());
            MiscUtils.AddShieldToButton(btnSetSavePath);
        }

        private void btnExploreFolder_Click(object sender, EventArgs e)
        {
            MiscUtils.ExploreFile(Player.GetExactDataFilePath());
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = Player.GetString("FilterZIP");
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Player.SaveDataFile();
                if (File.Exists(saveFileDialog.FileName))
                    File.Delete(saveFileDialog.FileName);
                ZipFile.CreateFromDirectory(Player.GetExactDataFilePath(), saveFileDialog.FileName);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = Player.GetString("FilterZIP");
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Directory.Delete(Player.GetExactDataFilePath(), true);
                    Directory.CreateDirectory(Player.GetExactDataFilePath());
                    ZipFile.ExtractToDirectory(openFileDialog.FileName, Player.GetExactDataFilePath());
                    MessageBox.Show(Player.GetString("MsgDataFileImportOK"), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Restart();
                    Process.GetCurrentProcess().Kill();
                }
                catch
                {
                    MessageBox.Show(Player.GetString("MsgDataFileImportError"), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClearCurrentUser_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Player.GetDataFilePath() == DataFilePath.LocalAppData ? Player.GetString("MsgClearDataFile1", MiscUtils.GetCurrentUserFullName()) : Player.GetString("MsgClearDataFile2"), Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Directory.Delete(Player.GetExactDataFilePath(), true);
                MessageBox.Show(Player.GetString("MsgClearDataFileOK"), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Restart();
                Process.GetCurrentProcess().Kill();
            }
        }

        private void btnSetSavePath_Click(object sender, EventArgs e)
        {
            if(MiscUtils.IsRunAsAdministrator())
            {
                var radioButton1 = new TaskDialogRadioButton(Player.GetString("SaveToLocalAppData"));
                var radioButton2 = new TaskDialogRadioButton(Player.GetString("SaveToProgramPath"));
                if(Player.GetDataFilePath() == DataFilePath.LocalAppData)
                    radioButton1.Checked = true;
                else
                    radioButton2.Checked = true;
                var page = new TaskDialogPage()
                {
                    Caption = Application.ProductName ?? string.Empty,
                    Heading = Player.GetString("MsgSetDataFileSavePath1"),
                    Text = Player.GetString("MsgSetDataFileSavePath2"),
                    Icon = TaskDialogIcon.ShieldBlueBar,
                    Buttons = [TaskDialogButton.OK, TaskDialogButton.Cancel],
                    RadioButtons = [radioButton1, radioButton2],
                };
                if (TaskDialog.ShowDialog(Handle, page) == TaskDialogButton.OK)
                {
                    if (radioButton1.Checked)
                        Player.SetDataFilePath(DataFilePath.LocalAppData);
                    else
                        Player.SetDataFilePath(DataFilePath.Program);
                }
            }
            else
            {
                if(MessageBox.Show(Player.GetString("MsgRunAsAdministrator"), Application.ProductName ?? string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        Player.SaveDataFile();
                        ProcessStartInfo psi = new ProcessStartInfo
                        {
                            WorkingDirectory = Environment.CurrentDirectory,
                            FileName = Application.ExecutablePath,
                            UseShellExecute = true,
                            Verb = "runas"
                        };
                        Process process = new Process
                        {
                            StartInfo = psi
                        };
                        process.Start();
                        Process.GetCurrentProcess().Kill();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, Application.ProductName ?? string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}