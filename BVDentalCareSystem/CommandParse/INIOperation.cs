using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace BVDentalCareSystem.CommandParse
{
    class INIOperation
    {
        //读取ini文件
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(string section, string key, string def,
                                                      StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        public static string ReadSerialPortINIFile()
        {
            //读取ini文件
            StringBuilder comName = new StringBuilder(255);
            string path = System.Environment.CurrentDirectory + @"\COM.INI";
            //判断INI文件是否存在
            if (!System.IO.File.Exists(path))
            {
                WritePrivateProfileString("COM", "PORT", "COM3", path);
                return "";
            }
            int i = GetPrivateProfileString("COM", "PORT", "", comName, 255, path);
            return comName.ToString();
        }


    }
}
