using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Threading;
using System.Runtime.InteropServices;

namespace BVDentalCareSystem.CommandParse
{
    class SerialPortHelper
    {
        //读取ini文件
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(string section, string key, string def,
                                                      StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        //此处是设置初始状态false表示无信号状态，true表示有信号状态
        private ManualResetEvent _manualResetEvent = new ManualResetEvent(false);
        public SerialPort comPortDevice = null; //真正可以通信的串口
        string[] AllPortNamesList;
        private bool isFindDeviceFlag = true; //是否找到我们要的串口设备

        // 事件对象
        public event EventHandler<RecvCommandChangedEventArgs> SerialPortRecvCmdEvent;

        public SerialPortHelper()
        {
            comPortDevice = new SerialPort();//构造串口设备
            AllPortNamesList = SerialPort.GetPortNames();//获取当前系统中所有串口的名字,例如COM1, COM3
            comPortDevice.DataReceived += ComPortDevice_DataReceived;
            //autoEvent = new AutoResetEvent(true);//处于非终止状态
        }
        ~SerialPortHelper()
        {
            ClosePort();
            comPortDevice.Dispose();
        }

        public void ClosePort()
        {
            if (comPortDevice.IsOpen)
                comPortDevice.Close();
        }

        private void InitPort(string comName)
        {
            if (comPortDevice.IsOpen)
            {
                comPortDevice.Close();
            }
            comPortDevice.PortName = comName;
            comPortDevice.BaudRate = 115200;
            comPortDevice.Parity = Parity.None;
            comPortDevice.DataBits = 8;
            comPortDevice.StopBits = StopBits.One;
            comPortDevice.Open();
        }

        //只要串口接收到数据
        private void ComPortDevice_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort comDeviceInstance = (SerialPort)sender;
            byte[] RecvDataBytes = new byte[comDeviceInstance.BytesToRead];
            comDeviceInstance.Read(RecvDataBytes, 0, RecvDataBytes.Length);//读取数据

            if (RecvDataBytes.Length % 8 != 0)// 不是8的倍数
            {
                //autoEvent.Set(); //接收完毕进行释放
                //comDeviceInstance.DiscardInBuffer();
                _manualResetEvent.Set();
                return;
            }
            List<byte[]> recvBytesList = StringOperator.SplitByteArray(ref RecvDataBytes);

            if (!isFindDeviceFlag) //进入寻找设备的阶段
            {
                byte[] TargetCmdBytes = new byte[] { 0x5A, 0xA5, 0x08, 0xFF, 0xA1, 0x11, 0xA5, 0x5A };
                foreach (byte[] curByte in recvBytesList)
                {

                    if (StringOperator.CompareFirstEightBytes(curByte, ref TargetCmdBytes))
                    {
                        isFindDeviceFlag = true;
                        break;
                    }
                }


            }
            else
            {
                foreach (byte[] curByte in recvBytesList)
                {
                    string RecvCmd = StringOperator.ByteArrayToString(curByte);
                    RecvCommandChangedEventArgs args = new RecvCommandChangedEventArgs();
                    args.ReceivedCommand = RecvCmd;
                    args.deviceType = 1; //1表示牙周观察
                    SerialPortCmdRecvEvent(args);
                }

            }
            //autoEvent.Set(); //接收完毕进行释放
            //comDeviceInstance.DiscardInBuffer();
        }

        public void Open()
        {
            if (!comPortDevice.IsOpen)
                comPortDevice.Open();
        }

        public bool FindDevice()
        {
            ////测试用COM5
            //Array.Clear(AllPortNamesList, 0, AllPortNamesList.Length);
            ////string[] comDevs = new string[] { "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7",
            ////"COM8","COM9","COM10","COM11"};
            //string[] comDevs = new string[] { "COM3" };
            //AllPortNamesList = comDevs.ToArray();

            ////遍历所有串口,向每一个串口发送心跳指令"5AA508FFA211A55A", 串口如果收到5AA508FFA111A55A表示找到目标设备
            //foreach (string comName in AllPortNamesList)
            //{
            //    string heartBeatCommand = "5AA508FFA211A55A";
            //    InitPort(comName); //先打开设备
            //    if (comPortDevice.IsOpen)
            //    {
            //        byte[] CmdBytes = StringOperator.ConvertStringToByteArray2(heartBeatCommand);
            //        comPortDevice.Write(CmdBytes, 0, CmdBytes.Length);
            //        autoEvent.WaitOne(200); //阻塞,等待接收完毕,然后释放
            //        if (!isFindDeviceFlag)
            //        {
            //            //comPortDevice.Close();
            //        }
            //        else
            //        {                 
            //            return true;
            //        }
            //    }
            //}
            //return false;

            //读取ini文件
            StringBuilder comName = new StringBuilder(255);
            string path = System.Environment.CurrentDirectory + @"\COM.INI";
            //判断INI文件是否存在
            if (!System.IO.File.Exists(path))
            {
                WritePrivateProfileString("COM", "PORT", "COM3", path);
            }
            int i = GetPrivateProfileString("COM", "PORT", "", comName, 255, path);
            InitPort(comName.ToString()); //先打开设备
            return true;

        }

        public void SendReadySignal()
        {
            if (!comPortDevice.IsOpen)
                return;
            byte[] CmdBytes = StringOperator.ConvertStringToByteArray2("5AA508F3A211A55A");
            comPortDevice.Write(CmdBytes, 0, CmdBytes.Length);
            //autoEvent.WaitOne(250); //阻塞,等待接收完毕,然后释放
        }

        public void SendReplay(string reply)
        {
            if (!comPortDevice.IsOpen)
                return;
            byte[] CmdBytes = StringOperator.ConvertStringToByteArray2(reply);
            comPortDevice.Write(CmdBytes, 0, CmdBytes.Length);
            //autoEvent.WaitOne(250); //阻塞,等待接收完毕,然后释放
        }


        protected virtual void SerialPortCmdRecvEvent(RecvCommandChangedEventArgs e)
        {
            SerialPortRecvCmdEvent?.Invoke(this, e);
        }

    }

    // 事件参数,必须继承类EventArgs
    public class RecvCommandChangedEventArgs : EventArgs
    {
        public string ReceivedCommand { get; set; }
        public int deviceType { get; set; }
    }
}
