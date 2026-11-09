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
			testpicture = new PictureBox();
			label1 = new Label();
			((System.ComponentModel.ISupportInitialize)testpicture).BeginInit();
			SuspendLayout();
			// 
			// testpicture
			// 
			testpicture.Image = Properties.Resources.HMI_Indicator_OFF;
			testpicture.Location = new Point(74, 40);
			testpicture.Name = "testpicture";
			testpicture.Size = new Size(128, 128);
			testpicture.SizeMode = PictureBoxSizeMode.AutoSize;
			testpicture.TabIndex = 0;
			testpicture.TabStop = false;
			testpicture.Click += pictureBox1_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Microsoft JhengHei UI", 20F);
			label1.Location = new Point(248, 91);
			label1.Name = "label1";
			label1.Size = new Size(123, 35);
			label1.TabIndex = 1;
			label1.Text = "觸發警報";
			// 
			// IoForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1251, 413);
			Controls.Add(label1);
			Controls.Add(testpicture);
			FormBorderStyle = FormBorderStyle.None;
			Name = "IoForm";
			Text = "IoForm";
			((System.ComponentModel.ISupportInitialize)testpicture).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private PictureBox testpicture;
		private Label label1;
	}
}