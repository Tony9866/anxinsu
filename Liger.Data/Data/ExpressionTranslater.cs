using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Liger.Data.Resources; 

namespace Liger.Data
{
    /// <summary>
    /// 表达式的翻译对象,生成SQL
    /// 这个类可能会涉及到很多的sql
    /// 翻译完会把sql 存放在 CommandText
    /// 如果有参数，存放到 Params
    /// </summary>
    public class ExpressionTranslater
    {
        internal const string SQL_SELECT = " SELECT ";
        internal const string SQL_FROM = " FROM ";
        internal const string SQL_DISTINCT = " DISTINCT ";
        internal const string SQL_TOP = " TOP ";
        internal const string SQL_WHERE = " WHERE ";
        internal const string SQL_ORDERBY = " ORDER BY ";
        internal const string SQL_ORDERBY_ASC = " ASC ";
        internal const string SQL_ORDERBY_DESC = " DESC ";
        internal const string SQL_GROUPBY = " GROUP BY ";
        internal const string SQL_HAVING = " HAVING ";
        internal const string SQL_JOIN_INNER = " INNER JOIN ";
        internal const string SQL_JOIN_LEFT = " LEFT JOIN ";
        internal const string SQL_JOIN_RIGHT = " RIGHT JOIN ";
        internal const string SQL_JOIN_CROSS = " CROSS JOIN ";
        internal const string SQL_JOIN_ON = " ON ";

        internal const string SQL_UPDDATE = " UPDATE ";
        internal const string SQL_INSERTINTO = " INSERT INTO ";
        internal const string SQL_INSERT_VALUES = " VALUES "; 
        internal const string SQL_DELETEFROM = " DELETE FROM";
        internal const string SQL_UPDATE_SET = " SET ";

        /// <summary>
        /// 数据驱动,根据不同的数据库类型，翻译的结果可能有所不同
        /// </summary>
        public DbProvider DbProvider { get; private set; }
        /// <summary>
        /// 要翻译的表达式
        /// </summary>
        public EntityQueryExpression Expression { get; private set; }
        /// <summary>
        /// 翻译表达式，如果遇到值，附加到这里来
        /// </summary>
        public List<QueryParameter> Params { get; private set; } 
        /// <summary>
        /// SQL
        /// </summary>
        public string CommandText { get; private set; }

        /// <summary>
        /// 参数计数器
        /// </summary>
        private int paramCounter = 0;

        /// <summary>
        /// 设置参数名开始数
        /// </summary>
        /// <param name="parmStartIndex"></param>
        public void SetParmStartIndex(int parmStartIndex)
        {
            paramCounter = parmStartIndex;
        }

        internal void SetCommandText(string commandText)
        {
            this.CommandText = commandText;
        }

        public ExpressionTranslater()
            : this(null, null)
        {
        }

        public ExpressionTranslater(DbProvider dbProvider)
            : this(dbProvider, null)
        {
        }

        public ExpressionTranslater(DbProvider dbProvider, EntityQueryExpression exp)
        {
            this.DbProvider = dbProvider;
            this.Params = new List<QueryParameter>();
            this.Expression = exp;
        }

        /// <summary>
        /// 翻译成SQL,并生成相应的参数
        /// </summary>
        public void Translate()
        {
            DbProvider.PrepareTranslater(this);
            this.CommandText = TranslateEntityQuery(this.Expression);
            DbProvider.AdjustTranslater(this);
        } 

        public string TranslateEntityQuery(EntityQueryExpression exp)
        { 
            StringBuilder str = new StringBuilder();
            str.Append(this.TranslateSelect(exp));
            str.Append(SQL_FROM);
            str.Append(DbProvider.BuildTableName(exp.From.GetName()));
            if (exp.Joins != null)
            {
                foreach (var join in exp.Joins)
                {
                    str.Append(this.TranslateJoin(join));
                }
            }
            if (exp.Where != null)
            {
                str.Append(SQL_WHERE);
                str.Append(this.TranslateWhere(exp.Where));
            }
            if (exp.IsOrderBy)
            {
                str.Append(this.TranslateOrderyByList(exp.OrderByList));
            }
            if (exp.GroupBy != null)
            {
                str.Append(this.TranslateGroupBy(exp.GroupBy));
            }
            return str.ToString();  
        }

        private string CreateParmName()
        {
            //return DataHelper.MakeUniqueKey(string.Empty); 
            return "p" + ++paramCounter;
        }


