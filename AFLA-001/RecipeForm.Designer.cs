namespace AFLA_001
{
    partial class RecipeForm
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            recipecombo = new ComboBox();
            sqlliteBindingSource = new BindingSource(components);
            recipeNametxt = new TextBox();
            recipeSavbtn = new Button();
            recipeLoabtn = new Button();
            recipeWribtn = new Button();
            sizeCombo = new ComboBox();
            label1 = new Label();
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
            ((System.ComponentModel.ISupportInitialize)sqlliteBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // recipecombo
            // 
            recipecombo.DataSource = sqlliteBindingSource;
            recipecombo.Font = new Font("Microsoft JhengHei UI", 12F);
            recipecombo.FormattingEnabled = true;
            recipecombo.Location = new Point(3, 2);
            recipecombo.Name = "recipecombo";
            recipecombo.Size = new Size(242, 28);
            recipecombo.TabIndex = 1;
            // 
            // sqlliteBindingSource
            // 
            sqlliteBindingSource.DataSource = typeof(Sqllite);
            // 
            // recipeNametxt
            // 
            recipeNametxt.Font = new Font("Microsoft JhengHei UI", 12F);
            recipeNametxt.Location = new Point(3, 33);
            recipeNametxt.Name = "recipeNametxt";
            recipeNametxt.Size = new Size(242, 28);
            recipeNametxt.TabIndex = 2;
            // 
            // recipeSavbtn
            // 
            recipeSavbtn.Font = new Font("Microsoft JhengHei UI", 15F);
            recipeSavbtn.Location = new Point(529, 2);
            recipeSavbtn.Name = "recipeSavbtn";
            recipeSavbtn.Size = new Size(127, 59);
            recipeSavbtn.TabIndex = 3;
            recipeSavbtn.Text = "SAVE";
            recipeSavbtn.UseVisualStyleBackColor = true;
            recipeSavbtn.Click += recipeSavbtn_Click;
            // 
            // recipeLoabtn
            // 
            recipeLoabtn.Font = new Font("Microsoft JhengHei UI", 15F);
            recipeLoabtn.Location = new Point(360, 2);
            recipeLoabtn.Name = "recipeLoabtn";
            recipeLoabtn.Size = new Size(127, 59);
            recipeLoabtn.TabIndex = 4;
            recipeLoabtn.Text = "LOAD";
            recipeLoabtn.UseVisualStyleBackColor = true;
            recipeLoabtn.Click += recipeLoabtn_Click;
            // 
            // recipeWribtn
            // 
            recipeWribtn.Font = new Font("Microsoft JhengHei UI", 15F);
            recipeWribtn.Location = new Point(702, 2);
            recipeWribtn.Name = "recipeWribtn";
            recipeWribtn.Size = new Size(127, 59);
            recipeWribtn.TabIndex = 5;
            recipeWribtn.Text = "WRITE PLC";
            recipeWribtn.UseVisualStyleBackColor = true;
            recipeWribtn.Click += recipeWribtn_Click;
            // 
            // sizeCombo
            // 
            sizeCombo.Font = new Font("Microsoft JhengHei UI", 14F);
            sizeCombo.FormattingEnabled = true;
            sizeCombo.Items.AddRange(new object[] { "8", "12" });
            sizeCombo.Location = new Point(944, 17);
            sizeCombo.Name = "sizeCombo";
            sizeCombo.Size = new Size(140, 32);
            sizeCombo.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 14F);
            label1.Location = new Point(1105, 20);
            label1.Name = "label1";
            label1.Size = new Size(48, 24);
            label1.TabIndex = 7;
            label1.Text = "SIZE";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.Orange;
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ID, Step, BSOIL, BSAIR, IPA, OIL, GLUE, START, END, SPEED, RPM, ACC, TIME, RATIO1, RATIO2, RATIO3, RATIO4, RATIO5, RATIO6, RATIO7, RATIO8, RATIO9, RATIO10 });
            dataGridView1.Location = new Point(3, 67);
            dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Microsoft JhengHei UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = Color.Bisque;
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.Size = new Size(1248, 296);
            dataGridView1.TabIndex = 8;
            dataGridView1.CellToolTipTextNeeded += dataGridView1_CellToolTipTextNeeded;
            dataGridView1.CellValidating += dataGridView1_CellValidating;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            dataGridView1.CurrentCellDirtyStateChanged += dataGridView1_CurrentCellDirtyStateChanged_1;
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
            // RecipeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1251, 413);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(sizeCombo);
            Controls.Add(recipeWribtn);
            Controls.Add(recipeLoabtn);
            Controls.Add(recipeSavbtn);
            Controls.Add(recipeNametxt);
            Controls.Add(recipecombo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RecipeForm";
            Text = "RecipeForm";
            ((System.ComponentModel.ISupportInitialize)sqlliteBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox recipecombo;
        private TextBox recipeNametxt;
        private Button recipeSavbtn;
        private Button recipeLoabtn;
        private Button recipeWribtn;
        private ComboBox sizeCombo;
        private Label label1;
        private BindingSource sqlliteBindingSource;
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