using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using Liger.Common;
using Liger.Common.Extensions;
using Liger.Data;
using Liger.Linq;
using System.Reflection;
using System.Collections.ObjectModel;

namespace Liger.Data.Linq
{
    /// <summary>
    /// 访问 Expression 并绑定到 Liger.Data.EntityQueryExpress
    /// </summary>
    public class ExpressionTranslater<T> : ExpressionVisitor 
        where T : Entity
    {


        #region 公共常用工具方法

        private Dictionary<Type, Entity> tables = new Dictionary<Type, Entity>();

        private Entity getTableByType(Type type)
        {
            if (tables.ContainsKey(type)) return tables[type];
            var table = DataHelper.Create(type)() as Entity;
            tables[type] = table;
            return table;
        }


        private bool IsQuery(Expression expression)
        {
            Type elementType = TypeHelper.GetElementType(expression.Type);
            return elementType != null && typeof(IQueryable<>).MakeGenericType(elementType).IsAssignableFrom(expression.Type);
        }
        private static LambdaExpression GetLambda(Expression e)
        {
            while (e.NodeType == ExpressionType.Quote)
            {
                e = ((UnaryExpression)e).Operand;
            }
            if (e.NodeType == ExpressionType.Constant)
            {
                return ((ConstantExpression)e).Value as LambdaExpression;
            }
            return e as LambdaExpression;
        }




        private QueryOperator GetQueryOperatorByExpressType(ExpressionType NodeType)
        {
            switch (NodeType)
            {
                case ExpressionType.Negate:
                case ExpressionType.NegateChecked:
                case ExpressionType.Not:
                    return QueryOperator.BitwiseNOT;
                case ExpressionType.Convert:
                case ExpressionType.ConvertChecked:
                case ExpressionType.ArrayLength:
                case ExpressionType.Quote:
                case ExpressionType.TypeAs:
                case ExpressionType.UnaryPlus:
                    throw new NotImplementedException();
                case ExpressionType.Add:
                    return QueryOperator.Add; 
                case ExpressionType.Subtract:
                case ExpressionType.SubtractChecked:
                    return QueryOperator.Subtract;
                case ExpressionType.Multiply:
                case ExpressionType.MultiplyChecked:
                    return QueryOperator.Multiply;
                case ExpressionType.Divide:
                    return QueryOperator.Divide;
                case ExpressionType.Modulo:
                    return QueryOperator.Modulo;
                case ExpressionType.And:
                    return QueryOperator.BitwiseAND;
                case ExpressionType.AndAlso:
                    return QueryOperator.And;
                case ExpressionType.Or:
                    return QueryOperator.BitwiseOR;
                case ExpressionType.OrElse:
                    return QueryOperator.Or;
                case ExpressionType.LessThan:
                    return QueryOperator.Less;
                case ExpressionType.LessThanOrEqual:
                    return QueryOperator.LessOrEqual;
                case ExpressionType.GreaterThan:
                    return QueryOperator.Greater;
                case ExpressionType.GreaterThanOrEqual:
                    return QueryOperator.GreaterOrEqual;
                case ExpressionType.Equal:
                    return QueryOperator.Equal;
                case ExpressionType.NotEqual:
                    return QueryOperator.NotEqual;
                case ExpressionType.Coalesce:
                case ExpressionType.ArrayIndex:
                case ExpressionType.RightShift:
                case ExpressionType.LeftShift:
                case ExpressionType.ExclusiveOr:
                case ExpressionType.Power:
                case ExpressionType.TypeIs:
                case ExpressionType.Conditional:
                case ExpressionType.Constant:
                case ExpressionType.Parameter:
                case ExpressionType.MemberAccess:
                case ExpressionType.Call:
                case ExpressionType.Lambda:
                case ExpressionType.New:
                case ExpressionType.NewArrayInit:
                case ExpressionType.NewArrayBounds:
                case ExpressionType.Invoke:
                case ExpressionType.MemberInit:
                case ExpressionType.ListInit:
                default:
                    throw new NotImplementedException();
            }
        }
        #endregion 


        #region 构造函数
        Expression root;

        public EntityQueryExpression EntityQueryExpression
        {
            get
            {
                return EntityQuery.Expression;
            }
        }

        public EntityQueryable<T> EntityQuery { get; private set; }

        public ExpressionTranslater(Expression root, EntityQueryable<T> entityQuery)
        {
            this.root = root;
            this.EntityQuery = entityQuery;
        }
        #endregion


        /// <summary>
        /// 当前表达式所使用的作用域
        /// 如 c=> c.CustomerID 中的 c
        /// </summary>
        private ReadOnlyCollection<ParameterExpression> currentContext;

        /// <summary>
        /// 当前表达式所投影的对象
        /// 如 c=> new { c.CustomerID } 中的 new { c.CustomerID }
        /// </summary>
        private NewExpression currentSelector;

        /// <summary>
        /// 当前表达式所投影的对象
        ///  如 c=>  c.CustomerID  中的 CustomerID
        /// </summary>
        private MemberExpression currentSelectMember;

        /// <summary>
        /// 表达式的方法名
        /// 如 First
        /// </summary>
        public string CallMethodName { get; private set; }

        public void Translat()
        {
            this.Visit(this.root); 
        }

        public object Execute()
        {
            switch (CallMethodName)
            {
                case "First":
                case "FirstOrDefault":
                case "Single":
                case "SingleOrDefault":
                case "Last":
                case "LastOrDefault":
                    var value = this.EntityQuery.ToFirst(); 
                    if (currentSelectMember != null)
                    { 
                        return DataHelper.ConvertValue(currentSelectMember.Type, value);
                    }
                    else if (currentSelector != null)
                    {
                        var newVal = DataHelper.Create(currentSelector.Type);
                        var properties = currentSelector.Type.GetProperties();
                        return null;
                    }
                    else
                    {
                        return value;
                    }
                case "Any":
                    return this.EntityQuery.Exist();
                case "Count":
                    return this.EntityQuery.Count();
                default:
                    var list = this.EntityQuery.ToList();
                    var values = new List<object>();
                    if (currentSelectMember != null)
                    {  
                        foreach (Entity item in list)
                        {
                            var memberVal = item.GetValue(currentSelectMember.Member.Name);
                            values.Add(DataHelper.ConvertValue(currentSelectMember.Type, memberVal)); 
                        }
                        return DataHelper.ListDataToEnumerable(values, currentSelectMember.Type); 
                    }
                    else if (currentSelector != null)
                    {
                        var newVal = Activator.CreateInstance(currentSelector.Type);

                        var properties = currentSelector.Type.GetProperties();
                        return null;
                    }
                    else
                    {
                        return list;
                    } 
            }
        } 



        protected override Expression Visit(Expression exp)
        {
            return base.Visit(exp);
        }

        protected override Expression VisitMethodCall(MethodCallExpression m)
        {
            if (m.Method.DeclaringType == typeof(Queryable)  || m.Method.DeclaringType == typeof(Enumerable)
                )
            {
                if (this.root == m)
                {
                    this.CallMethodName = m.Method.Name;
                } 
                switch (m.Method.Name)
                {
                    case "Where": 
                        this.TranslatWhere(m.Type, m.Arguments[0], GetLambda(m.Arguments[1]));
                        break;
                    case "Select":
                        this.TranslatSelect(m.Type, m.Arguments[0], GetLambda(m.Arguments[1]));
                        break;
                    case "SelectMany": 
                        break;
                    case "Join": 
                        break;
                    case "GroupJoin": 
                        break;
                    case "OrderBy": 
                    case "OrderByDescending": 
                    case "ThenBy": 
                    case "ThenByDescending":
                        this.TranslatOrderBy(m.Type, m.Arguments[0], GetLambda(m.Arguments[1]),
                            m.Method.Name == "OrderByDescending" || m.Method.Name == "ThenByDescending");
                        break;
                    case "GroupBy":
                        this.TranslatGroupBy(m.Type, m.Arguments[0], GetLambda(m.Arguments[1]));
                        break;
                    case "Distinct":
                        this.TranslatDistinct(m.Type, m.Arguments[0]);
                        break;
                    case "Skip":
                        this.TranslatSkip(m.Type, m.Arguments[0], m.Arguments[1]);
                        break;
                    case "Take":
                        this.TranslatTake(m.Type, m.Arguments[0], m.Arguments[1]);
                        break;
                    case "First":
                    case "FirstOrDefault":
                    case "Single":
                    case "SingleOrDefault":
                    case "Last":
                    case "LastOrDefault":  
                    case "Any": 
                    case "All":  
                    case "Count": 
                        if (m.Arguments.Count == 2)
                        {
                            this.TranslatWhere(m.Type, m.Arguments[0], GetLambda(m.Arguments[1]));
                        }
                        else
                        {
                            this.TranslatSource(m.Arguments[0]);
                        }
                        break;
                    case "Contains": 
                        break;
                    case "Cast": 
                        break;
                    case "Reverse": 
                    case "Intersect":
                    case "Except": 
                        break;
                }
            }
            return null;
        }



        protected override Expression VisitConstant(ConstantExpression c)
        {
            if (this.IsQuery(c))
            {
                IQueryable q = (IQueryable)c.Value;
                                                                                                                                                   
            }
            return c;
        }

        private void TranslatSource(Expression source)
        {
            base.Visit(source);
        }


        private void TranslatOrderBy(Type resultType, Expression source, LambdaExpression predicate, bool desc)
        {
            this.TranslatSource(source);
            this.currentContext = predicate.Parameters; 
            if (predicate.Body.NodeType == ExpressionType.MemberAccess)
            {
                var memExp = (MemberExpression)predicate.Body;
                var table = getTableByType(memExp.Expression.Type);
                var field = new Field(memExp.Member.Name, table.GetName());
                //注意到 ：这里没有考虑 字段名 与 对象属性名 不一样的情况
                this.EntityQueryExpression.AddOrderBy(new OrderByExpression(field,
                    desc ? OrderByDirection.Asc : OrderByDirection.Desc));
            }
        }

        private void TranslatGroupBy(Type resultType, Expression source, LambdaExpression predicate)
        {
            this.TranslatSource(source);
            this.currentContext = predicate.Parameters; 
            if (predicate.Body.NodeType == ExpressionType.MemberAccess)
            {
                var memExp = (MemberExpression)predicate.Body; 
                var table = getTableByType(memExp.Expression.Type);
                if (this.EntityQueryExpression.GroupBy == null)
                    this.EntityQueryExpression.GroupBy = new GroupByExpression();
                //注意到 ：这里没有考虑 字段名 与 对象属性名 不一样的情况
                this.EntityQueryExpression.GroupBy.Fields.Add(
                    new Field(memExp.Member.Name, table.GetName())
                );
            }
        }

        private void TranslatDistinct(Type resultType, Expression source)
        {
            this.TranslatSource(source);
            this.EntityQuery.Distinct();
        }
        private void TranslatTake(Type resultType, Expression source, Expression exp)
        {
            this.TranslatSource(source);
            var take = GetValueByExpression(exp);
            if (take != null)
            {
                this.EntityQuery.Top((int)take);
            }
        }
        private void TranslatSkip(Type resultType, Expression source, Expression exp)
        {
            this.TranslatSource(source);
            var skip = GetValueByExpression(exp);
            if (skip != null)
            {
                this.EntityQuery.Skip((int)skip);
            }
        }
      

        private void TranslatWhere(Type resultType, Expression source, LambdaExpression predicate)
        {
            this.TranslatSource(source);
            this.currentContext = predicate.Parameters; 
            this.EntityQueryExpression.AddWhere(GetWhereExpression(predicate.Body)); 
        }

        private WhereExpression GetWhereExpression(Expression exp)
        {
            switch (exp.NodeType)
            {
                case ExpressionType.AndAlso: 
                case ExpressionType.OrElse: 
                case ExpressionType.LessThan:
                case ExpressionType.LessThanOrEqual:
                case ExpressionType.GreaterThan:
                case ExpressionType.GreaterThanOrEqual:
                case ExpressionType.Equal:
                case ExpressionType.NotEqual:
                    var binaryExp = (BinaryExpression)exp;
                    return GetWhereExpression(binaryExp.Left, binaryExp.Right, exp.NodeType);
                case ExpressionType.Call:
                    var callExp = (MethodCallExpression)exp;
                    if (callExp.Method.Name == "Contains")
                    {
                        var values = GetValueByExpression(callExp.Arguments[0]) as IEnumerable;
                        var field = GetFieldByExpression(callExp.Arguments[1]);
                        return field.SelectIn(values);
                    }
                    else if (callExp.Method.Name == "StartsWith" || callExp.Method.Name == "EndsWith")
                    {
                        var value = GetValueByExpression(callExp.Arguments[0]);
                        var field = GetFieldByExpression(callExp.Object);
                        if(callExp.Method.Name == "StartsWith")
                            return field.StartsWith(value as string);
                        else
                            return field.EndsWith(value as string);
                    }
                    return null;
                case ExpressionType.Not:
                    return GetWhereExpression(((UnaryExpression)exp).Operand).Not;
                default:
                    return null;
            }
        }

        private WhereExpression GetWhereExpression(Expression left,Expression right,ExpressionType NodeType)
        {
            if (NodeType == ExpressionType.AndAlso || NodeType == ExpressionType.OrElse)
            {
                return WhereExpression.Create(GetWhereExpression(left), GetWhereExpression(right), GetQueryOperatorByExpressType(NodeType));
            }  
            if (FieldConvertable(left) && FieldConvertable(right))
                return WhereExpression.Create(GetFieldByExpression(left), GetFieldByExpression(right), GetQueryOperatorByExpressType(NodeType));
            if(FieldConvertable(left) && ValueConvertable(right)  )
                return WhereExpression.Create(GetFieldByExpression(left), GetValueByExpression(right), GetQueryOperatorByExpressType(NodeType));
            if(FieldConvertable(left) && ValueConvertable(right))
                return WhereExpression.Create(GetValueByExpression(right), GetFieldByExpression(right), GetQueryOperatorByExpressType(NodeType)); 
            return null;
        }


        /// <summary>
        /// 判断表达式是否可以转换为 Field
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        private bool FieldConvertable(Expression exp)
        {
            if (exp.NodeType == ExpressionType.MemberAccess)
            {
                var memExp = (MemberExpression)exp;
                if (memExp.Expression == null)
                    return false;
                if (memExp.Expression.Type == currentContext[0].Type)
                    return true;
            }
            return false;
        }


        /// <summary>
        /// 判断表达式是否可以转换为值
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        private bool ValueConvertable(Expression exp)
        {
            if (exp.NodeType == ExpressionType.Constant
            || exp.NodeType == ExpressionType.MemberAccess
            || exp.NodeType == ExpressionType.New
                )
                return true;
            if (exp.NodeType == ExpressionType.Convert)
                return ValueConvertable(((UnaryExpression)exp).Operand);
            return false;
        }

        private Field GetFieldByExpression(Expression exp)
        {
            if(exp.NodeType != ExpressionType.MemberAccess) return null;
            var memExp = (MemberExpression)exp; 
            var table = getTableByType(memExp.Expression.Type);
            return new Field(memExp.Member.Name, table.GetName());
        }

        private object GetValueByExpression(Expression exp)
        { 
            if (!ValueConvertable(exp))
                return null;
            if (exp.NodeType == ExpressionType.Constant)
            {
                var constantExp = (ConstantExpression)exp;
                return constantExp.Value;
            }
            else if (exp.NodeType == ExpressionType.MemberAccess)
            {
               //如果是Field
               if (FieldConvertable(exp))
                    return null;

              var memberExp = (MemberExpression)exp;
              PropertyInfo property;
              if (memberExp.Expression != null && memberExp.Expression.NodeType == ExpressionType.Constant)
              {
                  var memberConst = (ConstantExpression)memberExp.Expression;
                  //字段成员
                  var fieldInfo = memberConst.Type.GetField(memberExp.Member.Name);
                  if (fieldInfo != null)
                      return fieldInfo.GetValue(memberConst.Value);
                  //属性成员
                  property = memberConst.Type.GetProperty(memberExp.Member.Name, BindingFlags.Instance
                      | BindingFlags.NonPublic
                      | BindingFlags.Public);
                  if (property != null)
                      return property.GetValue(memberConst.Value, null);
              } 
              //静态成员
              property = memberExp.Type.GetProperty(memberExp.Member.Name);
              if (property != null)
                  return property.GetValue(null, null);
              return null;
            }
            else if (exp.NodeType == ExpressionType.New)
            {
                var newExp = (NewExpression)exp;
               object[] parms = new object[newExp.Arguments.Count];
               for(var i =0;i<parms.Length;i++)
               {
                   parms[i] = GetValueByExpression(newExp.Arguments[i]);
               }
               return newExp.Constructor.Invoke(parms); 
            }
            else if (exp.NodeType == ExpressionType.Convert)
            {
                return GetValueByExpression(((UnaryExpression)exp).Operand);
            }
            return null;
        }


        private void TranslatSelect(Type resultType, Expression source, LambdaExpression predicate)
        {
            this.TranslatSource(source);
            this.currentContext = predicate.Parameters; 
            // c=>c
            if (predicate.Body.NodeType == ExpressionType.Parameter)
            {
                var parmExp = (ParameterExpression)predicate.Body;
                if (parmExp.Type.IsSubclassOf(typeof(Entity)))
                {
                    var table = getTableByType(parmExp.Type);

                    this.EntityQueryExpression.Select.Fields.Add(
                        new Field("*", table.GetName())
                    );
                }
            }
            //c=> c.CustomerID
            else if (predicate.Body.NodeType == ExpressionType.MemberAccess)
            {
                this.currentSelectMember = (MemberExpression)predicate.Body;
                this.EntityQueryExpression.Select.Fields = new List<Field>()
                {
                    GetFieldByExpression(predicate.Body)
                };
            }
            // c=> new {c. c.CustomerID,  c.EmployeeID }
            else if (predicate.Body.NodeType == ExpressionType.New)
            {
                var newExp = (NewExpression)predicate.Body;
                currentSelector = newExp;
                var argus = newExp.Arguments;
                for (var i = 0; i < argus.Count; i++)
                {
                    var arg = argus[i];
                    if (arg.NodeType == ExpressionType.MemberAccess)
                    {
                        var memExp = (MemberExpression)arg;

                        var table = getTableByType(memExp.Expression.Type);
                        var memInfo = memExp.Member;

                        //注意到 ：这里没有考虑 字段名 与 对象属性名 不一样的情况
                        this.EntityQueryExpression.Select.Fields.Add(
                            new Field(memInfo.Name, table.GetName())
                        );
                    }

                    else if (arg.NodeType == ExpressionType.Constant)
                    {
                        var constantExp = (ConstantExpression)arg;

                        this.EntityQueryExpression.Select.Fields.Add(
                            new Field("N'{0}'".FormatWith(constantExp.Value.ToStr())).As(newExp.Members[i].Name)
                        );
                    }
                }

            } 
        }

    }
}
