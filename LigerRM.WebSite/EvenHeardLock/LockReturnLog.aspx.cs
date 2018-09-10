using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using SignetInternet_BusinessLayer;
using System.Data;
using LigerRM.Common;

public partial class EvenHeardLock_LockReturnLog : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string postContent = Request.Params["parameters"];
            Dictionary<string, string> ret = new Dictionary<string, string>();
            string sql = string.Empty;
            string statucode = "000";
            string reason = "request success";
            //////打印
            FileStream fs = new FileStream(Server.MapPath("~") + "\\EvenHeardLock\\LockReturnLog.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(DateTime.Now.ToString() + "接收到参数" + postContent);
            try
            {
                //postContent = "{\"res\":[{\"ret\":\"true\",\"StartDate\":\"\",\"EndDate\":\"\",\"uuid\":\"-34b634a4\",\"userId\":\"11111\"}]}";
                Dictionary<string, LockReturnBak[]> retCallBack = JSONHelper.FromJson<Dictionary<string, LockReturnBak[]>>(postContent);
                foreach (LockReturnBak b in retCallBack["res"])
                {
                    sql = "insert into Rent_Locks_ReturnLog values ('" + Guid.NewGuid().ToString() + "','" + b.userId + "','" + b.devId + "','" + b.pwd + "','" + 1 + "','" + GetDateTime(b.openTime) +"','" + DateTime.Now.ToString() + "','" + b.openType + "', '')";
                    MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                }
            }
            catch (Exception ex)
            {
                statucode = "201";
                reason = ex.Message;
                sw.WriteLine(DateTime.Now.ToString() + " " + ex.Message);
            }

            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();


            ret.Add("resutcode", statucode);
            ret.Add("reason", reason);
            Response.Write(JSONHelper.ToJson(ret));
        }

    }

    /// <summary>  
    /// 时间戳Timestamp转换成日期  
    /// </summary>  
    /// <param name="timeStamp"></param>  
    /// <returns></returns>  
    private DateTime GetDateTime(string timeStamp)
    {
        DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
        long lTime = long.Parse(timeStamp + "0000000");
        TimeSpan toNow = new TimeSpan(lTime);
        DateTime targetDt = dtStart.Add(toNow);
        return dtStart.Add(toNow);
    }
}