using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Leadshine.SMC.IDE.Motion;


namespace SMC_600Test
{
    public partial class Form1 : Form
    {
        private ushort _ConnectNo = 0;
        ushort CardNo = 0;          //卡号
        ushort x_axis = 0;            //运动轴号x
        ushort y_axis = 1;            //运动轴号y
        ushort z_axis = 2;            //运动轴号z
        double start_speed = 0;     //启动速度
        double speed = 100;        //最大运行速度
        double stop_speed = 0;      //停止速度
        double tacc = 0.1;          //加速时间
        double tdec = 0.1;      //减速时间
        double s_pare = 0.05;   //s形平滑系数
        double max_dist = 600;    //运动距离， 脉冲？
        double min_dist = 0;    //运动距离，
        ushort mode = 0;     //停止模式，0；减速停止，1；紧急停止
        double workpos_X = 0.0;
        double workpos_Y = 0.0;
        double workpos_Z = 0.0;
        double workpos_U = 0.0;
        double workpos_V = 0.0;
        double workpos_W = 0.0;

        public Form1()
        {
            InitializeComponent();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            //short res = LTSMC.smc_board_init(_ConnectNo, 2, "192.168.1.77", 115200);//获取卡数量
            //if (res != 0)
            //{
            //    MessageBox.Show("连接错误!", "出错");

            //    return;
            //}
            //LTSMC.smc_set_pulse_outmode(_ConnectNo, 0, 0);//设置脉冲模式
            //LTSMC.smc_set_pulse_outmode(_ConnectNo, 1, 0);//设置脉冲模式
            //LTSMC.smc_set_pulse_outmode(_ConnectNo, 2, 0);//设置脉冲模式
            //LTSMC.smc_set_pulse_outmode(_ConnectNo, 3, 0);//设置脉冲模式
            //LTSMC.smc_set_pulse_outmode(_ConnectNo, 4, 0);//设置脉冲模式
            //LTSMC.smc_set_pulse_outmode(_ConnectNo, 5, 0);//设置脉冲模式
            //
            //timer1.Start();
        }

        private void connect_Click(object sender, EventArgs e)
        {
            ushort CardNo = 0;
            string connect_IP = textBox_IP.Text;
            Console.WriteLine(connect_IP);
            short res = LTSMC.smc_board_init(CardNo, 2, connect_IP, 0);
            if (res != 0)
            {
                MessageBox.Show(string.Format("连接控制器失败，错误码：【0】", res), "错误");
            }
            else
                timer1.Start();
            LTSMC.smc_set_pulse_outmode(_ConnectNo, 0, 0);//设置脉冲模式
            LTSMC.smc_set_pulse_outmode(_ConnectNo, 1, 0);//设置脉冲模式
            LTSMC.smc_set_pulse_outmode(_ConnectNo, 2, 0);//设置脉冲模式
            LTSMC.smc_set_pulse_outmode(_ConnectNo, 3, 0);//设置脉冲模式
            LTSMC.smc_set_pulse_outmode(_ConnectNo, 4, 0);//设置脉冲模式
            LTSMC.smc_set_pulse_outmode(_ConnectNo, 5, 0);//设置脉冲模式

            Console.WriteLine("abc");

        }

        private void textBox_IP_TextChanged(object sender, EventArgs e)
        {

        }

        private void disconnect_Click(object sender, EventArgs e)
        {
            ushort CardNo = 0;
            short res = LTSMC.smc_board_close(CardNo);
            timer1.Stop();
            textBox1.Text = ("");
        }

        //private void SB_Start_Click(object sender, EventArgs e)
        //{
        //    ushort CardNo = 0;          //卡号
        //    ushort axis = 0;            //运动轴号u
        //    double start_speed = 0;     //启动速度
        //    double speed = 100;        //最大运行速度
        //    double stop_speed = 0;      //停止速度
        //    double tacc = 0.1;          //加速时间
        //    double tdec = 0.1;      //减速时间
        //    double s_pare = 0.05;   //s形平滑系数
        //    double dist = 10000;    //运动距离
        //    LTSMC.smc_set_profile_unit(CardNo, axis, start_speed, speed, tacc, tdec, stop_speed);//设置速度参数
        //    LTSMC.smc_set_s_profile(CardNo, axis, 0, s_pare);   //设置S平滑系数
        //    LTSMC.smc_pmove_unit(CardNo, axis, dist, 0);    //启动定长运动
        //    Console.WriteLine("123"); //
        //}


