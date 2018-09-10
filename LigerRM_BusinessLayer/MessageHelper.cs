using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SignetInternet_DataLayer.BaseDataSetTableAdapters;
using SignetInternet_DataLayer.SignetDataSetTableAdapters;


namespace SignetInternet_BusinessLayer
{
    public class MessageHelper
    {
        public DataTable GetAllMessages()
        {
            string sql = "select top 5 * from t_web_text order by wt_time desc ";
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString,MySQLHelper.CreateCommand(sql)).Tables[0];
            return dt;
        }

        public DataTable GetMessageByPoliceStation()
        { 
            string sql = "select * from t_web_text where wt_serial_id not in(select messageid from t_web_text_relationship )"+
                           " union all"+
                           "  select t_web_text.* from t_web_text "+
                           " inner join t_web_text_relationship r on r.MessageID = t_web_text.wt_serial_id and r.RelatedID  in("+LigerRM.Common.SysContext.CurrentAreaIDs+")";
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            return dt;
        }

        public bool IsRead(long messageId, string carveIds)
        {
            t_web_text_relationshipTableAdapter adapter = new t_web_text_relationshipTableAdapter();
            DataTable dt = adapter.up_SignetInternet_WebMessageSelectByMessageCarves(messageId, carveIds);
            if (dt == null || dt.Rows.Count == 0)
                return true;
            else
            {
                bool isread = true;
                foreach (DataRow row in dt.Rows)
                {
                    isread = isread && bool.Parse(row["IsRead"].ToString());
                }

                return isread;
            }
        }
        
        public void AddMessage(string title,string content,string reporter,string carveIds)
        {
            string guid = Guid.NewGuid().ToString();
            string sql = "insert into t_web_text values ('"+guid+"','"+title+"','"+content+"','"+DateTime.Now.ToString()+"','"+reporter+"','A')";
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
            if (!string.IsNullOrEmpty(carveIds))
            {
                foreach (string s in carveIds.Split(','))
                {
                    sql = "insert into t_web_text_relationship values ('" + Guid.NewGuid().ToString() + "','" + guid + "','" + s + "',0,null)";
                    MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                }
            }
        }

        public void DeleteMessage(string msgId)
        {
            string guid = Guid.NewGuid().ToString();
            string sql = "delete from t_web_text where wt_serial_id='"+msgId+"'";
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));

        }

        public void UpdateMessage(string title,string content,string id)
        {
            string guid = Guid.NewGuid().ToString();
            string sql = "update t_web_text set wt_title='" + title + "',wt_text='" + content + "' where wt_serial_id='"+id+"'";
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
        }

        public DataTable GetMessage(string id)
        {
            string sql = "select * from t_web_text where wt_serial_id='" + id + "'";
            return MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
        }

        public void AddMessageRelation(long messageId, string carveId)
        {
            t_web_text_relationshipTableAdapter adapter = new t_web_text_relationshipTableAdapter();
            adapter.up_SignetInternet_WebMessageRelationshipInsert(messageId, carveId, false);
        }

        public void DeleteMessageRelation(long relationId)
        {
            t_web_text_relationshipTableAdapter adapter = new t_web_text_relationshipTableAdapter();
            adapter.up_SignetInternet_WebMessageRelationshipDelete(relationId);
        }

        public void DeleteMessageRelationByMessageID(long messageId)
        {
            t_web_text_relationshipTableAdapter adapter = new t_web_text_relationshipTableAdapter();
            adapter.up_SignetInternet_WebMessageRelationshipDeleteByMessageID(messageId);
        }

        public void ReadMessage(string messageId,string carveId)
        {
            string sql = "update t_web_text_relationship set IsRead=1,ReadDate= '"+DateTime.Now.ToString()+"' where MessageID='"+messageId+"' and RelatedID in ("+carveId+")";
        }
    }
}
