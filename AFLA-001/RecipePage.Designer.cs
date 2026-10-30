namespace AFLA_001
{
    partial class RecipePage
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
            Recipebtn = new Button();
            SuspendLayout();
            // 
            // Recipebtn
            // 
            Recipebtn.Location = new Point(397, 93);
            Recipebtn.Name = "Recipebtn";
            Recipebtn.Size = new Size(175, 192);
            Recipebtn.TabIndex = 0;
            Recipebtn.Text = "Recipe";
            Recipebtn.UseVisualStyleBackColor = true;
            // 
            // RecipePage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(Recipebtn);
            Name = "RecipePage";
            Size = new Size(1267, 452);
            ResumeLayout(false);
        }

        #endregion

        private Button Recipebtn;
    }
}
