using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SignetInternet_BusinessLayer
{
    public class MonitorPersonHelper
    {
        public void AddMonitorPerson(MonitorPersonInfo info)
        {
            string endDate = string.Empty;
            if (info.EndDate.HasValue)
            {
                endDate = "'" + info.EndDate.ToString() + "'";
            }
            else
                endDate = "null";
            string sql = "insert into Rent_Person_Monitor values ('"+Guid.NewGuid().ToString()+"','"+info.Name+"','"+info.IDCard
                +"','"+info.Phone+"','"+info.CreatedOn.ToString()+"','"+info.StartDate.ToString()+"',"+endDate+",'"+info.CreatedBy+"','"+info.PersonType+"','"+info.Status+"')";
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
        }

        public void DeleteMonitorPerson(string id)
        { 
            string sql = "update Rent_Person_Monitor set status='C' where id='"+id+"'";
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
        }

        public void UpdateMonitorPerson(MonitorPersonInfo info)
        {
            string endDate = string.Empty;
            if (info.EndDate.HasValue)
            {
                endDate = "'" + info.EndDate.ToString() + "'";
            }
            else
                endDate = "null";
            string sql = "update Rent_Person_Monitor set Name='" + info.Name + "',IDCard='" + info.IDCard
                + "',Phone='" + info.Phone + "',StartDate='" + info.StartDate.ToString() + "',EndDate=" + endDate + ",PersonType='" + info.PersonType + "',Status='" + info.Status + "' where ID='"+info.ID+"'";
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
        }

        public void AddMonitorMotor(MonitorMotorInfo info)
        {
            string endDate = string.Empty;
            if (info.EndDate.HasValue)
            {
                endDate = "'" + info.EndDate.ToString() + "'";
            }
            else
                endDate = "null";
            string sql = "insert into Rent_Motor_Monitor values ('" + Guid.NewGuid().ToString() + "','" + info.MotorNO +  "','" + info.CreatedOn.ToString() + "','" + info.StartDate.ToString() + "'," + endDate + ",'" + info.CreatedBy + "','" + info.MotorType + "','" + info.Status + "')";
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
        }

        public void DeleteMonitorMotor(string id)
        {
            string sql = "update Rent_Motor_Monitor set status='C' where id='" + id + "'";
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
        }

        public void UpdateMonitorMotor(MonitorMotorInfo info)
        {
            string endDate = string.Empty;
            if (info.EndDate.HasValue)
            {
                endDate = "'" + info.EndDate.ToString() + "'";
            }
            else
                endDate = "null";
            string sql = "update Rent_Motor_Monitor set MotorNO='" + info.MotorNO  + "',StartDate='" + info.StartDate.ToString() + "',EndDate=" + endDate + ",MotorType='" + info.MotorType + "',Status='" + info.Status + "' where ID='" + info.ID + "'";
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
        }
    }
}
