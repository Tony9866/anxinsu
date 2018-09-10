using System;

namespace XGAPI.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToDateAndTimeString(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd HH:mm:ss");
        }
        public static string ToDateString(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// 标准时间戳，默认获取当前时间的
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static long DateTimeToUTCTicks(this DateTime time)
        {
            var dtime = time.ToUniversalTime();

            return (dtime.Ticks - 621355968000000000) / 10000000;
        }
    }
}
