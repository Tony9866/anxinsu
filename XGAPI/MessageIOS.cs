using System;
using System.Collections.Generic;
using XGAPI.Extensions;

namespace XGAPI
{
    public class MessageIOS
    {
        public MessageIOS()
        {
            this.sendTime = DateTime.Now.ToDateAndTimeString();
            this.raw = "";
            this.alertStr = "";
            this.badge = 0;
            this.sound = "";
            this.category = "";
            this.loopInterval = -1;
            this.loopTimes = -1;
            this.type = 0;
        }
        public bool isValid()
        {
            if (expireTime < 0 || expireTime > 3 * 24 * 60 * 60)
                return false;
            try
            {
                DateTime.Parse(sendTime);
            }
            catch (Exception e)
            {
                return false;
            }
            if (!string.IsNullOrEmpty(raw))
            {
                return true;
            }
            if (accept_time != null)
            {
                foreach (var item in accept_time)
                {
                    if (!item.isValid()) return false;
                }
            }
            if (string.IsNullOrEmpty(alertStr))
                return false;

            return true;
        }
        public string ToJosnByType()
        {
            if (!string.IsNullOrEmpty(raw))
            {
                return raw;
            }
            var aps = new Dictionary<string, object>();
            //custom.Add("accept_time", accept_time);
            if (!string.IsNullOrEmpty(alertJo))
            {
                aps.Add("alert", alertJo);
            }
            else
            {
                aps.Add("alert", alertStr);
            }
            if (badge != 0)
            {
                aps.Add("badge", badge);
            }
            if (!string.IsNullOrEmpty(category))
            {
                aps.Add("category", category);
            }
            if (!string.IsNullOrEmpty(sound))
            {
                custom.Add("sound", sound);
            }
            var obj = new { aps = aps, paramJson = custom.ToJson(), accept_time = accept_time };
            return obj.ToJson();
        }
        public int expireTime { get; set; }
        public String sendTime { get; set; }
        private List<TimeInterval> accept_time;
        public String raw { get; set; }
        public String alertStr { get; set; }
        public string alertJo { get; set; }
        public int badge { get; set; }
        public String sound { get; set; }
        public String category { get; set; }
        public int loopInterval { get; set; }
        public int loopTimes { get; set; }
        public int type { get; set; }

        public Dictionary<string, object> custom = new Dictionary<string, object>();
    }
}
