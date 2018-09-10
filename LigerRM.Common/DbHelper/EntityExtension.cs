using System;
using System.Collections.Specialized; 
using Liger.Data;
using System.Reflection;
using Liger.Common.Extensions;
using Liger.Common;
namespace LigerRM.Common
{
    /// <summary>
    /// 对ORM实体类Entity 扩展
    /// </summary>
    public static class EntityExtension
    {
         
        public static void Load(this Entity entity,NameValueCollection coll)
        {
            if (coll == null) return;
            foreach (var key in coll.AllKeys)
            {
                var prop = entity.GetType().GetProperty(key);
                if (prop != null)
                {
                    if (coll[key].HasValue())
                    {
                        var propValue = DataHelper.ConvertValue(prop.PropertyType, coll[key]);
                        prop.SetValue(entity, propValue, null);
                    }
                    else if (prop.PropertyType == typeof(string))
                    {
                        prop.SetValue(entity, null, null);
                    }
                }
            }
        }
         

         
    }
}
