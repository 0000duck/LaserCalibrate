using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preview
{
    class Relay
    {
        private static SerialPort _comm = new SerialPort();//继电器串口 所有继电器共用此串口
        private byte[] open = { 0xAA, 0x00, 0x02, 0x01, 0xBB };//打开命令
        private byte[] close = { 0xAA, 0x00, 0x03, 0x01, 0xBB };//关闭命令

        public bool IsOpen = false;

        /// <summary>
        /// 继电器构造函数
        /// </summary>
        /// <param name="comName">串口名</param>
        /// <param name="address">继电器地址 可以为0x00 0x01 等</param>
        public Relay(string comName,byte address)
        {
            if(!_comm.IsOpen)
                OpenSerialPort(comName);
            open[1] = address;
        }
        /// <summary>
        /// 打开开关
        /// </summary>
        public void TurnOn()
        {
            if (_comm.IsOpen)
            {
                _comm.Write(open, 0, open.Length);
            }
            IsOpen = true;
        }
        /// <summary>
        /// 关闭
        /// </summary>
        public void TurnOff()
        {
            if (_comm.IsOpen)
            {
                _comm.Write(close, 0, close.Length);
            }
            IsOpen = false;
        }


        /// <summary>
        /// 打开串口
        /// </summary>
        private void OpenSerialPort(string comName)
        {

            //关闭时点击，则设置好端口，波特率后打开

            _comm.PortName = comName; //串口名 COM
            _comm.BaudRate = 9600; //波特率  9600
            _comm.DataBits = 8; // 数据位 8
            _comm.ReadBufferSize = 4096;
            _comm.StopBits = StopBits.One;
            _comm.Parity = Parity.None;
            _comm.Open();

        }

        private void CloseSerialPort()
        {
            if(_comm.IsOpen)
                _comm.Close();
        }

        ~Relay() => CloseSerialPort();

    }
}
