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
    public partial class DoctorInfoForm : Form
    {
        public DoctorInfoForm()
        {
            InitializeComponent();
            //避免第一行多出来一个空白行
            dataGridView_doctorInfo.AllowUserToAddRows = false;
            //列标题居中
            dataGridView_doctorInfo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public void SetDataTable(ref DataTable dt)
        {
            dataGridView_doctorInfo.DataSource = dt;
        }

    }
}
