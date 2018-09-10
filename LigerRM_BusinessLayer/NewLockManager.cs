using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using XGAPI;
using LigerRM.Common;
using XGAPI.Enums;
using System.IO;
using System.Threading;
using System.Collections;
using System.Text.RegularExpressions;

namespace SignetInternet_BusinessLayer
{
    public class NewLockManager
    {
        System.Timers.Timer t = new System.Timers.Timer(1000);//实例化Timer类，设置间隔时间为10000毫秒；
        System.Timers.Timer t1 = new System.Timers.Timer(1000);//实例化Timer类，设置间隔时间为10000毫秒；
        private string retStatus1 = string.Empty;
        private string retStatus = string.Empty;
        protected string appKey = "123";
        protected string appSecret = "LXS-123";
        protected string accountOpening = "17702285600";
        protected string setPwdTimeUrl = "https://smart.miitzc.com/tmall/setPwd";  //设置临时密码
        protected string setPwdUrl = "https://smart.miitzc.com/tmall/setPerPwd";  //设置永久密码
        protected string setCardUrl = "https://smart.miitzc.com/tmall/setPerCardPwd";  //设置永久卡密码
        protected string setCardTimeUrl = "https://smart.miitzc.com/tmall/setCardPwd";  //设置临时卡密码
        protected string delCardPass = "https://smart.miitzc.com/tmall/deletePwd";  //删除卡和密码
        protected string recoverPwdICCard = "https://smart.miitzc.com/tmall/recoverPwd";  //解冻卡，密码
        protected string openDoorUrl = "https://smart.miitzc.com/tmall/openLock"; //一键开锁
        protected string freezeLockUrl = "https://smart.miitzc.com/tmall/freezeLock";   //冻结锁
        protected string unfreezeLockUrl = "https://smart.miitzc.com/tmall/recoverLock";   //解冻锁 
        protected string createHomeUrl = "https://smart.miitzc.com/tmall/addFamily";   //创建家庭 
        protected string createGatewayUrl = "https://smart.miitzc.com/tmall/addGateway";   //创建网关
        protected string createAddLockUrl = "https://smart.miitzc.com/tmall/addLock";   //创建锁
        protected string deleteGatewayUrl = "https://smart.miitzc.com/tmall/delGateway";   //删除网关
        protected string forceDelGateUrl = "https://smart.miitzc.com/tmall/forceDelGate";   //强制删除网关 
        protected string deleteAddLockUrl = "https://smart.miitzc.com/tmall/delLock";   //删除锁
        protected string delFamilyUrl = "https://smart.miitzc.com/tmall/delFamily";   //删除家庭

