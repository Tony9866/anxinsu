using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using System.IO;
using System.Configuration;
using Liger.Common;
using Liger.Common.Extensions;
using Liger.Data.Resources;

namespace Liger.Data
{  
    public class DbContext
    {  
        private Database db; 
        private CommandBulider cmdBulider;
        private DbTrans DbTrans { get; set; }

        #region Cache

        /// <summary>
        /// 开启缓存
        /// </summary>
        public void TurnOnCache()
        {
            if (null != CacheConfig)
            {
                CacheConfig.Enable = true;
            }
        }


        /// <summary>
        /// 关闭缓存
        /// </summary>
        public void TurnOffCache()
        {
            if (null != CacheConfig)
            {
                CacheConfig.Enable = false;
            }
        }

        private CacheConfiguration CacheConfig
        {
            get { return db.DbProvider.CacheConfig; }
        }


        #endregion 

        #region Default


        /// <summary>
        /// 获取默认的DbContext
        /// </summary>
        public static DbContext Default = new DbContext(Database.Default);

        public static DbContext CurrentDB = new DbContext(Database.Custome);

        /// <summary>
        /// 设置默认的DbContext
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="connStr"></param>
        public static void SetDefault(DatabaseType dt, string connStr)
        {
            DbProvider provider = CreateDbProvider(dt, connStr);

            Default = new DbContext(new Database(provider));
        }

        /// <summary>
        /// 创建一个Db Provider
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="connStr"></param>
        /// <returns></returns>
        private static DbProvider CreateDbProvider(DatabaseType dt, string connStr)
        {
            DbProvider provider = null;
            if (dt == DatabaseType.SqlServer9)
            {
                provider = ProviderFactory.CreateDbProvider(null, typeof(Liger.Data.SqlServer9.SqlServer9Provider).FullName, connStr);
            }
            else if (dt == DatabaseType.SqlServer)
            {
                provider = ProviderFactory.CreateDbProvider(null, typeof(Liger.Data.SqlServer.SqlServerProvider).FullName, connStr);
            }
            else if (dt == DatabaseType.Oracle)
            {
                provider = ProviderFactory.CreateDbProvider(null, typeof(Liger.Data.Oracle.OracleProvider).FullName, connStr);
            }
            else if (dt == DatabaseType.MySql)
            {
                provider = ProviderFactory.CreateDbProvider("Liger.Data.MySql", "Liger.Data.MySql.MySqlProvider", connStr);
            }
            else if (dt == DatabaseType.Sqlite3)
            {
                provider = ProviderFactory.CreateDbProvider("Liger.Data.Sqlite", "Liger.Data.Sqlite.SqliteProvider", connStr);
            }
            else if (dt == DatabaseType.MsAccess)
            {
                provider = ProviderFactory.CreateDbProvider(null, typeof(Liger.Data.MsAccess.MsAccessProvider).FullName, connStr);
            }
            return provider;
        }

        /// <summary>
        /// 设置默认的DbContext
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <param name="className"></param>
        /// <param name="connStr"></param>
        public static void SetDefault(string assemblyName, string className, string connStr)
        {
            DbProvider provider = ProviderFactory.CreateDbProvider(assemblyName, className, connStr);
            if (provider == null)
            {
                throw new NotSupportedException(string.Format("Cannot construct DbProvider by specified parameters: {0}, {1}, {2}",
                    assemblyName, className, connStr));
            }

            Default = new DbContext(new Database(provider));
        }

        /// <summary>
        /// 设置默认的DbContext
        /// </summary>
        /// <param name="connStrName"></param>
        public static void SetDefault(string connStrName)
        {
            DbProvider provider = ProviderFactory.CreateDbProvider(connStrName);
            provider.ConnectionStringsName = connStrName;
            if (provider == null)
            {
                throw new NotSupportedException(string.Format("Cannot construct DbProvider by specified ConnectionStringName: {0}", connStrName));
            }

            Default = new DbContext(new Database(provider));
        }

        #endregion

        #region 构造函数
         
