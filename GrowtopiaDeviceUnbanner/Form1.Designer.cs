namespace GrowtopiaDeviceUnbanner
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnChangeReg = new Button();
            lblStatus = new Label();
            rtbLog = new RichTextBox();
            SuspendLayout();
            // 
            // btnChangeReg
            // 
            btnChangeReg.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnChangeReg.Location = new Point(281, 166);
            btnChangeReg.Name = "btnChangeReg";
            btnChangeReg.Size = new Size(222, 47);
            btnChangeReg.TabIndex = 0;
            btnChangeReg.Text = "Delete Regedit ID's";
            btnChangeReg.UseVisualStyleBackColor = true;
            btnChangeReg.Click += btnChangeReg_Click;
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblStatus.Location = new Point(236, 94);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(316, 69);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Click the button below to start the process..";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // rtbLog
            // 
            rtbLog.Location = new Point(236, 244);
            rtbLog.Name = "rtbLog";
            rtbLog.Size = new Size(316, 194);
            rtbLog.TabIndex = 2;
            rtbLog.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rtbLog);
            Controls.Add(lblStatus);
            Controls.Add(btnChangeReg);
            Name = "Form1";
            Text = "GT Device Unbanner";
            ResumeLayout(false);
        }

        #endregion

        private Button btnChangeReg;
		private Label lblStatus;
        private RichTextBox rtbLog;
    }
}