        /// <summary>
        /// 翻译查询条件表达式
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public string TranslateWhere(WhereExpression exp)
        {
            StringBuilder str = new StringBuilder(); 
            if (exp.IsSingle)
            {
                if (exp.Operator == QueryOperator.BitwiseNOT)
                {
                    if (exp.Quote != null && exp.Quote.Operator == QueryOperator.In)
                    {
                        return TranslateWhere(WhereExpression.Create(exp.Quote.LeftField, exp.Quote.Value, QueryOperator.NotIn));
                    }
                }
                if ((exp.LeftField as object) != null && (exp.RightField as object) != null)
                {
                    str.Append(exp.LeftField.FieldNameWithTable);
                    str.Append(DataHelper.GetOperatorQueryText(exp.Operator));
                    str.Append(exp.RightField.FieldNameWithTable);
                }
                else if ((exp.LeftField as object) != null)
                {
                    str.Append(exp.LeftField.FieldNameWithTable);
                    str.Append(DataHelper.GetOperatorQueryText(exp.Operator));
                    //子查询 这里只暂时支持写在左边
                    if (exp.SubExpression != null)
                    {
                        str.Append("(" + this.TranslateEntityQuery(exp.SubExpression) + ")");
                    }
                    else if (exp.Operator == QueryOperator.In || exp.Operator == QueryOperator.NotIn)
                    { 
                        str.Append("(");
                        if (exp.Value != null)
                        {
                            var appended = false;
                            foreach (var value in (IEnumerable)exp.Value)
                            {
                                var parm = new QueryParameter(CreateParmName(), value);
                                this.Params.Add(parm);
                                if (appended) str.Append(",");
                                str.Append(parm.Name);
                                appended = true;
                            }
                        }
                        str.Append(")");

                    }
                    else if(exp.Operator != QueryOperator.IsNotNULL && exp.Operator != QueryOperator.IsNULL)
                    {
                        var parm = new QueryParameter(CreateParmName(), exp.Value);
                        this.Params.Add(parm);
                        str.Append(parm.Name);
                    } 
                }
                else if ((exp.RightField as object) != null)
                {
                    var parm = new QueryParameter(CreateParmName(), exp.Value);
                    str.Append(parm.Name);
                    str.Append(DataHelper.GetOperatorQueryText(exp.Operator));
                    str.Append(exp.RightField.FieldNameWithTable);
                    this.Params.Add(parm);
                }
            }
            else
            {
                str.Append("(" + this.TranslateWhere(exp.Left) + ")");
                str.Append(DataHelper.GetOperatorQueryText(exp.Operator));
                str.Append("(" + this.TranslateWhere(exp.Right) + ")");
            }
            if (str.Length < 8)
                return "";
            return str.ToString();
        }



        public string TranslateSelect(EntityQueryExpression exp)
        {
            StringBuilder str = new StringBuilder();
            str.Append(SQL_SELECT);
            if (exp.IsDistinct != null && exp.IsDistinct.Value)
                str.Append(SQL_DISTINCT);
            //如果不是 子查询的表达式
            if(exp == this.Expression)
                str.Append(this.DbProvider.GetSQLSelectTopClip(this));
            var fields = exp.SelectFields;
            var appended = false;
            foreach (var field in fields)
            {
                if (appended) str.Append(",");
                str.Append(field.FullName);
                appended = true;
            }
            if (!appended) str.Append(" *");
            return str.ToString();
        }

        public string TranslateJoin(JoinExpression exp)
        {
            StringBuilder str = new StringBuilder();
            if (exp.JoinType == JoinType.InnerJoin)
                str.Append(SQL_JOIN_INNER);
            else if (exp.JoinType == JoinType.LeftJoin)
                str.Append(SQL_JOIN_LEFT);
            else if (exp.JoinType == JoinType.CrossJoin)
                str.Append(SQL_JOIN_CROSS);
            else 
                str.Append(SQL_JOIN_RIGHT);
            str.Append("{0}" + exp.Entity.GetName() + "{1}" + SQL_JOIN_ON);
            str.Append(this.TranslateWhere(exp.Where));
            return str.ToString();
        }

        public string TranslateOrderyBy(OrderByExpression exp)
        {
            if (exp.Field == null) return "";
            StringBuilder str = new StringBuilder(); 
            str.Append(exp.Field.FieldNameWithTable);
            str.Append(" " + (exp.Direction == OrderByDirection.Asc ? SQL_ORDERBY_ASC : SQL_ORDERBY_DESC));
            return str.ToString();
        }
        public string TranslateGroupBy(GroupByExpression exp)
        {
            StringBuilder str = new StringBuilder();
            var fields = exp.Fields;
            if (fields == null || fields.Count == 0) return "";
            str.Append(SQL_GROUPBY); 
            var appended = false;
            foreach (var field in fields)
            {
                if (appended) str.Append(",");
                str.Append(field.FieldNameWithTable);
                appended = true;
            }
            if (exp.Having != null)
            {
                str.Append(SQL_HAVING);
                str.Append(this.TranslateWhere(exp.Having));
            }
            return str.ToString();
        }
        public string TranslateOrderyByList(IList<OrderByExpression> orderbys)
        {
            return this.TranslateOrderyByList(orderbys, false);
        }
        public string TranslateOrderyByList(IList<OrderByExpression> orderbys, bool isReverse)
        {
            if (orderbys == null || orderbys.Count == 0) return "";
            StringBuilder str = new StringBuilder();
            str.Append(SQL_ORDERBY);
            var appended = false;
            foreach (var orderby in orderbys)
            {
                if (appended) str.Append(",");
                if(!isReverse)
                    str.Append(this.TranslateOrderyBy(orderby));
                else
                    str.Append(this.TranslateOrderyBy(orderby.Reverse()));
                appended = true;
            }
            return str.ToString();
        }
    }
}
