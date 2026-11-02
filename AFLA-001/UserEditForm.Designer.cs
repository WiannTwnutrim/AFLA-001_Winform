namespace AFLA_001
{
    partial class UserEditForm
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
            accountcombo = new ComboBox();
            passwordtxt = new TextBox();
            label2 = new Label();
            label1 = new Label();
            editresult = new TextBox();
            userdelbtn = new Button();
            alteracbtn = new Button();
            alterpwbtn = new Button();
            groupBox1 = new GroupBox();
            acccess3 = new RadioButton();
            acccess2 = new RadioButton();
            acccess1 = new RadioButton();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // accountcombo
            // 
            accountcombo.Font = new Font("Microsoft JhengHei UI", 20F);
            accountcombo.FormattingEnabled = true;
            accountcombo.Location = new Point(237, 34);
            accountcombo.Name = "accountcombo";
            accountcombo.Size = new Size(250, 43);
            accountcombo.TabIndex = 17;
            // 
            // passwordtxt
            // 
            passwordtxt.Font = new Font("Microsoft JhengHei UI", 20F);
            passwordtxt.Location = new Point(237, 109);
            passwordtxt.Name = "passwordtxt";
            passwordtxt.Size = new Size(250, 41);
            passwordtxt.TabIndex = 16;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei UI", 20F);
            label2.Location = new Point(6, 109);
            label2.Name = "label2";
            label2.Size = new Size(200, 35);
            label2.TabIndex = 15;
            label2.Text = "New Password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 20F);
            label1.Location = new Point(6, 34);
            label1.Name = "label1";
            label1.Size = new Size(119, 35);
            label1.TabIndex = 14;
            label1.Text = "Account";
            // 
            // editresult
            // 
            editresult.Font = new Font("Microsoft JhengHei UI", 20F);
            editresult.Location = new Point(12, 179);
            editresult.Name = "editresult";
            editresult.ReadOnly = true;
            editresult.Size = new Size(475, 41);
            editresult.TabIndex = 19;
            // 
            // userdelbtn
            // 
            userdelbtn.Location = new Point(12, 273);
            userdelbtn.Name = "userdelbtn";
            userdelbtn.Size = new Size(154, 68);
            userdelbtn.TabIndex = 20;
            userdelbtn.Text = "DeleteUser";
            userdelbtn.UseVisualStyleBackColor = true;
            // 
            // alteracbtn
            // 
            alteracbtn.Location = new Point(260, 273);
            alteracbtn.Name = "alteracbtn";
            alteracbtn.Size = new Size(154, 68);
            alteracbtn.TabIndex = 21;
            alteracbtn.Text = "AlterAccess";
            alteracbtn.UseVisualStyleBackColor = true;
            alteracbtn.Click += alteracbtn_Click;
            // 
            // alterpwbtn
            // 
            alterpwbtn.Location = new Point(531, 273);
            alterpwbtn.Name = "alterpwbtn";
            alterpwbtn.Size = new Size(154, 68);
            alterpwbtn.TabIndex = 22;
            alterpwbtn.Text = "AlterPassword";
            alterpwbtn.UseVisualStyleBackColor = true;
            alterpwbtn.Click += alterpwbtn_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(acccess3);
            groupBox1.Controls.Add(acccess2);
            groupBox1.Controls.Add(acccess1);
            groupBox1.Font = new Font("Microsoft JhengHei UI", 20F);
            groupBox1.Location = new Point(531, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(237, 210);
            groupBox1.TabIndex = 23;
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
            // UserEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 382);
            Controls.Add(groupBox1);
            Controls.Add(alterpwbtn);
            Controls.Add(alteracbtn);
            Controls.Add(userdelbtn);
            Controls.Add(editresult);
            Controls.Add(accountcombo);
            Controls.Add(passwordtxt);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "UserEditForm";
            Text = "UserEditForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox accountcombo;
        private TextBox passwordtxt;
        private Label label2;
        private Label label1;
        private TextBox editresult;
        private Button userdelbtn;
        private Button alteracbtn;
        private Button alterpwbtn;
        private GroupBox groupBox1;
        private RadioButton acccess3;
        private RadioButton acccess2;
        private RadioButton acccess1;
    }
}