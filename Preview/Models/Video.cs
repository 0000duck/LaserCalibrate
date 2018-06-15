using System;
using System.Drawing;
using System.Threading;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static Preview.CHCNetSDK;




namespace Preview
{
    /// <summary>
    /// 视频采集类，负责连接摄像头，获取图像
    /// </summary>
    class VideoCapture
    {

        private Camera CamLeft { get; }
        private Camera CamRight { get; }

        //public Bitmap[] BitMapPicture => CaptureBMP();
        public Bitmap[] PreviewImage;
        public bool IsPreviewing;
        public bool IsRecording;
        public bool IsPlaybacking;
        public bool IsPausing;
        public bool IsDownloading;

        public VideoCapture(DVRLoginInfo leftDvrLoginInfo, DVRLoginInfo rightDvrLoginInfo)
        {
            if (!CHCNetSDK.NET_DVR_Init())
            {
                throw new Exception("NET_DVR_Init error!");
            }
            CamLeft = new Camera(leftDvrLoginInfo.DVRIPAddress, leftDvrLoginInfo.DVRPortNumber,
                leftDvrLoginInfo.DVRUserName, leftDvrLoginInfo.DVRPassword);
            CamRight = new Camera(rightDvrLoginInfo.DVRIPAddress, rightDvrLoginInfo.DVRPortNumber,
                rightDvrLoginInfo.DVRUserName, rightDvrLoginInfo.DVRPassword);
            IsPreviewing = false;
            IsRecording = false;
            IsPlaybacking = false;
            IsPausing = false;
            IsDownloading = false;
            PreviewImage = new Bitmap[2];
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Login()
        {
            if (!(CamLeft.Login() && CamRight.Login()))
            {
                var iLastErr = NET_DVR_GetLastError();
                throw new Exception("NET_DVR_Login failed, error code= " + iLastErr);

            }


        }

        /// <summary>
        /// 启动实时画面预览
        /// </summary>
        /// <param name="picA">角度图像显示的picBox</param>
        /// <param name="picB">位移图像显示的picBox</param>
        public void StartPreview(PictureBox picA, PictureBox picB)
        {
            if (!IsPreviewing)
            {

                CamLeft.StartPreview(picA);
                CamRight.StartPreview(picB);
                IsPreviewing = true;

            }


        }
        /// <summary>
        /// 停止预览
        /// </summary>
        public void StopPreview()
        {
            if (IsRecording)
            {
                throw new Exception("Please stop recording first!");

            }
            if (IsPreviewing)
            {
                CamLeft.StopPreview();
                CamRight.StopPreview();
                IsPreviewing = false;

            }


        }

        /// <summary>
        /// 开启录像
        /// </summary>

        public void StartRecord()
        {
            if (!IsRecording)
            {
                CamLeft.StartRecord();
                CamRight.StartRecord();
                IsRecording = true;

            }


        }

        /// <summary>
        /// 结束录像
        /// </summary>
        public void StopRecord()
        {
            if (IsRecording)
            {
                CamLeft.StopRecord();
                CamRight.StopRecord();
                IsRecording = false;

            }


        }

        public string[][] Findfile(uint y1, uint m1, uint d1, uint h1, uint min1, uint s1, uint y2, uint m2, uint d2,
            uint h2, uint min2, uint s2)
        {

            string[][] filelist = new string[2][];
            //string[2,] filelist1;
            filelist[0] = CamLeft.findfile(y1, m1, d1, h1, min1, s1, y2, m2, d2, h2, min2, s2);
            filelist[1] = CamRight.findfile(y1, m1, d1, h1, min1, s1, y2, m2, d2, h2, min2, s2);
            //CamRight.findfile(y1, m1, d1, h1, min1, s1, y2, m2, d2, h2, min2, s2);
            return filelist;


        }

        ///<summary>
        /// 开启回放
        /// </summary>
        public void StartPlayBack(string sPlayBackFileName1, string sPlayBackFileName2, PictureBox picA, PictureBox picB/*uint y1, uint m1, uint d1, uint h1, uint min1, uint s1, uint y2, uint m2, uint d2, uint h2, uint min2, uint s2*/)
        {
            if (!IsPlaybacking)
            {
                CamLeft.StartPlayback(sPlayBackFileName1, picA/*y1, m1, d1, h1, min1, s1, y2, m2, d2, h2, min2, s2*/);
                CamRight.StartPlayback(sPlayBackFileName2, picB);//,y1, m1, d1, h1, min1, s1, y2, m2, d2, h2, min2, s2);
                IsPlaybacking = true;

            }


        }

        public void Playpause()
        {
            if (!IsPausing)
            {
                CamLeft.Playpause();
                CamRight.Playpause();
                IsPausing = true;

            }
            else
            {
                CamLeft.Playstart();
                CamRight.Playstart();
                IsPausing = false;

            }

        }

        public void Playfast()
        {
            CamLeft.Playfast();
            CamRight.Playfast();
        }

        public void Playslow()
        {
            CamLeft.Playslow();
            CamRight.Playslow();
        }

        public void Playnormal()
        {
            CamLeft.Playnormal();
            CamRight.Playnormal();
        }

        public void StopPlayBack()
        {
            if (IsPlaybacking)
            {
                CamLeft.StopPlayback();
                CamRight.StopPlayback();
                IsPlaybacking = false;
                IsPausing = false;

            }


        }

        public int GetPlaybackProgress()
        {
            int ipos = CamLeft.GetPlaybackProgress();
            CamRight.GetPlaybackProgress();
            return ipos;
        }

        public int GetDownloadProgress()
        {
            int ipos = CamLeft.GetDownloadProgress();
            CamRight.GetDownloadProgress();
            return ipos;
        }

        public void Download(String sPlayBackFileName1, String sPlayBackFileName2)
        {
            CamLeft.Download(sPlayBackFileName1);
            CamRight.Download(sPlayBackFileName2);
            IsDownloading = true;
        }

        public void DownloadStop()
        {
            CamLeft.DownloadStop();
            CamRight.DownloadStop();
            IsDownloading = false;
        }

        /// <summary>
        /// Capture BMP maps
        /// </summary>
        /// <returns>bmpMaps[0] leftImg,bmpMaps[1] baseImg</returns>
        /// <summary>
        /// modified to void function by SHEN,HANWEN on 2018/5/8.Initialize PreviewImage character
        /// </summary>
        public void CaptureBMPpreview()
        {

            const string leftImgName = "Left.bmp";
            const string rightImgName = "Right.bmp";


            //if (!NET_DVR_CapturePicture(CamLeft.RealPlayHandle, leftImgName))
            //{
            //    var iLastErr = NET_DVR_GetLastError();
            //    throw new Exception("NET_DVR_CapturePicturepreview failed, error code= " + iLastErr);
            //}
            if (!(NET_DVR_CapturePicture(CamLeft.RealPlayHandle, leftImgName) && NET_DVR_CapturePicture(CamRight.RealPlayHandle, rightImgName)))
            {
                var iLastErr = NET_DVR_GetLastError();
                throw new Exception("NET_DVR_CapturePicturepreview failed, error code= " + iLastErr);
            }
            Thread.Sleep(1000);
            try
            {
                PreviewImage[0] = new Bitmap(leftImgName);
                PreviewImage[1] = new Bitmap(rightImgName);
            }
            catch (Exception)
            {
                
            }


        }

        public void CaptureBMPplayback()
        {

            const string leftImgName = "Left.bmp";
            const string rightImgName = "Right.bmp";

            if (!(NET_DVR_PlayBackCaptureFile(CamLeft.PlaybackHandle, leftImgName) && NET_DVR_PlayBackCaptureFile(CamRight.PlaybackHandle, rightImgName)))
            {
                var iLastErr = NET_DVR_GetLastError();
                throw new Exception("NET_DVR_CapturePictureplayback failed, error code= " + iLastErr);
            }

            PreviewImage[0] = new Bitmap(leftImgName);
            PreviewImage[1] = new Bitmap(rightImgName);


        }


        public void NewdrawOnpreview(int xa1, int ya1, int xa2, int ya2, int xb1, int yb1, int xb2, int yb2)
        {
            CamLeft.DrawImageOnpreview(xa1, ya1, xa2, ya2);
            CamRight.DrawImageOnpreview(xb1, yb1, xb2, yb2);

        }

        public void NewdrawOnplayback(int xa1, int ya1, int xa2, int ya2, int xb1, int yb1, int xb2, int yb2)
        {
            CamLeft.DrawImageOnplayback(xa1, ya1, xa2, ya2);
            CamRight.DrawImageOnplayback(xb1, yb1, xb2, yb2);

        }

        ~VideoCapture()
        {

            CamLeft.StopPreview();
            CamLeft.Logout();
            CamRight.StopPreview();
            CamRight.Logout();

            NET_DVR_Cleanup();
        }

    }

