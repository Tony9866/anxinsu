using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using XGAPI.Enums;
using XGAPI.Extensions;

namespace XGAPI
{
    public class XingeApp
    {
        private long m_accessId;
        private String m_secretKey;
        public XingeApp(long accessId, String secretKey)
        {
            this.m_accessId = accessId;
            this.m_secretKey = secretKey;
        }
        public bool pushSingleDevice(String deviceToken, string account, string title, string content, int type, int environment, Dictionary<string, object> custom, out string returnStr)
        {
            content = content.Replace("\r", "").Replace("\n", "");
            switch (type)
            {
                case (int)DeviceType.Android:
                    Message android = new Message();
                    //android.type = Message.TYPE_MESSAGE;
                    android.title = title;
                    android.content = content;
                    //if (message.custom_content == null)
                    //{
                    //    message.custom_content = new Dictionary<string, object>();
                    //}
                    android.custom_content = custom.ToJson();
                    returnStr = pushSingleDevice(deviceToken, android);
                    break;
                case (int)DeviceType.IOS:
                    MessageIOS ios = new MessageIOS();
                    //ios.type = Message.TYPE_NOTIFICATION;
                    ios.alertStr = content.Length > 20 ? content.Substring(0, 20) : content;
                    ios.custom = custom;
          
                    if (!string.IsNullOrEmpty(account))
                    {
                        returnStr = pushSingleAccount(account, ios, environment);
                    }
                    else
                    {
                        returnStr = pushSingleDevice(deviceToken, ios, environment);
                    }
                    break;
                default:

                    returnStr = string.Format("找不到指定类型的推送方法,设备类型:{0}", type);
                    break;
            }
            return true;
        }


        /// <summary>
        /// IOS单个设备 推送信息
        /// </summary>
        /// <param name="deviceToken">针对某一设备推送，token是设备的唯一识别 ID</param>
        /// <param name="message"></param>
        /// <param name="environment"></param>
        /// <returns></returns>
        public string pushSingleDevice(String deviceToken, MessageIOS message, int environment)
        {
            if (!ValidateMessageType(message, environment))
            {
                return "";
            }
            if (!message.isValid())
            {
                return "";
            }
            Dictionary<String, Object> dic = new Dictionary<String, Object>();
            dic.Add("access_id", this.m_accessId);
            dic.Add("expire_time", message.expireTime);
            dic.Add("send_time", message.sendTime);
            dic.Add("device_token", deviceToken);
            dic.Add("message_type", message.type);
            dic.Add("message", message.ToJosnByType());
            dic.Add("timestamp", DateTime.Now.DateTimeToUTCTicks());
            dic.Add("environment", environment);

            if (message.loopInterval > 0 && message.loopTimes > 0)
            {
                dic.Add("loop_interval", message.loopInterval);
                dic.Add("loop_times", message.loopTimes);
            }

            return CallRestful(XinGeAPIUrl.RESTAPI_PUSHSINGLEDEVICE, dic);
        }
        /// <summary>
        /// IOS 根据帐号 推送信息
        /// </summary>
        /// <param name="account">针对某一设备推送，token是设备的唯一识别 ID</param>
        /// <param name="message"></param>
        /// <param name="environment"></param>
        /// <returns></returns>
        public string pushSingleAccount(String account, MessageIOS message, int environment)
        {
            if (!ValidateMessageType(message, environment))
            {
                return "";
            }
            if (!message.isValid())
            {
                return "";
            }
            Dictionary<String, Object> dic = new Dictionary<String, Object>();
            dic.Add("access_id", this.m_accessId);
            dic.Add("expire_time", message.expireTime);
            dic.Add("send_time", message.sendTime);
            dic.Add("account", account);
            dic.Add("message_type", message.type);
            dic.Add("message", message.ToJosnByType());
            dic.Add("timestamp", DateTime.Now.DateTimeToUTCTicks());
            dic.Add("environment", environment);

            if (message.loopInterval > 0 && message.loopTimes > 0)
            {
                dic.Add("loop_interval", message.loopInterval);
                dic.Add("loop_times", message.loopTimes);
            }

            return CallRestful(XinGeAPIUrl.RESTAPI_PUSHSINGLEACCOUNT, dic);
        }

        /// <summary>
        /// Android单个设备 推送信息
        /// </summary>
        /// <param name="deviceToken">针对某一设备推送，token是设备的唯一识别 ID</param>
        /// <param name="message"></param>
        /// <returns></returns>
        public string pushSingleDevice(String deviceToken, Message message)
        {
            if (!ValidateMessageType(message))
            {
                return "";
            }
            if (!message.isValid())
            {
                return "";
            }
            Dictionary<String, Object> dic = new Dictionary<String, Object>();
            dic.Add("access_id", this.m_accessId);
            dic.Add("expire_time", message.expireTime);
            dic.Add("send_time", message.sendTime);
            dic.Add("multi_pkg", message.multiPkg);
            dic.Add("device_token", deviceToken);
            dic.Add("message_type", message.type);
            dic.Add("message", message.ToJson());
            dic.Add("timestamp", DateTime.Now.DateTimeToUTCTicks());

            return CallRestful(XinGeAPIUrl.RESTAPI_PUSHSINGLEDEVICE, dic);
        }

