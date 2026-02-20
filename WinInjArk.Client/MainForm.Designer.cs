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
            buttonOpenDomainObjects = new Button();
            buttonDesktop = new Button();
            SuspendLayout();
            // 
            // richTextBoxLogs
            // 
            richTextBoxLogs.Dock = DockStyle.Left;
            richTextBoxLogs.Location = new Point(0, 0);
            richTextBoxLogs.MinimumSize = new Size(400, 0);
            richTextBoxLogs.Name = "richTextBoxLogs";
            richTextBoxLogs.ReadOnly = true;
            richTextBoxLogs.Size = new Size(400, 450);
            richTextBoxLogs.TabIndex = 0;
            richTextBoxLogs.Text = "";
            richTextBoxLogs.WordWrap = false;
            // 
            // buttonOpenDomainObjects
            // 
            buttonOpenDomainObjects.AutoSize = true;
            buttonOpenDomainObjects.Location = new Point(406, 12);
            buttonOpenDomainObjects.Name = "buttonOpenDomainObjects";
            buttonOpenDomainObjects.Size = new Size(150, 25);
            buttonOpenDomainObjects.TabIndex = 1;
            buttonOpenDomainObjects.Text = "Open List Form";
            buttonOpenDomainObjects.UseVisualStyleBackColor = true;
            buttonOpenDomainObjects.Click += buttonOpenDomainObjects_Click;
            // 
            // buttonDesktop
            // 
            buttonDesktop.Location = new Point(406, 43);
            buttonDesktop.Name = "buttonDesktop";
            buttonDesktop.Size = new Size(150, 23);
            buttonDesktop.TabIndex = 2;
            buttonDesktop.Text = "Open Desktop";
            buttonDesktop.UseVisualStyleBackColor = true;
            buttonDesktop.Click += buttonDesktop_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonDesktop);
            Controls.Add(buttonOpenDomainObjects);
            Controls.Add(richTextBoxLogs);
            Name = "MainForm";
            Text = "Main form of the WinInjArk client";
            Load += mainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox richTextBoxLogs;
		private Button buttonOpenDomainObjects;
        private Button buttonDesktop;
    }
}
