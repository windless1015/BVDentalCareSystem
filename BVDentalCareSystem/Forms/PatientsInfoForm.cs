using System;
using System.Runtime;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BVDentalCareSystem.Interfaces;
using System.IO;

namespace BVDentalCareSystem.Forms
{
    public partial class PatientsInfoForm : Form
    {
        SqliteHelper sqlHeperInstance = null;
        DataTable dataTablePatientInfo = null;
        string rootPath = Environment.CurrentDirectory + @"\PatientInfoDir\";
        public delegate void NotifyRecordSideBarEvent(string dataPath);
        public event NotifyRecordSideBarEvent SideBarDataReorderNotify;

        public PatientsInfoForm()
        {
            InitializeComponent();
        }

        private void PatientsInfoForm_Load(object sender, EventArgs e)
        {
            //判断数据库文件是否存在
            if (sqlHeperInstance != null)
            {
                sqlHeperInstance = null;
            }
            sqlHeperInstance = new SqliteHelper(); //实例化
            sqlHeperInstance.InitDB();
            sqlHeperInstance.CreateDBFile();
            //加载的时候查询当前数据库的表
            dataTablePatientInfo = sqlHeperInstance.QuerySqlTable();
            DataView_Patients.DataSource = dataTablePatientInfo;
            SelectOnePatient(0);

            //设置控件属性
            SetControlsProperties();
            //禁止输入控件
            EnableOrDisableInputControls(false);
        }

