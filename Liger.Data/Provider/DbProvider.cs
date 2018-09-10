using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Data;
using System.Data.Common;
using Liger.Data.Extensions;
using Liger.Common;
using Liger.Data.Resources;
using System.Text.RegularExpressions;

namespace Liger.Data
{
    public abstract class DbProvider
    {
        internal static readonly string SQL_PAGING = " SELECT * FROM (SELECT TOP {M_N_1} * FROM ({OLDSQL} {OLDORDER}) AS tmptableinner {REVORDER}) AS tmptableouter {ORDER} ";

        /// <summary>
        /// isnull([Orders].[Freight],0)
        /// group[1]:[Orders].[Freight]
        /// group[2]:0
        /// </summary>
        internal static readonly Regex REGEX_ISNULL = new Regex(@"isnull\((.*?),(.*?)\)", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);



        #region 几个内部成员 
        protected char leftToken; 
        protected char paramPrefixToken; 
        protected char rightToken; 
        protected DbProviderFactory dbProviderFactory;
        protected DbConnectionStringBuilder dbConnStrBuilder;
        #endregion
         

        #region 构造函数
        /// <summary>
        /// 实例化一个DbProvider
        /// </summary>
        /// <param name="connectionString">链接字符串</param>
        /// <param name="dbProviderFactory">MS DbProviderFactory</param>
        /// <param name="leftToken">表/字段前缀</param>
        /// <param name="rightToken">表/字段后缀</param>
        /// <param name="paramPrefixToken">参数前缀</param>
        protected DbProvider(string connectionString, DbProviderFactory dbProviderFactory, char leftToken, char rightToken, char paramPrefixToken)
        {
            dbConnStrBuilder = new DbConnectionStringBuilder();
            dbConnStrBuilder.ConnectionString = connectionString;
            this.dbProviderFactory = dbProviderFactory;
            this.leftToken = leftToken;
            this.rightToken = rightToken;
            this.paramPrefixToken = paramPrefixToken;
            this.CacheConfig = new DbCacheConfiguration();
            this.EntitiesCache = new Dictionary<string, CacheInfo>();
        }
        #endregion


        #region 属性

        /// <summary>
        /// ConnectionStrings 节点名称
        /// </summary>
        public string ConnectionStringsName { get; set; } 
        /// <summary>
        /// 链接字符串
        /// </summary> 
        public string ConnectionString
        {
            get
            {
                return dbConnStrBuilder.ConnectionString;
            }
        } 
        /// <summary>
        /// System.Data.Common.DbProviderFactory
        /// </summary> 
        public DbProviderFactory DbProviderFactory
        {
            get
            {
                return dbProviderFactory;
            }
        } 
        /// <summary>
        /// 参数前缀
        /// </summary>
        public char ParamPrefix { get { return paramPrefixToken; } }

        /// <summary>
        ///  表/字段 前缀
        /// </summary>
        public char LeftToken { get { return leftToken; } }

        /// <summary>
        /// 表/字段 后缀
        /// </summary>
        public char RightToken { get { return rightToken; } }

        #endregion
          

        #region 缓存支持
         
        /// <summary>
        /// 缓存
        /// </summary>
        internal DbCacheConfiguration CacheConfig { get; set; }
         
        /// <summary>
        /// 实体缓存
        /// </summary>
        internal Dictionary<string, CacheInfo> EntitiesCache { get; set; }

        #endregion


        /// <summary>
        /// 自增长字段查询语句
        /// </summary>
        public abstract string RowAutoID
        {
            get;
        }

        /// <summary>
        /// 是否支持批量sql提交
        /// </summary>
        public abstract bool SupportBatch
        {
            get;
        }

        /// <summary>
        /// 格式化表名
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public virtual string BuildTableName(string name)
        {
            return string.Concat(leftToken.ToString(), name.Trim(leftToken, rightToken), rightToken.ToString());
        }

