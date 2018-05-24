using System;
using System.Drawing;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;




namespace Preview
{
    /// <summary>
    /// 视频采集类，负责连接摄像头，获取图像
    /// </summary>
    class VideoCapture
    {
        private PictureBox _anglePictureBox;
        private PictureBox _shiftPictureBox;
        private Graphics grfxA; 
        public Camera CamLeft;//角度图像相机
        public Camera CamRight;//位移图像相机

        public Bitmap[] PreviewImage;
        public bool IsPreviewing;

        public VideoCapture(DvrLoginInfo leftDvrLoginInfo,DvrLoginInfo rightDvrLoginInfo)
        {
            if (!CHCNetSDK.NET_DVR_Init())
            {
                throw new Exception("NET_DVR_Init error!");
            }
            CamLeft=new Camera(leftDvrLoginInfo.DvripAddress,leftDvrLoginInfo.DvrPortNumber,
                leftDvrLoginInfo.DvrUserName,leftDvrLoginInfo.DvrPassword);
            CamRight = new Camera(rightDvrLoginInfo.DvripAddress, rightDvrLoginInfo.DvrPortNumber,
                rightDvrLoginInfo.DvrUserName, rightDvrLoginInfo.DvrPassword);
            IsPreviewing = false;
            PreviewImage = new Bitmap[2];
        }


        /// <summary>
        /// 登陆操作
        /// </summary>
        /// <returns>是否成功</returns>
        public bool Login()
        {
            return CamLeft.Login() && CamRight.Login();
        }

        /// <summary>
        /// 启动实时画面预览
        /// </summary>
        /// <param name="picA">角度图像显示的picBox</param>
        /// <param name="picB">位移图像显示的picBox</param>
        public void StartPreview(PictureBox picA,PictureBox picB)
        {
            _anglePictureBox = picA;
            _shiftPictureBox = picB;
            CamLeft.StartPreview(picA.Handle);
            CamRight.StartPreview(picB.Handle);
            IsPreviewing = true;
            grfxA = _shiftPictureBox.CreateGraphics();
        }
        /// <summary>
        /// 停止预览
        /// </summary>
        public void StopPreview()
        {
            CamLeft.StopPreview();
            CamRight.StopPreview();
            IsPreviewing = false;
        }

        ///<summary>
        /// 下载录像
        /// </summary>
        public void PlayBack()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Capture BMP maps
        /// </summary>
        /// <returns>bmpMaps[0] leftImg,bmpMaps[1] baseImg</returns>
        /// <summary>
        /// modified to void function by SHEN,HANWEN on 2018/5/8.Initialize PreviewImage character
        /// </summary>
        public void CaptureBmp()
        {
            //TODO：当前存在严重的性能与稳定性的问题，需重构
            if (PreviewImage[0] != null)
            {
                PreviewImage[0].Dispose();
                
            }
            if (PreviewImage[1] != null)
            {
                PreviewImage[1].Dispose();
            }
            const string leftImgName = "Left.bmp";
            const string rightImgName = "Right.bmp";
            //if (File.Exists(leftImgName))
            //{
            //    File.Delete("./"+leftImgName);
            //    File.Delete("./"+rightImgName);
            //}
            bool flag = true;
            flag&=CHCNetSDK.NET_DVR_CapturePicture(CamLeft.RealPlayHandle, leftImgName); 
            flag&=CHCNetSDK.NET_DVR_CapturePicture(CamRight.RealPlayHandle, rightImgName);
            if(!flag)
            {
                var iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                throw new Exception("NET_DVR_CapturePicture failed, error code= " + iLastErr);
            }
            PreviewImage[0] = new Bitmap("Left.bmp");
            PreviewImage[1] = new Bitmap("Right.bmp");
            

        }

        /// <summary>
        /// 在预览画面上叠加十字 沈翰文 2018/5/9
        /// </summary>
        
