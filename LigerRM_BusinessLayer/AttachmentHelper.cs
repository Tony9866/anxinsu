using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace SignetInternet_BusinessLayer
{
    public class AttachmentHelper
    {
        private static String SqlConnString = MySQLHelper.SqlConnString;
        public DataSet GetList(int PageSize, int PageIndex, string tableName, string key, string strWhere, string Fields, string SortStr, bool IsRetCount)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@TableName", SqlDbType.VarChar, 500),
					new SqlParameter("@Fields", SqlDbType.VarChar, 255),
					new SqlParameter("@SortStr", SqlDbType.VarChar, 255),
					new SqlParameter("@Pkey", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsRetCount", SqlDbType.Bit),
					new SqlParameter("@WhereStr", SqlDbType.VarChar,1000),
					};
            parameters[0].Value = tableName;
            parameters[1].Value = Fields;
            parameters[2].Value = SortStr;
            parameters[3].Value = key;
            parameters[4].Value = PageSize;
            parameters[5].Value = PageIndex;
            parameters[6].Value = IsRetCount;
            parameters[7].Value = strWhere;
            return MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(CommandType.StoredProcedure, "UP_GetRecordByPageOrder", parameters));
        }

        public void DeleteAttachment(string attachmentId)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("Delete from t_signet_attachment where sa_attachment_id=" + attachmentId);
            MySQLHelper.ExecuteNonQuery(SqlConnString, MySQLHelper.CreateCommand(sqlStr.ToString()));
        }

        public void UpdateAttachment(AttachmentInfo attachInfo)
        {
            StringBuilder sqlStr = new StringBuilder();
            if (attachInfo.AttachmentID.HasValue) //update
            {

            }
            else //Insert
            {
                sqlStr.Append("Insert into t_signet_attachment values(@sa_signet_id,@sa_title,@file,@sa_demo,@sa_date)");
                SqlParameter[] parameters = {
                                        new SqlParameter("@sa_signet_id",SqlDbType.VarChar,13),
                                        new SqlParameter("@sa_title",SqlDbType.VarChar,100),
                                        new SqlParameter("@file",SqlDbType.Image),
                                        new SqlParameter("@sa_demo",SqlDbType.VarChar,500),
                                        new SqlParameter("@sa_date",SqlDbType.DateTime)
                                        };
                parameters[0].Value = attachInfo.SignetID;
                parameters[1].Value = attachInfo.Title;
                parameters[2].Value = attachInfo.FileInfo;
                parameters[3].Value = attachInfo.AttachmentDemo;
                parameters[4].Value = DateTime.Now;
                MySQLHelper.ExecuteNonQuery(SqlConnString, MySQLHelper.CreateCommand(sqlStr.ToString(),parameters));
            }
        }

        
    }
}