        public string pushAllDevice(Message message)
        {
            if (!ValidateMessageType(message))
            {
                return "";
            }
            if (!message.isValid())
            {
                return "";
            }
            Dictionary<String, Object> dic = new Dictionary<String, Object>();
            dic.Add("access_id", this.m_accessId);
            dic.Add("expire_time", message.expireTime);
            dic.Add("send_time", message.sendTime);
            dic.Add("multi_pkg", message.multiPkg);
            dic.Add("message_type", message.type);
            dic.Add("message", message.ToJson());
            dic.Add("timestamp", DateTime.Now.DateTimeToUTCTicks());

            return CallRestful(XinGeAPIUrl.RESTAPI_PUSHALLDEVICE, dic);
        }

        /// <summary>
        /// 生成 sign（签名）
        /// </summary>
        /// <param name="method"></param>
        /// <param name="url"></param>
        /// <param name="dic"></param>
        /// <returns></returns>
        protected String GenerateSign(String method, String url, Dictionary<String, Object> dic)
        {
            var str = method;
            Uri address = new Uri(url);
            str += address.Host;
            str += address.AbsolutePath;
            var dic2 = dic.OrderBy(d => d.Key);
            foreach (var item in dic2)
            {
                str += (item.Key + "=" + (item.Value == null ? "" : item.Value.ToString()));
            }
            //foreach (var item in dic)
            //{
            //    str += (item.Key +"="+ (item.Value == null ? "" : item.Value.ToString()));
            //}
            str += this.m_secretKey;
            var s_byte = Encoding.UTF8.GetBytes(str);
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(s_byte);
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        /// <summary>
        /// 生成请求的地址和调用请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="dic"></param>
        /// <returns></returns>
        protected string CallRestful(String url, Dictionary<String, Object> dic)
        {
            String sign = GenerateSign("POST", url, dic);
            if (string.IsNullOrEmpty(sign))
            {
                return (new { ret_code = -1, err_msg = "generateSign error" }).ToJson();
            }
            dic.Add("sign", sign);
            try
            {
                var param = "";
                foreach (var item in dic)
                {
                    var key = item.Key;// HttpUtility.UrlEncode(item.Key, Encoding.UTF8);
                    
                    var value =  HttpUtility.UrlEncode(item.Value == null ? "" : item.Value.ToString(), Encoding.UTF8);
                    param = string.IsNullOrEmpty(param) ? string.Format("{0}={1}", key, value) : string.Format("{0}&{1}={2}", param, key, value);
                }
                return Request(url, "POST", param);

            }
            catch (Exception e)
            {

                return e.Message;
            }
        }

        protected bool ValidateMessageType(Message message)
        {
            if (this.m_accessId < XinGeAPIUrl.IOS_MIN_ID)
                return true;
            else
                return false;
        }

        protected bool ValidateMessageType(MessageIOS message, int environment)
        {
            if (this.m_accessId >= XinGeAPIUrl.IOS_MIN_ID && (environment == XinGeAPIUrl.IOSENV_PROD || environment == XinGeAPIUrl.IOSENV_DEV))
                return true;
            else
                return false;
        }

        public string Request(string _address, string method = "GET", string jsonData = null, int timeOut = 5)
        {
            string resultJson = string.Empty;
            if (string.IsNullOrEmpty(_address))
                return resultJson;
            try
            {
                Uri address = new Uri(_address);

                // 创建网络请求  
                HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;
                //System.Net.ServicePointManager.DefaultConnectionLimit = 50; 
                // 构建Head
                request.Method = method;
                request.KeepAlive = false;
                Encoding myEncoding = Encoding.GetEncoding("utf-8");
                if (!string.IsNullOrEmpty(jsonData))
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(jsonData);
                    using (Stream reqStream = request.GetRequestStream())
                    {
                        reqStream.Write(bytes, 0, bytes.Length);
                        reqStream.Close();
                    }
                }
                request.Timeout = timeOut * 1000;
                request.ContentType = "application/x-www-form-urlencoded";
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    string responseStr = reader.ReadToEnd();
                    if (responseStr != null && responseStr.Length > 0)
                    {
                        resultJson = responseStr;
                    }
                }
            }
            catch (Exception ex)
            {
                resultJson = ex.Message;
            }
            return resultJson;
        }

        public bool pushAllDevice(string title, string content, int type, int environment, Dictionary<string, object> custom, out string returnStr)
        {
            content = content.Replace("\r", "").Replace("\n", "");
            switch (type)
            {
                case (int)DeviceType.Android:
                    Message android = new Message();
                    //android.type = Message.TYPE_MESSAGE;
                    android.title = title;
                    android.content = content;
                    //if (message.custom_content == null)
                    //{
                    //    message.custom_content = new Dictionary<string, object>();
                    //}
                    android.custom_content = custom.ToJson();
                    returnStr = pushAllDevice(android);
                    break;
                //case (int)DeviceType.IOS:
                //    MessageIOS ios = new MessageIOS();
                //    //ios.type = Message.TYPE_NOTIFICATION;
                //    ios.alertStr = content.Length > 20 ? content.Substring(0, 20) : content;
                //    ios.custom = custom;
                //    if (!string.IsNullOrEmpty(account))
                //    {
                //        returnStr = pushSingleAccount(account, ios, environment);
                //    }
                //    else
                //    {
                //        returnStr = pushSingleDevice(deviceToken, ios, environment);
                //    }
                //    break;
                default:

                    returnStr = string.Format("找不到指定类型的推送方法,设备类型:{0}", type);
                    break;
            }
            return true;
        }

        
    }
}
