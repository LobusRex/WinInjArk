namespace WinInjArk.Client
{
	partial class DomainObjectForm
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
			textBoxId = new TextBox();
			textBoxName = new TextBox();
			textBoxDescription = new TextBox();
			label1 = new Label();
			label2 = new Label();
			label3 = new Label();
			SuspendLayout();
			// 
			// textBoxId
			// 
			textBoxId.Location = new Point(85, 6);
			textBoxId.Name = "textBoxId";
			textBoxId.ReadOnly = true;
			textBoxId.Size = new Size(290, 23);
			textBoxId.TabIndex = 0;
			// 
			// textBoxName
			// 
			textBoxName.Location = new Point(85, 35);
			textBoxName.Name = "textBoxName";
			textBoxName.ReadOnly = true;
			textBoxName.Size = new Size(290, 23);
			textBoxName.TabIndex = 1;
			// 
			// textBoxDescription
			// 
			textBoxDescription.Location = new Point(85, 64);
			textBoxDescription.Name = "textBoxDescription";
			textBoxDescription.ReadOnly = true;
			textBoxDescription.Size = new Size(290, 23);
			textBoxDescription.TabIndex = 2;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(12, 9);
			label1.Name = "label1";
			label1.Size = new Size(18, 15);
			label1.TabIndex = 3;
			label1.Text = "ID";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(12, 38);
			label2.Name = "label2";
			label2.Size = new Size(39, 15);
			label2.TabIndex = 4;
			label2.Text = "Name";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(12, 67);
			label3.Name = "label3";
			label3.Size = new Size(67, 15);
			label3.TabIndex = 5;
			label3.Text = "Description";
			// 
			// DomainObjectForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(387, 152);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(textBoxDescription);
			Controls.Add(textBoxName);
			Controls.Add(textBoxId);
			Name = "DomainObjectForm";
			Text = "Domain Object";
			Load += domainObjectForm_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox textBoxId;
		private TextBox textBoxName;
		private TextBox textBoxDescription;
		private Label label1;
		private Label label2;
		private Label label3;
	}
}