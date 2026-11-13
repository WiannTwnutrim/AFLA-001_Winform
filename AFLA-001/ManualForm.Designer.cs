namespace AFLA_001
{
    partial class ManualForm
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
            button7 = new Button();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            Resetbtn = new Button();
            Checkbtn = new Button();
            toolbtn = new Button();
            manualdata = new DataGridView();
            flowLayoutPanel1 = new FlowLayoutPanel();
            glueTestbtn = new Button();
            oiltestbtn = new Button();
            ipatestbtn = new Button();
            vaccumoffbtn = new Button();
            vaccumonbtm = new Button();
            powerbtn = new Button();
            homebtn = new Button();
            Stopbtn = new Button();
            jogbtn = new Button();
            spinbtn = new Button();
            CUPbtn = new Button();
            label1 = new Label();
            cuplifttxt = new TextBox();
            Chuckrpmtxt = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)manualdata).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // button7
            // 
            button7.Font = new Font("Microsoft JhengHei UI", 14F);
            button7.Location = new Point(3, 793);
            button7.Name = "button7";
            button7.Size = new Size(171, 41);
            button7.TabIndex = 6;
            button7.Text = "ARM2 ROTATE";
            button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Font = new Font("Microsoft JhengHei UI", 14F);
            button6.Location = new Point(3, 746);
            button6.Name = "button6";
            button6.Size = new Size(171, 41);
            button6.TabIndex = 5;
            button6.Text = "ARM2 LIFT";
            button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Font = new Font("Microsoft JhengHei UI", 14F);
            button5.Location = new Point(3, 699);
            button5.Name = "button5";
            button5.Size = new Size(171, 41);
            button5.TabIndex = 4;
            button5.Text = "ARM1 ROTATE";
            button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Font = new Font("Microsoft JhengHei UI", 14F);
            button4.Location = new Point(3, 652);
            button4.Name = "button4";
            button4.Size = new Size(171, 41);
            button4.TabIndex = 3;
            button4.Text = "ARM1 LIFT";
            button4.UseVisualStyleBackColor = true;
            // 
            // Resetbtn
            // 
            Resetbtn.Font = new Font("Microsoft JhengHei UI", 14F);
            Resetbtn.Location = new Point(3, 323);
            Resetbtn.Name = "Resetbtn";
            Resetbtn.Size = new Size(171, 41);
            Resetbtn.TabIndex = 2;
            Resetbtn.Text = "Reset";
            Resetbtn.UseVisualStyleBackColor = true;
            Resetbtn.Visible = false;
            // 
            // Checkbtn
            // 
            Checkbtn.Font = new Font("Microsoft JhengHei UI", 14F);
            Checkbtn.Location = new Point(3, 276);
            Checkbtn.Name = "Checkbtn";
            Checkbtn.Size = new Size(171, 41);
            Checkbtn.TabIndex = 1;
            Checkbtn.Text = "CHECK";
            Checkbtn.UseVisualStyleBackColor = true;
            Checkbtn.Click += Checkbtn_Click;
            // 
            // toolbtn
            // 
            toolbtn.Font = new Font("Microsoft JhengHei UI", 14F);
            toolbtn.Location = new Point(3, 3);
            toolbtn.Name = "toolbtn";
            toolbtn.Size = new Size(171, 32);
            toolbtn.TabIndex = 0;
            toolbtn.Text = "TOOL";
            toolbtn.UseVisualStyleBackColor = true;
            toolbtn.Click += toolbtn_Click;
            // 
            // manualdata
            // 
            manualdata.AllowUserToAddRows = false;
            manualdata.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.Orange;
            manualdata.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            manualdata.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            manualdata.Location = new Point(3, 69);
            manualdata.Name = "manualdata";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft JhengHei UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            manualdata.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            manualdata.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = Color.Bisque;
            manualdata.RowsDefaultCellStyle = dataGridViewCellStyle3;
            manualdata.Size = new Size(823, 342);
            manualdata.TabIndex = 1;
            manualdata.CellBeginEdit += manualdata_CellBeginEdit;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Add(toolbtn);
            flowLayoutPanel1.Controls.Add(glueTestbtn);
            flowLayoutPanel1.Controls.Add(oiltestbtn);
            flowLayoutPanel1.Controls.Add(ipatestbtn);
            flowLayoutPanel1.Controls.Add(vaccumoffbtn);
            flowLayoutPanel1.Controls.Add(vaccumonbtm);
            flowLayoutPanel1.Controls.Add(Checkbtn);
            flowLayoutPanel1.Controls.Add(Resetbtn);
            flowLayoutPanel1.Controls.Add(powerbtn);
            flowLayoutPanel1.Controls.Add(homebtn);
            flowLayoutPanel1.Controls.Add(Stopbtn);
            flowLayoutPanel1.Controls.Add(jogbtn);
            flowLayoutPanel1.Controls.Add(spinbtn);
            flowLayoutPanel1.Controls.Add(CUPbtn);
            flowLayoutPanel1.Controls.Add(button4);
            flowLayoutPanel1.Controls.Add(button5);
            flowLayoutPanel1.Controls.Add(button6);
            flowLayoutPanel1.Controls.Add(button7);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(1049, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(200, 408);
            flowLayoutPanel1.TabIndex = 7;
            flowLayoutPanel1.WrapContents = false;
            // 
            // glueTestbtn
            // 
            glueTestbtn.Font = new Font("Microsoft JhengHei UI", 14F);
            glueTestbtn.Location = new Point(3, 41);
            glueTestbtn.Name = "glueTestbtn";
            glueTestbtn.Size = new Size(171, 41);
            glueTestbtn.TabIndex = 10;
            glueTestbtn.Text = "GLUE Test";
            glueTestbtn.UseVisualStyleBackColor = true;
            glueTestbtn.Visible = false;
            // 
            // oiltestbtn
            // 
            oiltestbtn.Font = new Font("Microsoft JhengHei UI", 14F);
            oiltestbtn.Location = new Point(3, 88);
            oiltestbtn.Name = "oiltestbtn";
            oiltestbtn.Size = new Size(171, 41);
            oiltestbtn.TabIndex = 9;
            oiltestbtn.Text = "OIL Test";
            oiltestbtn.UseVisualStyleBackColor = true;
            oiltestbtn.Visible = false;
            // 
            // ipatestbtn
            // 
            ipatestbtn.Font = new Font("Microsoft JhengHei UI", 14F);
            ipatestbtn.Location = new Point(3, 135);
            ipatestbtn.Name = "ipatestbtn";
            ipatestbtn.Size = new Size(171, 41);
            ipatestbtn.TabIndex = 8;
            ipatestbtn.Text = "IPA Test";
            ipatestbtn.UseVisualStyleBackColor = true;
            ipatestbtn.Visible = false;
            // 
            // vaccumoffbtn
            // 
            vaccumoffbtn.Font = new Font("Microsoft JhengHei UI", 14F);
            vaccumoffbtn.Location = new Point(3, 182);
            vaccumoffbtn.Name = "vaccumoffbtn";
            vaccumoffbtn.Size = new Size(171, 41);
            vaccumoffbtn.TabIndex = 7;
            vaccumoffbtn.Text = "VaccumOff";
            vaccumoffbtn.UseVisualStyleBackColor = true;
            vaccumoffbtn.Visible = false;
            // 
            // vaccumonbtm
            // 
            vaccumonbtm.Font = new Font("Microsoft JhengHei UI", 14F);
            vaccumonbtm.Location = new Point(3, 229);
            vaccumonbtm.Name = "vaccumonbtm";
            vaccumonbtm.Size = new Size(171, 41);
            vaccumonbtm.TabIndex = 6;
            vaccumonbtm.Text = "VaccumOn";
            vaccumonbtm.UseVisualStyleBackColor = true;
            vaccumonbtm.Visible = false;
            // 
            // powerbtn
            // 
            powerbtn.Font = new Font("Microsoft JhengHei UI", 14F);
            powerbtn.Location = new Point(3, 370);
            powerbtn.Name = "powerbtn";
            powerbtn.Size = new Size(171, 41);
            powerbtn.TabIndex = 8;
            powerbtn.Text = "Power";
            powerbtn.UseVisualStyleBackColor = true;
            powerbtn.Visible = false;
            // 
            // homebtn
            // 
            homebtn.Font = new Font("Microsoft JhengHei UI", 14F);
            homebtn.Location = new Point(3, 417);
            homebtn.Name = "homebtn";
            homebtn.Size = new Size(171, 41);
            homebtn.TabIndex = 12;
            homebtn.Text = "Home";
            homebtn.UseVisualStyleBackColor = true;
            homebtn.Visible = false;
            // 
            // Stopbtn
            // 
            Stopbtn.Font = new Font("Microsoft JhengHei UI", 14F);
            Stopbtn.Location = new Point(3, 464);
            Stopbtn.Name = "Stopbtn";
            Stopbtn.Size = new Size(171, 41);
            Stopbtn.TabIndex = 13;
            Stopbtn.Text = "Stop";
            Stopbtn.UseVisualStyleBackColor = true;
            Stopbtn.Visible = false;
            // 
            // jogbtn
            // 
            jogbtn.Font = new Font("Microsoft JhengHei UI", 14F);
            jogbtn.Location = new Point(3, 511);
            jogbtn.Name = "jogbtn";
            jogbtn.Size = new Size(171, 41);
            jogbtn.TabIndex = 14;
            jogbtn.Text = "Jog";
            jogbtn.UseVisualStyleBackColor = true;
            jogbtn.Visible = false;
            // 
            // spinbtn
            // 
            spinbtn.Font = new Font("Microsoft JhengHei UI", 14F);
            spinbtn.Location = new Point(3, 558);
            spinbtn.Name = "spinbtn";
            spinbtn.Size = new Size(171, 41);
            spinbtn.TabIndex = 15;
            spinbtn.Text = "Spin";
            spinbtn.UseVisualStyleBackColor = true;
            spinbtn.Visible = false;
            // 
            // CUPbtn
            // 
            CUPbtn.Font = new Font("Microsoft JhengHei UI", 14F);
            CUPbtn.Location = new Point(3, 605);
            CUPbtn.Name = "CUPbtn";
            CUPbtn.Size = new Size(171, 41);
            CUPbtn.TabIndex = 9;
            CUPbtn.Text = "CUP";
            CUPbtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 15F);
            label1.Location = new Point(480, 35);
            label1.Name = "label1";
            label1.Size = new Size(84, 25);
            label1.TabIndex = 8;
            label1.Text = "Cup Lift";
            // 
            // cuplifttxt
            // 
            cuplifttxt.Font = new Font("Microsoft JhengHei UI", 15F);
            cuplifttxt.Location = new Point(583, 32);
            cuplifttxt.Name = "cuplifttxt";
            cuplifttxt.ReadOnly = true;
            cuplifttxt.Size = new Size(100, 33);
            cuplifttxt.TabIndex = 9;
            // 
            // Chuckrpmtxt
            // 
            Chuckrpmtxt.Font = new Font("Microsoft JhengHei UI", 15F);
            Chuckrpmtxt.Location = new Point(269, 29);
            Chuckrpmtxt.Name = "Chuckrpmtxt";
            Chuckrpmtxt.ReadOnly = true;
            Chuckrpmtxt.Size = new Size(100, 33);
            Chuckrpmtxt.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei UI", 15F);
            label2.Location = new Point(139, 32);
            label2.Name = "label2";
            label2.Size = new Size(124, 25);
            label2.TabIndex = 10;
            label2.Text = "Chuck RPM:";
            // 
            // ManualForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1251, 413);
            Controls.Add(Chuckrpmtxt);
            Controls.Add(label2);
            Controls.Add(cuplifttxt);
            Controls.Add(label1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(manualdata);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ManualForm";
            Text = "ManualForm";
            ((System.ComponentModel.ISupportInitialize)manualdata).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button7;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button Resetbtn;
        private Button Checkbtn;
        private Button toolbtn;
        private DataGridView manualdata;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button glueTestbtn;
        private Button oiltestbtn;
        private Button ipatestbtn;
        private Button vaccumoffbtn;
        private Button vaccumonbtm;
        private Button CUPbtn;
        private Button powerbtn;
        private Button homebtn;
        private Button Stopbtn;
        private Button jogbtn;
        private Button spinbtn;
        private Label label1;
        private TextBox cuplifttxt;
        private TextBox Chuckrpmtxt;
        private Label label2;
    }
}