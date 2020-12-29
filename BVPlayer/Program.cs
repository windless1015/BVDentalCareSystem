using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace vlc.net
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
            instance.needPlayFile = args[0];
            instance.folderPath = args[1];

            //instance.needPlayFile = @"E:\BVSoftware\BVDentalCareSystem\bin\x86\Debug\PatientInfoDir\张凯_1609174453\20201229015153.avi";
            //instance.folderPath = @"E:\BVSoftware\BVDentalCareSystem\bin\x86\Debug\PatientInfoDir\张凯_1609174453\";
            Application.Run(instance);
        }
    }
}
