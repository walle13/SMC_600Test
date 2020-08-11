namespace SMC_600Test
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SB_Star = new System.Windows.Forms.Button();
            this.SB_Stop = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SB_Clear = new System.Windows.Forms.Button();
            this.connect = new System.Windows.Forms.Button();
            this.disconnect = new System.Windows.Forms.Button();
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.X_axis_plus = new System.Windows.Forms.Button();
            this.Y_axis_plus = new System.Windows.Forms.Button();
            this.Z_axis_plus = new System.Windows.Forms.Button();
            this.X_axis_sub = new System.Windows.Forms.Button();
            this.Y_axis_sub = new System.Windows.Forms.Button();
            this.Z_axis_sub = new System.Windows.Forms.Button();
            this.softHome = new System.Windows.Forms.Button();
            this.Home = new System.Windows.Forms.Button();
            this.NewForm1 = new System.Windows.Forms.Button();
            this.performanceCounter1 = new System.Diagnostics.PerformanceCounter();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.Send = new System.Windows.Forms.Button();
            this.ClearCode = new System.Windows.Forms.Button();
            this.textBox_Xaxis = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_Yaxis = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_Zaxis = new System.Windows.Forms.TextBox();
            this.setWorkpiece = new System.Windows.Forms.Button();
            this.setCurrent = new System.Windows.Forms.Button();
            this.textBox_Xspeed = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_Zspeed = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.status = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Pause = new System.Windows.Forms.Button();
            this.U_axis_plus = new System.Windows.Forms.Button();
            this.U_axis_sub = new System.Windows.Forms.Button();
            this.V_axis_plus = new System.Windows.Forms.Button();
            this.V_axis_sub = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.performanceCounter1)).BeginInit();
            this.SuspendLayout();
            // 
            // SB_Star
            // 
            this.SB_Star.Location = new System.Drawing.Point(12, 73);
            this.SB_Star.Name = "SB_Star";
            this.SB_Star.Size = new System.Drawing.Size(70, 50);
            this.SB_Star.TabIndex = 0;
            this.SB_Star.Text = "启动";
            this.SB_Star.UseVisualStyleBackColor = true;
            this.SB_Star.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SB_Star_MouseDown);
            this.SB_Star.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SB_Star_MouseUp);
            // 
            // SB_Stop
            // 
            this.SB_Stop.Location = new System.Drawing.Point(105, 73);
            this.SB_Stop.Name = "SB_Stop";
            this.SB_Stop.Size = new System.Drawing.Size(70, 50);
            this.SB_Stop.TabIndex = 1;
            this.SB_Stop.Text = "停止";
            this.SB_Stop.UseVisualStyleBackColor = true;
            this.SB_Stop.Click += new System.EventHandler(this.SB_Stop_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.Location = new System.Drawing.Point(12, 338);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(379, 21);
            this.textBox1.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SB_Clear
            // 
            this.SB_Clear.Location = new System.Drawing.Point(196, 73);
            this.SB_Clear.Name = "SB_Clear";
            this.SB_Clear.Size = new System.Drawing.Size(70, 50);
            this.SB_Clear.TabIndex = 3;
            this.SB_Clear.Text = "清零";
            this.SB_Clear.UseVisualStyleBackColor = true;
            this.SB_Clear.Click += new System.EventHandler(this.SB_Clear_Click);
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(12, 12);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(70, 50);
            this.connect.TabIndex = 4;
            this.connect.Text = "连接";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // disconnect
            // 
            this.disconnect.Location = new System.Drawing.Point(280, 12);
            this.disconnect.Name = "disconnect";
            this.disconnect.Size = new System.Drawing.Size(70, 50);
            this.disconnect.TabIndex = 5;
            this.disconnect.Text = "断开";
            this.disconnect.UseVisualStyleBackColor = true;
            this.disconnect.Click += new System.EventHandler(this.disconnect_Click);
            // 
            // textBox_IP
            // 
            this.textBox_IP.Location = new System.Drawing.Point(105, 28);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(161, 21);
            this.textBox_IP.TabIndex = 6;
            this.textBox_IP.Text = "192.168.5.11";
            // 
            // X_axis_plus
            // 
            this.X_axis_plus.Location = new System.Drawing.Point(12, 156);
            this.X_axis_plus.Name = "X_axis_plus";
            this.X_axis_plus.Size = new System.Drawing.Size(59, 50);
            this.X_axis_plus.TabIndex = 7;
            this.X_axis_plus.Text = "X+";
            this.X_axis_plus.UseVisualStyleBackColor = true;
            this.X_axis_plus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.X_axis_plus_MouseDown);
            this.X_axis_plus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.X_axis_plus_MouseUp);
            // 
            // Y_axis_plus
            // 
            this.Y_axis_plus.Location = new System.Drawing.Point(77, 156);
            this.Y_axis_plus.Name = "Y_axis_plus";
            this.Y_axis_plus.Size = new System.Drawing.Size(66, 50);
            this.Y_axis_plus.TabIndex = 8;
            this.Y_axis_plus.Text = "Y+";
            this.Y_axis_plus.UseVisualStyleBackColor = true;
            this.Y_axis_plus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Y_axis_plus_MouseDown);
            this.Y_axis_plus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Y_axis_plus_MouseUp);
            // 
            // Z_axis_plus
            // 
            this.Z_axis_plus.Location = new System.Drawing.Point(149, 156);
            this.Z_axis_plus.Name = "Z_axis_plus";
            this.Z_axis_plus.Size = new System.Drawing.Size(60, 50);
            this.Z_axis_plus.TabIndex = 9;
            this.Z_axis_plus.Text = "Z+";
            this.Z_axis_plus.UseVisualStyleBackColor = true;
            this.Z_axis_plus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Z_axis_plus_MouseDown);
            this.Z_axis_plus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Z_axis_plus_MouseUp);
            // 
            // X_axis_sub
            // 
            this.X_axis_sub.Location = new System.Drawing.Point(12, 212);
            this.X_axis_sub.Name = "X_axis_sub";
            this.X_axis_sub.Size = new System.Drawing.Size(59, 50);
            this.X_axis_sub.TabIndex = 10;
            this.X_axis_sub.Text = "X-";
            this.X_axis_sub.UseVisualStyleBackColor = true;
            this.X_axis_sub.MouseDown += new System.Windows.Forms.MouseEventHandler(this.X_axis_sub_MouseDown);
            this.X_axis_sub.MouseUp += new System.Windows.Forms.MouseEventHandler(this.X_axis_sub_MouseUp);
            // 
            // Y_axis_sub
            // 
            this.Y_axis_sub.Location = new System.Drawing.Point(77, 212);
            this.Y_axis_sub.Name = "Y_axis_sub";
            this.Y_axis_sub.Size = new System.Drawing.Size(65, 50);
            this.Y_axis_sub.TabIndex = 11;
            this.Y_axis_sub.Text = "Y-";
            this.Y_axis_sub.UseVisualStyleBackColor = true;
            this.Y_axis_sub.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Y_axis_sub_MouseDown);
            this.Y_axis_sub.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Y_axis_sub_MouseUp);
            // 
            // Z_axis_sub
            // 
            this.Z_axis_sub.Location = new System.Drawing.Point(148, 212);
            this.Z_axis_sub.Name = "Z_axis_sub";
            this.Z_axis_sub.Size = new System.Drawing.Size(61, 50);
            this.Z_axis_sub.TabIndex = 12;
            this.Z_axis_sub.Text = "Z-";
            this.Z_axis_sub.UseVisualStyleBackColor = true;
            this.Z_axis_sub.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Z_axis_sub_MouseDown);
            this.Z_axis_sub.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Z_axis_sub_MouseUp);
            // 
            // softHome
            // 
            this.softHome.Location = new System.Drawing.Point(345, 157);
            this.softHome.Name = "softHome";
            this.softHome.Size = new System.Drawing.Size(70, 50);
            this.softHome.TabIndex = 13;
            this.softHome.Text = "HOME";
            this.softHome.UseVisualStyleBackColor = true;
            this.softHome.Click += new System.EventHandler(this.softHome_Click);
            // 
            // Home
            // 
            this.Home.Location = new System.Drawing.Point(280, 73);
            this.Home.Name = "Home";
            this.Home.Size = new System.Drawing.Size(70, 50);
            this.Home.TabIndex = 14;
            this.Home.Text = "机械找零";
            this.Home.UseVisualStyleBackColor = true;
            this.Home.Click += new System.EventHandler(this.MachHome_Click);
            // 
            // NewForm1
            // 
            this.NewForm1.Location = new System.Drawing.Point(345, 213);
            this.NewForm1.Name = "NewForm1";
            this.NewForm1.Size = new System.Drawing.Size(70, 50);
            this.NewForm1.TabIndex = 15;
            this.NewForm1.Text = "IO状态";
            this.NewForm1.UseVisualStyleBackColor = true;
            this.NewForm1.Click += new System.EventHandler(this.NewForm1_Click);
            // 
            // performanceCounter1
            // 
            this.performanceCounter1.CategoryName = "Processor";
            this.performanceCounter1.CounterName = "% Processor Time";
            this.performanceCounter1.InstanceName = "_Total";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.Location = new System.Drawing.Point(12, 393);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(379, 21);
            this.textBox2.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 323);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "机械坐标";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 378);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 18;
            this.label2.Text = "工件坐标";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3.Location = new System.Drawing.Point(490, 190);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(337, 21);
            this.textBox3.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(420, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "工件坐标";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(490, 32);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox4.Size = new System.Drawing.Size(337, 152);
            this.textBox4.TabIndex = 21;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(490, 215);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox5.Size = new System.Drawing.Size(337, 137);
            this.textBox5.TabIndex = 22;
            // 
            // Send
            // 
            this.Send.Location = new System.Drawing.Point(490, 358);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(75, 23);
            this.Send.TabIndex = 23;
            this.Send.Text = "发送";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // ClearCode
            // 
            this.ClearCode.Location = new System.Drawing.Point(677, 358);
            this.ClearCode.Name = "ClearCode";
            this.ClearCode.Size = new System.Drawing.Size(75, 23);
            this.ClearCode.TabIndex = 24;
            this.ClearCode.Text = "清除";
            this.ClearCode.UseVisualStyleBackColor = true;
            this.ClearCode.Click += new System.EventHandler(this.ClearCode_Click);
            // 
            // textBox_Xaxis
            // 
            this.textBox_Xaxis.Location = new System.Drawing.Point(35, 284);
            this.textBox_Xaxis.Name = "textBox_Xaxis";
            this.textBox_Xaxis.Size = new System.Drawing.Size(47, 21);
            this.textBox_Xaxis.TabIndex = 25;
            this.textBox_Xaxis.Text = "100";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 287);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 26;
            this.label4.Text = "X:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(88, 287);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 28;
            this.label5.Text = "Y:";
            // 
            // textBox_Yaxis
            // 
            this.textBox_Yaxis.Location = new System.Drawing.Point(105, 284);
            this.textBox_Yaxis.Name = "textBox_Yaxis";
            this.textBox_Yaxis.Size = new System.Drawing.Size(47, 21);
            this.textBox_Yaxis.TabIndex = 27;
            this.textBox_Yaxis.Text = "100";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(162, 287);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 30;
            this.label6.Text = "Z:";
            // 
            // textBox_Zaxis
            // 
            this.textBox_Zaxis.Location = new System.Drawing.Point(179, 284);
            this.textBox_Zaxis.Name = "textBox_Zaxis";
            this.textBox_Zaxis.Size = new System.Drawing.Size(47, 21);
            this.textBox_Zaxis.TabIndex = 29;
            this.textBox_Zaxis.Text = "-32";
            // 
            // setWorkpiece
            // 
            this.setWorkpiece.Location = new System.Drawing.Point(232, 268);
            this.setWorkpiece.Name = "setWorkpiece";
            this.setWorkpiece.Size = new System.Drawing.Size(57, 50);
            this.setWorkpiece.TabIndex = 31;
            this.setWorkpiece.Text = "设定工件坐标";
            this.setWorkpiece.UseVisualStyleBackColor = true;
            this.setWorkpiece.Click += new System.EventHandler(this.setWorkpiece_Click);
            // 
            // setCurrent
            // 
            this.setCurrent.Location = new System.Drawing.Point(298, 268);
            this.setCurrent.Name = "setCurrent";
            this.setCurrent.Size = new System.Drawing.Size(52, 50);
            this.setCurrent.TabIndex = 32;
            this.setCurrent.Text = "设定为当前";
            this.setCurrent.UseVisualStyleBackColor = true;
            this.setCurrent.Click += new System.EventHandler(this.setCurrent_Click);
            // 
            // textBox_Xspeed
            // 
            this.textBox_Xspeed.Location = new System.Drawing.Point(105, 129);
            this.textBox_Xspeed.Name = "textBox_Xspeed";
            this.textBox_Xspeed.Size = new System.Drawing.Size(70, 21);
            this.textBox_Xspeed.TabIndex = 33;
            this.textBox_Xspeed.Text = "15.0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 34;
            this.label7.Text = "X/Y:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(223, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 36;
            this.label8.Text = "Z:";
            // 
            // textBox_Zspeed
            // 
            this.textBox_Zspeed.Location = new System.Drawing.Point(280, 129);
            this.textBox_Zspeed.Name = "textBox_Zspeed";
            this.textBox_Zspeed.Size = new System.Drawing.Size(70, 21);
            this.textBox_Zspeed.TabIndex = 35;
            this.textBox_Zspeed.Text = "5.0";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(422, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 50);
            this.button1.TabIndex = 37;
            this.button1.Text = "出丝";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(422, 133);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(62, 50);
            this.button2.TabIndex = 38;
            this.button2.Text = "关丝";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(421, 189);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(62, 50);
            this.button3.TabIndex = 39;
            this.button3.Text = "运行";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(421, 245);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(62, 50);
            this.button4.TabIndex = 40;
            this.button4.Text = "连续插补";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(421, 301);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(62, 50);
            this.button5.TabIndex = 41;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(421, 357);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(62, 50);
            this.button6.TabIndex = 42;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // status
            // 
            this.status.BackColor = System.Drawing.SystemColors.Control;
            this.status.Location = new System.Drawing.Point(558, 399);
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Size = new System.Drawing.Size(194, 21);
            this.status.TabIndex = 43;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(499, 402);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 44;
            this.label9.Text = "状态栏：";
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.SystemColors.Control;
            this.textBox6.Location = new System.Drawing.Point(196, 431);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(506, 21);
            this.textBox6.TabIndex = 45;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(137, 434);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 46;
            this.label10.Text = "插补状态";
            // 
            // Pause
            // 
            this.Pause.Location = new System.Drawing.Point(582, 358);
            this.Pause.Name = "Pause";
            this.Pause.Size = new System.Drawing.Size(75, 23);
            this.Pause.TabIndex = 47;
            this.Pause.Text = "暂停";
            this.Pause.UseVisualStyleBackColor = true;
            this.Pause.Click += new System.EventHandler(this.Pause_Click);
            // 
            // U_axis_plus
            // 
            this.U_axis_plus.Location = new System.Drawing.Point(215, 156);
            this.U_axis_plus.Name = "U_axis_plus";
            this.U_axis_plus.Size = new System.Drawing.Size(59, 50);
            this.U_axis_plus.TabIndex = 9;
            this.U_axis_plus.Text = "U+";
            this.U_axis_plus.UseVisualStyleBackColor = true;
            this.U_axis_plus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.U_axis_plus_MouseDown);
            this.U_axis_plus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.U_axis_plus_MouseUp);
            // 
            // U_axis_sub
            // 
            this.U_axis_sub.Location = new System.Drawing.Point(215, 212);
            this.U_axis_sub.Name = "U_axis_sub";
            this.U_axis_sub.Size = new System.Drawing.Size(59, 50);
            this.U_axis_sub.TabIndex = 9;
            this.U_axis_sub.Text = "U-";
            this.U_axis_sub.UseVisualStyleBackColor = true;
            this.U_axis_sub.MouseDown += new System.Windows.Forms.MouseEventHandler(this.U_axis_sub_MouseDown);
            this.U_axis_sub.MouseUp += new System.Windows.Forms.MouseEventHandler(this.U_axis_plus_MouseUp);
            // 
            // V_axis_plus
            // 
            this.V_axis_plus.Location = new System.Drawing.Point(280, 157);
            this.V_axis_plus.Name = "V_axis_plus";
            this.V_axis_plus.Size = new System.Drawing.Size(59, 50);
            this.V_axis_plus.TabIndex = 48;
            this.V_axis_plus.Text = "V+";
            this.V_axis_plus.UseVisualStyleBackColor = true;
            this.V_axis_plus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.V_axis_plus_MouseDown);
            this.V_axis_plus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.V_axis_plus_MouseUp);
            // 
            // V_axis_sub
            // 
            this.V_axis_sub.Location = new System.Drawing.Point(280, 213);
            this.V_axis_sub.Name = "V_axis_sub";
            this.V_axis_sub.Size = new System.Drawing.Size(59, 50);
            this.V_axis_sub.TabIndex = 49;
            this.V_axis_sub.Text = "V-";
            this.V_axis_sub.UseVisualStyleBackColor = true;
            this.V_axis_sub.MouseDown += new System.Windows.Forms.MouseEventHandler(this.V_axis_sub_MouseDown);
            this.V_axis_sub.MouseUp += new System.Windows.Forms.MouseEventHandler(this.V_axis_sub_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 464);
            this.Controls.Add(this.V_axis_sub);
            this.Controls.Add(this.V_axis_plus);
            this.Controls.Add(this.Pause);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.status);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_Zspeed);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_Xspeed);
            this.Controls.Add(this.setCurrent);
            this.Controls.Add(this.setWorkpiece);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_Zaxis);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_Yaxis);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_Xaxis);
            this.Controls.Add(this.ClearCode);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.NewForm1);
            this.Controls.Add(this.Home);
            this.Controls.Add(this.softHome);
            this.Controls.Add(this.Z_axis_sub);
            this.Controls.Add(this.Y_axis_sub);
            this.Controls.Add(this.X_axis_sub);
            this.Controls.Add(this.U_axis_sub);
            this.Controls.Add(this.U_axis_plus);
            this.Controls.Add(this.Z_axis_plus);
            this.Controls.Add(this.Y_axis_plus);
            this.Controls.Add(this.X_axis_plus);
            this.Controls.Add(this.textBox_IP);
            this.Controls.Add(this.disconnect);
            this.Controls.Add(this.connect);
            this.Controls.Add(this.SB_Clear);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.SB_Stop);
            this.Controls.Add(this.SB_Star);
            this.Name = "Form1";
            this.Text = "SMC600运动调试软件";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.performanceCounter1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button SB_Star;
        public System.Windows.Forms.Button SB_Stop;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button SB_Clear;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.Button disconnect;
        private System.Windows.Forms.TextBox textBox_IP;
        public System.Windows.Forms.Button X_axis_plus;
        public System.Windows.Forms.Button Y_axis_plus;
        public System.Windows.Forms.Button Z_axis_plus;
        public System.Windows.Forms.Button X_axis_sub;
        public System.Windows.Forms.Button Y_axis_sub;
        public System.Windows.Forms.Button Z_axis_sub;
        public System.Windows.Forms.Button softHome;
        private System.Windows.Forms.Button Home;
        private System.Windows.Forms.Button NewForm1;
        private System.Diagnostics.PerformanceCounter performanceCounter1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.Button ClearCode;
        private System.Windows.Forms.TextBox textBox_Xaxis;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_Yaxis;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_Zaxis;
        private System.Windows.Forms.Button setWorkpiece;
        private System.Windows.Forms.Button setCurrent;
        private System.Windows.Forms.TextBox textBox_Xspeed;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_Zspeed;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox status;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button Pause;
        public System.Windows.Forms.Button U_axis_plus;
        public System.Windows.Forms.Button U_axis_sub;
        public System.Windows.Forms.Button V_axis_plus;
        public System.Windows.Forms.Button V_axis_sub;
    }
}

