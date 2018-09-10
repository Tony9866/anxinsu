using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Liger.Data
{ 
    /// <summary>
    /// 连接类型
    /// </summary>
    public enum JoinType
    {
        /// <summary>
        /// 左链接
        /// </summary>
        LeftJoin,
        /// <summary>
        /// 右链接
        /// </summary>
        RightJoin,
        /// <summary>
        /// 内部链接
        /// </summary>
        InnerJoin, 
        /// <summary>
        /// 交叉链接
        /// </summary>
        CrossJoin
    }
}
