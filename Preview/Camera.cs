using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static Preview.CHCNetSDK;


namespace Preview
{

    class VideoCapture
    {
        private Camera CamLeft { get; }
        private Camera CamRight { get; }

        public (Bitmap leftBitmap, Bitmap rightBitmap) BitMapPicture => CaptureBMP();
        public bool IsPreviewing;

        public VideoCapture(DVRLoginInfo leftDvrLoginInfo,DVRLoginInfo rightDvrLoginInfo)
        {
            if (!CHCNetSDK.NET_DVR_Init())
            {
                throw new Exception("NET_DVR_Init error!");
            }
            CamLeft=new Camera(leftDvrLoginInfo.DVRIPAddress,leftDvrLoginInfo.DVRPortNumber,
                leftDvrLoginInfo.DVRUserName,leftDvrLoginInfo.DVRPassword);
            CamRight=new Camera(rightDvrLoginInfo.DVRIPAddress,rightDvrLoginInfo.DVRPortNumber,
                rightDvrLoginInfo.DVRUserName,rightDvrLoginInfo.DVRPassword);
            IsPreviewing = false;
        }



        public bool Login()
        {
            return CamLeft.Login() && CamRight.Login();
        }


        public void StartPreview(IntPtr HandleA,IntPtr HandleB)
        {
            CamLeft.StartPreview(HandleA);
            CamRight.StartPreview(HandleB);
            IsPreviewing = true;
        }

        public void StopPreview()
        {
            CamLeft.StopPreview();
            CamRight.StopPreview();
            IsPreviewing = false;
        }

        /// <summary>
        /// Capture BMP maps
        /// </summary>
        /// <returns>bmpMaps[0] lightImg,bmpMaps[1] baseImg</returns>
        public (Bitmap leftBitmap, Bitmap rightBitmap) CaptureBMP()
        {
            const string leftImgName = "Left.bmp";
            const string rightImgName = "Right.bmp";
            if (File.Exists(leftImgName))
            {
                File.Delete(leftImgName);
            }

            if (File.Exists(rightImgName))
            {
                File.Delete(rightImgName);
            }

            if (!NET_DVR_CapturePicture(CamLeft.RealPlayHandle, leftImgName)&&!NET_DVR_CapturePicture(CamRight.RealPlayHandle, rightImgName))
            {
                var iLastErr = NET_DVR_GetLastError();
                throw new Exception("NET_DVR_CapturePicture failed, error code= " + iLastErr);
            }
            
            return ( new Bitmap(leftImgName), new Bitmap(rightImgName) );

        }

        public void Record()
        {

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
        public string DVRIPAddress { get; set; }
        public short DVRPortNumber { get; set; }
        public string DVRUserName { get; set; }
        public string DVRPassword { get; set; }

        public IntPtr User;
        public int RealPlayHandle;
        public REALDATACALLBACK RealData=null;

        public NET_DVR_DEVICEINFO_V30 DeviceInfo;
        private NET_DVR_PREVIEWINFO lpPreviewInfo;

        public IntPtr CamHandle;
        public int UserID;

        public Camera(string ipAddress,short port, string userName, string password)
        {
            DVRIPAddress = ipAddress;
            DVRPortNumber = port;
            DVRUserName = userName;
            DVRPassword = password;

            DeviceInfo=new NET_DVR_DEVICEINFO_V30();
            User = new IntPtr();

        }

        private Camera(){  }

        public bool Login()
        {
            UserID= NET_DVR_Login_V30(DVRIPAddress, DVRPortNumber, DVRUserName, DVRPassword, ref DeviceInfo);
            if (UserID < 0)
            {
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
            if (UserID >= 0)
            {
                NET_DVR_Logout(UserID);
            }
        }


        public void StartPreview(IntPtr realPlayWndHandle)
        {
            if (UserID < 0)
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

            RealPlayHandle = NET_DVR_RealPlay_V40(UserID, ref previewInfo, null, User);

        }

        public void StopPreview()
        {
            if(RealPlayHandle>=0)
                NET_DVR_StopRealPlay(RealPlayHandle);
        }

        public void RealDataCallBack(Int32 lRealHandle, UInt32 dwDataType, IntPtr pBuffer, UInt32 dwBufSize, IntPtr pUser)
        {
            if (dwBufSize > 0)
            {
                byte[] sData = new byte[dwBufSize];
                Marshal.Copy(pBuffer, sData, 0, (Int32)dwBufSize);

                string str = "实时流数据.ps";
                FileStream fs = new FileStream(str, FileMode.Create);
                int iLen = (int)dwBufSize;
                fs.Write(sData, 0, iLen);
                fs.Close();
            }
        }

    }
}