        //请求远程接口  1 永久密码  2 临时密码  3 永久卡和永久身份证  4  临时卡和临时身份证
        //时间为时间格式   永久接口   时间都相同
        public string GetPostInterface(string familyName, string userId, string type, string pwd, string startTime, string endTime)
        {
            Dictionary<string, string> ret = new Dictionary<string, string>();
            //密码设置
            Dictionary<string, string> setRet = new Dictionary<string, string>();
            string getPostInfo = string.Empty;
            string sql = string.Empty;
            string table = string.Empty;
            string menu = string.Empty;
            string sqlPassIC = string.Empty;
            setRet.Add("appKey", appKey);
            setRet.Add("appSecret", appSecret);
            setRet.Add("familyName", familyName);
            setRet.Add("username", accountOpening);
            setRet.Add("userid", userId);
            setRet.Add("startTime", GetCreatetime(DateTime.Parse(startTime))); //获取时间戳
            setRet.Add("endTime", GetCreatetime(DateTime.Parse(endTime)));//获取时间戳
            //永久时间判断
            if (type == "1" || type == "3")
            {
                if (DateTime.Parse(startTime) != DateTime.Parse(endTime))
                {
                    ret.Add("ret", "1");
                    ret.Add("msg", "录入永久密码或卡片开始时间和结束时间需相同！");
                    return JSONHelper.ToJson(ret);
                }
            }

            //判断锁是否冻结（锁冻结不能录入）
            sql = "select * from Rent_Locks where DeviceID='" + familyName + "'";
            DataTable dtLock = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            if (dtLock.Rows[0]["Status"].ToString() == "3")
            {
                ret.Add("ret", "1");
                ret.Add("msg", "该锁已经被冻结，不能进行录入！");
                return JSONHelper.ToJson(ret);
            }
            switch (type)
            {
                case "1":  //永久密码
                    menu = "永久密码请求";
                    setRet.Add("pwd", pwd);
                    getPostInfo = LigerRM.Common.WebRequestHelper.WebRequestPoster.JsonHttpPost(setPwdUrl, JSONHelper.ToJson(setRet), "parameters");
                    sql = "insert into Rent_Locks_Password values ('" + familyName + "','" + pwd + "','" + startTime + "','" + endTime + "','0','1')SELECT SCOPE_IDENTITY() as ID";
                    break;
                case "2":  //临时密码
                    menu = "临时密码请求";
                    setRet.Add("pwd", pwd);
                    getPostInfo = LigerRM.Common.WebRequestHelper.WebRequestPoster.JsonHttpPost(setPwdTimeUrl, JSONHelper.ToJson(setRet), "parameters");
                    sql = "insert into Rent_Locks_Password values ('" + familyName + "','" + pwd + "','" + startTime + "','" + endTime + "','0','1')SELECT SCOPE_IDENTITY() as ID";
                    break;
                case "3": //永久卡和身份证
                    menu = "永久卡或身份证请求";
                    setRet.Add("cardId", pwd); //卡号和身份证
                    getPostInfo = LigerRM.Common.WebRequestHelper.WebRequestPoster.JsonHttpPost(setCardUrl, JSONHelper.ToJson(setRet), "parameters");
                    sql = "insert into Rent_Locks_ICCards values ('" + familyName + "','', '" + startTime + "','" + endTime + "','0','1')SELECT SCOPE_IDENTITY() as ID";
                    break;
                case "4": //临时卡和身份证
                    menu = "临时卡或身份证请求";
                    setRet.Add("cardId", pwd); //卡号和身份证
                    getPostInfo = LigerRM.Common.WebRequestHelper.WebRequestPoster.JsonHttpPost(setCardTimeUrl, JSONHelper.ToJson(setRet), "parameters");
                    sql = "insert into Rent_Locks_ICCards values ('" + familyName + "','', '" + startTime + "','" + endTime + "','0','1')SELECT SCOPE_IDENTITY() as ID";
                    break;
            }
            Dictionary<string, object> returnInfo = new Dictionary<string, object>();
            returnInfo = JSONHelper.FromJson<Dictionary<string, object>>(getPostInfo);
            if (returnInfo["success"].ToString() == "True")
            {
                //校验是否多次提交  (临时卡片多次校验)  永久不需要  时间时刻变化
                if (type == "4")
                {
                    string sqlUser = "select * from v_RentICCard_view where UserId='" + userId + "'and LockID='" + familyName + "' and StartDate='" + startTime + "' and EndDate='" + endTime + "'and IsValid='1' and Status='0'";
                    DataTable dt1 = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sqlUser)).Tables[0];
                    if (dt1.Rows.Count > 0)
                    {
                        ret.Add("ret", "0");
                        ret.Add("msg", returnInfo["msg"].ToString());
                        AddLockNewLog(familyName, menu, returnInfo["msg"].ToString());   //增加新锁的log请求返回日志
                        return JSONHelper.ToJson(ret);
                    }
                }
                //数据插入
                DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
                if (type == "1" || type == "2")
                {
                    table = "Rent_lock_User_Password";
                    sqlPassIC = "'" + Guid.NewGuid().ToString() + "','" + userId + "','" + dt.Rows[0]["ID"].ToString() + "', ''";
                }
                else
                {
                    table = "Rent_Lock_User_ICCards";
                    sqlPassIC = "'" + Guid.NewGuid().ToString() + "','" + userId + "','" + dt.Rows[0]["ID"].ToString() + "'";
                }
                sql = "insert into " + table + "  values (" + sqlPassIC + ")";
                MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));

                ret.Add("ret", "0");
                ret.Add("msg", returnInfo["msg"].ToString());
            }
            else
            {
                ret.Add("ret", "1");
                ret.Add("msg", returnInfo["msg"].ToString());
            }
            AddLockNewLog(familyName, menu, returnInfo["msg"].ToString());   //增加新锁的log请求返回日志
            return JSONHelper.ToJson(ret);
        }

        //删除卡、密码 
        //type   永久密码、临时密码、永久卡片、临时卡片
        //recoverDelType  1  删除   2  解冻    3 冻结
        //时间为时间格式
        public string delAction(string userId, string type, string startTime, string endTime, string lockId, string recoverDelType)
        {
            string url = string.Empty;
            string sqlSuffix = string.Empty;//确认数据后缀
            //string sqlDelSuffix = string.Empty; //删除，冻结，解冻后缀
            string operateType = string.Empty;
            if (recoverDelType == "1") //删除
            {
                url = delCardPass;
                sqlSuffix = "IsValid='1'";
                //sqlDelSuffix = "IsValid='0'";
                operateType = "删除";

            }
            else if (recoverDelType == "2")  //解冻
            {
                url = recoverPwdICCard;
                sqlSuffix = "Status='1'";
                //sqlDelSuffix = "Status='0'";
            }
            else //冻结
            {

                url = delCardPass;
                sqlSuffix = "Status='0'";
                //sqlDelSuffix = "Status='1'";
                operateType = "冻结";
            }
            Dictionary<string, string> ret = new Dictionary<string, string>();
            string ICCardPass = string.Empty;
            string tableUIP = string.Empty;
            string tableIP = string.Empty;
            string fieldIP = string.Empty;
            string firldICCardPass = string.Empty;
            string isExistence = string.Empty;
            string setICCardPass = string.Empty;
            string ID = string.Empty;
            if (type == "临时卡片" || type == "永久卡片")
            {
                tableUIP = "v_RentICCard_view";
                //tableIP = "Rent_Locks_ICCards";
                fieldIP = "ICCardId";
                firldICCardPass = "ICCard";
                setICCardPass = "cardId";
                isExistence = "ICCard";
            }
            else
            {
                tableUIP = "v_RentPass_view";
                //tableIP = "Rent_Locks_Password";
                fieldIP = "PassId";
                firldICCardPass = "Password";
                setICCardPass = "pwd";
                isExistence = "IsAdd";
            }
            //确定数据库ICCard或者临时密码
            string sqlUser = "select * from " + tableUIP + " where UserId='" + userId + "'and LockID='" + lockId + "' and StartDate='" + startTime + "' and EndDate='" + endTime + "' and " + sqlSuffix + "";
            DataTable dt1 = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sqlUser)).Tables[0];
            if (dt1.Rows.Count > 0)
            {
                if (recoverDelType != "1" && dt1.Rows[0]["IsValid"].ToString() == "0")
                {
                    ret.Add("ret", "1");
                    ret.Add("msg", "该密码已被删除，不能进行操作");
                    return JSONHelper.ToJson(ret);
                }
                if (string.Empty == dt1.Rows[0][isExistence].ToString().Trim())  // 判断密码和卡片是否被录入
                {
                    ret.Add("ret", "1");
                    ret.Add("msg", "该信息尚未被录入锁中，请重新添加！");
                    return JSONHelper.ToJson(ret);
                }
                ICCardPass = dt1.Rows[0][firldICCardPass].ToString().Trim();
                ID = dt1.Rows[0]["ID"].ToString().Trim();
            }
            if (string.Empty == ICCardPass)
            {
                ret.Add("ret", "0");
                ret.Add("msg", "暂无信息");
                return JSONHelper.ToJson(ret);
            }
            Dictionary<string, string> delRet = new Dictionary<string, string>();
            delRet.Add("appKey", appKey);
            delRet.Add("appSecret", appSecret);
            delRet.Add("userid", userId);
            delRet.Add("type", type);
            delRet.Add("startTime", GetCreatetime(DateTime.Parse(startTime)));
            delRet.Add("endTime", GetCreatetime(DateTime.Parse(endTime)));
            delRet.Add(setICCardPass, ICCardPass);
            if (recoverDelType != "2")
            {
                delRet.Add("operate", operateType);
            }
            string json = JSONHelper.ToJson(delRet);
            string getPostInfo = LigerRM.Common.WebRequestHelper.WebRequestPoster.JsonHttpPost(url, json, "parameters");  //调用远程
            Dictionary<string, object> returnInfo = new Dictionary<string, object>();
            returnInfo = JSONHelper.FromJson<Dictionary<string, object>>(getPostInfo);
            if (returnInfo["success"].ToString() == "True")
            {
                //修改数据库删除状态,冻结状态  IsValid  0  删除   1 不删除  Status 0 启用  1 禁用
                //string sqlDel = "update " + tableIP + " set " + sqlDelSuffix + " where ID=" + ID;
                //MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sqlDel));
                ret.Add("ret", "0");
                ret.Add("msg", returnInfo["msg"].ToString());
            }
            else
            {
                ret.Add("ret", "1");
                ret.Add("msg", returnInfo["msg"].ToString());
            }
            AddLockNewLog(lockId, type, returnInfo["msg"].ToString());   //增加新锁的log请求返回日志
            return JSONHelper.ToJson(ret);
        }

        //冻结锁和解冻锁   
        //type 0 冻结锁   1 解冻锁
        public string freezeAndUnfreezeLock(string familyName, string type)
        {
            Dictionary<string, string> ret = new Dictionary<string, string>();
            Dictionary<string, string> setRet = new Dictionary<string, string>();
            setRet.Add("appKey", appKey);
            setRet.Add("appSecret", appSecret);
            setRet.Add("familyName", familyName);
            setRet.Add("username", accountOpening);
            string url = string.Empty;
            string menu = string.Empty;
            string status = string.Empty;
            if (type == "1")
            {
                url = unfreezeLockUrl;
                menu = "解冻锁";
                status = "0";
            }
            else
            {
                url = freezeLockUrl;
                menu = "冻结锁";
                status = "3";
            }
            string getPostInfo = LigerRM.Common.WebRequestHelper.WebRequestPoster.JsonHttpPost(url, JSONHelper.ToJson(setRet), "parameters");  //调用远程
            Dictionary<string, object> returnInfo = new Dictionary<string, object>();
            returnInfo = JSONHelper.FromJson<Dictionary<string, object>>(getPostInfo);
            if (returnInfo["success"].ToString() == "True")
            {
                ret.Add("ret", "0");
                string sql = "update Rent_Locks set status='" + status + "' where DeviceID='" + familyName + "'";
                MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
            }
            else
            {
                ret.Add("ret", "1");
            }
            ret.Add("msg", returnInfo["msg"].ToString());
            AddLockNewLog(familyName, menu, returnInfo["msg"].ToString());   //增加新锁的log请求返回日志
            return JSONHelper.ToJson(ret);
        }

        //一键开锁
        public string openDoor(string familyName)
        {
            Dictionary<string, string> setRet = new Dictionary<string, string>();
            Dictionary<string, string> ret = new Dictionary<string, string>();
            setRet.Add("appKey", appKey);
            setRet.Add("appSecret", appSecret);
            setRet.Add("username", accountOpening);
            setRet.Add("familyName", familyName);
            string getPostInfo = LigerRM.Common.WebRequestHelper.WebRequestPoster.JsonHttpPost(openDoorUrl, JSONHelper.ToJson(setRet), "parameters");
            LogManager.WriteLog(getPostInfo);
            Dictionary<string, object> returnInfo = new Dictionary<string, object>();
            returnInfo = JSONHelper.FromJson<Dictionary<string, object>>(getPostInfo);
            if (returnInfo["success"].ToString() == "True")
            {
                ret.Add("ret", "0");
            }
            else
            {
                ret.Add("ret", "1");
            }
            ret.Add("msg", returnInfo["msg"].ToString());
            AddLockNewLog(familyName, "一键开锁", returnInfo["msg"].ToString());   //增加新锁的log请求返回日志
            return JSONHelper.ToJson(ret);
        }


        //一键开锁  SDK版本
        public string openDoorSDK(string familyName, string userId)
        {
            Dictionary<string, string> setRet = new Dictionary<string, string>();
            Dictionary<string, string> ret = new Dictionary<string, string>();
            setRet.Add("appKey", appKey);
            setRet.Add("appSecret", appSecret);
            setRet.Add("username", accountOpening);
            setRet.Add("familyName", familyName);
            string getPostInfo = LigerRM.Common.WebRequestHelper.WebRequestPoster.JsonHttpPost(openDoorUrl, JSONHelper.ToJson(setRet), "parameters");
            LogManager.WriteLog(getPostInfo);
            Dictionary<string, object> returnInfo = new Dictionary<string, object>();
            returnInfo = JSONHelper.FromJson<Dictionary<string, object>>(getPostInfo);
            if (returnInfo["success"].ToString() == "True")
            {
                ret.Add("ret", "0");
            }
            else
            {
                ret.Add("ret", "1");
            }
            ret.Add("msg", returnInfo["msg"].ToString());
            AddLockNewSDKLog(familyName, "一键开锁", returnInfo["msg"].ToString(), userId);   //增加新锁的log请求返回日志
            return JSONHelper.ToJson(ret);
        }

        //添加家庭
        public string createHomeInfo(string familyName)
        {
            Dictionary<string, string> setRet = new Dictionary<string, string>();
            Dictionary<string, string> ret = new Dictionary<string, string>();
            setRet.Add("appKey", appKey);
            setRet.Add("appSecret", appSecret);
            setRet.Add("username", accountOpening);
            setRet.Add("familyName", familyName);
            string getPostInfo = LigerRM.Common.WebRequestHelper.WebRequestPoster.JsonHttpPost(createHomeUrl, JSONHelper.ToJson(setRet), "parameters");
            LogManager.WriteLog("Get:" + getPostInfo);
            Dictionary<string, object> returnInfo = new Dictionary<string, object>();
            returnInfo = JSONHelper.FromJson<Dictionary<string, object>>(getPostInfo);
            if (returnInfo["success"].ToString() == "True")
            {
                ret.Add("ret", "0");
            }
            else
            {
                ret.Add("ret", "1");
            }
            ret.Add("msg", returnInfo["msg"].ToString());
            AddLockNewLog(familyName, "添加家庭", returnInfo["msg"].ToString());   //增加新锁的log请求返回日志
            return JSONHelper.ToJson(ret);
        }

        //添加网关
        //familyName   新锁ID
        public string createAddGateway(string gatewayId, string devKey, string familyName)
        {
            Dictionary<string, string> setRet = new Dictionary<string, string>();
            Dictionary<string, string> ret = new Dictionary<string, string>();
            setRet.Add("appKey", appKey);
            setRet.Add("appSecret", appSecret);
            setRet.Add("username", accountOpening);
            setRet.Add("gatewayId", gatewayId);
            setRet.Add("devKey", devKey);
            setRet.Add("familyName", getDeviceID(familyName, "DeviceID"));
            string getPostInfo = LigerRM.Common.WebRequestHelper.WebRequestPoster.JsonHttpPost(createGatewayUrl, JSONHelper.ToJson(setRet), "parameters");
            Dictionary<string, object> returnInfo = new Dictionary<string, object>();
            returnInfo = JSONHelper.FromJson<Dictionary<string, object>>(getPostInfo);
            if (returnInfo["success"].ToString() == "True")
            {
                ret.Add("ret", "0");
            }
            else
            {
                ret.Add("ret", "1");
            }
            ret.Add("msg", returnInfo["msg"].ToString());
            AddLockNewLog(getDeviceID(familyName, "DeviceID"), "添加网关请求", returnInfo["msg"].ToString());   //增加新锁的log请求返回日志
            return JSONHelper.ToJson(ret);
        }

        //删除网关
        //familyName   新锁ID
        public string deleteGateway(string familyName)
        {
            Dictionary<string, string> setRet = new Dictionary<string, string>();
            Dictionary<string, string> ret = new Dictionary<string, string>();
            setRet.Add("appKey", appKey);
            setRet.Add("appSecret", appSecret);
            setRet.Add("username", accountOpening);
            setRet.Add("gatewayId", getDeviceID(familyName, "GatewayId"));
            setRet.Add("devKey", getDeviceID(familyName, "DevKey"));
            string getPostInfo = LigerRM.Common.WebRequestHelper.WebRequestPoster.JsonHttpPost(deleteGatewayUrl, JSONHelper.ToJson(setRet), "parameters");
            Dictionary<string, object> returnInfo = new Dictionary<string, object>();
            returnInfo = JSONHelper.FromJson<Dictionary<string, object>>(getPostInfo);
            if (returnInfo["success"].ToString() == "True")
            {
                ret.Add("ret", "0");
            }
            else
            {
                ret.Add("ret", "1");
            }
            ret.Add("msg", returnInfo["msg"].ToString());
            AddLockNewLog(getDeviceID(familyName, "DeviceID"), "删除网关请求", returnInfo["msg"].ToString());   //增加新锁的log请求返回日志
            return JSONHelper.ToJson(ret);
        }

        //强制删除网关
        //familyName   新锁Id
        public string forceDelGate(string familyName)
        {
            Dictionary<string, string> setRet = new Dictionary<string, string>();
            Dictionary<string, string> ret = new Dictionary<string, string>();
            setRet.Add("appKey", appKey);
            setRet.Add("appSecret", appSecret);
            setRet.Add("username", accountOpening);
            setRet.Add("gatewayId", getDeviceID(familyName, "GatewayId"));
            string getPostInfo = LigerRM.Common.WebRequestHelper.WebRequestPoster.JsonHttpPost(forceDelGateUrl, JSONHelper.ToJson(setRet), "parameters");
            Dictionary<string, object> returnInfo = new Dictionary<string, object>();
            returnInfo = JSONHelper.FromJson<Dictionary<string, object>>(getPostInfo);
            if (returnInfo["success"].ToString() == "True")
            {
                ret.Add("ret", "0");
            }
            else
            {
                ret.Add("ret", "1");
            }
            ret.Add("msg", returnInfo["msg"].ToString());
            AddLockNewLog(getDeviceID(familyName, "DeviceID"), "强制删除网关请求", returnInfo["msg"].ToString());   //增加新锁的log请求返回日志
            return JSONHelper.ToJson(ret);
        }

        //删除家庭
        //familyName   新锁Id 
        public string deleteFamily(string familyName)
        {
            Dictionary<string, string> setRet = new Dictionary<string, string>();
            Dictionary<string, string> ret = new Dictionary<string, string>();
            setRet.Add("appKey", appKey);
            setRet.Add("appSecret", appSecret);
            setRet.Add("username", accountOpening);
            setRet.Add("familyName", getDeviceID(familyName, "DeviceID"));
            string getPostInfo = LigerRM.Common.WebRequestHelper.WebRequestPoster.JsonHttpPost(delFamilyUrl, JSONHelper.ToJson(setRet), "parameters");
            Dictionary<string, object> returnInfo = new Dictionary<string, object>();
            returnInfo = JSONHelper.FromJson<Dictionary<string, object>>(getPostInfo);
            if (returnInfo["success"].ToString() == "True")
            {
                ret.Add("ret", "0");
            }
            else
            {
                ret.Add("ret", "1");
            }
            ret.Add("msg", returnInfo["msg"].ToString());
            AddLockNewLog(getDeviceID(familyName, "DeviceID"), "删除家庭", returnInfo["msg"].ToString());   //增加新锁的log请求返回日志
            return JSONHelper.ToJson(ret);
        }

        //添加锁
        //familyName   新锁ID
        public string createAddLock(string gatewayId, string familyName)
        {
            Dictionary<string, string> setRet = new Dictionary<string, string>();
            Dictionary<string, string> ret = new Dictionary<string, string>();
            setRet.Add("appKey", appKey);
            setRet.Add("appSecret", appSecret);
            setRet.Add("username", accountOpening);
            setRet.Add("gatewayId", gatewayId);
            string getPostInfo = LigerRM.Common.WebRequestHelper.WebRequestPoster.JsonHttpPost(createAddLockUrl, JSONHelper.ToJson(setRet), "parameters");
            Dictionary<string, object> returnInfo = new Dictionary<string, object>();
            returnInfo = JSONHelper.FromJson<Dictionary<string, object>>(getPostInfo);
            if (returnInfo["success"].ToString() == "True")
            {
                ret.Add("ret", "0");
            }
            else
            {
                ret.Add("ret", "1");
            }
            ret.Add("msg", returnInfo["msg"].ToString());
            AddLockNewLog(getDeviceID(familyName, "DeviceID"), "添加锁请求", returnInfo["msg"].ToString());   //增加新锁的log请求返回日志
            return JSONHelper.ToJson(ret);
        }


        //删除锁
        //familyName   新锁Id
        public string deleteAddLock(string familyName)
        {
            Dictionary<string, string> setRet = new Dictionary<string, string>();
            Dictionary<string, string> ret = new Dictionary<string, string>();
            setRet.Add("appKey", appKey);
            setRet.Add("appSecret", appSecret);
            setRet.Add("username", accountOpening);
            setRet.Add("gatewayId", getDeviceID(familyName, "GatewayId"));
            setRet.Add("pin", getDeviceID(familyName, "PinInfo"));
            string getPostInfo = LigerRM.Common.WebRequestHelper.WebRequestPoster.JsonHttpPost(deleteAddLockUrl, JSONHelper.ToJson(setRet), "parameters");
            Dictionary<string, object> returnInfo = new Dictionary<string, object>();
            returnInfo = JSONHelper.FromJson<Dictionary<string, object>>(getPostInfo);
            if (returnInfo["success"].ToString() == "True")
            {
                ret.Add("ret", "0");
            }
            else
            {
                ret.Add("ret", "1");
            }
            ret.Add("msg", returnInfo["msg"].ToString());
            AddLockNewLog(getDeviceID(familyName, "DeviceID"), "删除锁请求", returnInfo["msg"].ToString());   //增加新锁的log请求返回日志
            return JSONHelper.ToJson(ret);
        }

        //获取锁编号
        //newLockID   新的锁Id
        //type   输出字符串
        public string getDeviceID(string newLockID, string type)
        {
            string outInfo = string.Empty;
            string sql = "select * from Rent_NewLock_Process where NewLockID='" + newLockID + "'";
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0][type].ToString();
            }
            else
            {
                return "";
            }

        }

        //删除密码(后台使用)
        public string DeletePassword(string id)
        {
            Hashtable date = SelectDate(id, "0");
            return delAction(date["UserId"].ToString(), date["type"].ToString(), date["StartDate"].ToString(), date["EndDate"].ToString(), date["lockId"].ToString(), "1");
        }

        //禁用密码(后台使用)
        public string FreezePassword(string id)
        {
            Hashtable date = SelectDate(id, "0");
            return delAction(date["UserId"].ToString(), date["type"].ToString(), date["StartDate"].ToString(), date["EndDate"].ToString(), date["lockId"].ToString(), "3");
        }

        //启用密码(后台使用)
        public string UnFreezePassword(string id)
        {
            Hashtable date = SelectDate(id, "0");
            return delAction(date["UserId"].ToString(), date["type"].ToString(), date["StartDate"].ToString(), date["EndDate"].ToString(), date["lockId"].ToString(), "2");
        }

        //禁用ICCard(后台使用)
        public string FreezeICCard(string id)
        {
            Hashtable date = SelectDate(id, "1");
            return delAction(date["UserId"].ToString(), date["type"].ToString(), date["StartDate"].ToString(), date["EndDate"].ToString(), date["lockId"].ToString(), "3");
        }

        //启用ICCard(后台使用)
        public string UnFreezeICCard(string id)
        {
            Hashtable date = SelectDate(id, "1");
            return delAction(date["UserId"].ToString(), date["type"].ToString(), date["StartDate"].ToString(), date["EndDate"].ToString(), date["lockId"].ToString(), "2");
        }

        //删除卡片(后台使用)
        public string DeleteICCard(string id)
        {
            Hashtable date = SelectDate(id, "1");
            return delAction(date["UserId"].ToString(), date["type"].ToString(), date["StartDate"].ToString(), date["EndDate"].ToString(), date["lockId"].ToString(), "1");
        }

        //数据查询(后台使用)
        //modelType 0 密码   1 ICCard
        public Hashtable SelectDate(string id, string modelType)
        {
            var item = new Hashtable();
            string tableUIP = string.Empty;
            string permanentIP = string.Empty;
            string temporaryIP = string.Empty;
            string sql = string.Empty;
            if (modelType == "1")
            {
                tableUIP = "v_RentICCard_view";
                permanentIP = "永久卡片";
                temporaryIP = "临时卡片";
            }
            else
            {
                tableUIP = "v_RentPass_view";
                permanentIP = "永久密码";
                temporaryIP = "临时密码";
            }
            sql = "select * from " + tableUIP + " where ID=" + id;
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            if (dt.Rows[0]["StartDate"].ToString() == dt.Rows[0]["EndDate"].ToString())
            {
                item.Add("type", permanentIP);
            }
            else
            {
                item.Add("type", temporaryIP);
            }
            item.Add("lockId", dt.Rows[0]["LockID"].ToString().Trim());
            item.Add("StartDate", dt.Rows[0]["StartDate"].ToString());
            item.Add("EndDate", dt.Rows[0]["EndDate"].ToString());
            item.Add("UserId", dt.Rows[0]["UserId"].ToString().Trim());
            return item;
        }

        //增加锁的log日志
        public void AddLockNewLog(string deviceId, string action, string meno)
        {
            string id = Guid.NewGuid().ToString();
            string sql = "insert into Rent_Lock_Logs values ('" + id + "','" + deviceId + "','" + action + "','" + DateTime.Now.ToString() + "','" + meno + "')";
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
        }


        //增加一键开锁的log日志  SDK
        public void AddLockNewSDKLog(string deviceId, string action, string meno, string userId)
        {
            string id = Guid.NewGuid().ToString();
            string sql = "insert into Enterprise_OpenDoor_Log values ('" + id + "', '" + userId + "', '" + deviceId + "','" + meno + "','" + DateTime.Now.ToString() + "','','','','','" + action + "')";
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
        }

        /// <summary>  
        /// 时间戳Timestamp  
        /// </summary>  
        /// <returns></returns>  
        private string GetCreatetime(DateTime time)
        {
            DateTime DateStart = new DateTime(1970, 1, 1, 8, 0, 0);
            return ((time - DateStart).TotalSeconds).ToString();
        }

        /// <summary>  
        /// 时间戳Timestamp转换成日期  
        /// </summary>  
        /// <param name="timeStamp"></param>  
        /// <returns></returns>  
        public DateTime GetDateTime(string timeStamp)
        {
            //取出后尾3个js  ms的3个0   (只限js使用)
            string time = (Convert.ToInt64(timeStamp) / 1000).ToString();
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(time + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            DateTime targetDt = dtStart.Add(toNow);
            return dtStart.Add(toNow);
        }


        //企业对接检索   1 允许企业对接   2 不允许企业对接
        public string GetIsEnterprise(string userId)
        {
            string ret = string.Empty;
            string sql = "select * from Lock_Enterprise_Dock where UserId='" + userId + "'and EnterpriseStatus='1'";
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            if (dt.Rows.Count > 0)
            {
                ret = "1";
            }
            else
            {
                ret = "2";
            }
            return ret;
        }

        //企业接口权限检索
        public bool GetIsInterfacePermissions(string number, string userId)
        {
            string sql = "select * from Lock_Enterprise_Dock where UserId='" + userId + "'and EnterpriseStatus='1'";
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            if (dt.Rows.Count <= 0)
            {
                return false;
            }
            else
            {
                if (dt.Rows[0]["memo1"].ToString() == string.Empty)
                {
                    return false;
                }
                else
                {
                    string[] bit = dt.Rows[0]["memo1"].ToString().Split('|');//用|进行分割
                    bool exists = ((IList)bit).Contains(number);
                    if (exists)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
        }

        //参数为空校验
        public string checkIsNullFild(Dictionary<string, string> arrayFiled)
        {
            foreach (KeyValuePair<string, string> array in arrayFiled)
            {
                if (array.Value == string.Empty)
                {
                    return array.Key;
                }
            }
            return "";
        }

        //身份证校验
        public bool checkidcard(string idcard)
        {
            //验证18位或者17位加大小写x  
            Regex rg = new Regex(@"^\d{17}(\d|X|x)$");
            Match mc = rg.Match(idcard);
            string r = "";
            if (!mc.Success)
                return false;
            //验证前两位是否符合地区代码  
            string[] area = { "11", "12", "13", "14", "15", "21", "22", "23", "31", "32", "33", "34", "35", "36", "37", "41", "42", "43", "44", "45", "46", "50", "51", "52", "53", "54", "61", "62", "63", "64", "65", "71", "81", "82", "91" };
            bool b = false;
            foreach (string a in area)
            {
                if (idcard.Substring(0, 2) == a)
                {
                    b = true;
                    break;
                }
            }
            if (b == false)
                return false;
            //验证出生日期  
            string birthday = idcard.Substring(6, 4) + "/" + idcard.Substring(10, 2) + "/" + idcard.Substring(12, 2);
            try
            {
                Convert.ToDateTime(birthday);
            }
            catch
            {
                return false;
            }
            //验证最后一位校验位是否符合规则  
            int i = (int.Parse(idcard.Substring(0, 1)) * 7)
                + (int.Parse(idcard.Substring(1, 1)) * 9)
                + (int.Parse(idcard.Substring(2, 1)) * 10)
                + (int.Parse(idcard.Substring(3, 1)) * 5)
                + (int.Parse(idcard.Substring(4, 1)) * 8)
                + (int.Parse(idcard.Substring(5, 1)) * 4)
                + (int.Parse(idcard.Substring(6, 1)) * 2)
                + (int.Parse(idcard.Substring(7, 1)) * 1)
                + (int.Parse(idcard.Substring(8, 1)) * 6)
                + (int.Parse(idcard.Substring(9, 1)) * 3)
                + (int.Parse(idcard.Substring(10, 1)) * 7)
                + (int.Parse(idcard.Substring(11, 1)) * 9)
                + (int.Parse(idcard.Substring(12, 1)) * 10)
                + (int.Parse(idcard.Substring(13, 1)) * 5)
                + (int.Parse(idcard.Substring(14, 1)) * 8)
                + (int.Parse(idcard.Substring(15, 1)) * 4)
                + (int.Parse(idcard.Substring(16, 1)) * 2);
            i = i - i / 11 * 11;
            switch (i)
            {
                case 0: r = "1"; break;
                case 1: r = "0"; break;
                case 2: r = "11"; break;
                case 3: r = "9"; break;
                case 4: r = "8"; break;
                case 5: r = "7"; break;
                case 6: r = "6"; break;
                case 7: r = "5"; break;
                case 8: r = "4"; break;
                case 9: r = "3"; break;
                case 10: r = "2"; break;
            }
            if (r == "11")
                r = "x";
            if (r == idcard.ToLower().Substring(17, 1))
                return true;
            else
                return false;
        }
        //手机号格式校验
        public bool IsTelephone(string str_telephone)
        {
            return Regex.IsMatch(str_telephone, @"^(0|86|17951)?(13[0-9]|15[012356789]|17[013678]|18[0-9]|14[57])[0-9]{8}$");
        }
    }
}
