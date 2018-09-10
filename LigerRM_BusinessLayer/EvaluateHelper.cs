using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SignetInternet_BusinessLayer
{
    public class EvaluateHelper
    {
        public void AddEvaluate(Evaluate info)
        {
            string sql = "insert into dbo.Rent_Evaluate values ('"+info.EvaluateID+"','"+info.EvaluateObject+"','"+info.EvaluateType+
                "','"+DateTime.Now.ToString()+"'," + (info.EvaluateItem0.HasValue ? info.EvaluateItem0.Value.ToString() : "null") + ","+(info.EvaluateItem1.HasValue?info.EvaluateItem1.Value.ToString():"null")+","
                +(info.EvaluateItem2.HasValue?info.EvaluateItem2.Value.ToString():"null")+","+(info.EvaluateItem3.HasValue?info.EvaluateItem3.Value.ToString():"null")+","+(info.EvaluateItem4.HasValue?info.EvaluateItem4.Value.ToString():"null")+",'"+info.EvaluatePerson+"','"+info.EvaluateDesc+"')";
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
        }

        public DataTable GetEvaluateList(string objectId)
        { 
            string sql = "select * from Rent_Evaluate where EvaluateObject='"+objectId+"'";
            return MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
        }

        public Evaluate GetEvaluateDetail(string evaId)
        {
            return new Evaluate(evaId);
        }
    }
}
