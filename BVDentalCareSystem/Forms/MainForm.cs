using BVDentalCareSystem.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BVDentalCareSystem.SelfDefinedControls;

namespace BVDentalCareSystem
{
    public partial class MainForm : Form
    {
        VideoPlayer videoPlayer = null;
        Accord.Controls.PictureBox picBox = null;
        string displayImageAbsPath = null;
        public MainForm()
        {
            InitializeComponent();
            imageVideoBrowserSideBar.dataPath = @"E:\project\DSDentalEndoscopeViewer\DSDentalEndoscopeViewer\bin\x64\Debug\PatientInfoDir\李伟_1_2020-07-22";
            //imageVideoBrowserSideBar.dataPath = @"F:\projects\Bangvo\DSDentalEndoscopeViewer\DSDentalEndoscopeViewer\bin\x64\Debug\PatientInfoDir\李伟1_1_2020-03-16";
            imageVideoBrowserSideBar.SortOrderByTimeDescend();
            imageVideoBrowserSideBar.GroupItemByDate();

            imageVideoBrowserSideBar.DBClickOpenItemNotify += new ImageVideoBrowserSideBar.DoubleClickOpenItemNotifyHandler(DoubleClickOpenProcessing);

        }

        private void btn_patientInfo_Click(object sender, EventArgs e)
        {
            PatientsInfoForm pif = new PatientsInfoForm();
            pif.TopLevel = false; //重要的一个步骤
            pif.Parent = this.splitContainer.Panel2;
            pif.Location = new Point(0, panel_head.Height + 34);
            pif.Size = new Size(this.splitContainer.Panel2.Width - imageVideoBrowserSideBar.Width - 10, 
                this.splitContainer.Panel2.Height - panel_head.Height - panel_seperate.Height - panel_bottom.Height);
            pif.Show();
            this.splitContainer.Panel2.Controls.Add(pif);
        }

        private void btn_periodontal_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_oralView_Click(object sender, EventArgs e)
        {
            videoPlayer = new VideoPlayer();
            videoPlayer.Parent = this.splitContainer.Panel2;
            videoPlayer.Location = new Point(0, panel_head.Height + 34);
            int w = this.splitContainer.Panel2.Width - imageVideoBrowserSideBar.Width - 10;
            int h = w * 720 / 1280;
            videoPlayer.Size = new Size(w, h);
            videoPlayer.PlayVideo("SKT-OL400C-13A");
            //vp.PlayVideo("http://10.10.10.254:8080");
            this.splitContainer.Panel2.Controls.Add(videoPlayer);
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }


        private void panel_help_Click(object sender, EventArgs e)
        {

        }

        private void panel_about_Click(object sender, EventArgs e)
        {
            AboutBox aboutWindow = new AboutBox();
            aboutWindow.StartPosition = FormStartPosition.CenterScreen;
            aboutWindow.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "录像")
            {
                videoPlayer.StartRecord("D://ttttt.avi");
                button1.Text = "停止";
            }
            else
            {
                videoPlayer.FinishRecord();
                button1.Text = "录像";

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //进行视频流播放和截图显示之间的切换
            if (picBox == null)
            {
                string dateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                //1. 主窗口移除掉videoPlayer这个控件，添加pictureBox控件
                Bitmap snapShotImg = videoPlayer.TakeSnapshot(@"E:\project\DSDentalEndoscopeViewer\DSDentalEndoscopeViewer\bin\x64\Debug\PatientInfoDir\李伟_1_2020-07-22\" + dateTime + ".jpg", true);
                this.splitContainer.Panel2.Controls.Remove(videoPlayer);
                //2. 重新排序
                imageVideoBrowserSideBar.SortOrderByTimeDescend();
                imageVideoBrowserSideBar.GroupItemByDate();

                //3.创建显示的pictureBox
                DisplayJPEGImage(ref snapShotImg);
            }
            else  //这时候picBox 已经实例化了，那么需要dispose, 重新恢复视频的播放
            {
                //1.清除pictureBox
                picBox.Dispose();
                picBox = null;
                //2.重新把视频播放器add进来
                this.splitContainer.Panel2.Controls.Add(videoPlayer);
            }
        }

        private void DisplayJPEGImage(ref Bitmap snapShot)
        {
            picBox = new Accord.Controls.PictureBox();
            picBox.MouseDoubleClick += PicBox_MouseDoubleClick;
            int w = this.splitContainer.Panel2.Width - imageVideoBrowserSideBar.Width - 10;
            int h = w * 720 / 1280;
            picBox.Location = new Point(0, panel_head.Height + 34);
            picBox.Size = new Size(w, h);
            picBox.Image = snapShot;
            picBox.Show();
            this.splitContainer.Panel2.Controls.Add(picBox);
        }

        //双击图片全屏显式
        private void PicBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //private ImageBrowser imgBrowser = new ImageBrowser(); //图片浏览器
            //                                 //绑定图片窗口关闭的事件
            //imgBrowser.CloseFormNotify += new ImageBrowser.CloseThisFormHandle(SubFormCloseEvent);
            //imgBrowser.curImageAbsPath = fileAbsPath;
            //string dataPath = fileAbsPath.Substring(0, fileAbsPath.LastIndexOf(@"\"));
            //imgBrowser.curDataAbsPath = dataPath;
            //imgBrowser.Show();

            ImageBrowser imgBrowser = new ImageBrowser(); //图片浏览器
            imgBrowser.curImageAbsPath = displayImageAbsPath;
            imgBrowser.curDataAbsPath = @"E:\project\DSDentalEndoscopeViewer\DSDentalEndoscopeViewer\bin\x64\Debug\PatientInfoDir\李伟_1_2020-07-22";
            imgBrowser.Show();
        }

        //private void 


        private void DoubleClickOpenProcessing(string itemPath)
        {
            //先判断是否有别的控件
            string fileType = itemPath.Substring(itemPath.LastIndexOf("."));//写入图片格式, .jpg
            if (fileType == ".jpg")
            {
                if (this.splitContainer.Panel2.Controls.Contains(videoPlayer))
                {
                    this.splitContainer.Panel2.Controls.Remove(videoPlayer);
                }

                if (picBox != null)
                {
                    picBox.Dispose();
                    picBox = null;
                }

                picBox = new Accord.Controls.PictureBox();
                picBox.MouseDoubleClick += PicBox_MouseDoubleClick;
                int w = this.splitContainer.Panel2.Width - imageVideoBrowserSideBar.Width - 10;
                int h = w * 720 / 1280;
                picBox.Location = new Point(0, panel_head.Height + 34);
                picBox.Size = new Size(w, h);
                picBox.Image = (Bitmap)Image.FromFile(itemPath);
                picBox.Show();
                this.splitContainer.Panel2.Controls.Add(picBox);
                displayImageAbsPath = itemPath;
            }
            else if (fileType == ".avi")
            {
                if (this.splitContainer.Panel2.Controls.Contains(picBox))
                {
                    this.splitContainer.Panel2.Controls.Remove(picBox);
                }
                if (videoPlayer != null)
                {
                    videoPlayer.Dispose();
                    videoPlayer = null;
                }

                videoPlayer = new VideoPlayer();
                videoPlayer.Parent = this.splitContainer.Panel2;
                videoPlayer.Location = new Point(0, panel_head.Height + 34);
                int w = this.splitContainer.Panel2.Width - imageVideoBrowserSideBar.Width - 10;
                int h = w * 720 / 1280;
                videoPlayer.Size = new Size(w, h);
                videoPlayer.PlayVideo(itemPath);
                this.splitContainer.Panel2.Controls.Add(videoPlayer);
            }



            
        }

    }
}
