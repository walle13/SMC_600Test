namespace SMC_600Test
{
    partial class CB_Start
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
            this.button1 = new System.Windows.Forms.Button();
            this.SB_Stop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(175, 121);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 74);
            this.button1.TabIndex = 0;
            this.button1.Text = "启动";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SB_Start_Click);
            // 
            // SB_Stop
            // 
            this.SB_Stop.Location = new System.Drawing.Point(413, 121);
            this.SB_Stop.Name = "SB_Stop";
            this.SB_Stop.Size = new System.Drawing.Size(128, 74);
            this.SB_Stop.TabIndex = 1;
            this.SB_Stop.Text = "停止";
            this.SB_Stop.UseVisualStyleBackColor = true;
            this.SB_Stop.Click += new System.EventHandler(this.SB_Stop_Click);
            // 
            // CB_Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SB_Stop);
            this.Controls.Add(this.button1);
            this.Name = "CB_Start";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.CB_Start_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button SB_Stop;
    }
}

