using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BVDentalCareSystem.Interfaces;

namespace BVDentalCareSystem.Forms
{
    public partial class PatientsInfoForm : Form
    {
        SqliteHelper sqlHeperInstance = null;
        public PatientsInfoForm()
        {
            InitializeComponent();
            if (sqlHeperInstance != null)
            {
                sqlHeperInstance = null;
            }
            //sqlHeperInstance = new SqliteHelper(); //实例化
        }

        private void PatientsInfoForm_Load(object sender, EventArgs e)
        {
            //设置控件属性
            SetControlsProperties();
            //禁止输入控件
            EnableOrDisableInputControls(false);

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

        private void textBox_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            //只允许输入中文和退格键
            System.Text.RegularExpressions.Regex rg = new System.Text.RegularExpressions.Regex("^[\u4e00-\u9fa5\b]$"); //\b是退格键
            if (!rg.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void textBox_phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键 
            {
                int len = textBox_phone.Text.Length;
                if (len < 1 && e.KeyChar == '0')
                {
                    e.Handled = true;
                }
                else if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字 
                {
                    e.Handled = true;
                }
                if (textBox_phone.Text.Length > 10)
                {
                    e.Handled = true;
                }
            }
        }

        private void textBox_identity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键 
            {
                int len = textBox_identity.Text.Length;
                if (len < 1 && e.KeyChar == '0')
                {
                    e.Handled = true;
                }
                else if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字 
                {
                    e.Handled = true;
                }
                if (textBox_identity.Text.Length > 8)
                {
                    e.Handled = true;
                }
            }
        }

        private void radioBtnMale_Click(object sender, EventArgs e)
        {
            radioBtnMale.Checked = true;
        }

        private void radioBtnFemale_Click(object sender, EventArgs e)
        {
            radioBtnFemale.Checked = true;
        }

        private void radioBtnMale_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnMale.Checked)
                radioBtnFemale.Checked = false;
        }

        private void radioBtnFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnFemale.Checked)
                radioBtnMale.Checked = false;
        }

        //鼠标进入表头
        private void DataView_Patients_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //判断当前cell是不是表头,nRowIdx 为-1表示表头
            int nRowIdx = e.RowIndex;
            if (nRowIdx > -1)
                return;
            int nColumnIndex = e.ColumnIndex;
            //把这个表头变色
            DataView_Patients.Columns[nColumnIndex].HeaderCell.Style.BackColor = Color.LightBlue;
        }

        //鼠标离开表头，颜色恢复为没有被选中
        private void DataView_Patients_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            int nRowIdx = e.RowIndex;
            if (nRowIdx > -1)
                return;
            int nColumnIndex = e.ColumnIndex;
            //把这个表头恢复原来颜色
            DataView_Patients.Columns[nColumnIndex].HeaderCell.Style.BackColor = Color.White;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////非UI类的函数借口/////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////
        //设置相关控件的属性
        private void SetControlsProperties()
        {
            //性别默认选择男性
            radioBtnMale.Checked = true;
            radioBtnFemale.Checked = false;
            // id这一列隐藏,暂时不需要隐藏,代码保留
            //DataView_Patients.Columns[0].Visible = false;

            //日期控件显示的格式
            dtpicker.Format = DateTimePickerFormat.Custom;
            dtpicker.CustomFormat = "yyyy-MM-dd";

            //指定某一列为指定的时间格式
            DataView_Patients.Columns[6].DefaultCellStyle.Format = "yyyy-MM-dd";
            DataView_Patients.RowHeadersVisible = false;
            DataView_Patients.AllowUserToAddRows = false; //否则显示的会多一个空白行
            //使表头不可编辑
            foreach (DataGridViewColumn column in DataView_Patients.Columns)
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            //禁止用户改变DataGridView1所有行的行高
            DataView_Patients.AllowUserToResizeRows = false;
            //去掉默认选中
            this.DataView_Patients.ClearSelection();
            //可以更改表头样式，否则后面涉及表头颜色改变的不起作用
            DataView_Patients.EnableHeadersVisualStyles = false;
            //所有cell居中
            DataView_Patients.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //设置字体
            DataView_Patients.DefaultCellStyle.Font = new Font("微软雅黑", 13);
            //禁止调整列宽
            DataView_Patients.AllowUserToResizeColumns = false;

        }

        //控制输入类型的控件使之能够输入或者输出
        private void EnableOrDisableInputControls(bool isEnable)
        {
            textBox_name.Enabled = isEnable;
            textBox_phone.Enabled = isEnable;
            textBox_identity.Enabled = isEnable;
            dtpicker.Enabled = isEnable;
            radioBtnFemale.Enabled = isEnable;
            radioBtnMale.Enabled = isEnable;
        }

    }
}
