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
    public class Controller
    {
        private IntPtr GHandle;
        public uint BaudRate { get; set; }
        public uint ByteSize { get; set; }
        public uint Parity { get; set; }
        public uint StopBits { get; set; }
        public uint Comid { get; set; }
        public uint StartSpeed { get; set; }
        public uint FinalSpeed { get; set; }
        public uint Acceleration { get; set; }
        public uint Deceleration { get; set; }
        public uint Stramp { get; set; }

        private float PulsePerAngle { get; set; }

        /// <summary>
        /// 构造函数，将属性设为默认值
        /// </summary>
        public Controller()
        {
            BaudRate = 38400;
            ByteSize = 8;
            Parity = 0;
            StopBits = 1;
            Comid = 1;
            StartSpeed = 1000;
            FinalSpeed = 1000;
            Acceleration = 0;
            Deceleration = 1000;
            Stramp = 0;
            PulsePerAngle = 90 * 25000 / 1.8f;
        }
        /// <summary>
        /// 设置脉冲当量与镜片角度转换的参数
        /// </summary>
        /// <param name="parameter"></param>
        public void SetPulse2AngleParameter(int parameter)
        {
            this.PulsePerAngle = 90 * parameter / 1.8f;
        }
        /// <summary>
        /// 链接控制器,并将类中的属性设为函数的参数
        /// </summary>
        /// <returns>链接成功返回True，否则返回False</returns>
        public bool OpenCom(uint baudRate, uint byteSize, uint parity, uint stopBits)
        {
            this.BaudRate = baudRate;
            this.ByteSize = byteSize;
            this.Parity = parity;
            this.StopBits = stopBits;
            zmcaux.ZAux_SetComDefaultBaud(this.BaudRate, this.ByteSize, this.Parity, this.StopBits);
            zmcaux.ZAux_OpenCom(this.Comid, out this.GHandle);
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
        /// 以默认属性为参数链接控制器
        /// </summary>
        /// <returns>链接成功返回True，否则返回False</returns>
        public bool OpenCom()
        {
            zmcaux.ZAux_SetComDefaultBaud(this.BaudRate, this.ByteSize, this.Parity, this.StopBits);
            zmcaux.ZAux_OpenCom(this.Comid, out this.GHandle);
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
        /// 使四个轴各偏转ArrayList提供的四个角度
        /// </summary>
        /// <param name="AngleList">提供四个Float类型的参数，四个参数与四个轴对应</param>
        /// <returns>成功转动返回True，否则返回False</returns>
        public bool AxisMove(ArrayList AngleList)
        {

            if (this.GHandle == IntPtr.Zero)
            {
                return false;
            }
            float[] Angle = new float[4];
            AngleList.CopyTo(Angle);
            //设置轴参数并转动
            for (int i = 0; i < 4; i++)
            {
                zmcaux.ZAux_Direct_SetAtype(this.GHandle, i, 1);
                zmcaux.ZAux_Direct_SetUnits(this.GHandle, i, Math.Abs(Angle[i]) * this.PulsePerAngle);
                zmcaux.ZAux_Direct_SetLspeed(this.GHandle, i, this.StartSpeed);
                zmcaux.ZAux_Direct_SetSpeed(this.GHandle, i, this.FinalSpeed);
                zmcaux.ZAux_Direct_SetAccel(this.GHandle, i, this.Acceleration);
                zmcaux.ZAux_Direct_SetDecel(this.GHandle, i, this.Deceleration);
                zmcaux.ZAux_Direct_SetSramp(this.GHandle, i, this.Stramp);
                if (Angle[i] >= 0)
                    zmcaux.ZAux_Direct_Singl_Vmove(GHandle, i, 1);
                else
                    zmcaux.ZAux_Direct_Singl_Vmove(GHandle, i, -1);
            }
            return true;
        }
        /// <summary>
        /// 指定单轴转动某一角度
        /// </summary>
        /// <param name="AxisID">轴号</param>
        /// <param name="Angle">角度，正负表方向</param>
        /// <returns></returns>
        public bool SingleAxisMove(int AxisID, float Angle)
        {
            if (this.GHandle == IntPtr.Zero)
            {
                return false;
            }
            zmcaux.ZAux_Direct_SetAtype(this.GHandle, AxisID, 1);
            zmcaux.ZAux_Direct_SetUnits(this.GHandle, AxisID, Math.Abs(Angle) * this.PulsePerAngle);
            zmcaux.ZAux_Direct_SetLspeed(this.GHandle, AxisID, this.StartSpeed);
            zmcaux.ZAux_Direct_SetSpeed(this.GHandle, AxisID, this.FinalSpeed);
            zmcaux.ZAux_Direct_SetAccel(this.GHandle, AxisID, this.Acceleration);
            zmcaux.ZAux_Direct_SetDecel(this.GHandle, AxisID, this.Deceleration);
            zmcaux.ZAux_Direct_SetSramp(this.GHandle, AxisID, this.Stramp);
            if (Angle >= 0)
                zmcaux.ZAux_Direct_Singl_Vmove(GHandle, AxisID, 1);
            else
                zmcaux.ZAux_Direct_Singl_Vmove(GHandle, AxisID, -1);
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
            zmcaux.ZAux_Close(this.GHandle);
        }
    }

}