        #region Dbcommand
        /// <summary>
        /// 格式化参数名
        /// 移除前后缀，加上参数前缀
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public virtual string BuildParameterName(string name)
        {
            string nameStr = name.Trim(leftToken, rightToken);
            if (nameStr[0] != paramPrefixToken)
            {
                return paramPrefixToken + nameStr;
            }
            return nameStr;
        }
        /// <summary>
        /// 调整DbCommand命令
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public virtual void PrepareCommand(DbCommand cmd)
        {
            cmd.CommandText = DataHelper.FormatSQL(cmd.CommandText, leftToken, rightToken); 
            foreach (DbParameter p in cmd.Parameters)
            {
                if (cmd.CommandText.IndexOf(p.ParameterName) == -1)
                    cmd.CommandText = cmd.CommandText.Replace(p.ParameterName.Substring(1), p.ParameterName); 
                if (p.Direction == ParameterDirection.Output || p.Direction == ParameterDirection.ReturnValue)
                {
                    continue;
                } 
                object value = p.Value;
                DbType dbType = p.DbType; 
                if (value == DBNull.Value || value == null)
                {
                    continue;
                }  
                Type type = value.GetType(); 
                if (type.IsEnum)
                {
                    p.DbType = DbType.Int32;
                    p.Value = Convert.ToInt32(value);
                    continue;
                }
                if (TypeHelper.IsInteger(type))
                {
                    p.DbType = DbType.Int32;
                    p.Value = Convert.ToInt32(value);
                    continue; 
                }
                if (dbType == DbType.Guid && type != typeof(Guid))
                {
                    p.Value = new Guid(value.ToString());
                    continue;
                } 
                if (type == typeof(Boolean))
                {
                    p.Value = (((bool)value) ? 1 : 0);
                    continue;
                }
            }
        }

        /// <summary>
        /// 创建一个Dbcommand
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="Parms"></param>
        /// <returns></returns>
        public virtual DbCommand CreateCommand(string commandText, QueryParameter[] Parms)
        {
            var cmd = this.dbProviderFactory.CreateCommand();
            cmd.CommandText = commandText;
            if (Parms != null)
            {
                foreach (var parm in Parms)
                {
                    DbParameter p = this.DbProviderFactory.CreateParameter();
                    p.ParameterName = this.BuildParameterName(parm.Name);
                    p.Value = parm.Value;
                    if (parm.DbType.HasValue)
                        p.DbType = parm.DbType.Value; 
                    if (parm.Size.HasValue)
                        p.Size = parm.Size.Value; 
                    cmd.Parameters.Add(p);
                }
            }
            return cmd;
        }
        #endregion 

        #region 解析SQL


        /// <summary>
        /// 创建一个翻译体(一般用于子查询)
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        internal ExpressionTranslater CreateTranslater(Entity table)
        {
            return new ExpressionTranslater(this, new EntityQueryExpression(table));
        }


        /// <summary>
        /// 对翻译体进行  翻译前调整
        /// 主要是针对表达式做调整
        /// </summary>
        /// <param name="translater"></param>
        public virtual void PrepareTranslater(ExpressionTranslater translater)
        {
            var exp = translater.Expression;
            if (exp.IsPagable)
            {
                exp.IsDistinct = false;
                exp.GroupBy = null;
                exp.IsOrderBy = false;
            }
            else if(exp.IsSkip)
            {
                PrepareSkip(translater);
            }
        }
        /// <summary>
        /// 跳过N行
        /// 实现方案： 根据排序和条件检索出全部数据
        /// 再加入一个条件：id 大于/或小于(需要根据排序来判断) 前N行记录ID的最大/最小值
        /// </summary>
        /// <param name="translater"></param>
        protected virtual void PrepareSkip(ExpressionTranslater translater)
        {
            var exp = translater.Expression;
            var idField = exp.From.GetIdentityField();
            if ((idField as object) == null)
                throw new NotImplementedException(TextResource.AutoKeyToSearchAllow); 
            var IsIdentityFieldDesc = exp.IsIdentityFieldDesc; 
            //子查询
            var subTableName = "subtable";
            var subId = idField.SetTableName(subTableName);
            var subTable = DataHelper.Clone(exp.From) as Entity;
            subTable.SetAliasName(subTableName);
            var subExp = new EntityQueryExpression(subTable);
            //前N行记录ID的最大/最小值
            if(IsIdentityFieldDesc)
                subExp.Select = new SelectExpression(new Field[] { subId.Min() });
            else
                subExp.Select = new SelectExpression(new Field[] { subId.Max() });
            //复制条件与排序
            subExp.Where = exp.Where.Clone();
            subExp.Where.SetTable(subTableName);
            subExp.OrderByList = exp.OrderByList.Clone().SetTable(subTableName);
            //再加入一个条件：id 大于/或小于(需要根据排序来判断) 前N行记录ID的最大/最小值
            var newWhere = WhereExpression.Create(exp.From.GetIdentityField(), subExp,
                IsIdentityFieldDesc ? QueryOperator.Less : QueryOperator.Greater);  
            exp.Where = WhereExpression.Create(exp.Where, newWhere, QueryOperator.And);
        }