        private void SB_Stop_Click(object sender, EventArgs e)
        {
            ushort CardNo = 0;          //卡号
            ushort axis = 0;            //运动轴号u
            ushort mode = 0;     //停止模式，0；减速停止，1；紧急停止
            LTSMC.smc_stop(CardNo, axis, mode);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder sbWork = new StringBuilder();
            //
            double pos = 0.0;
            
            LTSMC.smc_get_position_unit(_ConnectNo, 0, ref pos);
            sb.AppendFormat("X={0},", pos);
            sbWork.AppendFormat("X={0},", pos + workpos_X);
            LTSMC.smc_get_position_unit(_ConnectNo, 1, ref pos);
            sb.AppendFormat("Y={0},", pos);
            sbWork.AppendFormat("X={0},", pos + workpos_Y);
            LTSMC.smc_get_position_unit(_ConnectNo, 2, ref pos);
            sb.AppendFormat("Z={0},", pos);
            sbWork.AppendFormat("X={0},", pos + workpos_Z);
            LTSMC.smc_get_position_unit(_ConnectNo, 3, ref pos);
            sb.AppendFormat("U={0},", pos);
            sbWork.AppendFormat("X={0},", pos + workpos_U);
            LTSMC.smc_get_position_unit(_ConnectNo, 4, ref pos);
            sb.AppendFormat("V={0},", pos);
            sbWork.AppendFormat("X={0},", pos + workpos_V);
            LTSMC.smc_get_position_unit(_ConnectNo, 5, ref pos);
            sb.AppendFormat("W={0},", pos);
            sbWork.AppendFormat("X={0},", pos + workpos_W);
            double speed = 0;
            LTSMC.smc_read_current_speed_unit(_ConnectNo, 0, ref speed);
            sb.AppendFormat("Speed={0},", speed);
            //
            textBox1.Text = sb.ToString();
            textBox2.Text = sbWork.ToString();
            // Console.WriteLine("456");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            LTSMC.smc_board_close(_ConnectNo);
            //Application.Exit();
            System.Environment.Exit(0);  //如何关闭全部form
            //foreach (Form1 frm in this.MdiChildren)
            //{
            //    frm.Close();
            //}
        }

     
        private void SB_Clear_Click(object sender, EventArgs e)
        {
            LTSMC.smc_set_position_unit(_ConnectNo, 0, 0);//位置清零
            LTSMC.smc_set_position_unit(_ConnectNo, 1, 0);//位置清零
            LTSMC.smc_set_position_unit(_ConnectNo, 2, 0);//位置清零
            LTSMC.smc_set_position_unit(_ConnectNo, 3, 0);//位置清零
            LTSMC.smc_set_position_unit(_ConnectNo, 4, 0);//位置清零
            LTSMC.smc_set_position_unit(_ConnectNo, 5, 0);//位置清零
        }

        private void softHome_Click(object sender, EventArgs e)
        {
            LTSMC.smc_set_profile_unit(CardNo, x_axis, start_speed, speed, tacc, tdec, stop_speed);//设置速度参数
            LTSMC.smc_set_s_profile(CardNo, x_axis, 0, s_pare);   //设置S平滑系数
            LTSMC.smc_pmove_unit(CardNo, z_axis, 0, 1);    //启动定长运动  绝对值方式走到“0”位置
            LTSMC.smc_pmove_unit(CardNo, y_axis, 0, 1);    //启动定长运动
            LTSMC.smc_pmove_unit(CardNo, x_axis, 0, 1);    //启动定长运动
            Console.WriteLine("123"); //
        }

        private void SB_Star_MouseDown(object sender, MouseEventArgs e)
        {
            LTSMC.smc_set_profile_unit(CardNo, x_axis, start_speed, speed, tacc, tdec, stop_speed);//设置速度参数
            LTSMC.smc_set_s_profile(CardNo, x_axis, 0, s_pare);   //设置S平滑系数
            LTSMC.smc_pmove_unit(CardNo, x_axis, max_dist, 0);    //启动定长运动
            Console.WriteLine("123"); //
        }

