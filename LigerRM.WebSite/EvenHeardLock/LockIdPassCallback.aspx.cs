using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LigerRM.Common;
using SignetInternet_BusinessLayer;
using System.IO;
using System.Data;

public partial class EvenHeardLock_LockIdPassCallback : System.Web.UI.Page
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
            ////打印
            FileStream fs = new FileStream(Server.MapPath("~") + "\\EvenHeardLock\\LockIdPassCallbackLog.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(DateTime.Now.ToString() + "接收到参数" + postContent);
            try
            {
                //string postContent = "{\"res\":[{\"ret\":\"true\",\"StartDate\":\"1520920855\",\"EndDate\":\"1520920855\",\"pwd\":\"888888\",\"userId\":\"17702285600\"}]}";
                Dictionary<string, PassCallBack[]> retCallBack = JSONHelper.FromJson<Dictionary<string, PassCallBack[]>>(postContent);
                foreach (PassCallBack b in retCallBack["res"])
                {
                    sql = "select * from v_RentPass_view where UserId='" + b.userId + "'and StartDate='" + GetDateTime(b.StartDate) + "' and EndDate='" + GetDateTime(b.EndDate) + "' and Password='"+ b.pwd +"'";
                    DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        sql = "update Rent_lock_User_Password set IsAdd='" + b.ret + "' where PassId='" + dt.Rows[0]["ID"].ToString() + "'";
                        MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                    }
                    else
                    {
                        statucode = "201";
                        reason = "暂无密码信息";
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