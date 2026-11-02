namespace AFLA_001
{
    partial class AddUserForm
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
            groupBox1 = new GroupBox();
            acccess3 = new RadioButton();
            acccess2 = new RadioButton();
            acccess1 = new RadioButton();
            addresult = new TextBox();
            passwordtxt = new TextBox();
            label2 = new Label();
            label1 = new Label();
            sureadduserbtn = new Button();
            accounttxt = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(acccess3);
            groupBox1.Controls.Add(acccess2);
            groupBox1.Controls.Add(acccess1);
            groupBox1.Font = new Font("Microsoft JhengHei UI", 20F);
            groupBox1.Location = new Point(552, 30);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(237, 210);
            groupBox1.TabIndex = 29;
            groupBox1.TabStop = false;
            groupBox1.Text = "Access";
            // 
            // acccess3
            // 
            acccess3.AutoSize = true;
            acccess3.Location = new Point(17, 118);
            acccess3.Name = "acccess3";
            acccess3.Size = new Size(142, 39);
            acccess3.TabIndex = 2;
            acccess3.Text = "Access C";
            acccess3.UseVisualStyleBackColor = true;
            // 
            // acccess2
            // 
            acccess2.AutoSize = true;
            acccess2.Location = new Point(17, 75);
            acccess2.Name = "acccess2";
            acccess2.Size = new Size(141, 39);
            acccess2.TabIndex = 1;
            acccess2.Text = "Access B";
            acccess2.UseVisualStyleBackColor = true;
            // 
            // acccess1
            // 
            acccess1.AutoSize = true;
            acccess1.Checked = true;
            acccess1.Location = new Point(17, 38);
            acccess1.Name = "acccess1";
            acccess1.Size = new Size(143, 39);
            acccess1.TabIndex = 0;
            acccess1.TabStop = true;
            acccess1.Text = "Access A";
            acccess1.UseVisualStyleBackColor = true;
            // 
            // addresult
            // 
            addresult.Font = new Font("Microsoft JhengHei UI", 20F);
            addresult.Location = new Point(33, 197);
            addresult.Name = "addresult";
            addresult.ReadOnly = true;
            addresult.Size = new Size(475, 41);
            addresult.TabIndex = 28;
            // 
            // passwordtxt
            // 
            passwordtxt.Font = new Font("Microsoft JhengHei UI", 20F);
            passwordtxt.Location = new Point(258, 127);
            passwordtxt.Name = "passwordtxt";
            passwordtxt.Size = new Size(250, 41);
            passwordtxt.TabIndex = 26;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei UI", 20F);
            label2.Location = new Point(27, 127);
            label2.Name = "label2";
            label2.Size = new Size(200, 35);
            label2.TabIndex = 25;
            label2.Text = "New Password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 20F);
            label1.Location = new Point(27, 52);
            label1.Name = "label1";
            label1.Size = new Size(119, 35);
            label1.TabIndex = 24;
            label1.Text = "Account";
            // 
            // sureadduserbtn
            // 
            sureadduserbtn.Location = new Point(285, 263);
            sureadduserbtn.Name = "sureadduserbtn";
            sureadduserbtn.Size = new Size(154, 68);
            sureadduserbtn.TabIndex = 30;
            sureadduserbtn.Text = "Yes";
            sureadduserbtn.UseVisualStyleBackColor = true;
            sureadduserbtn.Click += sureadduserbtn_Click;
            // 
            // accounttxt
            // 
            accounttxt.Font = new Font("Microsoft JhengHei UI", 20F);
            accounttxt.Location = new Point(258, 52);
            accounttxt.Name = "accounttxt";
            accounttxt.Size = new Size(250, 41);
            accounttxt.TabIndex = 31;
            // 
            // AddUserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 382);
            Controls.Add(accounttxt);
            Controls.Add(sureadduserbtn);
            Controls.Add(groupBox1);
            Controls.Add(addresult);
            Controls.Add(passwordtxt);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddUserForm";
            Text = "AddUserForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private RadioButton acccess3;
        private RadioButton acccess2;
        private RadioButton acccess1;
        private TextBox addresult;
        private TextBox passwordtxt;
        private Label label2;
        private Label label1;
        private Button sureadduserbtn;
        private TextBox accounttxt;
    }
}