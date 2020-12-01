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

        public delegate void RecordHandler();
        public event RecordHandler PressRecordBtn;
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

        }

        //一般模式
        private void NormalModeBtn_Click(object sender, EventArgs e)
        {

        }

        //人像模式
        private void FigureModeBtn_Click(object sender, EventArgs e)
        {

        }

        //拍照
        private void btnSnapshot_Click(object sender, EventArgs e)
        {
            PressSnapShotBtn();
        }

        //录像
        private void btnRecord_Click(object sender, EventArgs e)
        {
            PressRecordBtn();
        }

        public void ChangeSnapshotBtnImg(Bitmap bm)
        {
            btnSnapshot.BackgroundImage = bm;
        }

        public void ChangeRecordBtnImg(Bitmap bm)
        {
            btnRecord.BackgroundImage = bm;
        }

    }
}