        public void DrawImage(int a, int b, int c, int d)
        {
            //TODO：重写实现
            int x0 = a * _shiftPictureBox.Width / 1920;
            int y0 = b * _shiftPictureBox.Height / 1080;
            int x1 = c * _shiftPictureBox.Width / 1920;
            int y1 = d * _shiftPictureBox.Height / 1080;
            
            Pen pen_base = new Pen(Color.Chartreuse, 1);
            Pen pen_now = new Pen(Color.Black, 1);
            //Point[]的参数还可以调，根据窗口大小
            Point[] points1 =
            {
                new Point(0, y0),
                new Point(_shiftPictureBox.Width, y0),
                new Point(x0, y0),
                new Point(x0, 0),
                new Point(x0,_shiftPictureBox.Height),
            };

            Point[] points2 =
            {
                new Point(0, y1),
                new Point(_shiftPictureBox.Width, y1),
                new Point(x1, y1),
                new Point(x1, 0),
                new Point(x1,_shiftPictureBox.Height),
            };
            grfxA.GetContextInfo();

            grfxA.DrawLines(pen_base, points1);

            grfxA.DrawLines(pen_now, points2);

        }


        ~VideoCapture()
        {
            
            CamLeft.StopPreview();
            CamLeft.Logout();
            CamRight.StopPreview();
            CamRight.Logout();

            CHCNetSDK.NET_DVR_Cleanup();
        }

    }
    /// <summary>
    /// 摄像头登陆信息
    /// </summary>
    struct DvrLoginInfo
    {
        public string DvripAddress;//IP地址
        public short DvrPortNumber;//端口号
        public string DvrUserName;//用户名
        public string DvrPassword;//密码

    }


    class Camera
    {
        public string DvripAddress { get; set; }
        public short DvrPortNumber { get; set; }
        public string DvrUserName { get; set; }
        public string DvrPassword { get; set; }

        public IntPtr User;
        public int RealPlayHandle;
        public CHCNetSDK.REALDATACALLBACK RealData = null;

        public CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo;
        private CHCNetSDK.NET_DVR_PREVIEWINFO _lpPreviewInfo;

        public IntPtr CamHandle;
        public int UserId;

        public Camera(string ipAddress,short port, string userName, string password)
        {
            DvripAddress = ipAddress;
            DvrPortNumber = port;
            DvrUserName = userName;
            DvrPassword = password;

            DeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();
            User = new IntPtr();

        }

        /// <summary>
        /// 登陆摄像头，登陆失败抛出异常
        /// </summary>
        /// <returns>是否成功</returns>
        public bool Login()
        {
            UserId = CHCNetSDK.NET_DVR_Login_V30(DvripAddress, DvrPortNumber, DvrUserName, DvrPassword, ref DeviceInfo);
            if (UserId < 0)
            {

                //throw new Exception("登录失败");
                var iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                throw new Exception("NET_DVR_CapturePicture failed, error code= " + iLastErr);

                return false;
            }
            else
            {
                //IntPtr ip=new IntPtr(40);
                //uint size = 0;
                //NET_DVR_GetDVRConfig(UserID, NET_DVR_GET_PICCFG_V30, 0,ip,40,ref size);
                
                //NET_DVR_SetDVRConfig(UserID, NET_DVR_SET_PICCFG_V30, 0xFFFFFFFF,commandInfo,commandInfo.dwSize);
                return true;
            }
        }

        public void Logout()
        {
            if (UserId >= 0)
            {
                CHCNetSDK.NET_DVR_Logout(UserId);
            }
        }

        /// <summary>
        /// 启动摄像头预览功能
        /// </summary>
        /// <param name="realPlayWndHandle">播放所使用的picbox的句柄</param>
        public void StartPreview(IntPtr realPlayWndHandle)
        {
            //TODO:建议重构，以实现实时解码获取图像的功能
            if (UserId < 0)
            {
                throw new Exception("Please login the device firstly");
            }

            CHCNetSDK.NET_DVR_PREVIEWINFO previewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();
            previewInfo.hPlayWnd = realPlayWndHandle;//预览窗口
            previewInfo.lChannel = 1;//预览的设备通道
            previewInfo.dwStreamType = 0;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
            previewInfo.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
            previewInfo.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流
            previewInfo.dwDisplayBufNum = 15; //播放库播放缓冲区最大缓冲帧数

            if (RealData == null)
            {
                RealData = RealDataCallBack;//预览实时流回调函数
            }

            RealPlayHandle = CHCNetSDK.NET_DVR_RealPlay_V40(UserId, ref previewInfo, null, User);

        }

