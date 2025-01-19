using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ProgressDialogs {

	public partial class ProgressDialogTest : Form {


		public ProgressDialogTest() {
			InitializeComponent();
		}

		private void btnStart_Click(object sender, EventArgs e) {
			progressDialog.Show();
			progressDialog.Line1 = "This is my operation";
			progressDialog.Line2 = "Something is happening";
			timer.Start();
		}

		private void timer_Tick(object sender, EventArgs e) {
			if (progressDialog.HasUserCancelled) {
				timer.Stop();
				progressDialog.Close();
			}
			else {
				progressDialog.Value++;
				if (progressDialog.Value >= progressDialog.Maximum) {
					timer.Stop();
				}
			}
		}

		private void btnPause_Click(object sender, EventArgs e) {
			timer.Stop();
			progressDialog.Pause();
		}

		private void btnResume_Click(object sender, EventArgs e) {
			timer.Start();
			progressDialog.Resume();
		}

		private void chkCancelButton_CheckedChanged(object sender, EventArgs e) {
			progressDialog.CancelButton = chkCancelButton.Checked;
		}

		private void chkMinimizeButton_CheckedChanged(object sender, EventArgs e) {
			progressDialog.MinimizeButton = chkMinimizeButton.Checked;
		}

		private void chkProgressBar_CheckedChanged(object sender, EventArgs e) {
			progressDialog.ProgressBar = chkProgressBar.Checked;
		}

		private void chkMarquee_CheckedChanged(object sender, EventArgs e) {
			progressDialog.Marquee = chkMarquee.Checked;
		}

		private void chkModal_CheckedChanged(object sender, EventArgs e) {
			progressDialog.Modal = chkModal.Checked;
		}
	}
}
