using IMedToolCommon;
using IMedToolCommon.Config;
using MachineControlSystem.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineControlSystem.Gcode.TypeB
{
    /// <summary>
    /// 三轴插补
    /// </summary>
    public class G1 : Gcode
    {
        /// <summary>
        /// G1构造函数
        /// </summary>
        public G1() : base()
        {
            IsCachedGcode = true;
        }
        /// <summary>
        /// 指令执行
        /// </summary>
        public override void Execute()
        {
            base.Execute();
            Status = GcodeExecuteStatus.Executing;
            AxisPosition destinaPosition = new AxisPosition();
            AxisPosition currentCoordinateSystem = new AxisPosition(); ;
            TypeBConfigModel configModel = (TypeBConfigModel)MachineConfig.GetInstance().Model;
            AxisPosition directionVector = configModel.DirectionVector;
            AxisPosition platFormCenter = configModel.PlatFormCenter.Clone() * directionVector.Clone();
            AxisPosition2D offset = new AxisPosition2D();

            offset.X = MachineControlSystem.CurrentNozzleIndex.Count !=0 ? configModel.NozzleList.FirstOrDefault(a => a.ID == MachineControlSystem.CurrentNozzleIndex[0]).NozzleOffset.X:0;
            offset.Y = MachineControlSystem.CurrentNozzleIndex.Count != 0 ? configModel.NozzleList.FirstOrDefault(a => a.ID == MachineControlSystem.CurrentNozzleIndex[0]).NozzleOffset.Y:0;
            if (MachineControlSystem.IsAbs)
            {
                currentCoordinateSystem = MachineControlSystem.GetCurrentCoordinateSystem();
                destinaPosition = destinaPosition + MachineControlSystem.LastDistance;
            }

            if (Paramters.ContainsKey("X"))
            {
                destinaPosition.X = Paramters.First(x => x.Key == "X").Value * directionVector.X;
            }
            else if (MachineControlSystem.IsAbs)
            {
                currentCoordinateSystem.X = 0;
            }

            if (Paramters.ContainsKey("Y"))
            {
                destinaPosition.Y = Paramters.First(x => x.Key == "Y").Value * directionVector.Y;
            }
            else if (MachineControlSystem.IsAbs)
            {
                currentCoordinateSystem.Y = 0;
            }

            if (Paramters.ContainsKey("Z"))
            {
                destinaPosition.Z = Paramters.First(x => x.Key == "Z").Value * directionVector.Z;
            }
            else if (MachineControlSystem.IsAbs)
            {
                currentCoordinateSystem.Z = 0;
            }

            if (Paramters.ContainsKey("U"))
            {
                destinaPosition.U = Paramters.First(x => x.Key == "U").Value * directionVector.U;
                int temp=0;
                if (MachineControlSystem.LastDistance.U < 0)
                {
                    temp = (int)(MachineControlSystem.LastDistance.U / (360 * directionVector.U)) - 1;
                    if (temp < -1)
                    {
                        temp = -1;
                    }
                }
                else
                {
                    temp = (int)(MachineControlSystem.LastDistance.U / (360 * directionVector.U));
                    if (temp > 1)
                    {
                        temp = 1;
                    }
                }//不知道这段在算什么，为啥temp 只有了 1 -1 0

                double axis_A_Distancediff = MachineControlSystem.LastDistance.U - temp * 360 * directionVector.U;  //换算为整圈绝对位置
                if (Math.Abs(axis_A_Distancediff - destinaPosition.U) == 180 * directionVector.U)   //目标刚好是180°
                {

                    destinaPosition.U = MachineControlSystem.LastDistance.U + 180 * directionVector.U; 
                }   
                else if (axis_A_Distancediff == destinaPosition.U) //判断是
                {
                    
                    destinaPosition.U = MachineControlSystem.LastDistance.U;
                }
                else if (destinaPosition.U - axis_A_Distancediff < 0 && destinaPosition.U - axis_A_Distancediff < -180 * directionVector.U) // 目标值变小 & *差值*＜180
                {

                    destinaPosition.U += 360 * directionVector.U * (temp + 1);
                }
                else if (destinaPosition.U - axis_A_Distancediff < 0 && destinaPosition.U - axis_A_Distancediff > -180 * directionVector.U) // 目标值变小 & *差值*大于180 
                {

                    destinaPosition.U += 360 * directionVector.U * temp;
                }
                else if (destinaPosition.U - axis_A_Distancediff > 0 && destinaPosition.U - axis_A_Distancediff > 180 * directionVector.U) ////判断是否是  -180<**＜0 
                {

                    destinaPosition.U += 360 * directionVector.U * (temp - 1);
                }
                else if (destinaPosition.U - axis_A_Distancediff > 0 && destinaPosition.U - axis_A_Distancediff < 180 * directionVector.U) ////判断是否是  -180<**＜0 
                {

                    destinaPosition.U += 360 * directionVector.U * temp;
                }
                else
                {
                    destinaPosition.U = MachineControlSystem.LastDistance.U;
                }
            }
            else if (MachineControlSystem.IsAbs)
            {
                currentCoordinateSystem.U = 0;
            }

            if (MachineControlSystem.IsAbs)
            {
                destinaPosition += (currentCoordinateSystem * directionVector);
                if (destinaPosition.Z < 0)
                {
                    destinaPosition.Z = 0;
                }
            }

            while (!isNeedStop)
            {
                if (MachineControlSystem.CouldSendGcode())
                {
                    float speed;
                    if (MachineControlSystem.SpeedMode == ControlMode.Auto)
                    {
                        if (Paramters.ContainsKey("F"))
                        {
                            speed = Paramters.First(x => x.Key == "F").Value;
                        }
                        else
                        {
                            speed = 10.0f;
                        }
                    }
                    else
                    {
                        speed = MachineControlSystem.ManualSpeed;
                    }

                    if (speed > Math.Min(Math.Min(MachineConfig.GetInstance().Model.MaxSpeed.X, MachineConfig.GetInstance().Model.MaxSpeed.Y), MachineConfig.GetInstance().Model.MaxSpeed.Z))
                    {
                        throw new IMedToolException(ErrorCode.E3049, this.GcodeToString);
                    }

                    if (MachineControlSystem.IsAbs)
                    {
                        float minX = platFormCenter.X + configModel.PrintBoundary.MinBoundary.X - offset.X;
                        float maxX = platFormCenter.X + configModel.PrintBoundary.MaxBoundary.X - offset.X;
                        float minY = platFormCenter.Y + configModel.PrintBoundary.MinBoundary.Y - offset.Y;
                        float maxY = platFormCenter.Y + configModel.PrintBoundary.MaxBoundary.Y - offset.Y;
                        float minZ = 0;
                        float maxZ = MachineControlSystem.GetCurrentCoordinateSystem().Z * directionVector.Z;
                        if (destinaPosition.X < minX
                        || destinaPosition.X > maxX
                        || destinaPosition.Y < minY
                        || destinaPosition.Y > maxY
                        || destinaPosition.Z < minZ
                        || destinaPosition.Z > maxZ
                        )
                            {
                                string s = string.Format("目标点为({0},{1},{2}), 可打印区域为：X({3}, {4}), Y({5}, {6}), Z({7}, {8})", 
                                destinaPosition.X* directionVector.X,
                                destinaPosition.Y * directionVector.Y,
                                destinaPosition.Z * directionVector.Z,
                                Math.Min(minX * directionVector.X, maxX * directionVector.X),
                                Math.Max(minX * directionVector.X, maxX * directionVector.X),
                                Math.Min(minY * directionVector.Y, maxY * directionVector.Y),
                                Math.Max(minY * directionVector.Y, maxY * directionVector.Y),
                                Math.Min(minZ * directionVector.Z, maxZ * directionVector.Z),
                                Math.Max(minZ * directionVector.Y, maxZ * directionVector.Z));

                                Status = GcodeExecuteStatus.Error;
                                throw new IMedToolException(ErrorCode.E5001, GcodeToString + "," + s, Level.Error);
                            }
                    }
                    else
                    {
                        float minX = platFormCenter.X + configModel.PrintBoundary.MinBoundary.X - offset.X;
                        float maxX = platFormCenter.X + configModel.PrintBoundary.MaxBoundary.X - offset.X;
                        float minY = platFormCenter.Y + configModel.PrintBoundary.MinBoundary.Y - offset.Y;
                        float maxY = platFormCenter.Y + configModel.PrintBoundary.MaxBoundary.Y - offset.Y;
                        float minZ = 0;
                        float maxZ = MachineControlSystem.GetCurrentCoordinateSystem().Z * directionVector.Z;
                        AxisPosition _destinaPosition = destinaPosition.Clone();
                        _destinaPosition = destinaPosition.Clone() + MachineControlSystem.LastDistance;
                        if (_destinaPosition.X < platFormCenter.X + configModel.PrintBoundary.MinBoundary.X - offset.X
                        || _destinaPosition.X > platFormCenter.X + configModel.PrintBoundary.MaxBoundary.X - offset.X
                        || _destinaPosition.Y < platFormCenter.Y + configModel.PrintBoundary.MinBoundary.Y - offset.Y
                        || _destinaPosition.Y > platFormCenter.Y + configModel.PrintBoundary.MaxBoundary.Y - offset.Y
                        || _destinaPosition.Z < 0 + configModel.PrintBoundary.MinBoundary.Z
                        || _destinaPosition.Z > MachineControlSystem.GetCurrentCoordinateSystem().Z * directionVector.Z +configModel.PrintBoundary.MaxBoundary.Z
                        )
                        {
                            string s = string.Format("目标点为({0},{1},{2}), 可打印区域为：X({3}, {4}), Y({5}, {6}), Z({7}, {8})",
                                 destinaPosition.X * directionVector.X,
                                 destinaPosition.Y * directionVector.Y,
                                 destinaPosition.Z * directionVector.Z,
                                 Math.Min(minX * directionVector.X, maxX * directionVector.X),
                                 Math.Max(minX * directionVector.X, maxX * directionVector.X),
                                 Math.Min(minY * directionVector.Y, maxY * directionVector.Y),
                                 Math.Max(minY * directionVector.Y, maxY * directionVector.Y),
                                 Math.Min(minZ * directionVector.Z, maxZ * directionVector.Z),
                                 Math.Max(minZ * directionVector.Y, maxZ * directionVector.Z));

                            Status = GcodeExecuteStatus.Error;
                            throw new IMedToolException(ErrorCode.E5001, GcodeToString + "," + s, Level.Error);
                        }
                    }
                        MachineControlSystem.VectMoveLineN(destinaPosition, speed, MachineControlSystem.IsAbs);
                        double vectLength = MachineControlSystem.VectLength + Math.Sqrt(Math.Pow(destinaPosition.X - MachineControlSystem.LastDistance.X, 2) +
                    Math.Pow(destinaPosition.Y - MachineControlSystem.LastDistance.Y, 2) +
                    Math.Pow(destinaPosition.Z - MachineControlSystem.LastDistance.Z, 2));
                        if (MachineControlSystem.IsAbs)
                        {
                            MachineControlSystem.LastDistance = destinaPosition;
                        }
                        else
                        {
                            MachineControlSystem.LastDistance = destinaPosition + MachineControlSystem.LastDistance;
                        }
                        MachineControlSystem.VectLength = vectLength;
                   
                    Status = GcodeExecuteStatus.Finished;
                    return;
                }
            }
            Status = GcodeExecuteStatus.Stoped;
        }



    }
}
