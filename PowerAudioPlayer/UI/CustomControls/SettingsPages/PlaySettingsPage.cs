using Un4seen.Bass;
using PowerAudioPlayer.Controllers;
using PowerAudioPlayer.Controllers.PlayerCore;
using System.ComponentModel;
using MiscUtils = PowerAudioPlayer.Controllers.Utils.MiscUtils;

namespace PowerAudioPlayer.UI.CustomControls.SettingsPages
{
    public partial class PlaySettingsPage : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Form? Owner
        {
            get; set;
        }

        public PlaySettingsPage()
        {
            InitializeComponent();
            if (!MiscUtils.IsDesignMode())
            {
                for (int i = 1; i < Bass.BASS_GetDeviceCount(); i++)
                {
                    var devInfo = Bass.BASS_GetDeviceInfo(i);
                    cmbDevice.Items.Add($"{i}.{devInfo.name}");
                }
            }
            Binding binding = new Binding("SelectedIndex", Settings.Default, "OutputDevice", true, DataSourceUpdateMode.OnPropertyChanged);
            binding.Format += delegate (object? sender, ConvertEventArgs e) { e.Value = (int)e.Value + 1; };
            binding.Parse += delegate (object? sender, ConvertEventArgs e) { e.Value = (int)e.Value - 1; };
            cmbDevice.DataBindings.Add(binding);
            binding = new Binding("SelectedFile", Settings.Default, "MIDISoundFont", true, DataSourceUpdateMode.OnPropertyChanged);
            binding.Parse += delegate (object? sender, ConvertEventArgs e) { Player.Core.SetMIDISoundFont((string)e.Value); };
            tbMIDISoundFont.DataBindings.Add(binding);
            tbMIDISoundFont.FileFilter = !MiscUtils.IsDesignMode() ? Player.GetString("FilterMIDISoundFont") : "All|*.*";
            binding = new Binding("Value", Settings.Default, "MIDIVoices", true, DataSourceUpdateMode.OnPropertyChanged);
            binding.Parse += delegate (object? sender, ConvertEventArgs e) { Player.Core.SetConfig(PlayerCoreConfig.MIDIVoices, Convert.ToInt32(e.Value)); };
            numMIDIVoices.DataBindings.Add(binding);
            binding = new Binding("Value", Settings.Default, "PlayBuffer", true, DataSourceUpdateMode.OnPropertyChanged);
            binding.Parse += delegate (object? sender, ConvertEventArgs e) { Player.Core.SetConfig(PlayerCoreConfig.PlayBuffer, Convert.ToInt32(e.Value)); };
            numPlayBuffer.DataBindings.Add(binding);
            binding = new Binding("Value", Settings.Default, "NetTimeOut", true, DataSourceUpdateMode.OnPropertyChanged);
            binding.Parse += delegate (object? sender, ConvertEventArgs e) { Player.Core.SetConfig(PlayerCoreConfig.NetTimeOut, Convert.ToInt32(e.Value)); };
            numTimeOut.DataBindings.Add(binding);
            binding = new Binding("Value", Settings.Default, "NetBuffer", true, DataSourceUpdateMode.OnPropertyChanged);
            binding.Parse += delegate (object? sender, ConvertEventArgs e) { Player.Core.SetConfig(PlayerCoreConfig.NetBuffer, Convert.ToInt32(e.Value)); };
            numNetBuffer.DataBindings.Add(binding);
            cbStopPlayingWhenError.DataBindings.Add("Checked", Settings.Default, "StopPlayingWhenError", true, DataSourceUpdateMode.OnPropertyChanged);
            AddRadioCheckedBinding(rbCoreBASS, Settings.Default, "PlayerCore", PlayerCores.BASS);
            AddRadioCheckedBinding(rbCoreMCI, Settings.Default, "PlayerCore", PlayerCores.MCI);
        }

        private void AddRadioCheckedBinding<T>(RadioButton radio, object dataSource, string dataMember, T trueValue)
        {
            var binding = new Binding(nameof(RadioButton.Checked), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
            binding.Parse += (s, a) => { if (a.Value is bool value && value) a.Value = trueValue; };
            binding.Format += (s, a) => a.Value = a.Value != null && ((T)a.Value).Equals(trueValue);
            radio.DataBindings.Add(binding);
        }
    }
}