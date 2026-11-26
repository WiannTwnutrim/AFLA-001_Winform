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
			historydataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			historydataGridView.BackgroundColor = Color.DarkSlateGray;
			historydataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			historydataGridView.Location = new Point(4, 4);
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
			historydataGridView.Size = new Size(1048, 455);
			historydataGridView.TabIndex = 0;
			// 
			// stabtn
			// 
			stabtn.Font = new Font("Microsoft JhengHei UI", 18F);
			stabtn.Location = new Point(1103, 12);
			stabtn.Name = "stabtn";
			stabtn.Size = new Size(141, 41);
			stabtn.TabIndex = 1;
			stabtn.Text = "站點A";
			stabtn.UseVisualStyleBackColor = true;
			stabtn.Click += stabtn_Click;
			// 
			// button1
			// 
			button1.Font = new Font("Microsoft JhengHei UI", 18F);
			button1.Location = new Point(1103, 327);
			button1.Name = "button1";
			button1.Size = new Size(141, 41);
			button1.TabIndex = 5;
			button1.Text = "輸出";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// dateTimePickerup
			// 
			dateTimePickerup.CustomFormat = "yyyy-MM-dd";
			dateTimePickerup.Font = new Font("Microsoft JhengHei UI", 16F);
			dateTimePickerup.Format = DateTimePickerFormat.Custom;
			dateTimePickerup.Location = new Point(1103, 80);
			dateTimePickerup.Name = "dateTimePickerup";
			dateTimePickerup.Size = new Size(141, 35);
			dateTimePickerup.TabIndex = 6;
			// 
			// dateTimePickerdown
			// 
			dateTimePickerdown.CustomFormat = "yyyy-MM-dd";
			dateTimePickerdown.Font = new Font("Microsoft JhengHei UI", 16F);
			dateTimePickerdown.Format = DateTimePickerFormat.Custom;
			dateTimePickerdown.Location = new Point(1103, 168);
			dateTimePickerdown.Name = "dateTimePickerdown";
			dateTimePickerdown.Size = new Size(141, 35);
			dateTimePickerdown.TabIndex = 7;
			// 
			// label
			// 
			label.AutoSize = true;
			label.Font = new Font("Microsoft JhengHei UI", 18F);
			label.Location = new Point(1154, 126);
			label.Name = "label";
			label.Size = new Size(37, 30);
			label.TabIndex = 8;
			label.Text = "到";
			// 
			// searchbtn
			// 
			searchbtn.Font = new Font("Microsoft JhengHei UI", 18F);
			searchbtn.Location = new Point(1103, 246);
			searchbtn.Name = "searchbtn";
			searchbtn.Size = new Size(141, 41);
			searchbtn.TabIndex = 9;
			searchbtn.Text = "搜尋";
			searchbtn.UseVisualStyleBackColor = true;
			searchbtn.Click += searchbtn_Click;
			// 
			// HistoryForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.DarkSlateGray;
			ClientSize = new Size(1267, 462);
			Controls.Add(searchbtn);
			Controls.Add(label);
			Controls.Add(dateTimePickerdown);
			Controls.Add(dateTimePickerup);
			Controls.Add(button1);
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
        private Button button1;
        private DateTimePicker dateTimePickerup;
        private DateTimePicker dateTimePickerdown;
        private Label label;
        private Button searchbtn;
    }
}