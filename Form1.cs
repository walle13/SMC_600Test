using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Leadshine.SMC.IDE.Motion;


namespace SMC_600Test
{
    public partial class Form1 : Form
    {
        private ushort _ConnectNo = 0;
        ushort CardNo = 0;          //卡号
        ushort X_axis = 0;            //运动轴号x
        ushort Y_axis = 1;            //运动轴号y
        ushort Z_axis = 2;            //运动轴号z
        double start_speed =2;        //初始速度 
        double X_speed ;        //最大运行速度
        double Y_speed ;        //最大运行速度
        double Z_speed ;        //最大运行速度
        double stop_speed = 0;      //停止速度
        double tacc = 0.1;          //加速时间
        double tdec = 0.1;      //减速时间
        double s_pare = 0.05;   //s形平滑系数
        double max_Xdist = 200;    //运动距离， 脉冲？
        double min_Xdist = 0;    //运动距离，
        double max_Ydist = 200;    //运动距离， 脉冲？
        double min_Ydist = 0;    //运动距离，
        double max_Zdist = 0;    //运动距离， 脉冲？
        double min_Zdist = -40;    //运动距离，
        ushort mode = 0;     //停止模式，0；减速停止，1；紧急停止
        ushort lookaheadMode = 1;   // 插补模式：0 -非前瞻模式0 ; 1 -前瞻模式1 ;2 -非前瞻模式2
        double workpos_X = 100;
        double workpos_Y = 70;
        double workpos_Z = -32;
        double workpos_U = 0.0;
        double workpos_V = 0.0;
        double workpos_W = 0.0;


        /// <summary>
        /// /插补运动参数
        /// </summary>
        short ret; //返回错误码
        ushort Myposi_mode = 1; //0:相对模式，1：绝对模式
        ushort MyCrd = 0; //参与插补运动的坐标系
        ushort MyCrd_Work = 1; //参与插补的工件坐标系
        ushort[] AxisArray = new ushort[3]; //定义轴        
        double MyMin_Vel = 0; //起始速度0
        double MyMax_Vel = 15; //插补运动最大速度
        double MyTacc = 0.2; //插补运动加速时间
        double MyTdec = 0.1; //插补运动减速时间
        double MyStop_Vel = 0; //插补运动停止速度
        ushort MySmode = 0; //保留参数，固定值为0
        double MySpara = 0.05; //平滑时间为0.05s
        ushort MyaxisNum = 3; //插补运动轴数为3    ********坑爹啊，居然这里没有设置三轴
        double[] Dist = new double[3];
        double[] DistWork = new double[3] { 100, 70, -32 };  //修正工件坐标
        

        short MyCardNo = 0;//连接号
        ushort enable =1; //是否启用Blend功能，0不使用，1使用
        ushort dir =0; //圆弧方向，0：顺时针，1：逆时针
        int cic=0; //圆弧圈数
        double[] cen = new double[3];   //定义圆心坐标

        int LookaheadSegment =200; //定义插补段数:200段
        double PathError=1; //定义轨迹误差：1unit
        double LookaheadAcc=10000; //定义拐弯加速度:10000unit/s2
        ushort ArcLimit=1; //使能圆弧限速，0：不使用，1使能



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
            LTSMC.smc_set_homemode(_ConnectNo, X_axis, 1, 1, 1, 0);    //设置回零模式 轴号，原点方向 （0负、1正）、原点速度模式、原点模式（一次回原点加反找）、返回回零计数源
            LTSMC.smc_set_homemode(_ConnectNo, Y_axis, 1, 1, 1, 0);    //设置回零模式 原点方向、原点速度模式、原点模式、返回回零计数源
            LTSMC.smc_set_homemode(_ConnectNo, Z_axis, 0, 1, 1, 0);    //设置回零模式 原点方向、原点速度模式、原点模式、返回回零计数源
            LTSMC.smc_set_pulse_outmode(_ConnectNo, X_axis, 2);//设置脉冲模式; 0,PUL+ DIR+ ;2, PUL+ DIR- 高脉冲/低方向  
            LTSMC.smc_set_pulse_outmode(_ConnectNo, Y_axis, 2);//设置脉冲模式
            LTSMC.smc_set_pulse_outmode(_ConnectNo, Z_axis, 2);//设置脉冲模式

            LTSMC.smc_set_softlimit_unit(_ConnectNo, X_axis, 0, 0, 1, -80, 80);  //设置X轴软限位 2020.4.2 添加;研究软限位与插补的冲突
            LTSMC.smc_set_softlimit_unit(_ConnectNo, Y_axis, 0, 0, 1, -80, 80);  //设置Y轴软限位
            LTSMC.smc_set_softlimit_unit(_ConnectNo, Y_axis, 0, 0, 1, 0, 30);  //设置Z轴软限位

            ushort outmode_Z = new ushort();
            LTSMC.smc_get_pulse_outmode(_ConnectNo, Z_axis, ref outmode_Z);
            Console.WriteLine("Z_" + outmode_Z);

            Console.WriteLine("abc");
            LTSMC.smc_set_axis_io_map(CardNo, X_axis, 3, 6, 29, 0);
            LTSMC.smc_set_axis_io_map(CardNo, Y_axis, 3, 6, 29, 0);
         //   LTSMC.smc_set_axis_io_map(CardNo, Z_axis, 3, 6, 29, 0);
            LTSMC.smc_set_emg_mode(CardNo, X_axis, 1, 1);   //设置EMG使能，信号使能 1有效 ；0：低、1：高电平有效
            LTSMC.smc_set_emg_mode(CardNo, Y_axis, 1, 1);   //设置EMG使能，信号使能 1 ；0：低、1：高电平有效
           // LTSMC.smc_set_emg_mode(CardNo, Z_axis, 1, 1);   //设置EMG使能，信号使能 1 ；0：低、1：高电平有效
        }

        private void textBox_IP_TextChanged(object sender, EventArgs e)
        {

        }

