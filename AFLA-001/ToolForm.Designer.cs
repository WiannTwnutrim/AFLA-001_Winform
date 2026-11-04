namespace AFLA_001
{
    partial class ToolForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolForm));
            toolbtn = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label1 = new Label();
            prebtn = new Button();
            SuspendLayout();
            // 
            // toolbtn
            // 
            toolbtn.Font = new Font("Microsoft JhengHei UI", 14F);
            toolbtn.Location = new Point(17, 54);
            toolbtn.Name = "toolbtn";
            toolbtn.Size = new Size(171, 41);
            toolbtn.TabIndex = 1;
            toolbtn.Text = "VaccumOn";
            toolbtn.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Font = new Font("Microsoft JhengHei UI", 14F);
            button1.Location = new Point(15, 121);
            button1.Name = "button1";
            button1.Size = new Size(171, 41);
            button1.TabIndex = 2;
            button1.Text = "VaccumOff";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Font = new Font("Microsoft JhengHei UI", 14F);
            button2.Location = new Point(15, 184);
            button2.Name = "button2";
            button2.Size = new Size(171, 41);
            button2.TabIndex = 3;
            button2.Text = "IPA Test";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Font = new Font("Microsoft JhengHei UI", 14F);
            button3.Location = new Point(17, 258);
            button3.Name = "button3";
            button3.Size = new Size(171, 41);
            button3.TabIndex = 4;
            button3.Text = "OIL Test";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Font = new Font("Microsoft JhengHei UI", 14F);
            button4.Location = new Point(15, 325);
            button4.Name = "button4";
            button4.Size = new Size(171, 41);
            button4.TabIndex = 5;
            button4.Text = "GLUE Test";
            button4.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 20F);
            label1.Location = new Point(17, 7);
            label1.Name = "label1";
            label1.Size = new Size(71, 35);
            label1.TabIndex = 6;
            label1.Text = "Tool";
            // 
            // prebtn
            // 
            prebtn.Font = new Font("Microsoft JhengHei UI", 10F);
            prebtn.Image = (Image)resources.GetObject("prebtn.Image");
            prebtn.Location = new Point(124, 7);
            prebtn.Name = "prebtn";
            prebtn.Size = new Size(51, 41);
            prebtn.TabIndex = 7;
            prebtn.UseVisualStyleBackColor = true;
            prebtn.Click += prebtn_Click;
            // 
            // ToolForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(200, 408);
            Controls.Add(prebtn);
            Controls.Add(label1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(toolbtn);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ToolForm";
            Text = "ToolForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button toolbtn;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label label1;
        private Button prebtn;
    }
}