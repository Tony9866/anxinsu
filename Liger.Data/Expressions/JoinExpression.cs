using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Liger.Common;
namespace Liger.Data
{
    [Serializable]
    public class JoinExpression : IDbExpression, ICloneable<JoinExpression>
    {
        public DbExpressionType ExpressionType
        {
            get
            {
                return DbExpressionType.Join;
            }

        }
        /// <summary>
        /// 条件
        /// </summary>
        public WhereExpression Where { get; set; }
        /// <summary>
        /// 链接表
        /// </summary>
        public Entity Entity { get; set; } 
        /// <summary>
        /// 链接类型
        /// </summary>
        public JoinType JoinType { get; set; }



        public JoinExpression(Entity entity, WhereExpression where)
            :this(entity,where,JoinType.InnerJoin)
        {
        }

        public JoinExpression(Entity entity, WhereExpression where,JoinType jointype)
        {
            this.Entity = entity;
            this.Where = where;
            this.JoinType = jointype;
        }



        /// <summary>
        /// Clone
        /// </summary>
        /// <returns></returns>
        public JoinExpression Clone()
        {
            return DataHelper.Clone(this) as JoinExpression;
        }
    }
}
