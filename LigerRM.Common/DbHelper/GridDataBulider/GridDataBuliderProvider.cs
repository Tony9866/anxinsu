using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Web;
using Liger.Common.Extensions;
using Liger.Data.Extensions;
using Liger.Data;

namespace LigerRM.Common
{
    /// <summary>
    /// 前台grid data json的处理类
    /// 可继承这个类，并重载 分页等细节
    /// </summary>
    public class GridDataBuliderProvider
    { 

        #region 实例化与构造函数
        /// <summary>
        /// 根据数据库的不同调用不同的子类进行分页等操作
        /// </summary>
        /// <param name="dbContext"></param>
        /// <returns></returns>
        public static GridDataBuliderProvider Create(DbContext dbContext)
        {
            var dbprovider = dbContext.Db.DbProvider;
            if (dbprovider is Liger.Data.MsAccess.MsAccessProvider)
            {
                return new AccessGridDataBuliderProvider(dbContext); 
            }
            if (dbprovider is Liger.Data.SqlServer9.SqlServer9Provider)
            {
                return new SqlServer9GridDataBuliderProvider(dbContext);
            }
            if (dbprovider is Liger.Data.SqlServer.SqlServerProvider)
            {
                return new SqlServerGridDataBuliderProvider(dbContext);
            } 
            return new GridDataBuliderProvider(dbContext);
        }

        public DbProvider DbProvider
        {
            get
            {
                return DbContext.Db.DbProvider;
            }
        }
        public DbContext DbContext { get; set; }

        protected GridDataBuliderProvider(DbContext dbContext)
        {
            this.DbContext = dbContext;
        }
        #endregion 

