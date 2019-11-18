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
        double max_dist = 600;    //运动距离
        double min_dist = 0;    //运动距离
        ushort mode = 0;     //停止模式，0；减速停止，1；紧急停止


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
            //
            double pos = 0.0;
            LTSMC.smc_get_position_unit(_ConnectNo, 0, ref pos);
            sb.AppendFormat("X={0},", pos);
            LTSMC.smc_get_position_unit(_ConnectNo, 1, ref pos);
            sb.AppendFormat("Y={0},", pos);
            LTSMC.smc_get_position_unit(_ConnectNo, 2, ref pos);
            sb.AppendFormat("Z={0},", pos);
            LTSMC.smc_get_position_unit(_ConnectNo, 3, ref pos);
            sb.AppendFormat("U={0},", pos);
            LTSMC.smc_get_position_unit(_ConnectNo, 4, ref pos);
            sb.AppendFormat("V={0},", pos);
            LTSMC.smc_get_position_unit(_ConnectNo, 5, ref pos);
            sb.AppendFormat("W={0},", pos);
            double speed = 0;
            LTSMC.smc_read_current_speed_unit(_ConnectNo, 0, ref speed);
            sb.AppendFormat("Speed={0},", speed);
            //
            textBox1.Text = sb.ToString();
            // Console.WriteLine("456");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            LTSMC.smc_board_close(_ConnectNo);
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            //
            double pos = 0.0;
            LTSMC.smc_get_position_unit(_ConnectNo, 0, ref pos);
            sb.AppendFormat("X={0},", pos);
            LTSMC.smc_get_position_unit(_ConnectNo, 1, ref pos);
            sb.AppendFormat("Y={0},", pos);
            LTSMC.smc_get_position_unit(_ConnectNo, 2, ref pos);
            sb.AppendFormat("Z={0},", pos);
            LTSMC.smc_get_position_unit(_ConnectNo, 3, ref pos);
            sb.AppendFormat("U={0},", pos);
            LTSMC.smc_get_position_unit(_ConnectNo, 4, ref pos);
            sb.AppendFormat("V={0},", pos);
            LTSMC.smc_get_position_unit(_ConnectNo, 5, ref pos);
            sb.AppendFormat("W={0},", pos);
            double speed = 0;
            LTSMC.smc_read_current_speed_unit(_ConnectNo, 0, ref speed);
            sb.AppendFormat("Speed={0},", speed);
            //
            textBox1.Text = sb.ToString();
            Console.WriteLine("789");
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

        private void X_axis_plus_MouseDown(object sender, MouseEventArgs e)
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

        private void X_axis_sub_MouseDown(object sender, MouseEventArgs e)
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

        private void Y_axis_plus_MouseDown(object sender, MouseEventArgs e)
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

        private void Y_axis_sub_MouseDown(object sender, MouseEventArgs e)
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

        private void Z_axis_plus_MouseDown(object sender, MouseEventArgs e)
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

        private void Z_axis_sub_MouseDown(object sender, MouseEventArgs e)
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

        }
    }
}
