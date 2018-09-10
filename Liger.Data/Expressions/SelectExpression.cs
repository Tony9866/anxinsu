using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Liger.Common;

namespace Liger.Data
{
    [Serializable]
    public class SelectExpression : IDbExpression, ICloneable<SelectExpression>, ITableResizable
    {

        public DbExpressionType ExpressionType
        {
            get
            {
                return DbExpressionType.Select;
            }

        }
        /// <summary>
        /// 用于投影的字段的列表
        /// </summary>
        public List<Field> Fields { get; set; }


        public SelectExpression() 
            :this(null)
        { 
        }

        public SelectExpression(Field[] fields)
        {
            if (this.Fields == null)
            {
                this.Fields = new List<Field>();
            }
            if (fields != null && fields.Length > 0)
            {
                foreach (var field in fields)
                {
                    this.Fields.Add(field);
                }
            }
        }



        /// <summary>
        /// Clone
        /// </summary>
        /// <returns></returns>
        public SelectExpression Clone()
        {
            return DataHelper.Clone(this) as SelectExpression;
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