        private void PatientsInfoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlHeperInstance != null)
            {
                sqlHeperInstance = null;
            }
        }

        private void Button_query_Click(object sender, EventArgs e)
        {
            string querySql = "";
            if (Button_query.Tag.ToString() == "query") //查询逻辑
            {
                EnableOrDisableInputControls(true);
                DisableOrEnableFourButtons(true, false, false, false); //查询按钮使能
                ClearInputBoxes();
                Button_query.Tag = "confirm";
                Button_query.BackgroundImage = Properties.Resources.btn_confirm;
                return;
            }
            else if (Button_query.Tag.ToString() == "confirm") //确认按钮
            {
                if (textBox_name.Text == "" && textBox_phone.Text == "" && textBox_identity.Text == "")
                {
                    MessageBox.Show("请输入需要查询的条件!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (textBox_phone.Text != "")
                    querySql = "SELECT * FROM patientInfo_t WHERE name='" + textBox_name.Text + "' and phone='"
                    + textBox_phone.Text + "'";
                else
                    querySql = "SELECT * FROM patientInfo_t WHERE name='" + textBox_name.Text + "'";
                ClearInputBoxes();
                EnableOrDisableInputControls(false);
                Button_query.Tag = "return";
                Button_query.BackgroundImage = Properties.Resources.btn_return;
            }
            else if (Button_query.Tag.ToString() == "return") //返回
            {
                Button_query.BackgroundImage = Properties.Resources.btn_query_record;
                Button_query.Tag = "query";
                querySql = "SELECT * FROM patientInfo_t ";
                EnableOrDisableInputControls(false);
                ClearInputBoxes();
                DisableOrEnableFourButtons(true, true, true, true);
            }
            dataTablePatientInfo.Clear();
            sqlHeperInstance.SelectionQuery(querySql, ref dataTablePatientInfo);

        }

        private void Button_add_Click(object sender, EventArgs e)
        {
            if (Button_add.Tag.ToString() == "add")
            {
                //新建一个数据,先查询sql,把查询的数据写入 dataTablePatientInfo
                if(dataTablePatientInfo != null)
                    dataTablePatientInfo.Clear(); //当前数据表数据都清空
                sqlHeperInstance.SelectionQuery("SELECT * FROM patientInfo_t ", ref dataTablePatientInfo);

                EnableOrDisableInputControls(true);//使能输入控件
                ClearInputBoxes();                 //清空输入控件的数据
                DisableOrEnableFourButtons(false, true, false, false); //新建按钮使能,其他都禁止
                Button_add.Tag = "confirm";
                Button_add.BackgroundImage = Properties.Resources.btn_confirm;
            }
            else if (Button_add.Tag.ToString() == "confirm")
            {
                //判断姓名如果为空提示
                if (textBox_name.Text == null || textBox_name.Text == "")
                {
                    MessageBox.Show("姓名不能为空！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //判断输入的姓名
                if (!(JudgeNameIsValid(textBox_name.Text) && JudgePhoneNumber(textBox_phone.Text)
                    && JudgeIdentityNumber(textBox_identity.Text)))
                {
                    return;
                }
                //生成一个数据行
                DataRow dr = dataTablePatientInfo.NewRow();
                dr["name"] = textBox_name.Text;
                dr["gender"] = (radioBtnMale.Checked) ? "男" : "女";
                dr["birth_date"] = dtpicker.Value.ToString("yyyy-MM-dd");
                dr["identity_number"] = textBox_identity.Text;
                dr["phone"] = textBox_phone.Text;
                dr["create_time"] = DateTime.Now.ToString("yyyy-MM-dd");
                System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区
                string timeStamp = Convert.ToInt32((DateTime.Now - startTime).TotalSeconds).ToString(); // 相差秒数
                string case_file_name = textBox_name.Text + "_" + timeStamp;
                dr["case_file_name"] = case_file_name;
                dataTablePatientInfo.Rows.Add(dr);

                //把新建的这个数据行插入到数据表之后,然后更新到sql里面
                sqlHeperInstance.UpdateData(ref dataTablePatientInfo);
                //添加了一个数据之后,默认会选中这个数据行,所以要取消选中
                int rowSize = DataView_Patients.RowCount;
                DataView_Patients.Rows[rowSize - 1].Selected = true;
                SelectOnePatient(rowSize - 1);
                //创建该文件夹
                Directory.CreateDirectory(rootPath + case_file_name);
                EnableOrDisableInputControls(false);
                Button_add.Tag = "add";
                Button_add.BackgroundImage = Properties.Resources.btn_add_record;
            }
        }

        private void Button_modify_Click(object sender, EventArgs e)
        {
            if (Button_modify.Tag.ToString() == "modify")
            {
                EnableOrDisableInputControls(true);
                Button_modify.Tag = "confirm";
                Button_modify.BackgroundImage = Properties.Resources.btn_confirm;
                return;
            }
            else if (Button_modify.Tag.ToString() == "confirm")
            {
                int curRowIndex = DataView_Patients.CurrentRow.Index;
                //如果不是修改病人姓名的，则不会改变文件夹名称，这种直接修改数据库
                if (textBox_name.Text == dataTablePatientInfo.Rows[curRowIndex][1].ToString()) //名字没有改变
                {
                    dataTablePatientInfo.Rows[curRowIndex][2] = (radioBtnMale.Checked) ? "男" : "女";
                    dataTablePatientInfo.Rows[curRowIndex][3] = dtpicker.Value.ToString("yyyy-MM-dd");
                    if (!JudgeIdentityNumber(textBox_identity.Text))
                    {
                        return;
                    }
                    dataTablePatientInfo.Rows[curRowIndex][4] = textBox_identity.Text;
                    if (!JudgePhoneNumber(textBox_phone.Text))
                    {
                        return;
                    }
                    dataTablePatientInfo.Rows[curRowIndex][5] = textBox_phone.Text;
                    sqlHeperInstance.UpdateData(ref dataTablePatientInfo);
                }
                else  //修改了用户的姓名
                {
                    System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区
                    string timeStamp = Convert.ToInt32((DateTime.Now - startTime).TotalSeconds).ToString(); // 相差秒数
                    string newFileName = textBox_name.Text + "_" + timeStamp;
                    //修改这个用户所对应的文件夹的名字
                    string originalFileName = rootPath + dataTablePatientInfo.Rows[curRowIndex][7].ToString();
                    string newFileNameAbsPath = rootPath + newFileName;
                    Directory.Move(originalFileName, newFileNameAbsPath);

                    //更新数据库中 姓名,case_file_name 这两个个字段
                    dataTablePatientInfo.Rows[curRowIndex][1] = textBox_name.Text;
                    dataTablePatientInfo.Rows[curRowIndex][7] = newFileName;
                    sqlHeperInstance.UpdateData(ref dataTablePatientInfo);
                }
                Button_modify.Tag = "modify";
                Button_modify.BackgroundImage = Properties.Resources.btn_modify_record;
            }
        }

        private void Button_delete_Click(object sender, EventArgs e)
        {
            if (DataView_Patients.CurrentRow == null)
            {
                MessageBox.Show("请选择需要删除的一行！");
                return;
            }
            //判断当前行是否为空，为null表示已经删完了
            if (DataView_Patients.CurrentRow == null)
            {
                MessageBox.Show("当前没有数据！");
                return;
            }

            //删除之前提示对应的数据是不是也要一并删除
            int needDeleteIdx = DataView_Patients.CurrentRow.Index;
            string dataPath = GetDataPath(needDeleteIdx);
            if (Directory.Exists(dataPath))
            {
                if (MessageBox.Show("是否删除当前病人所有数据?", "确认信息", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return;
                }
            }
            //递归删除文件夹
            DelectDir(ref dataPath);
            dataTablePatientInfo.Rows[needDeleteIdx].Delete();
            sqlHeperInstance.DeleteData(ref dataTablePatientInfo);
            dataTablePatientInfo.AcceptChanges();

            //向外发送sidebar更新的消息
            SideBarDataReorderNotify("");
            ClearInputBoxes();
            DisableOrEnableFourButtons(true, true, true, true);
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

        private void DataView_Patients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            SelectOnePatient(e.RowIndex);
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

            //最后一列是记录文件名,不显示
            DataView_Patients.Columns[7].Visible = false;

        }
        //清空输入控件
        private void ClearInputBoxes()
        {
            textBox_name.Text = "";
            textBox_phone.Text = "";
            textBox_identity.Text = "";
        }
        //对于四个按钮的设置使能(或者失能)的状态
        private void DisableOrEnableFourButtons(bool query, bool add, bool modify, bool delete)
        {
            Button_query.Enabled = query;
            Button_modify.Enabled = modify;
            Button_delete.Enabled = delete;
            Button_add.Enabled = add;
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

        private void FillOneItmeToDisplay(int rowIdx)
        {
           //RowCount获取或设置DataGridView中显示的行数。
            if (DataView_Patients.RowCount <= 1 || rowIdx < 0 || rowIdx >= DataView_Patients.RowCount)
                return;
            textBox_name.Text = DataView_Patients.Rows[rowIdx].Cells[1].Value.ToString();
            if (DataView_Patients.Rows[rowIdx].Cells[2].Value.ToString() == "男")
            {
                radioBtnMale.Checked = true;
            }
            else
                radioBtnFemale.Checked = true;
            dtpicker.Value = Convert.ToDateTime(DataView_Patients.Rows[rowIdx].Cells[3].Value.ToString());
            textBox_identity.Text = DataView_Patients.Rows[rowIdx].Cells[4].Value.ToString();
            textBox_phone.Text = DataView_Patients.Rows[rowIdx].Cells[5].Value.ToString();
        }

        private string GetDataPath(int rowIndex)
        {
            if (DataView_Patients.RowCount <= 0)
                return "";
            if (DataView_Patients.Rows[rowIndex].Cells[7].Value == null)
                return"";
            string caseFileName = DataView_Patients.Rows[rowIndex].Cells[7].Value.ToString();
            caseFileName = rootPath + caseFileName;
            return caseFileName;
        }

        public void SelectOnePatient(int rowIndex)
        {
            FillOneItmeToDisplay(rowIndex);
            //发送消息,告诉外界 窗体控件更新数据
            string dataPath = GetDataPath(rowIndex);
            if (dataPath != "")
                SideBarDataReorderNotify(dataPath);
        }

        public void DelectDir(ref string srcPath)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(srcPath);
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //返回目录中所有文件和子目录
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)            //判断是否文件夹
                    {
                        DirectoryInfo subdir = new DirectoryInfo(i.FullName);
                        subdir.Delete(true);          //删除子目录和文件
                    }
                    else
                    {
                        File.Delete(i.FullName);      //删除指定文件
                    }
                }
                //然后再删除这个目录自身
                DirectoryInfo root = new DirectoryInfo(srcPath);
                root.Delete(true);
            }
            catch (Exception e)
            {
                throw e;
            }
            srcPath = null;
        }
    }
}
