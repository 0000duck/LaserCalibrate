using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Preview.Views
{
    public partial class PlayBack : Form
    {
        private VideoCapture videoCapture;
        private string sPlayBackFileName1;
        private string sPlayBackFileName2;
        private ControlClass _controlClass;
        public PlayBack()
        {
            InitializeComponent();
            _controlClass=ControlClass.GetInstance();
            sPlayBackFileName1 = null;
            sPlayBackFileName2 = null;

            videoCapture = _controlClass.videoCap;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!videoCapture.IsPreviewing)
            {
                videoCapture.StartPreview(pictureBox1, pictureBox2);
                //videoCapture.NewdrawOnpreview(xa1, ya1, xa2, ya2, xb1, yb1, xb2, yb2);
                button1.Text = "停止预览";


            }
            else
            {
                videoCapture.StopPreview();
                button1.Text = "开启预览";

            }


        }


        private void button2_Click(object sender, EventArgs e)
        {
            //uint y1 = (uint) dateTimeStart.Value.Year;
            //uint m1 = (uint) dateTimeStart.Value.Month;
            //uint d1 = (uint) dateTimeStart.Value.Day;
            //uint h1 = (uint) dateTimeStart.Value.Hour;
            //uint min1 = (uint) dateTimeStart.Value.Minute;
            //uint s1 = (uint) dateTimeStart.Value.Second;

            ////设置回放的结束时间 Set the stopping time to search video files
            //uint y2 = (uint) dateTimeEnd.Value.Year;
            //uint m2 = (uint) dateTimeEnd.Value.Month;
            //uint d2 = (uint) dateTimeEnd.Value.Day;
            //uint h2 = (uint) dateTimeEnd.Value.Hour;
            //uint min2 = (uint) dateTimeEnd.Value.Minute;
            //uint s2 = (uint) dateTimeEnd.Value.Second;
            if (videoCapture.IsPlaybacking == false)
            {

                videoCapture.StartPlayBack(sPlayBackFileName1, sPlayBackFileName2, pictureBox1, pictureBox2);

                timerplayback.Enabled = true;


                button2.Text = "停止回放";


                //videoCapture.CaptureBMPplayback();

            }
            else
            {

                videoCapture.StopPlayBack();
                PlaybackprogressBar.Value = 0;
                timerplayback.Stop();
                timerplayback.Enabled = false;




                buttonpause.Text = "||";
                labelpause.Text = "暂停";


                button2.Text = "开启回放";


            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (videoCapture.IsRecording == false)
            {
                //强制I帧 Make a I frame
                videoCapture.StartRecord();
                button3.Text = "停止录像";


            }
            else
            {
                //停止录像 Stop recording
                videoCapture.StopRecord();
                button3.Text = "开启录像";
                MessageBox.Show("录像文件已保存至Record_test.mp4");


            }

        }




        private void buttonfast_Click(object sender, EventArgs e)
        {
            videoCapture.Playfast();

        }

        private void buttonpause_Click(object sender, EventArgs e)
        {
            if (videoCapture.IsPausing == false)
            {
                videoCapture.Playpause();
                labelpause.Text = "播放";
                buttonpause.Text = ">";

            }
            else
            {
                videoCapture.Playpause();
                labelpause.Text = "暂停";
                buttonpause.Text = "||";

            }
        }

        private void buttonslow_Click(object sender, EventArgs e)
        {
            videoCapture.Playslow();
        }

        private void buttonnormal_Click(object sender, EventArgs e)
        {
            videoCapture.Playnormal();
        }

        private void timerplayback_Tick(object sender, EventArgs e)
        {

            PlaybackprogressBar.Maximum = 100;
            PlaybackprogressBar.Minimum = 0;

            int iPos = videoCapture.GetPlaybackProgress();

            if ((iPos > PlaybackprogressBar.Minimum) && (iPos < PlaybackprogressBar.Maximum))
            {
                PlaybackprogressBar.Value = iPos;
            }

            if (iPos == 100) //回放结束
            {
                PlaybackprogressBar.Value = iPos;
                videoCapture.StopPlayBack();

                timerplayback.Stop();
            }

            if (iPos == 200) //网络异常，回放失败
            {
                MessageBox.Show("The playback is abnormal for the abnormal network!");
                timerplayback.Stop();
            }




        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            listViewFile1.Items.Clear();
            uint y1 = (uint)dateTimeStart.Value.Year;
            uint m1 = (uint)dateTimeStart.Value.Month;
            uint d1 = (uint)dateTimeStart.Value.Day;
            uint h1 = (uint)dateTimeStart.Value.Hour;
            uint min1 = (uint)dateTimeStart.Value.Minute;
            uint s1 = (uint)dateTimeStart.Value.Second;

            //设置回放的结束时间 Set the stopping time to search video files
            uint y2 = (uint)dateTimeEnd.Value.Year;
            uint m2 = (uint)dateTimeEnd.Value.Month;
            uint d2 = (uint)dateTimeEnd.Value.Day;
            uint h2 = (uint)dateTimeEnd.Value.Hour;
            uint min2 = (uint)dateTimeEnd.Value.Minute;
            uint s2 = (uint)dateTimeEnd.Value.Second;

            string[][] filelist = videoCapture.Findfile(y1, m1, d1, h1, min1, s1, y2, m2, d2, h2, min2, s2);
            for (int i = 0; i + 2 < filelist[0].Length; i = i + 3)
            {
                listViewFile1.Items.Add(new ListViewItem(new string[]
                    {filelist[0][i], filelist[0][i + 1], filelist[0][i + 2]})); //将查找的录像文件添加到列表中

            }
            for (int i = 0; i + 2 < filelist[1].Length; i = i + 3)
            {
                listViewFile1.Items.Add(new ListViewItem(new string[]
                    {filelist[1][i], filelist[1][i + 1], filelist[1][i + 2]})); //将查找的录像文件添加到列表中

            }

        }

        private void listViewFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewFile1.SelectedItems.Count > 0)
            {
                sPlayBackFileName1 = listViewFile1.FocusedItem.SubItems[0].Text;
                sPlayBackFileName2 = listViewFile2.FocusedItem.SubItems[0].Text;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (videoCapture.IsDownloading == false)
            {
                videoCapture.Download(sPlayBackFileName1, sPlayBackFileName2);
                timerDownload.Enabled = true;
                button4.Text = "停止下载";

            }
            else
            {
                videoCapture.DownloadStop();
                DownloadProgressBar.Value = 0;
                timerDownload.Enabled = false;
                button4.Text = "回放下载";
            }

        }

        private void timerDownload_Tick(object sender, EventArgs e)
        {
            DownloadProgressBar.Maximum = 100;
            DownloadProgressBar.Minimum = 0;

            int iPos = videoCapture.GetDownloadProgress();

            if ((iPos > DownloadProgressBar.Minimum) && (iPos < DownloadProgressBar.Maximum))
            {
                DownloadProgressBar.Value = iPos;
            }

            if (iPos == 100)  //下载完成
            {

                videoCapture.DownloadStop();
                DownloadProgressBar.Value = 0;
                timerDownload.Enabled = false;
                button4.Text = "回放下载";
                MessageBox.Show("下载完成！文件已保存至" + sPlayBackFileName1 + ".mp4。");


            }

            if (iPos == 200) //网络异常，下载失败
            {
                MessageBox.Show("The downloading is abnormal for the abnormal network!");
                timerDownload.Stop();
            }

        }
    }
}
