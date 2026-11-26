namespace AFLA_001
{
    partial class AlarmForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            alarmData = new DataGridView();
            button1 = new Button();
            loadalarmtimer = new System.Windows.Forms.Timer(components);
            searchbtn = new Button();
            livebtn = new Button();
            label = new Label();
            dateTimePickerdown = new DateTimePicker();
            dateTimePickerup = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)alarmData).BeginInit();
            SuspendLayout();
            // 
            // alarmData
            // 
            alarmData.AllowUserToAddRows = false;
            alarmData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.Orange;
            alarmData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            alarmData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            alarmData.BackgroundColor = Color.DarkSlateGray;
            alarmData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            alarmData.Location = new Point(3, 3);
            alarmData.Name = "alarmData";
            alarmData.ReadOnly = true;
            alarmData.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = Color.Bisque;
            alarmData.RowsDefaultCellStyle = dataGridViewCellStyle2;
            alarmData.Size = new Size(1048, 455);
            alarmData.TabIndex = 0;
            // 
            // button1
            // 
            button1.Font = new Font("Microsoft JhengHei UI", 18F);
            button1.Location = new Point(1081, 288);
            button1.Name = "button1";
            button1.Size = new Size(141, 41);
            button1.TabIndex = 3;
            button1.Text = "輸出";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // loadalarmtimer
            // 
            loadalarmtimer.Interval = 500;
            loadalarmtimer.Tick += loadalarmtimer_Tick;
            // 
            // searchbtn
            // 
            searchbtn.Font = new Font("Microsoft JhengHei UI", 18F);
            searchbtn.Location = new Point(1081, 176);
            searchbtn.Name = "searchbtn";
            searchbtn.Size = new Size(141, 41);
            searchbtn.TabIndex = 13;
            searchbtn.Text = "搜尋";
            searchbtn.UseVisualStyleBackColor = true;
            searchbtn.Click += searchbtn_Click;
            // 
            // livebtn
            // 
            livebtn.Font = new Font("Microsoft JhengHei UI", 18F);
            livebtn.Location = new Point(1081, 232);
            livebtn.Name = "livebtn";
            livebtn.Size = new Size(141, 41);
            livebtn.TabIndex = 14;
            livebtn.Text = "恢復即時";
            livebtn.UseVisualStyleBackColor = true;
            livebtn.Click += livebtn_Click;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Font = new Font("Microsoft JhengHei UI", 18F);
            label.ForeColor = Color.White;
            label.Location = new Point(1132, 56);
            label.Name = "label";
            label.Size = new Size(37, 30);
            label.TabIndex = 12;
            label.Text = "到";
            // 
            // dateTimePickerdown
            // 
            dateTimePickerdown.CustomFormat = "yyyy-MM-dd";
            dateTimePickerdown.Font = new Font("Microsoft JhengHei UI", 16F);
            dateTimePickerdown.Format = DateTimePickerFormat.Custom;
            dateTimePickerdown.Location = new Point(1081, 98);
            dateTimePickerdown.Name = "dateTimePickerdown";
            dateTimePickerdown.Size = new Size(141, 35);
            dateTimePickerdown.TabIndex = 11;
            // 
            // dateTimePickerup
            // 
            dateTimePickerup.CustomFormat = "yyyy-MM-dd";
            dateTimePickerup.Font = new Font("Microsoft JhengHei UI", 16F);
            dateTimePickerup.Format = DateTimePickerFormat.Custom;
            dateTimePickerup.Location = new Point(1081, 10);
            dateTimePickerup.Name = "dateTimePickerup";
            dateTimePickerup.Size = new Size(141, 35);
            dateTimePickerup.TabIndex = 10;
            // 
            // AlarmForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSlateGray;
            ClientSize = new Size(1267, 462);
            Controls.Add(searchbtn);
            Controls.Add(livebtn);
            Controls.Add(label);
            Controls.Add(dateTimePickerdown);
            Controls.Add(dateTimePickerup);
            Controls.Add(button1);
            Controls.Add(alarmData);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AlarmForm";
            Text = "AlarmForm";
            VisibleChanged += AlarmForm_VisibleChanged;
            ((System.ComponentModel.ISupportInitialize)alarmData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView alarmData;
        private Button button1;
        private System.Windows.Forms.Timer loadalarmtimer;
        private Button searchbtn;
        private Button livebtn;
        private Label label;
        private DateTimePicker dateTimePickerdown;
        private DateTimePicker dateTimePickerup;
    }
}