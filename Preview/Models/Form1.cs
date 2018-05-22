using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Preview;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
            var i = 0;
            Pen pen = new Pen(Color.Blue, 3);
            DVRLoginInfo dvrLoginInfo = new DVRLoginInfo()
            {
                DVRIPAddress = "192.168.1.65",
                DVRPortNumber = 8000,
                DVRPassword = "li123123",
                DVRUserName = "admin"


            };
            
            VideoCapture videoCapture = new VideoCapture(dvrLoginInfo,dvrLoginInfo);
            videoCapture.Login();
            videoCapture.StartPreview(pictureBox1, pictureBox1);
            

            timer1.Tick += (s, arg) =>
            {
                videoCapture.CaptureBMP();
                
               // Random r=new Random();
                //r.Next(0, 200);
                int x = 960;
                int y = 540;
                videoCapture.DrawImage(x,y);


                //Point[] points =
                //{
                //    new Point(0, 50),
                //    new Point(200, 50),
                //    new Point(100, 50),
                //    new Point(100, 0),
                //    new Point(100,130), 
                //};


                //Graphics grfx = pictureBox1.CreateGraphics();
                //grfx.DrawLines(pen,points);
                //grfx.Dispose();
              
            };
         
            timer1.Interval = 30;
            timer1.Start();

        }



        private void button1_Click(object sender, EventArgs e)
        {
            DVRLoginInfo dvrLoginInfo = new DVRLoginInfo()
            {
                DVRIPAddress = "192.168.1.65",
                DVRPortNumber = 8000,
                DVRPassword = "li123123",
                DVRUserName = "admin"


            };
            VideoCapture videoCapture = new VideoCapture(dvrLoginInfo, dvrLoginInfo);
            videoCapture.Login();
            videoCapture.PlayBack();


        }
    }
}
