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
    public partial class CB_Start : Form
    {
        public CB_Start()
        {
            InitializeComponent();
        }

        private void SB_Start_Click(object sender, EventArgs e)
        {
            ushort CardNo = 0;          //卡号
            ushort axis = 0;            //运动轴号u
            double start_speed = 0;     //启动速度
            double speed = 1000;        //最大运行速度
            double stop_speed = 0;      //停止速度
            double tacc = 0.1;          //加速时间
            double tdec = 0.1;      //减速时间
            double s_pare = 0.05;   //s形平滑系数
            double dist = 10000;    //运动距离
            LTSMC.smc_set_profile_unit(CardNo, axis, start_speed, speed, tacc, tdec, stop_speed);//设置速度参数
            LTSMC.smc_set_s_profile(CardNo, axis, 0, s_pare);   //设置S平滑系数
            LTSMC.smc_pmove_unit(CardNo, axis, dist, 0);    //启动定长运动
                
        }

        private void SB_Stop_Click(object sender, EventArgs e)
        {
            ushort CardNo = 0;          //卡号
            ushort axis = 0;            //运动轴号u
            ushort mode = 0;     //停止模式，0；减速停止，1；紧急停止
            LTSMC.smc_stop(CardNo, axis, mode);
        }

        private void CB_Start_Load(object sender, EventArgs e)
        {
            ushort CardNo = 0;
            short res = LTSMC.smc_board_init(CardNo, 2, "192.168.2.77", 0);
            if (res != 0)
            {
                MessageBox.Show(string.Format("连接控制器失败，错误码：【0】",res),"错误");
            }
            
        }
    }
}
