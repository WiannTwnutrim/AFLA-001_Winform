namespace AFLA_001
{
    partial class UserForm
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
            loginresult = new TextBox();
            outeditbtn = new Button();
            logoutbtn = new Button();
            loginbtn = new Button();
            accountcombo = new ComboBox();
            passwordtxt = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // loginresult
            // 
            loginresult.Font = new Font("Microsoft JhengHei UI", 26F);
            loginresult.Location = new Point(451, 338);
            loginresult.Name = "loginresult";
            loginresult.ReadOnly = true;
            loginresult.Size = new Size(287, 52);
            loginresult.TabIndex = 17;
            // 
            // outeditbtn
            // 
            outeditbtn.Font = new Font("Microsoft JhengHei UI", 26F);
            outeditbtn.Location = new Point(895, 324);
            outeditbtn.Name = "outeditbtn";
            outeditbtn.Size = new Size(182, 61);
            outeditbtn.TabIndex = 16;
            outeditbtn.Text = "EditUser";
            outeditbtn.UseVisualStyleBackColor = true;
            outeditbtn.Visible = false;
            // 
            // logoutbtn
            // 
            logoutbtn.Font = new Font("Microsoft JhengHei UI", 26F);
            logoutbtn.Location = new Point(895, 214);
            logoutbtn.Name = "logoutbtn";
            logoutbtn.Size = new Size(182, 61);
            logoutbtn.TabIndex = 15;
            logoutbtn.Text = "Logout";
            logoutbtn.UseVisualStyleBackColor = true;
            // 
            // loginbtn
            // 
            loginbtn.Font = new Font("Microsoft JhengHei UI", 26F);
            loginbtn.Location = new Point(895, 130);
            loginbtn.Name = "loginbtn";
            loginbtn.Size = new Size(182, 61);
            loginbtn.TabIndex = 14;
            loginbtn.Text = "Login";
            loginbtn.UseVisualStyleBackColor = true;
            loginbtn.Click += loginbtn_Click;
            // 
            // accountcombo
            // 
            accountcombo.Font = new Font("Microsoft JhengHei UI", 26F);
            accountcombo.FormattingEnabled = true;
            accountcombo.Location = new Point(451, 139);
            accountcombo.Name = "accountcombo";
            accountcombo.Size = new Size(287, 52);
            accountcombo.TabIndex = 13;
            // 
            // passwordtxt
            // 
            passwordtxt.Font = new Font("Microsoft JhengHei UI", 26F);
            passwordtxt.Location = new Point(451, 214);
            passwordtxt.Name = "passwordtxt";
            passwordtxt.Size = new Size(287, 52);
            passwordtxt.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft JhengHei UI", 30F);
            label3.Location = new Point(402, 22);
            label3.Name = "label3";
            label3.Size = new Size(295, 50);
            label3.TabIndex = 11;
            label3.Text = "Login by Index";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei UI", 30F);
            label2.Location = new Point(173, 214);
            label2.Name = "label2";
            label2.Size = new Size(200, 50);
            label2.TabIndex = 10;
            label2.Text = "Password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 30F);
            label1.Location = new Point(173, 139);
            label1.Name = "label1";
            label1.Size = new Size(178, 50);
            label1.TabIndex = 9;
            label1.Text = "Account";
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1251, 413);
            Controls.Add(loginresult);
            Controls.Add(outeditbtn);
            Controls.Add(logoutbtn);
            Controls.Add(loginbtn);
            Controls.Add(accountcombo);
            Controls.Add(passwordtxt);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "UserForm";
            Text = "UserForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox loginresult;
        private Button outeditbtn;
        private Button logoutbtn;
        private Button loginbtn;
        private ComboBox accountcombo;
        private TextBox passwordtxt;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}