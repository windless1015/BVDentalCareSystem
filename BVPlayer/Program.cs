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

            //instance.needPlayFile = @"E:\TestFiles\Video.avi";
            //instance.folderPath = @"E:\TestFiles\";
            Application.Run(instance);
        }
    }
}
