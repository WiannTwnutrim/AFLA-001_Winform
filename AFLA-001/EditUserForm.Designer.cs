namespace AFLA_001
{
    partial class EditUserForm
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
            changeUserPage = new Panel();
            inEditUserbtn = new Button();
            AddUserbtn = new Button();
            SuspendLayout();
            // 
            // changeUserPage
            // 
            changeUserPage.Location = new Point(0, 68);
            changeUserPage.Name = "changeUserPage";
            changeUserPage.Size = new Size(801, 382);
            changeUserPage.TabIndex = 0;
            // 
            // inEditUserbtn
            // 
            inEditUserbtn.Location = new Point(515, -1);
            inEditUserbtn.Name = "inEditUserbtn";
            inEditUserbtn.Size = new Size(154, 68);
            inEditUserbtn.TabIndex = 1;
            inEditUserbtn.Text = "EditUser";
            inEditUserbtn.UseVisualStyleBackColor = true;
            // 
            // AddUserbtn
            // 
            AddUserbtn.Location = new Point(158, -1);
            AddUserbtn.Name = "AddUserbtn";
            AddUserbtn.Size = new Size(154, 68);
            AddUserbtn.TabIndex = 2;
            AddUserbtn.Text = "AddUser";
            AddUserbtn.UseVisualStyleBackColor = true;
            // 
            // EditUserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(AddUserbtn);
            Controls.Add(inEditUserbtn);
            Controls.Add(changeUserPage);
            Name = "EditUserForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EditUserForm";
            ResumeLayout(false);
        }

        #endregion

        private Panel changeUserPage;
        private Button inEditUserbtn;
        private Button AddUserbtn;
    }
}