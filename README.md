# SMC_600Test

LEADSHINE SMC600 
默认连接IP 192.168.1.77
5axis test

---
	2019.12.05
X/Y轴脉冲当量 1600pluse/unit  
导程4mm ；驱动32细分 ；57步进电机 200pluse/r
Z轴脉冲当量	1280pluse/unit
导程5mm ；驱动32细分 ；57步进电机 200pluse/r
1 unit = 1mm

X/Y轴脉冲模式  2, PUL+ DIR- 高脉冲/低方向

机械找零时候如何 停止
---
	2019.12.06
单条直线插补指令，smc_line_unit，不能连续使用。必须一条执行完毕后，再发送吓一调。
连续插补函数，可以缓冲执行。
smc_conti_open_list（）；
smc_conti_start_list（）；
smc_conti_line_unit();
最多可缓冲 5000行，通过smc_conti_remain_space(_ConnectNo, 0)可查。
---
	2019.12.12
测试指令，使用Dictionary 用于存储已有的指令坐标参数。
G01 X10.15 Y10.22 Z-1.5 F20
G01 X9 Z-9 F20
G01 X130 Y150 Z-15 F10
G01 X150 Y0 Z-5 F15
G01 X0 Y0 Z0 F20
---
	2020.04.1
实验 M101 M103指令对应功能；
smc_write_outbit 这个指令开IO。
smc_conti_ahead_outbit_to_stop 
连续插补中相对于轨迹段起点IO滞后输出	1.提前关丝指令倒是有用，但是针对下一条指令的。
2.必须插入在两个 smc_conti_start_list 中间才有用
smc_conti_write_outbit 
插补中立刻操作IO
1.插补中立刻操作IO,可以用来M101 M103
2.只能在非前瞻模式下使用
M101
G01 X10.15 Y10.22 Z-1.5 F20
G01 X9 Y10 Z-9 F20
G01 X130 Y100 Z-15 F20
G01 X150 Y0 Z-5 F15
M103
G01 X0 Y0 Z0 F20
M101
G01 X10.15 Y10.22 Z-1.5 F20
G01 X9 Y10 Z-9 F20
M103
---
	2020.04.1  添加的工件坐标模式，原有gcode需要切换成工件模式
smc_set_homemode /smc_set_pulse_outmode 先需要通过原点模式+脉冲模式+固件参数，设置好设备的坐标系。
先建好坐标系和方向。
Dist[0] = gcodeParameter["X"] + DistWork[0];    //添加工件坐标偏置
工件坐标系，直接在发送坐标然后再加偏置。不要改变方向。
smc_set_softlimit_unit 再添加软限位
M101
G01 X-90.22 Y-90.22 Z1.5 F20
G01 X-95 Y-95 F20
G01 X30 Y0 Z15 F20
G01 X50 Z5 F15
M103
G01 X-100 Y-100 Z0 F20
M101
G01 X-90.15 Y-90.22 Z1.5 F20
G01 X-99 Y-99 Z9 F20
M103

---
G01 X10 Y10 Z10 F10
G01 Y22 Z13 F12		//暂时不知道为啥会跟软限位冲突
