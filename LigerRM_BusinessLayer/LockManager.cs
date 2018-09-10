using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using XGAPI;
using LigerRM.Common;
using XGAPI.Enums;

namespace SignetInternet_BusinessLayer
{
    public class LockManager
    {
        System.Timers.Timer t = new System.Timers.Timer(1000);//实例化Timer类，设置间隔时间为10000毫秒；
        System.Timers.Timer t1 = new System.Timers.Timer(1000);//实例化Timer类，设置间隔时间为10000毫秒；
        private bool isLoop = true;
        private bool isLoop1 = true;
        private string retStatus1 = string.Empty;
        private string retStatus = string.Empty;
        private int retCount = 0;
        private int retCount1 = 0;
        public void AddLockDevice(string deviceId, string deviceType, string rentNo, string versionId, string batchNo, string memo, string status)
        {
            string sql = "insert into Rent_Locks values ('" + deviceId + "','" + deviceType + "','" + versionId + "','" + rentNo + "','" + status + "','" + DateTime.Now.ToString() + "','','" + batchNo + "','" + memo + "')";
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
        }

        public void UpdateLockDevice(string deviceId, string deviceType, string rentNo, string versionId, string batchNo, string memo, string status)
        {
            string sql = "update Rent_Locks set DeviceType='" + deviceType + "',VersionID='" + versionId + "',RentNo='" + rentNo + "',Status='" + status + "',BatchNO='" + batchNo + "',Memo='" + memo + "' where ID=" + deviceId;
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
        }

        public DataTable GetDeviceDetailInfo(string deviceId)
        {
            string sql = "select * from Rent_Locks where ID=" + deviceId;
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            return dt;
        }

        public void DeleteLockDevice(string deviceId)
        {
            string sql = "delete from Rent_Locks where ID=" + deviceId;
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
        }

        public string UnLockDevice(string id)
        {
            string userId = "hzb_yskj".PadRight(30, ' ');
            //string doorId = "0201075500100001"; //Test
            LockServices.IhzbAttenServiceservice client = new LockServices.IhzbAttenServiceservice();
            string ret = client.hzb_SetDoorOpen(99, "02500262", userId + id);
            retStatus = ret;
            string returnStr = ret.Substring(0, 1);
            string doorId = ret.Substring(1, 16);
            string serialNo = ret.Substring(17, 12);
            string statusRet = string.Empty;
            //System.Timers.Timer t = new System.Timers.Timer(1000);
            if (returnStr == "1")
            {
                //statusRet = client.hzb_GetOprateResult(99, "02500262", ret.Substring(1));


                t.Elapsed += new System.Timers.ElapsedEventHandler(theout);//到达时间的时候执行事件；
                t.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；
                t.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；

                while (isLoop)
                {
                    //statusRet = client.hzb_GetOprateResult(99, "02500262", ret.Substring(1));

                }

                AddLockLog(id, "Open");
            }
            else
            {
                return "3";
            }
            return retStatus;
        }

        private void theout(object source, System.Timers.ElapsedEventArgs e)
        {
            LockServices.IhzbAttenServiceservice client = new LockServices.IhzbAttenServiceservice();
            string statusRet = client.hzb_GetOprateResult(99, "02500262", retStatus.Substring(1));

            if (statusRet.Substring(0, 1).Equals("0"))
            {
                isLoop = false;
                retStatus = statusRet;
            }
            else
            {
                if (retCount >= 10)
                {
                    isLoop = false;
                    t.Enabled = false;
                    retStatus = string.Empty;
                }
            }
            retCount++;
        }

        private void theout1(object source, System.Timers.ElapsedEventArgs e)
        {
            LockServices.IhzbAttenServiceservice client = new LockServices.IhzbAttenServiceservice();
            string statusRet = client.hzb_GetOprateResult(99, "02500262", retStatus1.Substring(1));

            if (statusRet.Substring(0, 1).Equals("0"))
            {
                isLoop1 = false;
                retStatus1 = statusRet;
            }
            else
            {
                if (retCount1 >= 10)
                {
                    isLoop1 = false;
                    t1.Enabled = false;
                    retStatus1 = string.Empty;
                }
            }
            retCount1++;
        }

