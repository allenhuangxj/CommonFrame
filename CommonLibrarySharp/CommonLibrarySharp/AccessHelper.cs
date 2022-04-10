using CommonLibrarySharp.WriteLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace CommonLibrarySharp.AccessDB
{
    public class AccessHelper
    {
        public static bool m_bConnectSuccess = false;
        public static OleDbConnection odcConnection = null;

        public static string m_strDBpath = System.Windows.Forms.Application.StartupPath + "\\data.mdb";
        /// <summary>
        /// 连接Access数据库
        /// </summary>
        /// <param name="mdbPath">数据库文件路径</param>
        /// <returns></returns>
        public static bool ConnectToDatabase(string strDbPath = "")
        {
            try
            {
                if (!string.IsNullOrEmpty(strDbPath))
                {
                    m_strDBpath = strDbPath;
                }

                // 判断数据库文件是否存在
                if (!File.Exists(m_strDBpath))
                {
                    Log.WriteMessage("access 数据库文件不存在:" + m_strDBpath, true);
                    return false;
                }
                // 建立连接  
                string strConn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + m_strDBpath;
                odcConnection = new OleDbConnection(strConn);
                if (odcConnection.State == ConnectionState.Open)
                {
                    Log.WriteMessage("数据库已经处于连接状态");
                    m_bConnectSuccess = true;
                    return true;
                }
                // 打开连接 
                odcConnection.Open();
                m_bConnectSuccess = true;
                Log.WriteMessage("连接accesss数据库成功");
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteMessage("连接access数据库捕获到异常:" + ex.Message);
            }
            return false;
        }
        /// <summary>
        /// 查询数据库
        /// </summary>
        /// <param name="strSql">sql查询语句</param>
        /// <param name="dt">查询到的数据表</param>
        /// <returns></returns>
        public static bool ReadData(string strSql, ref DataTable dt)
        {
            if (!m_bConnectSuccess)
            {
                Log.WriteMessage("未连接数据库", true);
                return false;
            }
            if (string.IsNullOrEmpty(strSql))
            {
                Log.WriteMessage("执行的sql不能为空", true);
                return false;
            }

            try
            {
                // 建立SQL查询   
                OleDbCommand odCommand = odcConnection.CreateCommand();
                OleDbDataAdapter sda = new OleDbDataAdapter(strSql, odcConnection);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                dt = ds.Tables[0];
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteMessage("ReadData 捕获到异常:" + ex.Message);
            }
            return false;
        }
        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="bExist"></param>
        /// <returns></returns>
        public static bool IsExist(string strSql, ref bool bExist)
        {
            if (!m_bConnectSuccess)
            {
                Log.WriteMessage("未连接数据库", true);
                return false;
            }
            if (string.IsNullOrEmpty(strSql))
            {
                Log.WriteMessage("执行的sql不能为空", true);
                return false;
            }

            try
            {
                // 建立SQL查询   
                OleDbCommand odCommand = odcConnection.CreateCommand();

                OleDbDataAdapter sda = new OleDbDataAdapter(strSql, odcConnection);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    bExist = true;
                }
                else
                {
                    bExist = false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteMessage("IsExist 捕获到异常:" + ex.Message);
            }
            return false;
        }

        /// <summary>
        /// 执行无返回sql  例如 更新 插入 删除操作
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public static bool ExecuteNonQuery(string strSql)
        {
            if (!m_bConnectSuccess)
            {
                Log.WriteMessage("未连接数据库", true);
                return false;
            }
            if (string.IsNullOrEmpty(strSql))
            {
                Log.WriteMessage("执行的sql不能为空", true);
                return false;
            }

            try
            {
                OleDbCommand cmd = new OleDbCommand(strSql, odcConnection);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteMessage("ExecuteNonQuery 捕获到异常:" + ex.Message);
            }
            return false;
        }

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        /// <returns></returns>
        public static bool CloseDatabase()
        {
            try
            {
                if (odcConnection != null)
                {
                    odcConnection.Close();
                }
                m_bConnectSuccess = false;
                Log.WriteMessage("关闭数据库成功");
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteMessage("CloseDatabase 捕获到异常:" + ex.Message);
            }
            return false;
        }

      
        /// <summary>
        /// 将记录集显示在listview
        /// </summary>
        /// <param name="listview"></param>
        /// <param name="dt"></param>
        public static void ShowTableToListView(System.Windows.Forms.ListView listview, DataTable dt)
        {
            try
            {
                listview.Invoke((EventHandler)(delegate
                {
                    //清空列名
                    listview.Clear();
                    listview.BeginUpdate();
                    //添加列名
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        System.Windows.Forms.ColumnHeader header = new System.Windows.Forms.ColumnHeader();
                        header.Text = dt.Columns[i].Caption;
                        header.Width = listview.Width / dt.Columns.Count;
                        listview.Columns.Add(header);
                    }
                    System.Windows.Forms.ListViewItem[] item = new System.Windows.Forms.ListViewItem[dt.Rows.Count];

                    string[] strColumnName = new string[dt.Columns.Count];

                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        for (int n = 0; n < dt.Columns.Count; n++)
                        {
                            strColumnName[n] = dt.Rows[j].ItemArray[n].ToString();
                        }

                        item[j] = new System.Windows.Forms.ListViewItem(strColumnName);
                        listview.Items.Add(item[j]);
                    }
                    listview.EndUpdate();
                }));
            }
            catch (Exception ex)
            {
                Log.WriteMessage("ShowTableToListView 捕获到异常:" + ex.Message);
            }
        }

        /// <summary>
        /// 将记录集显示在 DataGridView
        /// </summary>
        /// <param name="DataGridView"></param>
        /// <param name="dt"></param>
        public static void ShowTableDataGridView(System.Windows.Forms.DataGridView DataGridView, DataTable dt)
        {
            try
            {
                DataGridView.Invoke((EventHandler)(delegate
                {
                    DataGridView.DataSource = dt;
                }));
            }
            catch (Exception ex)
            {
                Log.WriteMessage("ShowTableDataGridView 捕获到异常:" + ex.Message);
            }
        }

        //获取文件所有表
        public static List<string> GetAllTableName()
        {
            List<string> templist = new List<string>();
            DataTable dt = odcConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string str = dt.Rows[i]["TABLE_NAME"].ToString();
                templist.Add(String.Format("{0}\n", str));
            }
            return templist;
        }

        //压缩数据库
        public static bool CompactAccessDB()
        {
            try
            {
                CloseDatabase();
                string TempMdbName = System.Windows.Forms.Application.StartupPath + @"\Temp.mdb";

                //创建 Jet 引擎对象
                object objJetEngine = Activator.CreateInstance(Type.GetTypeFromProgID("JRO.JetEngine"));

                //设置参数数组
                //根据你所使用的Access版本修改 "Jet OLEDB:Engine Type=5" 中的数字.
                //5 对应 JET4X 格式 (access 2000,2002)

                object[] objParams = new object[] {
                String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}",m_strDBpath), //输入连接字符串
                String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Jet OLEDB:Engine Type=5",TempMdbName) //输出连接字符串
                };
                //通过反射调用 CompactDatabase 方法
                objJetEngine.GetType().InvokeMember("CompactDatabase",
                    System.Reflection.BindingFlags.InvokeMethod,
                    null,
                    objJetEngine,
                    objParams);

                //删除原数据库文件
                System.IO.File.Delete(m_strDBpath);
                //重命名压缩后的数据库文件
                System.IO.File.Move(TempMdbName, m_strDBpath);
                //释放Com组件
                System.Runtime.InteropServices.Marshal.ReleaseComObject(objJetEngine);
                objJetEngine = null;
                return ConnectToDatabase();
            }
            catch (Exception)
            {
                return false;
            }

        }
        //批量插入
        public static bool BachInsert(List<string> ListInsertSql)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = odcConnection;
            cmd.Transaction = odcConnection.BeginTransaction();
            try
            {
                foreach (string strSql in ListInsertSql)
                {
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
                cmd.Transaction.Commit();  //提交事务
                return true;
            }
            catch (Exception)
            {
                cmd.Transaction.Rollback();
                return false;
            }
        }
    }
}
