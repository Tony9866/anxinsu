using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LigerRM.Common;
using SignetInternet_BusinessLayer;
using System.Data;
using System.IO;

public partial class EvenHeardLock_DelPassICCardCallback : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string postContent = Request.Params["parameters"];
            Dictionary<string, string> ret = new Dictionary<string, string>();
            string sql = string.Empty;
            string tableIUP = string.Empty;
            string table = string.Empty;
            string filed = string.Empty;
            string filedType = string.Empty;
            string statucode = "000";
            string reason = "request success";
            //////打印
            FileStream fs = new FileStream(Server.MapPath("~") + "\\EvenHeardLock\\LockDelCallbackLog.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(DateTime.Now.ToString() + "接收到参数" + postContent);
            try
            {
                //postContent = "{\"res\":[{\"ret\":\"true\",\"StartDate\":\"\",\"EndDate\":\"\",\"uuid\":\"-34b634a4\",\"userId\":\"11111\"}]}";
                Dictionary<string, DelReturn[]> retCallBack = JSONHelper.FromJson<Dictionary<string, DelReturn[]>>(postContent);
                foreach (DelReturn b in retCallBack["res"])
                {
                    if (b.lockType == "1")  //密码
                    {
                        tableIUP = "v_RentPass_view";
                        filed = "Password";
                        table = "Rent_Locks_Password";
                    }
                    else //卡片
                    {
                        tableIUP = "v_RentICCard_view";
                        filed = "ICCard";
                        table = "Rent_Locks_ICCards";
                    }
                    sql = "select * from " + tableIUP + " where UserId='" + b.userId + "'and StartDate='" + GetDateTime(b.StartDate) + "' and EndDate='" + GetDateTime(b.EndDate) + "' and " + filed + "='" + b.pwdICCard + "'";
                    DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        if (b.lockState == "1")  //  1  删除    2  冻结   3  解冻
                        {
                            filedType = "IsValid";
                        }
                        else
                        {
                            filedType = "Status";
                        }
                        sql = "update " + table + " set " + filedType + "='" + b.ret + "' where ID='" + dt.Rows[0]["ID"].ToString() + "'";
                        MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                    }
                    else
                    {
                        statucode = "201";
                        reason = "暂无录入信息";
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