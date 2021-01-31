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
using System.Threading;

namespace BVDentalCareSystem.SelfDefinedControls
{
    public partial class TeethCleanerPanel : UserControl
    {
        private bool recvReturnShakeHandMsg = false;//是否收到握手的回复指令
        public delegate void ToothCleanerMsgOutEvent(string msg);
        public event ToothCleanerMsgOutEvent ToothCleanerMsgOut;
        public TeethCleanerPanel()
        {
            InitializeComponent();
        }
       ~TeethCleanerPanel()
        {
            timer_shakeHand.Stop();
            timer_oscModel.Stop();
        }
        private void TeethCleanerPanel_Load(object sender, EventArgs e)
        {
            Thread.Sleep(500);
            //程序进来的时候,就读一次数据,显示到界面上
            SendMsgToReadParam(true, PeridonticTherapyDeviceMsgType.CUR_SOFTWARE_GUI_STATE);
            
        }

        public void StartSendShakeHandMsg()
        {
            timer_shakeHand.Start();
            timer_oscModel.Start();
        }

        private void btn_init_Click(object sender, EventArgs e)
        {
            string msg = BVDentalCareSystem.CommandParse.CommandParse.SendPeridonticMsg(
                    PeridonticTherapyDeviceMsgType.RST_FACTOR, 0);
            ToothCleanerMsgOut(msg);
            Thread.Sleep(50);
            SendMsgToReadParam(true, PeridonticTherapyDeviceMsgType.CUR_SOFTWARE_GUI_STATE);
            Thread.Sleep(500);
        }

        //把所有参数都重新设置到GUI界面上
        public void UpdateALLParam2GUI(AllParamItem guiParam)
        {
            if (guiParam.osc_mode != -1)
            {
                Action actionDelegate = () => { 
                    label_osc_mode.Text = (guiParam.osc_mode == 0) ? "洁牙模式" : "骨刀模式"; 
                };
                label_osc_mode.Invoke(actionDelegate);

                Action actionDelegate1 = () => {
                    if(guiParam.osc_mode == 1)
                    radioBtn_fingerControl.Enabled = false;
                    else
                        radioBtn_fingerControl.Enabled = true;
                };
                radioBtn_fingerControl.Invoke(actionDelegate1);

            }
                
            if (guiParam.osc_state != -1)
            {
                Action actionDelegate = () => {label_osc_state.Text = (guiParam.osc_state == 0) ? "空闲" : "工作";  };//空闲, 工作
                label_osc_state.Invoke(actionDelegate);

            }
                
            if (guiParam.sw_mode != -1)
            {
                Action actionDelegate1 = () => { radioBtn_fingerControl.Checked = (guiParam.sw_mode == 1) ? false : true; };//指控 手柄开关, swMode = 0
                radioBtn_fingerControl.Invoke(actionDelegate1);

                Action actionDelegate2 = () => { radioBtn_footPadel.Checked = !radioBtn_fingerControl.Checked; }; // 脚踏, sw mode =1
                radioBtn_footPadel.Invoke(actionDelegate2);
            }
            if (guiParam.curPumpLevel != -1)
            {
                Action actionDelegate = () => { vScrollBar_waterPump.Value = guiParam.curPumpLevel; };
                vScrollBar_waterPump.Invoke(actionDelegate);
            }

            if (guiParam.curPwrLevel != -1)
            {
                Action actionDelegate = () => { vScrollBar_pwr.Value = guiParam.curPwrLevel;  };//能量档位
                vScrollBar_pwr.Invoke(actionDelegate);
            }

            if (guiParam.curPumpLevel != -1)
            {
                Action actionDelegate = () => { textBox_pump_level.Text = guiParam.curPumpLevel.ToString(); };//水泵数值
                textBox_pump_level.Invoke(actionDelegate);
            }
                if (guiParam.curPwrLevel != -1)
            {
                Action actionDelegate = () => { textBox_pwr_level.Text = guiParam.curPwrLevel.ToString(); };//能量档位数值
                textBox_pwr_level.Invoke(actionDelegate);
            }
                 
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
        private void SendMsgToReadParam(bool isRdAllParam, PeridonticTherapyDeviceMsgType type)
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

        //每100ms发送一次握手帧
        private void timer_shakeHand_Tick(object sender, EventArgs e)
        {
            recvReturnShakeHandMsg = false;
            string msg = BVDentalCareSystem.CommandParse.CommandParse.SendPeridonticMsg(
                PeridonticTherapyDeviceMsgType.SHAKE_HAND, 0);
            ToothCleanerMsgOut(msg);
            Thread.Sleep(10);
            if (recvReturnShakeHandMsg == false)
            {
                label_connStatus.BackColor = Color.Red;
                label_desc.Text = "未连接";
            }
        }

        //从上位机收到了握手的回复指令,
        public void RecvShakeHandMsgFromUpperWare()
        {
            Action actionDelegate1 = () => { label_connStatus.BackColor = Color.Green; };
                label_connStatus.Invoke(actionDelegate1);

            Action actionDelegate2 = () => { label_desc.Text = "已连接"; };
            label_desc.Invoke(actionDelegate2);

            recvReturnShakeHandMsg = true;
        }

        private void radioBtn_fingerControl_CheckedChanged(object sender, EventArgs e)
        {
            //如果设置为指控模式,
            if (radioBtn_fingerControl.Checked)
            {
                radioBtn_footPadel.Checked = false;
                //发送指控指令
                string msg = BVDentalCareSystem.CommandParse.CommandParse.SendPeridonticMsg(
                PeridonticTherapyDeviceMsgType.SET_SW_MODE, 0); //这里0表示指控
                ToothCleanerMsgOut(msg);
            }
        }

        private void radioBtn_footPadel_CheckedChanged(object sender, EventArgs e)
        {

            //如果设置为脚踏模式,
            if (radioBtn_footPadel.Checked)
            {
                radioBtn_fingerControl.Checked = false;
                //发送脚踏指令
                string msg = BVDentalCareSystem.CommandParse.CommandParse.SendPeridonticMsg(
                PeridonticTherapyDeviceMsgType.SET_SW_MODE, 1); //这里1表示脚踏
                ToothCleanerMsgOut(msg);
            }
        }

        //每200ms读取一次OSCModel的参数,判断是洁牙机还是骨刀
        private void timer_oscModel_Tick(object sender, EventArgs e)
        {
            string msg = BVDentalCareSystem.CommandParse.CommandParse.SendPeridonticMsg(
                PeridonticTherapyDeviceMsgType.RD_OSC_MODE, 0); //这里1表示脚踏
            ToothCleanerMsgOut(msg);
        }
    }
}
