using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Threading;
using BVDentalCareSystem.CommandParse;

namespace BVDentalCareSystem.CommandParse
{
    class SerialPortHelper : ICommunicationBase
    {
        //此处是设置初始状态false表示无信号状态，true表示有信号状态
        //private ManualResetEvent _manualResetEvent = new ManualResetEvent(false);

        public SerialPort comPortDevice = null; //真正可以通信的串口
        private string comPort = null;  //串口号
        private byte[] recvBytes = new byte[8];
        // 事件对象
        public event EventHandler<RecvMsgEventArgs> MsgReceivedHandler;
        private RecvMsgEventArgs args = new RecvMsgEventArgs();

        public SerialPortHelper(string com)
        {
            comPort = com;
        }

        public bool Open()
        {
            comPortDevice = new SerialPort();//构造串口设备
            comPortDevice.PortName = comPort;
            comPortDevice.BaudRate = 115200;
            comPortDevice.Parity = Parity.None;
            comPortDevice.DataBits = 8;
            comPortDevice.StopBits = StopBits.One;
            comPortDevice.ReadBufferSize = 8; //设置读取的buffer size
            comPortDevice.WriteBufferSize = 8; //设置发送的buffer size
            comPortDevice.Open();

            comPortDevice.DataReceived += ComPortDevice_DataReceived;
            return comPortDevice.IsOpen;
        }

        public void Close()
        {
            comPortDevice.Close();
            comPortDevice.Dispose();
        }

        public void SendCmdMsg(string msg)
        {
            byte[] CmdBytes = StringOperator.ConvertStringToByteArray2(msg);
            comPortDevice.Write(CmdBytes, 0, CmdBytes.Length);
        }
        public byte[] RecvCmdMsg()
        {
            return recvBytes;
        }

        private void ComPortDevice_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort comDeviceInstance = (SerialPort)sender;
            byte[] recvDataBytes = new byte[comDeviceInstance.BytesToRead];
            comDeviceInstance.Read(recvDataBytes, 0, recvDataBytes.Length);//读取数据

            string str = StringOperator.ByteArrayToString(recvDataBytes);//5AA508F1A111A55A
            
            args.ReceivedMsg = str;
            args.deviceType = 1; //1表示牙周观察
            SerialPortRecvMsgNotifyEvent(args);//向外界发送收到信息的事件

        }



        protected virtual void SerialPortRecvMsgNotifyEvent(RecvMsgEventArgs e)
        {
            MsgReceivedHandler?.Invoke(this, e);
        }

    }

    
}
