using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Liger.Data;
using Liger.Common;
namespace Liger.Data.Extensions
{
    public static class OrderByListExtension
    {
        public static IList<OrderByExpression> Clone(this IList<OrderByExpression> list)
        {
            var result = new List<OrderByExpression>();
            foreach (var orderby in list)
            {
                result.Add(orderby.Clone());
            }
            return result;
        }


        public static IList<OrderByExpression> Reverse(this IList<OrderByExpression> list)
        {
            var result = new List<OrderByExpression>();
            foreach (var orderby in list)
            {
                result.Add(orderby.Reverse());
            }
            return result;
        } 


        public static IList<OrderByExpression> SetTable(this IList<OrderByExpression> list,string tName)
        { 
            foreach (var orderby in list)
            {
                orderby.SetTable(tName);
            }
            return list;
        }
    }
}
