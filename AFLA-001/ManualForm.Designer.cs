namespace AFLA_001
{
    partial class ManualForm
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
            manualPanel = new Panel();
            button7 = new Button();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            toolbtn = new Button();
            manualdata = new DataGridView();
            manualPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)manualdata).BeginInit();
            SuspendLayout();
            // 
            // manualPanel
            // 
            manualPanel.Controls.Add(button7);
            manualPanel.Controls.Add(button6);
            manualPanel.Controls.Add(button5);
            manualPanel.Controls.Add(button4);
            manualPanel.Controls.Add(button3);
            manualPanel.Controls.Add(button2);
            manualPanel.Controls.Add(toolbtn);
            manualPanel.Location = new Point(1049, 3);
            manualPanel.Name = "manualPanel";
            manualPanel.Size = new Size(200, 408);
            manualPanel.TabIndex = 0;
            // 
            // button7
            // 
            button7.Font = new Font("Microsoft JhengHei UI", 14F);
            button7.Location = new Point(19, 367);
            button7.Name = "button7";
            button7.Size = new Size(171, 41);
            button7.TabIndex = 6;
            button7.Text = "ARM2 ROTATE";
            button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Font = new Font("Microsoft JhengHei UI", 14F);
            button6.Location = new Point(19, 310);
            button6.Name = "button6";
            button6.Size = new Size(171, 41);
            button6.TabIndex = 5;
            button6.Text = "ARM2 LIFT";
            button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Font = new Font("Microsoft JhengHei UI", 14F);
            button5.Location = new Point(19, 252);
            button5.Name = "button5";
            button5.Size = new Size(171, 41);
            button5.TabIndex = 4;
            button5.Text = "ARM1 ROTATE";
            button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Font = new Font("Microsoft JhengHei UI", 14F);
            button4.Location = new Point(19, 194);
            button4.Name = "button4";
            button4.Size = new Size(171, 41);
            button4.TabIndex = 3;
            button4.Text = "ARM1 LIFT";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Font = new Font("Microsoft JhengHei UI", 14F);
            button3.Location = new Point(19, 129);
            button3.Name = "button3";
            button3.Size = new Size(171, 41);
            button3.TabIndex = 2;
            button3.Text = "CUP";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Font = new Font("Microsoft JhengHei UI", 14F);
            button2.Location = new Point(19, 66);
            button2.Name = "button2";
            button2.Size = new Size(171, 41);
            button2.TabIndex = 1;
            button2.Text = "CHECK";
            button2.UseVisualStyleBackColor = true;
            // 
            // toolbtn
            // 
            toolbtn.Font = new Font("Microsoft JhengHei UI", 14F);
            toolbtn.Location = new Point(19, 3);
            toolbtn.Name = "toolbtn";
            toolbtn.Size = new Size(171, 41);
            toolbtn.TabIndex = 0;
            toolbtn.Text = "TOOL";
            toolbtn.UseVisualStyleBackColor = true;
            toolbtn.Click += toolbtn_Click;
            // 
            // manualdata
            // 
            manualdata.AllowUserToAddRows = false;
            manualdata.AllowUserToDeleteRows = false;
            manualdata.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            manualdata.Location = new Point(3, 69);
            manualdata.Name = "manualdata";
            manualdata.Size = new Size(1040, 342);
            manualdata.TabIndex = 1;
            // 
            // ManualForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1251, 413);
            Controls.Add(manualdata);
            Controls.Add(manualPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ManualForm";
            Text = "ManualForm";
            manualPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)manualdata).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel manualPanel;
        private Button button7;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button toolbtn;
        private DataGridView manualdata;
    }
}