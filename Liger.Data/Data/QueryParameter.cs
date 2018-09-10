using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

namespace Liger.Data
{
    /// <summary>
    /// 参数
    /// </summary>
    [Serializable]
    public class QueryParameter
    {
        /// <summary>
        /// 参数名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 参数值
        /// </summary>
        public object Value { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public DbType? DbType { get; set; }
        /// <summary>
        /// 长度
        /// </summary>
        public int? Size { get; set; }

        /// <summary>
        /// 初始化QueryParameter
        /// </summary>
        /// <param name="pName"></param>
        public QueryParameter(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// 初始化QueryParameter
        /// </summary>
        /// <param name="pName"></param>
        /// <param name="pValue"></param>
        public QueryParameter(string name, object pValue)
            : this(name)
        {
            this.Value = pValue;
        }




        public QueryParameter(string name, object pValue,DbType? dbtype,int? size)
            : this(name)
        {
            this.Value = pValue;
            this.DbType = dbtype;
            this.Size = size;
        }
    }
}
