
using System.Web.Script.Serialization;

namespace XGAPI.Extensions
{
    public static class JsonExtends
    {
        public static string ToJson(this object o)
        {
            return new JavaScriptSerializer().Serialize(o);
        }
        /// <summary>
        /// 将json格式的字符串，转换成模型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T ToModel<T>(this string json)
        {
            return new JavaScriptSerializer().Deserialize<T>(json);
        }
    }
}
