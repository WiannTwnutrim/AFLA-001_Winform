namespace AFLA_001
{
    partial class RecipeForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecipeForm));
            recipePanel = new Panel();
            recipecombo = new ComboBox();
            sqlliteBindingSource = new BindingSource(components);
            textBox1 = new TextBox();
            recipeSavbtn = new Button();
            recipeLoabtn = new Button();
            recipeWribtn = new Button();
            sizeCombo = new ComboBox();
            label1 = new Label();
            leftRecipebtn = new Button();
            rightRecipebtn = new Button();
            ((System.ComponentModel.ISupportInitialize)sqlliteBindingSource).BeginInit();
            SuspendLayout();
            // 
            // recipePanel
            // 
            recipePanel.Location = new Point(3, 64);
            recipePanel.Name = "recipePanel";
            recipePanel.Size = new Size(1244, 346);
            recipePanel.TabIndex = 0;
            // 
            // recipecombo
            // 
            recipecombo.DataSource = sqlliteBindingSource;
            recipecombo.Font = new Font("Microsoft JhengHei UI", 12F);
            recipecombo.FormattingEnabled = true;
            recipecombo.Location = new Point(3, 2);
            recipecombo.Name = "recipecombo";
            recipecombo.Size = new Size(242, 28);
            recipecombo.TabIndex = 1;
            // 
            // sqlliteBindingSource
            // 
            sqlliteBindingSource.DataSource = typeof(Sqllite);
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Microsoft JhengHei UI", 12F);
            textBox1.Location = new Point(3, 33);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(242, 28);
            textBox1.TabIndex = 2;
            // 
            // recipeSavbtn
            // 
            recipeSavbtn.Font = new Font("Microsoft JhengHei UI", 15F);
            recipeSavbtn.Location = new Point(529, 2);
            recipeSavbtn.Name = "recipeSavbtn";
            recipeSavbtn.Size = new Size(127, 59);
            recipeSavbtn.TabIndex = 3;
            recipeSavbtn.Text = "SAVE";
            recipeSavbtn.UseVisualStyleBackColor = true;
            // 
            // recipeLoabtn
            // 
            recipeLoabtn.Font = new Font("Microsoft JhengHei UI", 15F);
            recipeLoabtn.Location = new Point(360, 2);
            recipeLoabtn.Name = "recipeLoabtn";
            recipeLoabtn.Size = new Size(127, 59);
            recipeLoabtn.TabIndex = 4;
            recipeLoabtn.Text = "LOAD";
            recipeLoabtn.UseVisualStyleBackColor = true;
            recipeLoabtn.Click += recipeLoabtn_Click;
            // 
            // recipeWribtn
            // 
            recipeWribtn.Font = new Font("Microsoft JhengHei UI", 15F);
            recipeWribtn.Location = new Point(702, 2);
            recipeWribtn.Name = "recipeWribtn";
            recipeWribtn.Size = new Size(127, 59);
            recipeWribtn.TabIndex = 5;
            recipeWribtn.Text = "WRITE PLC";
            recipeWribtn.UseVisualStyleBackColor = true;
            // 
            // sizeCombo
            // 
            sizeCombo.Font = new Font("Microsoft JhengHei UI", 14F);
            sizeCombo.FormattingEnabled = true;
            sizeCombo.Location = new Point(848, 2);
            sizeCombo.Name = "sizeCombo";
            sizeCombo.Size = new Size(140, 32);
            sizeCombo.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 14F);
            label1.Location = new Point(853, 37);
            label1.Name = "label1";
            label1.Size = new Size(48, 24);
            label1.TabIndex = 7;
            label1.Text = "SIZE";
            // 
            // leftRecipebtn
            // 
            leftRecipebtn.Font = new Font("Microsoft JhengHei UI", 14F);
            leftRecipebtn.Image = (Image)resources.GetObject("leftRecipebtn.Image");
            leftRecipebtn.Location = new Point(1016, 4);
            leftRecipebtn.Name = "leftRecipebtn";
            leftRecipebtn.Size = new Size(98, 56);
            leftRecipebtn.TabIndex = 8;
            leftRecipebtn.UseVisualStyleBackColor = true;
            leftRecipebtn.Click += leftRecipebtn_Click;
            // 
            // rightRecipebtn
            // 
            rightRecipebtn.Font = new Font("Microsoft JhengHei UI", 14F);
            rightRecipebtn.Image = (Image)resources.GetObject("rightRecipebtn.Image");
            rightRecipebtn.Location = new Point(1132, 2);
            rightRecipebtn.Name = "rightRecipebtn";
            rightRecipebtn.Size = new Size(98, 56);
            rightRecipebtn.TabIndex = 9;
            rightRecipebtn.UseVisualStyleBackColor = true;
            rightRecipebtn.Click += rightRecipebtn_Click;
            // 
            // RecipeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1251, 413);
            Controls.Add(rightRecipebtn);
            Controls.Add(leftRecipebtn);
            Controls.Add(label1);
            Controls.Add(sizeCombo);
            Controls.Add(recipeWribtn);
            Controls.Add(recipeLoabtn);
            Controls.Add(recipeSavbtn);
            Controls.Add(textBox1);
            Controls.Add(recipecombo);
            Controls.Add(recipePanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RecipeForm";
            Text = "RecipeForm";
            ((System.ComponentModel.ISupportInitialize)sqlliteBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel recipePanel;
        private ComboBox recipecombo;
        private TextBox textBox1;
        private Button recipeSavbtn;
        private Button recipeLoabtn;
        private Button recipeWribtn;
        private ComboBox sizeCombo;
        private Label label1;
        private Button leftRecipebtn;
        private Button rightRecipebtn;
        private BindingSource sqlliteBindingSource;
    }
}