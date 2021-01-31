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
        public int deviceType { get; set; }


        private byte[] onePieceOfMsg = new byte[8]; //一次接收到的8个字节的数据
        bool pieceMsgReady = false;
        int curLastBitOfMsgBuff = 0;// 记录当前8个数据字节的最后一位

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
            byte[] CmdBytes;
            if (deviceType == 4)
            {
                CmdBytes = StringOperator.ConvertStringToByteArray(msg);
            }
            else
                CmdBytes = StringOperator.ConvertStringToByteArray2(msg);

            comPortDevice.Write(CmdBytes, 0, CmdBytes.Length);
        }
        public byte[] RecvCmdMsg()
        {
            return recvBytes;
        }

        private void ComPortDevice_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort comDeviceInstance = (SerialPort)sender;
            int bytsToReadNum = comDeviceInstance.BytesToRead;
            byte[] recvDataBytes = new byte[bytsToReadNum];
            comDeviceInstance.Read(recvDataBytes, 0, recvDataBytes.Length);//读取数据

            if (deviceType == 4)
            {
                //有可能一次读入超过8个字节,即 recvDataBytes 长度超过8
                //只取前8个字节,后面的字节再次读入
                int readTimes = (recvDataBytes.Length % 8 == 0) ? recvDataBytes.Length / 8 : recvDataBytes.Length / 8 + 1; //如果长度为小于等于8, 那么readTimes为1,大于8 则根据具体长度来计算
                for(int i=0; i < readTimes; i++)
                {
                    int curBytesNum = 0; //本次需要读入的字节数
                    if (bytsToReadNum % 8 == 0) //8的倍数
                    {
                        curBytesNum = 8;
                    }
                    else //不是8的倍数
                    {
                        if (i < readTimes - 1)
                        {
                            curBytesNum = 8;
                        }
                        else
                            curBytesNum = bytsToReadNum % 8;
                    }

                    byte[] curProcessBytes = new byte[curBytesNum];//构造本地处理的字节数
                    //把真实的byte[]拷贝过来
                    for (int j = 0; j < curBytesNum; j++)
                    {
                        int realIdx = i * 8 + j;
                        curProcessBytes[j] = recvDataBytes[realIdx];
                    }
                    string readBytesStr = StringOperator.ByteToHex(curProcessBytes);
                    Construct8BytesMsg("5A", ref readBytesStr, ref curProcessBytes, ref curBytesNum);

                    if (pieceMsgReady)
                    {
                        args.ReceivedMsg = StringOperator.ByteToHex(onePieceOfMsg);
                        args.deviceType = deviceType; //1表示牙周观察, 4表示洁牙机
                        SerialPortRecvMsgNotifyEvent(args);//向外界发送收到信息的事件
                                                           //使用完毕之后就清空
                        for (int m = 0; m < 8; m++)
                        {
                            onePieceOfMsg[m] = 0;
                        }
                        curLastBitOfMsgBuff = 0;
                        pieceMsgReady = false;
                    }
                }

                
            }
            else
            {
                string str = StringOperator.ByteArrayToString(recvDataBytes);//5AA508F1A111A55A
                args.ReceivedMsg = str;
                args.deviceType = deviceType; //1表示牙周观察, 4表示洁牙机
                SerialPortRecvMsgNotifyEvent(args);//向外界发送收到信息的事件

            }
        }



        protected virtual void SerialPortRecvMsgNotifyEvent(RecvMsgEventArgs e)
        {
            MsgReceivedHandler?.Invoke(this, e);
        }


        //通过头帧检测什么时候开始计算,然后来构造8个字节的字节消息
        private void Construct8BytesMsg(string headFram, ref string bytesReadStr, ref byte[] bytesRead, ref int bytesNum)
        {
            //根据头帧开始算起, 输入的只能是 "5A"  "FF" 类似这样的数据格式
            string first2Letter = bytesReadStr.Substring(0, 2);

            //因为这个指令
            if (headFram.Equals(first2Letter) && (curLastBitOfMsgBuff != 6)) //说明就是需要写入到指定缓冲池
            {

                Array.Copy(bytesRead, onePieceOfMsg, bytesNum);
                curLastBitOfMsgBuff = bytesNum - 1; //因为是从0开始的
                pieceMsgReady = (bytesNum == 8) ? true : false; //如果一次性接受到8个字节,那么pieceMsgReady就为true,否则为false
            }
            else
            {
                for (int i = 0; i < bytesNum; i++)
                {
                    onePieceOfMsg[curLastBitOfMsgBuff + 1 + i] = bytesRead[i];
                }
                curLastBitOfMsgBuff += bytesNum;
                if (curLastBitOfMsgBuff == 7)
                    pieceMsgReady = true;
                else
                    pieceMsgReady = false;
            }


        }

    }

    
}
