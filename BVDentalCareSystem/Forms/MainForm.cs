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
        }

        private void btn_patientInfo_Click(object sender, EventArgs e)
        {
            //Button a = new Button();
            //a.Text = "text";
            //a.Location = new Point(0, 100);
            //a.Show();
            //this.splitContainer.Panel2.Controls.Add(a);
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
