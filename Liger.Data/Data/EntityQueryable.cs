using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Liger.Common;
using Liger.Common.Extensions;
using Liger.Data.Resources; 
namespace Liger.Data
{
    public interface IEntityQueryable
    {
        EntityQueryExpression Expression { get; set; }
        object ToScalar();
        TObject ToScalar<TObject>(); 
        DataSet ToDataSet();
        DataTable ToDataTable();

    }

    public interface IEntityQueryable<T>
    {
        T ToFirst();
        List<T> ToList();
    }

    /// <summary>
    /// 一个实例代表一个查询
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EntityQueryable<T> : IEntityQueryable<T> , IEntityQueryable 
        where T : Entity
    { 
        #region 属性 适配器、表达式、主表 
        /// <summary>
        /// 数据适配器
        /// </summary>
        public DbProvider DbProvider
        {
            get
            {
                return database.DbProvider;
            }
        }
        internal Database database { get; private set; }
        /// <summary>
        /// 主表达式
        /// </summary>
        public EntityQueryExpression Expression { get; set; } 
        /// <summary>
        /// 主表/视图
        /// </summary>
        internal Entity Table { get; set; }

        /// <summary>
        /// 事务   -- 查询
        /// </summary>
        protected DbTransaction trans;
        #endregion

        #region 构造函数
        public EntityQueryable(Database db) 
        {
            this.database = db;
            this.Expression = new EntityQueryExpression(DataHelper.Create<T>());
        } 
        public EntityQueryable(Database db, DbTransaction trans)
            :this(db)
        { 
            this.trans = trans;
        }
        #endregion

        #region 投影、查询、聚合、筛选、Distinct
        /// <summary>
        /// 投影  更新EntityQueryExpress，并返回 EntityQueryable以便继续操作
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        public EntityQueryable<T> Select(params Field[] fields)
        {
            this.Expression.AddSelect(fields);
            return this;
        } 
        /// <summary>
        /// 查询  更新EntityQueryExpress，并返回 EntityQueryable以便继续操作
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public EntityQueryable<T> Where(WhereExpression expression)
        {
            this.Expression.AddWhere(expression);
            return this;
        }

         /// <summary>
        /// 排序 更新EntityQueryExpress，并返回 EntityQueryable以便继续操作
         /// </summary>
         /// <param name="expression"></param>
         /// <returns></returns>
        public EntityQueryable<T> OrderBy(params OrderByExpression[] exps)
        {
            this.Expression.AddOrderBy(exps);
            return this;
        }
        /// <summary>
        /// 分组 更新EntityQueryExpress，并返回 EntityQueryable以便继续操作
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public EntityQueryable<T> GroupBy(params Field[] exps)
        {
            this.Expression.AddGroupBy(exps);
            return this;
        }

        public EntityQueryable<T> Having(WhereExpression exp)
        {
            this.Expression.AddGroupByHaving(exp);
            return this;
        }



        /// <summary>
        /// Distinct操作
        /// </summary>
        /// <returns></returns>
        public EntityQueryable<T> Distinct()
        {
            this.Expression.IsDistinct = true;
            return this;
        }
        #endregion 

        #region 链接
        public EntityQueryable<T> LeftJoin<TJOIN>(WhereExpression expression)
            where TJOIN : Entity
        {
            return Join<TJOIN>(expression, JoinType.LeftJoin);
        }

        public EntityQueryable<T> RightJoin<TJOIN>(WhereExpression expression)
            where TJOIN : Entity
        {
            return Join<TJOIN>(expression, JoinType.RightJoin);
        }

        public EntityQueryable<T> InnerJoin<TJOIN>(WhereExpression expression)
            where TJOIN : Entity
        {
            return Join<TJOIN>(expression, JoinType.InnerJoin);
        }
        public EntityQueryable<T> CrossJoin<TJOIN>(WhereExpression expression)
          where TJOIN : Entity
        {
            return Join<TJOIN>(expression, JoinType.CrossJoin);
        }
        public EntityQueryable<T> Join<TJOIN>(WhereExpression expression)
            where TJOIN : Entity
        {
            return Join<TJOIN>(expression, JoinType.InnerJoin);
        }
        public EntityQueryable<T> Join<TJOIN>(WhereExpression expression, JoinType joinType)
            where TJOIN : Entity
        {
            var joinEntity = DataHelper.Create<TJOIN>();
            var joinExp = new JoinExpression(joinEntity, expression, joinType);
            this.Expression.AddJoin(joinEntity,joinExp);
            return this;
        }
        #endregion
         
        #region 只搜索前N行、分页、跳过几行
        /// <summary>
        /// 跳过行
        /// </summary>
        /// <param name="skip"></param>
        /// <returns></returns>
        public EntityQueryable<T> Skip(int skip)
        {
            this.Expression.StartIndex = skip;
            return this;
        }
        public EntityQueryable<T> Top(int top)
        {
            if (this.Expression.StartIndex == null)
                this.Expression.StartIndex = 0;
            this.Expression.EndIndex = this.Expression.StartIndex + top;
            return this;
        }
        public EntityQueryable<T> Page(int pageSize, int pageNumber)
        {
            this.Expression.StartIndex = (pageNumber - 1) * pageSize;
            this.Expression.EndIndex = pageNumber * pageSize - 1;
            return this;
        }
        #endregion 

        #region DbCommand操作
        protected IDataReader ToDataReader(DbCommand cmd)
        { 
            if (trans == null)
                return database.ExecuteReader(cmd);
            else
                return database.ExecuteReader(cmd, trans);
        }
        protected object ExecuteScalar(DbCommand cmd)
        {
            if (trans == null)
                return database.ExecuteScalar(cmd);
            else
                return database.ExecuteScalar(cmd, trans);
        }
        protected DataSet ToDataSet(DbCommand cmd)
        {
            if (trans == null)
                return database.ExecuteDataSet(cmd);
            else
                return database.ExecuteDataSet(cmd, trans);
        }
        #endregion
         
        #region 缓存
        private bool enabledCache
        {
            get
            {
                if (!this.DbProvider.CacheConfig.Enable)
                    return false;
                if (!this.DbProvider.EntitiesCache.ContainsKey(EntityHelper.GetName<T>()))
                    return false;
                return true;
            }
        }
        private CacheInfo cacheInfo
        {
            get
            {
                if (enabledCache) return null;
                return this.DbProvider.EntitiesCache[EntityHelper.GetName<T>()];
            }
        }
        private void AddCache(string key, object obj)
        {
            if (!enabledCache)
                return;
            var info = cacheInfo;
            if (info.TimeOut != null)
                CacheHelper.Insert(key, obj, info.TimeOut.Value);
            else if (!info.FilePath.IsNullOrEmpty())
                CacheHelper.Insert(key, obj, new System.Web.Caching.CacheDependency(info.FilePath));
        }
        private object getCache(string key)
        {
            if (!enabledCache) return null;
            return CacheHelper.Get(key);
        }
        private void removeCache(string key)
        {
            if (!enabledCache) return;
            CacheHelper.Remove(key);
        }
        #endregion 

        #region 数据库检索前处理
        /// <summary>
        /// 设置表达式为一条记录
        /// </summary>
        private void SetOneRecord()
        {
            if (this.Expression.IsSkip)
                this.Expression.EndIndex = this.Expression.StartIndex.Value + 1;
            else
                this.Expression.EndIndex = 1;
        }
        /// <summary>
        /// 根据当前的表达式，获取Command
        /// </summary>
        private DbCommand CreateCurrentCommand()
        {
            var traslater = new ExpressionTranslater(this.DbProvider, this.Expression);
            traslater.Translate();
            var command = DbProvider.CreateCommand(traslater.CommandText, traslater.Params.ToArray());
            return command;
        }
        /// <summary>
        /// 获取CacheKey
        /// </summary>
        /// <param name="type">操作类型</param>
        /// <param name="commandText">commandText</param>
        /// <returns></returns>
        private string GetCacheKey(string type, string commandText)
        {
            return string.Concat(this.DbProvider.ConnectionStringsName, "_" + type + "_", commandText);
        }
        #endregion

        #region Count、ToScalar、ToFirst、ToList、Exist

        /// <summary>
        /// 记录总数
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            SetOneRecord();
            this.Expression.Select.Fields = new List<Field>()
            {
                new Field("count(*)").As("cnt")
            };
            var command = CreateCurrentCommand();
            string cacheKey = GetCacheKey("Count", command.CommandText);
            if (enabledCache)
            {
                object cacheValue = getCache(cacheKey);
                if (null != cacheValue)
                {
                    return (int)cacheValue;
                }
            }
            int returnValue = (int)ExecuteScalar(command);
            if (enabledCache)
            {
                AddCache(cacheKey, returnValue);
            }
            return returnValue;
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <returns></returns>
        public bool Any()
        {
            return this.Count() > 0;
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <returns></returns>
        public bool Exist()
        {
            return this.Count() > 0;
        }
 


        public object ToScalar()
        {
            SetOneRecord();
            var command = CreateCurrentCommand();
            string cacheKey = GetCacheKey("ToScalar", command.CommandText);
            if (enabledCache)
            {
                object cacheValue = getCache(cacheKey);
                if (null != cacheValue)
                {
                    return cacheValue;
                }
            } 
            object returnValue = ExecuteScalar(command); 
            if (enabledCache)
            {
                AddCache(cacheKey, returnValue);
            }
            return returnValue;
        }

        public TObject ToScalar<TObject>() 
        {
            return DataHelper.ConvertValue<TObject>(this.ToScalar());
        }

        public T ToFirst()
        {
            SetOneRecord(); 
            var command =CreateCurrentCommand();
            string cacheKey = GetCacheKey("ToFirst", command.CommandText);
            object cacheValue = getCache(cacheKey);
            if (null != cacheValue)
            {
                return cacheValue as T;
            }  
            var entity = EntityHelper.CreateTable<T>(); 
            using (IDataReader reader = ToDataReader(command))
            {
                if (reader.Read())
                {
                    var fields = this.Expression.SelectFields;
                    foreach (var field in fields)
                    {
                        if (field.PropertyName.Contains("*"))
                            continue;
                        //如果设置了 跟原来 属性名不同的别名，那么不加载
                        if (!string.IsNullOrEmpty(field.AliasName) && field.AliasName != field.PropertyName)
                            continue;
                        if (entity.GetFields().Any(c => c.PropertyName == field.PropertyName))
                            entity.SetValue(field.PropertyName, reader[field.PropertyName]);
                    }

                }
            }
            AddCache(cacheKey, entity);
            return entity as T;
        }

        public List<T> ToList()
        {
            var command = CreateCurrentCommand();
            string cacheKey = GetCacheKey("ToList", command.CommandText);
            object cacheValue = getCache(cacheKey);
            if (null != cacheValue)
            {
                return cacheValue as List<T>;
            }
            List<T> list = new List<T>();
            var fields = this.Expression.SelectFields;
            using (IDataReader reader = ToDataReader(command))
            {
                while (reader.Read())
                {
                    var entity = EntityHelper.CreateTable<T>(); 
                    foreach (var field in fields)
                    {
                        if (field.PropertyName.Contains("*"))
                            continue;
                        //如果设置了 跟原来 属性名不同的别名，那么不加载
                        if (!string.IsNullOrEmpty(field.AliasName) && field.AliasName != field.PropertyName)
                            continue;
                        if (!entity.GetFields().Any(c => c.PropertyName == field.PropertyName))
                            continue;
                        if (!Convert.IsDBNull(reader[field.PropertyName]))
                            entity.SetValue(field.PropertyName, reader[field.PropertyName]);
                    }
                    list.Add(entity);
                }
            }
            AddCache(cacheKey, list);
            return list;
        }


        public DataSet ToDataSet()
        {
            var command = CreateCurrentCommand();
            string cacheKey = GetCacheKey("ToDataSet", command.CommandText);
            object cacheValue = getCache(cacheKey);
            if (null != cacheValue)
            {
                return cacheValue as DataSet;
            }
            var ds = ToDataSet(command);
            AddCache(cacheKey, ds);
            return ds;
        }

        public DataTable ToDataTable()
        {
            var command = CreateCurrentCommand();
            var ds= ToDataSet(command);
            if (ds == null || ds.Tables.Count == 0) 
                return null;
            return ds.Tables[0];
        }
        #endregion
    }
}