        private void SB_Star_MouseUp(object sender, MouseEventArgs e)
        {
            ushort CardNo = 0;          //卡号
            ushort axis = 0;            //运动轴号u
            ushort mode = 0;     //停止模式，0；减速停止，1；紧急停止
            LTSMC.smc_stop(CardNo, x_axis, mode);  //轴停止运动 （卡号， 运动轴号 ， 停止模式：0；减速停止，1；紧急停止）
        }

        private void X_axis_plus_MouseDown(object sender, MouseEventArgs e)  // X+
        {
            
            LTSMC.smc_set_profile_unit(CardNo, x_axis, start_speed, speed, tacc, tdec, stop_speed);//设置速度参数
            LTSMC.smc_set_s_profile(CardNo, x_axis, 0, s_pare);   //设置S平滑系数
            LTSMC.smc_pmove_unit(CardNo, x_axis, max_dist, 1);    //启动定长运动
            Console.WriteLine("123"); //
        }

        private void X_axis_plus_MouseUp(object sender, MouseEventArgs e)
        {
            LTSMC.smc_stop(CardNo, x_axis, mode);  //轴停止运动 （卡号， 运动轴号 ， 停止模式：0；减速停止，1；紧急停止）
        }

        private void X_axis_sub_MouseDown(object sender, MouseEventArgs e)  // X-
        {
            
            LTSMC.smc_set_profile_unit(CardNo, x_axis, start_speed, speed, tacc, tdec, stop_speed);//设置速度参数
            LTSMC.smc_set_s_profile(CardNo, x_axis, 0, s_pare);   //设置S平滑系数
            LTSMC.smc_pmove_unit(CardNo, x_axis, min_dist, 1);    //启动定长运动
            Console.WriteLine("123"); //
        }

        private void X_axis_sub_MouseUp(object sender, MouseEventArgs e)
        {
            LTSMC.smc_stop(CardNo, x_axis, mode);  //轴停止运动 （卡号， 运动轴号 ， 停止模式：0；减速停止，1；紧急停止）
        }

        private void Y_axis_plus_MouseDown(object sender, MouseEventArgs e)     // Y+
        {
            
            LTSMC.smc_set_profile_unit(CardNo, y_axis, start_speed, speed, tacc, tdec, stop_speed);//设置速度参数
            LTSMC.smc_set_s_profile(CardNo, y_axis, 0, s_pare);   //设置S平滑系数
            LTSMC.smc_pmove_unit(CardNo, y_axis, max_dist, 1);    //启动定长运动
            Console.WriteLine("123"); //

        }

        private void Y_axis_plus_MouseUp(object sender, MouseEventArgs e)
        {
            
            LTSMC.smc_stop(CardNo, y_axis, mode);  //轴停止运动 （卡号， 运动轴号 ， 停止模式：0；减速停止，1；紧急停止）
        }

        private void Y_axis_sub_MouseDown(object sender, MouseEventArgs e)      // Y-
        {
            
            LTSMC.smc_set_profile_unit(CardNo, y_axis, start_speed, speed, tacc, tdec, stop_speed);//设置速度参数
            LTSMC.smc_set_s_profile(CardNo, y_axis, 0, s_pare);   //设置S平滑系数
            LTSMC.smc_pmove_unit(CardNo, y_axis, min_dist, 1);    //启动定长运动
            Console.WriteLine("123"); //
        }

        private void Y_axis_sub_MouseUp(object sender, MouseEventArgs e)
        {
            
            LTSMC.smc_stop(CardNo, y_axis, mode);  //轴停止运动 （卡号， 运动轴号 ， 停止模式：0；减速停止，1；紧急停止）
        }

        private void Z_axis_plus_MouseDown(object sender, MouseEventArgs e)     //Z+
        {
            
            LTSMC.smc_set_profile_unit(CardNo, z_axis, start_speed, speed, tacc, tdec, stop_speed);//设置速度参数
            LTSMC.smc_set_s_profile(CardNo, z_axis, 0, s_pare);   //设置S平滑系数
            LTSMC.smc_pmove_unit(CardNo, z_axis, max_dist, 1);    //启动定长运动
            Console.WriteLine("123"); //
        }

