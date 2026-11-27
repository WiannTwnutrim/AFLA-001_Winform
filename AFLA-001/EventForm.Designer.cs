namespace AFLA_001
{
	partial class EventForm
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            EventdataGridView = new DataGridView();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)EventdataGridView).BeginInit();
            SuspendLayout();
            // 
            // EventdataGridView
            // 
            EventdataGridView.AllowUserToAddRows = false;
            EventdataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.Orange;
            EventdataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            EventdataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            EventdataGridView.BackgroundColor = Color.DarkSlateGray;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 136);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            EventdataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            EventdataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.AntiqueWhite;
            dataGridViewCellStyle3.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 136);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            EventdataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            EventdataGridView.Location = new Point(1, 3);
            EventdataGridView.Name = "EventdataGridView";
            EventdataGridView.ReadOnly = true;
            EventdataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = Color.Bisque;
            EventdataGridView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            EventdataGridView.RowTemplate.Height = 35;
            EventdataGridView.Size = new Size(1048, 455);
            EventdataGridView.TabIndex = 0;
            // 
            // button1
            // 
            button1.Font = new Font("Microsoft JhengHei UI", 18F);
            button1.Location = new Point(1069, 91);
            button1.Name = "button1";
            button1.Size = new Size(171, 41);
            button1.TabIndex = 4;
            button1.Text = "輸出";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // EventForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSlateGray;
            ClientSize = new Size(1267, 463);
            Controls.Add(button1);
            Controls.Add(EventdataGridView);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EventForm";
            Text = "EventForm";
            ((System.ComponentModel.ISupportInitialize)EventdataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView EventdataGridView;
		private Button button1;
	}
}