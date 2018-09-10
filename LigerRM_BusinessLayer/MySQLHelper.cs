using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using System.Collections.Generic;

namespace SignetInternet_BusinessLayer
{
    public abstract  class MySQLHelper
    {

        //Database connection strings
        public static readonly string SqlConnString = ConfigurationManager.ConnectionStrings["SqlConnString"].ConnectionString;
        public static readonly string DataSynConnectionString = ConfigurationManager.ConnectionStrings["DataSynConnectionString"].ConnectionString;
        // Hashtable to store cached parameters
        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

        public static void CacheParameters(string cacheKey, params SqlParameter[] commandParameters)
        {
            parmCache[cacheKey] = commandParameters;
        }

        public static SqlParameter[] GetCachedParameters(string cacheKey)
        {
            SqlParameter[] cachedParms = (SqlParameter[])parmCache[cacheKey];

            if (cachedParms == null)
                return null;

            SqlParameter[] clonedParms = new SqlParameter[cachedParms.Length];

            for (int i = 0, j = cachedParms.Length; i < j; i++)
                clonedParms[i] = (SqlParameter)((ICloneable)cachedParms[i]).Clone();

            return clonedParms;
        }       

        #region  CreateCommand

        public static SqlCommand CreateCommand(CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();
            
            cmd.CommandText = cmdText;
            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                {
                    if (parm.Value == null )
                    {
                        parm.Value = DBNull.Value;
                    }

                    cmd.Parameters.Add(parm);
                }
                  
            }
            return cmd;
        }

        public static SqlCommand CreateCommand(string cmdText, SqlParameter[] cmdParms)
        {
            return CreateCommand( CommandType.Text, cmdText, cmdParms);
        }
        public static SqlCommand CreateCommand(string cmdText)
        {        
            return CreateCommand( CommandType.Text, cmdText, null);
        }

        #endregion

        #region  ExecuteNonQuery


        public static int ExecuteNonQuery(string connectionString, SqlCommand cmd)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                cmd.Connection = conn;
                conn.Open();
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }



        public static int ExecuteNonQueryTrans(string connectionString, List<SqlCommand> cmdlist)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
 
                        foreach (SqlCommand cmd in cmdlist)
                        {
                            cmd.Transaction = trans;
                            cmd.Connection = conn;
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                        trans.Commit();
                        return 0;
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }
        public static int ExecuteNonQueryTrans(string connectionString, SqlCommand cmd)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        cmd.Transaction = trans;
                        cmd.Connection = conn;
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();

                        trans.Commit();
                        return 0;
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }
        public static int ExecuteNonQuery(SqlTransaction trans, SqlCommand cmd)
        {
            if (trans != null)
            {
                cmd.Transaction = trans;
                cmd.Connection = trans.Connection;
            }
            if (cmd.Connection.State != ConnectionState.Open)
                cmd.Connection.Open();
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        public static int ExecuteNonQuery(SqlConnection conn, SqlCommand cmd)
        {
            cmd.Connection = conn;
            if (cmd.Connection.State != ConnectionState.Open)
                cmd.Connection.Open();
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        #endregion

        #region  ExecuteReader


        public static SqlDataReader ExecuteReader(string connectionString, SqlCommand cmd)
        {
             
            SqlConnection conn = new SqlConnection(connectionString);

            // we use a try/catch here because if the method throws an exception we want to 
            // close the connection throw code, because no datareader will exist, hence the 
            // commandBehaviour.CloseConnection will not work
            try
            {
                cmd.Connection = conn;
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch(Exception ex)
            {
                conn.Close();
                throw;
            }
        }

        public static SqlDataReader ExecuteReader(SqlTransaction trans, SqlCommand cmd)
        {
            if (trans != null)
            {
                cmd.Transaction = trans;
                cmd.Connection = trans.Connection;
            }
            if (cmd.Connection.State != ConnectionState.Open)
                cmd.Connection.Open();
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd.Parameters.Clear();
            return rdr;

        }

        public static SqlDataReader ExecuteReader(SqlConnection conn, SqlCommand cmd)
        {
            cmd.Connection = conn;
            if (cmd.Connection.State != ConnectionState.Open)
                cmd.Connection.Open();
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd.Parameters.Clear();
            return rdr;
        }

        #endregion

        #region  ExecuteScalar

        public static object ExecuteScalar(string connectionString, SqlCommand cmd)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                cmd.Connection = conn;
                conn.Open();
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }

        public static object ExecuteScalar(SqlTransaction trans, SqlCommand cmd)
        {
            if (trans != null)
            {
                cmd.Transaction = trans;
                cmd.Connection = trans.Connection;
            }
            if (cmd.Connection.State != ConnectionState.Open)
                cmd.Connection.Open();
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }

        public static object ExecuteScalar(SqlConnection conn, SqlCommand cmd)
        {
            cmd.Connection = conn;
            if (cmd.Connection.State != ConnectionState.Open)
                cmd.Connection.Open();
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }

        #endregion

        #region ExecuteDataset

        public static DataSet ExecuteDataset(string connectionString, SqlCommand cmd)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                cmd.Connection = conn;               
                SqlDataAdapter da = new SqlDataAdapter(cmd);               
                DataSet ds = new DataSet();
                da.Fill(ds);
                cmd.Parameters.Clear();
                return ds;
            }
        }

        public static DataSet ExecuteDataset(SqlTransaction trans, SqlCommand cmd)
        {
            if (trans != null)
            {
                cmd.Transaction = trans;
                cmd.Connection = trans.Connection;
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.Parameters.Clear();
            return ds;
        }

        public static DataSet ExecuteDataset(SqlConnection conn, SqlCommand cmd)
        {
            cmd.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.Parameters.Clear();
            return ds;
        }


        #endregion

        #region 更新数据表
        public static int UpdateDataTable(string connectionString, SqlCommand cmd, DataTable data)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                int count = 0;

                cmd.Connection = conn;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                SqlCommandBuilder b = new SqlCommandBuilder(da);
                count = da.Update(data);
                data.AcceptChanges();

                return count;
            }
        }


        public static int UpdateDataTable(SqlTransaction trans, SqlCommand cmd, DataTable data)
        {
            int count = 0;
            if (trans != null)
            {
                cmd.Transaction = trans;
                cmd.Connection = trans.Connection;
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlCommandBuilder b = new SqlCommandBuilder(da);
            count = da.Update(data);
            data.AcceptChanges();
            return count;
        }

        public static int UpdateDataTable(SqlConnection conn, SqlCommand cmd, DataTable data)
        {
            int count = 0;
            cmd.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlCommandBuilder b = new SqlCommandBuilder(da);
            count = da.Update(data);
            data.AcceptChanges();
            return count;
        }

        #endregion

    }
}
