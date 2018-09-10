using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Liger.Linq;
using System.Data; 


namespace Liger.Data.Linq
{
    public class DbQueryProvider<T> : QueryProvider
        where T : Entity
    {
        EntityQueryable<T> entityQuery;

        public DbQueryProvider(EntityQueryable<T> entityQuery)
            : base()
        {
            this.entityQuery = entityQuery;
        }


        public override object Execute(System.Linq.Expressions.Expression expression)
        {
            var translater = new ExpressionTranslater<T>(expression, this.entityQuery);
            translater.Translat();
            return translater.Execute();
        }



        public override string GetQueryText(System.Linq.Expressions.Expression expression)
        {
            var translater = new ExpressionTranslater<T>(expression, this.entityQuery);
            translater.Translat();  

            var SQLTranslater = new Liger.Data.ExpressionTranslater(entityQuery.DbProvider,translater.EntityQueryExpression);
            SQLTranslater.Translate();

            return SQLTranslater.CommandText;
        }
    }
}
