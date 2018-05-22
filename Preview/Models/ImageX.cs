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
        private const double f = 350;//光学系统1和2的组合焦距mm
        private const double l1 = 270;//面阵探测器1距离入射激光的光程mm
        private const double l = 270;//两伺服反射镜的中心距离mm
        private const double a = 2.7e-3;//探测器相元尺寸mm
        private const double F = 14;//光学系统垂轴放大率倒数

        //private double Error = 1.0 / 3600;

        //私有成员变量
        #region private variables
        private Image<Bgr, Byte> image12;
        private Image<Bgr, Byte> image22;

        private Bitmap LightImage_Left;
        private Bitmap LightImage_Right;

        private Point BaseCenter;

        private double breadthx;
        private double breadthy;

        private double shapecenterx;
        private double shapecentery;

        //private double biasx;
        //private double biasy;

        private double anglex;
        private double angley;

        private double delta_theta1;
        private double delta_fai1;
        private double delta_theta2;
        private double delta_fai2;

        private Bitmap grayimage;//用来获取在加十字窗口显示的bitmap
        private Bitmap heightmap;//用来获取opengl中3D图的高度信息
        private Bitmap coloredmap;//用来获取opengl中3D图的颜色信息&展示用的2D俯视图

        #endregion

        #region For Test
        /*
        public static void Main()
        {
            Bitmap t1 = new Bitmap("C:\\Users\\apple\\Desktop\\test\\456\\80.jpg");
            Bitmap t2 = new Bitmap("C:\\Users\\apple\\Desktop\\test\\123\\350.jpg");
            Bitmap bl = new Bitmap(t1.Width, t1.Height);
            Bitmap br = new Bitmap(t2.Width, t2.Height);

            Point center = new Point(0, 0);
            //Point center2 = new Point(t2.Width / 2, t2.Height / 2);

            ImageX px = new ImageX(bl, br, center);

            Point c = new Point(t1.Width / 2, t1.Height / 2);

            px.Load_Bitmap(t1, t2);

            //px.LightImage_Left = t1;
            //px.LightImage_Right = t2;

            Console.WriteLine(px.BreadthX);
            Console.WriteLine(px.BreadthY);
            Console.WriteLine(px.ShapeCenterX);
            Console.WriteLine(px.ShapeCenterY);
            Console.WriteLine(px.BiasX);
            Console.WriteLine(px.BiasY);
            Console.WriteLine(px.AngleX);
            Console.WriteLine(px.AngleY);
            Console.WriteLine(px.Delta_Theta1);
            Console.WriteLine(px.Delta_Fai1);
            Console.WriteLine(px.Delta_Theta2);
            Console.WriteLine(px.Delta_Fai2);
        }
        */
        #endregion

        //构造函数和加载新图像的函数
        #region Constructer & Public Methods
        public ImageX(Bitmap BaseLeft, Bitmap BaseRight, Point basecenter)//左背景图，右背景图，基准点(相对于图片中心)
        {
            image12 = new Image<Bgr, Byte>(BaseLeft);
            image22 = new Image<Bgr, Byte>(BaseRight);
            BaseCenter = basecenter;
        }

        //读取新图像的函数，每次调用都将重新计算所需变量
        public void Load_Bitmap(Bitmap lightimage_left, Bitmap lightimage_right)
        {
            LightImage_Left = lightimage_left;
            LightImage_Right = lightimage_right;

            Initialization();
        }

        #endregion

        //属性
        #region Attributes

        //返回光斑x轴宽度像素值
        public double BreadthX
        {
            get
            {
                return breadthx;
            }
        }

        //返回光斑y轴宽度像素值
        public double BreadthY
        {
            get
            {
                return breadthy;
            }
        }

        //返回形心坐标x，像素值
        public double ShapeCenterX
        {
            get
            {
                return shapecenterx;
            }
        }

        //返回形心坐标y，像素值
        public double ShapeCenterY
        {
            get
            {
                return shapecentery;
            }
        }

        //返回x轴偏移量
        public double BiasX
        {
            get
            {
                return shapecenterx - BaseCenter.X;
            }
        }

        //返回y轴偏移量
        public double BiasY
        {
            get
            {
                return shapecentery - BaseCenter.Y;
            }
        }

        //返回x轴偏移角度
        public double AngleX
        {
            get
            {
                return anglex;
            }
        }

        //返回y轴偏移角度
        public double AngleY
        {
            get
            {
                return angley;
            }
        }

        //返回电机1转动角度theta
        public double Delta_Theta1
        {
            get
            {
                return delta_theta1;
            }
        }

        //返回电机1转动角度fai
        public double Delta_Fai1
        {
            get
            {
                return delta_fai1;
            }
        }

        //返回电机2转动角度theta
        public double Delta_Theta2
        {
            get
            {
                return delta_theta2;
            }
        }

        //返回电机2转动角度fai
        public double Delta_Fai2
        {
            get
            {
                return delta_fai2;
            }
        }

        //获得彩色分布图&2D彩色俯视图
        public Bitmap ColorMap
        {
            get
            {
                return coloredmap;
            }
        }

        //获得高度图(处理过的灰度图)
        public Bitmap HeitghtMap
        {
            get
            {
                return heightmap;
            }
        }

        //获取在加十字窗口显示用的bitmap
        public Bitmap GrayBitmap
        {
            get
            {
                return grayimage;
            }
        }
        #endregion

        //私有方法
        #region private methods
        /// <summary>
        /// 属性Left_Center_Points,获得左摄像头的形心和质心坐标，相对于图像中心，先形心后质心
        /// </summary>
        private ArrayList Left_Center_Points//参数：光斑图片，存储偏移的list，背景图片
        {
            get
            {
                ArrayList list = new ArrayList();
                Image<Gray, Byte> original_image = new Image<Bgr, Byte>(LightImage_Left).Convert<Gray, Byte>();
                Image<Gray, Byte> background_image = image12.Convert<Gray, Byte>();

                grayimage = original_image.ToBitmap();

                Image<Gray, Byte> unback_image = new Image<Gray, Byte>(LightImage_Left).AbsDiff(background_image);
                Image<Gray, Byte> blured_image = new Image<Gray, Byte>(CvInvoke.cvGetSize(unback_image));
                CvInvoke.Blur(unback_image, blured_image, new Size(7, 7), new Point(-1, -1));

                Int32 centerx = blured_image.Cols / 2;
                Int32 centery = blured_image.Rows / 2;

                double max_pix = 0;
                double min_pix = 0;
                int[] minlist = new int[100];
                int[] maxlist = new int[100];

                CvInvoke.MinMaxIdx(blured_image, out min_pix, out max_pix, minlist, maxlist);

                Image<Gray, Double> dimage = blured_image.ConvertScale<Double>(255 / (max_pix - min_pix), 0);

                CvInvoke.Threshold(dimage, dimage, 220, 255, ThresholdType.ToZero);

                //CvInvoke.NamedWindow("Gray_Image", NamedWindowType.KeepRatio);
                //CvInvoke.Imshow("Gray_Image", dimage);

                Image<Gray, Byte> nImage = dimage.Convert<Gray, Byte>();

                heightmap = nImage.ToBitmap();

                Image<Bgr, Byte> cimage = new Image<Bgr, Byte>(CvInvoke.cvGetSize(dimage));

                CvInvoke.ApplyColorMap(nImage, cimage, ColorMapType.Jet);//进行颜色空间转换

                coloredmap = cimage.ToBitmap();

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
                        double tempg = dimage.Data[j, i, 0];
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

                shapecenterx = x1;
                shapecentery = y1;

                double x01 = 0;
                double x02 = 0;

                for (int i = 0; i <= (int)y1 + dimage.Cols / 2; i++)
                {
                    if (dimage.Data[(int)x1 + dimage.Rows / 2, i, 0] != 0)
                    {
                        x01 = i;
                        break;
                    }
                }

                for (int i = (int)y1 + dimage.Cols / 2; i < dimage.Cols; i++)
                {
                    if (dimage.Data[(int)x1 + dimage.Rows / 2, i, 0] == 0)
                    {
                        x02 = i;
                        break;
                    }
                }

                breadthx = x02 - x01;

                double y01 = 0;
                double y02 = 0;

                for (int i = 0; i <= (int)x1 + dimage.Rows / 2; i++)
                {
                    if (dimage.Data[i, (int)y1 + dimage.Cols / 2, 0] != 0)
                    {
                        y01 = i;
                        break;
                    }
                }

                for (int i = (int)x1 + dimage.Rows / 2; i < dimage.Rows; i++)
                {
                    if (dimage.Data[i, (int)y1 + dimage.Cols / 2, 0] == 0)
                    {
                        y02 = i;
                        break;
                    }
                }

                breadthy = y02 - y01;

                return list;
            }
        }
        /// <summary>
        /// 属性Right_Center_Points,获得右摄像头的形心和质心坐标，相对于图像中心，先形心后质心
        /// </summary>
        private ArrayList Right_Center_Points//参数：光斑图片，存储偏移的list，背景图片
        {
            get
            {
                ArrayList list = new ArrayList();
                Image<Gray, Byte> original_image = new Image<Bgr, Byte>(LightImage_Right).Convert<Gray, Byte>();
                Image<Gray, Byte> background_image = image22.Convert<Gray, Byte>();

                Image<Gray, Byte> unback_image = new Image<Gray, Byte>(LightImage_Left).AbsDiff(background_image);
                Image<Gray, Byte> blured_image = new Image<Gray, Byte>(CvInvoke.cvGetSize(unback_image));
                CvInvoke.Blur(unback_image, blured_image, new Size(7, 7), new Point(-1, -1));

                Int32 centerx = blured_image.Cols / 2;
                Int32 centery = blured_image.Rows / 2;

                double max_pix = 0;
                double min_pix = 0;
                int[] minlist = new int[100];
                int[] maxlist = new int[100];

                CvInvoke.MinMaxIdx(blured_image, out min_pix, out max_pix, minlist, maxlist);

                Image<Gray, Double> dimage = blured_image.ConvertScale<Double>(255 / (max_pix - min_pix), 0);

                CvInvoke.Threshold(dimage, dimage, 230, 255, ThresholdType.ToZero);

                //CvInvoke.NamedWindow("Gray_Image", NamedWindowType.KeepRatio);
                //CvInvoke.Imshow("Gray_Image", dimage);

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
                        double tempg = dimage.Data[j, i, 0];
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

                return list;
            }
        }
        //**************************************************************//
        // 函数名称：Delta_Angle
        // 函数作用：接受两个摄像头传来的参数，计算转动角度
        // 函数参数:    ArrayList Centers1：摄像头一的形心和质心坐标，分别为形心x，形心y，质心x，质心y
        //                   ArrayList Centers2：摄像头二的形心和质心坐标，分别为形心x，形心y，质心x，质心y
        //                   ref ArrayList Angle：计算得到的电机转动角度，分别为theta1，fai1，theta2，fai2
        //**************************************************************//
        public void Delta_Angle(ArrayList Centers1, ArrayList Centers2)//参数：图片一的四个中心，图片二的四个中心，输出角度，theta1，fai1，theta2，fai2
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
            double delta_beita = Math.Atan((mcentery1 - BaseCenter.Y) * a / f);



            double delta_x = (mcenterx2 - BaseCenter.X) * a * F - l1 * Math.Tan(delta_alpha);//?
            double delta_y = (mcentery2 - BaseCenter.X) * a * F - l1 * Math.Tan(delta_beita);

            delta_theta1 = (0.5 * delta_alpha + 0.5 * Math.Asin(delta_x / l)) * 180 / Math.PI;//镜1旋转角度
            delta_fai1 = (0.5 * delta_beita + 0.5 * Math.Asin(delta_y / l)) * 180 / Math.PI;//镜1旋转角度
            delta_theta2 = (0.5 * Math.Asin(delta_x / l)) * 180 / Math.PI;//镜3旋转角度
            delta_fai2 = (0.5 * Math.Asin(delta_y / l)) * 180 / Math.PI;//镜4旋转角度

            anglex = delta_alpha;
            angley = delta_beita;
        }


        /// <summary>
        ///初始化，设置各个属性的值
        /// </summary>
        public void Initialization()
        {
            Image<Bgr, Byte> image11 = new Image<Bgr, Byte>(LightImage_Left);
            //Image<Bgr, Byte> image12 = new Image<Bgr, Byte>(BaseLeft);
            Image<Bgr, Byte> image21 = new Image<Bgr, Byte>(LightImage_Right);
            // Image<Bgr, Byte> image22 = new Image<Bgr, Byte>(BaseRight);

            Image<Gray, Byte> light_image1 = image11.Convert<Gray, Byte>();
            Image<Gray, Byte> back_image1 = image12.Convert<Gray, Byte>();
            Image<Gray, Byte> light_image2 = image21.Convert<Gray, Byte>();
            Image<Gray, Byte> back_image2 = image22.Convert<Gray, Byte>();

            ArrayList angles = new ArrayList();

            ArrayList centers1 = Left_Center_Points;
            ArrayList centers2 = Right_Center_Points;


            //Detect_Center_Point(light_image1, back_image1, ref centers1);//获取摄像头1的形心和质心
            //Detect_Center_Point(light_image2, back_image2, ref centers2);//获取摄像头2的形心和质心

            Delta_Angle(centers1, centers2);

        }
        #endregion
    }
}