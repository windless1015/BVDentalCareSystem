using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace BVDentalCareSystem.Interfaces
{
    class SqliteHelper
    {
        private SQLiteConnection connection = null;
        private SQLiteCommand selectCommand = null;
        private SQLiteDataAdapter dataAdapter = null;
        private SQLiteConnectionStringBuilder sb = new SQLiteConnectionStringBuilder();
        private string connectionString = null;

        //数据库所在的路径,为exe同级目录
        private string dbFilePath = Environment.CurrentDirectory + @"\patientInfo_t.db";
        public SqliteHelper()
        {
            sb.DataSource = Environment.CurrentDirectory + @"\patientInfo_t.db";
            connectionString = sb.ToString();
        }

        public void CreateDBFile()
        {
            if (IsDataBaseFileExist()) //存在
                return;
            SQLiteConnection conn = new SQLiteConnection(@"Data Source =" + dbFilePath);//创建数据库实例，指定文件位置
            conn.Open();//打开数据库，若文件不存在会自动创建 
            SQLiteCommand cmd = new SQLiteCommand(conn);//实例化SQL命令 
            string createSqlString = @"CREATE TABLE IF NOT EXISTS patientInfo_t 
                (id INTEGER PRIMARY KEY, name VARCHAR(50) NOT NULL, gender VARCHAR(10),
                birth_date VARCHAR(15), identity_number VARCHAR(50), phone VARCHAR(40),
                create_time VARCHAR(20))";
            cmd.CommandText = createSqlString;
            int res = cmd.ExecuteNonQuery();  //-1表示没有生效,即数据库中已经有这个数据表了,不需要重新创建
        }

        //public static int ExecuteNonQuery(string sql)
        //{
        //        SQLiteCommand cmd;
        //        cmd = new SQLiteCommand(sql, dbConnection());
        //        cmd.ExecuteNonQuery().ToString();
        //        return 1;
        //}

        public DataTable QuerySqlTable()
        {

            //connection = new SQLiteConnection(connectionString);
            //selectCommand = connection.CreateCommand();
            //selectCommand.CommandText = "SELECT * FROM patientInfo_t";
            //dataAdapter = new SQLiteDataAdapter();// SQLiteDataAdapter 是对数据库进行增加表，删除， 修改等操作，不是对某一个具体的数据表
            //dataAdapter.SelectCommand = selectCommand;
            //dt = new DataTable();
            //dataAdapter.Fill(dt);

            try
            {
                SQLiteCommand sqlcmd = new SQLiteCommand(connectionString);
                connection = new SQLiteConnection(connectionString);
                selectCommand = connection.CreateCommand();
                selectCommand.CommandText = "SELECT * FROM patientInfo_t";
                dataAdapter = new SQLiteDataAdapter();// SQLiteDataAdapter 是对数据库进行增加表，删除， 修改等操作，不是对某一个具体的数据表
                dataAdapter.SelectCommand = selectCommand;
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void InsertData(ref DataTable dt)
        {
            SQLiteCommandBuilder builder = new SQLiteCommandBuilder(dataAdapter);
            dataAdapter.InsertCommand = builder.GetInsertCommand();
            dataAdapter.Update(dt);
            dt.Clear();
            dataAdapter.Fill(dt);
            builder.Dispose();
        }
        public void UpdateData(ref DataTable dt)
        {
            SQLiteCommandBuilder builder = new SQLiteCommandBuilder(dataAdapter);
            dataAdapter.UpdateCommand = builder.GetUpdateCommand();
            dataAdapter.Update(dt);
            dt.Clear();
            dataAdapter.Fill(dt);
            builder.Dispose();
        }

        public void DeleteData(ref DataTable dt)
        {
            SQLiteCommandBuilder builder = new SQLiteCommandBuilder(dataAdapter);
            dataAdapter.DeleteCommand = builder.GetDeleteCommand();
            dataAdapter.Update(dt);
            builder.Dispose();
        }

        public void SelectionQuery(string querySql, ref DataTable dt) //显式所有的记录
        {
            SQLiteCommandBuilder builder = new SQLiteCommandBuilder(dataAdapter);
            dataAdapter.SelectCommand.CommandText = querySql;
            dataAdapter.Update(dt);
            dt.Clear();
            dataAdapter.Fill(dt);
            builder.Dispose();
        }

        //判断数据库是否存在
        private bool IsDataBaseFileExist()
        {
            return System.IO.File.Exists(dbFilePath);
        }


    }
}

