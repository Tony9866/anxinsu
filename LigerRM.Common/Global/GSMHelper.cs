using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LigerRM.Common.Global
{
    public static class GSMHelper
    {
        public static bool SendMessage(List<string> phones,string msg)
        {
            foreach (string p in phones)
            {
                SendMessage(p, msg);
            }
            return true;
        }

        public static string SendMessage(string phoneNumber, string message)
        {
            try
            {
                //{x}温馨提示{x}尊敬的用户{x}您辖区内{xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx }的出租屋已经出租{x}
                SMS.SmsPortTypeClient client = new SMS.SmsPortTypeClient();
                string response = client.Sms("239930", "tjs_bhga", "bhga123", message, phoneNumber, DateTime.Now.ToString("yyyyMMddHHmmss"), "", "1", "", "", "");
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
