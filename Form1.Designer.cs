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
            this.SuspendLayout();
            // 
            // SB_Star
            // 
            this.SB_Star.Location = new System.Drawing.Point(12, 73);
            this.SB_Star.Name = "SB_Star";
            this.SB_Star.Size = new System.Drawing.Size(94, 52);
            this.SB_Star.TabIndex = 0;
            this.SB_Star.Text = "启动";
            this.SB_Star.UseVisualStyleBackColor = true;
            this.SB_Star.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SB_Star_MouseDown);
            this.SB_Star.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SB_Star_MouseUp);
            // 
            // SB_Stop
            // 
            this.SB_Stop.Location = new System.Drawing.Point(121, 73);
            this.SB_Stop.Name = "SB_Stop";
            this.SB_Stop.Size = new System.Drawing.Size(89, 52);
            this.SB_Stop.TabIndex = 1;
            this.SB_Stop.Text = "停止";
            this.SB_Stop.UseVisualStyleBackColor = true;
            this.SB_Stop.Click += new System.EventHandler(this.SB_Stop_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.Location = new System.Drawing.Point(12, 331);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(488, 21);
            this.textBox1.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SB_Clear
            // 
            this.SB_Clear.Location = new System.Drawing.Point(236, 73);
            this.SB_Clear.Name = "SB_Clear";
            this.SB_Clear.Size = new System.Drawing.Size(83, 52);
            this.SB_Clear.TabIndex = 3;
            this.SB_Clear.Text = "清零";
            this.SB_Clear.UseVisualStyleBackColor = true;
            this.SB_Clear.Click += new System.EventHandler(this.SB_Clear_Click);
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(12, 12);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(86, 38);
            this.connect.TabIndex = 4;
            this.connect.Text = "连接";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // disconnect
            // 
            this.disconnect.Location = new System.Drawing.Point(341, 12);
            this.disconnect.Name = "disconnect";
            this.disconnect.Size = new System.Drawing.Size(86, 38);
            this.disconnect.TabIndex = 5;
            this.disconnect.Text = "断开";
            this.disconnect.UseVisualStyleBackColor = true;
            this.disconnect.Click += new System.EventHandler(this.disconnect_Click);
            // 
            // textBox_IP
            // 
            this.textBox_IP.Location = new System.Drawing.Point(147, 22);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(172, 21);
            this.textBox_IP.TabIndex = 6;
            this.textBox_IP.Text = "192.168.1.77";
            this.textBox_IP.TextChanged += new System.EventHandler(this.textBox_IP_TextChanged);
            // 
            // X_axis_plus
            // 
            this.X_axis_plus.Location = new System.Drawing.Point(51, 164);
            this.X_axis_plus.Name = "X_axis_plus";
            this.X_axis_plus.Size = new System.Drawing.Size(70, 50);
            this.X_axis_plus.TabIndex = 7;
            this.X_axis_plus.Text = "X+";
            this.X_axis_plus.UseVisualStyleBackColor = true;
            this.X_axis_plus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.X_axis_plus_MouseDown);
            this.X_axis_plus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.X_axis_plus_MouseUp);
            // 
            // Y_axis_plus
            // 
            this.Y_axis_plus.Location = new System.Drawing.Point(144, 164);
            this.Y_axis_plus.Name = "Y_axis_plus";
            this.Y_axis_plus.Size = new System.Drawing.Size(70, 50);
            this.Y_axis_plus.TabIndex = 8;
            this.Y_axis_plus.Text = "Y+";
            this.Y_axis_plus.UseVisualStyleBackColor = true;
            this.Y_axis_plus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Y_axis_plus_MouseDown);
            this.Y_axis_plus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Y_axis_plus_MouseUp);
            // 
            // Z_axis_plus
            // 
            this.Z_axis_plus.Location = new System.Drawing.Point(235, 164);
            this.Z_axis_plus.Name = "Z_axis_plus";
            this.Z_axis_plus.Size = new System.Drawing.Size(70, 50);
            this.Z_axis_plus.TabIndex = 9;
            this.Z_axis_plus.Text = "Z+";
            this.Z_axis_plus.UseVisualStyleBackColor = true;
            this.Z_axis_plus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Z_axis_plus_MouseDown);
            this.Z_axis_plus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Z_axis_plus_MouseUp);
            // 
            // X_axis_sub
            // 
            this.X_axis_sub.Location = new System.Drawing.Point(51, 220);
            this.X_axis_sub.Name = "X_axis_sub";
            this.X_axis_sub.Size = new System.Drawing.Size(70, 50);
            this.X_axis_sub.TabIndex = 10;
            this.X_axis_sub.Text = "X-";
            this.X_axis_sub.UseVisualStyleBackColor = true;
            this.X_axis_sub.MouseDown += new System.Windows.Forms.MouseEventHandler(this.X_axis_sub_MouseDown);
            this.X_axis_sub.MouseUp += new System.Windows.Forms.MouseEventHandler(this.X_axis_sub_MouseUp);
            // 
            // Y_axis_sub
            // 
            this.Y_axis_sub.Location = new System.Drawing.Point(144, 220);
            this.Y_axis_sub.Name = "Y_axis_sub";
            this.Y_axis_sub.Size = new System.Drawing.Size(70, 50);
            this.Y_axis_sub.TabIndex = 11;
            this.Y_axis_sub.Text = "Y-";
            this.Y_axis_sub.UseVisualStyleBackColor = true;
            this.Y_axis_sub.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Y_axis_sub_MouseDown);
            this.Y_axis_sub.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Y_axis_sub_MouseUp);
            // 
            // Z_axis_sub
            // 
            this.Z_axis_sub.Location = new System.Drawing.Point(235, 220);
            this.Z_axis_sub.Name = "Z_axis_sub";
            this.Z_axis_sub.Size = new System.Drawing.Size(70, 50);
            this.Z_axis_sub.TabIndex = 12;
            this.Z_axis_sub.Text = "Z-";
            this.Z_axis_sub.UseVisualStyleBackColor = true;
            this.Z_axis_sub.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Z_axis_sub_MouseDown);
            this.Z_axis_sub.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Z_axis_sub_MouseUp);
            // 
            // softHome
            // 
            this.softHome.Location = new System.Drawing.Point(338, 174);
            this.softHome.Name = "softHome";
            this.softHome.Size = new System.Drawing.Size(74, 86);
            this.softHome.TabIndex = 13;
            this.softHome.Text = "HOME";
            this.softHome.UseVisualStyleBackColor = true;
            this.softHome.Click += new System.EventHandler(this.softHome_Click);
            // 
            // Home
            // 
            this.Home.Location = new System.Drawing.Point(341, 73);
            this.Home.Name = "Home";
            this.Home.Size = new System.Drawing.Size(86, 52);
            this.Home.TabIndex = 14;
            this.Home.Text = "机械找零";
            this.Home.UseVisualStyleBackColor = true;
            this.Home.Click += new System.EventHandler(this.MachHome_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 364);
            this.Controls.Add(this.Home);
            this.Controls.Add(this.softHome);
            this.Controls.Add(this.Z_axis_sub);
            this.Controls.Add(this.Y_axis_sub);
            this.Controls.Add(this.X_axis_sub);
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
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
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
    }
}

