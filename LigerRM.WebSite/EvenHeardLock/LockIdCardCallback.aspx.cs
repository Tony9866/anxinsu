using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using LigerRM.Common;
using SignetInternet_BusinessLayer;
using System.Data;

public partial class EvenHeardLock_LockIdCardCallback : System.Web.UI.Page
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
            FileStream fs = new FileStream(Server.MapPath("~") + "\\EvenHeardLock\\LockIdCardCallbackLog.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(DateTime.Now.ToString() + "接收到参数" + postContent);
            try
            {
                //string postContent = "{\"res\":[{\"ret\":\"true\",\"StartDate\":\"1521511200\",\"EndDate\":\"1521514800\",\"uuid\":\"120d100229d80c34\",\"userId\":\"13821872153\"}]}";
                Dictionary<string, IdCardCallBack[]> retCallBack = JSONHelper.FromJson<Dictionary<string, IdCardCallBack[]>>(postContent);
                foreach (IdCardCallBack b in retCallBack["res"])
                {
                    sql = "select * from v_RentICCard_view where UserId='" + b.userId + "'and StartDate='" + GetDateTime(b.StartDate) + "' and EndDate='" + GetDateTime(b.EndDate) + "'";
                    DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        sql = "update Rent_Locks_ICCards set ICCard='" + b.uuid + "' where ID='" + dt.Rows[0]["ID"].ToString() + "'";
                        MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                    }
                    else
                    {
                        statucode = "201";
                        reason = "暂无ICCard信息";
                    }
                }
            }
            catch (Exception ex)
            {
                statucode = "201";
                reason = ex.Message;
            }
            sw.WriteLine(DateTime.Now.ToString() + "数据返回：" + reason);
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