        private void initDbSesion()
        {
            cmdBulider = new CommandBulider(db); 
            object cacheConfig = System.Configuration.ConfigurationManager.GetSection("LigerCacheConfig"); 
            //如果定义了配置节点LigerCacheConfig,那么加载读取
            if (cacheConfig != null)
            {
                db.DbProvider.CacheConfig = cacheConfig as DbCacheConfiguration; 
                initCache();
            } 
        }
        private void initCache()
        { 
            Dictionary<string, CacheInfo> entitiesCache = new Dictionary<string, CacheInfo>();

            //获取缓存配制
            foreach (string key in db.DbProvider.CacheConfig.Entities.AllKeys)
            {
                if (key.IndexOf('.') > 0)
                {
                    string[] splittedKey = key.Split('.');
                    string entityName = splittedKey[1].Trim();
                    if (splittedKey[0].Trim() == db.DbProvider.ConnectionStringsName)
                    {
                        int expireSeconds = 0;
                        CacheInfo cacheInfo = new CacheInfo();
                        if (int.TryParse(db.DbProvider.CacheConfig.Entities[key].Value, out expireSeconds))
                        {
                            cacheInfo.TimeOut = expireSeconds;
                        }
                        else
                        {
                            string tempFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, db.DbProvider.CacheConfig.Entities[key].Value);
                            if (File.Exists(tempFilePath))
                            {
                                cacheInfo.FilePath = tempFilePath;
                            } 
                        } 
                        if (!cacheInfo.IsNullOrEmpty())
                        { 
                            if (entitiesCache.ContainsKey(entityName))
                                entitiesCache.Remove(entityName);

                            entitiesCache.Add(entityName, cacheInfo);
                        }
                    }
                }
            }

            db.DbProvider.EntitiesCache = entitiesCache;
        }

