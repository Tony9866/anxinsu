using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Liger.Common;

namespace Liger.Data
{
    [Serializable]
    public class WhereExpression : IDbExpression, ICloneable<WhereExpression>, ITableResizable
    {
        public DbExpressionType ExpressionType
        {
            get
            {
                return DbExpressionType.Where;
            }
        }

        //左边表达式
        public WhereExpression Left { get; set; }

        //右边表示式
        public WhereExpression Right { get; set; }

        //左边的字段 
        public Field LeftField { get; set; }

        //右边的字段
        public Field RightField { get; set; }

         
        /// <summary>
        /// 值
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// 子查询
        /// </summary>
        public EntityQueryExpression SubExpression { get; set; }

        //一元运算时关联的表达式，比如!
        public WhereExpression Quote { get; set; }

        //操作符，比如  ==  ， != , && , ||
        public QueryOperator Operator { get; set; }

        /// <summary>
        /// 是否检索全部数据  1=1
        /// </summary>
        internal bool? IsAll { get; set; }

        /// <summary>
        /// 是否为单独的查询
        /// </summary>
        /// <returns></returns>
        public bool IsSingle
        {
            get
            {
                if ((Left as object) == null && (Right as object) == null)
                    return true;
                return
                    false;
            }
        }

        public static bool IsNullOrEmpty(WhereExpression exp)
        {
            if ((exp as object) == null) return true;
            if ((exp.Left as object) == null &&
                (exp.Right as object) == null &&
                (exp.LeftField as object) == null &&
                (exp.RightField as object) == null)
                return true;
            return false;
        }


        public static WhereExpression ALL
        {
            get
            {
                return new WhereExpression()
                {
                    IsAll = true
                };
            }
        }
        public WhereExpression Not
        {
            get
            {
                return new WhereExpression()
                {
                    Quote = this,
                    Operator = QueryOperator.BitwiseNOT
                };
            }
        }


        #region 静态方法

        

        public static WhereExpression Create(WhereExpression left, WhereExpression right, QueryOperator op)
        {
            return new WhereExpression()
            {
                Left = left,
                Right = right,
                Operator = op
            };
        }
        public static WhereExpression Create(Field leftField, Field rightField, QueryOperator op)
        {
            return new WhereExpression()
            {
                LeftField = leftField,
                RightField = rightField,
                Operator = op
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leftField"></param>
        /// <param name="value">值，包括子查询</param>
        /// <param name="op"></param>
        /// <returns></returns>
        public static WhereExpression Create(Field leftField, object value, QueryOperator op)
        { 
            var exp =  new WhereExpression()
            {
                LeftField = leftField, 
                Operator = op
            };
            if (value is IEntityQueryable)
            {
                exp.SubExpression = ((IEntityQueryable)value).Expression;
            }
            else if (value is EntityQueryExpression)
            {
                exp.SubExpression = (EntityQueryExpression)value;
            }
            else
            {
                exp.Value = value;
                if (exp.Value == null && exp.Operator == QueryOperator.Equal)
                {
                    exp.Operator = QueryOperator.IsNULL;
                }
                if (exp.Value == null && exp.Operator == QueryOperator.NotEqual)
                {
                    exp.Operator = QueryOperator.IsNotNULL;
                }
            }
            return exp;
        }
        public static WhereExpression Create(object value,Field rightField, QueryOperator op)
        {
            var exp =  new WhereExpression()
            {
                RightField = rightField,
                Value = value,
                Operator = op
            }; 
            if (value is IEntityQueryable)
            {
                exp.SubExpression = ((IEntityQueryable)value).Expression;
            }
            else if (value is EntityQueryExpression)
            {
                exp.SubExpression = (EntityQueryExpression)value;
            }
            return exp;
        } 
 
        #endregion

         

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        #region 运算符重载

         

        #region 两个条件表达式的组合

        /// <summary>
        /// And
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static WhereExpression operator &(WhereExpression left, WhereExpression right)
        {
            return WhereExpression.Create(left, right, QueryOperator.And);
        }


        /// <summary>
        /// Or
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static WhereExpression operator |(WhereExpression left, WhereExpression right)
        {
            return WhereExpression.Create(left, right, QueryOperator.Or);
        }
        #endregion
         

        #endregion

        public static bool operator true(WhereExpression exp)
        {
            return false;
        }

        public static bool operator false(WhereExpression exp)
        {
            return false;
        }

        /// <summary>
        /// Clone
        /// </summary>
        /// <returns></returns>
        public WhereExpression Clone()
        {
            return DataHelper.Clone(this) as WhereExpression;
        }

        /// <summary>
        /// 设置表名
        /// </summary>
        /// <param name="tName"></param>
        public void SetTable(string tName)
        {
            if ((LeftField as object) != null)
                LeftField.SetTableName(tName);
            if ((RightField as object) != null)
                RightField.SetTableName(tName);
            if (Left != null)
                Left.SetTable(tName);
            if (Right != null)
                Right.SetTable(tName);
        }
    }
}