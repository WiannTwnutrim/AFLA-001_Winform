namespace AFLA_001
{
    partial class Recipe1Form
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
            Step = new DataGridViewCheckBoxColumn();
            BSOIL = new DataGridViewCheckBoxColumn();
            BSAIR = new DataGridViewCheckBoxColumn();
            IPA = new DataGridViewCheckBoxColumn();
            OIL = new DataGridViewCheckBoxColumn();
            GLUE = new DataGridViewCheckBoxColumn();
            START = new DataGridViewTextBoxColumn();
            END = new DataGridViewTextBoxColumn();
            SPEED = new DataGridViewTextBoxColumn();
            RPM = new DataGridViewTextBoxColumn();
            ACC = new DataGridViewTextBoxColumn();
            TIME = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ID, Step, BSOIL, BSAIR, IPA, OIL, GLUE, START, END, SPEED, RPM, ACC, TIME });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1244, 346);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            dataGridView1.CurrentCellDirtyStateChanged += dataGridView1_CurrentCellDirtyStateChanged;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Width = 50;
            // 
            // Step
            // 
            Step.HeaderText = "Step";
            Step.Name = "Step";
            Step.Resizable = DataGridViewTriState.True;
            Step.SortMode = DataGridViewColumnSortMode.Automatic;
            Step.Width = 80;
            // 
            // BSOIL
            // 
            BSOIL.HeaderText = "BSOIL";
            BSOIL.Name = "BSOIL";
            BSOIL.Resizable = DataGridViewTriState.True;
            BSOIL.SortMode = DataGridViewColumnSortMode.Automatic;
            BSOIL.Width = 80;
            // 
            // BSAIR
            // 
            BSAIR.HeaderText = "BSAIR";
            BSAIR.Name = "BSAIR";
            BSAIR.Resizable = DataGridViewTriState.True;
            BSAIR.SortMode = DataGridViewColumnSortMode.Automatic;
            BSAIR.Width = 80;
            // 
            // IPA
            // 
            IPA.HeaderText = "IPA";
            IPA.Name = "IPA";
            IPA.Resizable = DataGridViewTriState.True;
            IPA.SortMode = DataGridViewColumnSortMode.Automatic;
            IPA.Width = 80;
            // 
            // OIL
            // 
            OIL.HeaderText = "OIL";
            OIL.Name = "OIL";
            OIL.Resizable = DataGridViewTriState.True;
            OIL.SortMode = DataGridViewColumnSortMode.Automatic;
            OIL.Width = 80;
            // 
            // GLUE
            // 
            GLUE.HeaderText = "GLUE";
            GLUE.Name = "GLUE";
            GLUE.Resizable = DataGridViewTriState.True;
            GLUE.SortMode = DataGridViewColumnSortMode.Automatic;
            GLUE.Width = 80;
            // 
            // START
            // 
            START.HeaderText = "START";
            START.Name = "START";
            START.Width = 80;
            // 
            // END
            // 
            END.HeaderText = "END";
            END.Name = "END";
            END.Width = 80;
            // 
            // SPEED
            // 
            SPEED.HeaderText = "SPEED";
            SPEED.Name = "SPEED";
            SPEED.Width = 80;
            // 
            // RPM
            // 
            RPM.HeaderText = "RPM";
            RPM.Name = "RPM";
            RPM.Width = 80;
            // 
            // ACC
            // 
            ACC.HeaderText = "ACC";
            ACC.Name = "ACC";
            ACC.Width = 80;
            // 
            // TIME
            // 
            TIME.HeaderText = "TIME";
            TIME.Name = "TIME";
            TIME.Width = 80;
            // 
            // Recipe1Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1244, 346);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Recipe1Form";
            Text = "Recipe1Form";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewCheckBoxColumn Step;
        private DataGridViewCheckBoxColumn BSOIL;
        private DataGridViewCheckBoxColumn BSAIR;
        private DataGridViewCheckBoxColumn IPA;
        private DataGridViewCheckBoxColumn OIL;
        private DataGridViewCheckBoxColumn GLUE;
        private DataGridViewTextBoxColumn START;
        private DataGridViewTextBoxColumn END;
        private DataGridViewTextBoxColumn SPEED;
        private DataGridViewTextBoxColumn RPM;
        private DataGridViewTextBoxColumn ACC;
        private DataGridViewTextBoxColumn TIME;
    }
}