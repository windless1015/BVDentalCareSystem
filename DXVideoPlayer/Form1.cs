using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.DirectX.AudioVideoPlayback;
using System.IO;

namespace DXVideoPlayer
{
    public partial class Form1 : Form
    {
        private Video video;
        private string[] videoPaths;
        public string folderPath { get; set; }
        public string needPlayFile { get; set; }
        private int selectedIndex = 0;
        private Size originalFormSize;
        private Size originalPanelVideoSize;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            originalFormSize = new Size(this.Width, this.Height);
            originalPanelVideoSize = new Size(pnlVideo.Width, pnlVideo.Height);
            ReorderVideoFiles();
        }

        private void lstVideos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                video.Stop();
                video.Dispose();
            }
            catch { }

            int index = lstVideos.SelectedIndex;
            selectedIndex = index;
            video = new Video(videoPaths[index], false);
            video.Owner = pnlVideo;
            pnlVideo.Size = originalPanelVideoSize;
            //pnlVideo.Size = new Size(pnlVideo.Width, pnlVideo.Height);
            video.Play();
            tmrVideo.Enabled = true;
            btnPlayPause.Text = "暂停";
            video.Ending += Video_Ending; //视频播放结束
            //lblVideo.Text = lstVideos.Text;

            trackBar.Minimum = 0;
            trackBar.Maximum = 100;
            trackBar.SmallChange = 1;
            trackBar.LargeChange = 1;
            trackBar.Value = 0;
        }

        private void Video_Ending(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                //System.Threading.Thread.Sleep(2000);

                if (InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        //NextVideo();
                        video.Stop();
                        btnPlayPause.Text = "播放";
                    }));
                }
            });
        }

        private void NextVideo()
        {
            int index = lstVideos.SelectedIndex;
            index++;
            if (index > videoPaths.Length - 1)
                index = 0;
            selectedIndex = index;
            lstVideos.SelectedIndex = index;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            NextVideo();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            PreviousVideo();
        }

        private void PreviousVideo()
        {
            int index = lstVideos.SelectedIndex;
            index--;
            if (index == -1)
                index = videoPaths.Length - 1;
            selectedIndex = index;
            lstVideos.SelectedIndex = index;
        }

        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            if (!video.Playing)
            {
                video.Play();
                tmrVideo.Enabled = true;
                btnPlayPause.Text = "暂停";
            }
            else if (video.Playing)
            {
                video.Pause();
                tmrVideo.Enabled = false;
                btnPlayPause.Text = "播放";
            }
            else if (video.Stopped) //重新播放
            {
                video.Play();
                tmrVideo.Enabled = true;
                btnPlayPause.Text = "暂停";
            }
        }

        private void btnFullscreen_Click(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            video.Owner = this;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
                this.Size = originalFormSize;
                video.Owner = pnlVideo;
                pnlVideo.Size = originalPanelVideoSize;
            }
        }

        private void tmrVideo_Tick(object sender, EventArgs e)
        {
            int currentTime = Convert.ToInt32(video.CurrentPosition);
            int maxTime = Convert.ToInt32(video.Duration);
            lblVideoPosition.Text = string.Format("{0:00}:{1:00}:{2:00}", currentTime / 3600, (currentTime / 60) % 60, currentTime % 60)
                                    + " / " + string.Format("{0:00}:{1:00}:{2:00}", maxTime / 3600, (maxTime / 60) % 60, maxTime % 60);
            trackBar.Value = Convert.ToInt32(video.CurrentPosition * 100 / video.Duration);
        }


        private void trackBar_Scroll(object sender, EventArgs e)
        {
            if (video == null)
                return;
            //根据trackbar的最大值,这里设置的是100,然后根据视频的总长度   Convert.ToInt32(video.Duration)
            double r = trackBar.Value / 100.0;
            video.CurrentPosition = r * video.Duration;
        }

        private void trackBar_MouseDown(object sender, MouseEventArgs e)
        {
            ////trackbar滑到当前位置
            //double dblValue = ((double)e.X / (double)trackBar.Width) * (trackBar.Maximum - trackBar.Minimum);
            //trackBar.Value = Convert.ToInt32(dblValue);
            ////video.CurrentPosition = dblValue;
            //Console.WriteLine(dblValue.ToString());

            //tmrVideo.Stop();
            //video.Pause();
        }

        private void trackBar_MouseUp(object sender, MouseEventArgs e)
        {
            //tmrVideo.Start();
            //video.Play();
        }

        private void ReorderVideoFiles()
        {
            videoPaths = Directory.GetFiles(folderPath, "*.avi");
            List<FileInfo> videoList = new List<FileInfo>();
            foreach (var item in videoPaths)
            {
                FileInfo fileInfo = new FileInfo(item);
                //DateTime t = fileInfo.LastWriteTime; //这里用LastWriteTime 更合理
                videoList.Add(fileInfo);
            }
            //把item根据时间降序排列
            videoList.Sort((x, y) => y.LastWriteTime.CompareTo(x.LastWriteTime));
            int count = 0;
            foreach (var item in videoList)
            {
                string fileName = item.Name;
                lstVideos.Items.Add(fileName);
                if (needPlayFile == fileName)
                {
                    selectedIndex = count++;
                }
            }
            lstVideos.SelectedIndex = selectedIndex;
        }

    }
}
