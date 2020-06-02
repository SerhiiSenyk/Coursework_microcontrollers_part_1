namespace WindowsFormsAppMCLab9
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.buttonOpenPort = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.progressBar_A_left = new System.Windows.Forms.ProgressBar();
            this.progressBar_A_right = new System.Windows.Forms.ProgressBar();
            this.progressBar_B_left = new System.Windows.Forms.ProgressBar();
            this.progressBar_B_right = new System.Windows.Forms.ProgressBar();
            this.hScrollBar_B = new System.Windows.Forms.HScrollBar();
            this.hScrollBar_A = new System.Windows.Forms.HScrollBar();
            this.label_motor_A = new System.Windows.Forms.Label();
            this.label_motor_B = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_stop_A = new System.Windows.Forms.Button();
            this.button_start_A = new System.Windows.Forms.Button();
            this.button_stop_B = new System.Windows.Forms.Button();
            this.button_start_B = new System.Windows.Forms.Button();
            this.comboBox_mode_A = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_mode_B = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_slaves = new System.Windows.Forms.ComboBox();
            this.hScrollBar_speed_A = new System.Windows.Forms.HScrollBar();
            this.progressBar_speed_A = new System.Windows.Forms.ProgressBar();
            this.progressBar_speed_B = new System.Windows.Forms.ProgressBar();
            this.hScrollBar_speed_B = new System.Windows.Forms.HScrollBar();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label_speed_A = new System.Windows.Forms.Label();
            this.label_speed_B = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(193, 29);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 33);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Click += new System.EventHandler(this.comboBox1_Click);
            // 
            // buttonOpenPort
            // 
            this.buttonOpenPort.BackColor = System.Drawing.Color.White;
            this.buttonOpenPort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonOpenPort.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOpenPort.Location = new System.Drawing.Point(329, 28);
            this.buttonOpenPort.Name = "buttonOpenPort";
            this.buttonOpenPort.Size = new System.Drawing.Size(122, 45);
            this.buttonOpenPort.TabIndex = 1;
            this.buttonOpenPort.Text = "Open";
            this.buttonOpenPort.UseVisualStyleBackColor = false;
            this.buttonOpenPort.Click += new System.EventHandler(this.buttonOpenPort_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 30);
            this.label1.TabIndex = 8;
            this.label1.Text = "COM port:";
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // progressBar_A_left
            // 
            this.progressBar_A_left.Enabled = false;
            this.progressBar_A_left.Location = new System.Drawing.Point(51, 149);
            this.progressBar_A_left.Maximum = 999;
            this.progressBar_A_left.Name = "progressBar_A_left";
            this.progressBar_A_left.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.progressBar_A_left.RightToLeftLayout = true;
            this.progressBar_A_left.Size = new System.Drawing.Size(425, 30);
            this.progressBar_A_left.Step = 1;
            this.progressBar_A_left.TabIndex = 21;
            // 
            // progressBar_A_right
            // 
            this.progressBar_A_right.Enabled = false;
            this.progressBar_A_right.Location = new System.Drawing.Point(508, 149);
            this.progressBar_A_right.Maximum = 999;
            this.progressBar_A_right.Name = "progressBar_A_right";
            this.progressBar_A_right.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.progressBar_A_right.Size = new System.Drawing.Size(425, 30);
            this.progressBar_A_right.Step = 1;
            this.progressBar_A_right.TabIndex = 21;
            // 
            // progressBar_B_left
            // 
            this.progressBar_B_left.Enabled = false;
            this.progressBar_B_left.Location = new System.Drawing.Point(51, 429);
            this.progressBar_B_left.Maximum = 999;
            this.progressBar_B_left.Name = "progressBar_B_left";
            this.progressBar_B_left.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.progressBar_B_left.RightToLeftLayout = true;
            this.progressBar_B_left.Size = new System.Drawing.Size(425, 30);
            this.progressBar_B_left.Step = 1;
            this.progressBar_B_left.TabIndex = 21;
            // 
            // progressBar_B_right
            // 
            this.progressBar_B_right.Enabled = false;
            this.progressBar_B_right.Location = new System.Drawing.Point(508, 429);
            this.progressBar_B_right.Maximum = 999;
            this.progressBar_B_right.Name = "progressBar_B_right";
            this.progressBar_B_right.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.progressBar_B_right.Size = new System.Drawing.Size(425, 30);
            this.progressBar_B_right.Step = 1;
            this.progressBar_B_right.TabIndex = 21;
            // 
            // hScrollBar_B
            // 
            this.hScrollBar_B.Enabled = false;
            this.hScrollBar_B.LargeChange = 1;
            this.hScrollBar_B.Location = new System.Drawing.Point(51, 479);
            this.hScrollBar_B.Maximum = 999;
            this.hScrollBar_B.Minimum = -999;
            this.hScrollBar_B.Name = "hScrollBar_B";
            this.hScrollBar_B.Size = new System.Drawing.Size(882, 20);
            this.hScrollBar_B.TabIndex = 21;
            this.hScrollBar_B.ValueChanged += new System.EventHandler(this.hScrollBar_B_ValueChanged);
            // 
            // hScrollBar_A
            // 
            this.hScrollBar_A.AllowDrop = true;
            this.hScrollBar_A.Enabled = false;
            this.hScrollBar_A.LargeChange = 1;
            this.hScrollBar_A.Location = new System.Drawing.Point(51, 194);
            this.hScrollBar_A.Maximum = 999;
            this.hScrollBar_A.Minimum = -999;
            this.hScrollBar_A.Name = "hScrollBar_A";
            this.hScrollBar_A.Size = new System.Drawing.Size(882, 20);
            this.hScrollBar_A.TabIndex = 21;
            this.hScrollBar_A.ValueChanged += new System.EventHandler(this.hScrollBar_A_ValueChanged);
            // 
            // label_motor_A
            // 
            this.label_motor_A.AutoSize = true;
            this.label_motor_A.BackColor = System.Drawing.Color.Transparent;
            this.label_motor_A.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_motor_A.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_motor_A.Location = new System.Drawing.Point(465, 100);
            this.label_motor_A.Name = "label_motor_A";
            this.label_motor_A.Size = new System.Drawing.Size(43, 46);
            this.label_motor_A.TabIndex = 22;
            this.label_motor_A.Text = "0";
            // 
            // label_motor_B
            // 
            this.label_motor_B.AutoSize = true;
            this.label_motor_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_motor_B.Location = new System.Drawing.Point(465, 375);
            this.label_motor_B.Name = "label_motor_B";
            this.label_motor_B.Size = new System.Drawing.Size(43, 46);
            this.label_motor_B.TabIndex = 23;
            this.label_motor_B.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 36);
            this.label2.TabIndex = 24;
            this.label2.Text = "Motor A :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(47, 380);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 36);
            this.label3.TabIndex = 25;
            this.label3.Text = "Motor B :";
            // 
            // button_stop_A
            // 
            this.button_stop_A.BackColor = System.Drawing.Color.Red;
            this.button_stop_A.Enabled = false;
            this.button_stop_A.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_stop_A.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button_stop_A.Location = new System.Drawing.Point(51, 237);
            this.button_stop_A.Name = "button_stop_A";
            this.button_stop_A.Size = new System.Drawing.Size(120, 60);
            this.button_stop_A.TabIndex = 26;
            this.button_stop_A.Text = "Stop A";
            this.button_stop_A.UseVisualStyleBackColor = false;
            this.button_stop_A.Click += new System.EventHandler(this.button_stop_A_Click);
            // 
            // button_start_A
            // 
            this.button_start_A.BackColor = System.Drawing.Color.Lime;
            this.button_start_A.Enabled = false;
            this.button_start_A.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_start_A.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button_start_A.Location = new System.Drawing.Point(49, 303);
            this.button_start_A.Name = "button_start_A";
            this.button_start_A.Size = new System.Drawing.Size(120, 60);
            this.button_start_A.TabIndex = 27;
            this.button_start_A.Text = "Start A";
            this.button_start_A.UseVisualStyleBackColor = false;
            this.button_start_A.Click += new System.EventHandler(this.button_start_A_Click);
            // 
            // button_stop_B
            // 
            this.button_stop_B.BackColor = System.Drawing.Color.Red;
            this.button_stop_B.Enabled = false;
            this.button_stop_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_stop_B.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button_stop_B.Location = new System.Drawing.Point(53, 525);
            this.button_stop_B.Name = "button_stop_B";
            this.button_stop_B.Size = new System.Drawing.Size(120, 60);
            this.button_stop_B.TabIndex = 28;
            this.button_stop_B.Text = "Stop  B";
            this.button_stop_B.UseVisualStyleBackColor = false;
            this.button_stop_B.Click += new System.EventHandler(this.button_stop_B_Click);
            // 
            // button_start_B
            // 
            this.button_start_B.BackColor = System.Drawing.Color.Lime;
            this.button_start_B.Enabled = false;
            this.button_start_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_start_B.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button_start_B.Location = new System.Drawing.Point(53, 591);
            this.button_start_B.Name = "button_start_B";
            this.button_start_B.Size = new System.Drawing.Size(120, 60);
            this.button_start_B.TabIndex = 29;
            this.button_start_B.Text = "Start B";
            this.button_start_B.UseVisualStyleBackColor = false;
            this.button_start_B.Click += new System.EventHandler(this.button_start_B_Click);
            // 
            // comboBox_mode_A
            // 
            this.comboBox_mode_A.BackColor = System.Drawing.SystemColors.HighlightText;
            this.comboBox_mode_A.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_mode_A.Enabled = false;
            this.comboBox_mode_A.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_mode_A.FormattingEnabled = true;
            this.comboBox_mode_A.Items.AddRange(new object[] {
            "One phase",
            "Two phase",
            "Half step"});
            this.comboBox_mode_A.Location = new System.Drawing.Point(306, 251);
            this.comboBox_mode_A.Name = "comboBox_mode_A";
            this.comboBox_mode_A.Size = new System.Drawing.Size(145, 34);
            this.comboBox_mode_A.TabIndex = 0;
            this.comboBox_mode_A.SelectedIndexChanged += new System.EventHandler(this.comboBox_mode_A_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(185, 251);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 36);
            this.label4.TabIndex = 30;
            this.label4.Text = "Mode :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(187, 537);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 36);
            this.label5.TabIndex = 32;
            this.label5.Text = "Mode :";
            // 
            // comboBox_mode_B
            // 
            this.comboBox_mode_B.BackColor = System.Drawing.SystemColors.HighlightText;
            this.comboBox_mode_B.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_mode_B.Enabled = false;
            this.comboBox_mode_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_mode_B.FormattingEnabled = true;
            this.comboBox_mode_B.Items.AddRange(new object[] {
            "One phase",
            "Two phase",
            "Half step"});
            this.comboBox_mode_B.Location = new System.Drawing.Point(301, 539);
            this.comboBox_mode_B.Name = "comboBox_mode_B";
            this.comboBox_mode_B.Size = new System.Drawing.Size(150, 34);
            this.comboBox_mode_B.TabIndex = 31;
            this.comboBox_mode_B.SelectedIndexChanged += new System.EventHandler(this.comboBox_mode_B_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(580, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 36);
            this.label6.TabIndex = 34;
            this.label6.Text = "Slave";
            // 
            // comboBox_slaves
            // 
            this.comboBox_slaves.BackColor = System.Drawing.SystemColors.HighlightText;
            this.comboBox_slaves.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_slaves.Enabled = false;
            this.comboBox_slaves.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_slaves.FormattingEnabled = true;
            this.comboBox_slaves.Items.AddRange(new object[] {
            "Slave 1",
            "Slave 2",
            "Slave 3"});
            this.comboBox_slaves.Location = new System.Drawing.Point(692, 36);
            this.comboBox_slaves.Name = "comboBox_slaves";
            this.comboBox_slaves.Size = new System.Drawing.Size(154, 34);
            this.comboBox_slaves.TabIndex = 33;
            this.comboBox_slaves.SelectedIndexChanged += new System.EventHandler(this.comboBox_slaves_SelectedIndexChanged);
            // 
            // hScrollBar_speed_A
            // 
            this.hScrollBar_speed_A.Enabled = false;
            this.hScrollBar_speed_A.LargeChange = 1;
            this.hScrollBar_speed_A.Location = new System.Drawing.Point(508, 339);
            this.hScrollBar_speed_A.Maximum = 8;
            this.hScrollBar_speed_A.Name = "hScrollBar_speed_A";
            this.hScrollBar_speed_A.Size = new System.Drawing.Size(425, 20);
            this.hScrollBar_speed_A.TabIndex = 35;
            this.hScrollBar_speed_A.ValueChanged += new System.EventHandler(this.hScrollBar_speed_A_ValueChanged);
            // 
            // progressBar_speed_A
            // 
            this.progressBar_speed_A.Enabled = false;
            this.progressBar_speed_A.Location = new System.Drawing.Point(508, 294);
            this.progressBar_speed_A.Maximum = 8;
            this.progressBar_speed_A.Name = "progressBar_speed_A";
            this.progressBar_speed_A.Size = new System.Drawing.Size(425, 30);
            this.progressBar_speed_A.TabIndex = 36;
            // 
            // progressBar_speed_B
            // 
            this.progressBar_speed_B.Enabled = false;
            this.progressBar_speed_B.Location = new System.Drawing.Point(508, 589);
            this.progressBar_speed_B.Maximum = 8;
            this.progressBar_speed_B.Name = "progressBar_speed_B";
            this.progressBar_speed_B.Size = new System.Drawing.Size(425, 30);
            this.progressBar_speed_B.TabIndex = 38;
            // 
            // hScrollBar_speed_B
            // 
            this.hScrollBar_speed_B.Enabled = false;
            this.hScrollBar_speed_B.LargeChange = 1;
            this.hScrollBar_speed_B.Location = new System.Drawing.Point(508, 634);
            this.hScrollBar_speed_B.Maximum = 8;
            this.hScrollBar_speed_B.Name = "hScrollBar_speed_B";
            this.hScrollBar_speed_B.Size = new System.Drawing.Size(425, 20);
            this.hScrollBar_speed_B.TabIndex = 37;
            this.hScrollBar_speed_B.ValueChanged += new System.EventHandler(this.hScrollBar_speed_B_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(502, 246);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(255, 36);
            this.label7.TabIndex = 39;
            this.label7.Text = "Speed  prescalar :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(502, 534);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(247, 36);
            this.label8.TabIndex = 40;
            this.label8.Text = "Speed prescalar :";
            // 
            // label_speed_A
            // 
            this.label_speed_A.AutoSize = true;
            this.label_speed_A.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_speed_A.Location = new System.Drawing.Point(755, 249);
            this.label_speed_A.Name = "label_speed_A";
            this.label_speed_A.Size = new System.Drawing.Size(32, 36);
            this.label_speed_A.TabIndex = 41;
            this.label_speed_A.Text = "1";
            // 
            // label_speed_B
            // 
            this.label_speed_B.AutoSize = true;
            this.label_speed_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_speed_B.Location = new System.Drawing.Point(755, 534);
            this.label_speed_B.Name = "label_speed_B";
            this.label_speed_B.Size = new System.Drawing.Size(32, 36);
            this.label_speed_B.TabIndex = 42;
            this.label_speed_B.Text = "1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(978, 844);
            this.Controls.Add(this.label_speed_B);
            this.Controls.Add(this.label_speed_A);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.progressBar_speed_B);
            this.Controls.Add(this.hScrollBar_speed_B);
            this.Controls.Add(this.progressBar_speed_A);
            this.Controls.Add(this.hScrollBar_speed_A);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox_slaves);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox_mode_B);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_mode_A);
            this.Controls.Add(this.button_start_B);
            this.Controls.Add(this.button_stop_B);
            this.Controls.Add(this.button_start_A);
            this.Controls.Add(this.button_stop_A);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_motor_B);
            this.Controls.Add(this.label_motor_A);
            this.Controls.Add(this.hScrollBar_A);
            this.Controls.Add(this.hScrollBar_B);
            this.Controls.Add(this.progressBar_B_right);
            this.Controls.Add(this.progressBar_B_left);
            this.Controls.Add(this.progressBar_A_right);
            this.Controls.Add(this.progressBar_A_left);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonOpenPort);
            this.Controls.Add(this.comboBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 900);
            this.MinimumSize = new System.Drawing.Size(1000, 850);
            this.Name = "Form1";
            this.Text = "Unipolar stepper motors";
            this.TransparencyKey = System.Drawing.Color.Gray;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button buttonOpenPort;
        private System.Windows.Forms.Label label1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ProgressBar progressBar_A_left;
        private System.Windows.Forms.ProgressBar progressBar_A_right;
        private System.Windows.Forms.ProgressBar progressBar_B_left;
        private System.Windows.Forms.ProgressBar progressBar_B_right;
        private System.Windows.Forms.HScrollBar hScrollBar_B;
        private System.Windows.Forms.HScrollBar hScrollBar_A;
        private System.Windows.Forms.Label label_motor_A;
        private System.Windows.Forms.Label label_motor_B;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_stop_A;
        private System.Windows.Forms.Button button_start_A;
        private System.Windows.Forms.Button button_stop_B;
        private System.Windows.Forms.Button button_start_B;
        private System.Windows.Forms.ComboBox comboBox_mode_A;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_mode_B;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_slaves;
        private System.Windows.Forms.HScrollBar hScrollBar_speed_A;
        private System.Windows.Forms.ProgressBar progressBar_speed_A;
        private System.Windows.Forms.ProgressBar progressBar_speed_B;
        private System.Windows.Forms.HScrollBar hScrollBar_speed_B;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label_speed_A;
        private System.Windows.Forms.Label label_speed_B;
    }
}

