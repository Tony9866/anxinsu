using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data.Common;
using System.Security.Cryptography;
using Liger.Common;

namespace Liger.Data
{

    /// <summary>
    /// 帮助类
    /// </summary>
    public class DataHelper
    {
        #region 格式化数据
        /// <summary>
        /// 格式化sql
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="leftToken">前缀</param>
        /// <param name="rightToken">后缀</param>
        /// <returns></returns>
        internal static string FormatSQL(string sql, char leftToken, char rightToken)
        {
            if (sql == null)
            {
                return string.Empty;
            } 
            sql = sql.Replace("{0}", leftToken.ToString()).Replace("{1}", rightToken.ToString()); 
            return sql;
        }

        /// <summary>
        /// 格式化数据为数据库通用格式
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string FormatValue(object val)
        {
            if (val == null || val == DBNull.Value)
            {
                return "null";
            } 
            Type type = val.GetType(); 
            if (type == typeof(DateTime) || type == typeof(Guid))
            {
                return string.Format("'{0}'", val);
            }
            else if (type == typeof(TimeSpan))
            {
                DateTime baseTime = new DateTime(1900, 01, 01);
                return string.Format("(cast('{0}' as datetime) - cast('{1}' as datetime))", baseTime + ((TimeSpan)val), baseTime);
            }
            else if (type == typeof(bool))
            {
                return ((bool)val) ? "1" : "0";
            }
            else if (val is Field)
            {
                return ((Field)val).FieldNameWithTable;
            }
            else if (type.IsEnum)
            {
                return Convert.ToInt32(val).ToString();
            }
            else if (type.IsValueType)
            {
                return val.ToString();
            }
            else
            {
                return string.Concat("N'", val.ToString().Replace("'", "''"), "'");
            }
        }
        #endregion
         