        public virtual GridData GetGridData(HttpContext context)
        {
            string view = context.Request["view"];
            string columns = context.Request["columns"];
            string sortname = context.Request["sortname"];
            string sortorder = context.Request["sortorder"];
            string _pagenumber = context.Request["page"];
            string _pagesize = context.Request["pagesize"];
            string procedure = context.Request["procedure"];
            string where = context.Request["where"];
            if (string.IsNullOrEmpty(procedure))
            {
                int? pagenumber = null, pagesize = null;
                //可分页
                if (!_pagenumber.IsNullOrEmpty() && !_pagesize.IsNullOrEmpty())
                {
                    pagenumber = _pagenumber.ToInt();
                    pagesize = _pagesize.ToInt();
                    if (pagesize == 0) pagesize = 20;
                }
                //可排序
                if (!sortname.IsNullOrEmpty())
                {
                    sortorder = sortorder.IsNullOrEmpty() || sortorder.EqualsTo("asc") ? "asc" : "desc";
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
                var dpRule = new DataPrivilegeRule(DbHelper.Db);


                var whereTranslator = new FilterTranslator();
                
                if (!where.IsNullOrEmpty())
                {
                    //反序列化Filter Group JSON
                    whereTranslator.Group = JSONHelper.FromJson<FilterGroup>(where);
                    //合并数据权限规则
                    
                    whereTranslator.Group = dpRule.GetRuleGroup(view, whereTranslator.Group);
                }
                else
                {
                    //如果没有定义前台搜索规则
                    whereTranslator.Group = dpRule.GetRuleGroup(view, whereTranslator.Group);
                }
                if (whereTranslator.Group != null && whereTranslator.Group.rules != null)
                    whereTranslator.Group.rules = whereTranslator.Group.rules.Where(i => i.value != null && i.value.ToString() != "全部" && i.value != "" && i.value != "undefined").ToList();
                whereTranslator.Translate();

                if (string.IsNullOrEmpty(columns))
                    return GetGridData(view, whereTranslator.CommandText, sortname, sortorder, pagenumber, pagesize, whereTranslator.Parms.ToArray());
                else
                    return GetGridData(view,columns, whereTranslator.CommandText, sortname, sortorder, pagenumber, pagesize, whereTranslator.Parms.ToArray());
            }
            else
            {
                if (string.IsNullOrEmpty(where))
                {
                    return GetGridData(procedure, null);
                }
                else
                {
                    var whereTranslator = new FilterTranslator();
                    whereTranslator.Group = JSONHelper.FromJson<FilterGroup>(where);
                    DbParameter[] parms = new DbParameter[whereTranslator.Group.rules.Count];
                    for (int i = 0; i < parms.Count(); i++)
                    {
                        DbParameter p = this.DbProvider.DbProviderFactory.CreateParameter();
                        FilterRule rule = whereTranslator.Group.rules[i];
                        p.ParameterName = "@"+rule.field.ToLower();
                        switch (rule.type)
                        { 
                            case "string":
                                p.DbType = DbType.String;
                                break;
                            case "int":
                                p.DbType = DbType.Int32;
                                break;
                        }
                        p.Value = string.IsNullOrEmpty(rule.value.ToString())||rule.value.ToString().Equals("全部")?"":rule.value.ToString();
                        parms[i] = p;
                    }
                    return GetGridData(procedure, parms);
                }
            }
        }

        public virtual GridData GetGridData(string view, string where, string sortname, string sortorder, int? pagenumber, int? pagesize, FilterParam[] parms)
        {
            var rows = GetGridRows(view, where, sortname, sortorder, pagenumber, pagesize, parms);
            var total = GetGridTotal(view, where, parms);
            return new GridData()
            {
                Rows = rows,
                Total = total
            };
        }

        public virtual GridData GetGridData(string view,string columns, string where, string sortname, string sortorder, int? pagenumber, int? pagesize, FilterParam[] parms)
        {
            var rows = GetGridRows(view,columns, where, sortname, sortorder, pagenumber, pagesize, parms);
            var total = GetGridTotal(view, where, parms);
            return new GridData()
            {
                Rows = rows,
                Total = total
            };
        }

        public virtual GridData GetGridData(string procedureName, DbParameter[] parms)
        {
            DataTable rows = GetGridRows(procedureName, parms);
            var total = rows.Rows.Count;
            return new GridData()
            {
                Rows = rows,
                Total = total
            };
        }

        public virtual int GetGridTotal(string view, string where, FilterParam[] parms)
        {
            string commandText = "SELECT count(*) FROM [{0}] WHERE {1}".FormatWith(view, where.IsNullOrEmpty() ? "1=1" : where);
            //创建command
            var cmd = this.CreateCommand(commandText, parms);
            //使用liger.Data内置的数据适配器预处理command
            this.DbProvider.PrepareCommand(cmd);
            //执行command
            return (int)DbContext.ExecuteScalar(cmd);
        }




        /// <summary>
        /// 默认的 N-M行    分页方案： 
        /// 1，根据条件和排序 检索出全部前M行数据 
        /// 2，对这M行数据反转(排序反转) 
        /// 3，对反转完的数据，取前 M-N+1 行
        /// 4，取完数据以后，再次反转
        /// 如：select * from (select top [M-N+1] * from (select top [M] * from 表 [order by id desc]) [order by id asc]) [order by id desc]
        /// </summary>
        /// <param name="view"></param>
        /// <param name="where"></param>
        /// <param name="sortname"></param>
        /// <param name="sortorder"></param>
        /// <param name="pagenumber"></param>
        /// <param name="pagesize"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public virtual DataTable GetGridRows(string view, string where, string sortname, string sortorder, int? pagenumber, int? pagesize, FilterParam[] parms)
        {
            string commandText = ""; 
            bool pagable = pagenumber.HasValue && pagesize.HasValue;
            bool sortable = !sortname.IsNullOrEmpty() && !sortorder.IsNullOrEmpty(); 
            if (pagable)
            { 
                string sql = "SELECT TOP {2} * FROM [{0}] WHERE {1}".FormatWith(view, where.IsNullOrEmpty() ? "1=1" : where, (pagenumber.Value * pagesize.Value).ToString());

                commandText = " SELECT * FROM (SELECT TOP {PAGESIZE} * FROM ({OLDSQL} {ORDER}) AS tmptableinner {REVORDER}) AS tmptableouter {ORDER} ";
                commandText = commandText.Replace("{PAGESIZE}", pagesize.Value.ToString());
                if (sortable)
                {
                    commandText = commandText.Replace("{ORDER}", string.Concat("ORDER BY " ,sortname," ", sortorder.EqualsTo("asc") ? "ASC" : "DESC"));
                    commandText = commandText.Replace("{REVORDER}", string.Concat("ORDER BY ", sortname, " ", sortorder.EqualsTo("asc") ? "DESC" : "ASC"));
                }
                else
                {
                    throw new Exception("必须指定一个排序条件");
                }
                commandText = commandText.Replace("{OLDSQL}", sql);
            }
            else
            {
                commandText = "SELECT * FROM [{VIEW}] WHERE {WHERE} "; 
                if (sortable)
                {
                    commandText += string.Concat(" ORDER BY ", sortname, " ", sortorder.EqualsTo("asc") ? "ASC" : "DESC");
                }
                commandText = commandText.Replace("{WHERE}", where.IsNullOrEmpty() ? "1=1" : where);
                commandText = commandText.Replace("{VIEW}", view);
            }
            //创建command
            var cmd = this.CreateCommand(commandText, parms);
            //使用liger.Data内置的数据适配器预处理command
            this.DbProvider.PrepareCommand(cmd);
            //执行command
            var ds = this.DbContext.ExecuteDataSet(cmd);
            if (ds == null || ds.Tables.Count == 0) 
                return null;
            return ds.Tables[0];
        }

        public virtual DataTable GetGridRows(string view,string columns, string where, string sortname, string sortorder, int? pagenumber, int? pagesize, FilterParam[] parms)
        {
            string commandText = "";
            bool pagable = pagenumber.HasValue && pagesize.HasValue;
            bool sortable = !sortname.IsNullOrEmpty() && !sortorder.IsNullOrEmpty();
            if (pagable)
            {
                string sql = "SELECT TOP {2} " + columns + " FROM [{0}] WHERE {1}";
                sql = sql.FormatWith(view, where.IsNullOrEmpty() ? "1=1" : where, (pagenumber.Value * pagesize.Value).ToString());

                commandText = " SELECT "+columns+" FROM (SELECT TOP {PAGESIZE} "+columns+" FROM ({OLDSQL} {ORDER}) AS tmptableinner {REVORDER}) AS tmptableouter {ORDER} ";
                commandText = commandText.Replace("{PAGESIZE}", pagesize.Value.ToString());
                if (sortable)
                {
                    commandText = commandText.Replace("{ORDER}", string.Concat("ORDER BY ", sortname, " ", sortorder.EqualsTo("asc") ? "ASC" : "DESC"));
                    commandText = commandText.Replace("{REVORDER}", string.Concat("ORDER BY ", sortname, " ", sortorder.EqualsTo("asc") ? "DESC" : "ASC"));
                }
                else
                {
                    throw new Exception("必须指定一个排序条件");
                }
                commandText = commandText.Replace("{OLDSQL}", sql);
            }
            else
            {
                commandText = "SELECT "+columns+" FROM [{VIEW}] WHERE {WHERE} ";
                if (sortable)
                {
                    commandText += string.Concat(" ORDER BY ", sortname, " ", sortorder.EqualsTo("asc") ? "ASC" : "DESC");
                }
                commandText = commandText.Replace("{WHERE}", where.IsNullOrEmpty() ? "1=1" : where);
                commandText = commandText.Replace("{VIEW}", view);
            }
            //创建command
            var cmd = this.CreateCommand(commandText, parms);
            //使用liger.Data内置的数据适配器预处理command
            this.DbProvider.PrepareCommand(cmd);
            //执行command
            var ds = this.DbContext.ExecuteDataSet(cmd);
            if (ds == null || ds.Tables.Count == 0)
                return null;
            return ds.Tables[0];
        }


        public virtual DataTable GetGridRows(string procedureName,DbParameter[] parms)
        {
            //创建command
            var cmd = CreateCommand(procedureName, parms);
            //使用liger.Data内置的数据适配器预处理command
            this.DbProvider.PrepareCommand(cmd);
            //执行command
            var ds = this.DbContext.ExecuteDataSet(cmd);
            if (ds == null || ds.Tables.Count == 0) 
                return null;
            return ds.Tables[0];
        }

        public virtual DbCommand CreateCommand(string commandText, FilterParam[] parms)
        {
            var cmd = this.DbProvider.DbProviderFactory.CreateCommand();
            cmd.CommandText = commandText;
            if (parms != null)
            {
                foreach (var parm in parms)
                {
                    DbParameter p = this.DbProvider.DbProviderFactory.CreateParameter();
                    p.ParameterName = this.DbProvider.ParamPrefix + parm.Name;
                    p.Value = parm.Value;
                    cmd.Parameters.Add(p);
                }
            }
            return cmd;
        }

        public virtual DbCommand CreateCommand(string commandText, DbParameter[] parms)
        {
            var cmd = this.DbProvider.DbProviderFactory.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = commandText;
            if (parms != null)
            {
                for(int i=0;i<parms.Count();i++)
                {
                    cmd.Parameters.Add(parms[i]);
                }
            }
            return cmd;
        }
    }
}
