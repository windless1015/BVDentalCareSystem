using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BVDentalCareSystem.Forms;
using BVDentalCareSystem.CommandParse;

namespace BVDentalCareSystem
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainForm());
            Login logForm = new Login();
            logForm.ShowDialog();
            if (logForm.DialogResult == DialogResult.OK)
            {
                string phone = logForm.GetcurDoctorLoginAccount();
                MainForm mainForm = new MainForm();
                mainForm.rootPath = Common.CurApplicationPath + @"PatientInfoDir\" + phone + @"\";
                Application.Run(mainForm);
            }
            logForm.Dispose();
        }
    }
}
