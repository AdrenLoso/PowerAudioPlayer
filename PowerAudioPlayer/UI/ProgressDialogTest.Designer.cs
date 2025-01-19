namespace ProgressDialogs {
	partial class ProgressDialogTest {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.btnStart = new System.Windows.Forms.Button();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.btnPause = new System.Windows.Forms.Button();
			this.btnResume = new System.Windows.Forms.Button();
			this.chkCancelButton = new System.Windows.Forms.CheckBox();
			this.chkMinimizeButton = new System.Windows.Forms.CheckBox();
			this.chkProgressBar = new System.Windows.Forms.CheckBox();
			this.chkMarquee = new System.Windows.Forms.CheckBox();
			this.chkModal = new System.Windows.Forms.CheckBox();
			this.progressDialog = new WinFormsExtendedControls.ExtendedForms.ProgressDialog(this.components);
			this.SuspendLayout();
			// 
			// btnStart
			// 
			this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnStart.Location = new System.Drawing.Point(136, 179);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(75, 23);
			this.btnStart.TabIndex = 0;
			this.btnStart.Text = "Start";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// timer
			// 
			this.timer.Interval = 150;
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// btnPause
			// 
			this.btnPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPause.Location = new System.Drawing.Point(217, 179);
			this.btnPause.Name = "btnPause";
			this.btnPause.Size = new System.Drawing.Size(75, 23);
			this.btnPause.TabIndex = 1;
			this.btnPause.Text = "Pause";
			this.btnPause.UseVisualStyleBackColor = true;
			this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
			// 
			// btnResume
			// 
			this.btnResume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnResume.Location = new System.Drawing.Point(298, 179);
			this.btnResume.Name = "btnResume";
			this.btnResume.Size = new System.Drawing.Size(75, 23);
			this.btnResume.TabIndex = 2;
			this.btnResume.Text = "Resume";
			this.btnResume.UseVisualStyleBackColor = true;
			this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
			// 
			// chkCancelButton
			// 
			this.chkCancelButton.AutoSize = true;
			this.chkCancelButton.Checked = true;
			this.chkCancelButton.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkCancelButton.Location = new System.Drawing.Point(12, 12);
			this.chkCancelButton.Name = "chkCancelButton";
			this.chkCancelButton.Size = new System.Drawing.Size(90, 17);
			this.chkCancelButton.TabIndex = 3;
			this.chkCancelButton.Text = "CancelButton";
			this.chkCancelButton.UseVisualStyleBackColor = true;
			this.chkCancelButton.CheckedChanged += new System.EventHandler(this.chkCancelButton_CheckedChanged);
			// 
			// chkMinimizeButton
			// 
			this.chkMinimizeButton.AutoSize = true;
			this.chkMinimizeButton.Checked = true;
			this.chkMinimizeButton.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkMinimizeButton.Location = new System.Drawing.Point(12, 35);
			this.chkMinimizeButton.Name = "chkMinimizeButton";
			this.chkMinimizeButton.Size = new System.Drawing.Size(97, 17);
			this.chkMinimizeButton.TabIndex = 4;
			this.chkMinimizeButton.Text = "MinimizeButton";
			this.chkMinimizeButton.UseVisualStyleBackColor = true;
			this.chkMinimizeButton.CheckedChanged += new System.EventHandler(this.chkMinimizeButton_CheckedChanged);
			// 
			// chkProgressBar
			// 
			this.chkProgressBar.AutoSize = true;
			this.chkProgressBar.Checked = true;
			this.chkProgressBar.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkProgressBar.Location = new System.Drawing.Point(12, 58);
			this.chkProgressBar.Name = "chkProgressBar";
			this.chkProgressBar.Size = new System.Drawing.Size(83, 17);
			this.chkProgressBar.TabIndex = 5;
			this.chkProgressBar.Text = "ProgressBar";
			this.chkProgressBar.UseVisualStyleBackColor = true;
			this.chkProgressBar.CheckedChanged += new System.EventHandler(this.chkProgressBar_CheckedChanged);
			// 
			// chkMarquee
			// 
			this.chkMarquee.AutoSize = true;
			this.chkMarquee.Location = new System.Drawing.Point(12, 81);
			this.chkMarquee.Name = "chkMarquee";
			this.chkMarquee.Size = new System.Drawing.Size(68, 17);
			this.chkMarquee.TabIndex = 6;
			this.chkMarquee.Text = "Marquee";
			this.chkMarquee.UseVisualStyleBackColor = true;
			this.chkMarquee.CheckedChanged += new System.EventHandler(this.chkMarquee_CheckedChanged);
			// 
			// chkModal
			// 
			this.chkModal.AutoSize = true;
			this.chkModal.Location = new System.Drawing.Point(12, 104);
			this.chkModal.Name = "chkModal";
			this.chkModal.Size = new System.Drawing.Size(55, 17);
			this.chkModal.TabIndex = 7;
			this.chkModal.Text = "Modal";
			this.chkModal.UseVisualStyleBackColor = true;
			this.chkModal.CheckedChanged += new System.EventHandler(this.chkModal_CheckedChanged);
			// 
			// ProgressDialogTest
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(385, 214);
			this.Controls.Add(this.chkModal);
			this.Controls.Add(this.chkMarquee);
			this.Controls.Add(this.chkProgressBar);
			this.Controls.Add(this.chkMinimizeButton);
			this.Controls.Add(this.chkCancelButton);
			this.Controls.Add(this.btnResume);
			this.Controls.Add(this.btnPause);
			this.Controls.Add(this.btnStart);
			this.Name = "ProgressDialogTest";
			this.Text = "ProgressDialog Test";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.Button btnPause;
		private System.Windows.Forms.Button btnResume;
		private System.Windows.Forms.CheckBox chkCancelButton;
		private System.Windows.Forms.CheckBox chkMinimizeButton;
		private System.Windows.Forms.CheckBox chkProgressBar;
		private System.Windows.Forms.CheckBox chkMarquee;
		private System.Windows.Forms.CheckBox chkModal;
		private WinFormsExtendedControls.ExtendedForms.ProgressDialog progressDialog;
	}
}

