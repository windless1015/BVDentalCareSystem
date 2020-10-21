using BVDentalCareSystem.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BVDentalCareSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            imageVideoBrowserSideBar.dataPath = @"E:\project\DSDentalEndoscopeViewer\DSDentalEndoscopeViewer\bin\x64\Debug\PatientInfoDir\李伟_1_2020-07-22";
            //imageVideoBrowserSideBar.dataPath = @"F:\projects\Bangvo\DSDentalEndoscopeViewer\DSDentalEndoscopeViewer\bin\x64\Debug\PatientInfoDir\李伟1_1_2020-03-16";
            imageVideoBrowserSideBar.SortOrderByTimeDescend();
            imageVideoBrowserSideBar.GroupItemByDate();
        }

        private void btn_patientInfo_Click(object sender, EventArgs e)
        {
            PatientsInfoForm pif = new PatientsInfoForm();
            pif.TopLevel = false; //重要的一个步骤
            pif.Parent = this.splitContainer.Panel2;
            pif.Location = new Point(0, panel_head.Height + 14);
            pif.Size = new Size(this.splitContainer.Panel2.Width - imageVideoBrowserSideBar.Width - 10, this.splitContainer.Panel2.Height - panel_head.Height);
            pif.Show();
            this.splitContainer.Panel2.Controls.Add(pif);
        }

        private void btn_periodontal_Click(object sender, EventArgs e)
        {

        }

        private void btn_oralView_Click(object sender, EventArgs e)
        {

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }


        private void panel_help_Click(object sender, EventArgs e)
        {

        }

        private void panel_about_Click(object sender, EventArgs e)
        {
            AboutBox aboutWindow = new AboutBox();
            aboutWindow.StartPosition = FormStartPosition.CenterScreen;
            aboutWindow.Show();
        }

    }
}
