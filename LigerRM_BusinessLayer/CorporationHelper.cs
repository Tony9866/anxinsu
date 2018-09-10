using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace SignetInternet_BusinessLayer
{
    public class CorporationHelper
    {
        private static String SqlConnString = MySQLHelper.SqlConnString;

        public void UpdateCorporation(CorporationInfo corpInfo)
        {
            StringBuilder strSql = new StringBuilder();
            if (IsExists(corpInfo.CorpID))
            {
                //Update
                strSql.Append("Update t_corporation set ");
                strSql.Append(" co_corp_name='" + corpInfo.CorpName + "',co_sort_id='" + corpInfo.SortID + "',co_alias_name='" + corpInfo.AliasName + "',");
                strSql.Append(" co_full_name = '" + corpInfo.FullName + "',co_corp_class='" + corpInfo.CorpClass + "',co_type='" + corpInfo.CorpType + "',");
                strSql.Append(" co_area_id='" + corpInfo.AreaID.Trim() + "',co_boss='" + corpInfo.BossName + "',co_boss_idcard='" + corpInfo.BossIDCard + "',");
                strSql.Append(" co_address='" + corpInfo.Address + "',co_linker='" + corpInfo.Linker + "',co_link_way='" + corpInfo.LinkWay + "', ");
                strSql.Append(" co_post_code='" + corpInfo.PostCode + "', co_tax_no='" + corpInfo.TaxNo + "',co_account_no='" + corpInfo.AccountNo + "', ");
                strSql.Append(" co_password='" + corpInfo.PassWord + "' ,co_other_no='" + corpInfo.OtherNo + "', co_creator='" + corpInfo.Creator + "',");
                strSql.Append(" co_create_date='" + corpInfo.CreateDate.ToString("yyyy-MM-dd hh:mm:ss") + "' ,co_who_cancel='" + corpInfo.Canceller + "',");
                if (corpInfo.CancelDate.HasValue)
                    strSql.Append(" co_cancel_date ='" + corpInfo.CancelDate.Value.ToString() + "',");
                else
                    strSql.Append(" co_cancel_date = null,");
                strSql.Append(" co_cancel_type='" + corpInfo.CancelType + "' ,co_cancel_reason='" + corpInfo.CancelReason + "',co_status='" + corpInfo.Status + "' ,");
                strSql.Append(" co_memo='"+corpInfo.Memo+"' ,co_biz_id='"+corpInfo.BizNo+"'");
                strSql.Append(" where co_corp_id = '" + corpInfo.CorpID + "'");
                SysLogHelper.AddLog(corpInfo.Creator, "修改企业信息ID：" + corpInfo.CorpID, "修改-企业信息");
            }
            else
            { 
                //Insert
                strSql.Append("Insert into t_corporation values (");
                strSql.Append("'" + corpInfo.CorpID + "','" + corpInfo.CorpName + "','" + corpInfo.SortID + "','" + corpInfo.AliasName + "','" + corpInfo.FullName + "',");
                strSql.Append("'" + corpInfo.CorpClass + "','" + corpInfo.CorpType + "','" + corpInfo.AreaID + "','" + corpInfo.BossName + "','" + corpInfo.BossIDCard + "',");
                strSql.Append("'" + corpInfo.Address + "','" + corpInfo.PostCode + "','" + corpInfo.Linker + "','" + corpInfo.LinkWay + "','" + corpInfo.TaxNo + "',");
                strSql.Append("'" + corpInfo.AccountNo + "','" + corpInfo.OtherNo + "','" + corpInfo.PassWord + "','" + corpInfo.Creator + "','" + corpInfo.CreateDate.ToString("yyyy-MM-dd hh:mm:ss") + "',");
                if (corpInfo.CancelDate.HasValue)
                    strSql.Append("'" + corpInfo.Canceller + "','" + corpInfo.CancelDate.Value.ToString("yyyy-MM-dd hh:mm:ss") + "',");
                else
                    strSql.Append("'" + corpInfo.Canceller + "',null,");
                strSql.Append("'" + corpInfo.CancelType + "','" + corpInfo.CancelReason + "','" + corpInfo.Status + "','" + corpInfo.Memo + "','" + corpInfo.BizNo + "'");
                strSql.Append(")");
                UpdateCorporationID(corpInfo.Region, corpInfo.RegionName);
                SysLogHelper.AddLog(corpInfo.Creator, "添加企业信息ID：" + corpInfo.CorpID, "添加-企业信息");
            }
            MySQLHelper.ExecuteNonQuery(SqlConnString, MySQLHelper.CreateCommand(strSql.ToString()));
        }

        public bool IsExists(string corpId)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select * from t_corporation where co_corp_id=@corpId");
            SqlParameter[] parameters = {
                                        new SqlParameter("@corpId",SqlDbType.VarChar,12),
                                        };
            parameters[0].Value = corpId;
            DataTable corpTable = MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(sqlStr.ToString(), parameters)).Tables[0];
            if (corpTable != null && corpTable.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public bool IsExistsCorpClass(string Id)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select * from t_corporation where co_corp_class=@Id");
            SqlParameter[] parameters = {
                                        new SqlParameter("@Id",SqlDbType.VarChar,10),
                                        };
            parameters[0].Value = Id;
            DataTable corpTable = MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(sqlStr.ToString(), parameters)).Tables[0];
            if (corpTable != null && corpTable.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public bool IsExistsSameCorp(string corpName)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select * from t_corporation where co_corp_name=@corpName");
            SqlParameter[] parameters = {
                                        new SqlParameter("@corpName",SqlDbType.VarChar,120),
                                        };
            parameters[0].Value = corpName;
            DataTable corpTable = MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(sqlStr.ToString(), parameters)).Tables[0];
            if (corpTable != null && corpTable.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public string GetCorporationID(string areaId)
        {
            
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select * from t_corpid_ctrl where ci_areaid='" + areaId + "'");
            DataTable corpTable = MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(sqlStr.ToString())).Tables[0];
            if (corpTable != null && corpTable.Rows.Count > 0)
                return areaId + corpTable.Rows[0]["ci_current_id"].ToString();
            else
                return areaId + "000001";
        }

        public bool IsCorporationInUsed(string corpId)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select * from t_signet where se_corp_id='" + corpId + "'");
            DataTable corpTable = MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(sqlStr.ToString())).Tables[0];
            if (corpTable != null && corpTable.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public void UpdateCorporationID(string areaId,string areaName)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select * from t_corpid_ctrl where ci_areaid='" + areaId + "'");
            DataTable corpTable = MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(sqlStr.ToString())).Tables[0];
            if (corpTable != null && corpTable.Rows.Count > 0)
            {
                int corpId = int.Parse(corpTable.Rows[0]["ci_current_id"].ToString());
                corpId++;
                string tempId = corpId.ToString().PadLeft(6, '0');
                sqlStr = new StringBuilder();
                sqlStr.Append("update t_corpid_ctrl set ci_current_id = '" + tempId + "' where ci_areaid='" + areaId + "'");
            }
            else
            {
                sqlStr = new StringBuilder();
                sqlStr.Append("Insert t_corpid_ctrl values (");
                sqlStr.Append("'" + areaId + "','" + areaName + "','000002'");
                sqlStr.Append(")");
            }
            MySQLHelper.ExecuteNonQuery(SqlConnString, MySQLHelper.CreateCommand(sqlStr.ToString()));
           
        }

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

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
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

        public string CreateVerifyCode(int maxInt)
        {
            string tempStr = string.Empty;
            Random ran = new Random();
            for (int i = 0; i < maxInt; i++)
            {
                tempStr += ran.Next(maxInt).ToString();
            }
            return tempStr;
        }

        public string CreateUserCode(int maxInt)
        {
            string tempStr = string.Empty;
            Random ran = new Random();
            return ran.Next(100000, 999999).ToString();
        }

        public void DeleteCorporation(string corpId)
        { 
                StringBuilder sqlStr = new StringBuilder();
                sqlStr.Append("delete from  t_corporation where co_corp_id='" + corpId + "'");
                MySQLHelper.ExecuteNonQuery(SqlConnString, MySQLHelper.CreateCommand(sqlStr.ToString()));
        }
    }
}
