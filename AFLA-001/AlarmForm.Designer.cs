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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            alarmData = new DataGridView();
            alarmtestbtn = new Button();
            alaemResetbtn = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)alarmData).BeginInit();
            SuspendLayout();
            // 
            // alarmData
            // 
            alarmData.AllowUserToAddRows = false;
            alarmData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.OldLace;
            alarmData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            alarmData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            alarmData.Location = new Point(0, 53);
            alarmData.Name = "alarmData";
            alarmData.ReadOnly = true;
            alarmData.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = Color.Peru;
            alarmData.RowsDefaultCellStyle = dataGridViewCellStyle2;
            alarmData.Size = new Size(1251, 360);
            alarmData.TabIndex = 0;
            // 
            // alarmtestbtn
            // 
            alarmtestbtn.Location = new Point(31, 12);
            alarmtestbtn.Name = "alarmtestbtn";
            alarmtestbtn.Size = new Size(90, 35);
            alarmtestbtn.TabIndex = 1;
            alarmtestbtn.Text = "觸發警告測試";
            alarmtestbtn.UseVisualStyleBackColor = true;
            alarmtestbtn.Click += alarmtestbtn_Click;
            // 
            // alaemResetbtn
            // 
            alaemResetbtn.Location = new Point(207, 12);
            alaemResetbtn.Name = "alaemResetbtn";
            alaemResetbtn.Size = new Size(90, 35);
            alaemResetbtn.TabIndex = 2;
            alaemResetbtn.Text = "重置";
            alaemResetbtn.UseVisualStyleBackColor = true;
            alaemResetbtn.Click += alaemResetbtn_Click;
            // 
            // button1
            // 
            button1.Location = new Point(663, 12);
            button1.Name = "button1";
            button1.Size = new Size(90, 35);
            button1.TabIndex = 3;
            button1.Text = "輸出";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // AlarmForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1251, 413);
            Controls.Add(button1);
            Controls.Add(alaemResetbtn);
            Controls.Add(alarmtestbtn);
            Controls.Add(alarmData);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AlarmForm";
            Text = "AlarmForm";
            ((System.ComponentModel.ISupportInitialize)alarmData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView alarmData;
        private Button alarmtestbtn;
        private Button alaemResetbtn;
        private Button button1;
    }
}