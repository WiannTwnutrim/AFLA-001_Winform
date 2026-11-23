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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
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
            Arm1Lifttxt = new TextBox();
            label3 = new Label();
            Arm2Lifttxt = new TextBox();
            label4 = new Label();
            Arm1Rotatetxt = new TextBox();
            label5 = new Label();
            Arm2Rotatetxt = new TextBox();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)manualdata).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // button7
            // 
            button7.Font = new Font("Microsoft JhengHei UI", 14F);
            button7.Location = new Point(3, 802);
            button7.Name = "button7";
            button7.Size = new Size(171, 41);
            button7.TabIndex = 6;
            button7.Text = "ARM2 ROTATE";
            button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Font = new Font("Microsoft JhengHei UI", 14F);
            button6.Location = new Point(3, 755);
            button6.Name = "button6";
            button6.Size = new Size(171, 41);
            button6.TabIndex = 5;
            button6.Text = "ARM2 LIFT";
            button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Font = new Font("Microsoft JhengHei UI", 14F);
            button5.Location = new Point(3, 708);
            button5.Name = "button5";
            button5.Size = new Size(171, 41);
            button5.TabIndex = 4;
            button5.Text = "ARM1 ROTATE";
            button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Font = new Font("Microsoft JhengHei UI", 14F);
            button4.Location = new Point(3, 661);
            button4.Name = "button4";
            button4.Size = new Size(171, 41);
            button4.TabIndex = 3;
            button4.Text = "ARM1 LIFT";
            button4.UseVisualStyleBackColor = true;
            // 
            // Resetbtn
            // 
            Resetbtn.Font = new Font("Microsoft JhengHei UI", 14F);
            Resetbtn.Location = new Point(3, 332);
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
            Checkbtn.Location = new Point(3, 285);
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
            toolbtn.Size = new Size(171, 41);
            toolbtn.TabIndex = 0;
            toolbtn.Text = "TOOL";
            toolbtn.UseVisualStyleBackColor = true;
            toolbtn.Click += toolbtn_Click;
            // 
            // manualdata
            // 
            manualdata.AllowUserToAddRows = false;
            manualdata.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = Color.Orange;
            manualdata.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            manualdata.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            manualdata.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            manualdata.Location = new Point(3, 96);
            manualdata.Name = "manualdata";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Microsoft JhengHei UI", 9F);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            manualdata.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            manualdata.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = Color.Bisque;
            manualdata.RowsDefaultCellStyle = dataGridViewCellStyle6;
            manualdata.Size = new Size(1059, 315);
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
            flowLayoutPanel1.Location = new Point(1068, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(200, 408);
            flowLayoutPanel1.TabIndex = 7;
            flowLayoutPanel1.WrapContents = false;
            // 
            // glueTestbtn
            // 
            glueTestbtn.Font = new Font("Microsoft JhengHei UI", 14F);
            glueTestbtn.Location = new Point(3, 50);
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
            oiltestbtn.Location = new Point(3, 97);
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
            ipatestbtn.Location = new Point(3, 144);
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
            vaccumoffbtn.Location = new Point(3, 191);
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
            vaccumonbtm.Location = new Point(3, 238);
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
            powerbtn.Location = new Point(3, 379);
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
            homebtn.Location = new Point(3, 426);
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
            Stopbtn.Location = new Point(3, 473);
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
            jogbtn.Location = new Point(3, 520);
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
            spinbtn.Location = new Point(3, 567);
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
            CUPbtn.Location = new Point(3, 614);
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
            label1.Location = new Point(785, 56);
            label1.Name = "label1";
            label1.Size = new Size(84, 25);
            label1.TabIndex = 8;
            label1.Text = "Cup Lift";
            // 
            // cuplifttxt
            // 
            cuplifttxt.Font = new Font("Microsoft JhengHei UI", 15F);
            cuplifttxt.Location = new Point(888, 53);
            cuplifttxt.Name = "cuplifttxt";
            cuplifttxt.ReadOnly = true;
            cuplifttxt.Size = new Size(100, 33);
            cuplifttxt.TabIndex = 9;
            // 
            // Chuckrpmtxt
            // 
            Chuckrpmtxt.Font = new Font("Microsoft JhengHei UI", 15F);
            Chuckrpmtxt.Location = new Point(888, 3);
            Chuckrpmtxt.Name = "Chuckrpmtxt";
            Chuckrpmtxt.ReadOnly = true;
            Chuckrpmtxt.Size = new Size(100, 33);
            Chuckrpmtxt.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei UI", 15F);
            label2.Location = new Point(758, 6);
            label2.Name = "label2";
            label2.Size = new Size(124, 25);
            label2.TabIndex = 10;
            label2.Text = "Chuck RPM:";
            // 
            // Arm1Lifttxt
            // 
            Arm1Lifttxt.Font = new Font("Microsoft JhengHei UI", 15F);
            Arm1Lifttxt.Location = new Point(566, 3);
            Arm1Lifttxt.Name = "Arm1Lifttxt";
            Arm1Lifttxt.ReadOnly = true;
            Arm1Lifttxt.Size = new Size(100, 33);
            Arm1Lifttxt.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft JhengHei UI", 15F);
            label3.Location = new Point(437, 7);
            label3.Name = "label3";
            label3.Size = new Size(103, 25);
            label3.TabIndex = 14;
            label3.Text = "Arm1 Lift:";
            // 
            // Arm2Lifttxt
            // 
            Arm2Lifttxt.Font = new Font("Microsoft JhengHei UI", 15F);
            Arm2Lifttxt.Location = new Point(566, 53);
            Arm2Lifttxt.Name = "Arm2Lifttxt";
            Arm2Lifttxt.ReadOnly = true;
            Arm2Lifttxt.Size = new Size(100, 33);
            Arm2Lifttxt.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft JhengHei UI", 15F);
            label4.Location = new Point(437, 56);
            label4.Name = "label4";
            label4.Size = new Size(103, 25);
            label4.TabIndex = 12;
            label4.Text = "Arm2 Lift:";
            // 
            // Arm1Rotatetxt
            // 
            Arm1Rotatetxt.Font = new Font("Microsoft JhengHei UI", 15F);
            Arm1Rotatetxt.Location = new Point(220, 4);
            Arm1Rotatetxt.Name = "Arm1Rotatetxt";
            Arm1Rotatetxt.ReadOnly = true;
            Arm1Rotatetxt.Size = new Size(100, 33);
            Arm1Rotatetxt.TabIndex = 19;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft JhengHei UI", 15F);
            label5.Location = new Point(91, 8);
            label5.Name = "label5";
            label5.Size = new Size(136, 25);
            label5.TabIndex = 18;
            label5.Text = "Arm1 Rotate:";
            // 
            // Arm2Rotatetxt
            // 
            Arm2Rotatetxt.Font = new Font("Microsoft JhengHei UI", 15F);
            Arm2Rotatetxt.Location = new Point(220, 54);
            Arm2Rotatetxt.Name = "Arm2Rotatetxt";
            Arm2Rotatetxt.ReadOnly = true;
            Arm2Rotatetxt.Size = new Size(100, 33);
            Arm2Rotatetxt.TabIndex = 17;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft JhengHei UI", 15F);
            label6.Location = new Point(91, 57);
            label6.Name = "label6";
            label6.Size = new Size(136, 25);
            label6.TabIndex = 16;
            label6.Text = "Arm2 Rotate:";
            // 
            // ManualForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSlateGray;
            ClientSize = new Size(1251, 413);
            Controls.Add(Arm1Rotatetxt);
            Controls.Add(label5);
            Controls.Add(Arm2Rotatetxt);
            Controls.Add(label6);
            Controls.Add(Arm1Lifttxt);
            Controls.Add(label3);
            Controls.Add(Arm2Lifttxt);
            Controls.Add(label4);
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
        private TextBox Arm1Lifttxt;
        private Label label3;
        private TextBox Arm2Lifttxt;
        private Label label4;
        private TextBox Arm1Rotatetxt;
        private Label label5;
        private TextBox Arm2Rotatetxt;
        private Label label6;
    }
}