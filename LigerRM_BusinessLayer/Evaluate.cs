using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SignetInternet_BusinessLayer
{
    public class Evaluate
    {
        private string m_evaId;
        private string m_evaObject;
        private string m_evaType;
        private DateTime m_evaDate;
        private decimal? m_evaItem0;
        private decimal? m_evaItem1;
        private decimal? m_evaItem2;
        private decimal? m_evaItem3;
        private decimal? m_evaItem4;
        private string m_evaPerson;
        private string m_evaDesc;

        public string EvaluateID
        {
            get { return m_evaId; }
            set { m_evaId = value; }
        }

        public string EvaluateObject { get { return m_evaObject; } set { m_evaObject = value; } }

        public string EvaluateType { get { return m_evaType; } set { m_evaType = value; } }

        public DateTime EvaluateDate { get { return m_evaDate; } set { m_evaDate = value; } }

        public decimal? EvaluateItem0 { get { return m_evaItem0; } set { m_evaItem0 = value; } }

        public decimal? EvaluateItem1 { get { return m_evaItem1; } set { m_evaItem1 = value; } }
        public decimal? EvaluateItem2 { get { return m_evaItem2; } set { m_evaItem2 = value; } }
        public decimal? EvaluateItem3 { get { return m_evaItem3; } set { m_evaItem3 = value; } }
        public decimal? EvaluateItem4 { get { return m_evaItem4; } set { m_evaItem4 = value; } }

        public string EvaluatePerson { get { return m_evaPerson; } set { m_evaPerson = value; } }

        public string EvaluateDesc { get { return m_evaDesc; } set { m_evaDesc = value; } }

        public Evaluate(string evaId)
        { 
            string sql = "select * from dbo.Rent_Evaluate where EvaluateID='"+evaId+"'";
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                m_evaId = evaId;
                m_evaObject = row["EvaluateObject"].ToString();
                m_evaType = row["EvaluateType"].ToString();
                m_evaDate = DateTime.Parse(row["EvaluateDate"].ToString());
                if (!row.IsNull("EvaluateItem0"))
                    m_evaItem0 = decimal.Parse( row["EvaluateItem0"].ToString());
                if (!row.IsNull("EvaluateItem1"))
                    m_evaItem1 = decimal.Parse(row["EvaluateItem1"].ToString());
                if (!row.IsNull("EvaluateItem2"))
                    m_evaItem2 = decimal.Parse(row["EvaluateItem2"].ToString());
                if (!row.IsNull("EvaluateItem3"))
                    m_evaItem3 = decimal.Parse(row["EvaluateItem3"].ToString());
                if (!row.IsNull("EvaluateItem4"))
                    m_evaItem4 = decimal.Parse(row["EvaluateItem4"].ToString());
                m_evaPerson = row["EvaluatePerson"].ToString();
                if (!row.IsNull("EvaluateDesc"))
                    m_evaDesc = row["EvaluateDesc"].ToString();
            }
        }

        public Evaluate() { }
    }
}
