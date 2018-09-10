using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LigerRM.Common;

namespace SignetInternet_BusinessLayer
{

    public class MotorHelper
    {
        private string LOGIN_URL = "http://219.150.56.148:8089/api/login";//"http://218.17.103.142:8094/api/login";
        private string PARK_URL = "http://219.150.56.148:8089/api/parklots";//"http://218.17.103.142:8094//api/parklots";
        private string IOLET_URL = "http://219.150.56.148:8089/api/iolets";//"http://218.17.103.142:8094//api/iolets";

        public bool LoginMotorPlatform()
        {
            string json = "{\"apid\":\"TJ_TIANTAJ_PS\",\"poa\":{\"uri\":\"http://10.10.108.1:8081/MotorManage/Motor_Notify_Url.aspx\", \"token\":\"TJ_TIANTAJ_PS\"}}";
            Dictionary<string, string> kv = new Dictionary<string, string>();
            kv.Add("ResourceId", "login");
            kv.Add("RequestId", "EBA1000S");
            string retStr = LigerRM.Common.WebRequestHelper.WebRequestPoster.PostJson(LOGIN_URL, json, kv);
            Dictionary<string, object> ret = JSONHelper.FromJson<Dictionary<string, object>>(retStr);
            if (ret["rsc"].ToString() == "200")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetPartInfos()
        {
            Dictionary<string, string> kv = new Dictionary<string, string>();
            kv.Add("ResourceId", "parklots");
            kv.Add("RequestId", "EBA1001S");
            //kv.Add("Host", "http://qxw2332340157.my3w.com");
            kv.Add("Token", "TJ_TIANTAJ_PS");
            string retStr = LigerRM.Common.WebRequestHelper.WebRequestPoster.GetJson(PARK_URL, kv);
            Dictionary<string, string> ret = new Dictionary<string, string>();
            ret = JSONHelper.FromJson<Dictionary<string, string>>(retStr);
            if (ret["rsc"].ToString() == "200")
            {
                string sql = "delete from Motor_BerthesInfo";
                MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                sql = "delete from Motor_ParkInfo";
                MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                Data[] partRet = JSONHelper.FromJson<Data[]>(ret["parklots"]);
                foreach (Data r in partRet)
                {
                    sql = "Insert into Motor_ParkInfo values ('" + r.id + "','" + r.name + "','" + DateTime.Now.ToString() + "','')";
                    MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));

                    foreach (berthes b in r.berthes)
                    {
                        sql = "Insert into Motor_BerthesInfo values ('" + b.id + "','" + b.number + "','" + r.id + "','','','0','" + DateTime.Now.ToString() + "','')";
                        MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                    }
                }
            }

            return retStr;
        }

