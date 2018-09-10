using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Liger.Common;
namespace Liger.Data
{
    [Serializable]
    public class GroupByExpression : IDbExpression, ICloneable<GroupByExpression>, ITableResizable
    {
        public DbExpressionType ExpressionType
        {
            get
            {
                return DbExpressionType.GroupBy;
            }
        }

        /// <summary>
        /// 用于分组的字段的列表
        /// </summary>
        public IList<Field> Fields { get; set; }

        public WhereExpression Having { get; set; }

        public GroupByExpression()
            : this(null)
        {
        }

        public GroupByExpression(Field field) 
        {
            this.Fields = new List<Field>();
            if ((field as object) != null)
            {
                this.Fields.Add(field);
            }
        }


        /// <summary>
        /// Clone
        /// </summary>
        /// <returns></returns>
        public GroupByExpression Clone()
        {
            return DataHelper.Clone(this) as GroupByExpression;
        }
        /// <summary>
        /// 设置表名
        /// </summary>
        /// <param name="tName"></param>
        public void SetTable(string tName)
        {
            if (Fields != null)
            {
                foreach (var field in Fields)
                {
                    field.SetTableName(tName);
                }
            }
        }
    }
}
