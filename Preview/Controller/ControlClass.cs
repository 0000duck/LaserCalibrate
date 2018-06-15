using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Preview
{
    class ControlClass
    {
        private static ControlClass _control;
        public Relay Relay1;
        public Relay Relay2;
        public VideoCapture videoCap;
        public MotorController motorController;
        public ImageX imageX;

        public Point center;

        public static ControlClass GetInstance()
        {
            return _control ?? (_control = new ControlClass());
        }

        private ControlClass()
        {
            //读取App.config文件中的appSettings
            //所有相关组件的配置都写在appSetting中
            var reader=new AppSettingsReader();

            //初始化继电器
            string relay1ComName = (string)reader.GetValue("Relay1ComName", typeof(string));
            byte relay1Address = (byte)(reader.GetValue("Relay1Address", typeof(byte)));

            Relay1 = new Relay(relay1ComName, relay1Address);
            Relay2 = new Relay((string)reader.GetValue("Relay2ComName", typeof(string)),
                (byte)reader.GetValue("Relay2Address", typeof(byte)));
            //初始化控制器
            uint baudRate = (uint)reader.GetValue("BaudRate", typeof(uint));
            uint byteSize = (uint)reader.GetValue("ByteSize", typeof(uint));
            uint parity = (uint)reader.GetValue("Parity", typeof(uint));
            uint stopBits = (uint)reader.GetValue("StopBits", typeof(uint));
            uint motorCOMID = uint.Parse((string)reader.GetValue("COMID", typeof(string)));
            

            motorController = new MotorController(baudRate, byteSize, parity, stopBits, motorCOMID);
            //motorController.OpenCom();
            //初始化摄像头
            DVRLoginInfo leftLoginInfo = new DVRLoginInfo()
            {
                DVRIPAddress = (string)reader.GetValue("LeftCamIP", typeof(string)),
                DVRPortNumber = (short)reader.GetValue("LeftCamPort", typeof(short)),
                DVRUserName = (string) reader.GetValue("LeftCamUsername",typeof(string)),
                DVRPassword = (string)reader.GetValue("LeftCamPassword", typeof(string))
            };
            
            DVRLoginInfo rightDvrLoginInfo=new DVRLoginInfo()
            {
                DVRIPAddress = (string)reader.GetValue("RightCamIP", typeof(string)),
                DVRPortNumber = (short)reader.GetValue("RightCamPort", typeof(short)),
                DVRUserName = (string)reader.GetValue("RightCamUsername", typeof(string)),
                DVRPassword = (string)reader.GetValue("RightCamPassword", typeof(string))
            };
            
            videoCap=new VideoCapture(leftLoginInfo,rightDvrLoginInfo);
            videoCap.Login();
            //中心坐标
            int x = (int) reader.GetValue("X", typeof(int));
            int y = (int) reader.GetValue("Y", typeof(int));
            center=new Point(960,540);
        }

        public void StartPreview(PictureBox leftPictureBox,PictureBox rightPictureBox)
        {
            videoCap.StartPreview(leftPictureBox,rightPictureBox);
            videoCap.CaptureBMPpreview();
            imageX=new ImageX(videoCap.PreviewImage[0],
                videoCap.PreviewImage[1],
                center);

        }

        /// <summary>
        /// 更新图像
        /// 在窗体绘制十字光标
        /// </summary>
        public void DrawCross()
        {
            //捕获图像
            videoCap.CaptureBMPpreview();
            //处理图像
            imageX.Load_Bitmap(videoCap.PreviewImage[0],videoCap.PreviewImage[1]);
            //绘制十字
            videoCap.NewdrawOnpreview((int)imageX.ShapeCenterX,(int)imageX.ShapeCenterY,
                center.X,center.Y, (int)imageX.ShapeCenterX, (int)imageX.ShapeCenterY,
                center.X, center.Y);
        }

        public void StopPreview()
        {
            videoCap.StopPreview();

        }
        /// <summary>
        /// 启动自动校准
        /// </summary>
        public void Calibrate()
        {
            //首先获取图像
            videoCap.CaptureBMPpreview();
            //获取偏移角度（计算旋转角度）
            imageX.Load_Bitmap(videoCap.PreviewImage[0],videoCap.PreviewImage[1]);
            //控制器运动
            motorController.AxisMove((float)imageX.Delta_Theta1, (float)imageX.Delta_Fai1, (float)imageX.Delta_Theta2, (float)imageX.Delta_Fai2 );
        }

        

    }
    


    public enum PowerMode
    {
        Low,Medium,High
    }
}
