namespace AFLA_001
{
    partial class HomeForm
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
            button1 = new Button();
            button2 = new Button();
            buzzerbtn = new Button();
            button4 = new Button();
            button5 = new Button();
            vaccumoffbtn = new Button();
            vaccumonbtn = new Button();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            pictureBox5 = new PictureBox();
            airpicture = new PictureBox();
            gluepicture = new PictureBox();
            label2 = new Label();
            pictureBox20 = new PictureBox();
            showair = new PictureBox();
            showoil = new PictureBox();
            pictureBox35 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox7 = new PictureBox();
            oilpupic = new PictureBox();
            pipeoil11 = new PathDrawing.PipeControl();
            pipeoil12 = new PathDrawing.PipeControl();
            pipeoil15 = new PathDrawing.PipeControl();
            pipeoil14 = new PathDrawing.PipeControl();
            pipeoil2 = new PathDrawing.PipeControl();
            pipeControl7 = new PathDrawing.PipeControl();
            pipeoil16 = new PathDrawing.PipeControl();
            pipeoil13 = new PathDrawing.PipeControl();
            pipeoil17 = new PathDrawing.PipeControl();
            pipeipa1 = new PathDrawing.PipeControl();
            pipeipa2 = new PathDrawing.PipeControl();
            pipeipa3 = new PathDrawing.PipeControl();
            pipeglue1 = new PathDrawing.PipeControl();
            airpipe1 = new PathDrawing.PipeControl();
            pipeControl16 = new PathDrawing.PipeControl();
            airpipe2 = new PathDrawing.PipeControl();
            oil1val2 = new PathDrawing.ValveControl();
            ipavalve = new PathDrawing.ValveControl();
            glueval = new PathDrawing.ValveControl();
            vaccumval = new PathDrawing.ValveControl();
            oilval1 = new PathDrawing.ValveControl();
            airval = new PathDrawing.ValveControl();
            arm1Control1 = new PathDrawing.Arm1Control();
            arm2Control1 = new PathDrawing.Arm2Control();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)airpicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gluepicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox20).BeginInit();
            ((System.ComponentModel.ISupportInitialize)showair).BeginInit();
            ((System.ComponentModel.ISupportInitialize)showoil).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox35).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)oilpupic).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Microsoft JhengHei UI", 14F);
            button1.Location = new Point(1110, 21);
            button1.Name = "button1";
            button1.Size = new Size(156, 35);
            button1.TabIndex = 5;
            button1.Text = "INITIAL";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Font = new Font("Microsoft JhengHei UI", 14F);
            button2.Location = new Point(1110, 77);
            button2.Name = "button2";
            button2.Size = new Size(156, 35);
            button2.TabIndex = 6;
            button2.Text = "PROCESS";
            button2.UseVisualStyleBackColor = true;
            // 
            // buzzerbtn
            // 
            buzzerbtn.BackColor = Color.AliceBlue;
            buzzerbtn.Font = new Font("Microsoft JhengHei UI", 14F);
            buzzerbtn.Location = new Point(1110, 136);
            buzzerbtn.Name = "buzzerbtn";
            buzzerbtn.Size = new Size(156, 35);
            buzzerbtn.TabIndex = 7;
            buzzerbtn.Text = "BUZZER OFF";
            buzzerbtn.UseVisualStyleBackColor = false;
            buzzerbtn.Click += buzzerbtn_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Microsoft JhengHei UI", 14F);
            button4.Location = new Point(1110, 252);
            button4.Name = "button4";
            button4.Size = new Size(156, 35);
            button4.TabIndex = 9;
            button4.Text = "HEPA";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Font = new Font("Microsoft JhengHei UI", 14F);
            button5.Location = new Point(1110, 193);
            button5.Name = "button5";
            button5.Size = new Size(156, 35);
            button5.TabIndex = 8;
            button5.Text = "STOP";
            button5.UseVisualStyleBackColor = true;
            // 
            // vaccumoffbtn
            // 
            vaccumoffbtn.BackColor = Color.AliceBlue;
            vaccumoffbtn.Font = new Font("Microsoft JhengHei UI", 14F);
            vaccumoffbtn.Location = new Point(1110, 366);
            vaccumoffbtn.Name = "vaccumoffbtn";
            vaccumoffbtn.Size = new Size(156, 35);
            vaccumoffbtn.TabIndex = 11;
            vaccumoffbtn.Text = "VACCUM OFF";
            vaccumoffbtn.UseVisualStyleBackColor = false;
            vaccumoffbtn.Click += vaccumCheck_Click;
            // 
            // vaccumonbtn
            // 
            vaccumonbtn.BackColor = Color.AliceBlue;
            vaccumonbtn.Font = new Font("Microsoft JhengHei UI", 14F);
            vaccumonbtn.Location = new Point(1110, 307);
            vaccumonbtn.Name = "vaccumonbtn";
            vaccumonbtn.Size = new Size(156, 35);
            vaccumonbtn.TabIndex = 10;
            vaccumonbtn.Text = "VACCUM ON";
            vaccumonbtn.UseVisualStyleBackColor = false;
            vaccumonbtn.Click += vaccumCheck_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.vaccum1;
            pictureBox1.Location = new Point(181, 401);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(147, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 15F);
            label1.Location = new Point(197, 418);
            label1.Name = "label1";
            label1.Size = new Size(99, 25);
            label1.TabIndex = 13;
            label1.Text = "VACCUM";
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.wastank2;
            pictureBox5.Location = new Point(390, 371);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(158, 75);
            pictureBox5.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox5.TabIndex = 16;
            pictureBox5.TabStop = false;
            // 
            // airpicture
            // 
            airpicture.Image = Properties.Resources.air;
            airpicture.Location = new Point(98, 353);
            airpicture.Name = "airpicture";
            airpicture.Size = new Size(33, 96);
            airpicture.SizeMode = PictureBoxSizeMode.AutoSize;
            airpicture.TabIndex = 32;
            airpicture.TabStop = false;
            // 
            // gluepicture
            // 
            gluepicture.BackColor = Color.Transparent;
            gluepicture.Image = Properties.Resources.glueout1;
            gluepicture.Location = new Point(91, -2);
            gluepicture.Name = "gluepicture";
            gluepicture.Size = new Size(130, 92);
            gluepicture.SizeMode = PictureBoxSizeMode.AutoSize;
            gluepicture.TabIndex = 30;
            gluepicture.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei UI", 15F);
            label2.Location = new Point(409, 410);
            label2.Name = "label2";
            label2.Size = new Size(120, 25);
            label2.TabIndex = 38;
            label2.Text = "Waste Tank";
            // 
            // pictureBox20
            // 
            pictureBox20.Image = Properties.Resources.tank_oil;
            pictureBox20.Location = new Point(734, 213);
            pictureBox20.Name = "pictureBox20";
            pictureBox20.Size = new Size(59, 87);
            pictureBox20.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox20.TabIndex = 50;
            pictureBox20.TabStop = false;
            // 
            // showair
            // 
            showair.Image = Properties.Resources.flow_air;
            showair.Location = new Point(241, 232);
            showair.Name = "showair";
            showair.Size = new Size(41, 41);
            showair.SizeMode = PictureBoxSizeMode.Zoom;
            showair.TabIndex = 63;
            showair.TabStop = false;
            showair.Visible = false;
            // 
            // showoil
            // 
            showoil.Image = Properties.Resources.flow_oil;
            showoil.Location = new Point(564, 223);
            showoil.Name = "showoil";
            showoil.Size = new Size(42, 41);
            showoil.SizeMode = PictureBoxSizeMode.Zoom;
            showoil.TabIndex = 64;
            showoil.TabStop = false;
            showoil.Visible = false;
            // 
            // pictureBox35
            // 
            pictureBox35.BackColor = Color.Transparent;
            pictureBox35.Image = Properties.Resources.tank_ipa;
            pictureBox35.Location = new Point(603, 24);
            pictureBox35.Name = "pictureBox35";
            pictureBox35.Size = new Size(59, 87);
            pictureBox35.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox35.TabIndex = 65;
            pictureBox35.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.cup;
            pictureBox3.Location = new Point(205, 181);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(374, 27);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 67;
            pictureBox3.TabStop = false;
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = Color.Transparent;
            pictureBox7.Image = Properties.Resources.mada;
            pictureBox7.Location = new Point(326, 214);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(85, 147);
            pictureBox7.TabIndex = 68;
            pictureBox7.TabStop = false;
            // 
            // oilpupic
            // 
            oilpupic.Image = Properties.Resources.oilpu;
            oilpupic.Location = new Point(324, 133);
            oilpupic.Name = "oilpupic";
            oilpupic.Size = new Size(102, 47);
            oilpupic.SizeMode = PictureBoxSizeMode.Zoom;
            oilpupic.TabIndex = 69;
            oilpupic.TabStop = false;
            oilpupic.Visible = false;
            // 
            // pipeoil11
            // 
            pipeoil11.Location = new Point(702, 181);
            pipeoil11.Name = "pipeoil11";
            pipeoil11.Shape = PathDrawing.PipeShape.LeftDown;
            pipeoil11.Size = new Size(124, 35);
            pipeoil11.TabIndex = 70;
            pipeoil11.Text = "pipeControl1";
            // 
            // pipeoil12
            // 
            pipeoil12.Location = new Point(629, 181);
            pipeoil12.Name = "pipeoil12";
            pipeoil12.Shape = PathDrawing.PipeShape.TeeRight;
            pipeoil12.Size = new Size(74, 35);
            pipeoil12.TabIndex = 72;
            pipeoil12.Text = "pipeControl3";
            // 
            // pipeoil15
            // 
            pipeoil15.Location = new Point(606, 410);
            pipeoil15.Name = "pipeoil15";
            pipeoil15.Shape = PathDrawing.PipeShape.LeftUp;
            pipeoil15.Size = new Size(120, 30);
            pipeoil15.TabIndex = 74;
            pipeoil15.Text = "pipeControl5";
            // 
            // pipeoil14
            // 
            pipeoil14.Location = new Point(648, 213);
            pipeoil14.Name = "pipeoil14";
            pipeoil14.Shape = PathDrawing.PipeShape.Vertical;
            pipeoil14.Size = new Size(37, 201);
            pipeoil14.TabIndex = 73;
            pipeoil14.Text = "pipeControl4";
            // 
            // pipeoil2
            // 
            pipeoil2.Location = new Point(565, 266);
            pipeoil2.Name = "pipeoil2";
            pipeoil2.Shape = PathDrawing.PipeShape.Vertical;
            pipeoil2.Size = new Size(37, 89);
            pipeoil2.TabIndex = 75;
            pipeoil2.Text = "pipeControl6";
            // 
            // pipeControl7
            // 
            pipeControl7.Location = new Point(440, 216);
            pipeControl7.Name = "pipeControl7";
            pipeControl7.Shape = PathDrawing.PipeShape.Vertical;
            pipeControl7.Size = new Size(37, 155);
            pipeControl7.TabIndex = 76;
            pipeControl7.Text = "pipeControl7";
            // 
            // pipeoil16
            // 
            pipeoil16.Location = new Point(558, 397);
            pipeoil16.Name = "pipeoil16";
            pipeoil16.Shape = PathDrawing.PipeShape.RightUp;
            pipeoil16.Size = new Size(49, 55);
            pipeoil16.TabIndex = 77;
            pipeoil16.Text = "pipeControl8";
            // 
            // pipeoil13
            // 
            pipeoil13.Location = new Point(607, 110);
            pipeoil13.Name = "pipeoil13";
            pipeoil13.Shape = PathDrawing.PipeShape.LeftDown;
            pipeoil13.Size = new Size(119, 32);
            pipeoil13.TabIndex = 78;
            pipeoil13.Text = "pipeControl9";
            // 
            // pipeoil17
            // 
            pipeoil17.Location = new Point(523, 111);
            pipeoil17.Name = "pipeoil17";
            pipeoil17.Size = new Size(85, 30);
            pipeoil17.TabIndex = 79;
            pipeoil17.Text = "pipeControl10";
            // 
            // pipeipa1
            // 
            pipeipa1.Location = new Point(574, -6);
            pipeipa1.Name = "pipeipa1";
            pipeipa1.Shape = PathDrawing.PipeShape.LeftDown;
            pipeipa1.Size = new Size(119, 32);
            pipeipa1.TabIndex = 80;
            pipeipa1.Text = "pipeControl11";
            // 
            // pipeipa2
            // 
            pipeipa2.Location = new Point(415, -10);
            pipeipa2.Name = "pipeipa2";
            pipeipa2.Shape = PathDrawing.PipeShape.RightDown;
            pipeipa2.Size = new Size(160, 41);
            pipeipa2.TabIndex = 82;
            pipeipa2.Text = "pipeControl13";
            // 
            // pipeipa3
            // 
            pipeipa3.Location = new Point(415, 24);
            pipeipa3.Name = "pipeipa3";
            pipeipa3.Shape = PathDrawing.PipeShape.Vertical;
            pipeipa3.Size = new Size(160, 23);
            pipeipa3.TabIndex = 83;
            pipeipa3.Text = "pipeControl14";
            // 
            // pipeglue1
            // 
            pipeglue1.Location = new Point(207, -6);
            pipeglue1.Name = "pipeglue1";
            pipeglue1.Shape = PathDrawing.PipeShape.LeftDown;
            pipeglue1.Size = new Size(160, 32);
            pipeglue1.TabIndex = 85;
            pipeglue1.Text = "pipeControl15";
            // 
            // airpipe1
            // 
            airpipe1.Location = new Point(34, 322);
            airpipe1.Name = "airpipe1";
            airpipe1.Shape = PathDrawing.PipeShape.RightDown;
            airpipe1.Size = new Size(160, 32);
            airpipe1.TabIndex = 86;
            airpipe1.Text = "pipeControl2";
            // 
            // pipeControl16
            // 
            pipeControl16.BendX = 40;
            pipeControl16.BendY = 80;
            pipeControl16.Location = new Point(325, 406);
            pipeControl16.Name = "pipeControl16";
            pipeControl16.Shape = PathDrawing.PipeShape.LeftUp;
            pipeControl16.Size = new Size(103, 50);
            pipeControl16.TabIndex = 87;
            pipeControl16.Text = "pipeControl16";
            // 
            // airpipe2
            // 
            airpipe2.Location = new Point(178, 322);
            airpipe2.Name = "airpipe2";
            airpipe2.Shape = PathDrawing.PipeShape.LeftUp;
            airpipe2.Size = new Size(160, 32);
            airpipe2.TabIndex = 88;
            airpipe2.Text = "pipeControl17";
            // 
            // oil1val2
            // 
            oil1val2.Location = new Point(564, 349);
            oil1val2.Name = "oil1val2";
            oil1val2.Size = new Size(36, 48);
            oil1val2.TabIndex = 89;
            oil1val2.Text = "valveControl1";
            // 
            // ipavalve
            // 
            ipavalve.Location = new Point(477, 40);
            ipavalve.Name = "ipavalve";
            ipavalve.Size = new Size(36, 62);
            ipavalve.TabIndex = 90;
            ipavalve.Text = "valveControl1";
            // 
            // glueval
            // 
            glueval.Location = new Point(269, 26);
            glueval.Name = "glueval";
            glueval.Size = new Size(36, 53);
            glueval.TabIndex = 91;
            glueval.Text = "valveControl1";
            glueval.Click += glueval_Click;
            // 
            // vaccumval
            // 
            vaccumval.Location = new Point(348, 363);
            vaccumval.Name = "vaccumval";
            vaccumval.Size = new Size(36, 48);
            vaccumval.TabIndex = 93;
            vaccumval.Text = "valveControl1";
            // 
            // oilval1
            // 
            oilval1.Location = new Point(648, 136);
            oilval1.Name = "oilval1";
            oilval1.Size = new Size(36, 48);
            oilval1.TabIndex = 92;
            oilval1.Text = "valveControl4";
            // 
            // airval
            // 
            airval.Location = new Point(241, 275);
            airval.Name = "airval";
            airval.Size = new Size(36, 48);
            airval.TabIndex = 94;
            airval.Text = "valveControl6";
            // 
            // arm1Control1
            // 
            arm1Control1.Location = new Point(466, 89);
            arm1Control1.Name = "arm1Control1";
            arm1Control1.Size = new Size(69, 68);
            arm1Control1.TabIndex = 95;
            arm1Control1.Text = "arm1Control1";
            // 
            // arm2Control1
            // 
            arm2Control1.Location = new Point(274, 70);
            arm2Control1.Name = "arm2Control1";
            arm2Control1.Size = new Size(47, 71);
            arm2Control1.TabIndex = 96;
            arm2Control1.Text = "arm2Control1";
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1267, 452);
            ControlBox = false;
            Controls.Add(pipeoil17);
            Controls.Add(pictureBox35);
            Controls.Add(ipavalve);
            Controls.Add(pipeipa2);
            Controls.Add(pipeipa1);
            Controls.Add(oilpupic);
            Controls.Add(pipeoil12);
            Controls.Add(airval);
            Controls.Add(vaccumval);
            Controls.Add(oilval1);
            Controls.Add(glueval);
            Controls.Add(pipeoil14);
            Controls.Add(pipeoil16);
            Controls.Add(oil1val2);
            Controls.Add(pipeoil15);
            Controls.Add(pictureBox7);
            Controls.Add(label2);
            Controls.Add(pictureBox5);
            Controls.Add(pipeControl16);
            Controls.Add(airpipe1);
            Controls.Add(pipeglue1);
            Controls.Add(pipeipa3);
            Controls.Add(pipeoil13);
            Controls.Add(pipeControl7);
            Controls.Add(pipeoil2);
            Controls.Add(pipeoil11);
            Controls.Add(pictureBox3);
            Controls.Add(showoil);
            Controls.Add(showair);
            Controls.Add(airpicture);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(vaccumoffbtn);
            Controls.Add(vaccumonbtn);
            Controls.Add(button4);
            Controls.Add(button5);
            Controls.Add(buzzerbtn);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(airpipe2);
            Controls.Add(gluepicture);
            Controls.Add(pictureBox20);
            Controls.Add(arm2Control1);
            Controls.Add(arm1Control1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "HomeForm";
            Text = "HomeForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)airpicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)gluepicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox20).EndInit();
            ((System.ComponentModel.ISupportInitialize)showair).EndInit();
            ((System.ComponentModel.ISupportInitialize)showoil).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox35).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)oilpupic).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button buzzerbtn;
        private Button button4;
        private Button button5;
        private Button vaccumoffbtn;
        private Button vaccumonbtn;
        private PictureBox pictureBox1;
        private Label label1;
        private PictureBox pictureBox5;
        private PictureBox airpicture;
        private PictureBox gluepicture;
        private Label label2;
        private PictureBox pictureBox20;
        private PictureBox showair;
        private PictureBox showoil;
        private PictureBox pictureBox35;
        private PictureBox pictureBox3;
        private PictureBox pictureBox7;
        private PictureBox oilpupic;
        private PathDrawing.PipeControl pipeoil11;
        private PathDrawing.PipeControl pipeoil12;
        private PathDrawing.PipeControl pipeoil15;
        private PathDrawing.PipeControl pipeoil14;
        private PathDrawing.PipeControl pipeoil2;
        private PathDrawing.PipeControl pipeControl7;
        private PathDrawing.PipeControl pipeoil16;
        private PathDrawing.PipeControl pipeoil13;
        private PathDrawing.PipeControl pipeoil17;
        private PathDrawing.PipeControl pipeipa1;
        private PathDrawing.PipeControl pipeipa2;
        private PathDrawing.PipeControl pipeipa3;
        private PathDrawing.PipeControl pipeglue1;
        private PathDrawing.PipeControl airpipe1;
        private PathDrawing.PipeControl pipeControl16;
        private PathDrawing.PipeControl airpipe2;
        private PathDrawing.ValveControl oil1val2;
        private PathDrawing.ValveControl ipavalve;
        private PathDrawing.ValveControl glueval;
        private PathDrawing.ValveControl vaccumval;
        private PathDrawing.ValveControl oilval1;
        private PathDrawing.ValveControl airval;
        private PathDrawing.Arm1Control arm1Control1;
        private PathDrawing.Arm2Control arm2Control1;
    }
}