        private void disconnect_Click(object sender, EventArgs e)
        {
            ushort CardNo = 0;
            LTSMC.smc_conti_stop_list(_ConnectNo, 0, 0);
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
            ushort mode = 0;     //停止模式，0；减速停止，1；紧急停止
            LTSMC.smc_stop(CardNo, X_axis, mode);   //X轴停止运动
            LTSMC.smc_stop(CardNo, Y_axis, mode);   //Y轴停止运动
            LTSMC.smc_stop(CardNo, Z_axis, mode);   //Z轴停止运动
            LTSMC.smc_conti_close_list(_ConnectNo, MyCrd);
            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder sbWork = new StringBuilder();
            //
            double pos = 0.0;
            
            LTSMC.smc_get_position_unit(_ConnectNo, 0, ref pos);
            sb.AppendFormat("X={0},", pos);
            sbWork.AppendFormat("X={0},", pos - workpos_X);
            LTSMC.smc_get_position_unit(_ConnectNo, 1, ref pos);
            sb.AppendFormat("Y={0},", pos);
            sbWork.AppendFormat("Y={0},", pos - workpos_Y);
            LTSMC.smc_get_position_unit(_ConnectNo, 2, ref pos);
            sb.AppendFormat("Z={0},", pos);
            sbWork.AppendFormat("Z={0},", pos - workpos_Z);
            LTSMC.smc_get_position_unit(_ConnectNo, 3, ref pos);
            sb.AppendFormat("U={0},", pos);
            sbWork.AppendFormat("U={0},", pos - workpos_U);
            LTSMC.smc_get_position_unit(_ConnectNo, 4, ref pos);
            sb.AppendFormat("V={0},", pos);
            sbWork.AppendFormat("V={0},", pos - workpos_V);
            LTSMC.smc_get_position_unit(_ConnectNo, 5, ref pos);
            sb.AppendFormat("W={0},", pos);
            sbWork.AppendFormat("W={0},", pos - workpos_W);
            double speed = 0;
            LTSMC.smc_read_current_speed_unit(_ConnectNo, 0, ref speed);
            sb.AppendFormat("Speed={0},", speed);
            //
            textBox1.Text = sb.ToString();  //textBox显示当前机械坐标
            textBox2.Text = sbWork.ToString();  //textBox显示当前工件坐标

            short runstate = LTSMC.smc_conti_get_run_state(_ConnectNo, MyCrd);  //读取插补运行状态 0-5
            short multicoor = LTSMC.smc_check_done_multicoor(_ConnectNo, MyCrd);    //检测连续插补运动状态    0-1
            int currentmark = LTSMC.smc_conti_read_current_mark(_ConnectNo, MyCrd); //连续插补当前插补段
            int remainspace = LTSMC.smc_conti_remain_space(_ConnectNo, MyCrd);  //剩余插补空间
            ushort refenable = 0;
            int refLookaheadSegments = 0;
            double refPathError = 0;
            double refLookaheadAcc = 0;
            LTSMC.smc_conti_get_lookahead_mode(_ConnectNo, MyCrd, ref refenable, ref refLookaheadSegments, ref refPathError, ref refLookaheadAcc);
            //Crd 坐标系号，取值范围：0~1
            //lookaheadMode 插补模式：0 - 非前瞻模式0，1 - 前瞻模式1，2 - 非前瞻模式2
            //LookaheadSegment 前瞻段数，即每次运行时内部计算段数
            //PathError 轨迹误差，单位：unit
            //LookaheadAcc 拐弯加速度，单位unit / s^2
            //第四步、打开连续插补
            string strrunstate = runstate.ToString()+" / "+ multicoor.ToString()+"||"+ 
                currentmark.ToString()+" / "+remainspace.ToString()+
                " |***| "+ refenable + " / "+ refLookaheadSegments + " / "+ refPathError + " / " + refLookaheadAcc;  //读取插补运行状态-*-检测插补运行状态-*-读取当前插补段号-*-剩余插补空间

            textBox6.Text = strrunstate;    //显示插补状态

            // Console.WriteLine("456");
            short EMGstatus = LTSMC.smc_read_inbit(_ConnectNo, 29);     //读取input IO 29口状态，判断EMG急停状态。
            // status.Text = EMGstatus;
            if (EMGstatus == 1)
            {
                status.Text = ("EMG 急停触发");
            }
            else
            {
                status.Text = ("");
            }

           // Console.WriteLine("EMGstatus " + EMGstatus);

            X_speed = double.Parse(textBox_Xspeed.Text);
            Y_speed = double.Parse(textBox_Xspeed.Text);
            Z_speed = double.Parse(textBox_Zspeed.Text);

            /// <summary>
            /// /读取轴脉冲状态
            //ushort outmode_Y = new ushort();
            //ushort outmode_Z = new ushort();
            //LTSMC.smc_get_pulse_outmode(_ConnectNo, Z_axis, ref outmode_X);
            //LTSMC.smc_get_pulse_outmode(_ConnectNo, Z_axis, ref outmode_Y);
            //LTSMC.smc_get_pulse_outmode(_ConnectNo, Z_axis, ref outmode_Z);
            //Console.WriteLine("x_" + outmode_Z + "; y_" + outmode_Y + "; z_" + outmode_Z);

            long remain_space;
            remain_space = LTSMC.smc_conti_remain_space(_ConnectNo, 0);
            //Console.WriteLine(remain_space);  //插补剩余行数
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
            LTSMC.smc_set_profile_unit(CardNo, X_axis, start_speed, X_speed, tacc, tdec, stop_speed);//设置速度参数
            LTSMC.smc_set_s_profile(CardNo, X_axis, 0, s_pare);   //设置S平滑系数
            LTSMC.smc_pmove_unit(CardNo, Z_axis, 0, 1);    //启动定长运动  绝对值方式走到“0”位置
            LTSMC.smc_pmove_unit(CardNo, Y_axis, 0, 1);    //启动定长运动
            LTSMC.smc_pmove_unit(CardNo, X_axis, 0, 1);    //启动定长运动
            Console.WriteLine("123"); //
        }

        private void SB_Star_MouseDown(object sender, MouseEventArgs e)
        {
            LTSMC.smc_set_profile_unit(CardNo, X_axis, start_speed, X_speed, tacc, tdec, stop_speed);//设置速度参数
            LTSMC.smc_set_s_profile(CardNo, X_axis, 0, s_pare);   //设置S平滑系数
            LTSMC.smc_pmove_unit(CardNo, X_axis, max_Xdist, 0);    //启动定长运动
            Console.WriteLine("123"); //
        }