    struct DVRLoginInfo
    {
        public string DVRIPAddress;
        public short DVRPortNumber;
        public string DVRUserName;
        public string DVRPassword;

    }


    class Camera
    {
        //注册有关信息
        public string DVRIPAddress { get; set; }
        public short DVRPortNumber { get; set; }
        public string DVRUserName { get; set; }
        public string DVRPassword { get; set; }

        private int x1;
        private int y1;
        private int x2;
        private int y2;

        //预览句柄
        public int RealPlayHandle;

        //下载句柄
        public int DownloadHandle;

        //设备信息
        public NET_DVR_DEVICEINFO_V30 DeviceInfo;


        //回放句柄
        public int PlaybackHandle;
        //用户id
        public int UserId;
        //camera绑定的picturebox控件
        public PictureBox pic { get; set; }

        public Camera(string ipAddress, short port, string userName, string password)
        {
            DVRIPAddress = ipAddress;
            DVRPortNumber = port;
            DVRUserName = userName;
            DVRPassword = password;

            DeviceInfo = new NET_DVR_DEVICEINFO_V30();

            RealPlayHandle = -1;
            PlaybackHandle = -1;
            DownloadHandle = -1;

            x1 = 0;
            y1 = 0;

            x2 = 0;
            y2 = 0;


        }


