using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Liger.Common;
namespace Liger.Data
{
    [Serializable]
    public class OrderByExpression : IDbExpression, ICloneable<OrderByExpression>, ITableResizable
    {

        public DbExpressionType ExpressionType
        {
            get
            {
                return DbExpressionType.OrderyBy;
            }
        }


        /// <summary>
        /// 排序的字段
        /// </summary> 
        public Field Field { get; set; }

        /// <summary>
        /// 排序的方向
        /// </summary>
        public OrderByDirection Direction { get; set; }

         
        public OrderByExpression(Field field)
            : this(field, OrderByDirection.Asc)
        {
        }

        public OrderByExpression(Field field,OrderByDirection dir)
        {
            this.Field = field;
            this.Direction = dir;
        }
          
         
          
        #region 参数
        private List<QueryParameter> parameters = new List<QueryParameter>(); 

        /// <summary>
        /// 返回参数列表
        /// </summary>
        internal QueryParameter[] Parameters
        {
            get
            {
                return parameters.ToArray();
            }
        }
        #endregion
         
         
        #region 转换排序方向，并返回
        public OrderByExpression Reverse()
        {
            var orderBy = new OrderByExpression(this.Field); 
            orderBy.Direction = this.Direction == OrderByDirection.Asc ? OrderByDirection.Desc : OrderByDirection.Asc;
            return orderBy;
        }
        #endregion



        /// <summary>
        /// Clone
        /// </summary>
        /// <returns></returns>
        public OrderByExpression Clone()
        {
            return DataHelper.Clone(this) as OrderByExpression;
        }

        /// <summary>
        /// 设置表名
        /// </summary>
        /// <param name="tName"></param>
        public void SetTable(string tName)
        {
            if ((Field as object) != null)
            {
                Field.SetTableName(tName);
            }
        }
    }
}
