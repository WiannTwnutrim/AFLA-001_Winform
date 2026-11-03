namespace AFLA_001
{
    partial class Recipe2Form
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
            dataGridView1 = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            RATIO1 = new DataGridViewTextBoxColumn();
            RATIO2 = new DataGridViewTextBoxColumn();
            RATIO3 = new DataGridViewTextBoxColumn();
            RATIO4 = new DataGridViewTextBoxColumn();
            RATIO5 = new DataGridViewTextBoxColumn();
            RATIO6 = new DataGridViewTextBoxColumn();
            RATIO7 = new DataGridViewTextBoxColumn();
            RATIO8 = new DataGridViewTextBoxColumn();
            RATIO9 = new DataGridViewTextBoxColumn();
            RATIO10 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ID, RATIO1, RATIO2, RATIO3, RATIO4, RATIO5, RATIO6, RATIO7, RATIO8, RATIO9, RATIO10 });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1244, 346);
            dataGridView1.TabIndex = 1;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Width = 50;
            // 
            // RATIO1
            // 
            RATIO1.HeaderText = "RATIO1";
            RATIO1.Name = "RATIO1";
            RATIO1.Resizable = DataGridViewTriState.True;
            RATIO1.Width = 80;
            // 
            // RATIO2
            // 
            RATIO2.HeaderText = "RATIO2";
            RATIO2.Name = "RATIO2";
            RATIO2.Width = 80;
            // 
            // RATIO3
            // 
            RATIO3.HeaderText = "RATIO3";
            RATIO3.Name = "RATIO3";
            RATIO3.Width = 80;
            // 
            // RATIO4
            // 
            RATIO4.HeaderText = "RATIO4";
            RATIO4.Name = "RATIO4";
            RATIO4.Width = 80;
            // 
            // RATIO5
            // 
            RATIO5.HeaderText = "RATIO5";
            RATIO5.Name = "RATIO5";
            RATIO5.Width = 80;
            // 
            // RATIO6
            // 
            RATIO6.HeaderText = "RATIO6";
            RATIO6.Name = "RATIO6";
            RATIO6.Width = 80;
            // 
            // RATIO7
            // 
            RATIO7.HeaderText = "RATIO7";
            RATIO7.Name = "RATIO7";
            RATIO7.Width = 80;
            // 
            // RATIO8
            // 
            RATIO8.HeaderText = "RATIO8";
            RATIO8.Name = "RATIO8";
            // 
            // RATIO9
            // 
            RATIO9.HeaderText = "RATIO9";
            RATIO9.Name = "RATIO9";
            // 
            // RATIO10
            // 
            RATIO10.HeaderText = "RATIO10";
            RATIO10.Name = "RATIO10";
            // 
            // Recipe2Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1244, 346);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Recipe2Form";
            Text = "Recipe2Form";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn RATIO1;
        private DataGridViewTextBoxColumn RATIO2;
        private DataGridViewTextBoxColumn RATIO3;
        private DataGridViewTextBoxColumn RATIO4;
        private DataGridViewTextBoxColumn RATIO5;
        private DataGridViewTextBoxColumn RATIO6;
        private DataGridViewTextBoxColumn RATIO7;
        private DataGridViewTextBoxColumn RATIO8;
        private DataGridViewTextBoxColumn RATIO9;
        private DataGridViewTextBoxColumn RATIO10;
    }
}