using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord.Controls;
using Accord.Video;
using Accord.Video.DirectShow;
using Accord.Video.FFMPEG;
using System.Diagnostics;

namespace BVDentalCareSystem.SelfDefinedControls
{
    public enum VideoType
    {
        UNKNOWN = -1,
        LOCAL_DEVICE = 0,
        MJPEG = 1,
        VIDEO_FILE = 2
    }

    //继承Accord.Controls.VideoSourcePlayer， 增加录像，截图等功能
    public partial class VideoPlayer :  VideoSourcePlayer
    {
        //private System.Windows.Forms.Timer timer;
        //private Stopwatch stopWatch = null;

        public VideoPlayer()
        {
            InitializeComponent();
            //timer = new Timer();
            this.
            this.NewFrameReceived += new Accord.Video.NewFrameEventHandler(this.videoSourcePlayer_NewFrame);
        }

        //打开本地的设备, MJPEG, 本地文件夹
        public bool PlayVideo(string inputStr)
        {
            VideoType vt = CheckVideoType(inputStr);
            if (vt == VideoType.UNKNOWN)
                return false;
            else if (vt == VideoType.LOCAL_DEVICE)
            {
                OpenLocalDevice(inputStr);
            }
            else if (vt == VideoType.MJPEG)
            {
                OpenMJPEGDevice(inputStr);
            }
            else if (vt == VideoType.VIDEO_FILE)
            {
                OpenVideoFile(inputStr);
            }
            return true;
        }

        private bool OpenLocalDevice(string deviceName)
        {
            bool isFindDevice = false;
            //得到本地所有的视频设备
            var videoDeviceList = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            //遍历这些设备，寻找名字为BV Camera的设备
            string targetDeviceMonikerString = null;
            foreach (var target in videoDeviceList)
            {
                if (target.Name == deviceName) //"BV USB Camera" "SKT-OL400C-13A"
                {
                    targetDeviceMonikerString = target.MonikerString;
                    isFindDevice = true;
                    break;
                }
            }
            if (!isFindDevice)
                return false;
            var videoSource = new VideoCaptureDevice(targetDeviceMonikerString);
            OpenVideoSource(videoSource);
            return true;
        }

        private bool OpenMJPEGDevice(string ip)
        {
            bool isPingOk = PingTest();
            if (!isPingOk)
                return false;
            MJPEGStream mjpegSource = new MJPEGStream("http://10.10.10.254:8080");
            OpenVideoSource(mjpegSource);
            return true;
        }

        private bool OpenVideoFile(string filePath)
        {
            if (!System.IO.File.Exists(filePath)) //文件是否存在
                return false;
            FileVideoSource fileSource = new FileVideoSource(filePath);
            OpenVideoSource(fileSource);
            return true;
        }

        //打开视频
        private void OpenVideoSource(IVideoSource source)
        {
            // set busy cursor
            this.Cursor = Cursors.WaitCursor;

            // stop current video source
            CloseCurrentVideoSource();

            // start new video source
            this.VideoSource = source;
            this.Start();

            // reset stop watch
            //stopWatch = null;

            // start timer
           // timer.Start();

            this.Cursor = Cursors.Default;

        }

        private void CloseCurrentVideoSource()
        {
            if (this.VideoSource != null)
            {
                this.SignalToStop();

                // wait ~ 3 seconds
                for (int i = 0; i < 30; i++)
                {
                    if (!this.IsRunning)
                        break;
                    System.Threading.Thread.Sleep(100);
                }

                if (this.IsRunning)
                {
                    this.Stop();
                }

                this.VideoSource = null;
            }
        }

        private void videoSourcePlayer_NewFrame(object sender, NewFrameEventArgs args)
        {
            DateTime now = DateTime.Now;
            Graphics g = Graphics.FromImage(args.Frame);

            // paint current time
            SolidBrush brush = new SolidBrush(Color.Red);
            g.DrawString(now.ToString(), this.Font, brush, new PointF(5, 5));
            brush.Dispose();

            g.Dispose();


            if (isNeedRecord)
            {
                using (var bitmap = (Bitmap)args.Frame.Clone())
                {
                    if (_firstFrameTime != null)
                    {
                        //_writer.WriteVideoFrame(bitmap, DateTime.Now - _firstFrameTime.Value);
                        _writer.WriteVideoFrame(bitmap);
                    }
                    else
                    {
                        _writer.WriteVideoFrame(bitmap);
                        _firstFrameTime = DateTime.Now;
                    }
                }
            }


        }


        public bool PingTest()
        {
            System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingReply pingStatus =
                ping.Send(System.Net.IPAddress.Parse("10.10.10.254"), 1000);

            if (pingStatus.Status == System.Net.NetworkInformation.IPStatus.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // On timer event - gather statistics
        //private void timer_Tick(object sender, EventArgs e)
        //{
        //    IVideoSource videoSource = this.VideoSource;

        //    if (videoSource != null)
        //    {
        //        // get number of frames since the last timer tick
        //        int framesReceived = videoSource.FramesReceived;

        //        if (stopWatch == null)
        //        {
        //            stopWatch = new Stopwatch();
        //            stopWatch.Start();
        //        }
        //        else
        //        {
        //            stopWatch.Stop();

        //            float fps = 1000.0f * framesReceived / stopWatch.ElapsedMilliseconds;
        //            fpsLabel.Text = fps.ToString("F2") + " fps";

        //            stopWatch.Reset();
        //            stopWatch.Start();
        //        }
        //    }
        //}

        private VideoType CheckVideoType(string inputString)
        {
            if (inputString.Contains("SKT") || inputString.Contains("BV"))
                return VideoType.LOCAL_DEVICE;
            else if (inputString.Contains("10.10"))
                return VideoType.MJPEG;
            else if (inputString.Contains(".avi"))
                return VideoType.VIDEO_FILE;
            else
                return VideoType.UNKNOWN;
        }


    }
}