        public string GetDeviceStatus(string ids)
        {
            LockServices.IhzbAttenServiceservice client = new LockServices.IhzbAttenServiceservice();
            string ret = client.hzb_GetLockerStatus(99, "02500262", ids);
            AddLockLog(ids, "Status");
            return ret;
        }

        public string UpdatePassengerInfoToDevice(string ids, string cardid, string idcard, string phone, string pass, string starttime, string endtime, string type)
        {
            //type 1-增加卡号，2-删除卡号，3-增加密码，4-删除密码，5-启用电子门锁，6-停用电子门锁,7-增加身份证,8-删除身份证
            LockServices.IhzbAttenServiceservice client = new LockServices.IhzbAttenServiceservice();
            string str = ids.PadRight(16, ' ') + cardid.PadRight(10, ' ') + idcard.PadRight(18, ' ') + phone.PadRight(13, ' ') + pass.PadRight(6, ' ') + starttime + endtime + type;
            string ret = client.hzb_SetPassengerInfo(99, "02500262", str);
            retStatus1 = ret;

            //if (ret.Substring(0,1) == "1")
            //{
            //    //statusRet = client.hzb_GetOprateResult(99, "02500262", ret.Substring(1));


            //    t1.Elapsed += new System.Timers.ElapsedEventHandler(theout1);//到达时间的时候执行事件；
            //    t1.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；
            //    t1.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；

            //    while (isLoop1)
            //    {
            //        //statusRet = client.hzb_GetOprateResult(99, "02500262", ret.Substring(1));

            //    }

            //    AddLockLog(ids, str);
            //}

            return retStatus1;
        }

        public void AddIDCard(string id)
        {

        }

        public void AddLockLog(string deviceId, string action)
        {
            string id = Guid.NewGuid().ToString();
            string sql = "insert into Rent_Lock_Logs values ('" + id + "','" + deviceId + "','" + action + "','" + DateTime.Now.ToString() + "','')";
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
        }


        public void AddICCard(string deviceId, string icCard, string startdate, string enddate)
        {
            string sql = "insert into Rent_Locks_ICCards values ('" + deviceId + "','" + icCard + "','" + startdate + "','" + enddate + "','0',1)";
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
        }

        public void UpdateICCard(string id, string deviceId, string icCard, string startdate, string enddate)
        {
            string sql = "update Rent_Locks_ICCards set LockID='" + deviceId + "',ICCard='" + icCard + "',StartDate='" + startdate + "',EndDate='" + enddate + "' where ID=" + id;
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
        }

        public void DeleteICCard(string id)
        {
            string sql = "select * from Rent_Locks_ICCards where ID=" + id;
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            sql = "update Rent_Locks_ICCards set IsValid='0' where ID=" + id;
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
            string s = string.Empty;
            LockServices.IhzbAttenServiceservice client = new LockServices.IhzbAttenServiceservice();
            string str = dt.Rows[0]["LockID"].ToString().PadRight(16, ' ') + dt.Rows[0]["ICCard"].ToString().PadRight(10, ' ') + s.PadRight(18, ' ') + s.PadRight(13, ' ') + s.PadRight(6, ' ') + DateTime.Parse(dt.Rows[0]["StartDate"].ToString()).ToString("yyyyMMddHHmm").Substring(2, 10) + DateTime.Parse(dt.Rows[0]["EndDate"].ToString()).ToString("yyyyMMddHHmm").Substring(2, 10) + "2";
            string ret = client.hzb_SetPassengerInfo(99, "02500262", str);
        }

        public void FreezeICCard(string id)
        {
            string sql = "update Rent_Locks_ICCards set status='1' where ID=" + id;
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));

