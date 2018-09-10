using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SignetInternet_DataLayer.SignetDataSetTableAdapters;

namespace SignetInternet_BusinessLayer
{
    public class CFUserInfo
    {
        public int UserID { get; set; }
        public string LoginName { get; set; }
        public int UserLevel { get; set; }
        public string RealName { get; set; }
        public string DeviceID { get; set; }
        public decimal Wallet { get; set; }
        public string Phone { get; set; }
        public string IDCard { get; set; }

        public CFUserInfo(string username)
        {
            string sql = "select * from cf_user where LoginName='" + username+ "'";
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                UserID = int.Parse(row["UserID"].ToString());
                LoginName = row["LoginName"].ToString();
                UserLevel = row.IsNull("DeptID") ? 0 : string.IsNullOrEmpty(row["DeptID"].ToString()) ? 0 : int.Parse(row["DeptID"].ToString());
                RealName = row.IsNull("RealName") ? string.Empty : row["RealName"].ToString();
                Phone = row.IsNull("Phone") ? string.Empty : row["Phone"].ToString();
                DeviceID = row.IsNull("Fax") ? string.Empty : row["Fax"].ToString();
                IDCard = row.IsNull("IDCard") ? string.Empty : row["IDCard"].ToString();
            }
        }

        public CFUserInfo(string idCard,bool isOut)
        { 
            string sql = "select * from cf_user where IDCard='"+idCard+"'";
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                UserID = int.Parse(row["UserID"].ToString());
                LoginName = row["LoginName"].ToString();
                UserLevel = row.IsNull("DeptID") ? 0 : string.IsNullOrEmpty(row["DeptID"].ToString()) ? 0 : int.Parse(row["DeptID"].ToString());
                RealName = row.IsNull("RealName")?string.Empty:row["RealName"].ToString();
                Phone = row.IsNull("Phone") ? string.Empty : row["Phone"].ToString();
                DeviceID = row.IsNull("Fax") ? string.Empty : row["Fax"].ToString();
                IDCard = row.IsNull("IDCard") ? string.Empty : row["IDCard"].ToString();
            }
        }


    }
}
