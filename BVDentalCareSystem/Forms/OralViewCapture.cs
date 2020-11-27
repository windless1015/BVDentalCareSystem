using BVDentalCareSystem.CommandParse;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BVDentalCareSystem.Forms
{
    public partial class OralViewCapture : Form
    {
        private USBHelper UsbHelperInstance = null;
        public OralViewCapture()
        {
            InitializeComponent();
        }

        public bool FindDevice()
        {
            UsbHelperInstance = new USBHelper();
            return UsbHelperInstance.OpenDevice(0x10c4, 0x8846);
        }
        //public void Init()
        //{
        //    UsbHelperInstance.RecvCommandChanged += OnRecvCurrentCommand;//设置命令接受处理函数
        //    imgVideoBrwser_Capture.DeleteImgNotify += new ImageVideoBrowserSideBar.DeleteImgNotifyHandler(HandleDeleteImg);
        //    imgVideoBrwser_Capture.OpenItemNotify += new ImageVideoBrowserSideBar.DoubleClickOpenItemNotifyHandler(DoubleClickOpenProcessing);
        //    imgVideoBrwser_Capture.CloseSubFormNotify += new ImageVideoBrowserSideBar.CloseSubFormHandle(CloseSubFormHandler);
        //    timer_timeout.Enabled = true;
        //    timer_heartbeat.Enabled = true;
        //    timer_heartbeat.Start();
        //}

        //private void OnRecvCurrentCommand(object sender, RecvCommandChangedEventArgs e)
        //{
        //    //接受到字符串的命令指令
        //    string RecvCmdString = e.ReceivedCommand;
        //    ParseRecvCommandsAndSetButtons(ref RecvCmdString);
        //}

        ////解析收到的指令,然后设置对应的按钮
        //private void ParseRecvCommandsAndSetButtons(ref string cmd)
        //{
        //    if (isSwitchToDisplayItemForm) //如果切换到显示的状态，那么就不做任何事情
        //        return;
        //    if (!isOralWindowAvailable)
        //        return;
        //    if (cmd == "0000000000000000")
        //        return;
        //    if (cmd == "0101010101010101")
        //    {
        //        timer_timeout.Stop(); //信号灯的超时连接定时器

        //        cameraCaptureControl.StopPlay();
        //        cameraCaptureControl.curCamState = CameraCaptureControl.CameraState.Stopped;
        //        isRecvDormantCMD = true;
        //    }
        //    else
        //    {
        //        if (cmd == "0001000000010000" || cmd == "0104000000050000" || cmd == "020a0000000c0000")
        //        {
        //            if (isRecvDormantCMD)
        //            {
        //                cameraCaptureControl.StartPlay();
        //                isRecvDormantCMD = false;
        //            }
        //            ModeSwitchByRecvAndSend(ref cmd);
        //        }
        //        //拍照指令
        //        if (cmd == "0002000000020000")
        //        {
        //            if (isRecvDormantCMD)
        //            {
        //                cameraCaptureControl.StartPlay();
        //                isRecvDormantCMD = false;
        //            }
        //            //上层软件需要先判断当前是否已经进行拍照暂停了,如果正在播放则拍照,如果已经拍照暂停,则继续重新播放
        //            if (isTakingPicturePause)
        //            {
        //                cameraCaptureControl.StartPlay();
        //                isTakingPicturePause = false;
        //            }
        //            else
        //            {
        //                Action actionDelegate;
        //                actionDelegate = () => { TakePicture(); };
        //                MicroLensModeBtn.Invoke(actionDelegate);
        //            }
        //        }
        //    }
        //}

        //private void ModeSwitchByRecvAndSend(ref string cmd)
        //{
        //    if (isRecvDormantCMD)
        //        return;
        //    bool MicroLensFlg = false, NormalFlg = false, FigureFlg = false;
        //    //微距模式
        //    if (cmd == "0001000000010000" || cmd == "0001000100020000")
        //    {
        //        MicroLensFlg = true; NormalFlg = false; FigureFlg = false;
        //    }
        //    //一般模式
        //    else if (cmd == "0104000000050000" || cmd == "0104000100060000")
        //    {
        //        MicroLensFlg = false; NormalFlg = true; FigureFlg = false;
        //    }
        //    //人像模式
        //    else if (cmd == "020a0000000c0000" || cmd == "020a0001000d0000")
        //    {
        //        MicroLensFlg = false; NormalFlg = false; FigureFlg = true;
        //    }

        //    Action actionDelegate;
        //    if (MicroLensFlg)
        //    {
        //        actionDelegate = () => { MicroLensModeBtn.BackgroundImage = Properties.Resources.microLen_selected; };
        //        MicroLensModeBtn.Invoke(actionDelegate);
        //    }
        //    else
        //    {
        //        actionDelegate = () => { MicroLensModeBtn.BackgroundImage = Properties.Resources.microLen_unselected; };
        //        MicroLensModeBtn.Invoke(actionDelegate);
        //    }

        //    if (NormalFlg)
        //    {
        //        actionDelegate = () => { NormalModeBtn.BackgroundImage = Properties.Resources.normal_selected; };
        //        NormalModeBtn.Invoke(actionDelegate);
        //    }
        //    else
        //    {
        //        actionDelegate = () => { NormalModeBtn.BackgroundImage = Properties.Resources.normal_unselected; };
        //        NormalModeBtn.Invoke(actionDelegate);
        //    }

        //    if (FigureFlg)
        //    {
        //        actionDelegate = () => { FigureModeBtn.BackgroundImage = Properties.Resources.figure_selected; };
        //        FigureModeBtn.Invoke(actionDelegate);
        //    }
        //    else
        //    {
        //        actionDelegate = () => { FigureModeBtn.BackgroundImage = Properties.Resources.figure_unselected; };
        //        FigureModeBtn.Invoke(actionDelegate);
        //    }

        //}

        //void TakePicture()
        //{
        //    if (cameraCaptureControl.isRecording)
        //    {
        //        MessageBox.Show("当前正在录像，无法进行图像拍照！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //    if (cameraCaptureControl.curCamState == CameraCaptureControl.CameraState.Playing)
        //    {
        //        cameraCaptureControl.PausePlay();
        //        cameraCaptureControl.SnapShot(curSelectPatientPath);
        //        new SoundPlayer(Properties.Resources.kaca).Play();
        //        //拍照完了,还需要显示当前患者的图片和视频信息
        //        imgVideoBrwser_Capture.Reorder();
        //        isTakingPicturePause = true; //拍照暂停标记为置为true
        //    }
        //}




    }
}