        private void SB_Star_MouseUp(object sender, MouseEventArgs e)
        {
            ushort CardNo = 0;          //卡号
            ushort mode = 0;     //停止模式，0；减速停止，1；紧急停止
            LTSMC.smc_stop(CardNo, X_axis, mode);  //轴停止运动 （卡号， 运动轴号 ， 停止模式：0；减速停止，1；紧急停止）
        }

        private void X_axis_plus_MouseDown(object sender, MouseEventArgs e)  // X+
        {
            
            LTSMC.smc_set_profile_unit(CardNo, X_axis, start_speed, X_speed, tacc, tdec, stop_speed);//设置速度参数
            LTSMC.smc_set_s_profile(CardNo, X_axis, 0, s_pare);   //设置S平滑系数
            LTSMC.smc_pmove_unit(CardNo, X_axis, max_Xdist, 1);    //启动定长运动
            Console.WriteLine("123"); //
        }

        private void X_axis_plus_MouseUp(object sender, MouseEventArgs e)
        {
            LTSMC.smc_stop(CardNo, X_axis, mode);  //轴停止运动 （卡号， 运动轴号 ， 停止模式：0；减速停止，1；紧急停止）
        }

        private void X_axis_sub_MouseDown(object sender, MouseEventArgs e)  // X-
        {

            LTSMC.smc_set_profile_unit(CardNo, X_axis, start_speed, X_speed, tacc, tdec, stop_speed);//设置速度参数
            LTSMC.smc_set_s_profile(CardNo, X_axis, 0, s_pare);   //设置S平滑系数
            LTSMC.smc_pmove_unit(CardNo, X_axis, min_Xdist, 1);    //启动定长运动
            Console.WriteLine("123"); //
        }

        private void X_axis_sub_MouseUp(object sender, MouseEventArgs e)
        {
            LTSMC.smc_stop(CardNo, X_axis, mode);  //轴停止运动 （卡号， 运动轴号 ， 停止模式：0；减速停止，1；紧急停止）
        }

        private void Y_axis_plus_MouseDown(object sender, MouseEventArgs e)     // Y+
        {
            
            LTSMC.smc_set_profile_unit(CardNo, Y_axis, start_speed, Y_speed, tacc, tdec, stop_speed);//设置速度参数
            LTSMC.smc_set_s_profile(CardNo, Y_axis, 0, s_pare);   //设置S平滑系数
            LTSMC.smc_pmove_unit(CardNo, Y_axis, max_Ydist, 1);    //启动定长运动
            Console.WriteLine("123"); //
        }

        private void Y_axis_plus_MouseUp(object sender, MouseEventArgs e)
        {
            
            LTSMC.smc_stop(CardNo, Y_axis, mode);  //轴停止运动 （卡号， 运动轴号 ， 停止模式：0；减速停止，1；紧急停止）
        }

        private void Y_axis_sub_MouseDown(object sender, MouseEventArgs e)      // Y-
        {
            
            LTSMC.smc_set_profile_unit(CardNo, Y_axis, start_speed, Y_speed, tacc, tdec, stop_speed);//设置速度参数
            LTSMC.smc_set_s_profile(CardNo, Y_axis, 0, s_pare);   //设置S平滑系数
            LTSMC.smc_pmove_unit(CardNo, Y_axis, min_Ydist, 1);    //启动定长运动
            Console.WriteLine("123"); //
        }

        private void Y_axis_sub_MouseUp(object sender, MouseEventArgs e)
        {
            
            LTSMC.smc_stop(CardNo, Y_axis, mode);  //轴停止运动 （卡号， 运动轴号 ， 停止模式：0；减速停止，1；紧急停止）
        }

        private void Z_axis_plus_MouseDown(object sender, MouseEventArgs e)     //Z+
        {
            
            LTSMC.smc_set_profile_unit(CardNo, Z_axis, start_speed, Z_speed, tacc, tdec, stop_speed);//设置速度参数
            LTSMC.smc_set_s_profile(CardNo, Z_axis, 0, s_pare);   //设置S平滑系数
            LTSMC.smc_pmove_unit(CardNo, Z_axis, max_Zdist, 1);    //启动定长运动
            Console.WriteLine("123"); //
        }

        private void Z_axis_plus_MouseUp(object sender, MouseEventArgs e)
        {
            
            LTSMC.smc_stop(CardNo, Z_axis, mode);  //轴停止运动 （卡号， 运动轴号 ， 停止模式：0；减速停止，1；紧急停止）
        }

        private void Z_axis_sub_MouseDown(object sender, MouseEventArgs e)      //Z-
        {
            
            LTSMC.smc_set_profile_unit(CardNo, Z_axis, start_speed, Z_speed, tacc, tdec, stop_speed);//设置速度参数
            LTSMC.smc_set_s_profile(CardNo, Z_axis, 0, s_pare);   //设置S平滑系数
            LTSMC.smc_pmove_unit(CardNo, Z_axis, min_Zdist, 1);    //启动定长运动
            Console.WriteLine("123"); //
        }

        private void Z_axis_sub_MouseUp(object sender, MouseEventArgs e)
        {
            
            LTSMC.smc_stop(CardNo, Z_axis, mode);  //轴停止运动 （卡号， 运动轴号 ， 停止模式：0；减速停止，1；紧急停止）
        }

