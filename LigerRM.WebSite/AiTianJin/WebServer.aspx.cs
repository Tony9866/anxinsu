using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LigerRM.Common;
using System.Text;
using SignetInternet_BusinessLayer;
using System.Data;

public partial class AiTianJin_WebServer : System.Web.UI.Page
{
    protected string Action = "";
    protected string token = "c9f0f895fb98ab9159f51fd0297e236d";  //请求令牌
    protected string userInfo = "http://60.28.26.20:81/Api/Free/userInfo";  //用户认证信息查询
    protected string spideInfo = "http://60.28.26.20:81/Api/Free/spiderInfo";  //探针记录查询接口
    protected string userWechat = "http://60.28.26.20:81/Api/Free/userWechat";  //用户微信信息查询
    protected string userAdInfo = "http://60.28.26.20:81/Api/Free/userAdInfo";  //页面广告浏览记录
    protected string wifiStatic = "http://60.28.26.20:81/Api/Free/wifiStatic";  //wifi设备WiFi连网记录
    protected string authStatic = "http://60.28.26.20:81/Api/Free/authStatic";  //wifi设备认证记录
    protected string passStatic = "http://60.28.26.20:81/Api/Free/passStatic";  //认证放行记录

    protected void Page_Load(object sender, EventArgs e)
    {
        getUserLogin();
    }

    /// <summary>    
    /// 获取时间戳    
    /// </summary>  
    public static string GetTimeStamp()
    {
        return "1512970226";
        //TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
        //return Convert.ToInt64(ts.TotalSeconds).ToString();
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

    // DateTime时间格式转换为Unix时间戳格式(往后减少一分钟)
    private int DateTimeToStamp(System.DateTime time)
    {
        System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
        return (int)(time.AddSeconds(-3600) - startTime).TotalSeconds;//往后减少59秒
    }

    public void getUserLogin()
    {
        try
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Action"]))
            {
                Action = Request.QueryString["Action"].Trim().ToLower();
            }

            switch (Action)
            {
                case "login":
                    //int loginTime = DateTimeToStamp(System.DateTime.Now);  //获取当前时间
                    int loginTime = DateTimeToStamp(GetDateTime("1512970226"));  //获取当前时间
                    //查询从数据库查询数据
                    string sqlSelect = "select Top 1 * from Wifi_User_Info ORDER BY created_time desc";
                    DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sqlSelect)).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        //有数据源，讯选择第一条数据时间进行查询
                        string dateSelectTime = dt.Rows[0]["created_time"].ToString();
                        loginTime = DateTimeToStamp(Convert.ToDateTime(dateSelectTime));
                    }
                    Response.Write("时间：" + loginTime + "<br/>");
                    Dictionary<string, string> userKv = new Dictionary<string, string>();
                    userKv.Add("shop_id", "8");
                    Response.Write("token：" + (token + loginTime) + "<br/>");
                    Response.Write("md5加密：" + LigerRM.Common.Global.Encryp.MD5(token + loginTime.ToString()) + "<br/>");
                    userKv.Add("token", LigerRM.Common.Global.Encryp.MD5(token + loginTime.ToString()));
                    userKv.Add("start_time", loginTime.ToString());
                    userKv.Add("period", "0");
                    Response.Write("json：" + (JSONHelper.ToJson(userKv)) + "<br/>");
                    string baseJson = Convert.ToBase64String(Encoding.UTF8.GetBytes(JSONHelper.ToJson(userKv)));
                    Response.Write("json加密：" + baseJson + "<br/>");
                    string retStr = LigerRM.Common.WebRequestHelper.WebRequestPoster.JsonHttpPost(userInfo, baseJson, "parameters");
                    Dictionary<string, object> ret = new Dictionary<string, object>();
                    ret = JSONHelper.FromJson<Dictionary<string, object>>(retStr);
                    if (ret["returnCode"].ToString() == "0" && ret["returnMessage"].ToString() == "success")
                    {
                        System.Collections.ArrayList returnDataList = new System.Collections.ArrayList();
                        returnDataList = ret["returnData"] as System.Collections.ArrayList;
                        foreach (Dictionary<string, object> returnData in returnDataList)
                        {
                            string sql = "Insert into Wifi_User_Info values ('" + Guid.NewGuid().ToString() + "','" + returnData["name"] + "','" + returnData["member_mac"] + "','" + returnData["allow_type"] + "','" + returnData["connect_type"] + "','" + GetDateTime(returnData["add_time"].ToString()) + "','" + GetDateTime(returnData["update_time"].ToString()) + "','" + returnData["is_online"] + "','" + DateTime.Now.ToString() + "')";
                            int result = MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                        }
                    }
                    Response.Write("结果：" + retStr);
                    break;

