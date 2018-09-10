using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using SignetInternet_DataLayer.SignetDataSetTableAdapters;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Xml;
using System.Drawing;
using System.Configuration;


namespace SignetInternet_BusinessLayer
{
    public class SignetHelper
    {
        private static String SqlConnString = MySQLHelper.SqlConnString;


        
        public int GetCount(string strSql)
        {
            object obj = MySQLHelper.ExecuteScalar(SqlConnString, MySQLHelper.CreateCommand(strSql));
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        public bool HasRFIDCard(string signetId)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@signetId", SqlDbType.VarChar, 13),
					};
            parameters[0].Value = signetId;
            DataTable signetTable = MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(CommandType.StoredProcedure, "up_SignetRFID_SignetRFIDSelectBySignetID", parameters)).Tables[0];
            if (signetTable.Rows.Count > 0)
                return true;
            else
                return false;

        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize, int PageIndex,string tableName,string key, string strWhere, string Fields, string SortStr, bool IsRetCount)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@TableName", SqlDbType.VarChar, 500),
					new SqlParameter("@Fields", SqlDbType.VarChar, 255),
					new SqlParameter("@SortStr", SqlDbType.VarChar, 255),
					new SqlParameter("@Pkey", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsRetCount", SqlDbType.Bit),
					new SqlParameter("@WhereStr", SqlDbType.VarChar,3000),
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

        public DataSet GetSignetMark(string signetId)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select * from t_signet_mark where signetid=@signetId");
            SqlParameter[] parameters = {
                                        new SqlParameter("@signetId",SqlDbType.VarChar,50),
                                        };
            parameters[0].Value = signetId;
            return MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(sqlStr.ToString(), parameters));
        }

        public void ExcuteSQL(string sql)
        {
            MySQLHelper.ExecuteNonQuery(SqlConnString, MySQLHelper.CreateCommand(sql));
        }

        public string GetVerifyCode(int maxLen) //Retun a 8 degrees verify code to user 
        {
            string tempStr = string.Empty;
            Random ran = new Random();
            for (int i = 0; i < maxLen; i++)
            {
                tempStr += ran.Next(9).ToString();
            }
            return tempStr;
        }

        public bool CreateTempFileFromDataBase(string signetId, string filename, out int width, out int height, out int dpi,out byte[] mark)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from t_signet_mark where sm_signet_id='" + signetId + "' order by sm_mark_id desc");
                DataTable markTable = new DataTable();
                markTable =MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(strSql.ToString())).Tables[0];

                if (markTable!=null && markTable.Rows.Count >= 1)
                {
                    width = int.Parse(double.Parse(markTable.Rows[0]["sm_width"].ToString()).ToString());
                    height = int.Parse(double.Parse(markTable.Rows[0]["sm_height"].ToString()).ToString());
                    dpi = int.Parse(markTable.Rows[0]["sm_definition"].ToString());
                    byte[] image = (byte[])markTable.Rows[0]["sm_mark"];
                    mark = (byte[])markTable.Rows[0]["sm_mark"];
                    FileStream fileStream = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite);
                    fileStream.Write(image, 0, image.Length);
                    fileStream.Flush();
                    fileStream.Dispose();
                    return true;
                }
                else
                {
                    width = 0;
                    height = 0;
                    dpi = 0;
                    mark = null;
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CreateDATFileFromDataBase(string signetId,string filename)
        {
            try
            {
                int width, height, dpi;
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from t_signet_mark where sm_signet_id='" + signetId + "'");
                DataTable markTable = new DataTable();
                markTable = MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(strSql.ToString())).Tables[0];

                if (markTable != null && markTable.Rows.Count == 1)
                {
                    width = int.Parse(double.Parse(markTable.Rows[0]["sm_width"].ToString()).ToString());
                    height = int.Parse(double.Parse(markTable.Rows[0]["sm_height"].ToString()).ToString());
                    dpi = int.Parse(markTable.Rows[0]["sm_definition"].ToString());
                    byte[] image = (byte[])markTable.Rows[0]["sm_mark"];
                    int head = 0x55aa5a5a;
                    byte[] headBytes = BitConverter.GetBytes(head);
                    byte[] widthBytes = BitConverter.GetBytes(width);
                    byte[] heightBytes = BitConverter.GetBytes(height);
                    FileStream fileStream = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite);
                    fileStream.Write(headBytes, 0, headBytes.Length);
                    fileStream.Write(widthBytes,0,widthBytes.Length);
                    fileStream.Write(heightBytes,0,heightBytes.Length);
                    fileStream.Write(image,0,image.Length);
                    fileStream.Flush();
                    fileStream.Dispose();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string CreateBmpFile(string tempfile, string bmpfile, int width, int height, int dpi)
        {
            try
            {
                bool hr = SignetImageHelper.ConvertSignFileToBmp(tempfile, bmpfile, width, height, dpi);
                if (hr)
                {
                    FileInfo file = new FileInfo(tempfile);
                    file.Delete();
                    return bmpfile;
                }
                else
                    return string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetSignetId(string areaId)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select currentId=right(MAX(se_signet_id),7) from T_signet where LEFT(se_signet_id,6)='" + areaId + "'");
            DataTable corpTable = MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(sqlStr.ToString())).Tables[0];
            if (corpTable != null && corpTable.Rows.Count > 0)
            {
                double tempD = 0;
                if (!corpTable.Rows[0].IsNull("currentId") && double.TryParse(corpTable.Rows[0]["currentId"].ToString(), out tempD))
                    return areaId + (double.Parse(corpTable.Rows[0]["currentId"].ToString()) + 1).ToString().PadLeft(7, '0');
                else
                {
                    string signetNumber = ConfigurationManager.AppSettings["SignetNumber"];
                    if (string.IsNullOrEmpty(signetNumber))
                        return areaId + "0000001";
                    else
                        return areaId + double.Parse(signetNumber).ToString().PadLeft(7, '0').ToString();
                }
            }
            else
            {
                string signetNumber = ConfigurationManager.AppSettings["SignetNumber"];
                if (string.IsNullOrEmpty(signetNumber))
                    return areaId + "0000001";
                else
                    return areaId + double.Parse(signetNumber).ToString().PadLeft(7, '0').ToString();
            }
        }

     


        public bool IsExistsRegister(string register)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select * from t_signet_view where sr_reg_dept_id =@register");
            SqlParameter[] parameters = {
                                        new SqlParameter("@register",SqlDbType.VarChar,12),
                                        };
            parameters[0].Value = register;
            DataTable signetTable = MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(sqlStr.ToString(), parameters)).Tables[0];
            if (signetTable != null && signetTable.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public bool IsCodeInUsing(string category, string item)
        {
            string sqlStr = string.Empty;
            switch (category)
            {
                case "BA":
                case "FC":
                case "CC":
                    {
                        sqlStr = "select * from t_signet_cancel_info where sci_cancel_type='"+item+"'";
                        break;
                    }
                case "LT":
                    {
                        sqlStr = "select * from t_signet_loss_log where sll_loss_type='" + item + "'";
                        break;
                    }
                case "CT":
                    {
                        sqlStr = "select * from t_corporation where co_type='"+item+"'";
                        break;
                    }
                case "CF":
                    {
                        sqlStr = "select sf_signet_id from t_signet_files where sf_file_type='"+item+"'";
                        break;
                    }
                case "ST":
                    {
                        sqlStr = "select * from t_signet where se_signet_type = '"+item+"'";
                        break;
                    }
                case "SS":
                    {
                        sqlStr = "select * from t_signet where se_status = '" + item + "'";
                        break;
                    }
                case "SH":
                    {
                        sqlStr = "select * from t_signet where se_shell_type = '"+item+"'";
                        break;
                    }
                case "SM":
                    {
                        sqlStr = "select * from t_signet where se_material = '"+item+"'";
                        break;
                    }
                case "User":
                    {
                        sqlStr = "Select * from t_signet where se_creator = '"+item+"'";
                        break;
                    }
                case "Role":
                    {
                        sqlStr = "select * from CF_UserRole where UserID="+item;
                        break;
                    }
            }
            if (string.IsNullOrEmpty(sqlStr))
                return true;
            else
            {
                DataTable signetTable = MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(sqlStr.ToString())).Tables[0];
                if (signetTable != null && signetTable.Rows.Count > 0)
                    return true;
                else
                    return false;
            }
        }


        public string BuildListXml(List<object> listToBuild, string parentElementName, string childElementName)
        {
            MemoryStream stream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(stream, System.Text.Encoding.UTF8);
            StreamReader reader = new StreamReader(stream);
            try
            {
                //build xml parameter
                writer.WriteStartDocument();
                writer.WriteStartElement(parentElementName);
                foreach (var i in listToBuild)
                {
                    writer.WriteStartElement(childElementName);
                    writer.WriteString(i.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();

                stream.Seek(0, SeekOrigin.Begin);
                return reader.ReadToEnd();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                writer.Close();
                stream.Close();
                reader.Close();
            }
        }

 


        public void DeleteData(string table)
        {
            string sqlStr = "Delete from " + table;
            MySQLHelper.ExecuteNonQuery(SqlConnString, MySQLHelper.CreateCommand(sqlStr));
        }

    }
}
