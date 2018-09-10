using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SignetInternet_BusinessLayer
{
    public class MonitorPersonInfo
    {
        private string m_id;
        private string m_name;
        private string m_idcard;
        private string m_phone;
        private string m_type;
        private string m_status;
        private DateTime m_startDate;
        private DateTime? m_endDate;
        private string m_createdBy;
        private DateTime m_createdOn;

        public string ID { get { return m_id; } set { m_id = value; } }
        public string Name { get { return m_name; } set { m_name = value; } }
        public string IDCard { get { return m_idcard; } set { m_idcard = value; } }
        public string Phone { get { return m_phone; } set { m_phone = value; } }
        public string PersonType { get { return m_type; } set { m_type = value; } }
        public string Status { get { return m_status; } set { m_status = value; } }
        public string CreatedBy { get { return m_createdBy; } set { m_createdBy = value; } }
        public DateTime CreatedOn { get { return m_createdOn; } set { m_createdOn = value; } }
        public DateTime StartDate { get { return m_startDate; } set { m_startDate = value; } }
        public DateTime? EndDate { get { return m_endDate; } set { m_endDate = value; } }

        public MonitorPersonInfo(string id)
        { 
            string sql = "select * from Rent_Person_Monitor where ID='"+id+"'";
            DataTable dt= MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                m_id = row["ID"].ToString();
                m_name = row["Name"].ToString();
                m_idcard = row["IDCard"].ToString();
                m_phone = row["Phone"].ToString();
                m_createdBy = row["CreatedBy"].ToString();
                m_status = row["Status"].ToString();
                m_type = row["PersonType"].ToString();
                m_startDate = DateTime.Parse(row["StartDate"].ToString());
                m_createdOn = DateTime.Parse(row["CreatedOn"].ToString());
                if (!row.IsNull("EndDate"))
                    m_endDate = DateTime.Parse(row["EndDate"].ToString());
            }
        }
    }
}
