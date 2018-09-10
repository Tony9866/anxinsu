using System;
using System.Collections.Generic;
using XGAPI.Extensions;

namespace XGAPI
{
    public class Message
    {
        public Message()
        {
            this.title = "";
            this.content = "";
            this.sendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.accept_time = new List<TimeInterval>();
            this.multiPkg = 0;
            this.raw = "";
            this.loopInterval = -1;
            this.loopTimes = -1;
            this.action = new ClickAction();
            this.style = new Style(0);
            this.type = Message.TYPE_NOTIFICATION;
        }
        public bool isValid()
        {
            if (!string.IsNullOrEmpty(raw))
            {
                return true;
            }
            if (type < TYPE_NOTIFICATION || type > TYPE_MESSAGE)
                return false;
            if (multiPkg < 0 || multiPkg > 1)
                return false;
            if (type == TYPE_NOTIFICATION)
            {
                if (!style.isValid()) return false;
                if (!action.isValid()) return false;
            }
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
            foreach (var item in accept_time)
            {
                if (!item.isValid()) return false;
            }
            if (loopInterval > 0 && loopTimes > 0
                    && ((loopTimes - 1) * loopInterval + 1) > 15)
            {
                return false;
            }

            return true;
        }
        public string ToJosnByType()
        {
            if (type == TYPE_MESSAGE)
            {
                var obj = new { title = title, content = content, accept_time = accept_time.ToJson() };
                return obj.ToJson();
            }
            return this.ToJson();
        }
        /// <summary>
        /// 1：通知
        /// </summary>
        public static readonly int TYPE_NOTIFICATION = 1;
        /// <summary>
        /// 2：透传消息
        /// </summary>
        public static readonly int TYPE_MESSAGE = 2;
        public String title;
        public String content;
        public int expireTime;
        public String sendTime;
        private List<TimeInterval> accept_time;
        public int type;
        public int multiPkg;
        private Style style;
        private ClickAction action;
        /// <summary>
        /// 自定义参数，所有的系统app操作参数放这里
        /// </summary>
        public string custom_content;
        public String raw;
        public int loopInterval;
        public int loopTimes;
    }
}
