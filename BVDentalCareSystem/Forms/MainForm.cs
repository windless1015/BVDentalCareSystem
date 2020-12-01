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
using System.IO;
using BVDentalCareSystem.CommandParse;
using Accord.Video.DirectShow;

namespace BVDentalCareSystem
{
    public partial class MainForm : Form
    {
        VideoPlayer videoCamera = null; //显示视频的camera form
        Accord.Controls.PictureBox picBox = null; //显示图片的picturebox form
        PatientsInfoForm pif = null; //病历列表的form
        ControlPanel controlPanelForm = null; //控制面板的form
        string displayImageAbsPath = null;
        public bool isTakingPicturePause = false; //是否是拍照暂停了
        string rootPath = @"D:\PatientInfoDir\李伟_1_2020-07-22\";
        public MainForm()
        {
            InitializeComponent();
            if(!Directory.Exists(rootPath))
                Directory.CreateDirectory(rootPath);//创建该文件夹　　 
            imageVideoBrowserSideBar.dataPath = rootPath;
            imageVideoBrowserSideBar.SortOrderByTimeDescend();
            imageVideoBrowserSideBar.GroupItemByDate();
            imageVideoBrowserSideBar.DBClickOpenItemNotify += new ImageVideoBrowserSideBar.DoubleClickOpenItemNotifyHandler(DoubleClickOpenProcessing);

        }

        private void btn_patientInfo_Click(object sender, EventArgs e)
        {
            //先把观察仪的界面关闭
            this.splitContainer.Panel2.Controls.Remove(videoCamera); //摄像头界面
            if(picBox != null)
                this.splitContainer.Panel2.Controls.Remove(picBox);
            if (pif != null)
            {
                this.splitContainer.Panel2.Controls.Remove(pif);
                pif.Dispose();
                pif = null;
            }
            if (controlPanelForm != null)
            {
                this.splitContainer.Panel2.Controls.Remove(controlPanelForm);
                controlPanelForm.Dispose();
                controlPanelForm = null;
            }

            pif = new PatientsInfoForm();
            pif.TopLevel = false; //重要的一个步骤
            pif.Parent = this.splitContainer.Panel2;
            pif.Location = new Point(0, panel_head.Height + 34);
            pif.Size = new Size(this.splitContainer.Panel2.Width - imageVideoBrowserSideBar.Width - 10, 
                this.splitContainer.Panel2.Height - panel_head.Height - panel_seperate.Height - 10);
            this.splitContainer.Panel2.Controls.Add(pif);
            pif.Show();
        }

        //牙周观察
        private void btn_periodontal_Click(object sender, EventArgs e)
        {
            PressCameraButton(1);
        }

        //口腔观察
        private void btn_oralView_Click(object sender, EventArgs e)
        {
            PressCameraButton(2);
        }

