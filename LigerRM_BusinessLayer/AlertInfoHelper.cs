using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SignetInternet_BusinessLayer
{
    public class AlertInfoHelper
    {
        public void DeleteAlertInfo(string id)
        {
            string sql = "delete from t_alert_info where AlertID='" + id + "'";
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
        }

        public void HandleAlertInfo(string id, string person, string desc)
        {
            string sql = "update t_alert_info set handleperson='"+person+"',handledate='"+DateTime.Now.ToString()+"',alertstatus='1',handleDesc='"+desc+"' where AlertID='" + id + "'";
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
        }
    }
}
