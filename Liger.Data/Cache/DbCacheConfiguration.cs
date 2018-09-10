using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Liger.Common;


namespace Liger.Data
{
    /// <summary>
    /// 缓存配置 
    /// 比如： <section name="LigerDbCacheConfig" type="Liger.Data.CacheConfiguration,Liger.Data"/>
    /// </summary>
    public class DbCacheConfiguration : CacheConfiguration
    {
        /// <summary>
        /// 设置表缓存。  key: 数据连接节点.表名  value:时间或者文件名 
        /// 比如：
        /// <LigerDbCacheConfig enable="true">
        ///     <entities>
        ///         <add key="Db.Products" value="60"></add>
        ///     </entities>
        /// </LigerDbCacheConfig>
        /// </summary>
        [ConfigurationProperty("entities", IsRequired = true, IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(KeyValueConfigurationCollection))]
        public KeyValueConfigurationCollection Entities
        {
            get
            {
                return (KeyValueConfigurationCollection)this["entities"];
            }
        }
    }
}
