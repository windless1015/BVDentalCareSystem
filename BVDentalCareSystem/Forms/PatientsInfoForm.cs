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
using BVDentalCareSystem.SelfDefinedControls;

namespace BVDentalCareSystem.Forms
{
    public partial class PatientsInfoForm : Form
    {
        SqliteHelper sqlHeperInstance = null;
        DataTable dataTablePatientInfo = null;
        string rootPath = Environment.CurrentDirectory + @"\PatientInfoDir\";
        public delegate void NotifyRecordSideBarEvent(string dataPath);
        public event NotifyRecordSideBarEvent SideBarDataReorderNotify;

        private int curSelectIdx = 0;//当前选择的行idx
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

        //查询患者按钮事件
        private void Button_query_Click(object sender, EventArgs e)
        {
            if (Button_query.Tag.ToString() == "query")
            {
                PatientDisplayForm patienDisForm = new PatientDisplayForm();
                patienDisForm.Text = "患者信息查询";
                string genderChinese = radioBtnMale.Checked ? "男" : "女";
                patienDisForm.SetPatientInfoData("query", "", "", "", "", DateTime.Now);
                patienDisForm.PassParamNotify += PatienDisForm_PassParamNotify;
                patienDisForm.ShowDialog();

                if (patienDisForm.DialogResult != DialogResult.Cancel)
                {
                    Button_query.Tag = "return";
                    Button_query.BackgroundImage = Properties.Resources.btn_return;
                }
            }
            else if (Button_query.Tag.ToString() == "return")
            {
                string querySql = "SELECT * FROM patientInfo_t";
                dataTablePatientInfo.Clear();
                sqlHeperInstance.SelectionQuery(querySql, ref dataTablePatientInfo);
                Button_query.Tag = "query";
                Button_query.BackgroundImage = Properties.Resources.btn_query_record;
            }
        }

        //新建患者按钮事件
        private void Button_add_Click(object sender, EventArgs e)
        {
            PatientDisplayForm patienDisForm = new PatientDisplayForm();
            patienDisForm.Text = "患者信息新建";
            string genderChinese = radioBtnMale.Checked ? "男" : "女";
            patienDisForm.SetPatientInfoData("add", "", "","", "男", DateTime.Now);
            patienDisForm.PassParamNotify += PatienDisForm_PassParamNotify;
            patienDisForm.ShowDialog();
        }

        //修改患者信息按钮事件
        private void Button_modify_Click(object sender, EventArgs e)
        {
            PatientDisplayForm patienDisForm = new PatientDisplayForm();
            patienDisForm.Text = "患者信息修改";
            string genderChinese = DataView_Patients.Rows[curSelectIdx].Cells[2].Value.ToString();
            patienDisForm.SetPatientInfoData("modify", textBox_name.Text, textBox_phone.Text,
                textBox_identity.Text, genderChinese, dtpicker.Value);
            patienDisForm.PassParamNotify += PatienDisForm_PassParamNotify;
            patienDisForm.ShowDialog();
        }