        /// <summary>
        /// 获取Sq语句中 "select" 和 字段之间 的部分(如果需要)
        /// </summary>
        /// <returns></returns>
        public virtual string GetSQLSelectTopClip(ExpressionTranslater translater)
        {
            StringBuilder str = new StringBuilder(); 
            var exp = translater.Expression;
            if (exp.IsPagable)
            {
                str.Append(ExpressionTranslater.SQL_TOP + exp.EndIndex + " ");
            }
            else if (exp.IsTop)
            {
                str.Append(ExpressionTranslater.SQL_TOP + exp.EndIndex + " ");
            }
            return str.ToString();
        }

        /// <summary>
        /// 对翻译的结果进行调整
        /// 1,N-M行模式、跳过N行、前M行 处理(可结合GetSQLSelectTopClip)
        /// 2,SQL格式化
        /// </summary>
        /// <param name="translater"></param>
        /// <returns></returns>
        public virtual void AdjustTranslater(ExpressionTranslater translater)
        {
            var exp = translater.Expression;
            if (exp.IsPagable)
                AdjustPagable(translater);  
        }
           

        /// <summary>
        /// N-M行  针对可分页进行调整
        /// 方案： 
        /// 1，根据条件和排序 检索出全部前M行数据(在GetSQLSelectTopClip已经完成了这一步)
        /// 2，对这M行数据反转(排序反转) 
        /// 3，对反转完的数据，取前 M-N+1 行
        /// 4，取完数据以后，再次反转
        /// 如：select * from (select top [M-N+1] * from (select top [M] * from 表 [order by id desc]) [order by id asc]) [order by id desc]
        /// 有一个条件：必须存在排序，如果不存在创建一个
        /// </summary>
        /// <param name="translater"></param>
        /// <returns></returns>
        protected virtual void AdjustPagable(ExpressionTranslater translater)
        {
            var oldSQL = translater.CommandText;
            var exp = translater.Expression;
            var sql = SQL_PAGING.ToString();
            IList<OrderByExpression> orderby = exp.IsOrderBy ? exp.OrderByList : new List<OrderByExpression>(){
                new OrderByExpression(exp.From.GetIdentityField(), OrderByDirection.Asc)
            };
            sql = sql.Replace("{M_N_1}", (exp.EndIndex.Value - exp.StartIndex.Value + 1).ToString());
            sql = sql.Replace("{OLDORDER}", exp.IsOrderBy ? "" : translater.TranslateOrderyByList(orderby, false));
            sql = sql.Replace("{REVORDER}", translater.TranslateOrderyByList(orderby, true));
            sql = sql.Replace("{ORDER}", translater.TranslateOrderyByList(orderby, false));
            sql = sql.Replace("{OLDSQL}", oldSQL);
            translater.SetCommandText(sql);
        }
        #endregion


    }
}
