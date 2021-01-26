using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BVDentalCareSystem.CommandParse;

namespace BVDentalCareSystem.SelfDefinedControls
{
    public partial class TeethCleanerPanel : UserControl
    {
        public delegate void ToothCleanerMsgOutEvent(string msg);
        public event ToothCleanerMsgOutEvent ToothCleanerMsgOut;
        public TeethCleanerPanel()
        {
            InitializeComponent();
        }

        private void btn_init_Click(object sender, EventArgs e)
        {
            //string msg = BVDentalCareSystem.CommandParse.CommandParse.SendPeridonticMsg(
            //        PeridonticTherapyDeviceMsgType.RST_FACTOR, 0);
            //ToothCleanerMsgOut(msg);
            //Thread.Sleep(50);
            //ReadParam(PeridonticTherapyDeviceMsgType.RST_FACTOR, true);
            //UpdateALLParam2GUI();

        }

        //把所有参数都重新设置到GUI界面上
        public void UpdateALLParam2GUI(ref AllParamItem guiParam)
        {
            if (guiParam.osc_mode != -1)
                label_osc_mode.Text = (guiParam.osc_mode == 0) ? "洁牙模式" : "骨刀模式";
            if (guiParam.osc_state != -1)
                label_osc_state.Text = (guiParam.osc_state == 0) ? "空闲" : "工作"; //空闲, 工作
            if (guiParam.sw_mode != -1)
            {
                radioBtn_fingerControl.Checked = (guiParam.sw_mode == 1) ? false : true; //指控 手柄开关, swMode = 0
                radioBtn_footPadel.Checked = !radioBtn_fingerControl.Checked; // 脚踏, sw mode =1
            }
            if (guiParam.curPumpLevel != -1)
                vScrollBar_waterPump.Value = guiParam.curPumpLevel; //水泵
            if (guiParam.curPwrLevel != -1)
                vScrollBar_pwr.Value = guiParam.curPwrLevel; //能量档位
            if (guiParam.osc_mode != -1)
                textBox_pump_level.Text = guiParam.curPumpLevel.ToString(); //水泵数值
            if (guiParam.curPwrLevel != -1)
                textBox_pwr_level.Text = guiParam.curPwrLevel.ToString(); //能量档位数值
        }

        //水泵
        private void btn_pump_increase_Click(object sender, EventArgs e)
        {
            if (vScrollBar_waterPump.Value > 20)
                return;

            Console.WriteLine(vScrollBar_waterPump.Value);
            vScrollBar_waterPump.Value += 1;
            int val = vScrollBar_waterPump.Value;
            textBox_pump_level.Text = val.ToString();
            string msg = BVDentalCareSystem.CommandParse.CommandParse.SendPeridonticMsg(
                PeridonticTherapyDeviceMsgType.SET_CUR_PUMP_LEVEL, val);
            ToothCleanerMsgOut(msg);

        }

        private void btn_pump_descend_Click(object sender, EventArgs e)
        {
            if (vScrollBar_waterPump.Value < 0)
                return;

            vScrollBar_waterPump.Value -= 1;
            int val = vScrollBar_waterPump.Value;
            textBox_pump_level.Text = val.ToString();
            string msg = BVDentalCareSystem.CommandParse.CommandParse.SendPeridonticMsg(
                    PeridonticTherapyDeviceMsgType.SET_CUR_PUMP_LEVEL, vScrollBar_waterPump.Value);
            ToothCleanerMsgOut(msg);

        }

        private void btn_pwr_increase_Click(object sender, EventArgs e)
        {
            if (vScrollBar_pwr.Value >= 0 && vScrollBar_pwr.Value < 18)
            {
                vScrollBar_pwr.Value += 1;
                int val = vScrollBar_pwr.Value;
                textBox_pwr_level.Text = val.ToString();
                string msg = BVDentalCareSystem.CommandParse.CommandParse.SendPeridonticMsg(
                    PeridonticTherapyDeviceMsgType.SET_CUR_PWR_LEVEL, val);
                ToothCleanerMsgOut(msg);
            }
        }

        private void btn_pwr_descend_Click(object sender, EventArgs e)
        {
            if (vScrollBar_pwr.Value >= 0 && vScrollBar_pwr.Value < 18)
            {
                if (vScrollBar_pwr.Value == 0)
                    return;
                vScrollBar_pwr.Value -= 1;
                int val = vScrollBar_pwr.Value;
                textBox_pwr_level.Text = val.ToString();
                string msg = BVDentalCareSystem.CommandParse.CommandParse.SendPeridonticMsg(
                    PeridonticTherapyDeviceMsgType.SET_CUR_PWR_LEVEL, val);
                ToothCleanerMsgOut(msg);
            }
        }


        //一次读取所有参数
        private void ReadParam(PeridonticTherapyDeviceMsgType type, bool isRdAllParam)
        {
            if (isRdAllParam)
            {
                ToothCleanerMsgOut(BVDentalCareSystem.CommandParse.CommandParse.SendPeridonticMsg(PeridonticTherapyDeviceMsgType.RD_PWR_LEVELS, 0));
                ToothCleanerMsgOut(BVDentalCareSystem.CommandParse.CommandParse.SendPeridonticMsg(PeridonticTherapyDeviceMsgType.RD_CUR_PWR_LEVEL, 0));
                ToothCleanerMsgOut(BVDentalCareSystem.CommandParse.CommandParse.SendPeridonticMsg(PeridonticTherapyDeviceMsgType.RD_PWR_MODE, 0));
                ToothCleanerMsgOut(BVDentalCareSystem.CommandParse.CommandParse.SendPeridonticMsg(PeridonticTherapyDeviceMsgType.RD_PUMP_LEVELS, 0));
                ToothCleanerMsgOut(BVDentalCareSystem.CommandParse.CommandParse.SendPeridonticMsg(PeridonticTherapyDeviceMsgType.RD_CUR_PUMP_LEVEL, 0));
                ToothCleanerMsgOut(BVDentalCareSystem.CommandParse.CommandParse.SendPeridonticMsg(PeridonticTherapyDeviceMsgType.RD_PUMP_MODE, 0));
                ToothCleanerMsgOut(BVDentalCareSystem.CommandParse.CommandParse.SendPeridonticMsg(PeridonticTherapyDeviceMsgType.RD_OSC_STATE, 0));
                ToothCleanerMsgOut(BVDentalCareSystem.CommandParse.CommandParse.SendPeridonticMsg(PeridonticTherapyDeviceMsgType.RD_OSC_MODE, 0));
                ToothCleanerMsgOut(BVDentalCareSystem.CommandParse.CommandParse.SendPeridonticMsg(PeridonticTherapyDeviceMsgType.RD_SW_MODE, 0));
            }
            else
            {
                ToothCleanerMsgOut(BVDentalCareSystem.CommandParse.CommandParse.SendPeridonticMsg(type, 0));
            }
        }

        private void ToothCleanerSettingControl_Load(object sender, EventArgs e)
        {
            string pumpLevelStr = textBox_pump_level.Text;
            int pumLevel = Convert.ToInt32(pumpLevelStr);
            vScrollBar_waterPump.Value = pumLevel;

            string pwrLevelStr = textBox_pwr_level.Text;
            int pwrLevel = Convert.ToInt32(pwrLevelStr);
            vScrollBar_pwr.Value = pwrLevel;

        }
    }
}
