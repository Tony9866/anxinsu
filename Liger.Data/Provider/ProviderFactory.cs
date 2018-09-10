using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Liger.Common;

namespace Liger.Data
{
    /// <summary>
    /// 数据驱动 工厂 DbProvider
    /// </summary>
    public sealed class ProviderFactory
    {
        #region Private Members

        private static Dictionary<string, DbProvider> providerCache = new Dictionary<string, DbProvider>();

        private ProviderFactory() { }

        #endregion

        #region Public Members

        /// <summary>
        /// 创建一个 db provider.
        /// </summary>
        /// <param name="assemblyName">程序集名</param>
        /// <param name="className">类名</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns>Db provider.</returns>
        public static DbProvider CreateDbProvider(string assemblyName, string className, string connectionString)
        {
            Guard.IsNotNullOrEmpty(connectionString, "connectionString");
            //首先判断ConnectionString是否不是Access驱动
            if (connectionString.IndexOf("microsoft.jet.oledb", StringComparison.OrdinalIgnoreCase) > -1 || connectionString.IndexOf(".db3", StringComparison.OrdinalIgnoreCase) > -1)
            {
                Guard.Check(connectionString.IndexOf("data source", StringComparison.OrdinalIgnoreCase) > -1, "ConnectionString的格式有错误，请检查");

                string mdbPath = connectionString.Substring(connectionString.IndexOf("data source", StringComparison.OrdinalIgnoreCase) + "data source".Length + 1).TrimStart(' ', '=');
                if (mdbPath.ToLower().StartsWith("|datadirectory|"))
                {
                    mdbPath = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\') + "\\App_Data" + mdbPath.Substring("|datadirectory|".Length);
                }
                else if (connectionString.StartsWith("./") || connectionString.EndsWith(".\\"))
                {
                    connectionString = connectionString.Replace("/", "\\").Replace(".\\", AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\') + "\\");
                }
                connectionString = connectionString.Substring(0, connectionString.ToLower().IndexOf("data source")) + "Data Source=" + mdbPath;
            }

            //如果是~则表示当前目录
            if (connectionString.Contains("~/") || connectionString.Contains("~\\"))
            {
                connectionString = connectionString.Replace("/", "\\").Replace("~\\", AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\') + "\\");
            }

            //默认使用sqlserver db provider
            if (string.IsNullOrEmpty(className))
            {
                className = typeof(SqlServer.SqlServerProvider).ToString();
            }
            else if (string.Compare(className, "System.Data.SqlClient", true) == 0 || string.Compare(className, "Liger.Data.SqlServer", true) == 0)
            {
                className = typeof(SqlServer.SqlServerProvider).ToString();
            }
            else if (string.Compare(className, "Liger.Data.SqlServer9", true) == 0 || className.IndexOf("SqlServer9", StringComparison.OrdinalIgnoreCase) >= 0 || className.IndexOf("sqlserver2005", StringComparison.OrdinalIgnoreCase) >= 0 || className.IndexOf("sql2005", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                className = typeof(SqlServer9.SqlServer9Provider).ToString();
            }
            else if (className.IndexOf("oracle", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                className = typeof(Oracle.OracleProvider).ToString();
            }
            else if (className.IndexOf("access", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                className = typeof(MsAccess.MsAccessProvider).ToString();
            }
            //待实现
            else if (className.IndexOf("mysql", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                className = "Liger.Data.MySql.MySqlProvider";
                assemblyName = "Liger.Data.MySql";
            }
            //待实现
            else if (className.IndexOf("sqlite", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                className = "Liger.Data.Sqlite.SqliteProvider";
                assemblyName = "Liger.Data.Sqlite";
            }

            string cacheKey = string.Concat(assemblyName, className, connectionString);
            if (providerCache.ContainsKey(cacheKey))
            {
                return providerCache[cacheKey];
            }
            else
            {
                System.Reflection.Assembly ass;

                if (assemblyName == null)
                {
                    ass = typeof(DbProvider).Assembly;
                }
                else
                {
                    ass = System.Reflection.Assembly.Load(assemblyName);
                }

                DbProvider retProvider = ass.CreateInstance(className, false, System.Reflection.BindingFlags.Default, null, new object[] { connectionString }, null, null) as DbProvider;
                providerCache.Add(cacheKey, retProvider);
                return retProvider;
            }
        }

        /// <summary>
        /// 获取默认的 db provider(读取最后一个ConnectionStrings节点)
        /// </summary>
        /// <value>The default.</value>
        public static DbProvider Default
        {
            get
            {
                try
                {
                    if (ConfigurationManager.ConnectionStrings.Count > 0)
                    {
                        DbProvider dbProvider;
                        ConnectionStringSettings connStrSetting = ConfigurationManager.ConnectionStrings[ConfigurationManager.ConnectionStrings.Count - 1];
                        string[] assAndClass = connStrSetting.ProviderName.Split(',');
                        if (assAndClass.Length > 1)
                        {
                            dbProvider = CreateDbProvider(assAndClass[1].Trim(), assAndClass[0].Trim(), connStrSetting.ConnectionString);
                        }
                        else
                        {
                            dbProvider = CreateDbProvider(null, assAndClass[0].Trim(), connStrSetting.ConnectionString);
                        }

                        dbProvider.ConnectionStringsName = connStrSetting.Name;

                        return dbProvider;
                    }
                    return null;
                }
                catch
                {
                    return null;
                }
            }
        }

        public static DbProvider Custome
        {
            get
            {
                try
                {
                        DbProvider dbProvider;
                        dbProvider = CreateDbProvider("CustomeConfig");
                        return dbProvider;
                }
                catch
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 创建 db provider.
        /// </summary>
        /// <param name="connStrName">ConnectionString 节点名</param>
        /// <returns>The db provider.</returns>
        public static DbProvider CreateDbProvider(string connStrName)
        { 
            Guard.IsNotNullOrEmpty(connStrName, "connStrName"); 
            DbProvider dbProvider;
            ConnectionStringSettings connStrSetting = ConfigurationManager.ConnectionStrings[connStrName];
            Guard.Check(connStrSetting != null, string.Concat("在配置文件中找不到名字为 ", connStrName, " 的ConnectionString 节点"));

            string[] assAndClass = connStrSetting.ProviderName.Split(',');
            if (assAndClass.Length > 1)
            {
                dbProvider = CreateDbProvider(assAndClass[0].Trim(), assAndClass[1].Trim(), connStrSetting.ConnectionString);
            }
            else
            {
                dbProvider = CreateDbProvider(null, assAndClass[0].Trim(), connStrSetting.ConnectionString);
            }

            dbProvider.ConnectionStringsName = connStrName;

            return dbProvider;
        }

        #endregion
    }
}
