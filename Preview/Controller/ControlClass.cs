using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Globalization;

namespace Preview
{
    class ControlClass
    {
        private Relay relay1;
        private Relay relay2;
        public Camera camera;
        private MotorController motorController;

        public ControlClass()
        {
            //读取App.config中的appSettings
            var reader=new AppSettingsReader();

            string relay1ComName = (string)reader.GetValue("Relay1ComName", typeof(string));
            byte relay1Address = (byte)(reader.GetValue("Relay1Address", typeof(byte)));
            relay1=new Relay(relay1ComName,relay1Address);
            relay2=new Relay((string)reader.GetValue("Relay2ComName", typeof(string)),
                (byte)reader.GetValue("Relay2Address", typeof(byte)));

            uint baudRate = (uint) reader.GetValue("BaudRate", typeof(uint));
            uint byteSize = (uint) reader.GetValue("ByteSize", typeof(uint));
            uint parity = (uint) reader.GetValue("Parity", typeof(uint));
            uint stopBits = (uint) reader.GetValue("StopBits", typeof(uint));
            uint motorCOMID = uint.Parse((string)reader.GetValue("COMID", typeof(string)));

            motorController=new MotorController(baudRate,byteSize,parity,stopBits,motorCOMID);
        }

        public void StartCalibrate()
        {

        }





    }



    public enum PowerMode
    {
        Low,Medium,High
    }
}