        public bool Login()
        {
            UserId = NET_DVR_Login_V30(DVRIPAddress, DVRPortNumber, DVRUserName, DVRPassword, ref DeviceInfo);

            if (UserId < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Logout()
        {
            if (UserId >= 0)
            {
                NET_DVR_Logout(UserId);
            }
        }


        public void StartPreview(PictureBox picA)
        {
            if (UserId < 0)
            {
                throw new Exception("Please login the device firstly");
            }
            if (PlaybackHandle >= 0)
            {
                throw new Exception("Please stop playback firstly");

            }

            if (RealPlayHandle < 0)
            {
                CHCNetSDK.NET_DVR_PREVIEWINFO previewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();
                previewInfo.hPlayWnd = pic.Handle;//预览窗口
                previewInfo.lChannel = 1;//预览的设备通道
                previewInfo.dwStreamType = 0;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
                previewInfo.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
                previewInfo.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流
                previewInfo.dwDisplayBufNum = 15; //播放库播放缓冲区最大缓冲帧数

                pic = picA;

                IntPtr user = new IntPtr();

                RealPlayHandle = NET_DVR_RealPlay_V40(UserId, ref previewInfo, null, user);

            }




        }

        public void StopPreview()
        {

            if (RealPlayHandle >= 0)
            {
                NET_DVR_StopRealPlay(RealPlayHandle);
                RealPlayHandle = -1;

            }

        }

        /// <summary>
        /// record 录像函数 沈翰文
        /// </summary>

        public void StartRecord()
        {
            if (RealPlayHandle < 0)
            {
                throw new Exception("Please start preview firstly");

            }
            string sVideoFileName;
            sVideoFileName = "Record_test.mp4";
            int lChannel = 1; //通道号 Channel number
            CHCNetSDK.NET_DVR_MakeKeyFrame(UserId, lChannel);

            //开始录像 Start recording
            if (!CHCNetSDK.NET_DVR_SaveRealData(RealPlayHandle, sVideoFileName))
            {
                var iLastErr = NET_DVR_GetLastError();
                throw new Exception("NET_DVR_SaveRealData failed, error code= " + iLastErr);

            }
        }

        public void StopRecord()
        {
            if (!CHCNetSDK.NET_DVR_StopSaveRealData(RealPlayHandle))
            {
                var iLastErr = NET_DVR_GetLastError();
                throw new Exception("NET_DVR_StopSaveRealData failed, error code= " + iLastErr);

            }
        }

        ///<summary>
        ///新的drawimage函数    沈翰文 2018/6/3
        /// </summary>

        public void DrawFunCallBack(int lRealHandle, IntPtr hdc, uint dwUser)
        {


            Graphics g = Graphics.FromHdc(hdc);
            Pen penA = new Pen(Color.Chartreuse, 1);
            Pen penB = new Pen(Color.Blue, 1);
            //Random r = new Random();
            //int a = r.Next(0, 1920);
            //int b = r.Next(0, 1080);


            int X1 = x1 * pic.Width / 1920;
            int Y1 = y1 * pic.Height / 1080;
            int X2 = x2 * pic.Width / 1920;
            int Y2 = y2 * pic.Height / 1080;



            //Point[]的参数还可以调，根据窗口大小
            Point[] points1 =
            {
                new Point(0, Y1),
                new Point(pic.Width, Y1),
                new Point(X1, Y1),
                new Point(X1, 0),
                new Point(X1,pic.Height),
            };

            Point[] points2 =
            {
                new Point(0, Y2),
                new Point(pic.Width, Y2),
                new Point(X2, Y2),
                new Point(X2, 0),
                new Point(X2,pic.Height),
            };


            Thread.Sleep(100);

            g.DrawLines(penA, points1);
            g.DrawLines(penB, points2);


        }

        public void DrawImageOnpreview(int a, int b, int c, int d)
        {
            x1 = a;
            y1 = b;
            x2 = c;
            y2 = d;

            DRAWFUN drawcross = new DRAWFUN(DrawFunCallBack);
            uint userInfo = new uint();
            if (!NET_DVR_RigisterDrawFun(RealPlayHandle, drawcross, userInfo))
            {
                var iLastErr = NET_DVR_GetLastError();
                throw new Exception("NET_DVR_RigisterDrawFun failed, error code= " + iLastErr);

            }
        }

        public void DrawImageOnplayback(int a, int b, int c, int d)
        {
            x1 = a;
            y1 = b;
            x2 = c;
            y2 = d;
            DRAWFUN drawcross = new DRAWFUN(DrawFunCallBack);
            uint userInfo = new uint();
            if (!NET_DVR_RigisterPlayBackDrawFun(PlaybackHandle, drawcross, userInfo))
            {
                var iLastErr = NET_DVR_GetLastError();
                throw new Exception("NET_DVR_RigisterDrawFun failed, error code= " + iLastErr);

            }
        }

        public string[] findfile(uint y1, uint m1, uint d1, uint h1, uint min1, uint s1, uint y2, uint m2, uint d2, uint h2, uint min2, uint s2)
        {
            Int32 m_lFindHandle = -1;
            CHCNetSDK.NET_DVR_FILECOND_V40 struFileCond_V40 = new CHCNetSDK.NET_DVR_FILECOND_V40();
            string[] filelist = new string[1000];

            struFileCond_V40.lChannel = 1; //通道号 Channel number
            struFileCond_V40.dwFileType = 0xff; //0xff-全部，0-定时录像，1-移动侦测，2-报警触发，...
            struFileCond_V40.dwIsLocked = 0xff; //0-未锁定文件，1-锁定文件，0xff表示所有文件（包括锁定和未锁定）

            //设置录像查找的开始时间 Set the starting time to search video files
            struFileCond_V40.struStartTime.dwYear = y1;
            struFileCond_V40.struStartTime.dwMonth = m1;
            struFileCond_V40.struStartTime.dwDay = d1;
            struFileCond_V40.struStartTime.dwHour = h1;
            struFileCond_V40.struStartTime.dwMinute = min1;
            struFileCond_V40.struStartTime.dwSecond = s1;

            //设置录像查找的结束时间 Set the stopping time to search video files
            struFileCond_V40.struStopTime.dwYear = y2;
            struFileCond_V40.struStopTime.dwMonth = m2;
            struFileCond_V40.struStopTime.dwDay = d2;
            struFileCond_V40.struStopTime.dwHour = h2;
            struFileCond_V40.struStopTime.dwMinute = min2;
            struFileCond_V40.struStopTime.dwSecond = s2;

            //开始录像文件查找 Start to search video files 
            m_lFindHandle = CHCNetSDK.NET_DVR_FindFile_V40(UserId, ref struFileCond_V40);

            if (m_lFindHandle < 0)
            {
                var iLastErr = NET_DVR_GetLastError();
                throw new Exception("NET_DVR_FindFile_V40 failed, error code= " + iLastErr);

            }
            else
            {
                int i = 0;
                CHCNetSDK.NET_DVR_FINDDATA_V30 struFileData = new CHCNetSDK.NET_DVR_FINDDATA_V30(); ;
                while (true)
                {
                    //逐个获取查找到的文件信息 Get file information one by one.
                    int result = CHCNetSDK.NET_DVR_FindNextFile_V30(m_lFindHandle, ref struFileData);

                    if (result == CHCNetSDK.NET_DVR_ISFINDING)  //正在查找请等待 Searching, please wait
                    {
                        continue;
                    }
                    else if (result == CHCNetSDK.NET_DVR_FILE_SUCCESS) //获取文件信息成功 Get the file information successfully
                    {
                        string str1 = struFileData.sFileName;

                        string str2 = Convert.ToString(struFileData.struStartTime.dwYear) + "-" +
                            Convert.ToString(struFileData.struStartTime.dwMonth) + "-" +
                            Convert.ToString(struFileData.struStartTime.dwDay) + " " +
                            Convert.ToString(struFileData.struStartTime.dwHour) + ":" +
                            Convert.ToString(struFileData.struStartTime.dwMinute) + ":" +
                            Convert.ToString(struFileData.struStartTime.dwSecond);

                        string str3 = Convert.ToString(struFileData.struStopTime.dwYear) + "-" +
                            Convert.ToString(struFileData.struStopTime.dwMonth) + "-" +
                            Convert.ToString(struFileData.struStopTime.dwDay) + " " +
                            Convert.ToString(struFileData.struStopTime.dwHour) + ":" +
                            Convert.ToString(struFileData.struStopTime.dwMinute) + ":" +
                            Convert.ToString(struFileData.struStopTime.dwSecond);

                        filelist.SetValue(str1, i++);//将查找的录像文件添加到列表中
                        filelist.SetValue(str2, i++);
                        filelist.SetValue(str3, i++);
                    }
                    else if (result == CHCNetSDK.NET_DVR_FILE_NOFIND || result == CHCNetSDK.NET_DVR_NOMOREFILE)
                    {
                        break; //未查找到文件或者查找结束，退出   No file found or no more file found, search is finished 
                    }
                    else
                    {
                        break;
                    }

                }

                return filelist;

            }

        }

        /// <summary>
        /// 录像回放函数   沈翰文 2018/6/2 修订
        /// </summary>
        public void StartPlayback(string sPlayBackFileName, PictureBox picA/*uint y1, uint m1, uint d1, uint h1, uint min1, uint s1, uint y2, uint m2, uint d2, uint h2, uint min2, uint s2*/)
        {
            if (UserId < 0)
            {
                throw new Exception("Please login the device firstly");
            }
            if (RealPlayHandle >= 0)
            {
                throw new Exception("Please stop preview firstly");

            }
            if (sPlayBackFileName == null)
            {
                throw new Exception("请先选中一个文件");
            }

            if (PlaybackHandle >= 0)
            {
                //如果已经正在回放，先停止回放
                if (!CHCNetSDK.NET_DVR_StopPlayBack(PlaybackHandle))
                {

                    var iLastErr = NET_DVR_GetLastError();
                    throw new Exception("NET_DVR_StopPlayBack failed, error code= " + iLastErr);
                }


                PlaybackHandle = -1;

            }

            pic = picA;
            PlaybackHandle = CHCNetSDK.NET_DVR_PlayBackByName(UserId, sPlayBackFileName, pic.Handle);
            if (PlaybackHandle < 0)
            {
                var iLastErr = NET_DVR_GetLastError();
                throw new Exception("NET_DVR_PlayBackByName failed, error code= " + iLastErr);

            }

            uint iOutValue = 0;
            if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(PlaybackHandle, CHCNetSDK.NET_DVR_PLAYSTART, IntPtr.Zero, 0, IntPtr.Zero, ref iOutValue))
            {
                var iLastErr = NET_DVR_GetLastError();
                throw new Exception("NET_DVR_PLAYSTART failed, error code= " + iLastErr);

            }

            //if (PlaybackHandle >= 0)
            //{
            //    //如果已经正在回放，先停止回放
            //    if (!CHCNetSDK.NET_DVR_StopPlayBack(PlaybackHandle))
            //    {
            //        var iLastErr = NET_DVR_GetLastError();
            //        throw new Exception("NET_DVR_StopPlayBack failed, error code= " + iLastErr);

            //    }

            //    PlaybackHandle = -1;


            //}

            //CHCNetSDK.NET_DVR_VOD_PARA struVodPara = new CHCNetSDK.NET_DVR_VOD_PARA();
            //struVodPara.dwSize = (uint)Marshal.SizeOf(struVodPara);
            //struVodPara.struIDInfo.dwChannel = 1; //通道号 Channel number  
            //struVodPara.hWnd = pic.Handle;//回放窗口句柄

            ////设置回放的开始时间 Set the starting time to search video files
            //struVodPara.struBeginTime.dwYear = y1;
            //struVodPara.struBeginTime.dwMonth = m1;
            //struVodPara.struBeginTime.dwDay = d1;
            //struVodPara.struBeginTime.dwHour = h1;
            //struVodPara.struBeginTime.dwMinute = min1;
            //struVodPara.struBeginTime.dwSecond = s1;
            ////2018/6/3/9/53/0 ~ 2018/6/3/9/55/20

            ////设置回放的结束时间 Set the stopping time to search video files
            //struVodPara.struEndTime.dwYear = y2;
            //struVodPara.struEndTime.dwMonth = m2;
            //struVodPara.struEndTime.dwDay = d2;
            //struVodPara.struEndTime.dwHour = h2;
            //struVodPara.struEndTime.dwMinute = min2;
            //struVodPara.struEndTime.dwSecond = s2;

            ////按时间回放 Playback by time



            //PlaybackHandle = CHCNetSDK.NET_DVR_PlayBackByTime_V40(UserId, ref struVodPara);
            //if (PlaybackHandle < 0)
            //{
            //    var iLastErr = NET_DVR_GetLastError();
            //    throw new Exception("NET_DVR_PlayBackByTime_V40 failed, error code= " + iLastErr);

            //}

            //uint iOutValue = 0;
            //if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(PlaybackHandle, CHCNetSDK.NET_DVR_PLAYSTART, IntPtr.Zero, 0, IntPtr.Zero, ref iOutValue))
            //{
            //    var iLastErr = NET_DVR_GetLastError();
            //    throw new Exception("NET_DVR_PLAYSTART failed, error code= " + iLastErr);


            //}

        }

        public void Playfast()
        {
            if (PlaybackHandle < 0)
            {
                throw new Exception("Please start playback firstly");

            }
            uint iOutValue = 0;

            if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(PlaybackHandle, CHCNetSDK.NET_DVR_PLAYFAST, IntPtr.Zero, 0, IntPtr.Zero, ref iOutValue))
            {
                var iLastErr = NET_DVR_GetLastError();
                throw new Exception("NET_DVR_PLAYFAST failed, error code= " + iLastErr);

            }
        }

