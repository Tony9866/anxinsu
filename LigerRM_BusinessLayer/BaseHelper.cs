using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using LigerRM.Common.Helper;

namespace SignetInternet_BusinessLayer
{
    public class BaseHelper : Basics
    {
        private static String SqlConnString = MySQLHelper.SqlConnString;

        /// <summary>
        /// 通过sql返回list实体对象
        /// 泛型
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="Sql">sql</param>
        /// <returns></returns>
        public List<T> GetList<T>(string Sql) where T : new()
        {
            DataSet ds = MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(Sql));
            List<T> lists = new List<T>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    lists.Add(PutVal(new T(), row));
                }
            }
            return lists;
        }

        public static T PutVal<T>(T entity, DataRow row) where T : new()
        {
            try
            {
                //初始化 如果为null
                if (entity == null)
                {
                    entity = new T();
                }
                //得到类型
                Type type = typeof(T);
                //取得属性集合
                PropertyInfo[] pi = type.GetProperties();
                foreach (PropertyInfo item in pi)
                {
                    try
                    {
                        var o = row[item.Name];
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                    //给属性赋值
                    if (row[item.Name] != null && row[item.Name] != DBNull.Value)
                    {
                        if (item.PropertyType == typeof(System.Nullable<System.DateTime>))
                        {
                            item.SetValue(entity, Convert.ToDateTime(row[item.Name].ToString()), null);
                        }
                        else
                        {
                            item.SetValue(entity, Convert.ChangeType(row[item.Name], item.PropertyType), null);
                        }
                    }
                }
                return entity;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        /// <summary>
        /// 通过sql返回实体对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Sql"></param>
        /// <returns></returns>
        public T GetModel<T>(string Sql) where T : new()
        {
            List<T> e = GetList<T>(Sql);
            if (e != null && e.Count > 0)
            {
                return e[0];
            }
            return default(T);
        }


        //#region  通过城市名称获取城市编号
        //public string GetLocal(string cityName)
        //{
        //    StringBuilder str = new StringBuilder();
        //    str.Append("SELECT ");
        //    str.Append("provinceid ");
        //    str.Append("FROM Public_Provinces ");
        //    str.Append("WHERE  ");
        //    str.Append("    Public_Provinces.province = '").Append(cityName).Append("'");
        //    LocalMod ModP = GetModel<LocalMod>(str.ToString());
        //    //判断名字属省类
        //    if (ModP != null)
        //    {
        //        return ModP.provinceid;
        //    }
        //    //判断名字属城市类
        //    else 
        //    {
        //        StringBuilder strC = new StringBuilder();
        //        strC.Append("SELECT ");
        //        strC.Append("cityId ");
        //        strC.Append("FROM Public_City ");
        //        strC.Append("WHERE  ");
        //        strC.Append("    Public_City.city='").Append(cityName).Append("'");
        //        ModP = GetModel<LocalMod>(strC.ToString());
        //        if (ModP != null)
        //        {
        //            return ModP.cityId;
        //        }
        //        //如果依旧null 返回天津市编号
        //        return "120000";
        //    }
            
        
        //    //return "天津市";
        //}
        #region  通过城市名称获取城市编号
        public string GetLocal(string cityName)
        {
            StringBuilder str = new StringBuilder();
            str.Append("SELECT ");
            str.Append("cityId ");
            str.Append("FROM Public_City ");
            str.Append("WHERE  ");
            str.Append("    Public_City.city='").Append(cityName).Append("'");
            LocalMod ModCity = GetModel<LocalMod>(str.ToString());
            //城市名字对应的编号
            if (ModCity != null)
            {
                return ModCity.cityId;
            }
            return "120100";
        }

        public class LocalMod
        {
            //城市编号
            public string cityId { get; set; }
        }
        #endregion

  
    }
}
