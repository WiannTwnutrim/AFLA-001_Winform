namespace AFLA_001
{
    partial class ManualValueForm
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
            Manualvaluetxt = new TextBox();
            checkManulvaluebtn = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // Manualvaluetxt
            // 
            Manualvaluetxt.Font = new Font("Microsoft JhengHei UI", 15F);
            Manualvaluetxt.Location = new Point(118, 58);
            Manualvaluetxt.Name = "Manualvaluetxt";
            Manualvaluetxt.Size = new Size(158, 33);
            Manualvaluetxt.TabIndex = 0;
            // 
            // checkManulvaluebtn
            // 
            checkManulvaluebtn.Font = new Font("Microsoft JhengHei UI", 15F);
            checkManulvaluebtn.Location = new Point(118, 112);
            checkManulvaluebtn.Name = "checkManulvaluebtn";
            checkManulvaluebtn.Size = new Size(158, 41);
            checkManulvaluebtn.TabIndex = 1;
            checkManulvaluebtn.Text = "確認";
            checkManulvaluebtn.UseVisualStyleBackColor = true;
            checkManulvaluebtn.Click += checkManulvaluebtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 20F);
            label1.Location = new Point(118, 9);
            label1.Name = "label1";
            label1.Size = new Size(150, 35);
            label1.TabIndex = 2;
            label1.Text = "請輸入數字";
            // 
            // ManualValueForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 175);
            Controls.Add(label1);
            Controls.Add(checkManulvaluebtn);
            Controls.Add(Manualvaluetxt);
            Name = "ManualValueForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ManualValueForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Manualvaluetxt;
        private Button checkManulvaluebtn;
        private Label label1;
    }
}