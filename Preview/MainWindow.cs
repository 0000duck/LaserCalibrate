using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using cszmcaux;

namespace Preview
{
    public partial class MainWindow : Form
    {
        private DVRLoginInfo CamLeftLoginInfo;
        private DVRLoginInfo CamRightLoginInfo;

        private VideoCapture videoCapture;
        private ImageX imageX;
        private Controller controller;
        private Relay relayA;
        private Relay relayB;
        private Point centerPoint;



        private int axis;//动作轴

        public MainWindow()
        {
            InitializeComponent();
            CamLeftLoginInfo = new DVRLoginInfo
            {
                DVRIPAddress = "192.168.1.55",
                DVRPassword = "123123",
                DVRPortNumber = 80,
                DVRUserName = "Li"
            };

            CamRightLoginInfo = new DVRLoginInfo
            {
                DVRIPAddress = "192.168.1.54",
                DVRPassword = "123123",
                DVRPortNumber = 80,
                DVRUserName = "Li"
            };

            videoCapture =new VideoCapture(CamLeftLoginInfo,CamRightLoginInfo);
            controller=new Controller();

            relayA=new Relay("COM1",0x00);
            relayB=new Relay("COM1",0x01);
            RelayAButton.Text = relayA.IsOpen ? "开" : "关";
            RelayBButton.Text = relayA.IsOpen ? "开" : "关";

            centerPoint=new Point(50,50);

        }

        private void PreviewButton_Click(object sender, EventArgs e)
        {
            videoCapture.StartPreview(RealPlayWnd1.Handle,RealPlayWnd2.Handle);
            var bitmaps = videoCapture.BitMapPicture;
            imageX=new ImageX(bitmaps.leftBitmap,bitmaps.rightBitmap,centerPoint);
        }

        private void StopPreview_Click(object sender, EventArgs e)
        {
            videoCapture.StopPreview();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender , EventArgs e)
        {
            if (relayA.IsOpen)
            {
                relayA.TurnOff();
            }
            else
            {
                relayA.TurnOn();
            }

            ((Button)sender).Text = relayA.IsOpen ? "开" : "关";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (relayB.IsOpen)
            {
                relayB.TurnOff();
            }
            else
            {
                relayB.TurnOn();
            }

            ((Button)sender).Text = relayB.IsOpen ? "开" : "关";
        }

        private void AutoMove_Click(object sender, EventArgs e)
        {
            if (videoCapture.IsPreviewing)
            {
                //TODO:自动校准
            }
            else
            {
                MessageBox.Show("请先开始预览画面","错误");
            }
        }

        private void StopMoveButton_Click(object sender, EventArgs e)
        {
            controller.StopMove();
        }

        private void StartMoveButton_Click(object sender, EventArgs e)
        {
            int axis=0;
            if (xAxis.Checked)
            {
                axis = 0;
            }
            else if (yAxis.Checked)
            {
                axis = 1;
            }
            else if (zAxis.Checked)
            {
                axis = 2;
            }
            else if (rAxis.Checked)
            {
                axis = 3;
            }
            try
            {
                float angle = float.Parse(Angle.Text);
                controller.SingleAxisMove(axis, angle);
            }
            catch (FormatException)
            {
                MessageBox.Show("输入字符串不合法（实例：顺时针0.53°:+0.53）", "错误");
                return;
            }

        }
    }

}
