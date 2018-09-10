using System;
using System.Collections.Generic;
using System.Text;
using Liger.Common.Extensions;

namespace Liger.Data
{
    /// <summary>
    /// 实体 帮助类
    /// </summary>
    public class EntityHelper
    {

        #region 缓存支持
        /// <summary>
        /// 实体列表缓存
        /// </summary>
        private static Dictionary<string, object> entityList = new Dictionary<string, object>();

        /// <summary>
        /// lock object
        /// </summary>
        private static object lockObj = new object();


        /// <summary>
        /// 清空所有缓存
        /// </summary>
        public static void Reset()
        {
            entityList.Clear();
        }

        /// <summary>
        /// 清理具体实体的缓存
        /// </summary>
        public static void Reset<T>()
            where T : Entity
        {
            string typestring = typeof(T).ToString();
            if (entityList.ContainsKey(typestring))
                entityList.Remove(typestring);
        }
        #endregion

        /// <summary>
        /// 返回表名
        /// </summary>
        /// <returns></returns>
        public static string GetName<T>()
            where T : Entity
        {
            return GetTable<T>().GetName();
        }


        /// <summary>
        /// 返回表
        /// </summary>
        /// <returns></returns>
        public static T GetTable<T>()
            where T : Entity
        {
            string typestring = typeof(T).ToString();

            if (entityList.ContainsKey(typestring))
                return (T)entityList[typestring];

            lock (lockObj)
            {
                if (entityList.ContainsKey(typestring))
                    return (T)entityList[typestring];

                T t = DataHelper.Create<T>();
                entityList.Add(typestring, t);
                return t;
            }
        }
        /// <summary>
        /// 创建表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T CreateTable<T>()
            where T : Entity
        {
            T t = DataHelper.Create<T>();
            return t; 
        }


        /// <summary>
        /// 返回标识字段
        /// </summary>
        /// <returns></returns>
        public static Field GetIdentityField<T>()
            where T : Entity
        {
            return GetTable<T>().GetIdentityField();
        }


        /// <summary>
        /// 获取主键字段
        /// </summary>
        /// <returns></returns>
        public static Field[] GetPrimaryKeyFields<T>()
            where T : Entity
        {
            return GetTable<T>().GetPrimaryKeyFields();
        }

        /// <summary>
        /// 返回所有字段
        /// </summary>
        /// <returns></returns>
        public static Field[] GetFields<T>()
            where T : Entity
        {
            return GetTable<T>().GetFields();
        }


        /// <summary>
        /// 返回第一个字段
        /// </summary>
        /// <returns></returns>
        public static Field GetFirstField<T>()
            where T : Entity
        {
            Field[] fields = GetFields<T>();
            if (null != fields && fields.Length > 0)
                return fields[0];
            return null;
        }


        /// <summary>
        /// 是否只读
        /// </summary>
        /// <returns></returns>
        public static bool IsReadOnly<T>()
            where T : Entity
        {
            return GetTable<T>().IsReadOnly();
        }

        /// <summary>
        /// 判断是否完整的字段名
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static bool IsCompletedFild(string fieldName)
        {
            return fieldName.Trim() == "*" ||
                    fieldName.Contains("'") ||
                    fieldName.Contains("(") ||
                    fieldName.Contains(")") ||
                    fieldName.Contains("{0}") ||
                    fieldName.Contains("{1}") ||
                    fieldName.ToLower().Contains(" as ") ||
                    fieldName.Contains("*");
        }
    }
}
