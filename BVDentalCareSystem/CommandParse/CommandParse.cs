using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVDentalCareSystem.CommandParse
{
   

    #region 牙周观察仪指令
    enum PeridonticCameraMsgType
    { 
        RD_WATER_PUMP_CLOSE = 0xF1A100,  //读取水泵关闭信号
        SEND_WATER_PUMP_CLOSE = 0xF1A200,  //水泵关闭信号

        RD_AIR_PUMP_CLOSE = 0xF2A100,  //读取气泵关闭信号
        SEND_AIR_PUMP_CLOSE = 0xF2A200,  //发送气泵关闭信号

        RD_WATER_PUMP_OPEN = 0xF1A111,  //读取水泵打开信号
        SEND_WATER_PUMP_OPEN = 0xF1A211,  //发送水泵打开信号

        RD_AIR_PUMP_OPEN = 0xF2A111,  //读取气泵打开信号
        SEND_AIR_PUMP_OPEN = 0xF2A211,  //发送气泵打开信号

        RD_TAKE_PHOTO = 0xF0A111,  //读取拍照指令
        SEND_TAKE_PHOTO = 0xF0A211,  //发送拍照指令

    }

    #endregion

    #region 口腔内窥镜指令
    enum OralCameraMsgType
    {
        DORMINANT = 0x11111111,  //休眠
        TAKE_PHOTO = 0x02000200, //受到拍照
        MICROLEN_MODE = 0x01000100, //微距模式
        NORMAL_MODE = 0x14000500, //一般模式
        FIGURE_MODE = 0x2A000C00, //人像模式

        SEND_MICROLEN_MODE = 0x01010200, //上位机发给下位机的微距模式  01010200
        SEND_NORMAL_MODE = 0x14010600, //上位机发给下位机的normal模式  14010600
        SEND_FIGURE_MODE = 0x2A010D00, //上位机发给下位机的figure模式  2a010d00
    }

    #endregion

    #region 洁牙机仪器洁牙机指令
    enum PeridonticTherapyDeviceMsgType
    {
        SHAKE_HAND = 0xD0,
        RST_FACTOR = 0xD5,
        SAVE_PARA = 0xDA,
        CUR_SOFTWARE_GUI_STATE = 0xD1,

        RD_PWR_LEVELS = 0xA0,
        RD_CUR_PWR_LEVEL = 0xA1,
        RD_PWR_MODE = 0xA2,
        RD_PUMP_LEVELS = 0xA3,
        RD_CUR_PUMP_LEVEL = 0xA4,
        RD_PUMP_MODE = 0xA5,
        RD_OSC_STATE = 0xA6,
        RD_OSC_MODE = 0xA7,
        RD_SW_MODE = 0xA8,

        SET_CUR_PWR_LEVEL = 0xB1,
        SET_PWR_MODE = 0xB2,
        SET_CUR_PUMP_LEVEL = 0xB0,
        SET_PUMP_MODE = 0xB3,
        SET_SW_STATE = 0xB4,
        SET_SW_MODE = 0xB5
    }

    //所有关于牙周治疗仪的数据
    public struct AllParamItem
    {
        public int pwrLevels { get; set; } //功率总档数
        public int curPwrLevel { get; set; } //当前功率档数
        public int pwrMode { get; set; } //功率模式
        public int pumpLevels { get; set; } //水泵总档数
        public int curPumpLevel { get; set; } //当前水泵档数
        public int pumpMode { get; set; } //当前水泵模式
        public int osc_state { get; set; } //震荡器工作状态
        public int osc_mode { get; set; } //振荡器工作模式
        public int sw_mode { get; set; } //开关模式

        public AllParamItem(int defaultVal)
        {
            pwrLevels = defaultVal;
            curPwrLevel = defaultVal;
            pwrMode = defaultVal;
            pumpLevels = defaultVal;
            curPumpLevel = defaultVal;
            pumpMode = defaultVal;
            osc_state = defaultVal;
            osc_mode = defaultVal;
            sw_mode = defaultVal;
        }

    }


    #endregion

    class CommandParse
    {


        #region 牙周观察仪

        #endregion

        #region 口腔观察仪

        #endregion


        #region 洁牙机仪器
        public static string SendPeridonticMsg(PeridonticTherapyDeviceMsgType type, int param)
        {
            int typeNum = Convert.ToInt32(type);
            string typeUpperString = typeNum.ToString("X").PadLeft(2, '0');
            string paramUpperString = param.ToString("X").PadLeft(2, '0');
            string msg = "5A A5 08 " + typeUpperString + " A2 " + paramUpperString + " A5 5A";
            return msg;
        }

        public static void ReadPeridonticMsg(ref string recvMsg,
            out PeridonticTherapyDeviceMsgType type, out int param)
        {
            //"5A A5 08 B0 A1 01 A5 5A"

            //根据第三个byte判断指令类型
            string typeNumStr = recvMsg.Substring(9, 2);
            string valStr = recvMsg.Substring(15, 2);
            int typeNum = Convert.ToInt32(typeNumStr, 16);
            type = (PeridonticTherapyDeviceMsgType)typeNum;
            param = Convert.ToInt32(valStr, 16);
        }
        #endregion



    }
}
