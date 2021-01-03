using System;
using LibUsbDotNet;
using LibUsbDotNet.Main;
using BVDentalCareSystem.CommandParse;

namespace BVDentalCareSystem.CommandParse
{
    class USBHelper : ICommunicationBase
    {
        private UsbDevice MyUsbDevice = null;
        private UsbEndpointReader reader = null;
        private UsbEndpointWriter writer = null;

        private int deviceVid;
        private int devicePid;
        public event EventHandler<RecvMsgEventArgs> MsgReceivedHandler; //接受到数据
        private RecvMsgEventArgs args = new RecvMsgEventArgs();

        public USBHelper(int vid, int pid)
        {
            deviceVid = vid;
            devicePid = pid;
            args.deviceType = 2; //表示口腔观察
        }


        public bool Open()
        {
            UsbDeviceFinder myUsbFinder = new UsbDeviceFinder(deviceVid, devicePid);
            try
            {
                MyUsbDevice = UsbDevice.OpenUsbDevice(myUsbFinder);
                if (MyUsbDevice == null)
                    throw new Exception("Device Not Found.");
                IUsbDevice wholeUsbDevice = MyUsbDevice as IUsbDevice;
                if (!ReferenceEquals(wholeUsbDevice, null))
                {
                    wholeUsbDevice.SetConfiguration(1);
                    wholeUsbDevice.ClaimInterface(0);
                }
                reader = MyUsbDevice.OpenEndpointReader(ReadEndpointID.Ep01, 8, EndpointType.Interrupt); //这里非常重要,设置为中断模式
                writer = MyUsbDevice.OpenEndpointWriter(WriteEndpointID.Ep01);

                reader.DataReceivedEnabled = true;
                reader.ReadBufferSize = 8;//设置读取bufer的大小
                reader.ReadThreadPriority = System.Threading.ThreadPriority.Highest;
                reader.DataReceived += (OnRxEndPointData);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Close()
        {
            if (MyUsbDevice != null)
            {
                if (MyUsbDevice.IsOpen)
                {
                    IUsbDevice wholeUsbDevice = MyUsbDevice as IUsbDevice;
                    if (!ReferenceEquals(wholeUsbDevice, null))
                    {
                        wholeUsbDevice.ReleaseInterface(0);
                    }
                    MyUsbDevice.Close();
                }
            }
            MyUsbDevice = null;
            UsbDevice.Exit();
        }

        public void SendCmdMsg(string msg)
        {
            Console.WriteLine(msg);
            byte[] bytesToWriteBuffer = StringOperator.ConvertStringToByteArray(msg);
            //byte[] writeBuffer = new byte[8];
            //for (int i = 0; i < 8; i++)
            //{
            //    if (i < msg.Length)
            //    {
            //        char ss = msg[i];
            //        byte c = Convert.ToByte(msg[i]);

            //        writeBuffer[i] = c;
            //    }
            //}

            int bytesWritten;
            writer.Write(bytesToWriteBuffer, 100, out bytesWritten);
        }


        public byte[] RecvCmdMsg()
        {
            byte[] readBuffer = new byte[8];
            try
            {
                if (MyUsbDevice.IsOpen)
                {
                    UsbEndpointReader reader = MyUsbDevice.OpenEndpointReader(ReadEndpointID.Ep01);
                    int bytesRead;
                    reader.Read(readBuffer, 100, out bytesRead);
                    return readBuffer;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public void OnRxEndPointData(object sender, EndpointDataEventArgs e)
        {
            byte[] recvBytes = e.Buffer;
            if (!isValid(ref recvBytes))
                return;
            string recvMsgStr = StringOperator.ByteArrayToString3(e.Buffer);
            Console.WriteLine(recvMsgStr);
            args.ReceivedMsg = recvMsgStr;
            USBRecvMsgNotifyEvent(args);//向外通知usb收到了指令
        }

        private bool isValid(ref byte[] msg)
        {
            bool res = false;
            for (int i = 0; i < 8; i++)
            {
                if (msg[i] != 0)
                    res = true;
            }
            return res;
        }

        protected virtual void USBRecvMsgNotifyEvent(RecvMsgEventArgs e)
        {
            MsgReceivedHandler?.Invoke(this, e);
        }
    }
}
