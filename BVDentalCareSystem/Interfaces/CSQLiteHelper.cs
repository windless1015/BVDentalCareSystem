﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;


namespace BVDentalCareSystem.Interfaces
{
    public class CSQLiteHelper
    {
        private string _dbName = "";
        private SQLiteConnection _SQLiteConn = null;     //连接对象
        private SQLiteTransaction _SQLiteTrans = null;   //事务对象
        private bool _IsRunTrans = false;        //事务运行标识
        private string _SQLiteConnString = null; //连接字符串
        private bool _AutoCommit = false; //事务自动提交标识
  
        public string SQLiteConnString
        {
            set { this._SQLiteConnString = value; }
            get { return this._SQLiteConnString; }
        }
        public CSQLiteHelper(string dbPath)
        {
           this._dbName = dbPath;
           this._SQLiteConnString = "Data Source=" + dbPath;
        }
         /// <summary>
          /// 新建数据库文件
          /// </summary>
          /// <param name="dbPath">数据库文件路径及名称</param>
          /// <returns>新建成功，返回true，否则返回false</returns>
        static public Boolean NewDbFile(string dbPath)
        {
            try
              {
                SQLiteConnection.CreateFile(dbPath);
                return true;
           }
            catch (Exception ex)
           {
                 throw new Exception("新建数据库文件" + dbPath + "失败：" + ex.Message);
              }
        }

 
          /// <summary>
          /// 创建表
          /// </summary>
          /// <param name="dbPath">指定数据库文件</param>
          /// <param name="tableName">表名称</param>
        static public void NewTable(string dbPath)
        {

            SQLiteConnection sqliteConn = new SQLiteConnection("data source=" + dbPath);
          if (sqliteConn.State != System.Data.ConnectionState.Open)
        {
            sqliteConn.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = sqliteConn;
            string createSqlString = @"CREATE TABLE IF NOT EXISTS doctorInfo_t
                (id INTEGER PRIMARY KEY, phone VARCHAR(40),
                password VARCHAR(50), create_time VARCHAR(20))";
             cmd.CommandText = createSqlString;
             cmd.ExecuteNonQuery();
           }
          sqliteConn.Close();
        }
        /// <summary>
        /// 打开当前数据库的连接
        /// </summary>
       /// <returns></returns>
        public Boolean OpenDb()
        {
            try
            {
                       this._SQLiteConn = new SQLiteConnection(this._SQLiteConnString);
                       this._SQLiteConn.Open();
                       return true;
                  }
             catch (Exception ex)
          {
                     throw new Exception("打开数据库：" + _dbName + "的连接失败：" + ex.Message);
                    }
           }
     
        /// <summary>
        /// 打开指定数据库的连接
        /// </summary>
        /// <param name="dbPath">数据库路径</param>
        /// <returns></returns>
        public Boolean OpenDb(string dbPath)
        {
            try
           {
            string sqliteConnString = "Data Source=" + dbPath;
            this._SQLiteConn = new SQLiteConnection(sqliteConnString);
            this._dbName = dbPath;
            this._SQLiteConnString = sqliteConnString;
            this._SQLiteConn.Open();
            return true;
            }
            catch (Exception ex)
            {
                throw new Exception("打开数据库：" + dbPath + "的连接失败：" + ex.Message);
            }
        }

        /// <summary> 
        /// 对SQLite数据库执行增删改操作，返回受影响的行数。 
        /// </summary> 
        /// <param name="sql">要执行的增删改的SQL语句。</param> 
        /// <param name="parameters">执行增删改语句所需要的参数，参数必须以它们在SQL语句中的顺序为准。</param> 
        /// <returns></returns> 
        /// <exception cref="Exception"></exception>
        public int ExecuteNonQuery(string sql, params SQLiteParameter[] parameters)
        {
            int affectedRows = 0;
            using (SQLiteConnection connection = new SQLiteConnection(SQLiteConnString))
            {
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    try
                    {
                        connection.Open();
                        command.CommandText = sql;
                        if (parameters.Length != 0)
                        {
                            command.Parameters.AddRange(parameters);
                        }
                        affectedRows = command.ExecuteNonQuery();
                    }
                    catch (Exception e1)
                    {
                        System.Diagnostics.Debug.WriteLine("SQLiteHelper ExecuteNonQuery [" + sql + "] Exception: " + e1.Message);
                    }
                }
            }
            return affectedRows;
        }


        /// <summary> 
        /// 执行一个查询语句，返回一个包含查询结果的DataTable。 
        /// </summary> 
        /// <param name="sql">要执行的查询语句。</param> 
        /// <param name="parameters">执行SQL查询语句所需要的参数，参数必须以它们在SQL语句中的顺序为准。</param> 
        /// <returns></returns> 
        /// <exception cref="Exception"></exception>
        public DataTable ExecuteQuery(string sql, params SQLiteParameter[] parameters)
        {
            using (SQLiteConnection connection = new SQLiteConnection(SQLiteConnString))
            {
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    if (parameters.Length != 0)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                    DataTable data = new DataTable();
                    try
                    { 
                        adapter.Fill(data); 
                    }
                    catch (Exception e1)
                    {
                        System.Diagnostics.Debug.WriteLine("SQLiteHelper ExecuteQuery [" + sql + "] Exception: " + e1.Message);
                    }
                    return data;
                }
            }
        }



        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void CloseDb()
        {
                    if (this._SQLiteConn != null && this._SQLiteConn.State != ConnectionState.Closed)
                    {
                     if (this._IsRunTrans && this._AutoCommit)
                          {
                        this.Commit();
                   }
                   this._SQLiteConn.Close();
                       this._SQLiteConn = null;
                     }
        }
       
        /// <summary>
       /// 开始数据库事务
       /// </summary>
        public void BeginTransaction()       
        {

            this._SQLiteConn.BeginTransaction();
                this._IsRunTrans = true;
        }

       /// <summary>
       /// 开始数据库事务
       /// </summary>
       /// <param name="isoLevel">事务锁级别</param>
       public void BeginTransaction(IsolationLevel isoLevel)
       {
                          this._SQLiteConn.BeginTransaction(isoLevel);
                          this._IsRunTrans = true;
                   }
          
        /// <summary>       /// 提交当前挂起的事务
        /// </summary>
        public void Commit()
        {
             if (this._IsRunTrans)
             {
             this._SQLiteTrans.Commit();
             this._IsRunTrans = false;
            }
        }

    }
  }