                case "spideinfo":
                    int spideTime = DateTimeToStamp(System.DateTime.Now);  //获取当前时间
                    //查询从数据库查询数据
                    string sqlSpide = "select Top 1 * from Wifi_Spider_Info ORDER BY created_time desc";
                    DataTable dtSpide = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sqlSpide)).Tables[0];
                    if (dtSpide.Rows.Count > 0)
                    {
                        //有数据源，讯选择第一条数据时间进行查询
                        string dateSelectTime = dtSpide.Rows[0]["created_time"].ToString();
                        loginTime = DateTimeToStamp(Convert.ToDateTime(dateSelectTime));
                    }
                    Dictionary<string, string> spideKV = new Dictionary<string, string>();
                    spideKV.Add("shop_id", "8");
                    spideKV.Add("token", LigerRM.Common.Global.Encryp.MD5(token + spideTime.ToString()));
                    spideKV.Add("start_time", spideTime.ToString());
                    spideKV.Add("period", "2");
                    string baseSpideJson = Convert.ToBase64String(Encoding.UTF8.GetBytes(JSONHelper.ToJson(spideKV)));
                    string retSpideStr = LigerRM.Common.WebRequestHelper.WebRequestPoster.JsonHttpPost(spideInfo, baseSpideJson, "parameters");
                    Dictionary<string, object> retSpide = new Dictionary<string, object>();
                    retSpide = JSONHelper.FromJson<Dictionary<string, object>>(retSpideStr);
                    if (retSpide["returnCode"].ToString() == "0" && retSpide["returnMessage"].ToString() == "success")
                    {
                        System.Collections.ArrayList returnDataList = new System.Collections.ArrayList();
                        returnDataList = retSpide["returnData"] as System.Collections.ArrayList;
                        foreach (Dictionary<string, object> returnData in returnDataList)
                        {
                            string sql = "Insert into Wifi_Spider_Info values ('" + Guid.NewGuid().ToString() + "','" + returnData["m_mac"] + "','" + returnData["ap_mac"] + "','" + GetDateTime(returnData["add_time"].ToString()) + "','" + GetDateTime(returnData["leave_time"].ToString()) + "','" + DateTime.Now.ToString() + "')";
                            int result = MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                        }
                    }
                    Response.Write("结果：" + retSpideStr);
                    break;

                case "userwechat":
                    string mac = Request.Form["mac"];
                    if (string.IsNullOrEmpty(mac))
                    {
                        Response.Write("请输入mac地址！");
                        break;
                    }
                    string userWechatTime = GetTimeStamp();
                    Dictionary<string, string> userWechatKV = new Dictionary<string, string>();
                    userWechatKV.Add("shop_id", "8");
                    userWechatKV.Add("token", LigerRM.Common.Global.Encryp.MD5(token));
                    userWechatKV.Add("mac", mac);
                    string userWechatJson = Convert.ToBase64String(Encoding.UTF8.GetBytes(JSONHelper.ToJson(userWechatKV)));
                    string userWechatStr = LigerRM.Common.WebRequestHelper.WebRequestPoster.JsonHttpPost(userWechat, userWechatJson, "parameters");
                    Dictionary<string, object> retUserWechat = new Dictionary<string, object>();
                    retUserWechat = JSONHelper.FromJson<Dictionary<string, object>>(userWechatStr);
                    if (retUserWechat["returnCode"].ToString() == "0" && retUserWechat["returnMessage"].ToString() == "success")
                    {
                        if (retUserWechat["returnData"] != null)
                        {
                            System.Collections.ArrayList returnDataList = new System.Collections.ArrayList();
                            returnDataList = retUserWechat["returnData"] as System.Collections.ArrayList;
                            foreach (Dictionary<string, object> returnData in returnDataList)
                            {
                                string sql = "Insert into Wifi_User_Wechat values ('" + returnData["member_mac"] + "','" + returnData["openid"] + "','" + returnData["subscribe"] + "','" + returnData["nickname"] + "','" + returnData["sex"] + "','" + returnData["city"] + "','" + returnData["country"] + "','" + returnData["province"] + "','" + returnData["headimgurl"] + "','" + GetDateTime(returnData["add_time"].ToString()) + "','" + GetDateTime(returnData["subscribe_time"].ToString()) + "')";
                                int result = MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                            }
                        }
                    }
                    Response.Write("结果：" + userWechatStr);
                    break;
                case "useradinfo":
                    string userAdMac = Request.Form["mac"];
                    if (string.IsNullOrEmpty(userAdMac))
                    {
                        Response.Write("请输入mac地址！");
                        break;
                    }
                    //int userAdTime = DateTimeToStamp(System.DateTime.Now);  //获取当前时间
                    ////查询从数据库查询数据
                    //string sqlUserAd = "select Top 1 * from Wifi_Spider_Info where ORDER BY created_time desc";
                    //DataTable dtUserAd = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sqlUserAd)).Tables[0];
                    //if (dtUserAd.Rows.Count > 0)
                    //{
                    //    //有数据源，讯选择第一条数据时间进行查询
                    //    string dateSelectTime = dtUserAd.Rows[0]["created_time"].ToString();
                    //    loginTime = DateTimeToStamp(Convert.ToDateTime(dateSelectTime));
                    //}
                    string userAdTime = GetTimeStamp();
                    Dictionary<string, string> userAdKV = new Dictionary<string, string>();
                    userAdKV.Add("shop_id", "8");
                    userAdKV.Add("token", LigerRM.Common.Global.Encryp.MD5(token + userAdTime));
                    userAdKV.Add("mac", userAdMac);
                    userAdKV.Add("start_time", userAdTime);
                    userAdKV.Add("period", "0");
                    string userAdJson = Convert.ToBase64String(Encoding.UTF8.GetBytes(JSONHelper.ToJson(userAdKV)));
                    string userAdStr = LigerRM.Common.WebRequestHelper.WebRequestPoster.JsonHttpPost(userAdInfo, userAdJson, "parameters");
                    Dictionary<string, object> retUserAd = new Dictionary<string, object>();
                    retUserAd = JSONHelper.FromJson<Dictionary<string, object>>(userAdStr);
                    if (retUserAd["returnCode"].ToString() == "0" && retUserAd["returnMessage"].ToString() == "success")
                    {
                        System.Collections.ArrayList returnDataList = new System.Collections.ArrayList();
                        returnDataList = retUserAd["returnData"] as System.Collections.ArrayList;
                        foreach (Dictionary<string, object> returnData in returnDataList)
                        {
                            string sql = "Insert into Wifi_UserAd_Info values ('" + returnData["type"] + "','" + GetDateTime(returnData["add_time"].ToString()) + "','" + returnData["UA"] + "','" + returnData["page_type"] + "')";
                            int result = MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                        }
                    }
                    Response.Write("结果：" + userAdStr);
                    break;

                case "wifistatic":
                    string wifiStaticMac = Request.Form["mac"];
                    if (string.IsNullOrEmpty(wifiStaticMac))
                    {
                        Response.Write("请输入mac地址！");
                        break;
                    }
                    int wifiStaticTime = DateTimeToStamp(System.DateTime.Now);  //获取当前时间
                    //查询从数据库查询数据
                    string sqlWifiStatic = "select Top 1 * from Wifi_Static where ac_mac=" + wifiStaticMac + " ORDER BY created_time desc";
                    DataTable dtWifiStatic = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sqlWifiStatic)).Tables[0];
                    if (dtWifiStatic.Rows.Count > 0)
                    {
                        //有数据源，讯选择第一条数据时间进行查询
                        string dateSelectTime = dtWifiStatic.Rows[0]["created_time"].ToString();
                        loginTime = DateTimeToStamp(Convert.ToDateTime(dateSelectTime));
                    }
                    Dictionary<string, string> wifiStaticKV = new Dictionary<string, string>();
                    wifiStaticKV.Add("shop_id", "8");
                    wifiStaticKV.Add("token", LigerRM.Common.Global.Encryp.MD5(token + wifiStaticTime.ToString()));
                    wifiStaticKV.Add("mac", wifiStaticMac);
                    wifiStaticKV.Add("start_time", wifiStaticTime.ToString());
                    wifiStaticKV.Add("period", "0");
                    string wifiStaticJson = Convert.ToBase64String(Encoding.UTF8.GetBytes(JSONHelper.ToJson(wifiStaticKV)));
                    string wifiStaticStr = LigerRM.Common.WebRequestHelper.WebRequestPoster.JsonHttpPost(wifiStatic, wifiStaticJson, "parameters");
                    Dictionary<string, object> retWifiStatic = new Dictionary<string, object>();
                    retWifiStatic = JSONHelper.FromJson<Dictionary<string, object>>(wifiStaticStr);
                    if (retWifiStatic["returnCode"].ToString() == "0" && retWifiStatic["returnMessage"].ToString() == "success")
                    {
                        System.Collections.ArrayList returnDataList = new System.Collections.ArrayList();
                        returnDataList = retWifiStatic["returnData"] as System.Collections.ArrayList;
                        foreach (Dictionary<string, object> returnData in returnDataList)
                        {
                            string sql = "Insert into Wifi_Static values ('" + returnData["ap_mac"] + "','" + returnData["ac_mac"] + "','" + returnData["ssid"] + "','" + GetDateTime(returnData["join_time"].ToString()) + "','" + GetDateTime(returnData["leave_time"].ToString()) + "','" + returnData["service_id"] + "')";
                            int result = MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                        }
                    }
                    Response.Write("结果：" + wifiStaticStr);
                    break;

                case "authstatic":
                    string authStaticMac = Request.Form["mac"];
                    if (string.IsNullOrEmpty(authStaticMac))
                    {
                        Response.Write("请输入mac地址！");
                        break;
                    }
                    string authStaticTime = GetTimeStamp();
                    Dictionary<string, string> authStaticKV = new Dictionary<string, string>();
                    authStaticKV.Add("shop_id", "8");
                    authStaticKV.Add("token", LigerRM.Common.Global.Encryp.MD5(token + authStaticTime));
                    authStaticKV.Add("mac", authStaticMac);
                    authStaticKV.Add("start_time", authStaticTime);
                    authStaticKV.Add("period", "2");
                    string authStaticJson = Convert.ToBase64String(Encoding.UTF8.GetBytes(JSONHelper.ToJson(authStaticKV)));
                    string authStaticStr = LigerRM.Common.WebRequestHelper.WebRequestPoster.JsonHttpPost(authStatic, authStaticJson, "parameters");
                    Dictionary<string, object> retAuthStatic = new Dictionary<string, object>();
                    retAuthStatic = JSONHelper.FromJson<Dictionary<string, object>>(authStaticStr);
                    if (retAuthStatic["returnCode"].ToString() == "0" && retAuthStatic["returnMessage"].ToString() == "success")
                    {
                        System.Collections.ArrayList returnDataList = new System.Collections.ArrayList();
                        returnDataList = retAuthStatic["returnData"] as System.Collections.ArrayList;
                        foreach (Dictionary<string, object> returnData in returnDataList)
                        {
                            string sql = "Insert into Wifi_Auth_Static values ('" + returnData["service_id"] + "','" + returnData["connect_type"] + "','" + returnData["allow_type"] + "','" + returnData["user_name"] + "','" + GetDateTime(returnData["sta_time"].ToString()) + "')";
                            int result = MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                        }
                    }
                    Response.Write("结果：" + authStaticStr);
                    break;

                case "passstatic":
                    string passStaticMac = Request.Form["mac"];
                    if (string.IsNullOrEmpty(passStaticMac))
                    {
                        Response.Write("请输入mac地址！");
                        break;
                    }
                    string passStaticTime = GetTimeStamp();
                    Dictionary<string, string> passStaticKV = new Dictionary<string, string>();
                    passStaticKV.Add("shop_id", "8");
                    passStaticKV.Add("token", LigerRM.Common.Global.Encryp.MD5(token + passStaticTime));
                    passStaticKV.Add("mac", passStaticMac);
                    passStaticKV.Add("start_time", passStaticTime);
                    passStaticKV.Add("period", "2");
                    string passStaticJson = Convert.ToBase64String(Encoding.UTF8.GetBytes(JSONHelper.ToJson(passStaticKV)));
                    string passStaticStr = LigerRM.Common.WebRequestHelper.WebRequestPoster.JsonHttpPost(passStatic, passStaticJson, "parameters");
                    Dictionary<string, object> retPassStatic = new Dictionary<string, object>();
                    retPassStatic = JSONHelper.FromJson<Dictionary<string, object>>(passStaticStr);
                    if (retPassStatic["returnCode"].ToString() == "0" && retPassStatic["returnMessage"].ToString() == "success")
                    {
                        if (!string.IsNullOrEmpty(retPassStatic["returnData"].ToString()))
                        {
                            System.Collections.ArrayList returnDataList = new System.Collections.ArrayList();
                            returnDataList = retPassStatic["returnData"] as System.Collections.ArrayList;
                            foreach (Dictionary<string, object> returnData in returnDataList)
                            {
                                string sql = "Insert into Wifi_Pass_Static values ('" + returnData["ap_mac"] + "','" + GetDateTime(returnData["auth_time"].ToString()) + "','" + GetDateTime(returnData["leave_time"].ToString()) + "','" + returnData["pass_time"] + "','" + returnData["connect_type"] + "','" + returnData["allow_type"] + "','" + returnData["stayed_time"] + "','" + returnData["user_name"] + "')";
                                int result = MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                            }
                        }
                    }
                    Response.Write("结果：" + passStaticStr);
                    break;
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}