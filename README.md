# SMC_600Test

LEADSHINE SMC600 
默认连接IP 192.168.1.77
5axis test

*********** 2019.12.05
X/Y轴脉冲当量 1600pluse/unit  
导程4mm ；驱动32细分 ；57步进电机 200pluse/r
Z轴脉冲当量	1280pluse/unit
导程5mm ；驱动32细分 ；57步进电机 200pluse/r
1 unit = 1mm

X/Y轴脉冲模式  2, PUL+ DIR- 高脉冲/低方向

机械找零时候如何 停止

*********** 2019.12.06
单条直线插补指令，smc_line_unit，不能连续使用。必须一条执行完毕后，再发送吓一调。
连续插补函数，可以缓冲执行。
smc_conti_open_list（）；
smc_conti_start_list（）；
smc_conti_line_unit();
最多可缓冲 5000行，通过smc_conti_remain_space(_ConnectNo, 0)可查。
