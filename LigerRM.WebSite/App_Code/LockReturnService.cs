using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;
using LigerRM.Common;
using SignetInternet_BusinessLayer;
using System.Data;

/// <summary>
/// Summary description for LockReturnService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class LockReturnService : System.Web.Services.WebService {

    public LockReturnService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string GetLockReturnInfo(string info,string status,string index,string lockerid,string cardid,string type,string time) {

        string statucode = "0";
        string reason = "";
        FileStream fs = new FileStream(Server.MapPath("~") + "\\BaseManage\\Log.txt", FileMode.Append);
        StreamWriter sw = new StreamWriter(fs);
        sw.WriteLine(DateTime.Now.ToString() + " info:" + info + " status:" + status + " index:" +index+" lockerid:"+lockerid+" cardid:"+cardid+" type:"+type+" time:"+time);
        try
        {
            //0-刷卡开门，
            //1-添加刷卡卡号
            //2-删除刷卡卡号  
            //3-通过手机APP方式添加身份证UID，
            //4-通过手机APP删除身份证UID，
            //5-卡号过期，自动删除

            string sql = "insert into Rent_Locks_ReturnLog values ('"+Guid.NewGuid().ToString()+"','"+index+"','"+lockerid+"','"+cardid+"','"+type+"','"+time+"','"+DateTime.Now.ToString()+"','"+GetTypeDesc(type,cardid)+"','')";
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));

            if (type == "3") //添加身份证编号到表内
            {
                Dictionary<string, string> ret = new Dictionary<string, string>();

                sql = "select * from v_RentHistory_view where DeviceID='" + lockerid + "' and RRAStartDate<='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' and RRAEndDate>'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' and RRAStatus='2'";
                DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    LockManager manager = new LockManager();
                    manager.AddICCard(lockerid, cardid, dt.Rows[0]["RRAStartDate"].ToString(), dt.Rows[0]["RRAEndDate"].ToString());
                }
            }

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

        Dictionary<string, string> ret1 = new Dictionary<string, string>();
        ret1.Add("resutcode", statucode);
        ret1.Add("reason", reason);
        return JSONHelper.ToJson(ret1);
    }


    private string GetTypeDesc(string type,string cardId)
    {
        //0-刷卡开门，
        //1-添加刷卡卡号
        //2-删除刷卡卡号  
        //3-通过手机APP方式添加身份证UID，
        //4-通过手机APP删除身份证UID，
        //5-卡号过期，自动删除
        string returnStr = string.Empty;
        switch (type)
        { 
            case "0":
                if (cardId.Length<=6)
                    returnStr = "密码开门";
                else
                    returnStr = "刷卡开门";
                break;
            case "1":
                if (cardId.Length<=6)
                    returnStr = "添加密码";
                else
                    returnStr = "添加卡号";
                break;
            case "2":
                if (cardId.Length<=6)
                    returnStr = "删除密码";
                else
                    returnStr = "删除卡号";
                break;
            case "3":
                returnStr = "添加身份证";
                break;
            case "4":
                returnStr = "删除身份证";
                break;
            case "5":
                if (cardId.Length<=6)
                    returnStr = "密码过期";
                else
                    returnStr = "卡号过期";
                break;
        }
        return returnStr;
    }
}