        public void Playslow()
        {
            if (PlaybackHandle < 0)
            {
                throw new Exception("Please start playback firstly");

            }
            uint iOutValue = 0;

            if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(PlaybackHandle, CHCNetSDK.NET_DVR_PLAYSLOW, IntPtr.Zero, 0, IntPtr.Zero, ref iOutValue))
            {
                var iLastErr = NET_DVR_GetLastError();
                throw new Exception("NET_DVR_PLAYSLOW failed, error code= " + iLastErr);

            }

        }

        public void Playpause()
        {
            if (PlaybackHandle < 0)
            {
                throw new Exception("Please start playback firstly");

            }
            uint iOutValue = 0;


            if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(PlaybackHandle, CHCNetSDK.NET_DVR_PLAYPAUSE, IntPtr.Zero, 0, IntPtr.Zero, ref iOutValue))
            {
                var iLastErr = NET_DVR_GetLastError();
                throw new Exception("NET_DVR_PLAYPAUSE failed, error code= " + iLastErr);

            }




        }

        public void Playstart()
        {
            if (PlaybackHandle < 0)
            {
                throw new Exception("Please start playback firstly");

            }
            uint iOutValue = 0;
            if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(PlaybackHandle, CHCNetSDK.NET_DVR_PLAYRESTART, IntPtr.Zero, 0, IntPtr.Zero, ref iOutValue))
            {
                var iLastErr = NET_DVR_GetLastError();
                throw new Exception("NET_DVR_PLAYRESTART failed, error code= " + iLastErr);

            }
        }

        public void Playnormal()
        {
            if (PlaybackHandle < 0)
            {
                throw new Exception("Please start playback firstly");

            }
            uint iOutValue = 0;

            if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(PlaybackHandle, CHCNetSDK.NET_DVR_PLAYNORMAL, IntPtr.Zero, 0, IntPtr.Zero, ref iOutValue))
            {
                var iLastErr = NET_DVR_GetLastError();
                throw new Exception("NET_DVR_PLAYNORMAL failed, error code= " + iLastErr);

            }

        }

        public void StopPlayback()
        {
            if (PlaybackHandle < 0)
            {
                return;
            }

            //停止回放
            if (!CHCNetSDK.NET_DVR_StopPlayBack(PlaybackHandle))
            {
                var iLastErr = NET_DVR_GetLastError();
                throw new Exception("NET_DVR_StopPlayBack failed, error code= " + iLastErr);

            }
            PlaybackHandle = -1;


        }

        public int GetPlaybackProgress()
        {

            uint iOutValue = 0;
            int iPos = 0;

            IntPtr lpOutBuffer = Marshal.AllocHGlobal(4);

            //获取回放进度
            if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(PlaybackHandle, CHCNetSDK.NET_DVR_PLAYGETPOS, IntPtr.Zero, 0,
                lpOutBuffer, ref iOutValue))
            {
                var iLastErr = NET_DVR_GetLastError();
                throw new Exception("NET_DVR_PLAYGETPOS failed, error code= " + iLastErr);
            }

            iPos = (int)Marshal.PtrToStructure(lpOutBuffer, typeof(int));
            Marshal.FreeHGlobal(lpOutBuffer);
            return iPos;

        }

        public int GetDownloadProgress()
        {


            int iPos = 0;
            if ((iPos = CHCNetSDK.NET_DVR_GetDownloadPos(DownloadHandle)) < 0)
            {
                var iLastErr = NET_DVR_GetLastError();
                throw new Exception("NET_DVR_GetDownloadPos failed, error code= " + iLastErr);

            }

            return iPos;

        }

        public void Download(string sPlayBackFileName)
        {
            if (DownloadHandle >= 0)
            {
                throw new Exception("正在下载，请先停止下载！");

            }

            var sVideoFileName = sPlayBackFileName + ".mp4";

            //按文件名下载 Download by file name
            DownloadHandle = CHCNetSDK.NET_DVR_GetFileByName(UserId, sPlayBackFileName, sVideoFileName);
            if (DownloadHandle < 0)
            {
                var iLastErr = NET_DVR_GetLastError();
                throw new Exception("NET_DVR_GetFileByName failed, error code= " + iLastErr);

            }

            uint iOutValue = 0;
            if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(DownloadHandle, CHCNetSDK.NET_DVR_PLAYSTART, IntPtr.Zero, 0, IntPtr.Zero, ref iOutValue))
            {
                var iLastErr = NET_DVR_GetLastError();
                throw new Exception("NET_DVR_PLAYSTART failed, error code= " + iLastErr);


            }


        }

        public void DownloadStop()
        {
            if (DownloadHandle < 0)
            {
                return;
            }

            if (!CHCNetSDK.NET_DVR_StopGetFile(DownloadHandle))
            {
                var iLastErr = NET_DVR_GetLastError();
                throw new Exception("NET_DVR_StopGetFile failed, error code= " + iLastErr);
                //下载控制失败，输出错误号

            }

            DownloadHandle = -1;


        }




    }
}