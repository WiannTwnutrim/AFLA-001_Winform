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
            EventdataGridView = new DataGridView();
            button1 = new Button();
            addeventbtn = new Button();
            ((System.ComponentModel.ISupportInitialize)EventdataGridView).BeginInit();
            SuspendLayout();
            // 
            // EventdataGridView
            // 
            EventdataGridView.AllowUserToAddRows = false;
            EventdataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.OldLace;
            EventdataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            EventdataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.AntiqueWhite;
            dataGridViewCellStyle2.Font = new Font("Microsoft JhengHei UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            EventdataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            EventdataGridView.Location = new Point(0, 54);
            EventdataGridView.Name = "EventdataGridView";
            EventdataGridView.ReadOnly = true;
            EventdataGridView.RowHeadersVisible = false;
            EventdataGridView.Size = new Size(1236, 320);
            EventdataGridView.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(954, 12);
            button1.Name = "button1";
            button1.Size = new Size(90, 35);
            button1.TabIndex = 4;
            button1.Text = "輸出";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // addeventbtn
            // 
            addeventbtn.Location = new Point(447, 12);
            addeventbtn.Name = "addeventbtn";
            addeventbtn.Size = new Size(90, 35);
            addeventbtn.TabIndex = 5;
            addeventbtn.Text = "新增";
            addeventbtn.UseVisualStyleBackColor = true;
            addeventbtn.Click += addeventbtn_Click;
            // 
            // EventForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1235, 374);
            Controls.Add(addeventbtn);
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
		private Button addeventbtn;
	}
}