        private void Z_axis_plus_MouseUp(object sender, MouseEventArgs e)
        {
            
            LTSMC.smc_stop(CardNo, z_axis, mode);  //轴停止运动 （卡号， 运动轴号 ， 停止模式：0；减速停止，1；紧急停止）
        }

        private void Z_axis_sub_MouseDown(object sender, MouseEventArgs e)      //Z-
        {
            
            LTSMC.smc_set_profile_unit(CardNo, z_axis, start_speed, speed, tacc, tdec, stop_speed);//设置速度参数
            LTSMC.smc_set_s_profile(CardNo, z_axis, 0, s_pare);   //设置S平滑系数
            LTSMC.smc_pmove_unit(CardNo, z_axis, min_dist, 1);    //启动定长运动
            Console.WriteLine("123"); //
        }

        private void Z_axis_sub_MouseUp(object sender, MouseEventArgs e)
        {
            
            LTSMC.smc_stop(CardNo, z_axis, mode);  //轴停止运动 （卡号， 运动轴号 ， 停止模式：0；减速停止，1；紧急停止）
        }

        private void MachHome_Click(object sender, EventArgs e)
        {


            double start = 1000.0;  //停止速度
     
            

            short ret = 0; //错误返回
            ushort axis = y_axis; //运动轴号，范围：0~最大轴数-1y
            double Start_Vel = 1000;//回零起始速度，范围：0~2MHz频率
            double Max_Vel = 10000;//回零运行速度，范围：0~2MHz频率
            double Tacc = 0.1; //加速时间，单位s，范围：0.001~10s
            double Tdec = 0.2;  //减速时间,单位s，范围：0.001~10s
            ushort org_logic = 0; //设置原点有效电平：0-低电平，1-高电平
            double filter = 0; //滤波时间为0，保留参数，无意义
            ushort home_dir = 1; //设置回原点方向：0-负向、1-正向
            ushort mode = 1; //设置回原点模式为一次回原点加反找
            ushort Source = 0; //设置计数源为脉冲计数 0：指令位置计数器，1：编码器计数器
            ushort enable = 2; //设置完成回原点后计数使能0：禁止。1:先清0，然后运动到指定位置（相对位置）。2:先运动到指定位置（相对位置），再清0
            double position = 100; //设置完成回原点后计数值

            LTSMC.smc_set_pulse_outmode(_ConnectNo, axis, 0);//设置脉冲模式
            LTSMC.smc_set_equiv(_ConnectNo, axis, 1);//设置脉冲当量
            LTSMC.smc_set_alm_mode(_ConnectNo, axis, 0, 0, 0);//设置报警使能，关闭报警
            LTSMC.smc_write_sevon_pin(_ConnectNo, axis, 0);//打开伺服使能
            LTSMC.smc_set_home_pin_logic(_ConnectNo, axis, 0, 0);//设置原点低电平有效
            LTSMC.smc_set_home_profile_unit(_ConnectNo, axis, Start_Vel, Max_Vel, Tacc, Tdec);//设置 轴号、起始速度、运行速度、加速时间、减速时间
            LTSMC.smc_set_homemode(_ConnectNo, axis, home_dir, 1, mode, Source);//设置回零模式 原点方向、原点速度模式、原点模式、返回回零计数源
            LTSMC.smc_set_home_position_unit(_ConnectNo, axis, enable, position);//设置偏移模式
            LTSMC.smc_home_move(_ConnectNo, axis);//启动回零

        }

        private void NewForm1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            //Application.Run(new Form2());
        }

        private void Send_Click(object sender, EventArgs e)
        {
            string username = textBox5.Text;
            Console.WriteLine(username);
            textBox4.Text = textBox4.Text + textBox5.Text + "\r\n";  //+Environment.NewLine 默认换行符
            this.textBox4.Focus();//获取焦点
            this.textBox4.Select(this.textBox4.TextLength, 0);//光标定位到文本最后
            this.textBox4.ScrollToCaret();//滚动到光标处
            textBox5.Text = "";
        }

        private void ClearCode_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void setWorkpiece_Click(object sender, EventArgs e)
        {
            workpos_X = double.Parse(textBox_Xaxis.Text);
            workpos_Y = double.Parse(textBox_Yaxis.Text);
            workpos_Z = double.Parse(textBox_Zaxis.Text);

        }

        private void setCurrent_Click(object sender, EventArgs e)
        {

        }
    }

}