        #region 深度拷贝对象
        /// <summary>
        /// DeepClone
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static object Clone(object obj)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, obj);
                stream.Position = 0L;
                return formatter.Deserialize(stream);
            }
        }
        #endregion

        #region 数据转换

        /// <summary>
        /// 转换列表数据
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TTarget"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IEnumerable<TTarget> ConvertList<TSource,TTarget>(List<TSource> list)
        {
            var target = new List<TTarget>(); 
            foreach (var item in list)
            {
                target.Add((TTarget)ConvertValue(typeof(TTarget), item));
            } 
            return (IEnumerable<TTarget>)target;
        }
        /// <summary>
        /// 列表数据 转换为可枚举的泛型对象
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="list"></param>
        /// <param name="targetType"></param> 
        /// <returns></returns>
        public static IEnumerable ListDataToEnumerable<TSource>(List<TSource> list, Type targetType)
        {
            IEnumerable target;
            if (targetType == typeof(int))
            {
                target = ConvertList<TSource, int>(list) as IEnumerable;
            }
            else if (targetType == typeof(double))
            {
                target = ConvertList<TSource, double>(list) as IEnumerable;
            }
            else if (targetType == typeof(decimal))
            {
                target = ConvertList<TSource, decimal>(list) as IEnumerable;
            }
            else if (targetType == typeof(string))
            {
                target = ConvertList<TSource, string>(list) as IEnumerable;
            }
            else if (targetType == typeof(byte[]))
            {
                target = ConvertList<TSource, byte[]>(list) as IEnumerable;
            }
            else
            {
                target = ConvertList<TSource, object>(list) as IEnumerable;
            }
            return target;
        }
        /// <summary>
        /// CheckStuct
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool CheckStruct(Type type)
        {
            return ((type.IsValueType && !type.IsEnum) && (!type.IsPrimitive && !type.IsSerializable));
        }
        /// <summary>
        /// 转换数据
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object ConvertValue(Type type, object value)
        {
            if (Convert.IsDBNull(value) || (value == null))
            {
                return null;
            }
            if (CheckStruct(type))
            {
                string data = value.ToString();
                return SerializationManager.Deserialize(type, data);
            }
            Type type2 = value.GetType();
            if (type == type2)
            {
                return value;
            }
            if (((type == typeof(Guid)) || (type == typeof(Guid?))) && (type2 == typeof(string)))
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    return null;
                }
                return new Guid(value.ToString());
            }
            if (((type == typeof(DateTime)) || (type == typeof(DateTime?))) && (type2 == typeof(string)))
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    return null;
                }
                return Convert.ToDateTime(value);
            }
            if (type.IsEnum)
            {
                try
                {
                    return Enum.Parse(type, value.ToString(), true);
                }
                catch
                {
                    return Enum.ToObject(type, value);
                }
            }
            if (((type == typeof(bool)) || (type == typeof(bool?))))
            {
                bool tempbool = false;
                if (bool.TryParse(value.ToString(), out tempbool))
                {
                    return tempbool;
                }
                else
                { 
                    if (string.IsNullOrEmpty(value.ToString()))
                        return false;
                    else
                        return true;
                } 
            } 
            if (type.IsGenericType)
            {
                type = type.GetGenericArguments()[0];
            } 
            return Convert.ChangeType(value, type);
        }
        /// <summary>
        /// 转换数据类型
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TResult ConvertValue<TResult>(object value)
        {
            if (Convert.IsDBNull(value) || value == null)
                return default(TResult);

            object obj = ConvertValue(typeof(TResult), value);
            if (obj == null)
            {
                return default(TResult);
            }
            return (TResult)obj;
        }
        #endregion
         
        #region 快速执行方法
        /// <summary>
        /// 快速执行Method
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="method"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static object FastMethodInvoke(object obj, MethodInfo method, params object[] parameters)
        {
            return DynamicCalls.GetMethodInvoker(method)(obj, parameters);
        }

        /// <summary>
        /// 快速实例化一个T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Create<T>()
        {
            return (T)Create(typeof(T))();
        }

        /// <summary>
        /// 快速实例化一个FastCreateInstanceHandler
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static FastCreateInstanceHandler Create(Type type)
        {
            return DynamicCalls.GetInstanceCreator(type);
        }
        #endregion

        #region 设置属性值
        /// <summary>
        /// 设置属性值
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="property"></param>
        /// <param name="value"></param>
        public static void SetPropertyValue(object obj, PropertyInfo property, object value)
        {
            if (property.CanWrite)
            {
                var propertySetter = DynamicCalls.GetPropertySetter(property);
                value = ConvertValue(property.PropertyType, value);
                propertySetter(obj, value);
            }
        }

        /// <summary>
        /// 设置属性值
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        public static void SetPropertyValue(object obj, string propertyName, object value)
        {
            SetPropertyValue(obj.GetType(), obj, propertyName, value);
        }

        /// <summary>
        /// 设置属性值
        /// </summary>
        /// <param name="type"></param>
        /// <param name="obj"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        public static void SetPropertyValue(Type type, object obj, string propertyName, object value)
        {
            PropertyInfo property = type.GetProperty(propertyName);
            if (property != null)
            {
                SetPropertyValue(obj, property, value);
            }
        }

        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static object GetPropertyValue<T>(T entity, string propertyName)
        {
            PropertyInfo property = entity.GetType().GetProperty(propertyName);
            if (property != null)
            {
                return property.GetValue(entity, null);
            }

            return null;
        }
        #endregion

        #region Entity转换格式
        /// <summary>
        /// 从Entity数组转换成DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static DataTable EntityArrayToDataTable<T>(T[] entities)
            where T : Entity
        {
            DataTable dt = new DataTable();
            if (entities == null || entities.Length == 0) return dt;

            Field[] fields = entities[0].GetFields();
            int fieldLength = fields.Length;
            foreach (Field field in fields)
            {
                dt.Columns.Add(field.Name);
            } 
            foreach (T entity in entities)
            {
                DataRow dtRow = dt.NewRow();
                object[] values = entity.GetValues();
                
                for (int i = 0; i < fieldLength; i++)
                {
                    dtRow[fields[i].Name] = values[i];
                }
                dt.Rows.Add(dtRow);
            }
            return dt;
        }
        #endregion
         
        #region 生成唯一字符串
        private static System.Text.RegularExpressions.Regex keyReg = new System.Text.RegularExpressions.Regex("[^a-zA-Z]", System.Text.RegularExpressions.RegexOptions.Compiled);

        /// <summary>
        /// 生成唯一字符串
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public static string MakeUniqueKey(string prefix)
        {

            byte[] data = new byte[16];
            new RNGCryptoServiceProvider().GetBytes(data);
            string keystring = keyReg.Replace(Convert.ToBase64String(data).Trim(), string.Empty);

            if (keystring.Length > 16)
                return keystring.Substring(0, 16).ToLower();

            return keystring.ToLower(); 
        }
        #endregion
         
        #region 工具
        /// <summary>
        /// 数组转成字典
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static Dictionary<Field, object> FieldValueToDictionary(Field[] fields, object[] values)
        {
            Dictionary<Field, object> dic = new Dictionary<Field, object>();
            if (null == fields || fields.Length == 0)
                return dic;
            int length = fields.Length;

            for (int i = 0; i < length; i++)
            {
                dic.Add(fields[i], values[i]);
            }

            return dic;

        }
        #endregion

        #region 操作符
        /// <summary>
        /// 获取操作符的Text
        /// </summary>
        /// <param name="op"></param>
        /// <returns></returns> 
        public static string GetOperatorQueryText(QueryOperator op)
        {
            switch (op)
            {
                case QueryOperator.Add:
                    return " + ";
                case QueryOperator.BitwiseAND:
                    return " & ";
                case QueryOperator.BitwiseNOT:
                    return " ~ ";
                case QueryOperator.BitwiseOR:
                    return " | ";
                case QueryOperator.BitwiseXOR:
                    return " ^ ";
                case QueryOperator.Divide:
                    return " / ";
                case QueryOperator.Equal:
                    return " = ";
                case QueryOperator.Greater:
                    return " > ";
                case QueryOperator.GreaterOrEqual:
                    return " >= ";
                case QueryOperator.IsNULL:
                    return " IS NULL ";
                case QueryOperator.IsNotNULL:
                    return " IS NOT NULL ";
                case QueryOperator.Less:
                    return " < ";
                case QueryOperator.LessOrEqual:
                    return " <= ";
                case QueryOperator.Like:
                    return " LIKE ";
                case QueryOperator.Modulo:
                    return " % ";
                case QueryOperator.Multiply:
                    return " * ";
                case QueryOperator.NotEqual:
                    return " <> ";
                case QueryOperator.Subtract:
                    return " - ";
                case QueryOperator.And:
                    return " and ";
                case QueryOperator.Or:
                    return " or ";
                case QueryOperator.In:
                    return " in ";
                case QueryOperator.NotIn:
                    return " not in "; 
            } 
            throw new NotSupportedException("Unknown QueryOperator: " + op.ToString() + "!");
        }
        #endregion
         
        #region 表达式支持
        public static WhereExpression GetPrimaryKeyWhere(Entity entity)
        {
            var pkFilds = entity.GetPrimaryKeyFields();
            var exp = new WhereExpression();
            foreach (var field in pkFilds)
            {
                var newExp = field == entity.GetValue(field.PropertyName);
                if (WhereExpression.IsNullOrEmpty(exp))
                    exp = newExp;
                else
                    exp = WhereExpression.Create(exp, newExp, QueryOperator.And);
            }
            return exp; 
        }

        public static WhereExpression GetPrimaryKeyWhere<T>(object[] pkValues)
            where T : Entity
        {
            var entity = EntityHelper.GetTable<T>();
            var pkFilds = entity.GetPrimaryKeyFields();
            var exp = new WhereExpression();
            for(var i =0;i<pkFilds.Length;i++) 
            {
                var field = pkFilds[i];
                var value = pkValues[i];
                if (WhereExpression.IsNullOrEmpty(exp))
                    exp = field == value;
                else
                    exp = WhereExpression.Create(exp, field == value, QueryOperator.Or);
            }
            return exp;
        }
        #endregion

    }
}
