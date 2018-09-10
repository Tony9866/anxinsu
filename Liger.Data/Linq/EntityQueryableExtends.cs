using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Liger.Linq;
using Liger.Data;
namespace Liger.Data.Linq
{
    public static class EntityQueryableExtends
    {
        public static IQueryable<T> Query<T>(this DbContext context)
           where T: Entity
        {
            return new Queryable<T>(new DbQueryProvider<T>(context.From<T>()));
        }
    }
}
