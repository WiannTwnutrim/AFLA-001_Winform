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
            eventpanel = new Panel();
            eventtxt = new Label();
            equipmentstatus = new TextBox();
            nowtxt = new TextBox();
            logintxt = new TextBox();
            showrecipetxt = new TextBox();
            alarmpanel = new Panel();
            alarmtxt = new Label();
            nowtime = new System.Windows.Forms.Timer(components);
            pictureBox1 = new PictureBox();
            greenlight = new Label();
            orangelight = new Label();
            redlight = new Label();
            ticker = new System.Windows.Forms.Timer(components);
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            eventpanel.SuspendLayout();
            alarmpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // MainPage
            // 
            MainPage.Location = new Point(1, 125);
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
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35.27181F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 64.7281952F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 283F));
            tableLayoutPanel2.Controls.Add(eventpanel, 1, 1);
            tableLayoutPanel2.Controls.Add(equipmentstatus, 0, 1);
            tableLayoutPanel2.Controls.Add(nowtxt, 0, 0);
            tableLayoutPanel2.Controls.Add(logintxt, 2, 0);
            tableLayoutPanel2.Controls.Add(showrecipetxt, 2, 1);
            tableLayoutPanel2.Controls.Add(alarmpanel, 1, 0);
            tableLayoutPanel2.Location = new Point(104, 4);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 53F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 47F));
            tableLayoutPanel2.Size = new Size(1084, 111);
            tableLayoutPanel2.TabIndex = 3;
            // 
            // eventpanel
            // 
            eventpanel.Controls.Add(eventtxt);
            eventpanel.Location = new Point(286, 62);
            eventpanel.Name = "eventpanel";
            eventpanel.Size = new Size(508, 45);
            eventpanel.TabIndex = 9;
            // 
            // eventtxt
            // 
            eventtxt.Font = new Font("Microsoft JhengHei UI", 20F);
            eventtxt.Location = new Point(3, 5);
            eventtxt.Name = "eventtxt";
            eventtxt.Size = new Size(502, 40);
            eventtxt.TabIndex = 5;
            // 
            // equipmentstatus
            // 
            equipmentstatus.BackColor = Color.LightCyan;
            equipmentstatus.BorderStyle = BorderStyle.None;
            equipmentstatus.Dock = DockStyle.Fill;
            equipmentstatus.Font = new Font("Microsoft JhengHei UI", 20F);
            equipmentstatus.Location = new Point(4, 62);
            equipmentstatus.Name = "equipmentstatus";
            equipmentstatus.ReadOnly = true;
            equipmentstatus.Size = new Size(275, 34);
            equipmentstatus.TabIndex = 4;
            equipmentstatus.Text = "Not Ready";
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
            nowtxt.Size = new Size(272, 34);
            nowtxt.TabIndex = 2;
            // 
            // logintxt
            // 
            logintxt.BackColor = Color.LightCyan;
            logintxt.BorderStyle = BorderStyle.None;
            logintxt.Dock = DockStyle.Fill;
            logintxt.Font = new Font("Microsoft JhengHei UI", 20F);
            logintxt.Location = new Point(802, 4);
            logintxt.Name = "logintxt";
            logintxt.ReadOnly = true;
            logintxt.Size = new Size(278, 34);
            logintxt.TabIndex = 0;
            // 
            // showrecipetxt
            // 
            showrecipetxt.BackColor = Color.LightCyan;
            showrecipetxt.BorderStyle = BorderStyle.None;
            showrecipetxt.Dock = DockStyle.Fill;
            showrecipetxt.Font = new Font("Microsoft JhengHei UI", 20F);
            showrecipetxt.Location = new Point(802, 62);
            showrecipetxt.Name = "showrecipetxt";
            showrecipetxt.ReadOnly = true;
            showrecipetxt.Size = new Size(278, 34);
            showrecipetxt.TabIndex = 1;
            // 
            // alarmpanel
            // 
            alarmpanel.Controls.Add(alarmtxt);
            alarmpanel.Dock = DockStyle.Fill;
            alarmpanel.Location = new Point(286, 4);
            alarmpanel.Name = "alarmpanel";
            alarmpanel.Size = new Size(509, 51);
            alarmpanel.TabIndex = 0;
            // 
            // alarmtxt
            // 
            alarmtxt.Font = new Font("Microsoft JhengHei UI", 20F);
            alarmtxt.Location = new Point(0, 0);
            alarmtxt.Name = "alarmtxt";
            alarmtxt.Size = new Size(508, 51);
            alarmtxt.TabIndex = 0;
            // 
            // nowtime
            // 
            nowtime.Enabled = true;
            nowtime.Interval = 1000;
            nowtime.Tick += nowtime_Tick;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.company;
            pictureBox1.Location = new Point(3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(96, 113);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // greenlight
            // 
            greenlight.BackColor = Color.Gray;
            greenlight.Font = new Font("Microsoft JhengHei UI", 20F);
            greenlight.Location = new Point(1194, 7);
            greenlight.Name = "greenlight";
            greenlight.Size = new Size(76, 30);
            greenlight.TabIndex = 6;
            // 
            // orangelight
            // 
            orangelight.BackColor = Color.Gray;
            orangelight.Font = new Font("Microsoft JhengHei UI", 20F);
            orangelight.Location = new Point(1194, 46);
            orangelight.Name = "orangelight";
            orangelight.Size = new Size(76, 30);
            orangelight.TabIndex = 7;
            // 
            // redlight
            // 
            redlight.BackColor = Color.Gray;
            redlight.Font = new Font("Microsoft JhengHei UI", 20F);
            redlight.Location = new Point(1194, 85);
            redlight.Name = "redlight";
            redlight.Size = new Size(76, 30);
            redlight.TabIndex = 8;
            // 
            // ticker
            // 
            ticker.Interval = 20;
            ticker.Tick += ticker_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSlateGray;
            ClientSize = new Size(1272, 691);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(redlight);
            Controls.Add(orangelight);
            Controls.Add(greenlight);
            Controls.Add(pictureBox1);
            Controls.Add(panel2);
            Controls.Add(MainPage);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            panel2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            eventpanel.ResumeLayout(false);
            alarmpanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private TextBox equipmentstatus;
        private PictureBox pictureBox1;
        private Label greenlight;
        private Label orangelight;
        private Label redlight;
        private Label alarmtxt;
        private Panel alarmpanel;
        private System.Windows.Forms.Timer ticker;
        private Label eventtxt;
        private Panel eventpanel;
    }
}
