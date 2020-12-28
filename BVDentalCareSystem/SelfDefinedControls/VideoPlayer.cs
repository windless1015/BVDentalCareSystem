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
        public bool doubleClickChangeSize { get; set; } //双击改变窗口size
        public bool isStopped = false; //是否已经停止
        public bool isRecording = false; //是否在录制
        public bool isPlaying = false; //是否正在播放
        private VideoFileWriter aviWriter = null;
        private DateTime? _firstFrameTime = null;
        private Size frameSize; //帧的size
        private VideoType vt;
        private string inputString = null;

        public VideoPlayer()
        {
            InitializeComponent();
            this.NewFrame += new NewFrameHandler(this.videoSourcePlayer_NewFrame);
            doubleClickChangeSize = false;
            this.KeepAspectRatio = true;
        }

        //打开本地的设备, MJPEG, 本地文件夹
        public bool PlayVideo(string inputStr)
        {
            inputString = inputStr;
            vt = CheckVideoType(inputStr);
            if (vt == VideoType.UNKNOWN)
                return false;
            else if (vt == VideoType.LOCAL_DEVICE)
            {
                OpenLocalDevice(inputStr);
                //还要判断是是哪个设备
                if (inputStr == "BV USB Camera")
                {
                    frameSize = new Size(400, 400);
                }
                else
                {
                    frameSize = new Size(1280, 720);
                }
                isPlaying = true;
            }
            else if (vt == VideoType.MJPEG)
            {
                OpenMJPEGDevice(inputStr);
                frameSize = new Size(640, 480);
                isPlaying = true;
            }
            else if (vt == VideoType.VIDEO_FILE)
            {
                OpenVideoFile(inputStr);
            }
            return true;
        }

        public void StartRecord(string aviSavedFile)
        {
            _firstFrameTime = null;
            aviWriter = new VideoFileWriter();
            aviWriter.Open(aviSavedFile, frameSize.Width, frameSize.Height, 25, VideoCodec.MPEG4, 4000 * 1000);
            isRecording = true;
        }

        public void FinishRecord()
        {
            isRecording = false;
            aviWriter.Close();
            aviWriter.Dispose();
        }

        public Bitmap TakeSnapshot(string file, bool isNeedReturenSnapshot)
        {
            Bitmap singleFrame = this.GetCurrentVideoFrame();
            singleFrame.Save(file, System.Drawing.Imaging.ImageFormat.Jpeg);
            if (isNeedReturenSnapshot)
                return singleFrame;
            else
                return null;
        }

        public void PauseVideo()
        {
            this.SignalToStop();
        }

        public void ReStartVideo()
        {
            this.Start();
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
            bool isPingOk = PingTest(ref ip);
            if (!isPingOk)
                return false;
            MJPEGStream mjpegSource = new MJPEGStream(ip);
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
            this.Cursor = Cursors.WaitCursor;
            CloseCurrentVideoSource();

            this.VideoSource = source;
            this.Start();

            this.Cursor = Cursors.Default;
        }

        private void CloseCurrentVideoSource()
        {
            if (this.VideoSource != null)
            {
                this.SignalToStop();

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
            isPlaying = false;
        }

        private void videoSourcePlayer_NewFrame(object sender, ref Bitmap image)
        {
            if (isRecording)
            {
                DateTime now = DateTime.Now;
                Graphics g = Graphics.FromImage(image);

                SolidBrush brush = new SolidBrush(Color.Red);
                g.DrawString(now.ToString(), this.Font, brush, new PointF(30, 10)); //画当前时间
                //if ((int)(now.Subtract(flickerDTime).TotalSeconds) == 3)
                //{
                //    g.FillRectangle(brush, new Rectangle(10, 10, 10, 10)); // 画闪烁的红色的实心方框
                //    flickerDTime = now;
                //}
                brush.Dispose();
                g.Dispose();

                using (var bitmap = (Bitmap)image.Clone())
                {
                    if (_firstFrameTime != null)
                    {
                        aviWriter.WriteVideoFrame(bitmap);
                    }
                    else
                    {
                        aviWriter.WriteVideoFrame(bitmap);
                        _firstFrameTime = DateTime.Now;
                    }
                }
            }


        }

        public bool PingTest(ref string ip)
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


        //双击播放器区域
        private void VideoPlayer_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //只有当在播放本地文件的时候，双击才有用
            //if (!doubleClickChangeSize)
            //    return;
            if (vt == VideoType.VIDEO_FILE)
            {
                //CloseCurrentVideoSource();

            }
            
            //this.ClientRectangle
            //this.Size = new Size(800, 800);
        }
    }
}
