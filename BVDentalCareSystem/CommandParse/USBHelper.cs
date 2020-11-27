using System;
using LibUsbDotNet;
using LibUsbDotNet.Main;

namespace BVDentalCareSystem.CommandParse
{
    class USBHelper
    {
        private UsbDevice MyUsbDevice = null;
        private UsbEndpointReader reader = null;
        private UsbEndpointWriter writer = null;
        string LastCommand = "0001000000010000";
        public bool OpenDevice(int vid, int pid)
        {
            UsbDeviceFinder myUsbFinder = new UsbDeviceFinder(vid, pid);
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

                reader.DataReceived += (OnRxEndPointData);
                reader.DataReceivedEnabled = true;
                reader.ReadBufferSize = 8;//设置读取bufer的大小
                reader.ReadThreadPriority = System.Threading.ThreadPriority.Highest;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void CloseDevice()
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

        public void Write(string cmd)
        {
            byte[] bytesToWriteBuffer = StringOperator.ConvertStringToByteArray2(cmd);
            int bytesWritten;
            writer.Write(bytesToWriteBuffer, 100, out bytesWritten);
        }

        //本函数不停的刷新在
        public void OnRxEndPointData(object sender, EndpointDataEventArgs e)
        {
            string currentCommand = StringOperator.ByteArrayToString2(e.Buffer);
            //Console.WriteLine(currentCommand);
            if (!LastCommand.Equals(currentCommand))
            {
                RecvCommandChangedEventArgs args = new RecvCommandChangedEventArgs();
                args.ReceivedCommand = LastCommand = currentCommand;
                OnRecvCommandChanged(args);
            }
        }

        protected virtual void OnRecvCommandChanged(RecvCommandChangedEventArgs e)
        {
            RecvCommandChanged?.Invoke(this, e);
        }

        public event EventHandler<RecvCommandChangedEventArgs> RecvCommandChanged;
    }
}
