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
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1272, 691);
            Controls.Add(panel2);
            Controls.Add(MainPage);
            Name = "Form1";
            Text = "Form1";
            panel2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
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
    }
}
