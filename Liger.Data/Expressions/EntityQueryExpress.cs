using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Liger.Common;
using Liger.Common.Extensions;
using Liger.Data.Resources;
namespace Liger.Data
{
    /// <summary>
    /// 主表达式
    /// </summary>
    [Serializable]
    public class EntityQueryExpression : IDbExpression
    {
        public DbExpressionType ExpressionType
        {
            get
            {
                return DbExpressionType.EntityQuery;
            }
        }

        public SelectExpression Select { get; set; } 

        public WhereExpression Where { get; set; }

        public IList<JoinExpression> Joins { get; set; }

        public IList<OrderByExpression> OrderByList { get; set; }

        public GroupByExpression GroupBy { get; set; }

 
        /// <summary>
        /// 主表
        /// </summary>
        public Entity From { get; set; }

        /// <summary>
        /// join的表
        /// </summary>
        public List<Entity> JoinEntities { get; set; }

        /// <summary>
        /// 是否生成distinct
        /// </summary>
        public bool? IsDistinct { get; set; }

        /// <summary>
        /// 开始记录行索引
        /// </summary>
        public int? StartIndex { get; set; }

        /// <summary>
        /// 结束行索引
        /// </summary>
        public int? EndIndex { get; set; }

        #region 几个常用的判断属性
        /// <summary>
        /// 是否分页(截取中间部分数据)
        /// </summary>
        public bool IsPagable
        {
            get
            {
                return IsSkip && IsTop;
            }
        }

        /// <summary>
        /// 是否跳过一部分数据
        /// </summary>
        public bool IsSkip
        {
            get
            {
                if (StartIndex.HasValue && StartIndex.Value != 0)
                    return true;
                else
                    return false;
            }
        }
        /// <summary>
        /// 是否设置最大记录数
        /// </summary>
        public bool IsTop
        {
            get
            {
                if (EndIndex.HasValue && EndIndex.Value != 0)
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// ID 字段是否倒序
        /// </summary>
        public bool IsIdentityFieldDesc
        {
            get
            {
                if (OrderByList == null || OrderByList.Count == 0) return false;
                if (OrderByList.Any(c => c.Field.Equals(From.GetIdentityField())))
                {
                    var orderBy = OrderByList.First(c => c.Field.Equals(From.GetIdentityField()));
                    return orderBy.Direction == OrderByDirection.Desc;
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// 是否排序
        /// </summary>
        private bool? isOrderBy;
        /// <summary>
        /// 是否包括排序
        /// </summary>
        /// <returns></returns>
        public bool IsOrderBy
        {
            get
            {
                if (isOrderBy.HasValue)
                    return isOrderBy.Value;
                if (this.OrderByList == null || this.OrderByList.Count == 0)
                    return false;
                return true;
            }
            set
            {
                isOrderBy = value;
            }
        }

        /// <summary>
        /// 是否显示全部字段
        /// </summary>
        /// <returns></returns>
        public bool IsShowAllField()
        {
            if(this.Select == null) 
                return true; 
            if (this.Select.Fields == null || this.Select.Fields.Count == 0)
                return true;
            var fields = this.Select.Fields;
            if (fields.Any(c => c.FieldName.Contains("*")))
                return true;
            return false;
        }

        /// <summary>
        /// 是否显示全部字段
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public bool IsShowAllField(string tableName)
        {
            if(this.Select == null) 
                return true;  
            if(this.Select.Fields == null || this.Select.Fields.Count == 0) 
                return true;
            string t = tableName.Replace("{0}", "").Replace("{1}", "");
            var fields = this.Select.Fields;
            if (fields.Any(c => !c.TableName.IsNullOrEmpty() && c.TableName.Replace("{0}", "").Replace("{1}", "").Equals(tableName, StringComparison.OrdinalIgnoreCase) && c.FieldName.Contains("*"))) 
                return true;
            return false;
        }

        /// <summary>
        /// 获取全部Select的字段
        /// </summary>
        public List<Field> SelectFields
        {
            get
            {
                var fields = this.Select.Fields;
                if (this.IsShowAllField(this.From.GetName()))
                {
                    fields.AddRange(this.From.GetFields().ToList<Field>());
                }
                var joinEntities = this.JoinEntities;
                if (joinEntities != null)
                {
                    foreach (var joinEntity in joinEntities)
                    {
                        if (this.IsShowAllField(joinEntity.GetName()))
                        {
                            fields.AddRange(joinEntity.GetFields().ToList<Field>());
                        }
                    }
                }
                return fields;
            }
        }

        #endregion


        public EntityQueryExpression(Entity from) 
        { 
            this.From = from; 
            this.Select = new SelectExpression();
            this.Joins = new List<JoinExpression>();
            this.OrderByList = new List<OrderByExpression>(); 
             
        }

        #region 增加Select
        public void AddSelect(Field[] fields)
        {
            AddSelect(new SelectExpression(fields));
        }
        public void AddSelect(SelectExpression expression)
        {
            foreach (var field in expression.Fields)
            {
                this.Select.Fields.Add(field);
            }
        }
        #endregion

        #region 增加Where
        public void AddWhere(WhereExpression expression)
        {
            if (expression == null) return;
            if (this.Where == null)
            {
                this.Where = expression;
            }
            else
            {
                this.Where = WhereExpression.Create(this.Where, expression, QueryOperator.And);
            }
        }
        #endregion

        #region 增加JOIN
        public void AddJoin(Entity entity, JoinExpression joinExp)
        {
            Guard.IsNotNull(joinExp, "JoinExpression");

            if(this.JoinEntities == null)
                this.JoinEntities = new List<Entity>();
            if(this.Joins == null)
                this.Joins = new List<JoinExpression>();
            this.JoinEntities.Add(entity);
            this.Joins.Add(joinExp);
        }
        #endregion

        #region 增加OrderBy
        public void AddOrderBy(OrderByExpression[] orderbys)
        {
            Guard.IsNotNull(orderbys, "OrderByExpression");
            foreach (var orderby in orderbys)
            {
                this.AddOrderBy(orderby);
            }
        }

        public void AddOrderBy(OrderByExpression orderby)
        {
            Guard.IsNotNull(orderby, "OrderByExpression"); 
            if (this.OrderByList == null)
                this.OrderByList = new List<OrderByExpression>();
            this.OrderByList.Add(orderby);
        }
        #endregion

        #region  GroupBy
         
        public void AddGroupBy(Field[] fields)
        {
            if (this.GroupBy == null) 
                this.GroupBy = new GroupByExpression();
            foreach (var field in fields)
            {
                this.GroupBy.Fields.Add(field);
            }
        }
        public void AddGroupBy(GroupByExpression expression)
        {
            if (this.GroupBy == null) 
                this.GroupBy = new GroupByExpression();
            foreach (var field in expression.Fields)
            {
                this.GroupBy.Fields.Add(field);
            }
        }

        public void AddGroupByHaving(WhereExpression expression)
        {
            if (this.GroupBy == null)
                this.GroupBy = new GroupByExpression();
            this.GroupBy.Having = expression;
        }
        #endregion


        /// <summary>
        /// Clone
        /// </summary>
        /// <returns></returns>
        public EntityQueryExpression Clone()
        {
            return DataHelper.Clone(this) as EntityQueryExpression;
        }
    }
}
