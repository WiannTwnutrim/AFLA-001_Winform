namespace AFLA_001
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            MainPage = new Panel();
            panel2 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            Historybtn = new Button();
            Languagebtn = new Button();
            Manualbtn = new Button();
            Recipebtn = new Button();
            Homebtn = new Button();
            Iobtn = new Button();
            Userbtn = new Button();
            Logbtn = new Button();
            Eventbtn = new Button();
            Alarmbtn = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            eventtxt = new TextBox();
            textBox2 = new TextBox();
            alarmtxt = new TextBox();
            nowtxt = new TextBox();
            logintxt = new TextBox();
            showrecipetxt = new TextBox();
            nowtime = new System.Windows.Forms.Timer(components);
            panel1 = new Panel();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // MainPage
            // 
            MainPage.Location = new Point(-2, 125);
            MainPage.Name = "MainPage";
            MainPage.Size = new Size(1267, 452);
            MainPage.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Location = new Point(3, 580);
            panel2.Name = "panel2";
            panel2.Size = new Size(1262, 100);
            panel2.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 10;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Controls.Add(Historybtn, 4, 0);
            tableLayoutPanel1.Controls.Add(Languagebtn, 9, 0);
            tableLayoutPanel1.Controls.Add(Manualbtn, 2, 0);
            tableLayoutPanel1.Controls.Add(Recipebtn, 1, 0);
            tableLayoutPanel1.Controls.Add(Homebtn, 0, 0);
            tableLayoutPanel1.Controls.Add(Iobtn, 8, 0);
            tableLayoutPanel1.Controls.Add(Userbtn, 7, 0);
            tableLayoutPanel1.Controls.Add(Logbtn, 6, 0);
            tableLayoutPanel1.Controls.Add(Eventbtn, 5, 0);
            tableLayoutPanel1.Controls.Add(Alarmbtn, 3, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1262, 100);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // Historybtn
            // 
            Historybtn.BackColor = SystemColors.ActiveCaption;
            Historybtn.Dock = DockStyle.Fill;
            Historybtn.Location = new Point(507, 3);
            Historybtn.Name = "Historybtn";
            Historybtn.Size = new Size(120, 94);
            Historybtn.TabIndex = 9;
            Historybtn.Text = "HISTORY";
            Historybtn.UseVisualStyleBackColor = false;
            Historybtn.Click += Historybtn_Click;
            // 
            // Languagebtn
            // 
            Languagebtn.BackColor = SystemColors.ActiveCaption;
            Languagebtn.Dock = DockStyle.Fill;
            Languagebtn.Location = new Point(1137, 3);
            Languagebtn.Name = "Languagebtn";
            Languagebtn.Size = new Size(122, 94);
            Languagebtn.TabIndex = 8;
            Languagebtn.Text = "Language";
            Languagebtn.UseVisualStyleBackColor = false;
            Languagebtn.Click += Languagebtn_Click;
            // 
            // Manualbtn
            // 
            Manualbtn.BackColor = SystemColors.ActiveCaption;
            Manualbtn.Dock = DockStyle.Fill;
            Manualbtn.Location = new Point(255, 3);
            Manualbtn.Name = "Manualbtn";
            Manualbtn.Size = new Size(120, 94);
            Manualbtn.TabIndex = 2;
            Manualbtn.Text = "MANUAL";
            Manualbtn.UseVisualStyleBackColor = false;
            Manualbtn.Click += Manualbtn_Click;
            // 
            // Recipebtn
            // 
            Recipebtn.BackColor = SystemColors.ActiveCaption;
            Recipebtn.Dock = DockStyle.Fill;
            Recipebtn.Location = new Point(129, 3);
            Recipebtn.Name = "Recipebtn";
            Recipebtn.Size = new Size(120, 94);
            Recipebtn.TabIndex = 1;
            Recipebtn.Text = "RECIPE";
            Recipebtn.UseVisualStyleBackColor = false;
            Recipebtn.Click += Recipebtn_Click;
            // 
            // Homebtn
            // 
            Homebtn.BackColor = SystemColors.ActiveCaption;
            Homebtn.Dock = DockStyle.Fill;
            Homebtn.Location = new Point(3, 3);
            Homebtn.Name = "Homebtn";
            Homebtn.Size = new Size(120, 94);
            Homebtn.TabIndex = 0;
            Homebtn.Text = "HOME";
            Homebtn.UseVisualStyleBackColor = false;
            Homebtn.Click += Homebtn_Click;
            // 
            // Iobtn
            // 
            Iobtn.BackColor = SystemColors.ActiveCaption;
            Iobtn.Dock = DockStyle.Fill;
            Iobtn.Location = new Point(1011, 3);
            Iobtn.Name = "Iobtn";
            Iobtn.Size = new Size(120, 94);
            Iobtn.TabIndex = 7;
            Iobtn.Text = "IO";
            Iobtn.UseVisualStyleBackColor = false;
            Iobtn.Click += Iobtn_Click;
            // 
            // Userbtn
            // 
            Userbtn.BackColor = SystemColors.ActiveCaption;
            Userbtn.Dock = DockStyle.Fill;
            Userbtn.Location = new Point(885, 3);
            Userbtn.Name = "Userbtn";
            Userbtn.Size = new Size(120, 94);
            Userbtn.TabIndex = 6;
            Userbtn.Text = "USER";
            Userbtn.UseVisualStyleBackColor = false;
            Userbtn.Click += Userbtn_Click;
            // 
            // Logbtn
            // 
            Logbtn.BackColor = SystemColors.ActiveCaption;
            Logbtn.Dock = DockStyle.Fill;
            Logbtn.Location = new Point(759, 3);
            Logbtn.Name = "Logbtn";
            Logbtn.Size = new Size(120, 94);
            Logbtn.TabIndex = 5;
            Logbtn.Text = "LOG";
            Logbtn.UseVisualStyleBackColor = false;
            Logbtn.Click += Logbtn_Click;
            // 
            // Eventbtn
            // 
            Eventbtn.BackColor = SystemColors.ActiveCaption;
            Eventbtn.Dock = DockStyle.Fill;
            Eventbtn.Location = new Point(633, 3);
            Eventbtn.Name = "Eventbtn";
            Eventbtn.Size = new Size(120, 94);
            Eventbtn.TabIndex = 4;
            Eventbtn.Text = "EVENT";
            Eventbtn.UseVisualStyleBackColor = false;
            Eventbtn.Click += Eventbtn_Click;
            // 
            // Alarmbtn
            // 
            Alarmbtn.BackColor = SystemColors.ActiveCaption;
            Alarmbtn.Dock = DockStyle.Fill;
            Alarmbtn.Location = new Point(381, 3);
            Alarmbtn.Name = "Alarmbtn";
            Alarmbtn.Size = new Size(120, 94);
            Alarmbtn.TabIndex = 3;
            Alarmbtn.Text = "ALARM";
            Alarmbtn.UseVisualStyleBackColor = false;
            Alarmbtn.Click += Alarmbtn_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.LightCyan;
            tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 385F));
            tableLayoutPanel2.Controls.Add(eventtxt, 1, 1);
            tableLayoutPanel2.Controls.Add(textBox2, 0, 1);
            tableLayoutPanel2.Controls.Add(alarmtxt, 1, 0);
            tableLayoutPanel2.Controls.Add(nowtxt, 0, 0);
            tableLayoutPanel2.Controls.Add(logintxt, 2, 0);
            tableLayoutPanel2.Controls.Add(showrecipetxt, 2, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 53F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 47F));
            tableLayoutPanel2.Size = new Size(1174, 111);
            tableLayoutPanel2.TabIndex = 3;
            // 
            // eventtxt
            // 
            eventtxt.BackColor = Color.LightCyan;
            eventtxt.BorderStyle = BorderStyle.None;
            eventtxt.Dock = DockStyle.Fill;
            eventtxt.Font = new Font("Microsoft JhengHei UI", 20F);
            eventtxt.Location = new Point(397, 62);
            eventtxt.Name = "eventtxt";
            eventtxt.ReadOnly = true;
            eventtxt.Size = new Size(386, 34);
            eventtxt.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.LightCyan;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Dock = DockStyle.Fill;
            textBox2.Font = new Font("Microsoft JhengHei UI", 20F);
            textBox2.Location = new Point(4, 62);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(386, 34);
            textBox2.TabIndex = 4;
            // 
            // alarmtxt
            // 
            alarmtxt.BackColor = Color.LightCyan;
            alarmtxt.BorderStyle = BorderStyle.None;
            alarmtxt.Dock = DockStyle.Fill;
            alarmtxt.Font = new Font("Microsoft JhengHei UI", 20F);
            alarmtxt.Location = new Point(397, 4);
            alarmtxt.Name = "alarmtxt";
            alarmtxt.ReadOnly = true;
            alarmtxt.Size = new Size(386, 34);
            alarmtxt.TabIndex = 3;
            // 
            // nowtxt
            // 
            nowtxt.BackColor = Color.LightCyan;
            nowtxt.BorderStyle = BorderStyle.None;
            nowtxt.Dock = DockStyle.Fill;
            nowtxt.Font = new Font("Microsoft JhengHei UI", 20F);
            nowtxt.Location = new Point(7, 4);
            nowtxt.Margin = new Padding(6, 3, 3, 3);
            nowtxt.Name = "nowtxt";
            nowtxt.ReadOnly = true;
            nowtxt.Size = new Size(383, 34);
            nowtxt.TabIndex = 2;
            // 
            // logintxt
            // 
            logintxt.BackColor = Color.LightCyan;
            logintxt.BorderStyle = BorderStyle.None;
            logintxt.Dock = DockStyle.Fill;
            logintxt.Font = new Font("Microsoft JhengHei UI", 20F);
            logintxt.Location = new Point(790, 4);
            logintxt.Name = "logintxt";
            logintxt.ReadOnly = true;
            logintxt.Size = new Size(380, 34);
            logintxt.TabIndex = 0;
            // 
            // showrecipetxt
            // 
            showrecipetxt.BackColor = Color.LightCyan;
            showrecipetxt.BorderStyle = BorderStyle.None;
            showrecipetxt.Dock = DockStyle.Fill;
            showrecipetxt.Font = new Font("Microsoft JhengHei UI", 20F);
            showrecipetxt.Location = new Point(790, 62);
            showrecipetxt.Name = "showrecipetxt";
            showrecipetxt.ReadOnly = true;
            showrecipetxt.Size = new Size(380, 34);
            showrecipetxt.TabIndex = 1;
            // 
            // nowtime
            // 
            nowtime.Enabled = true;
            nowtime.Interval = 1000;
            nowtime.Tick += nowtime_Tick;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaptionText;
            panel1.Controls.Add(tableLayoutPanel2);
            panel1.Location = new Point(85, 2);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(3);
            panel1.Size = new Size(1180, 117);
            panel1.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1272, 691);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(MainPage);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            panel2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel MainPage;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel1;
        private Button Languagebtn;
        private Button Iobtn;
        private Button Userbtn;
        private Button Logbtn;
        private Button Eventbtn;
        private Button Alarmbtn;
        private Button Manualbtn;
        private Button Recipebtn;
        private Button Homebtn;
        private Button Historybtn;
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox logintxt;
        private TextBox showrecipetxt;
        private TextBox nowtxt;
        private System.Windows.Forms.Timer nowtime;
        private Panel panel1;
        private TextBox eventtxt;
        private TextBox textBox2;
        private TextBox alarmtxt;
    }
}
