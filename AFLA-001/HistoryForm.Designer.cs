namespace AFLA_001
{
    partial class HistoryForm
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            historydataGridView = new DataGridView();
            stabtn = new Button();
            stbbtn = new Button();
            stcbtn = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)historydataGridView).BeginInit();
            SuspendLayout();
            // 
            // historydataGridView
            // 
            historydataGridView.AllowUserToAddRows = false;
            historydataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = SystemColors.GradientActiveCaption;
            historydataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            historydataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            historydataGridView.Location = new Point(2, 68);
            historydataGridView.Name = "historydataGridView";
            historydataGridView.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.ActiveCaption;
            dataGridViewCellStyle4.Font = new Font("Microsoft JhengHei UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            historydataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            historydataGridView.RowHeadersVisible = false;
            historydataGridView.Size = new Size(1246, 344);
            historydataGridView.TabIndex = 0;
            // 
            // stabtn
            // 
            stabtn.Font = new Font("Microsoft JhengHei UI", 15F);
            stabtn.Location = new Point(119, 12);
            stabtn.Name = "stabtn";
            stabtn.Size = new Size(76, 37);
            stabtn.TabIndex = 1;
            stabtn.Text = "站點A";
            stabtn.UseVisualStyleBackColor = true;
            stabtn.Click += stabtn_Click;
            // 
            // stbbtn
            // 
            stbbtn.Font = new Font("Microsoft JhengHei UI", 15F);
            stbbtn.Location = new Point(232, 12);
            stbbtn.Name = "stbbtn";
            stbbtn.Size = new Size(76, 37);
            stbbtn.TabIndex = 2;
            stbbtn.Text = "站點B";
            stbbtn.UseVisualStyleBackColor = true;
            stbbtn.Click += stbbtn_Click;
            // 
            // stcbtn
            // 
            stcbtn.Font = new Font("Microsoft JhengHei UI", 15F);
            stcbtn.Location = new Point(355, 12);
            stcbtn.Name = "stcbtn";
            stcbtn.Size = new Size(76, 37);
            stcbtn.TabIndex = 3;
            stcbtn.Text = "站點C";
            stcbtn.UseVisualStyleBackColor = true;
            stcbtn.Click += stcbtn_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Microsoft JhengHei UI", 15F);
            button1.Location = new Point(627, 16);
            button1.Name = "button1";
            button1.Size = new Size(90, 35);
            button1.TabIndex = 5;
            button1.Text = "輸出";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // HistoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1251, 413);
            Controls.Add(button1);
            Controls.Add(stcbtn);
            Controls.Add(stbbtn);
            Controls.Add(stabtn);
            Controls.Add(historydataGridView);
            FormBorderStyle = FormBorderStyle.None;
            Name = "HistoryForm";
            Text = "HistoryForm";
            ((System.ComponentModel.ISupportInitialize)historydataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView historydataGridView;
        private Button stabtn;
        private Button stbbtn;
        private Button stcbtn;
        private Button button1;
    }
}