        private void PatienDisForm_PassParamNotify(string opType, string name, string phone, string identityNum, string gender, DateTime birth)
        {
            if (opType == "add")
            {
                //判断姓名如果为空提示
                if (name == null || name == "")
                {
                    MessageBox.Show("姓名不能为空！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //生成一个数据行
                DataRow dr = dataTablePatientInfo.NewRow();
                dr["name"] = name;
                dr["gender"] = gender;
                dr["birth_date"] = birth.ToString("yyyy-MM-dd");
                dr["identity_number"] = identityNum;
                dr["phone"] = phone;
                dr["create_time"] = DateTime.Now.ToString("yyyy-MM-dd");
                System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区
                string timeStamp = Convert.ToInt32((DateTime.Now - startTime).TotalSeconds).ToString(); // 相差秒数
                string case_file_name = name + "_" + timeStamp;
                dr["case_file_name"] = case_file_name;
                dataTablePatientInfo.Rows.Add(dr);

                //把新建的这个数据行插入到数据表之后,然后更新到sql里面
                sqlHeperInstance.UpdateData(ref dataTablePatientInfo);

                //添加了一个数据之后,默认会选中这个数据行,所以要取消选中
                int rowSize = DataView_Patients.RowCount;
                curSelectIdx = rowSize - 1;
                /////////////////////////////////////////////////////////
                //用这行是不能设置current row的,需要用current cell 属性
                //参考 https://stackoverflow.com/questions/14576803/selecting-rows-programmatically-in-datagridview
                //DataView_Patients.Rows[curSelectIdx].Selected = true;
                DataView_Patients.CurrentCell = DataView_Patients.Rows[curSelectIdx].Cells[0];
                /////////////////////////////////////////////////////////
                SelectOnePatient(curSelectIdx);

                //创建该文件夹
                Directory.CreateDirectory(rootPath + case_file_name);
            }
            else if (opType == "modify")
            {
                int curRowIndex = DataView_Patients.CurrentRow.Index;
                //如果不是修改病人姓名的，则不会改变文件夹名称，这种直接修改数据库
                if (name == dataTablePatientInfo.Rows[curRowIndex][1].ToString()) //名字没有改变
                {
                    dataTablePatientInfo.Rows[curRowIndex][2] = gender;
                    dataTablePatientInfo.Rows[curRowIndex][3] = dtpicker.Value.ToString("yyyy-MM-dd");
                    dataTablePatientInfo.Rows[curRowIndex][4] = textBox_identity.Text;
                    dataTablePatientInfo.Rows[curRowIndex][5] = textBox_phone.Text;
                    sqlHeperInstance.UpdateData(ref dataTablePatientInfo);
                }
                else  //修改了用户的姓名
                {
                    System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区
                    string timeStamp = Convert.ToInt32((DateTime.Now - startTime).TotalSeconds).ToString(); // 相差秒数
                    string newFileName = name + "_" + timeStamp;
                    //修改这个用户所对应的文件夹的名字
                    string originalFileName = rootPath + dataTablePatientInfo.Rows[curRowIndex][7].ToString();
                    string newFileNameAbsPath = rootPath + newFileName;
                    Directory.Move(originalFileName, newFileNameAbsPath);

                    //更新数据库中 姓名,case_file_name 这两个个字段
                    dataTablePatientInfo.Rows[curRowIndex][1] = name;
                    dataTablePatientInfo.Rows[curRowIndex][7] = newFileName;
                    sqlHeperInstance.UpdateData(ref dataTablePatientInfo);
                }
                DataView_Patients.CurrentCell = DataView_Patients.Rows[curSelectIdx].Cells[0];
            }
            else if (opType == "query")
            {
                string querySql = "";
                if (name != "") //有名字，以名字为主
                {
                    querySql = "SELECT * FROM patientInfo_t WHERE name='" + name + "'";
                }
                if (name == "" && phone != "") //没有名字，有电话，以电话为主
                    querySql = "SELECT * FROM patientInfo_t WHERE phone='" + phone + "'";
                else if (name == "" && phone == "") //名字电话都没有
                {
                    MessageBox.Show("请输入名字或者电话！", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                dataTablePatientInfo.Clear();
                sqlHeperInstance.SelectionQuery(querySql, ref dataTablePatientInfo);

            }
        }

        

        private void Button_delete_Click(object sender, EventArgs e)
        {
            if (DataView_Patients.CurrentRow == null)
            {
                MessageBox.Show("请选择需要删除的一行！");
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
        }

        private void PatientsInfoForm_Resize(object sender, EventArgs e)
        {
            this.DataView_Patients.Height = this.Height - this.GroupBox_Operation.Height - 10;
        }

        private void DataView_Patients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            curSelectIdx = e.RowIndex;
            SelectOnePatient(e.RowIndex);
            //判断这个文件夹是否存在
            string caseFileName = DataView_Patients.Rows[e.RowIndex].Cells[7].Value.ToString();
            string patienDataPath = rootPath + caseFileName;
            if (!Directory.Exists(patienDataPath))
            {
                Directory.CreateDirectory(patienDataPath);
            }
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

            // DataGridView1的单元格只读  
            DataView_Patients.ReadOnly = true;

            //取消默认选中
            DataView_Patients.ClearSelection();

        }
        //清空输入控件
        private void ClearInputBoxes()
        {
            textBox_name.Text = "";
            textBox_phone.Text = "";
            textBox_identity.Text = "";
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

        

        private void FillOneItmeToDisplay(int rowIdx)
        {
            textBox_name.Text = DataView_Patients.Rows[rowIdx].Cells[1].Value.ToString();
            if (DataView_Patients.Rows[rowIdx].Cells[2].Value.ToString() == "男")
            {
                radioBtnMale.Checked = true;
                radioBtnFemale.Checked = false;
            }
            else
            {
                radioBtnMale.Checked = false;
                radioBtnFemale.Checked = true;
            }
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
            DataGridViewRow oneRow = DataView_Patients.Rows[rowIndex];
            object patientNameObj = oneRow.Cells[1].Value;
            if (patientNameObj == null)
                return;

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

        private void radioBtnMale_CheckedChanged(object sender, EventArgs e)
        {
            radioBtnFemale.Checked = !radioBtnMale.Checked;
        }

        private void radioBtnFemale_CheckedChanged(object sender, EventArgs e)
        {
            radioBtnMale.Checked = !radioBtnFemale.Checked;
        }

        //private void DataView_Patients_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        //{
        //    return;
        //    if (DataView_Patients.CurrentRow != null)
        //    {
        //        DataView_Patients.CurrentRow.Selected = false;
        //    }
        //}
    }
}
