using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVDentalCareSystem.CommandParse
{
    // 事件参数,必须继承类EventArgs
    public class RecvMsgEventArgs : EventArgs
    {
        public string ReceivedMsg { get; set; }
        public int deviceType { get; set; }
    }

    public interface ICommunicationBase //通信的基类, usb  串口  tcp通信模式都以此为接口
    {
        bool Open(); //打开通信
        void Close(); //关闭通信
        void SendCmdMsg(string msg); //发送指令消息
        //byte[] RecvCmdMsg(); //接受指令消息
        byte[] RecvCmdMsg(); //接受指令消息
        event EventHandler<RecvMsgEventArgs> MsgReceivedHandler; //接受到数据
    }
}
