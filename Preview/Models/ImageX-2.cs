using System;
using System.Collections;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;


namespace Preview
{
    class ImageX
    {
        private double f = 350;//光学系统1和2的组合焦距mm
        private double l1= 270;//面阵探测器1距离入射激光的光程mm
        private double l = 270;//两伺服反射镜的中心距离mm
        private double a = 2.7e-3;//探测器相元尺寸mm
        private double F = 14;//光学系统垂轴放大率倒数

        private double Error = 1.0 / 3600;

        private Image<Bgr, Byte> image12;
        private Image<Bgr, Byte> image22;

        public Point BaseCenter;
        /*
        public static void Main()
        {
            Bitmap t1 = new Bitmap("C:\\Users\\apple\\Desktop\\test\\456\\80.jpg");
            Bitmap t2 = new Bitmap("C:\\Users\\apple\\Desktop\\test\\123\\350.jpg");
            Bitmap bl = new Bitmap(t1.Width, t1.Height);
            Bitmap br = new Bitmap(t2.Width, t2.Height);

            Point center = new Point(0, 0);
            //Point center2 = new Point(t2.Width / 2, t2.Height / 2);
        
            ImageX px = new ImageX(bl, br ,center);

            Point c = new Point(t1.Width/2, t1.Height/2);

            ArrayList a = new ArrayList();

            CvInvoke.NamedWindow("SHOW", NamedWindowType.KeepRatio);

            px.Detect_Angle(t1, t2, ref a);

            bool ss = px.Is_Aligned(t1,t2);

            Bitmap pi = px.Add_Cross(t1, 1);

            CvInvoke.Imshow("SHOW", new Image<Bgr, Byte>(pi));

            CvInvoke.WaitKey();
        }
        */

        
        public ImageX(Bitmap BaseLeft, Bitmap BaseRight, Point basecenter)//左背景图，右背景图，基准点(相对于图片中心)
        {
            image12 = new Image<Bgr, Byte>(BaseLeft);
            image22 = new Image<Bgr, Byte>(BaseRight);
            BaseCenter = basecenter;
        }
        //**************************************************************//
        //函数名称：Is_Aligned
        //函数作用：判断是否校准成功
        //参数：       Bitmap Light_Image_Left//左摄像头光斑图
        //                 Bitmap Light_Image_Right//右摄像头光斑图  
        //**************************************************************//
        public bool Is_Aligned(Bitmap Light_Image_Left, Bitmap Light_Image_Right)
        {
            ArrayList angle = new ArrayList();

            Image<Bgr, Byte> image11 = new Image<Bgr, Byte>(Light_Image_Left);
            //Image<Bgr, Byte> image12 = new Image<Bgr, Byte>(BaseLeft);
            Image<Bgr, Byte> image21 = new Image<Bgr, Byte>(Light_Image_Right);
            // Image<Bgr, Byte> image22 = new Image<Bgr, Byte>(BaseRight);

            Image<Gray, Byte> light_image1 = image11.Convert<Gray, Byte>();
            Image<Gray, Byte> back_image1 = image12.Convert<Gray, Byte>();
            Image<Gray, Byte> light_image2 = image21.Convert<Gray, Byte>();
            Image<Gray, Byte> back_image2 = image22.Convert<Gray, Byte>();

            ArrayList centers1 = new ArrayList();
            ArrayList centers2 = new ArrayList();

            Detect_Center_Point(light_image1, back_image1, ref centers1);//获取摄像头1的形心和质心
            Detect_Center_Point(light_image2, back_image2, ref centers2);//获取摄像头2的形心和质心

            Delta_Angle(centers1, centers2, ref angle);

            if((double)angle[0]<Error&& (double)angle[1] < Error&& (double)angle[2] < Error&& (double)angle[3] < Error)
            {
                return true;
            }
            else
                return false;
        }
        //**************************************************************//
        // 函数名称：Detect_Center_Point
        // 函数作用：接受一张光斑图和一张背景图，输出形心和质心坐标
        // 函数参数:   Image<Gray,Byte> light_image:  光斑图
        //                  Image<Gray, Byte> base_image：背景图
        //                  ref ArrayList list： 形心和质心坐标，分别为形心x，形心y，质心x，质心y，相对于图像中心
        //**************************************************************//
        public void Detect_Center_Point(Image<Gray,Byte> light_image, Image<Gray, Byte> base_image, ref ArrayList list)//参数：光斑图片，存储偏移的list，背景图片
        {
            Image<Gray, Byte> original_image = light_image;
            Image<Gray, Byte> background_image = base_image;

            Image<Gray, Byte> unback_image = light_image.AbsDiff(base_image);
            Image<Gray, Byte> blured_image = new Image<Gray, Byte>(CvInvoke.cvGetSize(unback_image));
            CvInvoke.Blur(unback_image, blured_image, new Size(7, 7), new Point(-1,-1));

            Int32 centerx = blured_image.Cols / 2;
            Int32 centery = blured_image.Rows / 2;

            double max_pix = 0;
            double min_pix = 0;
            int[] minlist = new int[100];
            int[] maxlist = new int[100];

            CvInvoke.MinMaxIdx(blured_image, out min_pix, out max_pix, minlist, maxlist);

            Image<Gray, Double> dimage = blured_image.ConvertScale<Double>(255 / (max_pix - min_pix), 0);

            CvInvoke.Threshold(dimage, dimage, 230, 255, ThresholdType.ToZero);

            CvInvoke.NamedWindow("Gray_Image", NamedWindowType.KeepRatio);
            CvInvoke.Imshow("Gray_Image", dimage);

            double scx = 0;
            double scy = 0;

            double mcx = 0;
            double mcy = 0;

            double sum = 0;

            int num = 0;

            for (int i = 0; i < dimage.Cols; i++)
            {
                for (int j = 0; j < dimage.Rows; j++)
                {
                    double tempg = dimage.Data[j,i,0];
                    if (tempg > 0)
                    {
                        scx += i;
                        scy += j;
                        num++;
                        mcx += tempg * i;
                        mcy += tempg * j;
                        sum += tempg;
                    }
                }
            }
            
            double x1 = scx / num - centerx;//形心x
            double y1 = scy / num - centery;//形心y
            double x2 = mcx / sum - centerx;//质心x
            double y2 = mcy / sum - centery;//质心y
            list.Add(x1);
            list.Add(y1);
            list.Add(x2);
            list.Add(y2);
        }
        //**************************************************************//
        // 函数名称：Delta_Angle
        // 函数作用：接受两个摄像头传来的参数，计算转动角度
        // 函数参数:    ArrayList Centers1：摄像头一的形心和质心坐标，分别为形心x，形心y，质心x，质心y
        //                   ArrayList Centers2：摄像头二的形心和质心坐标，分别为形心x，形心y，质心x，质心y
        //                   ref ArrayList Angle：计算得到的电机转动角度，分别为theta1，fai1，theta2，fai2
        //**************************************************************//
        public void Delta_Angle(ArrayList Centers1, ArrayList Centers2,   ref ArrayList Angle)//参数：图片一的四个中心，图片二的四个中心，输出角度，theta1，fai1，theta2，fai2
        {
            //获取探测器1的形心和质心
            double scenterx1 = (double)Centers1[0];
            double scentery1 = (double)Centers1[1];
            double mcenterx1 = (double)Centers1[2];
            double mcentery1 = (double)Centers1[3];

            //获取探测器2的形心和质心
            double scenterx2 = (double)Centers2[0];
            double scentery2 = (double)Centers2[1];
            double mcenterx2 = (double)Centers2[2];
            double mcentery2 = (double)Centers2[3];
        
            double delta_alpha = Math.Atan((mcenterx1 - BaseCenter.X) * a / f);//?
            double delta_beita = Math.Atan((mcentery1 - BaseCenter.Y) *  a / f);

            double delta_x = (mcenterx2 - BaseCenter.X) * a * F - l1 * Math.Tan(delta_alpha);//?
            double delta_y = (mcentery2 - BaseCenter.X) * a * F - l1 * Math.Tan(delta_beita);

            double delta_theta1 = (0.5 * delta_alpha + 0.5 * Math.Asin(delta_x/l)) * 180 / Math.PI;//镜1旋转角度
            double delta_fai1 = (0.5 * delta_beita + 0.5 * Math.Asin(delta_y/l)) * 180 / Math.PI;//镜1旋转角度
            double delta_theta2 = (0.5 * Math.Asin(delta_x / l)) * 180 / Math.PI;//镜3旋转角度
            double delta_fai2 = (0.5 * Math.Asin(delta_y / l)) * 180 / Math.PI;//镜4旋转角度

            Angle.Add(delta_theta1);
            Angle.Add(delta_fai1);
            Angle.Add(delta_theta2);
            Angle.Add(delta_fai2);
        }
        //**************************************************************//
        // 函数名称：Detect_Angle
        // 函数作用：接受摄像头一输入图像和摄像头二输入图像，和基准坐标点point，计算输出角度，返回图片
        //函数参数:    Image<Bgr, Byte> Light_Image_Left:摄像头1拍摄得到的图像,光斑图
        //                  Image<Bgr, Byte> Light_Image_Right:摄像头2拍摄得到的图像，光斑图
        //                  Point verti：自定义基准点的坐标，坐标相对于图像中心
        //                  ref ArrayList angle：输出电机应该转动的角度
        //                  String Window_Name：显示图像的命名窗体，用EmguCV.CV.CvInvoke.NamedWindow函数来创建
        //**************************************************************//
        public void Detect_Angle(Bitmap Light_Image_Left, Bitmap Light_Image_Right, ref ArrayList angle)
        {
            Image<Bgr, Byte> image11 = new Image<Bgr, Byte>(Light_Image_Left);
            //Image<Bgr, Byte> image12 = new Image<Bgr, Byte>(BaseLeft);
            Image<Bgr, Byte> image21 = new Image<Bgr, Byte>(Light_Image_Right);
            // Image<Bgr, Byte> image22 = new Image<Bgr, Byte>(BaseRight);

            Image<Gray, Byte> light_image1 = image11.Convert<Gray, Byte>();
            Image<Gray, Byte> back_image1 = image12.Convert<Gray, Byte>();
            Image<Gray, Byte> light_image2 = image21.Convert<Gray, Byte>();
            Image<Gray, Byte> back_image2 = image22.Convert<Gray, Byte>();

            ArrayList centers1 = new ArrayList();
            ArrayList centers2 = new ArrayList();

            Detect_Center_Point(light_image1, back_image1, ref centers1);//获取摄像头1的形心和质心
            Detect_Center_Point(light_image2, back_image2, ref centers2);//获取摄像头2的形心和质心

            Delta_Angle(centers1, centers2, ref angle);
        }
        //**************************************************************//
        //函数名称：Add_Cross
        //函数作用：在光斑的形心处和图像基准点处加十字,并返回加十字的图
        //参数：       Bitmap original_image//原图
        //                 int Is_Left//图片是左摄像头还是右摄像头得到的，左为1，右为0             
        //**************************************************************//
        public Bitmap Add_Cross(Bitmap original_image, int Is_Left)
        {
            ArrayList centers = new ArrayList();
            Image<Bgr, Byte> image1 = new Image<Bgr, Byte>(original_image);
            Image<Bgr, Byte> image2;
            if (Is_Left == 1)
                 image2 = image12;
            else
                image2 = image22;

            Image<Gray, Byte> light_image = image1.Convert<Gray, Byte>();
            Image<Gray, Byte> back_image = image2.Convert<Gray, Byte>();

            Detect_Center_Point(light_image, back_image, ref centers);//获取形心和质心

            Int32 centerx = light_image.Cols / 2;
            Int32 centery = light_image.Rows / 2;

            double x1 = (double)centers[0];
            double y1 = (double)centers[1];
            double x2 = (double)centers[2];
            double y2 = (double)centers[3];

            Point scenterp = new Point();
            scenterp.X = (int)(x1 + centerx);
            scenterp.Y = (int)(y1 + centery);

            Point mcenterp = new Point();
            mcenterp.X = (int)(x2 + centerx);
            mcenterp.Y = (int)(y2 + centery);

            Point[] points1 = new Point[2];
            points1[0].X = BaseCenter.X + light_image.Cols / 2;
            points1[0].Y = 0;
            points1[1].X = BaseCenter.X + light_image.Cols / 2;
            points1[1].Y = light_image.Rows;

            Point[] points2 = new Point[2];
            points2[0].X = 0;
            points2[0].Y = BaseCenter.Y + light_image.Rows / 2;
            points2[1].X = light_image.Cols;
            points2[1].Y = BaseCenter.Y + light_image.Rows / 2;

            Point[] points3 = new Point[2];
            points3[0].X = scenterp.X;
            points3[0].Y = 0;
            points3[1].X = scenterp.X;
            points3[1].Y = light_image.Rows;

            Point[] points4 = new Point[2];
            points4[0].X = 0;
            points4[0].Y = scenterp.Y;
            points4[1].X = light_image.Cols;
            points4[1].Y = scenterp.Y;

            image1.DrawPolyline(points1, true, new Bgr(0, 170, 0), 2);
            image1.DrawPolyline(points2, true, new Bgr(0, 170, 0), 2);

            image1.DrawPolyline(points3, true, new Bgr(170, 0, 0), 2);
            image1.DrawPolyline(points4, true, new Bgr(170, 0, 0), 2);

            CvInvoke.Circle(image1, scenterp, 3, new MCvScalar(0, 0, 0), 2);
            CvInvoke.Circle(image1, mcenterp, 3, new MCvScalar(0, 0, 0), 2);

            return image1.ToBitmap();
        }
    }
}


