﻿using PowerAudioPlayer.Controllers;
using PowerAudioPlayer.Controllers.Helper;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace PowerAudioPlayer.UI
{
    partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            rtbAcknowledgement.Text = Resources.Acknowledgement;
            Text = string.Format(Player.GetString("MsgAbout"), Application.ProductName);
            lblArchitecture.Text = string.Format(Player.GetString("ArchitectureMode"), RuntimeInformation.ProcessArchitecture.ToString());
            lblProductName.Text = Application.ProductName;
            lblVersion.Text = string.Format(Player.GetString("MsgVersion"), Assembly.GetExecutingAssembly().GetName().Version);
            lblCompany.Text = string.Format(Player.GetString("Author"), Application.CompanyName);
            lbldotNETVersion.Text = Player.GetString("dotNETVersion", Environment.Version.ToString());
            lblLastCompileTime.Text = Player.GetString("MsgLastCompileTime", File.GetLastWriteTime(GetType().Assembly.Location).ToString());
        }

        private void rtbAcknowledgement_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.LinkText) { UseShellExecute = true });
        }

        private void lblProductName_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo(Player.GetString("ProjectPageURL")) { UseShellExecute = true });
        }
    }
}