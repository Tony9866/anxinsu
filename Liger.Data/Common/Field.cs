using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Liger.Common;
using Liger.Common.Extensions;
namespace Liger.Data
{
    /// <summary>
    /// 字段信息   
    /// </summary>
    /// <typeparam name="T">实体</typeparam>
    [Serializable]
    public class Field<T> : Field
        where T : Entity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fileName">字段名</param>
        public Field(string fileName) : base(fileName, EntityHelper.GetName<T>()) { }
    }

    /// <summary>
    /// 字段信息
    /// </summary>
    [Serializable]
    public class Field : ICloneable<Field>
    {
        #region 构造函数
        /// <summary>
        /// 空的构造函数
        /// </summary>
        Field() { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fieldName"></param>
        public Field(string fieldName) : this(fieldName, null) 
        { 
        }
 

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="tableName"></param>
        public Field(string fieldName, string tableName) 
            : this(fieldName, tableName, null, null, fieldName) 
        { 
        }

         /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="tableName"></param>
        public Field(string fieldName, string tableName, DbType? dbType)
            : this(fieldName, tableName, dbType, null, null)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="tableName"></param>
        public Field(string fieldName, string tableName, DbType? dbType, string description)
            : this(fieldName, tableName, dbType, null, description)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="tableName"></param>
        /// <param name="description"></param>
        public Field(string fieldName, string tableName, string description) 
            : this(fieldName, tableName, null, null, description) 
        { 
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="tableName"></param>
        /// <param name="parameterDbType"></param>
        /// <param name="parameterSize"></param>
        /// <param name="description"></param>
        public Field(string fieldName, string tableName, DbType? parameterDbType, int? parameterSize, string description) 
            : this(fieldName, tableName, parameterDbType, parameterSize, description, null) 
        { 
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fieldName"></param
        /// <param name="tableName"></param>
        /// <param name="parameterDbType"></param>
        /// <param name="parameterSize"></param>
        /// <param name="description"></param>
        /// <param name="aliasName"></param>
        public Field(string fieldName, string tableName, DbType? parameterDbType, int? parameterSize, string description, string aliasName)
        {
            this.fieldName = fieldName;
            this.tableName = tableName;
            this.description = description;
            this.aliasName = aliasName;
            this.parameterDbType = parameterDbType;
            this.parameterSize = parameterSize;
        }
        #endregion

        #region 字段名、表名、别名等

        /// <summary>
        /// 字段名
        /// </summary>
        private string fieldName;

        /// <summary>
        /// 表名
        /// </summary>
        private string tableName;

        /// <summary>
        /// 字段别名
        /// </summary>
        private string aliasName;

        /// <summary>
        /// 字段描述
        /// </summary>
        private string description;

        /// <summary>
        /// 字段数据库中类型
        /// </summary>
        private DbType? parameterDbType;

        /// <summary>
        /// 字段数据库中长度
        /// </summary>
        private int? parameterSize;

        /// <summary>
        /// 所有字段   就是  *  
        /// </summary>
        public static readonly Field All = new Field("*");

        #endregion

        #region 常量
        private const string LIKE_STRING = "%"; 
        private const string SELECT_IN_STRING = " IN ";
        private const string SELECT_NOTIN_STRING = " NOT IN ";
        #endregion

        #region 属性

        /// <summary>
        /// 字段数据库中类型
        /// </summary>
        public DbType? ParameterDbType
        {
            get { return parameterDbType; }
        }

        /// <summary>
        /// 字段数据库中长度
        /// </summary>
        public int? ParameterSize
        {
            get { return parameterSize; }
        }
       
         

        /// <summary>
        /// 返回  别名
        /// 当别名为空返回字段名
        /// </summary>
        public string Name
        {
            get
            {
                if (aliasName.IsNullOrEmpty())
                    return fieldName;
                return aliasName;
            }
        }

        /// <summary>
        /// 返回属性名  
        /// fieldName
        /// </summary>
        public string PropertyName
        {
            get { return fieldName; }
        }

        /// <summary>
        /// 返回  别名
        /// </summary>
        public string AliasName
        {
            get
            {
                return aliasName;
            }
        }

        /// <summary>
        /// 返回  字段描述
        /// </summary>
        public string Description
        {
            get
            {
                return description;
            }
        }

        /// <summary>
        /// 表名(带前缀、后缀)
        /// </summary>
        public string TableName
        {
            get
            {
                if (tableName.IsNullOrEmpty())
                    return tableName;
                return "{0}" + tableName + "{1}";
            }
        }
        /// <summary>
        /// 字段名 (带前缀、后缀) 
        /// </summary>
        public string FieldName
        {
            get
            {
                if (EntityHelper.IsCompletedFild(fieldName))
                {
                    return fieldName;
                }
                return "{0}".Add(fieldName).Add("{1}");
            }
        }

        /// <summary>
        /// 表名.字段名(带前缀、后缀)
        /// </summary>
        public string FieldNameWithTable
        {
            get
            {
                if (string.IsNullOrEmpty(tableName))
                    return FieldName; 
                return string.Concat(TableName, ".", FieldName);
            }
        }

        /// <summary>
        /// 表名.字段名 AS 别名
        /// </summary>
        public string FullName
        {
            get
            {
                if (string.IsNullOrEmpty(aliasName))
                    return FieldNameWithTable;

                return string.Concat(FieldNameWithTable, " AS {0}", aliasName, "{1}");
            }
        }
         
        
         
        #endregion
         
        #region 判断
        /// <summary>
        /// 比较
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public bool Equals(Field field)
        {
            if (null == (object)field)
                return false;
            return this.FullName.Equals(field.FullName);
        }

        /// <summary>
        /// 判断是否为空
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(Field field)
        {
            if (null == (object)field || string.IsNullOrEmpty(field.PropertyName))
                return true;
            return false;
        }
        #endregion
         
        #region  复制字段并修改,返回常见的字段，比如 sum(amount) as amount


        /// <summary>
        /// 根据两个字段的组合创建一个新的字段
        /// 比如  amount1 + amount2
        /// </summary>
        /// <param name="leftField"></param>
        /// <param name="rightField"></param>
        /// <param name="op"></param>
        /// <returns></returns>
        public static Field Create(Field leftField, Field rightField, QueryOperator op)
        {
            if (IsNullOrEmpty(leftField) && IsNullOrEmpty(rightField))
                return null; 
            if (IsNullOrEmpty(leftField))
                return rightField; 
            if (IsNullOrEmpty(rightField))
                return leftField;
            return new Field("(" + leftField.FieldNameWithTable + DataHelper.GetOperatorQueryText(op) + rightField.FieldNameWithTable + ")");
        }


        /// <summary>
        /// 重新设置所属表名
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public Field SetTableName(string tableName)
        {
            return new Field(this.fieldName, tableName, this.parameterDbType, this.parameterSize, this.description, this.aliasName);
        }

        /// <summary>
        /// AS
        /// </summary>
        /// <param name="aliasName"></param>
        /// <returns></returns>
        public Field As(string aliasName)
        {
            return new Field(this.fieldName, this.tableName, this.parameterDbType, this.parameterSize, this.description, aliasName);
        }


        /// <summary>
        /// AS
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public Field As(Field field)
        {
            return As(field.Name);
        }

        /// <summary>
        /// 改变表名
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public Field At(string tableName)
        {
            return new Field(this.fieldName, tableName, this.fieldName);
        }
        /// <summary>
        /// 改变表名
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public Field At(Entity table)
        {
            if (table == null) return this;
            return new Field(this.PropertyName, table.GetName(), this.fieldName);
        }

        /// <summary>
        /// 获取 当字段为空时返回另一个字段 的字段
        /// </summary>
        /// <param name="field">字段实体</param>
        /// <returns></returns>
        public Field IsNull(Field field)
        {
            return new Field(string.Concat("isnull(", this.FieldNameWithTable, ",", field.FieldNameWithTable, ")")).As(this);
        }

        /// <summary>
        /// 当字段为空时返回指定值 的字段
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Field IsNull(object value)
        {
            return new Field(string.Concat("isnull(", this.FieldNameWithTable, ",", DataHelper.FormatValue(value), ")")).As(this);
        }

        /// <summary>
        /// Count
        /// </summary>
        /// <returns></returns>
        public Field Count()
        {
            if (this.PropertyName.Trim().Equals("*"))
                return new Field("count(*)").As("cnt");
            return new Field(string.Concat("count(", this.FieldNameWithTable, ")")).As(this);
        }

        /// <summary>
        /// Sum
        /// </summary>
        /// <returns></returns>
        public Field Sum()
        {
            return new Field(string.Concat("sum(", this.FieldNameWithTable, ")")).As(this);
        }

        /// <summary>
        /// Avg
        /// </summary>
        /// <returns></returns>
        public Field Avg()
        {
            return new Field(string.Concat("avg(", this.FieldNameWithTable, ")")).As(this);
        }

        /// <summary>
        /// len
        /// </summary>
        /// <returns></returns>
        public Field Len()
        {
            return new Field(string.Concat("len(", this.FieldNameWithTable, ")")).As(this);
        }


        /// <summary>
        /// ltrim and  rtrim
        /// </summary>
        /// <returns></returns>
        public Field Trim()
        {
            return new Field(string.Concat("ltrim(rtrim(", this.FieldNameWithTable, "))")).As(this);
        }

        /// <summary>
        /// Max
        /// </summary>
        /// <returns></returns>
        public Field Max()
        {
            return new Field(string.Concat("max(", this.FieldNameWithTable, ")")).As(this);
        }

        /// <summary>
        /// Min
        /// </summary>
        /// <returns></returns>
        public Field Min()
        {
            return new Field(string.Concat("min(", this.FieldNameWithTable, ")")).As(this);
        }

        /// <summary>
        /// Left
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public Field Left(int length)
        {
            return new Field(string.Concat("left(", this.FieldNameWithTable, ",", length.ToString(), ")")).As(this);
        }


        /// <summary>
        /// Right
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public Field Right(int length)
        {
            return new Field(string.Concat("right(", this.FieldNameWithTable, ",", length.ToString(), ")")).As(this);
        }


        /// <summary>
        /// substring
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public Field Substring(int startIndex, int endIndex)
        {
            return new Field(string.Concat("substring(", this.FieldNameWithTable, ",", startIndex.ToString(), ",", endIndex.ToString(), ")")).As(this);
        }
         

        /// <summary>
        /// replace
        /// </summary>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        public Field Replace(string oldValue, string newValue)
        {
            return new Field(string.Concat("replace(", this.FieldNameWithTable, ",", DataHelper.FormatValue(oldValue), ",", DataHelper.FormatValue(newValue), ")")).As(this);
        }




        /// <summary>
        /// datepart   year
        /// </summary>
        public Field Year()
        {
             
                return new Field(string.Concat("datepart(year,", this.FieldNameWithTable, ")")).As(this);
             
        }

        /// <summary>
        /// datepart   month
        /// </summary>
        public Field Month()
        {

            return new Field(string.Concat("datepart(month,", this.FieldNameWithTable, ")")).As(this);
             
        }

        /// <summary>
        /// datepart  day
        /// </summary>
        public Field Day()
        {
             
                return new Field(string.Concat("datepart(day,", this.FieldNameWithTable, ")")).As(this);
            
        }

        

        #endregion

        #region 返回 in、not in、字符串 like 的条件 、Between的条件

        /// <summary>
        /// 返回 in 条件
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public WhereExpression SelectIn(IEnumerable values)
        {
            return WhereExpression.Create(this, values, QueryOperator.In);
        } 
       
        /// <summary>
        /// 返回 not in 条件
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public WhereExpression SelectNotIn(IEnumerable values)
        {
            return WhereExpression.Create(this, values, QueryOperator.NotIn);
        }

        /// <summary>
        /// 返回 int 子查询
        /// </summary>
        /// <param name="subQuery"></param>
        /// <returns></returns>
        public WhereExpression SelectIn(IEntityQueryable subQuery)
        {
            return WhereExpression.Create(this, subQuery, QueryOperator.In);
        }
        /// <summary>
        /// 返回 not int 子查询
        /// </summary>
        /// <param name="subQuery"></param>
        /// <returns></returns>
        public WhereExpression SelectNotIn(IEntityQueryable subQuery)
        {
            return WhereExpression.Create(this, subQuery, QueryOperator.NotIn);
        } 


        /// <summary>
        /// Between操作
        /// </summary>
        /// <param name="leftValue"></param>
        /// <param name="rightValue"></param>
        /// <returns></returns>
        public WhereExpression Between(object leftValue, object rightValue)
        {
            var exp = (this >= leftValue) && (this <= rightValue);
            return exp;
        }
        /// <summary>
        /// like
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public WhereExpression Like(string value)
        {
            return WhereExpression.Create(this, string.Concat(LIKE_STRING, value, LIKE_STRING), QueryOperator.Like);
        } 
        /// <summary>
        /// 开始字符匹配
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public WhereExpression StartsWith(string value)
        {
            return WhereExpression.Create(this, string.Concat(LIKE_STRING, value), QueryOperator.Like); 
        }
        /// <summary>
        /// 结束字符匹配
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public WhereExpression EndsWith(string value)
        {
            return WhereExpression.Create(this, string.Concat(value, LIKE_STRING), QueryOperator.Like);
        } 

        #endregion  

        #region 快速返回排序或分组的表达式
        /// <summary>
        /// 倒序
        /// </summary>
        public OrderByExpression Desc
        {
            get
            {
                return new OrderByExpression(this, OrderByDirection.Desc);
            }
        }


        /// <summary>
        /// 正序
        /// </summary>
        public OrderByExpression Asc
        {
            get
            {
                return new OrderByExpression(this, OrderByDirection.Asc);
            }
        }


        /// <summary>
        /// 分组
        /// </summary>
        public GroupByExpression GroupBy
        {
            get
            {
                return new GroupByExpression(this);
            }
        }
        #endregion 

        #region Equals 、 GetHashCode 、Clone
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public Field Clone()
        {
            return DataHelper.Clone(this) as Field;
        }
        #endregion
         
        #region 运算符重载

        #region 两个字段的比较 比如 Project._.Q1 == Project._.Q2
        public static WhereExpression operator ==(Field leftField, Field rightField)
        {
            if((rightField as object) == null)
                return WhereExpression.Create(leftField, (object)null, QueryOperator.Equal);
            return WhereExpression.Create(leftField, rightField, QueryOperator.Equal);
        }

        public static WhereExpression operator !=(Field leftField, Field rightField)
        {
            if ((rightField as object) == null)
                return WhereExpression.Create(leftField, (object)null, QueryOperator.NotEqual);
            return WhereExpression.Create(leftField, rightField, QueryOperator.NotEqual);
        }

        public static WhereExpression operator >(Field leftField, Field rightField)
        {
            return WhereExpression.Create(leftField, rightField, QueryOperator.Greater);
        }

        public static WhereExpression operator >=(Field leftField, Field rightField)
        {
            return WhereExpression.Create(leftField, rightField, QueryOperator.GreaterOrEqual);
        }

        public static WhereExpression operator <(Field leftField, Field rightField)
        {
            return WhereExpression.Create(leftField, rightField, QueryOperator.Less);
        }

        public static WhereExpression operator <=(Field leftField, Field rightField)
        {
            return WhereExpression.Create(leftField, rightField, QueryOperator.LessOrEqual);
        }
        #endregion

        #region 字段和值的比较 比如 Project._.Q1 == 1001 ，支持子查询

        /// <summary>
        /// value 字段值的匹配，或者子查询的匹配
        /// 可以是子查询表达式 只需要继承了IEntityQueryable接口，实则上，用于 dbcontext的From以后都可以用在这里
        /// 比如： 
        /// var result = Db.From&lt;Orders&gt;()
        ///  .Where(Orders._.CustomerID ==
        ///  Db.From&lt;Customers&gt;().Where(Customers._.ContactName == "ALFKI").Select(Customers._.CustomerID).Distinct()
        ///  )
        ///  .ToDataTable();
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static WhereExpression operator ==(Field field, object value)
        {
            return WhereExpression.Create(field, value, QueryOperator.Equal);
        } 
        public static WhereExpression operator ==(object value, Field field)
        {
            return WhereExpression.Create(value, field, QueryOperator.Equal);
        }
        /// <summary>
        /// value 字段值的匹配，或者子查询的匹配
        /// 可以是子查询表达式 只需要继承了IEntityQueryable接口，实则上，用于 dbcontext的From以后都可以用在这里
        /// 比如： 
        /// var result = Db.From&lt;Orders&gt;()
        ///  .Where(Orders._.CustomerID !=
        ///  Db.From&lt;Customers&gt;().Where(Customers._.ContactName == "ALFKI").Select(Customers._.CustomerID).Distinct()
        ///  )
        ///  .ToDataTable();
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static WhereExpression operator !=(Field field, object value)
        {
            return WhereExpression.Create(field, value, QueryOperator.NotEqual);
        } 
        public static WhereExpression operator !=(object value, Field field)
        {
            return WhereExpression.Create(value, field, QueryOperator.NotEqual);
        }
        /// <summary>
        /// value 字段值的匹配，或者子查询的匹配
        /// 可以是子查询表达式 只需要继承了IEntityQueryable接口，实则上，用于 dbcontext的From以后都可以用在这里
        /// 比如： 
        /// var result = Db.From&lt;Orders&gt;()
        ///  .Where(Orders._.CustomerID >
        ///  Db.From&lt;Customers&gt;().Where(Customers._.ContactName == "ALFKI").Select(Customers._.CustomerID).Distinct()
        ///  )
        ///  .ToDataTable();
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static WhereExpression operator >(Field field, object value)
        {
            return WhereExpression.Create(field, value, QueryOperator.Greater);
        }
        public static WhereExpression operator >(object value, Field field)
        {
            return WhereExpression.Create(value, field, QueryOperator.Less);
        }

        /// <summary>
        /// value 字段值的匹配，或者子查询的匹配
        /// 可以是子查询表达式 只需要继承了IEntityQueryable接口，实则上，用于 dbcontext的From以后都可以用在这里
        /// 比如： 
        /// var result = Db.From&lt;Orders&gt;()
        ///  .Where(Orders._.CustomerID >=
        ///  Db.From&lt;Customers&gt;().Where(Customers._.ContactName == "ALFKI").Select(Customers._.CustomerID).Distinct()
        ///  )
        ///  .ToDataTable();
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static WhereExpression operator >=(Field field, object value)
        {
            return WhereExpression.Create(field, value, QueryOperator.GreaterOrEqual);
        }
        public static WhereExpression operator >=(object value, Field field)
        {
            return WhereExpression.Create(value, field, QueryOperator.LessOrEqual);
        }
        /// <summary>
        /// value 字段值的匹配，或者子查询的匹配
        /// 可以是子查询表达式 只需要继承了IEntityQueryable接口，实则上，用于 dbcontext的From以后都可以用在这里
        /// 比如： 
        /// var result = Db.From&lt;Orders&gt;()
        ///  .Where(Orders._.CustomerID <
        ///  Db.From&lt;Customers&gt;().Where(Customers._.ContactName == "ALFKI").Select(Customers._.CustomerID).Distinct()
        ///  )
        ///  .ToDataTable();
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static WhereExpression operator <(Field field, object value)
        {
            return WhereExpression.Create(field, value, QueryOperator.Less);
        }
        public static WhereExpression operator <(object value, Field field)
        {
            return WhereExpression.Create(value, field, QueryOperator.Greater);
        }
        /// <summary>
        /// value 字段值的匹配，或者子查询的匹配
        /// 可以是子查询表达式 只需要继承了IEntityQueryable接口，实则上，用于 dbcontext的From以后都可以用在这里
        /// 比如： 
        /// var result = Db.From&lt;Orders&gt;()
        ///  .Where(Orders._.CustomerID <=
        ///  Db.From&lt;Customers&gt;().Where(Customers._.ContactName == "ALFKI").Select(Customers._.CustomerID).Distinct()
        ///  )
        ///  .ToDataTable();
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static WhereExpression operator <=(Field field, object value)
        {
            return WhereExpression.Create(field, value, QueryOperator.LessOrEqual);
        }
        public static WhereExpression operator <=(object value, Field field)
        {
            return WhereExpression.Create(value, field, QueryOperator.GreaterOrEqual);
        }
        #endregion 
 


        #region 两个字段的组合 比如 Project._.Q1 + Project._.Q2
        /// <summary>
        /// +
        /// </summary>
        /// <param name="leftField"></param>
        /// <param name="rightField"></param>
        /// <returns></returns>
        public static Field operator +(Field leftField, Field rightField)
        {
            return Field.Create(leftField, rightField, QueryOperator.Add);
        }

        /// <summary>
        /// -
        /// </summary>
        /// <param name="leftField"></param>
        /// <param name="rightField"></param>
        /// <returns></returns>
        public static Field operator -(Field leftField, Field rightField)
        {
            return Field.Create(leftField, rightField, QueryOperator.Subtract);
        }

        /// <summary>
        /// *
        /// </summary>
        /// <param name="leftField"></param>
        /// <param name="rightField"></param>
        /// <returns></returns>
        public static Field operator *(Field leftField, Field rightField)
        {
            return Field.Create(leftField, rightField, QueryOperator.Multiply);
        }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="leftField"></param>
        /// <param name="rightField"></param>
        /// <returns></returns>
        public static Field operator /(Field leftField, Field rightField)
        {
            return Field.Create(leftField, rightField, QueryOperator.Divide);
        }

        /// <summary>
        /// %
        /// </summary>
        /// <param name="leftField"></param>
        /// <param name="rightField"></param>
        /// <returns></returns>
        public static Field operator %(Field leftField, Field rightField)
        {
            return Field.Create(leftField, rightField, QueryOperator.Modulo);
        }
        #endregion

        #endregion

 
    }


}
