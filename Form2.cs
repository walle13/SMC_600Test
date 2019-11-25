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

    public partial class Form2 : Form
    {
        private ushort _ConnecNo = 0;
        public Form2()
        {
            InitializeComponent();
            timer2.Start();
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {

            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //输入口
            uint n = LTSMC.smc_read_inport(_ConnecNo, 0); // 读取输入口的状态
            for (int i = 0; i < 24; i++)
            {
                Label label = GetINLabel(i);
                if (label != null)
                {
                    SetLabel(label, (n & 1) != 1);
                }
                n = n >> 1;
            }
            //输出口
            n = LTSMC.smc_read_outport(_ConnecNo, 0);   // 读取输出口的状态
            for (int i = 0; i < 24; i++)
            {
                Label label = GetOUTLabel(i);
                if (label != null)
                {
                    SetLabel(label, (n & 1) != 1);
                }
                n = n >> 1;
            }
            //专用口
            n = LTSMC.smc_axis_io_status(_ConnecNo, 0);
            SetAxisStatus(panel1, n);
            n = LTSMC.smc_axis_io_status(_ConnecNo, 1);
            SetAxisStatus(panel2, n);
            n = LTSMC.smc_axis_io_status(_ConnecNo, 2);
            SetAxisStatus(panel3, n);
            n = LTSMC.smc_axis_io_status(_ConnecNo, 3);
            SetAxisStatus(panel4, n);
            n = LTSMC.smc_axis_io_status(_ConnecNo, 4);
            SetAxisStatus(panel5, n);
            n = LTSMC.smc_axis_io_status(_ConnecNo, 5);
            SetAxisStatus(panel6, n);

        }
        private Label GetINLabel(int index)
        {
            string txt = index.ToString();
            foreach (Label _label in groupBox1.Controls)
            {
                if (_label != null && _label.Text == txt)
                {
                    return _label;
                }
            }
            return null;
        }
        private Label GetOUTLabel(int index)
        {
            string txt = index.ToString();
            foreach (Label _label in groupBox2.Controls)
            {
                if (_label != null && _label.Text == txt)
                {
                    return _label;
                }
            }
            return null;
        }
        private void SetLabel(Label label, bool status)
        {
            if (label != null)
            {
                if (status)
                {
                    label.BackColor = Color.Red;
                }
                else
                {
                    label.BackColor = Color.Green;
                }
            }
        }
        private void SetAxisStatus(Panel panel, uint status)
        {
            foreach (Label _label in panel.Controls)
            {
                if (_label != null)
                {
                    if (_label.Text == "ALM")
                    {
                        SetLabel(_label, (status & 1) == 1);
                    }
                    else if (_label.Text == "EL+")
                    {
                        SetLabel(_label, (status & (int)Math.Pow(2, 1)) == (int)Math.Pow(2, 1));
                    }
                    else if (_label.Text == "EL-")
                    {
                        SetLabel(_label, (status & (int)Math.Pow(2, 2)) == (int)Math.Pow(2, 2));
                    }
                    else if (_label.Text == "EMG")
                    {
                        SetLabel(_label, (status & (int)Math.Pow(2, 3)) == (int)Math.Pow(2, 3));
                    }
                    else if (_label.Text == "HOME")
                    {
                        SetLabel(_label, (status & (int)Math.Pow(2, 4)) == (int)Math.Pow(2, 4));
                    }
                    else if (_label.Text == "SL+")
                    {
                        SetLabel(_label, (status & (int)Math.Pow(2, 6)) == (int)Math.Pow(2, 6));
                    }
                    else if (_label.Text == "SL-")
                    {
                        SetLabel(_label, (status & (int)Math.Pow(2, 7)) == (int)Math.Pow(2, 7));
                    }
                    else if (_label.Text == "INP")
                    {
                        SetLabel(_label, (status & (int)Math.Pow(2, 8)) == (int)Math.Pow(2, 8));
                    }
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer2.Stop();
            LTSMC.smc_board_close(_ConnecNo);
        }

        private void label_Click(object sender, EventArgs e)
        {
            int index = -1;
            foreach (Label _label in groupBox2.Controls)
            {
                if (_label == sender)
                {
                    index = Convert.ToInt32(_label.Text);
                    break;
                }
            }
            if (index >= 0)
            {

                short s = LTSMC.smc_read_outbit(_ConnecNo, (ushort)index);
                if (s == 1)
                {
                    LTSMC.smc_write_outbit(_ConnecNo, (ushort)(index), 0);
                }
                else
                {
                    LTSMC.smc_write_outbit(_ConnecNo, (ushort)(index), 1);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LTSMC.smc_write_outbit(_ConnecNo, 18, 0);
            LTSMC.smc_write_outbit(_ConnecNo, 19, 0);
            LTSMC.smc_write_outbit(_ConnecNo, 20, 0);
        }
    }

}
