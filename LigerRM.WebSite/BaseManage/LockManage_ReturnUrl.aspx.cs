using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using LigerRM.Common;

public partial class BaseManage_LockManage_ReturnUrl : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            System.IO.Stream postData = Request.InputStream;
            StreamReader sRead = new StreamReader(postData);
            string postContent = sRead.ReadToEnd();
            sRead.Close();
            Dictionary<string, string> retDic = new Dictionary<string, string>();
            string sql = string.Empty;
            string statucode = "0";
            string reason = "";
            FileStream fs = new FileStream(Server.MapPath("~") + "\\BaseManage\\Log.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(DateTime.Now.ToString() + " " + postContent);


            try
            {
                //switch (Request.Headers["ResourceId"])
                //{
                //    case "banevent": //道闸事件
                //        //postContent ="{\"res\":[{\"whois\":{\"pln\":\"津GHY798\",\"etag\":\"\"},\"loc\":{\"parklot\":\"ff8080815d340ac3015d3e2bc5c00004\",\"logicid\":\"8\"},\"status\":1,\"timeStamp\":\"2017-11-16T11:57:43+08:00\"}]}";
                //        Dictionary<string, BanEvent[]> ret1 = JSONHelper.FromJson<Dictionary<string, BanEvent[]>>(postContent);
                //        //{
                //        //    “loc”:{“parklot”: “0201”, “logicid”:”755001”},
                //        //    “whois”:{“pln”: “”, “etag”:””},
                //        //    "status": 0, 
                //        //    "timeStamp":”2016-11-01T19:40:00+8:00” 
                //        //}
                //        foreach (BanEvent b in ret1["res"])
                //        {
                //            sql = "insert into Motor_BanEvent values ('" + Guid.NewGuid().ToString() + "','" + b.loc.parklot + "','" + b.loc.logicid + "','" + b.whois.pln + "','" + b.whois.etag + "','" + b.status + "','" + DateTime.Parse(b.timestamp).ToString() + "','')";
                //            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                //            sql = "Update Motor_berthesInfo set status='" + b.status + "' where ParkID='" + b.loc.parklot + "' and BertheNumber ='" + b.loc.logicid + "'";
                //            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));

                //            string uploadData = ConfigurationManager.AppSettings["UploadData"];
                //            RentAttribute rentAttribute = new RentAttribute();
                //            RentAttributeHelper rentAttributeHelper = new RentAttributeHelper();
                //            if (uploadData.Equals("1"))
                //            {
                //                //string sql = "insert into T_Person_Info values ('" + Guid.NewGuid().ToString() + "','" + info.RRAID.ToString() + "','" + info.RRAContactName + "','" + info.RRAIDCard + "','0','" + DateTime.Now.ToString() + "','0','','RZF','" + rent.RAddress + "','" + rent.RPSName + "','" + rent.RPSName + "','0','','')";
                //                rentAttributeHelper.UploadPersonInfo("0", b.whois.pln);
                //            }
                //        }
                //        break;
                //    case "parkevent": //停车走车
                //        Dictionary<string, ParkEvent[]> ret2 = JSONHelper.FromJson<Dictionary<string, ParkEvent[]>>(postContent);

                //        //{
                //        //    “loc”:{“parklot”: “0201”, “logicid”:”755001”},
                //        //    “whois”:{“pln”: “”, “etag”:””},
                //        //    "status": 0, 
                //        //    "timeStamp":”2016-11-01T19:40:00+8:00” 
                //        //}
                //        foreach (ParkEvent p in ret2["res"])
                //        {
                //            sql = "insert into Motor_ParkEvent values ('" + Guid.NewGuid().ToString() + "','','" + p.loc.logicid + "','" + p.whois.pln + "','" + p.whois.etag + "','" + p.status + "','" + DateTime.Parse(p.timestamp).ToString() + "','')";
                //            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                //            sql = "Update Motor_berthesInfo set status='" + p.status + "' where BertheNumber ='" + p.loc.logicid + "'";
                //            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                //        }
                //        break;
                //    case "devstatus": //车位状态
                //        break;
                //    case "alarm": //告警
                //        break;
                //}


            }
            catch (Exception ex)
            {
                statucode = "201";
                reason = ex.Message;
                sw.WriteLine(DateTime.Now.ToString() + " " + ex.Message);
            }


            ////开始写入
            //sw.WriteLine(DateTime.Now.ToString() + " " + Request.Headers["ResourceId"] + " " + postContent);

            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();

            Dictionary<string, string> ret = new Dictionary<string, string>();
            ret.Add("resutcode", statucode);
            ret.Add("reason", reason);
            Response.Write(JSONHelper.ToJson(ret));
        }
    }
}