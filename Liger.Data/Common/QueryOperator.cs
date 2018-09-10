using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Liger.Data
{
    /// <summary>
    /// 运算类型
    /// </summary>
    public enum QueryOperator : byte
    {
        /// <summary>
        /// ==
        /// </summary>
        Equal,

        /// <summary>
        /// <>
        /// </summary>
        NotEqual,

        /// <summary>
        /// >
        /// </summary>
        Greater,

        /// <summary>
        /// <
        /// </summary>
        Less,

        /// <summary>
        /// >=
        /// </summary>
        GreaterOrEqual,

        /// <summary>
        /// <=
        /// </summary>
        LessOrEqual,

        /// <summary>
        /// LIKE
        /// </summary>
        Like,


        /// <summary>
        /// &&
        /// </summary>
        And,

        /// <summary>
        /// ||
        /// </summary>
        Or,

        /// <summary>
        /// &
        /// </summary>
        BitwiseAND,

        /// <summary>
        /// |
        /// </summary>
        BitwiseOR,

        /// <summary>
        /// ^
        /// </summary>
        BitwiseXOR,

        /// <summary>
        /// ~
        /// </summary>
        BitwiseNOT,

        /// <summary>
        /// IS NULL
        /// </summary>
        IsNULL,

        /// <summary>
        /// IS Not NULL
        /// </summary>
        IsNotNULL,

        /// <summary>
        ///  +
        /// </summary>
        Add,

        /// <summary>
        /// -
        /// </summary>
        Subtract,


        /// <summary>
        /// *
        /// </summary>
        Multiply,

        /// <summary>
        /// /
        /// </summary>
        Divide,

        /// <summary>
        /// %
        /// </summary>
        Modulo,

        /// <summary>
        /// in
        /// </summary>
        In,

        /// <summary>
        /// not in
        /// </summary>
        NotIn 
    }
}