        private void MachHome_Click(object sender, EventArgs e)
        {

            ushort outmode = 2; //脉冲输出方式  0,PUL+ DIR+ ;2, PUL+ DIR- 高脉冲/低方向
            ushort axis ;   //运动轴号，范围：0~最大轴数-1y
            double equiv = 1600; //脉冲当量，单位：1600 pulse/unit

            double Start_Vel = 1.0;//回零起始速度，范围：0~2MHz频率;  1.0 unit/s= 1mm/s
            double Max_Vel = 10.0;//回零运行速度，范围：0~2MHz频率
            double Tacc = 0.1; //加速时间，单位s，范围：0.001~10s
            double Tdec = 0.2;  //减速时间,单位s，范围：0.001~10s

            ushort org_logic = 0; //设置原点有效电平：0-低电平，1-高电平
            double filter = 0; //滤波时间为0，保留参数，无意义

            ushort home_dir = 0; //设置回原点方向：0-负向、1-正向
            ushort mode = 1; //设置回原点模式为一次回原点加反找
            ushort Source = 0; //设置计数源为脉冲计数 0：指令位置计数器，1：编码器计数器
            ushort enable = 2; //设置完成回原点后计数使能0：禁止。1:先清0，然后运动到指定位置（相对位置）。2:先运动到指定位置（相对位置），再清0
            double position = 0; //设置完成回原点后计数值

            axis = Z_axis; //运动轴号，范围：0~最大轴数-1y
            home_dir = 1; //设置 Z轴 回原点方向：0-负向、1-正向
            LTSMC.smc_set_pulse_outmode(_ConnectNo, axis, outmode);                 //设置脉冲模式  2, PUL+ DIR- 高脉冲/低方向
            LTSMC.smc_set_equiv(_ConnectNo, axis, 1280);                           //设置脉冲当量 1600 pulse/unit
            LTSMC.smc_set_alm_mode(_ConnectNo, axis, 0, 0, 0);                      //设置报警使能，关闭报警
            LTSMC.smc_write_sevon_pin(_ConnectNo, axis, 0);                         //打开伺服使能
            LTSMC.smc_set_home_pin_logic(_ConnectNo, axis, org_logic, filter);      //设置原点低电平有效  org_logic有效电平：0-低电平，1-高电平
            LTSMC.smc_set_home_profile_unit(_ConnectNo, axis, Start_Vel, Max_Vel, Tacc, Tdec);//设置 轴号、起始速度、运行速度、加速时间、减速时间
            LTSMC.smc_set_homemode(_ConnectNo, axis, home_dir, 1, mode, Source);    //设置回零模式 原点方向、原点速度模式、原点模式、返回回零计数源
            LTSMC.smc_set_home_position_unit(_ConnectNo, axis, enable, position);   //设置偏移模式
            LTSMC.smc_home_move(_ConnectNo, axis);          //启动回零

            ushort state = new ushort();
            while (state == 0)
            {
                LTSMC.smc_get_home_result(_ConnectNo, axis, ref state);
                Thread.Sleep(500);
                Console.WriteLine(state); //
            }
            Console.WriteLine(state); //

            state = 0;
            axis = X_axis; //运动轴号，范围：0~最大轴数-1y
            home_dir = 0; //设置 X轴 回原点方向：0-负向、1-正向
            LTSMC.smc_set_pulse_outmode(_ConnectNo, axis, outmode);                 //设置脉冲模式  2, PUL+ DIR- 高脉冲/低方向
            LTSMC.smc_set_equiv(_ConnectNo, axis, equiv);                           //设置脉冲当量 1600 pulse/unit
            LTSMC.smc_set_alm_mode(_ConnectNo, axis, 0, 0, 0);                      //设置报警使能，关闭报警
            LTSMC.smc_write_sevon_pin(_ConnectNo, axis, 0);                         //打开伺服使能
            LTSMC.smc_set_home_pin_logic(_ConnectNo, axis, org_logic, filter);      //设置原点低电平有效  org_logic有效电平：0-低电平，1-高电平
            LTSMC.smc_set_home_profile_unit(_ConnectNo, axis, Start_Vel, Max_Vel, Tacc, Tdec);//设置 轴号、起始速度、运行速度、加速时间、减速时间
            LTSMC.smc_set_homemode(_ConnectNo, axis, home_dir, 1, mode, Source);    //设置回零模式 原点方向、原点速度模式、原点模式、返回回零计数源
            LTSMC.smc_set_home_position_unit(_ConnectNo, axis, enable, position);   //设置偏移模式
            LTSMC.smc_home_move(_ConnectNo, axis);          //启动回零

            while (state == 0)
            {
                LTSMC.smc_get_home_result(_ConnectNo, axis, ref state);
                Thread.Sleep(500);
                Console.WriteLine(state); //
            }
            Console.WriteLine(state); //

            state = 0;
            axis = Y_axis; //运动轴号，范围：0~最大轴数-1y
            home_dir = 0; //设置 Y轴 回原点方向：0-负向、1-正向
            LTSMC.smc_set_pulse_outmode(_ConnectNo, axis, outmode);                 //设置脉冲模式  2, PUL+ DIR- 高脉冲/低方向
            LTSMC.smc_set_equiv(_ConnectNo, axis, equiv);                           //设置脉冲当量 1600 pulse/unit
            LTSMC.smc_set_alm_mode(_ConnectNo, axis, 0, 0, 0);                      //设置报警使能，关闭报警
            LTSMC.smc_write_sevon_pin(_ConnectNo, axis, 0);                         //打开伺服使能
            LTSMC.smc_set_home_pin_logic(_ConnectNo, axis, org_logic, filter);      //设置原点低电平有效  org_logic有效电平：0-低电平，1-高电平
            LTSMC.smc_set_home_profile_unit(_ConnectNo, axis, Start_Vel, Max_Vel, Tacc, Tdec);//设置 轴号、起始速度、运行速度、加速时间、减速时间
            LTSMC.smc_set_homemode(_ConnectNo, axis, home_dir, 1, mode, Source);    //设置回零模式 原点方向、原点速度模式、原点模式、返回回零计数源
            LTSMC.smc_set_home_position_unit(_ConnectNo, axis, enable, position);   //设置偏移模式
            LTSMC.smc_home_move(_ConnectNo, axis);          //启动回零
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

            string gcode = textBox5.Text;    //Trim（）去除头尾空格,ToUpper()全部大写.StartsWith("G")判断首位是不是G
            string[] gcodeList = gcode.Split(new string[] { "\r\n" }, StringSplitOptions.None); //Split()，分隔字符串。通过“ ”截取数组，截取出单行指令。


            VectorInit();   //--------------------插补初始化---------------------------

            Dictionary<string, double> gcodeParameter = new Dictionary<string, double>(); //创建一个字典。Dictionary提供快速的基于键值的元素查找。可以根据key得到value
            for (int clist = 0; clist < gcodeList.Length; ++clist)
            {
                
                if (gcodeList[clist].Trim().ToUpper().StartsWith("G")) //*****这里后续应该写成直接提取G01 G101 这样的形式，从第一个字母开始，到下一个字母截止
                {
                    Console.WriteLine("G");
                    textBox3.Text = "G";

                    string[] subGcodes = gcodeList[clist].Split(' ');  //Split()，分隔字符串。通过" "截取数组。
                    string gcodeNumber = subGcodes[0].Substring(1, subGcodes[0].Length - 1);    //Substring（），截取首段字符串。提取除关键“G”以外的数值。 
                    string gcodeCommand = gcodeNumber.TrimStart('0');   //保留指令的有效数值

                    for (int i = 1; i < subGcodes.Length; ++i)  //提取单行指令的 单段数据。
                    {
                        string GcodeKey = subGcodes[i].Substring(0, 1);  //提取GcodeKey ,即 Dictionary 的字典位置。
                        if (GcodeKey != null)
                        {
                            double GcodeNumber = double.Parse(subGcodes[i].Substring(1, subGcodes[i].Length - 1));    //double.Parse 强制转化 double

                            if (gcodeParameter.ContainsKey(GcodeKey)==false)
                            {
                                //不存在，则添加
                                gcodeParameter.Add(GcodeKey, GcodeNumber);  //添加一组 集合
                                Console.WriteLine("新增_" + GcodeKey + gcodeParameter[GcodeKey]);
                                Console.WriteLine( gcodeParameter[GcodeKey]);
                            }
                            else
                            {
                                gcodeParameter[GcodeKey]= GcodeNumber;  //添加一组 集合
                                Console.WriteLine("修改_" + GcodeKey + gcodeParameter[GcodeKey]);
                                Console.WriteLine( gcodeParameter[GcodeKey]);
                                //如果指定的字典的键存在
                                //gcodeParameter[GcodeKey] = GcodeNumber;
                            }
                        }
                    }

                    if (gcodeCommand == "1")  //判断有效数值，是否为“G01”指令
                    {
                        textBox3.Text = "G01";
                        Console.WriteLine("G");
                        // Console.WriteLine("{0},{1}", "X", gcodeParameter["X"]);
                        // Console.WriteLine("Key:{0},Value:{1}", "X", gcodeParameter["X"]);
                        //double masagek = gcodeParameter["X"];
                        //Console.WriteLine(masagek);

                        if (gcodeParameter.ContainsKey("X"))    //判断指令中是否有"X" 的元素
                        {
                            Dist[0] = gcodeParameter["X"] + DistWork[0];    //添加工件坐标偏置
                        }
                        else
                        {
                            Dist[0] = Dist[0];
                        }

                        if (gcodeParameter.ContainsKey("Y"))    //判断指令中是否有"X" 的元素
                        {
                            Dist[1] = gcodeParameter["Y"] + DistWork[1];    //添加工件坐标偏置
                        }
                        else
                        {
                            Dist[1] = Dist[1];
                        }

                        if (gcodeParameter.ContainsKey("Z"))    //判断指令中是否有"X" 的元素
                        {
                            Dist[2] = gcodeParameter["Z"] + DistWork[2];    //添加工件坐标偏置
                        }
                        else
                        {
                            Dist[2] = Dist[2];

                        }

                        if (gcodeParameter.ContainsKey("F"))    //判断指令中是否有"X" 的元素
                        {
                            MyMax_Vel = gcodeParameter["F"];    //添加工件坐标偏置
                        }
                        else
                        {
                            MyMax_Vel = MyMax_Vel;
                        }

                        // Dist[3] = gcodeParameter["U"];
                        //MyMax_Vel = gcodeParameter["F"];
                       
                        VectorLineRun();    //插补运行

                    }
                    else if (gcodeCommand == "2")    //判断有效数值，是否为“G02”指令
                    {
                        textBox3.Text = "G02";
                        Dist[0] = gcodeParameter["X"];
                        Dist[1] = gcodeParameter["Y"];
                        Dist[2] = gcodeParameter["Z"];
                        MyMax_Vel = gcodeParameter["F"];
                        VectorInit();   //插补初始化
                        //VectorRun();    //插补运行
                    }


                }
                else if (gcodeList[clist].Trim().ToUpper().StartsWith("M"))
                {
                    Console.WriteLine("M");
                    textBox3.Text = "M";

                    string[] subGcodes = gcodeList[clist].Split(' ');  //Split()，分隔字符串。通过“ ”截取数组。
                    string gcodeNumber = subGcodes[0].Substring(1, subGcodes[0].Length - 1);    //Substring（），截取首段字符串。提取除关键“G”以外的数值。 
                    string gcodeCommand = gcodeNumber.TrimStart('0');   //保留指令的有效数值
                    Console.WriteLine(gcodeCommand);
                    for (int i = 1; i < subGcodes.Length; ++i)  //提取单行指令的 单段数据。
                    {
                        string GcodeKey = subGcodes[i].Substring(0, 1);  //提取GcodeKey ,即 Dictionary 的字典位置。
                        if (GcodeKey != null)
                        {
                            double GcodeNumber = double.Parse(subGcodes[i].Substring(1, subGcodes[i].Length - 1));    //double.Parse 强制转化 double

                            if (gcodeParameter.ContainsKey(GcodeKey) == false)
                            {
                                //不存在，则添加
                                gcodeParameter.Add(GcodeKey, GcodeNumber);  //添加一组 集合
                                Console.WriteLine("新增_" + GcodeKey + gcodeParameter[GcodeKey]);
                                Console.WriteLine(gcodeParameter[GcodeKey]);
                            }
                            else
                            {
                                gcodeParameter[GcodeKey] = GcodeNumber;  //添加一组 集合
                                Console.WriteLine("修改_" + GcodeKey + gcodeParameter[GcodeKey]);
                                Console.WriteLine(gcodeParameter[GcodeKey]);
                                //如果指定的字典的键存在
                                //gcodeParameter[GcodeKey] = GcodeNumber;
                            }
                        }
                    }
                    if (gcodeCommand == "101")  //判断有效数值，是否为“G01”指令
                    {
                        

                        textBox3.Text = "M101";
                        Console.WriteLine("M101");
                        // Console.WriteLine("{0},{1}", "X", gcodeParameter["X"]);
                        // Console.WriteLine("Key:{0},Value:{1}", "X", gcodeParameter["X"]);
                        ushort IO_on = 0;
                        ushort IO_off = 1;
                       
                       // LTSMC.smc_conti_delay_outbit_to_start(_ConnectNo, MyCrd, 1, IO_on, -0.0, 0, 0); //连续插补中相对于轨迹段起点IO滞后输出（段内执行)
                       //LTSMC.smc_write_outbit(_ConnectNo, 0, IO_on); //立刻操作IO
                       // LTSMC.smc_write_outbit(_ConnectNo, 1, IO_on); 
                        LTSMC.smc_conti_write_outbit(_ConnectNo, MyCrd, 0, IO_on, 0.0);    //插补中立刻操作IO

                        //参数：ConnectNo 指定链接号：0 - 7,默认值0
                        //Crd 坐标系号，取值范围：0~1
                        //bitno 输出口号，取值范围：0~31
                        //on_off 电平状态，0：低电平，1：高电平
                        //delay_value 滞后值，单位：s（滞后时间模式）或unit（滞后距离模式）
                        //delay_mode 滞后模式，0：滞后时间，1：滞后距离
                        //ReverseTime 电平输出后的延时翻转时间，单位：s
                    }
                    else if (gcodeCommand == "103")    //判断有效数值，是否为“G02”指令
                    {
                        
                        textBox3.Text = "M103";
                        Console.WriteLine("M103");
                        ushort IO_on = 0;
                        ushort IO_off = 1;
                        VectorInit();   //插补初始化
                        //LTSMC.smc_write_outbit(_ConnectNo, 0, IO_off); /立刻操作IO
                        // LTSMC.smc_write_outbit(_ConnectNo, 1, IO_off); /立刻操作IO
                        LTSMC.smc_conti_write_outbit(_ConnectNo, MyCrd, 0, IO_off, 0.0); //插补中立刻操作IO
                        LTSMC.smc_conti_delay_outbit_to_start(_ConnectNo, MyCrd, 1, IO_off, 0, 0, 0); //连续插补中相对于轨迹段起点IO滞后输出（段内执行)
                       // LTSMC.smc_conti_ahead_outbit_to_stop(_ConnectNo, MyCrd, 1, IO_off, 2.0, 0, 0);     //连续插补中相对于轨迹段终点IO提前输出（段内执行,···,但是是针对下一条指令，蛋疼！！！
                        //参数：ConnectNo 指定链接号：0 - 7,默认值0
                        //Crd 坐标系号，取值范围：0~1
                        //bitno 输出口号，取值范围：0~31
                        //on_off 电平状态，0：低电平，1：高电平
                        //ahead_value 提前值，单位：s（提前时间模式）或unit（提前距离模式）
                        //ahead_mode 提前模式，0：提前时间，1：提前距离
                        //ReverseTime 电平输出后的延时翻转时间，单位：s     ***延时翻转，会对IO做一个短时间的翻转，然后再变化。
                    }
                    else if (gcodeCommand == "20")    //判断有效数值，是否为“G02”指令
                    {

                        textBox3.Text = "M20";
                        Console.WriteLine("M20");
                        //第八步、关闭连续插补缓冲区
                        LTSMC.smc_conti_close_list(_ConnectNo, MyCrd);
                    }

                }

                Console.WriteLine("没有识别");

            }

            //第八步、关闭连续插补缓冲区
            uint IoMask = 0;
            LTSMC.smc_conti_clear_io_action(_ConnectNo, MyCrd, 0);
            LTSMC.smc_conti_close_list(_ConnectNo, MyCrd);
            textBox3.Text = "";
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

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            AxisArray[0] = 0; //定义插补0轴为X轴
            AxisArray[2] = 2; //定义插补1轴为Y轴
            Dist[0] = 10; //定义X轴运动距离
            Dist[2] = -20; //Y轴运动距离
            LTSMC.smc_set_vector_profile_unit(_ConnectNo, MyCrd, MyMin_Vel, MyMax_Vel, MyTacc, MyTdec, MyStop_Vel); //第一步、设置插补运动速度参数
            LTSMC.smc_set_vector_s_profile(_ConnectNo, MyCrd, MySmode, MySpara);    //第二步、设置插补运动平滑参数
            LTSMC.smc_line_unit(_ConnectNo, MyCrd, MyaxisNum, AxisArray, Dist, Myposi_mode);    //第三步、启动直线插补运动
            */
            //****************临时征用来做IO实验**********************
            textBox3.Text = "M101";
            Console.WriteLine("M101");
            // Console.WriteLine("{0},{1}", "X", gcodeParameter["X"]);
            // Console.WriteLine("Key:{0},Value:{1}", "X", gcodeParameter["X"]);
            ushort IO_on = 0;
            ushort IO_off = 1;
            
            LTSMC.smc_conti_write_outbit(_ConnectNo, MyCrd, 0, IO_on, 0.0);    //插补中立刻操作IO
            VectorInit();   //插补初始化
            Console.WriteLine("button1_ 出丝");
            //  ConnectNo 指定链接号：0 - 7
            //  Crd 坐标系号，取值范围：0~1
            //  bitno 输出口号，取值范围：0~31
            //  on_off 电平状态，0：低电平，1：高电平
            //  ReverseTime 电平输出后的延时翻转时间，单位：s
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
            AxisArray[0] = 0; //定义插补0轴为X轴
            AxisArray[2] = 2; //定义插补1轴为Y轴
            Dist[0] = 100; //定义X轴运动距离
            Dist[2] = -10; //Y轴运动距离
            LTSMC.smc_set_vector_profile_unit(_ConnectNo, MyCrd, MyMin_Vel, MyMax_Vel, MyTacc, MyTdec, MyStop_Vel); //第一步、设置插补运动速度参数
            LTSMC.smc_set_vector_s_profile(_ConnectNo, MyCrd, MySmode, MySpara);    //第二步、设置插补运动平滑参数
            LTSMC.smc_line_unit(_ConnectNo, MyCrd, MyaxisNum, AxisArray, Dist, Myposi_mode);    //第三步、启动直线插补运动
            */
            textBox3.Text = "M103";
            Console.WriteLine("M103");
            // Console.WriteLine("{0},{1}", "X", gcodeParameter["X"]);
            // Console.WriteLine("Key:{0},Value:{1}", "X", gcodeParameter["X"]);
            ushort IO_on = 0;
            ushort IO_off = 1;
            
            LTSMC.smc_conti_write_outbit(_ConnectNo, MyCrd, 0, IO_off, 0.0);    //插补中立刻操作IO

            VectorInit();   //插补初始化
            Console.WriteLine("button1_ 关丝");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AxisArray[0] = 0; //定义插补0轴为X轴
            AxisArray[1] = 1; //定义插补1轴为Y轴
            Dist[0] = 100; //定义X轴运动距离
            Dist[1] = 0; //Y轴运动距离
            LTSMC.smc_set_vector_profile_unit(_ConnectNo, MyCrd, MyMin_Vel, MyMax_Vel, MyTacc, MyTdec, MyStop_Vel); //第一步、设置插补运动速度参数
            LTSMC.smc_set_vector_s_profile(_ConnectNo, MyCrd, MySmode, MySpara);    //第二步、设置插补运动平滑参数
            LTSMC.smc_line_unit(_ConnectNo, MyCrd, MyaxisNum, AxisArray, Dist, Myposi_mode);    //第三步、启动直线插补运动
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AxisArray[0] = 0; //定义插补0轴为X轴
            AxisArray[1] = 1; //定义插补1轴为Y轴
            AxisArray[2] = 2; //定义插补2轴为Z轴
            cen[0] = 10000; //定义X轴圆心坐标
            cen[1] = 0; //定义Y轴圆心坐标
            Dist[0] = 10; //定义X轴运动终点
            Dist[1] = 0; //定义Y轴运动终点
            Dist[2] = -1.5; //定义Y轴运动终点
            //第一步、设置插补运动速度参数、S时间参数
            LTSMC.smc_set_vector_profile_unit(_ConnectNo, MyCrd, MyMin_Vel, MyMax_Vel, MyTacc, MyTdec, MyStop_Vel);
            LTSMC.smc_set_vector_s_profile(_ConnectNo, MyCrd, MySmode, MySpara);
            //第二步、设置圆弧限速功能使能
            LTSMC.smc_set_arc_limit(_ConnectNo, MyCrd, ArcLimit, 0, 0);
            //第三步、设置前瞻参数
            LTSMC.smc_conti_set_lookahead_mode(_ConnectNo, MyCrd, mode, LookaheadSegment, PathError, LookaheadAcc);
            //第四步、打开连续插补
            LTSMC.smc_conti_open_list(_ConnectNo, MyCrd, MyaxisNum, AxisArray);
            //第五步、开始连续插补
            LTSMC.smc_conti_start_list(_ConnectNo, MyCrd);
            //第六步、添加直线插补段
            LTSMC.smc_conti_line_unit(_ConnectNo, MyCrd, MyaxisNum, AxisArray, Dist, Myposi_mode, 0);
            Dist[0] = 12; //定义X轴运动终点
            Dist[1] = 10; //定义Y轴运动终点
            Dist[2] = -10; //定义Y轴运动终点
            LTSMC.smc_conti_line_unit(_ConnectNo, MyCrd, MyaxisNum, AxisArray, Dist, Myposi_mode, 0);
            Dist[0] = 20; //定义X轴运动终点
            Dist[1] = 0; //定义Y轴运动终点
            Dist[2] = -15; //定义Y轴运动终点
            LTSMC.smc_conti_line_unit(_ConnectNo, MyCrd, MyaxisNum, AxisArray, Dist, Myposi_mode, 0);
            Dist[0] = 10; //定义X轴运动终点
            Dist[1] = 20; //定义Y轴运动终点
            Dist[2] = 0; //定义Y轴运动终点
            LTSMC.smc_conti_line_unit(_ConnectNo, MyCrd, MyaxisNum, AxisArray, Dist, Myposi_mode, 0);
            //第七步、添加圆弧插补段
            // LTSMC.smc_conti_arc_move_center_unit(_ConnectNo, MyCrd, MyaxisNum, AxisArray, Dist, cen, dir, cic, Myposi_mode, 0);
            //第八步、关闭连续插补缓冲区
            LTSMC.smc_conti_close_list(_ConnectNo, MyCrd);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AxisArray[0] = 0; //定义插补0轴为X轴
            AxisArray[1] = 1; //定义插补1轴为Y轴
            Dist[0] = 100; //定义X轴运动距离
            Dist[1] = 80; //Y轴运动距离
            LTSMC.smc_set_vector_profile_unit(_ConnectNo, MyCrd, MyMin_Vel, MyMax_Vel, MyTacc, MyTdec, MyStop_Vel); //第一步、设置插补运动速度参数
            LTSMC.smc_set_vector_s_profile(_ConnectNo, MyCrd, MySmode, MySpara);    //第二步、设置插补运动平滑参数
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AxisArray[0] = 0; //定义插补0轴为X轴
            AxisArray[1] = 1; //定义插补1轴为Y轴

            Dist[0] = 10 + DistWork[0]; //定义X轴运动距离
            Dist[1] = 0 + DistWork[1];  //Y轴运动距离
            LTSMC.smc_line_unit(_ConnectNo, MyCrd, MyaxisNum, AxisArray, Dist, Myposi_mode);    //第三步、启动直线插补运动
            
            Dist[0] = 10 + DistWork[0]; //定义X轴运动距离
            Dist[1] = 1 + DistWork[1];  //Y轴运动距离
            LTSMC.smc_line_unit(_ConnectNo, MyCrd, MyaxisNum, AxisArray, Dist, Myposi_mode);    //第三步、启动直线插补运动

            Dist[0] = -10 + DistWork[0]; //定义X轴运动距离
            Dist[1] = 1 + DistWork[1];  //Y轴运动距离
            LTSMC.smc_line_unit(_ConnectNo, MyCrd, MyaxisNum, AxisArray, Dist, Myposi_mode);    //第三步、启动直线插补运动
           
            Dist[0] = -10 + DistWork[0]; //定义X轴运动距离
            Dist[1] = 2 + DistWork[1];  //Y轴运动距离
            LTSMC.smc_line_unit(_ConnectNo, MyCrd, MyaxisNum, AxisArray, Dist, Myposi_mode);    //第三步、启动直线插补运动

            Dist[0] = 10 + DistWork[0]; //定义X轴运动距离
            Dist[1] = 2 + DistWork[1];  //Y轴运动距离
            LTSMC.smc_line_unit(_ConnectNo, MyCrd, MyaxisNum, AxisArray, Dist, Myposi_mode);    //第三步、启动直线插补运动

            Dist[0] = 10 + DistWork[0]; //定义X轴运动距离
            Dist[1] = 3 + DistWork[1];  //Y轴运动距离
            LTSMC.smc_line_unit(_ConnectNo, MyCrd, MyaxisNum, AxisArray, Dist, Myposi_mode);    //第三步、启动直线插补运动

            Dist[0] = -10 + DistWork[0]; //定义X轴运动距离
            Dist[1] = 3 + DistWork[1];  //Y轴运动距离
            LTSMC.smc_line_unit(_ConnectNo, MyCrd, MyaxisNum, AxisArray, Dist, Myposi_mode);    //第三步、启动直线插补运动

        }                       
        
