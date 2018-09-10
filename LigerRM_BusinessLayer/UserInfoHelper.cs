using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using SignetInternet_DataLayer.SignetDataSetTableAdapters;

namespace SignetInternet_BusinessLayer
{
    public class UserInfoHelper
    {
        private static String SqlConnString = MySQLHelper.SqlConnString;
        public DataTable GetUserInfoList()
        {
            DataTable userTable = MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(CommandType.StoredProcedure, "up_SignetInternet_UserSelectAll", null)).Tables[0];
            return userTable;
        }

        //up_SignetInternet_RegDeptSelectAll
        public DataTable GetRegDeptList()
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select * from Rent_PoliceStation where parentID>0");
            return MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(sqlStr.ToString())).Tables[0];
        }

        public DataTable GetDeptList()
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select * from CF_Department");
            return MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(sqlStr.ToString())).Tables[0];
        }

        public DataTable GetCummunityList()
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select * from Rent_Road");
            return MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(sqlStr.ToString())).Tables[0];
        }

        public DataTable GetCummunityListByUser(string userId)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select * from Rent_user_community_relationship where t_wu_user_id="+userId);
            return MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(sqlStr.ToString())).Tables[0];
        }

        public DataTable GetCFUserList(string deptId)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select * from cf_user where DeptId="+deptId);
            return MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(sqlStr.ToString())).Tables[0];
        }

        public DataTable GetUserRegRelationList(string userId)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select * from Rent_user_dept_relationship where t_wu_user_id="+userId);
            return MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(sqlStr.ToString())).Tables[0];
        }

        public void InsertRelationShip(string userId, string region)
        {
            
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("insert into Rent_user_dept_relationship values ('"+Guid.NewGuid().ToString()+"',"+userId+",'"+region+"','1','')");
            MySQLHelper.ExecuteNonQuery(SqlConnString, MySQLHelper.CreateCommand(sqlStr.ToString()));
        }

        public void DeleteRelationShip(string userId)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("delete from Rent_user_dept_relationship where t_wu_user_id="+userId);
            MySQLHelper.ExecuteNonQuery(SqlConnString, MySQLHelper.CreateCommand(sqlStr.ToString()));
        }

        public void DeleteSignetRelationship(string guid)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("delete from Rent_user_dept_relationship where t_fun_guid='" + guid+"'");
            MySQLHelper.ExecuteNonQuery(SqlConnString, MySQLHelper.CreateCommand(sqlStr.ToString()));
        }

        public void DeleteCommunityRelationship(string guid)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("delete from Rent_user_community_relationship where t_fun_guid='" + guid + "'");
            MySQLHelper.ExecuteNonQuery(SqlConnString, MySQLHelper.CreateCommand(sqlStr.ToString()));
        }

        public void DeleteCommunityRelationShip(string userId)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("delete from Rent_user_community_relationship where t_wu_user_id=" + userId);
            MySQLHelper.ExecuteNonQuery(SqlConnString, MySQLHelper.CreateCommand(sqlStr.ToString()));
        }

        public void InsertCommunityRelationShip(string userId, string region)
        {

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("insert into Rent_user_community_relationship values ('" + Guid.NewGuid().ToString() + "'," + userId + ",'" + region + "','1','')");
            MySQLHelper.ExecuteNonQuery(SqlConnString, MySQLHelper.CreateCommand(sqlStr.ToString()));
        }

        public void InsertUserRole(string userId, string roleId)
        {
            string sql = "insert into cf_UserRole values (" + userId + "," + roleId + ",null,'" + DateTime.Now.ToString() + "',null,null,'A')";
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
        }

        public void AddUserInfo(string loginName, string password, string realName, string sex, string phone, string idcard)
        {

            RentInfoHelper helper = new RentInfoHelper();
            string tempPass = Encrypt.DESEncrypt(password);
            Dictionary<string, string> ret = new Dictionary<string, string>();
            try
            {
                helper.GetJSONInfo("insert into cf_user values ('" + loginName + "','" + tempPass + "','','0','','" + realName + "','','" + sex + "','" +
                    phone + "','','','" + idcard + "','','','" + DateTime.Now.ToString() + "',0,'" + DateTime.Now.ToString() + "',0,'" + DateTime.Now.ToString() + "','0')");

                //添加默认权限
                UserInfoHelper userhelper = new UserInfoHelper();
                CFUserInfo info = new CFUserInfo(loginName);
                userhelper.InsertUserRole(info.UserID.ToString(), "20");
            }
            catch (Exception ex)
            {
            }
        }

        public bool IsExistsSamePhone(string phone)
        { 
            string sql = "select * from cf_user where Phone='"+phone+"'";
            return MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0].Rows.Count > 0;
        }
    }
}
