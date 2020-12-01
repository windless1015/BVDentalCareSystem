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
            if (deviceType == 1)
            {
                MicroLensModeBtn.Show();
                FigureModeBtn.Show();
                NormalModeBtn.Show();
                labAirPump.Show();
                labWaterPump.Show();
                panelAirPump.Show();
                panelWaterPump.Show();
            }
            else 
            {
                MicroLensModeBtn.Hide();
                FigureModeBtn.Hide();
                NormalModeBtn.Hide();
                labAirPump.Hide();
                labWaterPump.Hide();
                panelAirPump.Hide();
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
    }
}