        public string GetIOLetInfos()
        {
            Dictionary<string, string> kv = new Dictionary<string, string>();
            kv.Add("ResourceId", "iolets");
            kv.Add("RequestId", "EBA1001S");
            //kv.Add("Host", "http://qxw2332340157.my3w.com");
            kv.Add("Token", "TJ_TIANTAJ_PS");
            string retStr = LigerRM.Common.WebRequestHelper.WebRequestPoster.GetJson(IOLET_URL, kv);
            Dictionary<string, string> ret = new Dictionary<string, string>();

            ret = JSONHelper.FromJson<Dictionary<string, string>>(retStr);
            if (ret["rsc"].ToString() == "200")
            {
                string sql = "delete from Motor_IOLetInfo";
                MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                IOLets[] partRet = JSONHelper.FromJson<IOLets[]>(ret["iolets"]);
                foreach (IOLets io in partRet)
                {
                    sql = "Insert into Motor_IOLetInfo values ('" + io.id + "','" + io.name + "','" + io.parklot + "','" + DateTime.Now.ToString() + "','')";
                    MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                }
            }

            return retStr;
        }

    }

    public class Data
    {
        public string id { get; set; }
        public string name { get; set; }
        public berthes[] berthes { get; set; }
    }

    public class berthes
    {
        public string id { get; set; }
        public string number { get; set; }
    }

    public class IOLets
    {
        public string id { get; set; }
        public string name { get; set; }
        public string parklot { get; set; }
    }

    public class ParkEvent
    {
        public Loc loc { get; set; }
        public Whois whois { get; set; }
        public string status { get; set; }
        public string timestamp { get; set; }
    }

    public class Loc
    {
        public string parklot { get; set; }
        public string logicid { get; set; }
    }

    public class Whois
    {
        public string pln { get; set; }
        public string etag { get; set; }
    }

    public class BanEvent
    {
        public Loc loc { get; set; }
        public Whois whois { get; set; }
        public string status { get; set; }
        public string timestamp { get; set; }
    }
    //电表推送
    public class ElectricMeter
    {
        public string vipm_sn { get; set; }
        public string intraday_electricity { get; set; }
        public string electricity_electricity { get; set; }
        public string wipm_state { get; set; }
        public string current_power { get; set; }
        public string timeflag { get; set; }
        public string current_electricity { get; set; }
    }
    //用户认证信息查询
    public class UserInfo
    {
        public string name { get; set; }
        public string member_mac { get; set; }
        public int allow_type { get; set; }
        public int connect_type { get; set; }
        public string add_time { get; set; }
        public string update_time { get; set; }
        public string is_online { get; set; }
    }
    //探针记录查询接口
    public class SpiderInfo
    {
        public string m_mac { get; set; }
        public string ap_mac { get; set; }
        public string add_time { get; set; }
        public string leave_time { get; set; }
    }
    //用户微信信息查询
    public class UserWechat
    {
        public string member_mac { get; set; }
        public string openid { get; set; }
        public int subscribe { get; set; }
        public string nickname { get; set; }
        public string sex { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string province { get; set; }
        public string headimgurl { get; set; }
        public string add_time { get; set; }
        public string subscribe_time { get; set; }
    }
    //页面广告浏览记录
    public class UserAdInfo
    {
        public string mac { get; set; }
        public string add_time { get; set; }
        public string UA { get; set; }
        public string page_type { get; set; }
    }
    //wifi设备WiFi连网记录
    public class WifiStatic
    {
        public string ap_mac { get; set; }
        public string ac_mac { get; set; }
        public string ssid { get; set; }
        public string join_time { get; set; }
        public string leave_time { get; set; }
        public int service_id { get; set; }
    }
    //wifi设备认证记录
    public class AuthStatic
    {
        public int service_id { get; set; }
        public int connect_type { get; set; }
        public int allow_type { get; set; }
        public string user_name { get; set; }
        public string sta_time { get; set; }
    }
    //认证放行记录
    public class PassStatic
    {
        public string ap_mac { get; set; }
        public string auth_time { get; set; }
        public string leave_time { get; set; }
        public string pass_time { get; set; }
        public int connect_type { get; set; }
        public int allow_type { get; set; }
        public string stayed_time { get; set; }
        public string user_name { get; set; }
    }
    //idcard推送数据
    public class IdCardCallBack
    {
        public string userId { get; set; }
        public string ret { get; set; }
        public string uuid { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
    //密码推送数据
    public class PassCallBack
    {
        public string userId { get; set; }
        public string ret { get; set; }
        public string pwd { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
    //开锁返回来的推送数据
    public class LockReturnBak
    {
        public string openType { get; set; }
        public string userId { get; set; }
        public string pwd { get; set; }
        public string openTime { get; set; }
        public string devId { get; set; }
    }
    //绑锁后数据返回
    public class HomeLockReturn
    {
        public string devId { get; set; }
        public string ret { get; set; }
        public string msg { get; set; }
        public int type { get; set; }
    }

    //删除，冻结，解冻数据返回
    public class DelReturn
    {
        public string lockState { get; set; }   //  1  删除    2  冻结   3  解冻
        public string lockType { get; set; }   //  1  密码  2   卡片
        public string msg { get; set; }
        public string ret { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string userId { get; set; }
        public string pwdICCard { get; set; }
    }

}