        //deviceType 为1表示牙周，2表示口腔
        private void PressCameraButton( int deviceType)
        {
            if (!CheckDeviceAvailable(deviceType))
            {
                string caption = (deviceType == 1) ? "牙周观察仪不存在，请检查设备连接！":"口腔观察仪不存在，请检查设备连接！";
                MessageBox.Show(caption, "连接设备出错", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //如果当前显示的是静态截图照片的处理
            if (picBox != null)
            {
                picBox.Dispose();
                picBox = null;
                this.splitContainer.Panel2.Controls.Add(videoCamera);
                return;
            }
            //如果当前正在播放视频，再次点击
            if (videoCamera != null)
            {
                this.splitContainer.Panel2.Controls.Remove(videoCamera);
                videoCamera.Stop();
                videoCamera.Dispose();
                videoCamera = null;
            }
            //如果当前显示的是病历列表
            if (pif != null)
            {
                this.splitContainer.Panel2.Controls.Remove(pif);
                pif.Dispose();
                pif = null;
            }
            videoCamera = new VideoPlayer();
            videoCamera.Parent = this.splitContainer.Panel2;
            int w = 0, h = 0;
            if (deviceType == 1)
            {
                w = 720;
                h = 720;
                videoCamera.Location = new Point((1280 - 720) / 2, panel_head.Height + 34);
            }
            else if (deviceType == 2)
            {
                w = this.splitContainer.Panel2.Width - imageVideoBrowserSideBar.Width - 10;
                h = w * 720 / 1280;
                videoCamera.Location = new Point(0, panel_head.Height + 34);
            }
            videoCamera.Size = new Size(w, h);
            string deviceName = (deviceType == 1) ? "BV USB Camera" : "SKT-OL400C-13A";
            videoCamera.PlayVideo(deviceName);
            //vp.PlayVideo("http://10.10.10.254:8080");
            this.splitContainer.Panel2.Controls.Add(videoCamera);

            //加载控制面板
            if(controlPanelForm != null) 
            {
                this.splitContainer.Panel2.Controls.Remove(controlPanelForm);
                controlPanelForm.Dispose();
                controlPanelForm = null;
            }
            controlPanelForm = new ControlPanel(deviceType);
            controlPanelForm.PressSnapShotBtn += ControlPanelForm_PressSnapShotBtn;
            controlPanelForm.PressRecordBtn += ControlPanelForm_PressRecordBtn;
            controlPanelForm.Location = new Point(0, 870);
            controlPanelForm.Show();
            this.splitContainer.Panel2.Controls.Add(controlPanelForm);
        }

        //点击截图按钮
        private void ControlPanelForm_PressSnapShotBtn()
        {
            //如果没在播放
            if (videoCamera == null)
                return;

            //进行视频流播放和截图显示之间的切换
            if (picBox == null)
            {
                string dateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                //1. 主窗口移除掉videoPlayer这个控件，添加pictureBox控件
                string snapShotImgPath = rootPath + dateTime + ".jpg";
                displayImageAbsPath = snapShotImgPath;
                Bitmap snapShotImg = videoCamera.TakeSnapshot(snapShotImgPath, true);
                int imgFromDeviceType = (snapShotImg.Width == snapShotImg.Height) ? 1 : 2; //照片宽高相等表示牙周观察仪
                this.splitContainer.Panel2.Controls.Remove(videoCamera);
                //2. 重新排序
                imageVideoBrowserSideBar.SortOrderByTimeDescend();
                imageVideoBrowserSideBar.GroupItemByDate();
                //3.创建显示的pictureBox
                DisplayJPEGImage(ref snapShotImg, imgFromDeviceType);
                //4. 图标切换
                controlPanelForm.ChangeSnapshotBtnImg(Properties.Resources.returnPreview);
            }
            else  //这时候picBox 已经实例化了，那么需要dispose, 重新恢复视频的播放
            {
                //1.清除pictureBox
                picBox.Dispose();
                picBox = null;
                //2.重新把视频播放器add进来
                this.splitContainer.Panel2.Controls.Add(videoCamera);
                controlPanelForm.ChangeSnapshotBtnImg(Properties.Resources.takePhoto);
            }
        }

        private void ControlPanelForm_PressRecordBtn()
        {
            if (videoCamera == null)
                return;
            if (picBox != null) //说明此时有截图的pictureBox遮挡，提示用户先返回视频流
            {
                MessageBox.Show("当前处于浏览照片状态，请点击拍照按钮先返回实时视频流！", "浏览照片", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //正在播放 且 没有在录像
            if (videoCamera.isPlaying && !videoCamera.isRecording)
            {
                string dateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                string aviFileName = rootPath + dateTime + ".avi";
                videoCamera.StartRecord(aviFileName);
                controlPanelForm.ChangeRecordBtnImg(Properties.Resources.recordStop);
            }
            else
            {
                videoCamera.FinishRecord();
                controlPanelForm.ChangeRecordBtnImg(Properties.Resources.record);
                //重新排序
                imageVideoBrowserSideBar.SortOrderByTimeDescend();
                imageVideoBrowserSideBar.GroupItemByDate();
            }
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


        //第二个参数是这个照片是来自于什么设备拍照的， 1表示口腔观察， 2表示牙周观察
        private void DisplayJPEGImage(ref Bitmap snapShot, int imgFromDeviceType)
        {
            picBox = new Accord.Controls.PictureBox();
            picBox.MouseDoubleClick += PicBox_MouseDoubleClick;
            int w = 0, h = 0;
            if (imgFromDeviceType == 2)
            {
                w = this.splitContainer.Panel2.Width - imageVideoBrowserSideBar.Width - 10;
                h = w * 720 / 1280;
                picBox.Location = new Point(0, panel_head.Height + 34);
            }
            else if(imgFromDeviceType == 1)
            {
                w = 720;
                h = 720;
                picBox.Location = new Point((1280 - 720) / 2, panel_head.Height + 34);
            }
            picBox.Size = new Size(w, h);
            picBox.SizeMode = PictureBoxSizeMode.StretchImage;
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
            imgBrowser.curDataAbsPath = rootPath;
            imgBrowser.Show();
        }

        private void DoubleClickOpenProcessing(string itemPath)
        {
            //先判断是否有别的控件
            string fileType = itemPath.Substring(itemPath.LastIndexOf("."));//写入图片格式, .jpg
            if (fileType == ".jpg")
            {
                if (this.splitContainer.Panel2.Controls.Contains(videoCamera))
                {
                    this.splitContainer.Panel2.Controls.Remove(videoCamera);
                }

                if (picBox != null)
                {
                    picBox.Dispose();
                    picBox = null;
                }

                picBox = new Accord.Controls.PictureBox();
                picBox.MouseDoubleClick += PicBox_MouseDoubleClick;
                picBox.Image = (Bitmap)Image.FromFile(itemPath);
                int w = 0, h = 0;
                if (picBox.Image.Width == picBox.Image.Height) //牙周观察 
                {
                    w = 720;
                    h = 720;
                    picBox.Location = new Point((1280 - 720) / 2, panel_head.Height + 34);
                }
                else 
                {
                    w = this.splitContainer.Panel2.Width - imageVideoBrowserSideBar.Width - 10;
                    h = w * 720 / 1280;
                    picBox.Location = new Point(0, panel_head.Height + 34);
                }
                picBox.SizeMode = PictureBoxSizeMode.StretchImage;
                picBox.Size = new Size(w, h);
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
                if (videoCamera != null)
                {
                    videoCamera.Dispose();
                    videoCamera = null;
                }

                videoCamera = new VideoPlayer();
                videoCamera.Parent = this.splitContainer.Panel2;
                videoCamera.Location = new Point(0, panel_head.Height + 34);
                int w = this.splitContainer.Panel2.Width - imageVideoBrowserSideBar.Width - 10;
                int h = w * 720 / 1280;
                videoCamera.Size = new Size(w, h);
                videoCamera.PlayVideo(itemPath);
                this.splitContainer.Panel2.Controls.Add(videoCamera);
            }



            
        }

        //牙周是1， 口腔观察是 2
        private bool  CheckDeviceAvailable(int deviceType)
        {
            var videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (var device in videoDevices)
            {
                string deviceName = device.Name;
                if (deviceName == "SKT-OL400C-13A" && deviceType == 2)
                {
                    return true;
                }
                if (deviceName == "BV USB Camera" && deviceType == 1)
                {
                    return true;
                }
            }
            return false;
        }


    }
}
