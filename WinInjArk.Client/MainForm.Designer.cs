namespace WinInjArk.Client
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			richTextBoxLogs = new RichTextBox();
			SuspendLayout();
			// 
			// richTextBoxLogs
			// 
			richTextBoxLogs.Dock = DockStyle.Left;
			richTextBoxLogs.Location = new Point(0, 0);
			richTextBoxLogs.MinimumSize = new Size(200, 0);
			richTextBoxLogs.Name = "richTextBoxLogs";
			richTextBoxLogs.ReadOnly = true;
			richTextBoxLogs.Size = new Size(200, 450);
			richTextBoxLogs.TabIndex = 0;
			richTextBoxLogs.Text = "";
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(richTextBoxLogs);
			Name = "MainForm";
			Text = "Main form of the WinInjArk client";
			Load += mainForm_Load;
			ResumeLayout(false);
		}

		#endregion

		private RichTextBox richTextBoxLogs;
	}
}
