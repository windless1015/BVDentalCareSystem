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
using System.Diagnostics;

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
        string rootPath = Environment.CurrentDirectory + @"\PatientInfoDir\";
        string curPatientPath = null;
        //数据通信
        const string heartBeatSendCmd = "0101000101040000";

        private SerialPortHelper periCommunicateInstance = null; //牙周内窥镜的通信
        private ICommunicationBase oralCommunicateInstance = null; //口腔观察仪的通信
        private SerialPortHelper cleanerCommunicateInstance = null; //洁牙机的通信

        ToothCleanerSettingControl settingControl = null;
        
        public MainForm()
        {
            InitializeComponent();　 
            imageVideoBrowserSideBar.DBClickOpenItemNotify += new ImageVideoBrowserSideBar.DoubleClickOpenItemNotifyHandler(DoubleClickOpenProcessing);
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            //检测数据文件夹是否存在,如果不存在就创建
            TestDataRootDirectoryExist();
            //btn_toothCleaner.Visible = false;
            panel_help.Visible = false;
        }

        private void btn_patientInfo_Click(object sender, EventArgs e)
        {
            if (controlPanelForm != null)
            {
                this.splitContainer.Panel2.Controls.Remove(controlPanelForm);
                controlPanelForm.Dispose();
                controlPanelForm = null;
            }
            //把摄像头关闭
            if (videoCamera != null)
            {
                btn_periodontal.BackgroundImage = Properties.Resources.periodontal_unselected;
                btn_oralView.BackgroundImage = Properties.Resources.oralView_unselected;
                this.splitContainer.Panel2.Controls.Remove(videoCamera); //摄像头界面
                videoCamera.Stop();
                videoCamera.Dispose();
                videoCamera = null;
            }
            
            if(picBox != null)
                this.splitContainer.Panel2.Controls.Remove(picBox);
            if (pif != null)
            {
                this.splitContainer.Panel2.Controls.Remove(pif);
                pif.Dispose();
                pif = null;
            }

            btn_patientInfo.BackgroundImage = Properties.Resources.patientInfo_selected;
            pif = new PatientsInfoForm();
            pif.SideBarDataReorderNotify += ProcessSideBarRecord;
            pif.TopLevel = false; //重要的一个步骤
            pif.Parent = this.splitContainer.Panel2;
            pif.Location = new Point(0, panel_head.Height + 34);
            int w = this.splitContainer.Panel2.Width - imageVideoBrowserSideBar.Width - 10;
            int h = this.splitContainer.Panel2.Height - panel_head.Height - panel_seperate.Height - 10;
            pif.Size = new Size(w, h);

            pif.Show();
            this.splitContainer.Panel2.Controls.Add(pif);
        }

        //牙周观察
        private void btn_periodontal_Click(object sender, EventArgs e)
        {
            BuildCommunication(1);
            PressCameraButton(1);
        }

        //口腔观察
        private void btn_oralView_Click(object sender, EventArgs e)
        {
            BuildCommunication(2);
            PressCameraButton(2);
            
        }

        //点击洁牙机
        private void btn_toothCleaner_Click(object sender, EventArgs e)
        {
            //如果当前显示的是静态截图照片的处理
            if (picBox != null)
            {
                picBox.Dispose();
                picBox = null;
                this.splitContainer.Panel2.Controls.Remove(picBox);
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

            BuildCommunication(4);

            settingControl = new ToothCleanerSettingControl();
            settingControl.ToothCleanerMsgOut += SettingControl_ToothCleanerMsgOut;//洁牙机界面向外发送数据
            int w, h;
            w = splitContainer.Panel2.Width - imageVideoBrowserSideBar.Width - 10;
            h = w * 720 / 1280;
            settingControl.Location = new Point(0, panel_head.Height + 34);
            btn_periodontal.BackgroundImage = Properties.Resources.periodontal_unselected;
            btn_oralView.BackgroundImage = Properties.Resources.oralView_unselected;
            btn_patientInfo.BackgroundImage = Properties.Resources.patientInfo_unselected;
            settingControl.Width = 1280;
            settingControl.Height = 720;
            settingControl.Show();
            splitContainer.Panel2.Controls.Add(settingControl);

        }

        private void SettingControl_ToothCleanerMsgOut(string msg)
        {
            cleanerCommunicateInstance.SendCmdMsg(msg);
        }



        //deviceType 为1表示牙周，2表示口腔
        private void PressCameraButton(int deviceType)
        {
            if (!CheckDeviceAvailable(deviceType))
            {
                string caption = (deviceType == 1) ? "牙周观察仪不存在，请检查设备连接！":"口腔观察仪不存在，请检查设备连接！";
                MessageBox.Show(caption, "连接设备出错", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (curPatientPath == null)
            {
                MessageBox.Show("请选择一个患者!", "选择患者", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //如果当前显示的是静态截图照片的处理
            if (picBox != null)
            {
                picBox.Dispose();
                picBox = null;
                this.splitContainer.Panel2.Controls.Add(videoCamera);
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
                btn_periodontal.BackgroundImage = Properties.Resources.periodontal_selected;
                btn_oralView.BackgroundImage = Properties.Resources.oralView_unselected;
                btn_patientInfo.BackgroundImage = Properties.Resources.patientInfo_unselected;
            }
            else if (deviceType == 2)
            {
                w = this.splitContainer.Panel2.Width - imageVideoBrowserSideBar.Width - 10;
                h = w * 720 / 1280;
                videoCamera.Location = new Point(0, panel_head.Height + 34);
                btn_periodontal.BackgroundImage = Properties.Resources.periodontal_unselected;
                btn_oralView.BackgroundImage = Properties.Resources.oralView_selected;
                btn_patientInfo.BackgroundImage = Properties.Resources.patientInfo_unselected;
            }
            videoCamera.Size = new Size(w, h);

            string deviceName = null;
            if (deviceType == 1)
            {
                deviceName = "BV USB Camera";
            }
            else if (deviceType == 2)
            {
                deviceName = "SKT-OL400C-13A";
            }
            else if(deviceType == 3)
            {
                deviceName = "http://10.10.10.254:8080";
            }
            videoCamera.PlayVideo(deviceName);
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
            controlPanelForm.cmdOutProcessing += ControlPanelForm_cmdOutProcessing;
            controlPanelForm.Location = new Point(0, 870);
            controlPanelForm.Show();
            this.splitContainer.Panel2.Controls.Add(controlPanelForm);
        }

        private void ControlPanelForm_cmdOutProcessing(ref string cmd)
        {
            oralCommunicateInstance.SendCmdMsg(cmd);
        }

        //deviceType: 1.牙周观察仪   2.口腔观察 usb  3.口腔观察 wifi
        private void BuildCommunication(int deviceType)
        {
            switch (deviceType)
            {
                case 1:  //牙周观察
                    if (periCommunicateInstance != null)
                    {
                        periCommunicateInstance.Close();
                        periCommunicateInstance = null;
                    }
                    string comName = INIOperation.ReadSerialPortINIFile();
                    periCommunicateInstance = new SerialPortHelper(comName);
                    periCommunicateInstance.deviceType = 1;
                    periCommunicateInstance.Open();
                    periCommunicateInstance.MsgReceivedHandler += OnRecvMsgHandler;
                    break;
                case 2:    //口腔观察 usb连接
                    if (oralCommunicateInstance != null)
                    {
                        oralCommunicateInstance.Close();
                        oralCommunicateInstance = null;
                    }
                    oralCommunicateInstance = new USBHelper(0x10c4, 0x8846);
                    oralCommunicateInstance.Open();
                    //绑定指令处理函数
                    oralCommunicateInstance.MsgReceivedHandler += OnRecvMsgHandler;
                    break;
                case 3: //口腔观察 wifi
                    break;
                case 4:
                    if (cleanerCommunicateInstance != null)
                    {
                        cleanerCommunicateInstance.Close();
                        cleanerCommunicateInstance = null;
                    }
                    string comNamed = "COM4";
                    cleanerCommunicateInstance = new SerialPortHelper(comNamed);
                    cleanerCommunicateInstance.deviceType = 4;
                    cleanerCommunicateInstance.Open();
                    cleanerCommunicateInstance.MsgReceivedHandler += OnRecvMsgHandler;
                    break;
                default:  //口腔观察 wifi连接
                    
                    break;
            }

            
        }

        private void OnRecvMsgHandler(object sender, RecvMsgEventArgs e)
        {
            //接受到字符串的命令指令
            string RecvCmdString = e.ReceivedMsg;
            int deviceType = e.deviceType;
            ParseRecvCommandsAndSetButtons(ref RecvCmdString, ref deviceType);
        }

        //解析收到的指令,然后设置对应的按钮
        private void ParseRecvCommandsAndSetButtons(ref string cmd, ref int deviceType)
        {
            switch (deviceType)
            {
                case 1://牙周观察
                    PeriCmdParse(ref cmd);
                    break;
                case 2://口腔观察, usb模式
                    OralCmdParse(ref cmd);
                    break;
                case 3://口腔观察, wifi模式
                    break;
                case 4: //洁牙机, 串口
                    ToothCleanerCmdParse(ref cmd);
                    break;
                default:
                    break;
            }
                
        }

        //牙周观察
        private void PeriCmdParse(ref string cmd)
        {
            if (cmd == "5AA508F1A100A55A") //水泵关闭信号
            {
                periCommunicateInstance.SendCmdMsg("5AA508F1A200A55A");
            }
            else if (cmd == "5AA508F2A100A55A") //气泵关闭信号
            {
                periCommunicateInstance.SendCmdMsg("5AA508F2A200A55A");
            }
            else if (cmd == "5AA508F1A111A55A") //水泵打开
            {
                periCommunicateInstance.SendCmdMsg("5AA508F1A211A55A");
            }
            else if (cmd == "5AA508F2A111A55A") //气泵打开
            {
                periCommunicateInstance.SendCmdMsg("5AA508F2A211A55A");
            }
            else if (cmd == "5AA508F0A111A55A") //拍照指令
            {
                periCommunicateInstance.SendCmdMsg("5AA508F0A211A55A");
                Action actionDelegate;
                actionDelegate = () => { ControlPanelForm_PressSnapShotBtn(); };
                this.Invoke(actionDelegate);
            }
            controlPanelForm.SetAirWaterPumpBtnImg(ref cmd);
        }

        //口腔观察解析
        private void OralCmdParse(ref string cmd)
        {
            if (cmd == "11111111") //休眠指令
            {
                timer_timeout.Stop(); //信号灯的超时连接定时器

                //videoCamera.Stop();
                //videoCamera.isStopped = true; //停止状态
            }
            else //非休眠指令
            {
                if (cmd == "01000100" || cmd == "14000500" || cmd == "2A000C00")
                {
                    if (controlPanelForm != null)
                        controlPanelForm.ModeSwitchByRecvAndSend(ref cmd);
                }
                //拍照指令
                if (cmd == "02000200")
                {
                    Action actionDelegate;
                    actionDelegate = () => { ControlPanelForm_PressSnapShotBtn(); };
                    this.Invoke(actionDelegate);
                }
            }
        }

        //洁牙机解析
        private void ToothCleanerCmdParse(ref string cmd)
        {
            //接受到字符串的命令指令
            Console.WriteLine("接受到的整条指令为: " + cmd);
            PeridonticTherapyDeviceMsgType msgType;
            int param;
            BVDentalCareSystem.CommandParse.CommandParse.ReadPeridonticMsg(ref cmd, out msgType, out param);
            AllParamItem guiParam = new AllParamItem(-1); //默认都是-1
            switch (msgType)
            {
                case PeridonticTherapyDeviceMsgType.RD_PWR_LEVELS:
                    guiParam.pwrLevels = param;
                    break;
                case PeridonticTherapyDeviceMsgType.RD_CUR_PWR_LEVEL:
                    guiParam.curPumpLevel = param;
                    break;
                case PeridonticTherapyDeviceMsgType.RD_PWR_MODE:
                    guiParam.pwrMode = param;
                    break;
                case PeridonticTherapyDeviceMsgType.RD_PUMP_LEVELS:
                    guiParam.pumpLevels = param;
                    break;
                case PeridonticTherapyDeviceMsgType.RD_CUR_PUMP_LEVEL:
                    guiParam.curPumpLevel = param;
                    break;
                case PeridonticTherapyDeviceMsgType.RD_PUMP_MODE:
                    guiParam.pumpMode = param;
                    break;
                case PeridonticTherapyDeviceMsgType.RD_OSC_STATE:
                    guiParam.osc_state = param;
                    break;
                case PeridonticTherapyDeviceMsgType.RD_OSC_MODE:
                    guiParam.osc_mode = param;
                    break;
                case PeridonticTherapyDeviceMsgType.RD_SW_MODE:
                    guiParam.sw_mode = param;
                    break;
                default:
                    break;
            }
            settingControl.UpdateALLParam2GUI(ref guiParam);
        }


        //点击截图按钮
        private void ControlPanelForm_PressSnapShotBtn()
        {
            //如果没在播放
            if (videoCamera == null)
                return;

            //如果在录像
            if (videoCamera.isRecording)
                return;

            //进行视频流播放和截图显示之间的切换
            if (picBox == null)
            {
                string dateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                //1. 主窗口移除掉videoPlayer这个控件，添加pictureBox控件
                string snapShotImgPath = curPatientPath + "\\" + dateTime + ".jpg";
                displayImageAbsPath = snapShotImgPath;
                Bitmap snapShotImg = videoCamera.TakeSnapshot(snapShotImgPath, true);
                int imgFromDeviceType = (snapShotImg.Width == snapShotImg.Height) ? 1 : 2; //照片宽高相等表示牙周观察仪
                this.splitContainer.Panel2.Controls.Remove(videoCamera);
                //2. 重新排序
                imageVideoBrowserSideBar.SortOrderByTimeDescend();
                imageVideoBrowserSideBar.GroupItemByDate();
                //3.创建显示的pictureBox
                DisplayJPEGImage(ref snapShotImg, imgFromDeviceType);
                new System.Media.SoundPlayer(Properties.Resources.kaca).Play();
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

        private int ControlPanelForm_PressRecordBtn()
        {
            if (videoCamera == null)
                return -1;
            if (picBox != null) //说明此时有截图的pictureBox遮挡，提示用户先返回视频流
            {
                MessageBox.Show("当前处于浏览照片状态，请点击拍照按钮先返回视频显示状态！", "浏览照片", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }

            //正在播放 且 没有在录像
            if (videoCamera.isPlaying && !videoCamera.isRecording)
            {
                string dateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                string aviFileName = curPatientPath + "\\" + dateTime + ".avi";
                videoCamera.StartRecord(aviFileName);
                controlPanelForm.ChangeRecordBtnImg(Properties.Resources.recordStop);
                return 0;
            }
            else
            {
                videoCamera.FinishRecord();
                controlPanelForm.ChangeRecordBtnImg(Properties.Resources.record);
                //重新排序
                imageVideoBrowserSideBar.SortOrderByTimeDescend();
                imageVideoBrowserSideBar.GroupItemByDate();
                return 1;
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Process[] procesRepo = Process.GetProcessesByName("BVPlayer");
            if (procesRepo.Length > 0)
            {
                procesRepo[0].Kill();
            }

            //释放需要释放的资源
            if (videoCamera != null)
            {
                videoCamera.Dispose();
            }
            if (picBox != null)
            {
                picBox.Dispose();
            }
            if (pif != null) 
            {
                pif.Dispose();
            }
            if (controlPanelForm != null)
            {
                controlPanelForm.Dispose();
            }

            if (periCommunicateInstance != null)
            {
                periCommunicateInstance.Close();
                periCommunicateInstance = null;
            }
            if (oralCommunicateInstance != null)
            {
                oralCommunicateInstance.Close();
                oralCommunicateInstance = null;
            }

            if (cleanerCommunicateInstance != null)
            {
                cleanerCommunicateInstance.Close();
                cleanerCommunicateInstance = null;
            }

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
            ImageBrowser imgBrowser = new ImageBrowser(); //图片浏览器
            imgBrowser.curImageAbsPath = displayImageAbsPath; //当前图片的绝对路径
            string curPatientDataPath = displayImageAbsPath.Substring(0, displayImageAbsPath.LastIndexOf(@"\"));
            imgBrowser.curDataAbsPath = curPatientDataPath; //当前病例数据文件夹的路径
            imgBrowser.Show();
        }

        private void DoubleClickOpenProcessing(string itemPath)
        {
            if (videoCamera != null && videoCamera.isPlaying)
            {
                return;
            }
            //先判断是否有别的控件
            string fileType = itemPath.Substring(itemPath.LastIndexOf("."));//写入图片格式, .jpg
            if (fileType == ".jpg")
            {
                if (this.splitContainer.Panel2.Controls.Contains(videoCamera))
                {
                    this.splitContainer.Panel2.Controls.Remove(videoCamera);
                }
                if (splitContainer.Panel2.Controls.Contains(pif))
                {
                    splitContainer.Panel2.Controls.Remove(pif);
                }

                if (this.splitContainer.Panel2.Controls.Contains(pif))
                {
                    this.splitContainer.Panel2.Controls.Remove(pif);
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
                if(controlPanelForm != null)//同时把拍照按钮的图标变成浏览模式
                    controlPanelForm.ChangeSnapshotBtnImg(Properties.Resources.returnPreview);
            }
            else if (fileType == ".avi")
            {
                //先去进程库里查询是否有BVPlayer.exe进程存在
                Process[] procesRepo = Process.GetProcessesByName("BVPlayer");
                if (procesRepo.Length > 0)
                {
                    procesRepo[0].Kill();
                }

                System.Diagnostics.Process pro = new System.Diagnostics.Process();
                pro.StartInfo.FileName = @"BVPlayer.exe";
                int aa = itemPath.LastIndexOf('\\');
                string fileName = itemPath;
                string folderPath = itemPath.Substring(0, aa);
                pro.StartInfo.Arguments = fileName + " " + folderPath;
                pro.Start();//开启程序
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

        //每隔2s发送一次心跳指令---发送1,1,0,1,1,4,0,0, 设备收到后回复11110000
        private void timer_heartbeat_Tick(object sender, EventArgs e)
        {
            oralCommunicateInstance.SendCmdMsg(heartBeatSendCmd);
            timer_timeout.Start();
        }

        private void timer_timeout_Tick(object sender, EventArgs e)
        {
            timer_timeout.Stop();
        }

        //222
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer_heartbeat.Stop();
        }


        private void ProcessSideBarRecord(string dataPath)
        {
            curPatientPath = dataPath;
            imageVideoBrowserSideBar.Clear();
            imageVideoBrowserSideBar.dataPath = dataPath;
            imageVideoBrowserSideBar.SortOrderByTimeDescend();
            imageVideoBrowserSideBar.GroupItemByDate();
        }

        private void TestDataRootDirectoryExist()
        {
            if (!Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath);
            }
        }


    }
}
