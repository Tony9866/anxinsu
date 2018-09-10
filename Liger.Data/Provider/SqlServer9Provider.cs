using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Liger.Data.SqlServer9
{
    public class SqlServer9Provider : Liger.Data.SqlServer.SqlServerProvider
    { 


        public SqlServer9Provider(string connectionString)
            : base(connectionString)
        {
        }



        /// <summary>
        /// 获取Sq语句中 "select" 和 字段之间 的部分 
        /// 这里针对分页做了处理。如果不是分页检索，那么调用父类的默认实现
        /// </summary>
        /// <returns></returns>
        public override string GetSQLSelectTopClip(ExpressionTranslater translater)
        {
            StringBuilder str = new StringBuilder(); 
            var exp = translater.Expression;
            if (exp.IsPagable)
            {
                IList<OrderByExpression> orderby = exp.IsOrderBy ? exp.OrderByList : new List<OrderByExpression>(){
                new OrderByExpression(exp.From.GetIdentityField(), OrderByDirection.Asc)
            };
                str.Append(string.Concat("row_number() over (", translater.TranslateOrderyByList(orderby), ") as rowId,"));
            }
            else
            {
                return base.GetSQLSelectTopClip(translater);
            }
            return str.ToString();
        }

        public override void AdjustTranslater(ExpressionTranslater translater)
        {
            var exp = translater.Expression;
            if (exp.IsPagable)
                AdjustPagable(translater);  
        }


        protected override void AdjustPagable(ExpressionTranslater translater)
        {
            var oldSQL = translater.CommandText;
            var exp = translater.Expression;
            var sql = @"SELECT * FROM ({OLDSQL}) AS tmptableinner WHERE rowId between {N} and {M}";
            sql = sql.Replace("{N}", (exp.StartIndex.Value + 1).ToString());
            sql = sql.Replace("{M}", (exp.EndIndex.Value + 1).ToString());
            sql = sql.Replace("{OLDSQL}", oldSQL);
            translater.SetCommandText(sql);
        }
    }
}
