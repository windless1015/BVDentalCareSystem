﻿using System;
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
            instance.folderPath = @"E:\testVideo";
            instance.needPlayFile = @"E:\testVideo\20201219125139.avi";
            Application.Run(instance);
        }
    }
}
