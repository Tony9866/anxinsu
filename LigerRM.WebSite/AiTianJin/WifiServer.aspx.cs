using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using LigerRM.Common;
using SignetInternet_BusinessLayer;

public partial class AiTianJin_WifiServer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            System.IO.Stream postData = Request.InputStream;
            //string postContent = Request.Params["json"];
            StreamReader sRead = new StreamReader(postData);
            string postContent = sRead.ReadToEnd();
            sRead.Close();
            Dictionary<string, string> retDic = new Dictionary<string, string>();
            string sql = string.Empty;
            string statucode = "0";
            string reason = "";
            FileStream fs = new FileStream(Server.MapPath("~") + "\\AiTianJin\\WifiLog.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("post请求参数：" + DateTime.Now.ToString() + " " + Request.Headers["ResourceType"] + " " + postContent);
            try
            {

                switch (Request.Headers["ResourceType"])
                {
                    case "userInfo": //用户认证信息查询
                        //postContent = "{\"res\":[{\"name\":\"15822043954\",\"member_mac\":\"38a4ed4ae147\",\"allow_type\":0,\"connect_type\":0,\"add_time\":\"2017-11-16T11:57:43+08:00\",\"update_time\":\"2017-11-16T11:57:43+08:00\",\"is_online\":\"no\"}]}";
                        //Response.Write(postContent);
                        Dictionary<string, UserInfo[]> ret1 = JSONHelper.FromJson<Dictionary<string, UserInfo[]>>(postContent);
                        //{
                        //    "name" : "15822043954",
                        //    "member_mac" : "38a4ed4ae147",
                        //    "allow_type" : 0,
                        //    "connect_type" : 0,
                        //    "add_time" : "2017-12-11 16:17:11",
                        //    "update_time" "2017-12-11 16:17:11",
                        //    "is_online" : "no"
                        //}
                        foreach (UserInfo b in ret1["res"])
                        {
                            sql = "Insert into Wifi_User_Info values ('" + Guid.NewGuid().ToString() + "','" + b.name + "','" + b.member_mac + "','" + b.allow_type + "','" + b.connect_type + "','" + DateTime.Parse(b.add_time).ToString() + "','" + DateTime.Parse(b.update_time).ToString() + "','" + b.is_online + "','" + DateTime.Now.ToString() + "')";
                            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                        }
                        break;
                    case "spiderInfo": //探针记录查询接口
                        //postContent = "{\"res\":[{\"m_mac\":\"8a11385bf649\",\"ap_mac\":\"d866ee1101e0\",\"add_time\":\"2017-11-16T11:57:43+08:00\",\"leave_time\":\"2017-11-16T11:57:43+08:00\"}]}";
                        //Response.Write(postContent);
                        Dictionary<string, SpiderInfo[]> ret2 = JSONHelper.FromJson<Dictionary<string, SpiderInfo[]>>(postContent);
                        //{
                        //    "m_mac" : "8a11385bf649",
                        //    "ap_mac" : "d866ee1101e0",
                        //    "add_time" : "2017-12-11 16:17:11",
                        //    "leave_time" "2017-12-11 16:17:11",
                        //}
                        foreach (SpiderInfo p in ret2["res"])
                        {
                            sql = "Insert into Wifi_Spider_Info values ('" + Guid.NewGuid().ToString() + "','" + p.m_mac + "','" + p.ap_mac + "','" + DateTime.Parse(p.add_time).ToString() + "','" + DateTime.Parse(p.leave_time).ToString() + "','" + DateTime.Now.ToString() + "')";
                            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                        }
                        break;
                    case "userWechat": //用户微信信息查询
                        //postContent = "{\"res\":[{\"member_mac\":\"8a11385bf649\",\"openid\":\"8a11385bf6498a11385bf6498a11385bf649\",\"subscribe\":1,\"nickname\":\"魏轩\",\"sex\":\"1\",\"city\":\"南开区\",\"country\":\"天津市\",\"province\":\"天津市\",\"headimgurl\":\"url\",\"add_time\":\"2017-11-16T11:57:43+08:00\",\"subscribe_time\":\"2017-11-16T11:57:43+08:00\"}]}";
                        //Response.Write(postContent);
                        Dictionary<string, UserWechat[]> ret3 = JSONHelper.FromJson<Dictionary<string, UserWechat[]>>(postContent);
                        //{
                        //    "member_mac" : "8a11385bf649",
                        //    "openid" : "8a11385bf6498a11385bf6498a11385bf649",
                        //    "subscribe" : 1,
                        //    "nickname" "魏轩",
                        //    "sex" : "1",
                        //    "city" : "南开区",
                        //    "country" "天津市",
                        //    "province" : "天津市",
                        //    "headimgurl" : "url",
                        //    "add_time" "2017-12-11 16:17:11",
                        //    "subscribe_time" : "2017-12-11 16:17:11",
                        //}
                        foreach (UserWechat w in ret3["res"])
                        {
                            sql = "Insert into Wifi_User_Wechat values ('" + Guid.NewGuid().ToString() + "','" + w.member_mac + "','" + w.openid + "','" + w.subscribe + "','" + w.nickname + "','" + w.sex + "','" + w.city + "','" + w.country + "','" + w.province + "','" + w.headimgurl + "','" + DateTime.Parse(w.add_time).ToString() + "','" + DateTime.Parse(w.subscribe_time).ToString() + "','" + DateTime.Now.ToString() + "')";
                            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                        }
                        break;
                    case "userAdInfo": //页面广告浏览记录
                        //postContent = "{\"res\":[{\"mac\":\"8a11385bf649\",\"add_time\":\"2017-11-16T11:57:43+08:00\",\"UA\":\"d866ee1101e0\",\"page_type\":\"m\"}]}";
                        //Response.Write(postContent);
                        Dictionary<string, UserAdInfo[]> ret4 = JSONHelper.FromJson<Dictionary<string, UserAdInfo[]>>(postContent);
                        //{
                        //    "mac" : "8a11385bf649",
                        //    "add_time" : "2017-12-11 16:17:11",
                        //    "UA" : "d866ee1101e0",
                        //    "page_type" "m",
                        //}
                        foreach (UserAdInfo a in ret4["res"])
                        {
                            sql = "Insert into Wifi_UserAd_Info values ('" + Guid.NewGuid().ToString() + "','" + a.mac + "','" + DateTime.Parse(a.add_time).ToString() + "','" + a.UA + "','" + a.page_type + "','" + DateTime.Now.ToString() + "')";
                            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                        }
                        break;
                    case "wifiStatic": //wifi设备WiFi连网记录
                        //postContent = "{\"res\":[{\"ap_mac\":\"d866ee1101e0\",\"ac_mac\":\"34cd41210080\",\"ssid\":\"i-Tianjin\",\"join_time\":\"2017-11-16T11:57:43+08:00\",\"leave_time\":\"2017-11-16T11:57:43+08:00\",\"service_id\":0}]}";
                        //Response.Write(postContent);
                        Dictionary<string, WifiStatic[]> ret5 = JSONHelper.FromJson<Dictionary<string, WifiStatic[]>>(postContent);
                        //{
                        //    "ap_mac" : "d866ee1101e0",
                        //    "ac_mac" : "34cd41210080",
                        //    "ssid" : "i-Tianjin",
                        //    "join_time" "2017-12-11 16:17:11",
                        //    "leave_time" : "2017-12-11 16:17:11",
                        //    "service_id" : "0",
                        //}
                        foreach (WifiStatic s in ret5["res"])
                        {
                            sql = "Insert into Wifi_Static values ('" + Guid.NewGuid().ToString() + "','" + s.ap_mac + "','" + s.ac_mac + "','" + s.ssid + "','" + DateTime.Parse(s.join_time).ToString() + "','" + DateTime.Parse(s.leave_time).ToString() + "','" + s.service_id + "','" + DateTime.Now.ToString() + "')";
                            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                        }
                        break;
                    case "authStatic": //wifi设备认证记录
                        //postContent = "{\"res\":[{\"service_id\":0,\"connect_type\":0,\"allow_type\":0,\"user_name\":\"13622103958\",\"sta_time\":\"2017-11-16T11:57:43+08:00\"}]}";
                        //Response.Write(postContent);
                        Dictionary<string, AuthStatic[]> ret6 = JSONHelper.FromJson<Dictionary<string, AuthStatic[]>>(postContent);
                        //{
                        //    "service_id" : 0,
                        //    "connect_type" : 0,
                        //    "allow_type" : 0,
                        //    "user_name" "13622103958",
                        //    "sta_time" : "2017-12-11 16:17:11",
                        //}
                        foreach (AuthStatic u in ret6["res"])
                        {
                            sql = "Insert into Wifi_Auth_Static values ('" + Guid.NewGuid().ToString() + "','" + u.service_id + "','" + u.connect_type + "','" + u.allow_type + "','" + u.user_name + "','" + DateTime.Parse(u.sta_time).ToString() + "','" + DateTime.Now.ToString() + "')";
                            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                        }
                        break;
                    case "passStatic": //认证放行记录
                        //postContent = "{\"res\":[{\"ap_mac\":\"d866ee1101e0\",\"auth_time\":\"2017-11-16T11:57:43+08:00\",\"leave_time\":\"2017-11-16T11:57:43+08:00\",\"pass_time\":\"14400\",\"connect_type\":0,\"allow_type\":0,\"stayed_time\":\"1492\",\"user_name\":\"13622103958\"}]}";
                        //Response.Write(postContent);
                        Dictionary<string, PassStatic[]> ret7 = JSONHelper.FromJson<Dictionary<string, PassStatic[]>>(postContent);
                        //{
                        //    "ap_mac" : "d866ee1101e0",
                        //    "auth_time" :  "2017-12-11 16:17:11",
                        //    "leave_time" :  "2017-12-11 16:17:11",
                        //    "pass_time" "14400",
                        //    "connect_type" : 0,
                        //    "allow_type" : 0,
                        //    "stayed_time" : "1492",
                        //    "user_name" "13622103958",
                        //}
                        foreach (PassStatic q in ret7["res"])
                        {
                            sql = "Insert into Wifi_Pass_Static values ('" + Guid.NewGuid().ToString() + "','" + q.ap_mac + "','" + DateTime.Parse(q.auth_time).ToString() + "','" + DateTime.Parse(q.leave_time).ToString() + "','" + q.pass_time + "','" + q.connect_type + "','" + q.allow_type + "','" + q.stayed_time + "','" + q.user_name + "','" + DateTime.Now.ToString() + "')";
                            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                        }
                        break;
                    default:
                        statucode = "201";
                        reason = "http request header false";
                        sw.WriteLine("返回结果：" + DateTime.Now.ToString() + " " + reason);
                        break;
                }
            }
            catch (Exception ex)
            {
                statucode = "201";
                reason = ex.Message;
                sw.WriteLine("结果返回：" + DateTime.Now.ToString() + " " + ex.Message);
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