        public void StopPreview()
        {
            if(RealPlayHandle>=0)
                CHCNetSDK.NET_DVR_StopRealPlay(RealPlayHandle);
        }
        /// <summary>
        /// 视频回调解码，暂时没有用到，可以参考手册实现
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <param name="dwDataType"></param>
        /// <param name="pBuffer"></param>
        /// <param name="dwBufSize"></param>
        /// <param name="pUser"></param>
        public void RealDataCallBack(Int32 lRealHandle, UInt32 dwDataType, IntPtr pBuffer, UInt32 dwBufSize, IntPtr pUser)
        {
            //这个暂时没有用
        }

        /// <summary>
        /// 录像回放函数   沈翰文 2018/5/9  缺少查找时间函数，无法查找录像时间，只能指定
        /// </summary>
        public void Playback(uint startYear, uint startMonth, uint startDay, uint startHour, uint startMinute, uint startSecond, uint endYear, uint endMonth, uint endDay, uint endHour, uint endMinute, uint endSecond)
        {
            CHCNetSDK.NET_DVR_PLAYCOND struDownloadCond = new CHCNetSDK.NET_DVR_PLAYCOND();
            struDownloadCond.dwChannel = 1;

            struDownloadCond.struStartTime.dwYear = startYear;
            struDownloadCond.struStartTime.dwMonth = startMonth;
            struDownloadCond.struStartTime.dwDay = startDay;
            struDownloadCond.struStartTime.dwHour = startHour;
            struDownloadCond.struStartTime.dwMinute = startMinute;
            struDownloadCond.struStartTime.dwSecond = startSecond;
            struDownloadCond.struStopTime.dwYear = endYear;
            struDownloadCond.struStopTime.dwMonth = endMonth;
            struDownloadCond.struStopTime.dwDay = endDay;
            struDownloadCond.struStopTime.dwHour = endHour;
            struDownloadCond.struStopTime.dwMinute = endMinute;
            struDownloadCond.struStopTime.dwSecond = endSecond;

            int hPlayback = CHCNetSDK.NET_DVR_GetFileByTime_V40(UserId, "./test.mp4", ref struDownloadCond);
            if (hPlayback < 0)
            {
                Console.WriteLine("NET_DVR_GetFileByTime_V40 fail,last error %d\n", CHCNetSDK.NET_DVR_GetLastError());
                CHCNetSDK.NET_DVR_Logout(UserId);
                CHCNetSDK.NET_DVR_Cleanup();
                return;
            }

            uint lpOutValue = 0;
            IntPtr lpInBuffer = new IntPtr();
            IntPtr lpOutBuffer = new IntPtr();

            if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(hPlayback, CHCNetSDK.NET_DVR_PLAYSTART, lpInBuffer, 0, lpOutBuffer, ref lpOutValue))
            {

                CHCNetSDK.NET_DVR_Logout(UserId);
                CHCNetSDK.NET_DVR_Cleanup();
                return;
            }

            int nPos = 0;
            for (nPos = 0; nPos < 100 && nPos >= 0; nPos = CHCNetSDK.NET_DVR_GetDownloadPos(hPlayback))
            {
                Console.WriteLine("Be downloading... %d %%\n", nPos);
                Thread.Sleep(5000);  //millisecond
            }
            if (!CHCNetSDK.NET_DVR_StopGetFile(hPlayback))
            {
                Console.WriteLine("failed to stop get file [%d]\n", CHCNetSDK.NET_DVR_GetLastError());
                CHCNetSDK.NET_DVR_Logout(UserId);
                CHCNetSDK.NET_DVR_Cleanup();
                return;
            }
            if (nPos < 0 || nPos > 100)
            {
                Console.WriteLine("download err [%d]\n", CHCNetSDK.NET_DVR_GetLastError());
                CHCNetSDK.NET_DVR_Logout(UserId);
                CHCNetSDK.NET_DVR_Cleanup();
                return;
            }
            Console.WriteLine("Be downloading... %d %%\n", nPos);


        }

    }
}