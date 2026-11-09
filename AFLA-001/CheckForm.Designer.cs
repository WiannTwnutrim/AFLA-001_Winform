namespace AFLA_001
{
    partial class CheckForm
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
            yesbtn = new Button();
            label1 = new Label();
            Nobtn = new Button();
            SuspendLayout();
            // 
            // yesbtn
            // 
            yesbtn.DialogResult = DialogResult.Yes;
            yesbtn.Font = new Font("Microsoft JhengHei UI", 15F);
            yesbtn.Location = new Point(60, 133);
            yesbtn.Name = "yesbtn";
            yesbtn.Size = new Size(90, 35);
            yesbtn.TabIndex = 6;
            yesbtn.Text = "Yes";
            yesbtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 20F);
            label1.Location = new Point(60, 70);
            label1.Name = "label1";
            label1.Size = new Size(271, 35);
            label1.TabIndex = 8;
            label1.Text = "ExcecuteCommand?";
            // 
            // Nobtn
            // 
            Nobtn.Font = new Font("Microsoft JhengHei UI", 15F);
            Nobtn.Location = new Point(224, 133);
            Nobtn.Name = "Nobtn";
            Nobtn.Size = new Size(90, 35);
            Nobtn.TabIndex = 9;
            Nobtn.Text = "No";
            Nobtn.UseVisualStyleBackColor = true;
            Nobtn.Click += Nobtn_Click;
            // 
            // CheckForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(388, 265);
            Controls.Add(Nobtn);
            Controls.Add(label1);
            Controls.Add(yesbtn);
            Name = "CheckForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ExcecuteCommand";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button yesbtn;
        private Label label1;
        private Button Nobtn;
    }
}