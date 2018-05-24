using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using cszmcaux;

namespace Preview
{
    public class MotorController
    {
        private IntPtr GHandle;
        private uint _baudRate;
        private uint _byteSize;
        private uint _parity;
        private uint _stopBits;
        private uint _comid;
        private readonly uint StartSpeed = 1000;
        private readonly uint FinalSpeed = 1000;
        private readonly uint Acceleration = 1000;
        private readonly uint Deceleration = 1000;
        private readonly uint Stramp = 0;

        private float PulsePerAngle { get; set; } //单位度/脉冲

        /// <summary>
        /// 构造函数，将属性设为默认值
        /// </summary>
        public MotorController(uint baudRate, uint byteSize, uint parity,
            uint stopBits, uint comid)
        {
            _baudRate = baudRate;
            _byteSize = byteSize;
            _parity = parity;
            _stopBits = stopBits;
            _comid = comid;
            PulsePerAngle = 90 * 256 / 1.8f; //根据公式获得 与电机细分度和其他参数有关
            //设置轴运动参数
            for (int i = 0; i < 4; i++)
            {
                zmcaux.ZAux_Direct_SetAtype(this.GHandle, i, 1);
                zmcaux.ZAux_Direct_SetUnits(this.GHandle, i, 1);
                zmcaux.ZAux_Direct_SetLspeed(this.GHandle, i, this.StartSpeed);
                zmcaux.ZAux_Direct_SetSpeed(this.GHandle, i, this.FinalSpeed);
                zmcaux.ZAux_Direct_SetAccel(this.GHandle, i, this.Acceleration);
                zmcaux.ZAux_Direct_SetDecel(this.GHandle, i, this.Deceleration);
                zmcaux.ZAux_Direct_SetSramp(this.GHandle, i, this.Stramp);

            }
        }

        /// <summary>
        /// 链接控制器,并将类中的属性设为函数的参数
        /// </summary>
        /// <returns>链接成功返回True，否则返回False</returns>
        public bool OpenCom()
        {
            zmcaux.ZAux_SetComDefaultBaud(_baudRate, _byteSize, _parity, _stopBits);
            zmcaux.ZAux_OpenCom(_comid, out GHandle);
            if (GHandle != IntPtr.Zero)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 使四个轴各偏转数组提供的四个角度
        /// </summary>
        /// <param name="angleList">提供四个Float类型的参数，四个参数与四个轴对应顺序为x,y,z,r</param>
        /// <returns>成功转动返回True，否则返回False</returns>
        public void AxisMove(float[] angleList)
        {

            if (this.GHandle == IntPtr.Zero)
            {
                throw new ControllerException();
            }
            //设置轴参数并转动
            for (int i = 0; i < 4; i++)
            {

                zmcaux.ZAux_Direct_Singl_Move(GHandle, i, angleList[i] * PulsePerAngle);

            }
        }

        /// <summary>
        /// 指定单轴转动某一角度
        /// </summary>
        /// <param name="axisID">轴号</param>
        /// <param name="angle">角度，正负表方向</param>
        /// <returns></returns>
        public bool SingleAxisMove(int axisID, float angle)
        {
            if (this.GHandle == IntPtr.Zero)
            {
                return false;
            }
            zmcaux.ZAux_Direct_Singl_Move(GHandle, axisID, angle * PulsePerAngle);
            return true;
        }

        /// <summary>
        /// 所有轴停止运动
        /// </summary>
        /// <returns>轴停止返回True，否则返回False</returns>
        public bool StopMove()
        {
            if (this.GHandle == IntPtr.Zero)
            {
                return false;
            }
            for (int i = 0; i < 4; i++)
            {
                zmcaux.ZAux_Direct_Singl_Cancel(this.GHandle, i, 2);
            }
            return true;
        }

        /// <summary>
        /// 断开链接
        /// </summary>
        public void CloseCom()
        {
            if (GHandle == IntPtr.Zero)
                zmcaux.ZAux_Close(this.GHandle);
        }

        ~MotorController() => CloseCom();
    
    }

    public class ControllerException : Exception
    {
        public ControllerException():base()
        {
            
        }
    }

}

