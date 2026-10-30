namespace AFLA_001
{
    partial class UserPage
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            passwordtxt = new TextBox();
            accountcombo = new ComboBox();
            loginbtn = new Button();
            logoutbtn = new Button();
            outeditbtn = new Button();
            loginresult = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 30F);
            label1.Location = new Point(175, 140);
            label1.Name = "label1";
            label1.Size = new Size(178, 50);
            label1.TabIndex = 0;
            label1.Text = "Account";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei UI", 30F);
            label2.Location = new Point(175, 215);
            label2.Name = "label2";
            label2.Size = new Size(200, 50);
            label2.TabIndex = 1;
            label2.Text = "Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft JhengHei UI", 30F);
            label3.Location = new Point(404, 23);
            label3.Name = "label3";
            label3.Size = new Size(295, 50);
            label3.TabIndex = 2;
            label3.Text = "Login by Index";
            // 
            // passwordtxt
            // 
            passwordtxt.Font = new Font("Microsoft JhengHei UI", 26F);
            passwordtxt.Location = new Point(453, 215);
            passwordtxt.Name = "passwordtxt";
            passwordtxt.Size = new Size(287, 52);
            passwordtxt.TabIndex = 3;
            // 
            // accountcombo
            // 
            accountcombo.Font = new Font("Microsoft JhengHei UI", 26F);
            accountcombo.FormattingEnabled = true;
            accountcombo.Location = new Point(453, 140);
            accountcombo.Name = "accountcombo";
            accountcombo.Size = new Size(287, 52);
            accountcombo.TabIndex = 4;
            // 
            // loginbtn
            // 
            loginbtn.Font = new Font("Microsoft JhengHei UI", 26F);
            loginbtn.Location = new Point(897, 131);
            loginbtn.Name = "loginbtn";
            loginbtn.Size = new Size(182, 61);
            loginbtn.TabIndex = 5;
            loginbtn.Text = "Login";
            loginbtn.UseVisualStyleBackColor = true;
            loginbtn.Click += loginbtn_Click;
            // 
            // logoutbtn
            // 
            logoutbtn.Font = new Font("Microsoft JhengHei UI", 26F);
            logoutbtn.Location = new Point(897, 215);
            logoutbtn.Name = "logoutbtn";
            logoutbtn.Size = new Size(182, 61);
            logoutbtn.TabIndex = 6;
            logoutbtn.Text = "Logout";
            logoutbtn.UseVisualStyleBackColor = true;
            // 
            // outeditbtn
            // 
            outeditbtn.Font = new Font("Microsoft JhengHei UI", 26F);
            outeditbtn.Location = new Point(897, 325);
            outeditbtn.Name = "outeditbtn";
            outeditbtn.Size = new Size(182, 61);
            outeditbtn.TabIndex = 7;
            outeditbtn.Text = "EditUser";
            outeditbtn.UseVisualStyleBackColor = true;
            outeditbtn.Visible = false;
            // 
            // loginresult
            // 
            loginresult.Font = new Font("Microsoft JhengHei UI", 26F);
            loginresult.Location = new Point(453, 339);
            loginresult.Name = "loginresult";
            loginresult.ReadOnly = true;
            loginresult.Size = new Size(287, 52);
            loginresult.TabIndex = 8;
            // 
            // UserPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(loginresult);
            Controls.Add(outeditbtn);
            Controls.Add(logoutbtn);
            Controls.Add(loginbtn);
            Controls.Add(accountcombo);
            Controls.Add(passwordtxt);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UserPage";
            Size = new Size(1267, 452);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox passwordtxt;
        private ComboBox accountcombo;
        private Button loginbtn;
        private Button logoutbtn;
        private Button outeditbtn;
        private TextBox loginresult;
    }
}