        /// <summary>
        /// 构造函数    使用默认  DbContext.Default
        /// </summary>
        public DbContext()
        {
            db = Database.Default;

            initDbSesion();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connStrName">config文件中connectionStrings节点的name</param>
        public DbContext(string connStrName)
        {
            this.db = new Database(ProviderFactory.CreateDbProvider(connStrName));
            this.db.DbProvider.ConnectionStringsName = connStrName;
            initDbSesion();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="db">已知的Database</param>
        public DbContext(Database db)
        {
            this.db = db;

            initDbSesion();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dt">数据库类别</param>
        /// <param name="connStr">连接字符串</param>
        public DbContext(DatabaseType dt, string connStr)
        {
            DbProvider provider = CreateDbProvider(dt, connStr);
            Guard.Check(provider != null, "Cannot construct DbProvider by specified parameters: {0}".FormatWith(connStr));
            this.db = new Database(provider);

            initDbSesion();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="assemblyName">程序集</param>
        /// <param name="className">类名</param>
        /// <param name="connStr">连接字符串</param>
        public DbContext(string assemblyName, string className, string connStr)
        {
            DbProvider provider = ProviderFactory.CreateDbProvider(assemblyName, className, connStr); 
            Guard.Check(provider != null, "Cannot construct DbProvider by specified parameters: {0}, {1}, {2}".FormatWith(assemblyName, className, connStr));
            this.db = new Database(provider);

            cmdBulider = new CommandBulider(db);

            initDbSesion();
        }

        #endregion

        #region 查询

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public EntityQueryable<T> From<T>()
            where T : Entity
        {
            return new EntityQueryable<T>(db);
        } 

        #endregion

        #region Database

        /// <summary>
        /// 注册一个 the SQL logger.
        /// </summary>
        /// <param name="handler">The handler.</param>
        public void Logging(LogHandler handler)
        {
            db.OnLog += handler;
        }

        /// <summary>
        /// 取消一个 the SQL logger.
        /// </summary>
        /// <param name="handler">The handler.</param>
        public void UnLogging(LogHandler handler)
        {
            db.OnLog -= handler;
        }

        /// <summary>
        /// Gets the db.
        /// </summary>
        /// <value>The db.</value>
        public Database Db
        {
            get
            {
                return this.db;
            }
        }

        /// <summary>
        /// 开始一个事务，必要时创建链接
        /// </summary>
        /// <returns>The begined transaction.</returns>
        public DbTrans BeginTransaction()
        {
            this.DbTrans = new DbTrans(db.BeginTransaction());
            return this.DbTrans;
        }

        /// <summary>
        /// 开始一个事务，必要时创建链接
        /// </summary>
        /// <param name="il">The il.</param>
        /// <returns>The begined transaction.</returns>
        public DbTrans BeginTransaction(System.Data.IsolationLevel il)
        {
            this.DbTrans = new DbTrans(db.BeginTransaction(il));
            return this.DbTrans; 
        }
        /// <summary>
        /// 回滚
        /// </summary>
        public void RollbackTransaction()
        {
            if (this.DbTrans != null)
            {
                this.DbTrans.Rollback(); 
            }
        }

        /// <summary>
        /// 提交
        /// </summary>
        /// <returns></returns>
        public void CommitTransaction()
        {
            if (this.DbTrans != null)
            {
                this.DbTrans.Commit(); 
            }
        }

        /// <summary>
        /// 关闭并取消事务
        /// </summary>
        public void CloseTransaction()
        {
            if (this.DbTrans != null)
            {
                this.DbTrans.Close();
                this.DbTrans = null;
            }
        }

        /// <summary>
        /// Closes the transaction.
        /// </summary>
        /// <param name="tran">The tran.</param>
        public void CloseTransaction(DbTransaction tran)
        {
            db.CloseConnection(tran);
        }

        /// <summary>
        /// Builds the name of the db param.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>The name of the db param</returns>
        public string BuildDbParamName(string name)
        {
            Guard.IsNotNullOrEmpty(name, "name");

            return db.DbProvider.BuildParameterName(name);
        }


        #endregion

        #region 更新操作

        /// <summary>
        /// 更新  
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public int Update<T>(T entity)
            where T : Entity
        {
            if (entity.GetChangedFields().Count == 0)
                return 0;

            WhereExpression where = DataHelper.GetPrimaryKeyWhere(entity);

            Guard.Check(!WhereExpression.IsNullOrEmpty(where), TextResource.MustSetupPK);

            return Update<T>(entity, where);
        }

        /// <summary>
        /// 更新  多条记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        public void Update<T>(params T[] entities)
            where T : Entity
        {
            if (null == entities || entities.Length == 0)
                return;
            if (this.DbTrans == null)
            {
                using (DbTrans trans = BeginTransaction())
                {
                    foreach (var entity in entities)
                    {
                        Update<T>(entity);
                    }
                    trans.Commit();
                }
            }
            else
            {
                foreach (var entity in entities)
                {
                    Update<T>(entity);
                }
            }
           
        }


        /// <summary>
        /// 更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update<T>(T entity, WhereExpression where)
            where T : Entity
        {
            if (entity.GetChangedFields().Count == 0)
                return 0;

            return ExecuteNonQuery(cmdBulider.CreateUpdateCommand<T>(entity, where));
        }
         
         
        /// <summary>
        /// 更新单个值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update<T>(Field field, object value, WhereExpression where)
            where T : Entity
        {
            if (Field.IsNullOrEmpty(field))
                return 0;

            return ExecuteNonQuery(cmdBulider.CreateUpdateCommand<T>(new Field[] { field }, new object[] { value }, where));
        }


        /// <summary>
        /// 更新多个值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fieldValue"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update<T>(Dictionary<Field, object> fieldValue, WhereExpression where)
              where T : Entity
        {
            if (null == fieldValue || fieldValue.Count == 0)
                return 0; 
            Field[] fields = new Field[fieldValue.Count];
            object[] values = new object[fieldValue.Count]; 
            int i = 0; 
            foreach (KeyValuePair<Field, object> kv in fieldValue)
            {
                fields[i] = kv.Key;
                values[i] = kv.Value; 
                i++;
            } 
            return ExecuteNonQuery(cmdBulider.CreateUpdateCommand<T>(fields, values, where));
        }

         
        /// <summary>
        /// 更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fields"></param>
        /// <param name="values"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update<T>(Field[] fields, object[] values, WhereExpression where)
            where T : Entity
        { 
            if (null == fields || fields.Length == 0)
                return 0; 
            return ExecuteNonQuery(cmdBulider.CreateUpdateCommand<T>(fields, values, where));
        }
 

        #endregion

        #region 删除操作
         
        /// <summary>
        ///  删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Delete<T>(T entity)
            where T : Entity
        {
            Guard.Check(!EntityHelper.IsReadOnly<T>(), TextResource.CanNotReadOnly.FormatWith(EntityHelper.GetName<T>())); 
            WhereExpression where = DataHelper.GetPrimaryKeyWhere(entity); 
            Guard.Check(!WhereExpression.IsNullOrEmpty(where), TextResource.MustSetupPK); 
            return Delete<T>(where);
        }
          

        /// <summary>
        ///  删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pkValues"></param>
        /// <returns></returns>
        public int Delete<T>(params object[] pkValues)
            where T : Entity
        {
            return DeleteByPrimaryKey<T>(pkValues);
        }

        /// <summary>
        ///  删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pkValues"></param>
        /// <returns></returns>
        public int Delete<T>(params string[] pkValues)
            where T : Entity
        {
            return DeleteByPrimaryKey<T>(pkValues);
        }

        /// <summary>
        ///  删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pkValues"></param>
        /// <returns></returns>
        internal int DeleteByPrimaryKey<T>(params object[] pkValues)
            where T : Entity
        {
            Guard.Check(!EntityHelper.IsReadOnly<T>(), TextResource.CanNotReadOnly.FormatWith(EntityHelper.GetName<T>())); 

            return ExecuteNonQuery(cmdBulider.CreateDeleteCommand(EntityHelper.GetName<T>(), DataHelper.GetPrimaryKeyWhere<T>(pkValues)));
        }  
         

        /// <summary>
        ///  删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete<T>(WhereExpression where)
            where T : Entity
        {
            Guard.Check(!EntityHelper.IsReadOnly<T>(), TextResource.CanNotReadOnly.FormatWith(EntityHelper.GetName<T>()));

            return ExecuteNonQuery(cmdBulider.CreateDeleteCommand(EntityHelper.GetName<T>(), where));
        }
         
        #endregion

        #region 添加操作

        /// <summary>
        /// 添加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>
        public void Insert<T>(params T[] entities)
            where T : Entity
        {
            if (null == entities || entities.Length == 0)
                return;
            foreach (var entity in entities)
            {
                Insert<T>(entity);
            }
        }



        /// <summary>
        /// 添加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Insert<T>(T entity)
            where T : Entity
        {
            return insertExecute<T>(cmdBulider.CreateInsertCommand<T>(entity));
        }
         
        /// <summary>
        /// 添加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fields"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public int Insert<T>(Field[] fields, object[] values)
            where T : Entity
        {
            return insertExecute<T>(cmdBulider.CreateInsertCommand<T>(fields, values));
        }
         
         


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmd"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        private int insertExecute<T>(DbCommand cmd)
             where T : Entity
        {
            if (null == cmd)
                return 0;

            Field identity = EntityHelper.GetIdentityField<T>();
            if (Field.IsNullOrEmpty(identity))
                return ExecuteNonQuery(cmd);
            else
            {
                object scalarValue = null;
                if (Db.DbProvider is MsAccess.MsAccessProvider)
                {
                    ExecuteNonQuery(cmd);
                    scalarValue = ExecuteScalar(db.GetSqlStringCommand(string.Format("select max({0}) from {1}", identity.FieldName, identity.TableName))); //Max<T, int>(identity, WhereExpression.All) + 1;

                } 
                else
                {
                    if (Db.DbProvider.SupportBatch)
                    {
                        cmd.CommandText = string.Concat(cmd.CommandText, ";", db.DbProvider.RowAutoID);
                        scalarValue = ExecuteScalar(cmd);
                    }
                    else
                    {
                        ExecuteNonQuery(cmd);
                        scalarValue = ExecuteScalar(db.GetSqlStringCommand(Db.DbProvider.RowAutoID));
                    }
                }

                if (null == scalarValue || Convert.IsDBNull(scalarValue))
                    return 0;
                return Convert.ToInt32(scalarValue);
            }
        }


        #endregion

        #region 执行command
         
        /// <summary>
        /// 执行ExecuteNonQuery
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(DbCommand cmd)
        { 
            if (null == cmd)
                return 0;
            if(this.DbTrans != null)
                return db.ExecuteNonQuery(cmd, this.DbTrans);
            else
                return db.ExecuteNonQuery(cmd);

        }  

        /// <summary>
        /// 执行ExecuteScalar
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public object ExecuteScalar(DbCommand cmd)
        { 
            if (null == cmd)
                return null;
            if (this.DbTrans != null)
                return db.ExecuteScalar(cmd, this.DbTrans);
            else
                return db.ExecuteScalar(cmd); 
        }

        /// <summary>
        /// 执行ExecuteReader
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public IDataReader ExecuteReader(DbCommand cmd)
        {
            if (null == cmd)
                return null;
            if (this.DbTrans != null)
                return db.ExecuteReader(cmd, this.DbTrans);
            else
                return db.ExecuteReader(cmd);  
        }
         

        /// <summary>
        /// 执行ExecuteDataSet
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(DbCommand cmd)
        {
            if (null == cmd)
                return null;
            if (this.DbTrans != null)
                return db.ExecuteDataSet(cmd, this.DbTrans);
            else
                return db.ExecuteDataSet(cmd);  
        } 

        public int ExecuteNonQuery(string commandText)
        {
            var cmd = db.CreateCommandByCommandType(CommandType.Text, commandText);
            return ExecuteNonQuery(cmd); 
        }

        public object ExecuteScalar(string commandText)
        {
            var cmd = db.CreateCommandByCommandType(CommandType.Text, commandText);
            return ExecuteScalar(cmd); 
        }
         
        public IDataReader ExecuteReader(string commandText)
        {
            var cmd = db.CreateCommandByCommandType(CommandType.Text, commandText);
            return ExecuteReader(cmd); 
        }

         
        public DataSet ExecuteDataSet(string commandText)
        {
            var cmd = db.CreateCommandByCommandType(CommandType.Text, commandText);
            return ExecuteDataSet(cmd); 
        }
         
        #endregion


    }
}