            sql = "select * from Rent_Locks_ICCards where ID=" + id;
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            string s = string.Empty;
            if (dt.Rows.Count > 0)
            {
                LockServices.IhzbAttenServiceservice client = new LockServices.IhzbAttenServiceservice();
                string str = dt.Rows[0]["LockID"].ToString().PadRight(16, ' ') + dt.Rows[0]["ICCard"].ToString().PadRight(10, ' ') + s.PadRight(18, ' ') + s.PadRight(13, ' ') + s.PadRight(6, ' ') + DateTime.Parse(dt.Rows[0]["StartDate"].ToString()).ToString("yyyyMMddHHmm").Substring(2, 10) + DateTime.Parse(dt.Rows[0]["EndDate"].ToString()).ToString("yyyyMMddHHmm").Substring(2, 10) + "2";
                string ret = client.hzb_SetPassengerInfo(99, "02500262", str);
                AddLockLog(dt.Rows[0]["ICCard"].ToString(), "Freeze");
            }
        }

        public void FreezePassword(string id)
        {
            string sql = "update Rent_Locks_Password set status='1' where ID=" + id;
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));

            sql = "select * from Rent_Locks_Password where ID=" + id;
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            string s = string.Empty;
            if (dt.Rows.Count > 0)
            {
                UpdatePassengerInfoToDevice(dt.Rows[0]["LockID"].ToString(), "", "", "", dt.Rows[0]["Password"].ToString().Trim(), DateTime.Parse(dt.Rows[0]["StartDate"].ToString()).ToString("yyyyMMddHHmm").Substring(2, 10), DateTime.Parse(dt.Rows[0]["EndDate"].ToString()).ToString("yyyyMMddHHmm").Substring(2, 10), "4");
                AddLockLog(dt.Rows[0]["Password"].ToString(), "Freeze");
            }
        }

        public void UnFreezePassword(string id)
        {
            string sql = "update Rent_Locks_Password set status='0' where ID=" + id;
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));

            sql = "select * from Rent_Locks_Password where ID=" + id;
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            string s = string.Empty;
            if (dt.Rows.Count > 0)
            {

                UpdatePassengerInfoToDevice(dt.Rows[0]["LockID"].ToString(), "", "", "", dt.Rows[0]["Password"].ToString().Trim(), DateTime.Parse(dt.Rows[0]["StartDate"].ToString()).ToString("yyyyMMddHHmm").Substring(2, 10), DateTime.Parse(dt.Rows[0]["EndDate"].ToString()).ToString("yyyyMMddHHmm").Substring(2, 10), "3");
                AddLockLog(dt.Rows[0]["Password"].ToString(), "Freeze");
            }
        }

        public void UnFreezeICCard(string id)
        {
            string sql = "update Rent_Locks_ICCards set status='0' where ID=" + id;
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));

            sql = "select * from Rent_Locks_ICCards where ID=" + id;
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            string s = string.Empty;
            if (dt.Rows.Count > 0)
            {
                LockServices.IhzbAttenServiceservice client = new LockServices.IhzbAttenServiceservice();
                string str = dt.Rows[0]["LockID"].ToString().PadRight(16, ' ') + dt.Rows[0]["ICCard"].ToString().PadRight(10, ' ') + s.PadRight(18, ' ') + s.PadRight(13, ' ') + s.PadRight(6, ' ') + DateTime.Parse(dt.Rows[0]["StartDate"].ToString()).ToString("yyyyMMddHHmm").Substring(2, 10) + DateTime.Parse(dt.Rows[0]["EndDate"].ToString()).ToString("yyyyMMddHHmm").Substring(2, 10) + "1";
                string ret = client.hzb_SetPassengerInfo(99, "02500262", str);
                AddLockLog(dt.Rows[0]["ICCard"].ToString(), "UnFreeze");
            }
        }

        public void DeletePassword(string id)
        {
            string sql = "update Rent_Locks_Password set IsValid='0' where ID=" + id;
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));

            sql = "select * from Rent_Locks_Password where ID=" + id;
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            string s = string.Empty;
            if (dt.Rows.Count > 0)
            {
                UpdatePassengerInfoToDevice(dt.Rows[0]["LockID"].ToString(), "", "", "", dt.Rows[0]["Password"].ToString().Trim(), DateTime.Parse(dt.Rows[0]["StartDate"].ToString()).ToString("yyyyMMddHHmm").Substring(2, 10), DateTime.Parse(dt.Rows[0]["EndDate"].ToString()).ToString("yyyyMMddHHmm").Substring(2, 10), "4");
                AddLockLog(dt.Rows[0]["Password"].ToString(), "Freeze");
            }
        }

        public void FreezeLock(string ID)
        {
            LockServices.IhzbAttenServiceservice client = new LockServices.IhzbAttenServiceservice();
            string cardid = string.Empty;
            string idcard = string.Empty;
            string phone = string.Empty;
            string pass = string.Empty;
            string starttime = DateTime.Now.ToString("yyyyMMddHHmm").Substring(2, 10);
            string endtime = DateTime.Now.ToString("yyyyMMddHHmm").Substring(2, 10);
            string str = ID.PadRight(16, ' ') + cardid.PadRight(10, ' ') + idcard.PadRight(18, ' ') + phone.PadRight(13, ' ') + pass.PadRight(6, ' ') + starttime + endtime + "6";
            string ret = client.hzb_SetPassengerInfo(99, "02500262", str);
            AddLockLog(ID, "Freeze");
            //}
            string sql = "update Rent_Locks set status='3' where DeviceID='" + ID + "'";
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));

        }

        public void UnFreezeLock(string ID)
        {

            LockServices.IhzbAttenServiceservice client = new LockServices.IhzbAttenServiceservice();
            string cardid = string.Empty;
            string idcard = string.Empty;
            string phone = string.Empty;
            string pass = string.Empty;
            string starttime = DateTime.Now.ToString("yyyyMMddHHmm").Substring(2, 10);
            string endtime = DateTime.Now.ToString("yyyyMMddHHmm").Substring(2, 10);
            string str = ID.PadRight(16, ' ') + cardid.PadRight(10, ' ') + idcard.PadRight(18, ' ') + phone.PadRight(13, ' ') + pass.PadRight(6, ' ') + starttime + endtime + "5";
            string ret = client.hzb_SetPassengerInfo(99, "02500262", str);
            AddLockLog(ID, "UnFreeze");

            string sql = "update Rent_Locks set status='0' where DeviceID='" + ID + "'";
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));

        }

        public void AddPassword(string deviceId, string pass, string startdate, string enddate)
        {
            string sql = "insert into Rent_Locks_Password values ('" + deviceId + "','" + pass + "','" + startdate + "','" + enddate + "','0',1)";
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
        }

        public void UpdatePassword(string id, string deviceId, string pass, string startdate, string enddate)
        {
            string sql = "update Rent_Locks_Password set LockID='" + deviceId + "',Password='" + pass + "',StartDate='" + startdate + "',EndDate='" + enddate + "' where ID=" + id;
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
        }

        public string SendMessageToDevice(string togleId, string message, string rraid, string idCard)
        {
            Dictionary<string, string> ret = new Dictionary<string, string>();
            string returnStr = "";
            var custom = new Dictionary<string, object>();
            custom.Add("Param", "1");
            XingeApp androidPush = new XingeApp(2100266015, "30eabd4f5ffe5c06d460be58a6ab29b5");
            var isSuccess = androidPush.pushSingleDevice(togleId, "", "来自云上之家的信息", message, (int)DeviceType.Android, 0, custom, out returnStr);
            XingeApp iosPush = new XingeApp(2200268045, "d618b7cfd494a6c8b8705d229555bbbf");
            isSuccess = iosPush.pushSingleDevice(togleId, "", "来自云上之家的信息", message, (int)DeviceType.IOS, 2, custom, out returnStr);
            //isSuccess = androidPush.pushAllDevice("群发", "Android测试推送内容", (int)DeviceType.Android, 0, custom, out returnStr);
            if (isSuccess)
            {
                this.CreateSendMessageInfo(rraid, message, togleId, idCard);
                ret.Add("ret", "0");
                ret.Add("msg", returnStr);
            }
            else
            {
                ret.Add("ret", "1");
                ret.Add("msg", returnStr);
            }

            return JSONHelper.ToJson(ret);
        }

        //推送信息记录
        public void CreateSendMessageInfo(string rraid, string message, string togleId, string idCard)
        {
            string sql = "insert into Rent_Send_Message values ('" + Guid.NewGuid().ToString() + "','" + idCard + "','" + message + "','1','" + DateTime.Now.ToString() + "', '" + togleId + "', '" + rraid + "', '', '')";
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
        }
    }
}
