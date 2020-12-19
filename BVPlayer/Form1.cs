using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;

namespace vlc.net
{
    public partial class Form1 : Form
    {
        private VlcPlayer vlc_player_;
        private bool is_playing;
        public string folderPath;
        public string needPlayFile;
        private int playIndex = 0;
        private string[] videoPaths;
        public Form1()
        {
            InitializeComponent();

            string pluginPath = System.Environment.CurrentDirectory + "\\plugins\\";
            vlc_player_ = new VlcPlayer(pluginPath);
            IntPtr render_wnd = this.panel_player.Handle;
            vlc_player_.SetRenderWindow((int)render_wnd);
            is_playing = false;


        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            playVideo(playIndex);
        }

        private void playVideo(int index)
        {
            if (is_playing)
            {
                vlc_player_.Stop();
                is_playing = false;
            }
            vlc_player_.PlayFile(videoPaths[index]);
            trackBar_playProgress.SetRange(0, (int)vlc_player_.Duration());
            trackBar_playProgress.Value = 0;
            timer1.Start();
            is_playing = true;
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
               vlc_player_.Stop();
               trackBar_playProgress.Value = 0;
               timer1.Stop();
               is_playing = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (is_playing)
            {
                if (trackBar_playProgress.Value == trackBar_playProgress.Maximum)
                {
                    vlc_player_.Stop();
                    timer1.Stop();
                }
                else
                {
                    trackBar_playProgress.Value = trackBar_playProgress.Value + 1;
                    tbVideoTime.Text = string.Format("{0}/{1}", 
                        GetTimeString(trackBar_playProgress.Value), 
                        GetTimeString(trackBar_playProgress.Maximum));
                }
            }
        }

        private string GetTimeString(int val)
        {
            int hour = val / 3600;
            val %= 3600;
            int minute = val / 60;
            int second = val % 60;
            return string.Format("{0:00}:{1:00}:{2:00}", hour, minute, second);
        }

        private void trackBar_playProgress_Scroll(object sender, EventArgs e)
        {
               vlc_player_.SetPlayTime(trackBar_playProgress.Value);
               Thread.Sleep(10);
               trackBar_playProgress.Value = (int)vlc_player_.GetPlayTime();

        }

        private void btn_fastForward_Click(object sender, EventArgs e)
        {
            if (is_playing)
            {
                vlc_player_.Pause();
                timer1.Stop();
                if (trackBar_playProgress.Value < trackBar_playProgress.Maximum)
                {
                    trackBar_playProgress.Value = trackBar_playProgress.Value + 1;
                    vlc_player_.SetPlayTime(trackBar_playProgress.Value);
                    is_playing = true;
                    vlc_player_.Pause();
                    timer1.Start();
                }
                else
                {
                    vlc_player_.SetPlayTime(trackBar_playProgress.Maximum);
                }
                trackBar_playProgress.Value = (int)vlc_player_.GetPlayTime();
            }
            else 
            {
                trackBar_playProgress.Value = trackBar_playProgress.Value + 1;
                if (trackBar_playProgress.Value < trackBar_playProgress.Maximum)
                {
                    vlc_player_.SetPlayTime(trackBar_playProgress.Value);
                    vlc_player_.Pause();
                    is_playing = true;
                    timer1.Start();

                }
                else
                {
                    vlc_player_.SetPlayTime(trackBar_playProgress.Maximum);
                }
                trackBar_playProgress.Value = (int)vlc_player_.GetPlayTime();
            }
        }

        private void btn_fastBackward_Click(object sender, EventArgs e)
        {
            if (is_playing)
            {
                vlc_player_.Pause();
                timer1.Stop();
                if (trackBar_playProgress.Value > trackBar_playProgress.Minimum)
                {
                    trackBar_playProgress.Value = trackBar_playProgress.Value - 1;
                    vlc_player_.SetPlayTime(trackBar_playProgress.Value);
                    is_playing = true;
                    vlc_player_.Pause();
                    timer1.Start();
                }
                else
                {
                    vlc_player_.Duration();
                    vlc_player_.SetPlayTime(trackBar_playProgress.Minimum);
                }
                trackBar_playProgress.Value = (int)vlc_player_.GetPlayTime();
            }
            else
            {
                trackBar_playProgress.Value = trackBar_playProgress.Value - 1;
                if (trackBar_playProgress.Value > trackBar_playProgress.Minimum)
                {
                    vlc_player_.SetPlayTime(trackBar_playProgress.Value);
                    vlc_player_.Pause();
                    is_playing = true;
                    timer1.Start();

                }
                else
                {
                    vlc_player_.SetPlayTime(trackBar_playProgress.Minimum);
                }
                trackBar_playProgress.Value = (int)vlc_player_.GetPlayTime();
            }
        }

        private void btnPauseOrResume_Click_1(object sender, EventArgs e)
        {
            if (is_playing)
            {
                vlc_player_.Pause();
                timer1.Stop();
                is_playing = false;
            }
            else
            {
                vlc_player_.Pause();
                timer1.Start();
                is_playing = true;
            }
        }

        private void videoList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void DescendSortVideoFiles()
        {
            videoPaths = Directory.GetFiles(folderPath, "*.avi");
            List<FileInfo> videoFileInfoList = new List<FileInfo>();
            foreach (var item in videoPaths)
            {
                FileInfo fileInfo = new FileInfo(item);
                videoFileInfoList.Add(fileInfo);
            }
            //把item根据时间降序排列
            videoFileInfoList.Sort((x, y) => y.LastWriteTime.CompareTo(x.LastWriteTime));

            //把videoPaths清空,然后再重新插入视频的地址
            List<string> newVideoPathDescendent = new List<string>();
            foreach (var item in videoFileInfoList)
            {
                newVideoPathDescendent.Add(item.FullName);
            }
            videoPaths = newVideoPathDescendent.ToArray();

            int count = 0;
            string needPlayFileNakeName = needPlayFile.Substring(needPlayFile.LastIndexOf(@"\") + 1);
            foreach (var item in videoFileInfoList)
            {
                string fileName = item.Name;
                videoList.Items.Add(fileName);
                if (needPlayFileNakeName == fileName)
                {
                    playIndex = count;
                }
                count++;
            }

            playVideo(playIndex);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DescendSortVideoFiles();
        }

        private void videoList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.videoList.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                playVideo(index);
            }
        }
    }
}
