namespace AFLA_001
{
    partial class IoForm
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
			iotabControl = new TabControl();
			tabPage1 = new TabPage();
			DiPanel = new FlowLayoutPanel();
			tabPage2 = new TabPage();
			DoPanel = new FlowLayoutPanel();
			iotabControl.SuspendLayout();
			tabPage1.SuspendLayout();
			tabPage2.SuspendLayout();
			SuspendLayout();
			// 
			// iotabControl
			// 
			iotabControl.Controls.Add(tabPage1);
			iotabControl.Controls.Add(tabPage2);
			iotabControl.Location = new Point(0, 0);
			iotabControl.Name = "iotabControl";
			iotabControl.SelectedIndex = 0;
			iotabControl.Size = new Size(1252, 412);
			iotabControl.TabIndex = 0;
			// 
			// tabPage1
			// 
			tabPage1.Controls.Add(DiPanel);
			tabPage1.Location = new Point(4, 24);
			tabPage1.Name = "tabPage1";
			tabPage1.Padding = new Padding(3);
			tabPage1.Size = new Size(1244, 384);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "DI";
			tabPage1.UseVisualStyleBackColor = true;
			// 
			// DiPanel
			// 
			DiPanel.AutoScroll = true;
			DiPanel.Dock = DockStyle.Fill;
			DiPanel.Location = new Point(3, 3);
			DiPanel.Name = "DiPanel";
			DiPanel.Size = new Size(1238, 378);
			DiPanel.TabIndex = 0;
			// 
			// tabPage2
			// 
			tabPage2.Controls.Add(DoPanel);
			tabPage2.Location = new Point(4, 24);
			tabPage2.Name = "tabPage2";
			tabPage2.Padding = new Padding(3);
			tabPage2.Size = new Size(1244, 384);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "DO";
			tabPage2.UseVisualStyleBackColor = true;
			// 
			// DoPanel
			// 
			DoPanel.AutoScroll = true;
			DoPanel.Dock = DockStyle.Fill;
			DoPanel.Location = new Point(3, 3);
			DoPanel.Name = "DoPanel";
			DoPanel.Size = new Size(1238, 378);
			DoPanel.TabIndex = 0;
			// 
			// IoForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1251, 413);
			Controls.Add(iotabControl);
			FormBorderStyle = FormBorderStyle.None;
			Name = "IoForm";
			Text = "IoForm";
			iotabControl.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			tabPage2.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private TabControl iotabControl;
		private TabPage tabPage1;
		private TabPage tabPage2;
		private FlowLayoutPanel DiPanel;
		private FlowLayoutPanel DoPanel;
	}
}