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
using BVDentalCareSystem.CommandParse;
using System.Text.RegularExpressions;
using System.Data.SQLite;

namespace BVDentalCareSystem.Forms
{
    public partial class Login : Form
    {
        DoctorInfoForm doctorInfoForm = null;
        CSQLiteHelper csqliteDoctorInfoHelper = null; //这个数据是记录医生信息的, 给超级用户使用的
        string doctorInfoDbPath = null;
        private string curDoctorLoginAccount { get; set; }
        public Login()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel; //进来默认这个DialogResult是cancel,如果点击登录,则设置为OK
            doctorInfoDbPath = Common.CurApplicationPath +  "doctorInfo_t.db";
            csqliteDoctorInfoHelper = new CSQLiteHelper(doctorInfoDbPath);
            //判断db文件是否存在
            if (!System.IO.File.Exists(doctorInfoDbPath))
            {
                CSQLiteHelper.NewDbFile(doctorInfoDbPath);
                CSQLiteHelper.NewTable(doctorInfoDbPath);
            }
            csqliteDoctorInfoHelper.OpenDb(doctorInfoDbPath);
        }

        public string GetcurDoctorLoginAccount()
        {
            return curDoctorLoginAccount;
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            //如果是超级用户登录,显示当前数据库中所有医生信息用户名和密码
            //判断是不是管理员用户, 管理员用户的用户名为admin
            if (textBox_userName.Text == "admin" && textBox_pwd.Text == "12345678")
            {
                doctorInfoForm = new DoctorInfoForm();
                DataTable queryTable = csqliteDoctorInfoHelper.ExecuteQuery("SELECT * FROM doctorInfo_t");
                int a = queryTable.Rows.Count;
                doctorInfoForm.SetDataTable(ref queryTable);
                doctorInfoForm.Show();
                return;
            }

            bool isMatch = Regex.IsMatch(textBox_userName.Text, @"^1[3456789]\d{9}$");
            //如果用户名为空,提示
            if (isMatch == false)
            {
                textBox_userName.Font = new Font(textBox_userName.Font.FontFamily, 11, textBox_userName.Font.Style);
                textBox_userName.Text = "请输入正确的用户名(普通用户为11位的电话号码)!";
                return;
            }

            //如果密码为空,提示
            if (textBox_pwd.Text == null || textBox_pwd.Text.Trim() == "")
            {
                textBox_pwd.Text = "密码不能为空!";
                return;
            }

            if (Regex.IsMatch(textBox_pwd.Text.Trim(), @"^[\u4e00-\u9fa5]+$"))
            {
                textBox_pwd.Text = "密码不能包含中文!";
                return;
            }
            //查询如果这个电话和密码和数据库中的记录是一样的那么就进入摄像头展示的界面
            string phone = textBox_userName.Text;
            string pwd = textBox_pwd.Text;
            SQLiteParameter[] parms1 =
            {
                new SQLiteParameter("@Phone",phone),
                new SQLiteParameter("@PassWord",pwd),
            };
            DataTable retTable = csqliteDoctorInfoHelper.ExecuteQuery("SELECT * FROM doctorInfo_t where phone = @Phone and " +
                "password = @PassWord", parms1);
            if (retTable.Rows.Count == 0)
            {
                MessageBox.Show("本条记录不存在,请先进行注册!");
                return;
            }
            this.DialogResult = DialogResult.OK;
            curDoctorLoginAccount = phone;
        }

        private void btn_signup_Click(object sender, EventArgs e)
        {
            bool isMatch = System.Text.RegularExpressions.Regex.IsMatch(textBox_userName.Text, @"^1[3456789]\d{9}$");
            //如果用户名为空,提示
            if (isMatch == false)
            {
                textBox_userName.Font = new Font(textBox_userName.Font.FontFamily, 11, textBox_userName.Font.Style);
                textBox_userName.Text = "请输入正确的用户名(11位的电话号码)!";
                return;
            }

            //如果密码为空,提示
            if (textBox_pwd.Text == null || textBox_pwd.Text.Trim() == "")
            {
                textBox_pwd.Text = "密码不能为空!";
                return;
            }

            if (Regex.IsMatch(textBox_pwd.Text.Trim(), @"^[\u4e00-\u9fa5]+$"))
            {
                textBox_pwd.Text = "密码不能包含中文!";
                return;
            }

            //查询当前这个用户名是否存在
            string phone = textBox_userName.Text.Trim();
            string pwd = textBox_pwd.Text.Trim();
            SQLiteParameter[] parms1 =
            {
            new SQLiteParameter("@Phone",phone),
            };
            SQLiteParameter[] parms2 =
            {
            new SQLiteParameter("@Phone",phone),
            new SQLiteParameter("@PassWord",pwd),
            new SQLiteParameter("@CreateTime",DateTime.Now.ToString()),
            };
            DataTable queryTable = csqliteDoctorInfoHelper.ExecuteQuery("SELECT * FROM doctorInfo_t where phone = @Phone", parms1);
            if (queryTable.Rows.Count == 0)
            {
                //插入记录
                int affectedNum = csqliteDoctorInfoHelper.ExecuteNonQuery(
                    "INSERT INTO doctorInfo_t (phone, password, create_time) VALUES (@Phone, @PassWord, @CreateTime)", parms2);
                if (affectedNum <= 0)
                {
                    MessageBox.Show("新数据插入数据库失败!");
                }
            }
            else 
            {
                MessageBox.Show("已经存在本条记录,如果密码丢失请登录管理员账号找回!");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

          
        }

        private void textBox_userName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //只有0-9数字和 退格键可以输入
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == '\b')
            {
                if (e.KeyChar == '\b')
                    e.Handled = false;
                else
                {
                    if (textBox_userName.Text.Length > 10)
                    {
                        e.Handled = true;//不处理
                    }
                }

            }
        }
    }
}
