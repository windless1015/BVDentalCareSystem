using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BVDentalCareSystem.SelfDefinedControls
{
    public partial class PatientDisplayForm : Form
    {
        public delegate void PassPatientInfoDataEvent(string opType, string name, string phone, string identityNum,
            string gender, DateTime birth);
        public event PassPatientInfoDataEvent PassParamNotify;

        private string m_OpType = "";// 操作类型
        public PatientDisplayForm()
        {
            InitializeComponent();
            textBox_name.Focus();
        }

        public void SetPatientInfoData(string opType, string name, string phone, string identityNum,
            string gender, DateTime birth)
        {
            m_OpType = opType;
            textBox_name.Text = name;
            textBox_phone.Text = phone;
            textBox_identity.Text = identityNum;
            radioBtnMale.Checked = (gender == "男") ? true : false;
            radioBtnFemale.Checked = (gender == "女") ? true : false;
            dtpicker.Value = birth;
        }

        public void OutputPatientInfoData(out string OpType, out string name, out string phone, out string identityNum,
            out string gender, out DateTime birth)
        {
            OpType = m_OpType;
            name = textBox_name.Text.Trim();
            phone = textBox_phone.Text.Trim();
            identityNum = textBox_identity.Text.Trim();
            gender = radioBtnMale.Checked ? "男" : "女";
            birth = dtpicker.Value;
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            if (!JudgeNameIsValid(textBox_name.Text.Trim()))
                return;
            if (m_OpType == "add" || m_OpType == "modify")
            {
                //电话
                if (!JudgePhoneNumber(textBox_phone.Text.Trim()))
                    return;
                //判断社保
                if (!JudgeIdentityNumber(textBox_identity.Text.Trim()))
                    return;
            }
            string opType, name, phone, identityNum, gender;
            DateTime birth;
            OutputPatientInfoData(out opType, out name, out phone, out identityNum, out gender, out birth);
            PassParamNotify(opType, name, phone, identityNum, gender, birth);
            Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void textBox_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            //只允许输入中文和退格键
            System.Text.RegularExpressions.Regex rg = new System.Text.RegularExpressions.Regex("^[\u4e00-\u9fa5\b]$"); //\b是退格键
            if (!rg.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private bool JudgeNameIsValid(string name)
        {
            string pat = @"[\u4e00-\u9fa5]";
            Regex rg = new Regex(pat);
            Match mh = rg.Match(textBox_name.Text);
            if (mh.Success)
                return true;
            MessageBox.Show("只能输入中文和英文字母！");
            //textBox_name.Undo();
            textBox_name.Text = "";
            return false;
        }

        private bool JudgeIdentityNumber(string phone)
        {
            if (textBox_identity.Text.Length != 9)
            {
                MessageBox.Show("社保号码为9位数字,请检查社保号是否正确！", "社保号错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool JudgePhoneNumber(string phone)
        {
            if (textBox_phone.Text.Length != 11)
            {
                MessageBox.Show("电话号码为11位数字,请检查电话号码是否正确！", "电话号码错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

    }
}
