using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
namespace vlc.net
{
    public partial class Form1 : Form
    {
        private VlcPlayer vlc_player_;
        private bool is_playinig_;
        public string folderPath;
        public string needPlayFile;
        public Form1()
        {
            InitializeComponent();

            string pluginPath = System.Environment.CurrentDirectory + "\\plugins\\";
            vlc_player_ = new VlcPlayer(pluginPath);
            IntPtr render_wnd = this.panel_player.Handle;
            vlc_player_.SetRenderWindow((int)render_wnd);

            tbVideoTime.Text = "00:00:00/00:00:00";
            is_playinig_ = false;

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            vlc_player_.PlayFile(needPlayFile);
            trackBar_playProgress.SetRange(0, (int)vlc_player_.Duration());
            trackBar_playProgress.Value = 0;
            timer1.Start();
            is_playinig_ = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (is_playinig_)
            {
                vlc_player_.Stop();
                trackBar_playProgress.Value = 0;
                timer1.Stop();
                is_playinig_ = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (is_playinig_)
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
            if (is_playinig_)
            {
                vlc_player_.SetPlayTime(trackBar_playProgress.Value);
                Thread.Sleep(10);
                trackBar_playProgress.Value = (int)vlc_player_.GetPlayTime();

//                 vlc_player_.SetPlayTime(trackBar1.Value);
//                 if ((int)vlc_player_.GetPlayTime()>trackBar1.Maximum)
//                 {
//                     trackBar1.Value = value;
//                     vlc_player_.SetPlayTime(trackBar1.Value);
//                 }
//                 else
//                 {
//                     trackBar1.Value = (int)vlc_player_.GetPlayTime();
//                 }
                
            }
        }

        private void btn_fastForward_Click(object sender, EventArgs e)
        {
            if (is_playinig_)  //is_playinig_ == true
            {
                vlc_player_.Pause();//暂停
                timer1.Stop();
                //int time = (int)vlc_player_.GetPlayTime() + 5;
                trackBar_playProgress.Value = trackBar_playProgress.Value + 5;

                if (trackBar_playProgress.Value < trackBar_playProgress.Maximum)
                {
                    vlc_player_.SetPlayTime(trackBar_playProgress.Value);  //设置快进后的时间点
                    is_playinig_ = true;
                    vlc_player_.Pause();
                    timer1.Start();
                }
                else
                {
                    vlc_player_.SetPlayTime(trackBar_playProgress.Maximum);
                }
                //vlc_player_.Pause();
                trackBar_playProgress.Value = (int)vlc_player_.GetPlayTime();
            }
            else //is_playinig_ == false
            {
                //int time = (int)vlc_player_.GetPlayTime() + 5;
                trackBar_playProgress.Value = trackBar_playProgress.Value + 5;
                if (trackBar_playProgress.Value < trackBar_playProgress.Maximum)
                {
                    vlc_player_.SetPlayTime(trackBar_playProgress.Value);
                    vlc_player_.Pause();
                    is_playinig_ = true;
                    timer1.Start();

                }
                else
                {
                    vlc_player_.SetPlayTime(trackBar_playProgress.Maximum);
                }
                //vlc_player_.Pause();
                trackBar_playProgress.Value = (int)vlc_player_.GetPlayTime();
            }
        }

        private void btn_fastBackward_Click(object sender, EventArgs e)
        {
            if (is_playinig_)  //is_playinig_ == true
            {
                vlc_player_.Pause();//暂停
                timer1.Stop();
                //int time = (int)vlc_player_.GetPlayTime() - 5;
                trackBar_playProgress.Value = trackBar_playProgress.Value - 10;

                if (trackBar_playProgress.Value > trackBar_playProgress.Minimum)
                {
                    vlc_player_.SetPlayTime(trackBar_playProgress.Value);  //设置快退后的时间点
                    is_playinig_ = true;
                    vlc_player_.Pause();
                    timer1.Start();
                }
                else
                {
                    vlc_player_.SetPlayTime(trackBar_playProgress.Minimum);
                }
                //vlc_player_.Pause();
                trackBar_playProgress.Value = (int)vlc_player_.GetPlayTime();
            }
            else //is_playinig_ == false
            {
                //int time = (int)vlc_player_.GetPlayTime() - 5;
                trackBar_playProgress.Value = trackBar_playProgress.Value - 5;
                if (trackBar_playProgress.Value > trackBar_playProgress.Minimum)
                {
                    vlc_player_.SetPlayTime(trackBar_playProgress.Value);
                    vlc_player_.Pause();
                    is_playinig_ = true;
                    timer1.Start();

                }
                else
                {
                    vlc_player_.SetPlayTime(trackBar_playProgress.Minimum);
                }
                //vlc_player_.Pause();
                trackBar_playProgress.Value = (int)vlc_player_.GetPlayTime();
            }
        }

        private void btnPauseOrResume_Click_1(object sender, EventArgs e)
        {
            if (is_playinig_)
            {
                vlc_player_.Pause();

                //timer1.Start();
                timer1.Stop();
                is_playinig_ = false;
            }
            else
            {
                vlc_player_.Pause();
                timer1.Start();
                is_playinig_ = true;
            }
        }
    }
}
