using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BVDentalCareSystem.Forms
{
    public partial class ControlPanel : UserControl
    {
        public delegate void SnapShotHandler();
        public event SnapShotHandler PressSnapShotBtn;

        public delegate int RecordHandler(); //result是返回的
        public event RecordHandler PressRecordBtn;

        public delegate void CmdOutHandler(ref string cmd);
        public event CmdOutHandler cmdOutProcessing;
        public ControlPanel(int deviceType)
        {
            InitializeComponent();
            if (deviceType == 1) //牙周
            {
                MicroLensModeBtn.Hide();
                FigureModeBtn.Hide();
                NormalModeBtn.Hide();
                labAirPump.Hide();
                labWaterPump.Hide();
                panelAirPump.Hide();
                panelWaterPump.Hide();
                labAirPump.Show();
                panelAirPump.Show();
                labWaterPump.Show();
                panelWaterPump.Show();
            }
            else //口腔观察
            {
                MicroLensModeBtn.Show();
                FigureModeBtn.Show();
                NormalModeBtn.Show();
                labAirPump.Show();
                labWaterPump.Show();
                panelAirPump.Show();
                panelWaterPump.Show();
                labAirPump.Hide();
                panelAirPump.Hide();
                labWaterPump.Hide();
                panelWaterPump.Hide();
            }
        }

        //微距模式
        private void MicroLensModeBtn_Click(object sender, EventArgs e)
        {
            //上位机发给下位机的微距模式  01010200
            string msg = "01010200";
            ModeSwitchByRecvAndSend(ref msg);
            cmdOutProcessing(ref msg);
        }

        //一般模式
        private void NormalModeBtn_Click(object sender, EventArgs e)
        {
            string msg = "14010600";
            //上位机发给下位机的normal模式  14010600
            ModeSwitchByRecvAndSend(ref msg);
            cmdOutProcessing(ref msg);
        }

        //人像模式
        private void FigureModeBtn_Click(object sender, EventArgs e)
        {
            string msg = "2A010D00";
            //上位机发给下位机的figure模式  2A010D00
            ModeSwitchByRecvAndSend(ref msg);
            cmdOutProcessing(ref msg);
        }

        //拍照
        private void btnSnapshot_Click(object sender, EventArgs e)
        {
            PressSnapShotBtn();
        }

        //录像
        private void btnRecord_Click(object sender, EventArgs e)
        {
            int res = PressRecordBtn();
            if (res == 0) //正在录像
            {
                btnSnapshot.Enabled = false;
            }
            if (res == 1) //结束录像
            {
                btnSnapshot.Enabled = true;
            }
        }

        public void ChangeSnapshotBtnImg(Bitmap bm)
        {
            btnSnapshot.BackgroundImage = bm;
        }

        public void ChangeRecordBtnImg(Bitmap bm)
        {
            btnRecord.BackgroundImage = bm;
        }


        public void ModeSwitchByRecvAndSend(ref string cmd)
        {
            bool MicroLensFlg = false, NormalFlg = false, FigureFlg = false;
            //微距模式
            if (cmd == "01000100" || cmd == "01010200")
            {
                MicroLensFlg = true; NormalFlg = false; FigureFlg = false;
            }
            //一般模式
            else if (cmd == "14000500" || cmd == "14010600")
            {
                MicroLensFlg = false; NormalFlg = true; FigureFlg = false;
            }
            //人像模式
            else if (cmd == "2A000C00" || cmd == "2A010D00")
            {
                MicroLensFlg = false; NormalFlg = false; FigureFlg = true;
            }

            Action actionDelegate;
            if (MicroLensFlg)
            {
                actionDelegate = () => { MicroLensModeBtn.BackgroundImage = Properties.Resources.microLen_selected; };
                MicroLensModeBtn.Invoke(actionDelegate);
            }
            else
            {
                actionDelegate = () => { MicroLensModeBtn.BackgroundImage = Properties.Resources.microLen_unselected; };
                MicroLensModeBtn.Invoke(actionDelegate);
            }

            if (NormalFlg)
            {
                actionDelegate = () => { NormalModeBtn.BackgroundImage = Properties.Resources.normal_selected; };
                NormalModeBtn.Invoke(actionDelegate);
            }
            else
            {
                actionDelegate = () => { NormalModeBtn.BackgroundImage = Properties.Resources.normal_unselected; };
                NormalModeBtn.Invoke(actionDelegate);
            }

            if (FigureFlg)
            {
                actionDelegate = () => { FigureModeBtn.BackgroundImage = Properties.Resources.figure_selected; };
                FigureModeBtn.Invoke(actionDelegate);
            }
            else
            {
                actionDelegate = () => { FigureModeBtn.BackgroundImage = Properties.Resources.figure_unselected; };
                FigureModeBtn.Invoke(actionDelegate);
            }

        }

        //水泵,气泵设置
        public void SetAirWaterPumpBtnImg(ref string cmd)
        {
            if (cmd == "5AA508F1A100A55A")//水泵关闭信号
            {
                panelWaterPump.BackgroundImage = Properties.Resources.waterPump_gray;
            }
            else if (cmd == "5AA508F2A100A55A") //气泵关闭信号
            {
                panelAirPump.BackgroundImage = Properties.Resources.ariPump_gray;
            }
            else if (cmd == "5AA508F1A111A55A") //水泵打开
            {
                panelWaterPump.BackgroundImage = Properties.Resources.waterPump_green;
            }
            else if (cmd == "5AA508F2A111A55A") //气泵打开
            {
                panelAirPump.BackgroundImage = Properties.Resources.airPump_green;
            }
            else if (cmd == "5AA508F0A111A55A") //拍照指令
            { }


        }

    }
}
