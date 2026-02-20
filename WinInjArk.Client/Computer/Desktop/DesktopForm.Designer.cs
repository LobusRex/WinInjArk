namespace WinInjArk.Client.Computer.Desktop
{
    partial class DesktopForm
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
            components = new System.ComponentModel.Container();
            buttonFiles = new Button();
            buttonEmail = new Button();
            buttonSettings = new Button();
            timerClock = new System.Windows.Forms.Timer(components);
            labelClock = new Label();
            SuspendLayout();
            // 
            // buttonFiles
            // 
            buttonFiles.Location = new Point(12, 12);
            buttonFiles.Name = "buttonFiles";
            buttonFiles.Size = new Size(75, 75);
            buttonFiles.TabIndex = 0;
            buttonFiles.Text = "Files";
            buttonFiles.UseVisualStyleBackColor = true;
            buttonFiles.Click += buttonFiles_Click;
            // 
            // buttonEmail
            // 
            buttonEmail.Location = new Point(12, 93);
            buttonEmail.Name = "buttonEmail";
            buttonEmail.Size = new Size(75, 75);
            buttonEmail.TabIndex = 1;
            buttonEmail.Text = "Email";
            buttonEmail.UseVisualStyleBackColor = true;
            buttonEmail.Click += buttonEmail_Click;
            // 
            // buttonSettings
            // 
            buttonSettings.Location = new Point(12, 174);
            buttonSettings.Name = "buttonSettings";
            buttonSettings.Size = new Size(75, 75);
            buttonSettings.TabIndex = 2;
            buttonSettings.Text = "Settings";
            buttonSettings.UseVisualStyleBackColor = true;
            buttonSettings.Click += buttonSettings_Click;
            // 
            // timerClock
            // 
            timerClock.Enabled = true;
            timerClock.Tick += timerClock_Tick;
            // 
            // labelClock
            // 
            labelClock.AutoSize = true;
            labelClock.Location = new Point(406, 314);
            labelClock.Name = "labelClock";
            labelClock.Size = new Size(49, 15);
            labelClock.TabIndex = 3;
            labelClock.Text = "00:00:00";
            // 
            // DesktopForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(467, 338);
            Controls.Add(labelClock);
            Controls.Add(buttonSettings);
            Controls.Add(buttonEmail);
            Controls.Add(buttonFiles);
            Name = "DesktopForm";
            Text = "Desktop";
            Load += desktopForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonFiles;
        private Button buttonEmail;
        private Button buttonSettings;
        private System.Windows.Forms.Timer timerClock;
        private Label labelClock;
    }
}