        private void VectorInit()
        {
            AxisArray[0] = 0; //定义插补0轴为X轴
            AxisArray[1] = 1; //定义插补1轴为Y轴
            AxisArray[2] = 2; //定义插补2轴为Z轴
            cen[0] = 20; //定义X轴圆心坐标
            cen[1] = 20; //定义Y轴圆心坐标

            

            //第一步、设置插补运动速度参数、S时间参数
            LTSMC.smc_set_vector_profile_unit(_ConnectNo, MyCrd, MyMin_Vel, MyMax_Vel, MyTacc, MyTdec, MyStop_Vel);
            LTSMC.smc_set_vector_s_profile(_ConnectNo, MyCrd, MySmode, MySpara);
            //第二步、设置圆弧限速功能使能
            //  LTSMC.smc_set_arc_limit(_ConnectNo, MyCrd, ArcLimit, 0, 0);
            //第三步、设置前瞻参数
            LTSMC.smc_conti_set_lookahead_mode(_ConnectNo, MyCrd, 1, LookaheadSegment, PathError, LookaheadAcc);
            //ConnectNo 指定链接号：0 - 7,默认值0
            //Crd 坐标系号，取值范围：0~1
            //lookaheadMode 插补模式：0 - 非前瞻模式0，1 - 前瞻模式1，2 - 非前瞻模式2
            //LookaheadSegment 前瞻段数，即每次运行时内部计算段数
            //PathError 轨迹误差，单位：unit
            //LookaheadAcc 拐弯加速度，单位unit / s^2
            //第四步、打开连续插补
            LTSMC.smc_conti_open_list(_ConnectNo, MyCrd, MyaxisNum, AxisArray);
            //第五步、开始连续插补
            LTSMC.smc_conti_start_list(_ConnectNo, MyCrd);
        }

