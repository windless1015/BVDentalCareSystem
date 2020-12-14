using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXVideoPlayer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 instance = new Form1();
            instance.folderPath = @"E:\project\BVDentalCareSystem\BVDentalCareSystem\bin\x86\Debug\PatientInfoDir\尚涛_1607359564";
            instance.needPlayFile = "20201209222334.avi";
            Application.Run(instance);
        }
    }
}
