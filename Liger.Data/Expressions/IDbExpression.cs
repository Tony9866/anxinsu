using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Liger.Data
{
    public enum DbExpressionType
    {
        Select = 1000,
        Where,
        Join,
        OrderyBy,
        GroupBy,
        EntityQuery
    }
     
    public interface IDbExpression
    {
        DbExpressionType ExpressionType { get; }
    }
}