        private void VectorLineRun()
        {
            //Dist[0] = 120; //定义X轴运动终点
            //Dist[1] = 100; //定义Y轴运动终点
            
            //LTSMC.smc_set_vector_s_profile(_ConnectNo, MyCrd, MySmode, MySpara);
            LTSMC.smc_set_vector_speed_unit(_ConnectNo, MyCrd, MyMax_Vel);  //设置连续插补速度曲线
            LTSMC.smc_conti_line_unit(_ConnectNo, MyCrd, MyaxisNum, AxisArray, Dist, Myposi_mode, 0);
            //第五步、开始连续插补
            //第六步、添加直线插补段
                  
            //第八步、关闭连续插补缓冲区
            //LTSMC.smc_conti_close_list(_ConnectNo, MyCrd);
        }

        private void VectorArcRun()
        {

            //Dist[0] = 120; //定义X轴运动终点
            //Dist[1] = 100; //定义Y轴运动终点
            //第五步、开始连续插补
            LTSMC.smc_conti_start_list(_ConnectNo, MyCrd);
            cen[0] = 20; //定义X轴圆心坐标
            cen[1] = 20; //定义Y轴圆心坐标
            //-----------添加圆弧插补段------------
            //第六步_1、添加圆弧插补段 ,圆心+圆弧终点模式扩展的螺旋线插补运动（可作两轴圆弧插补）
            LTSMC.smc_arc_move_center_unit(_ConnectNo, MyCrd, MyaxisNum, AxisArray, Dist, cen, dir, Myposi_mode, 0);
                    //参数：ConnectNo 指定链接号：0 - 7,默认值0
                    //Crd 坐标系号，取值范围：0~1
                    //AxisNum 运动轴数，取值范围：2~控制器最大轴数
                    //AxisList 轴号列表
                    //Target_Pos 目标位置数组，单位：unit
                    //Cen_Pos 圆心位置数组，单位：unit
                    //Arc_Dir 圆弧方向，0：顺时针，1：逆时针
                    //Circle 圈数：负数：表示此时执行的为同心圆插补该值的绝对值加1表示同心圆的圈数。如，-1即表示2圈同心圆插补，-2表示3圈同心圆插补…
                                    //自然数：表示此时执行的为螺旋线插补该值表示螺旋线的圈数。如，0即表示0圈螺旋线插补，1表示1圈螺旋线插补…
                    //posi_mode 运动模式，0：相对坐标模式，1：绝对坐标模式
            //第六步_2、添加圆弧插补段 ,圆心+圆弧终点模式扩展的螺旋线插补运动（可作两轴圆弧插补）
                //LTSMC.smc_arc_move_radius_unit()
            //第六步_3、添加圆弧插补段 ,圆心+圆弧终点模式扩展的螺旋线插补运动（可作两轴圆弧插补）
                //LTSMC.smc_arc_move_3points_unit()
            //第八步、关闭连续插补缓冲区
            // LTSMC.smc_conti_close_list(_ConnectNo, MyCrd);
        }

        private void IfVectorStop()
        {

        }
        private void Ifsoftlimit()
        {
            if (min_Xdist <= Dist[0] & Dist[0] <= max_Xdist)
            {

            }
            else if (Dist[0] < min_Xdist)
            {
                Dist[0] = min_Xdist;
            }
            else
            {
                Dist[0] = max_Xdist;
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Pause_Click(object sender, EventArgs e)
        {
            LTSMC.smc_conti_pause_list(_ConnectNo, MyCrd);
        }
    }

}
