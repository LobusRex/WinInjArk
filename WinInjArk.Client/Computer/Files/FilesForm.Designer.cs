namespace WinInjArk.Client.Computer.Files
{
    partial class FilesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBoxFiles = new ListBox();
            SuspendLayout();
            // 
            // listBoxFiles
            // 
            listBoxFiles.Dock = DockStyle.Fill;
            listBoxFiles.FormattingEnabled = true;
            listBoxFiles.ItemHeight = 15;
            listBoxFiles.Location = new Point(0, 0);
            listBoxFiles.Name = "listBoxFiles";
            listBoxFiles.Size = new Size(329, 450);
            listBoxFiles.TabIndex = 0;
            listBoxFiles.MouseDoubleClick += listBoxFiles_MouseDoubleClick;
            // 
            // FilesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(329, 450);
            Controls.Add(listBoxFiles);
            Name = "FilesForm";
            Text = "Files";
            Load += filesForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxFiles;
    }
}