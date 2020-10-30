using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BVDentalCareSystem.Forms
{
    public partial class PatientsInfoForm : Form
    {
        public PatientsInfoForm()
        {
            InitializeComponent();
        }

        private void Button_query_Click(object sender, EventArgs e)
        {

        }

        private void Button_add_Click(object sender, EventArgs e)
        {

        }

        private void Button_modify_Click(object sender, EventArgs e)
        {

        }

        private void Button_delete_Click(object sender, EventArgs e)
        {

        }

        private void PatientsInfoForm_Resize(object sender, EventArgs e)
        {
            this.DataView_Patients.Height = this.Height - this.GroupBox_Operation.Height - 10;
        }
    }
}
