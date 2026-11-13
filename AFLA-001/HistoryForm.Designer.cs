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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            historydataGridView = new DataGridView();
            stabtn = new Button();
            stbbtn = new Button();
            stcbtn = new Button();
            button1 = new Button();
            dateTimePickerup = new DateTimePicker();
            dateTimePickerdown = new DateTimePicker();
            label = new Label();
            searchbtn = new Button();
            ((System.ComponentModel.ISupportInitialize)historydataGridView).BeginInit();
            SuspendLayout();
            // 
            // historydataGridView
            // 
            historydataGridView.AllowUserToAddRows = false;
            historydataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.Orange;
            historydataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            historydataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            historydataGridView.Location = new Point(2, 68);
            historydataGridView.Name = "historydataGridView";
            historydataGridView.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.ActiveCaption;
            dataGridViewCellStyle2.Font = new Font("Microsoft JhengHei UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            historydataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            historydataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = Color.Bisque;
            historydataGridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            historydataGridView.Size = new Size(1246, 344);
            historydataGridView.TabIndex = 0;
            // 
            // stabtn
            // 
            stabtn.Font = new Font("Microsoft JhengHei UI", 15F);
            stabtn.Location = new Point(26, 13);
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
            stbbtn.Location = new Point(146, 15);
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
            stcbtn.Location = new Point(264, 16);
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
            button1.Location = new Point(1050, 19);
            button1.Name = "button1";
            button1.Size = new Size(90, 35);
            button1.TabIndex = 5;
            button1.Text = "輸出";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dateTimePickerup
            // 
            dateTimePickerup.CustomFormat = "yyyy-MM-dd";
            dateTimePickerup.Format = DateTimePickerFormat.Custom;
            dateTimePickerup.Location = new Point(399, 27);
            dateTimePickerup.Name = "dateTimePickerup";
            dateTimePickerup.Size = new Size(106, 23);
            dateTimePickerup.TabIndex = 6;
            // 
            // dateTimePickerdown
            // 
            dateTimePickerdown.CustomFormat = "yyyy-MM-dd";
            dateTimePickerdown.Format = DateTimePickerFormat.Custom;
            dateTimePickerdown.Location = new Point(615, 27);
            dateTimePickerdown.Name = "dateTimePickerdown";
            dateTimePickerdown.Size = new Size(106, 23);
            dateTimePickerdown.TabIndex = 7;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Font = new Font("Microsoft JhengHei UI", 15F);
            label.Location = new Point(553, 27);
            label.Name = "label";
            label.Size = new Size(32, 25);
            label.TabIndex = 8;
            label.Text = "到";
            // 
            // searchbtn
            // 
            searchbtn.Font = new Font("Microsoft JhengHei UI", 15F);
            searchbtn.Location = new Point(911, 20);
            searchbtn.Name = "searchbtn";
            searchbtn.Size = new Size(90, 35);
            searchbtn.TabIndex = 9;
            searchbtn.Text = "搜尋";
            searchbtn.UseVisualStyleBackColor = true;
            searchbtn.Click += searchbtn_Click;
            // 
            // HistoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1251, 413);
            Controls.Add(searchbtn);
            Controls.Add(label);
            Controls.Add(dateTimePickerdown);
            Controls.Add(dateTimePickerup);
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
            PerformLayout();
        }

        #endregion

        private DataGridView historydataGridView;
        private Button stabtn;
        private Button stbbtn;
        private Button stcbtn;
        private Button button1;
        private DateTimePicker dateTimePickerup;
        private DateTimePicker dateTimePickerdown;
        private Label label;
        private Button searchbtn;
    }
}