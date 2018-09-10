using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web;
using Liger.Data; 
using Liger.Common.Extensions;
using System.Data.Common;
using System.Data;

namespace LigerRM.Common
{
    /// <summary>
    /// 对DbContext类扩展一下 前台使用的常用方法
    /// </summary>
    public static class DbContextExtension
    {
        /// <summary>
        /// 获取liger Grid 所需要的JSON
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetGridJSON(this DbContext dbContext, HttpContext context)
        {

            var bulider = GridDataBuliderProvider.Create(dbContext);

            var data = bulider.GetGridData(context);

            string result = new Liger.Common.JSON.DataTableJSONSerializer().Serialize(data.Rows);


            string json = @"{""Rows"":" + result + @",""Total"":""" + data.Total + @"""}";
            return json;
        }

        /// <summary>
        /// 获取 ligerTree 所需要的JSON
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetTreeJSON(this DbContext dbContext, HttpContext context)
        {
            string view = context.Request["view"];
            string where = context.Request["where"];
            string idfield = context.Request["idfield"];
            string pidfield = context.Request["pidfield"];
            string textfield = context.Request["textfield"];
            string iconfield = context.Request["iconfield"];
            string iconroot = context.Request["iconroot"] ?? "";
            string root = context.Request["root"];
            string rooticon = context.Request["rooticon"];
            string sql = "select {0} from [{1}] where {2}";

            string sqlselect = "[" + textfield + "] as [text]";
            if (iconfield.HasValue())
            {
                sqlselect += ",'" + iconroot + "'+[" + iconfield + "] as [icon]";
            }
            if (idfield.HasValue())
            {
                sqlselect += ",[" + idfield + "] as [id]";
            }
            if (idfield.HasValue())
            {
                sqlselect += ",[" + idfield + "]";
            }
            if (pidfield.HasValue())
            {
                sqlselect += ",[" + pidfield + "]";
            }

            /*
             * where 为 json参数，格式如下： 
             * {
                  "roles":[
                     {"field":"ID","value":112,"op":"equal"},
                      {"field":"Time","value":"2011-3-4","op":"greaterorequal"}
                   ],
                  "op":"and","groups":null
             *  }
             *  FilterTranslator可以为以上格式的where表达式翻译为sql，并生成参数列表(FilterParam[])
             */
            var whereTranslator = new FilterTranslator();
            var dpRule = new DataPrivilegeRule(dbContext);
            if (!where.IsNullOrEmpty())
            {
                //反序列化Filter Group JSON
                whereTranslator.Group = JSONHelper.FromJson<FilterGroup>(where);
                //合并条件权限规则
                whereTranslator.Group = dpRule.GetRuleGroup(view, whereTranslator.Group);
            }
            else
            {
                whereTranslator.Group = dpRule.GetRuleGroup(view, whereTranslator.Group);
            }
            whereTranslator.Translate();
            where = whereTranslator.CommandText;

            sql = sql.FormatWith(sqlselect, view, where.IsNullOrEmpty() ? " 1=1 " : where);
            //创建command
            var cmd = CreateCommand(dbContext, sql, whereTranslator.Parms.ToArray());
            //使用liger.Data内置的数据适配器预处理command
            //比如对整数类型、日期类型的处理
            dbContext.Db.DbProvider.PrepareCommand(cmd);
            //获取树格式对象的JSON，这个方法首先会执行command，并且对结果进行格式化(转化为树格式)
            string json = JSONHelper.GetArrayJSON(cmd, idfield, pidfield);

            if (!root.IsNullOrEmpty())
            {
                json = @"[{""text"":""" + root + @""",""children"":" + json;
                if (rooticon.HasValue()) json += @",""icon"":""" + rooticon + @"""";
                json += "}]";
            }

            return json;
        }




        /// <summary>
        /// 获取 ligerGrid(Tree) 所需要的JSON
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetGridTreeJSON(this DbContext dbContext, HttpContext context)
        {
            string view = context.Request["view"];
            string where = context.Request["where"];
            string idfield = context.Request["idfield"];
            string pidfield = context.Request["pidfield"]; 
            string sql = "select * from [{0}] where {1}";


            var whereTranslator = new FilterTranslator();
            var dpRule = new DataPrivilegeRule(dbContext);
            if (!where.IsNullOrEmpty())
            {
                //反序列化Filter Group JSON
                whereTranslator.Group = JSONHelper.FromJson<FilterGroup>(where);
                //合并条件权限规则
                whereTranslator.Group = dpRule.GetRuleGroup(view, whereTranslator.Group);
            }
            else
            {
                whereTranslator.Group = dpRule.GetRuleGroup(view, whereTranslator.Group);
            }
            whereTranslator.Translate();
            where = whereTranslator.CommandText;

            sql = sql.FormatWith(view, where.IsNullOrEmpty() ? " 1=1 " : where);
            //创建command
            var cmd = CreateCommand(dbContext, sql, whereTranslator.Parms.ToArray());
            //使用liger.Data内置的数据适配器预处理command
            //比如对整数类型、日期类型的处理
            dbContext.Db.DbProvider.PrepareCommand(cmd);
            //获取树格式对象的JSON，这个方法首先会执行command，并且对结果进行格式化(转化为树格式)
            List<Hashtable> o = JSONHelper.ArrayToTreeData(cmd, idfield, pidfield) as List<Hashtable>;
           
            string json = @"{""Rows"":" + JSONHelper.ToJson(o) + @",""Total"":""" + o.Count + @"""}";
            return json;
        }

        /// <summary>
        /// 获取 ligerComboBox 所需要的JSON
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetSelectJSON(this DbContext dbContext, HttpContext context)
        {
            string view = context.Request["view"];
            string where = context.Request["where"];
            string idfield = context.Request["idfield"];
            string textfield = context.Request["textfield"];
            string distinct = context.Request["distinct"];
            string defaultValues = context.Request["defaultValues"];
            string needAll = context.Request["needAll"];
            string sql = "select "
                + ((distinct.HasValue() && distinct != "false") ? "distinct" : "")
                + @"  {0} from [{1}] where {2}";
            var sqlselect = "";
            if (idfield.HasValue())
            {
                sqlselect += ",[" + idfield + "] as [id]";
                sqlselect += ",[" + idfield + "] as [value]";
            }
            if (textfield.HasValue())
            {
                sqlselect += ",[" + textfield + "] as [text]";
            }
            var whereTranslator = new FilterTranslator();
            if (!where.IsNullOrEmpty())
            {
                //反序列化Filter Group JSON
                whereTranslator.Group = JSONHelper.FromJson<FilterGroup>(where);
                if (dbContext != DbHelper.DBCustome)
                {
                    var dpRule = new DataPrivilegeRule(DbHelper.Db);
                    whereTranslator.Group = dpRule.GetRuleGroup(view, whereTranslator.Group);
                }
                //翻译，这一步是必须的
                whereTranslator.Translate();
                where = whereTranslator.CommandText;
            }

            sql = sql.FormatWith(sqlselect.HasValue() ? sqlselect.Substring(1) : "*", view, where.IsNullOrEmpty() ? " 1=1 " : where);
            //创建command
            var cmd = CreateCommand(dbContext, sql, whereTranslator.Parms.ToArray());
            //使用liger.Data内置的数据适配器预处理command
            //比如对整数类型、日期类型的处理
            dbContext.Db.DbProvider.PrepareCommand(cmd);
            var ds = dbContext.ExecuteDataSet(cmd);

            if (!defaultValues.IsNullOrEmpty())
            {
                foreach (string item in defaultValues.Split(','))
                {
                    DataRow newRow = ds.Tables[0].NewRow();
                    newRow["id"] = item;
                    newRow["value"] = item;
                    newRow["text"] = item;
                    ds.Tables[0].Rows.Add(newRow);
                }
            }
            if (needAll == "1")
            {
                DataRow row = ds.Tables[0].NewRow();
                row["id"] = "全部";
                row["value"] = "全部";
                row["text"] = "全部";
                ds.Tables[0].Rows.Add(row);
            }

            var json = new Liger.Common.JSON.DataSetJSONSerializer().Serialize(ds);
            return json;
        }

        private static DbCommand CreateCommand(DbContext dbContext, string commandText, FilterParam[] parms)
        {
            var DbProvider = dbContext.Db.DbProvider;
            var cmd = DbProvider.DbProviderFactory.CreateCommand();
            cmd.CommandText = commandText;
            if (parms != null)
            {
                foreach (var parm in parms)
                {
                    DbParameter p = DbProvider.DbProviderFactory.CreateParameter();
                    p.ParameterName = DbProvider.ParamPrefix + parm.Name;
                    p.Value = parm.Value;
                    cmd.Parameters.Add(p);
                }
            }
            return cmd;
        }

        /// <summary>
        /// 获取实体对象，并返回对前台友好的数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbContext"></param>
        /// <param name="exp"></param>
        /// <returns></returns>
        public static AjaxResult GetEntity<T>(this DbContext dbContext, WhereExpression exp)
          where T : Entity
        {
            try
            {
                var result = dbContext.From<T>().Where(exp).ToFirst();
                if (result == null)
                {
                    return AjaxResult.Error("加载失败");
                }
                else
                {
                    return AjaxResult.Success(result, "加载成功");
                }
            }
            catch (Exception err)
            {
                return AjaxResult.Error("系统错误:" + err.Message);
            }
        }


        /// <summary>
        /// 插入实体对象，并返回对前台友好的数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbContext"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static AjaxResult InsertEntity<T>(this DbContext dbContext, T entity)
            where T : Entity
        {
            try 
            {
                var result = dbContext.Insert<T>(entity);
                return AjaxResult.Success(result, "保存成功");

            }
            catch (Exception err)
            {
                LogManager.WriteLog("Error", err.Message);
                return AjaxResult.Error("系统错误:" + err.Message);
            }
        }

        /// <summary>
        /// 保存实体对象，并返回对前台友好的数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbContext"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static AjaxResult UpdateEntity<T>(this DbContext dbContext, T entity)
           where T : Entity
        {
            try
            {
                var result = dbContext.Update<T>(entity);
                return AjaxResult.Success(result, "保存成功");
            }
            catch (Exception err)
            {
                LogManager.WriteLog("Error", err.Message);
                return AjaxResult.Error("系统错误:" + err.Message);
            }
        }
        /// <summary>
        /// 删除实体对象，并返回对前台友好的数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbContext"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static AjaxResult DeleteEntity<T>(this DbContext dbContext, T entity)
           where T : Entity
        {
            try
            {
                var result = dbContext.Delete<T>(entity);
                return AjaxResult.Success(result, "删除成功");

            }
            catch (Exception err)
            {
                LogManager.WriteLog("Error", err.Message);
                return AjaxResult.Error("系统错误:" + err.Message);
            }
        }

        /// <summary>
        /// 删除实体对象，并返回对前台友好的数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbContext"></param>
        /// <param name="pkValue"></param>
        /// <returns></returns>
        public static AjaxResult DeleteEntity<T>(this DbContext dbContext, string pkValue)
           where T : Entity
        {
            try
            {
                var result = dbContext.Delete<T>(pkValue);
                return AjaxResult.Success(result, "删除成功");

            }
            catch (Exception err)
            {
                LogManager.WriteLog("Error", err.Message);
                if (err.Message.Contains("FK_Rent"))
                {
                    return AjaxResult.Error("系统错误:" + "数据已被引用，不能删除");
                }
                else
                {
                    return AjaxResult.Error("系统错误:" + err.Message);
                }
            }
        }


    }
}