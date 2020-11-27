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

namespace BVDentalCareSystem.SelfDefinedControls
{
    public partial class VideoPlayerForm : Form
    {
        private Video video = null;

        public VideoPlayerForm()
        {
            InitializeComponent();
        }

        private void VideoPlayerForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnVideoPlayerExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVideoPlayOrResume_Click(object sender, EventArgs e)
        {
            if (!video.Playing)
            {
                video.Play();
                btnVideoPlayOrResume.BackgroundImage = Properties.Resources.playVideoPause;
            }
            else if (video.Playing)
            {
                video.Pause();
                btnVideoPlayOrResume.BackgroundImage = Properties.Resources.playVideoResume;
            }
        }

        private void VideoPlayerForm_Load(object sender, EventArgs e)
        {

        }

        public void StartPlayVideoFile(ref string videoFile)
        {
            //int a = 1;
            //if (video != null)
            //{
            //    video.Dispose();
            //    video = null;
            //}
            //video = new Video(videoFile, false);
            //video.Owner = playPanel;
            //video.Play();

        }

    }
}
