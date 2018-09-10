using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using Liger.Common;
using Liger.Common.Extensions;
using Liger.Data.Resources; 

namespace Liger.Data
{
    /// <summary>
    /// Command 创建对象(用于update、insert和delete时使用的Command)
    /// </summary>
    public class CommandBulider
    {  
        private Database db;
        private DbProvider dbProvider
        {
            get
            {
                return db.DbProvider;
            }
        }

        private ExpressionTranslater CreateTranslater()
        { 
            return new ExpressionTranslater(this.dbProvider); 
        }

        public CommandBulider(Database db)
        {
            this.db = db; 
        }

        /// <summary>
        /// 参数计数器
        /// </summary>
        private int paramCounter = 0;

        /// <summary>
        /// 获取参数名
        /// </summary>
        /// <returns></returns>
        private string CreateParmName()
        {
            //return DataHelper.MakeUniqueKey(string.Empty); 
            return "p" + ++paramCounter;
        }


        #region 更新

        /// <summary>
        /// 创建更新DbCommand
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public DbCommand CreateUpdateCommand<T>(T entity, WhereExpression where)
            where T : Entity
        { 
            List<Field> changedFields = entity.GetChangedFields(); 
            if (changedFields == null || changedFields.Count == 0)
                return null;  
            object[] values = new object[changedFields.Count];
            for (int i = 0, l = changedFields.Count; i < l; i++)
            {
                values[i] = entity.GetValue(changedFields[i].PropertyName);
            } 
            return CreateUpdateCommand<T>(changedFields.ToArray(), values, where);

        }

        /// <summary>
        /// 创建更新DbCommand
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fields"></param>
        /// <param name="values"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public DbCommand CreateUpdateCommand<T>(Field[] fields, object[] values, WhereExpression where)
            where T : Entity
        { 
            Guard.Check(!EntityHelper.IsReadOnly<T>(), TextResource.CanNotReadOnly.FormatWith(EntityHelper.GetName<T>())); 
            if (null == fields || fields.Length == 0 || null == values || values.Length == 0)
                return null; 
            Guard.Check(fields.Length == values.Length, TextResource.ArgumentShouldEqual.FormatWith("字段的个数", "值的个数"));
            int length = fields.Length;
            Field identityField = EntityHelper.GetIdentityField<T>();
            bool identityExist = !Field.IsNullOrEmpty(identityField);

            if (WhereExpression.IsNullOrEmpty(where))
                where = WhereExpression.ALL;

            StringBuilder sql = new StringBuilder();
            sql.Append(ExpressionTranslater.SQL_UPDDATE);
            sql.Append(db.DbProvider.BuildTableName(EntityHelper.GetName<T>()));
            sql.Append(ExpressionTranslater.SQL_UPDATE_SET); 
            List<QueryParameter> list = new List<QueryParameter>();
            StringBuilder colums = new StringBuilder();
            var appended = false;
            for (int i = 0; i < length; i++)
            {
                if (identityExist && fields[i].PropertyName.Equals(identityField.PropertyName)) 
                    continue; 
                if(appended) 
                    colums.Append(",");
                appended = true;
                colums.Append(fields[i].FieldName);
                colums.Append("=");  
                if (values[i] is Field)
                {
                    Field fieldValue = (Field)values[i];
                    colums.Append(fieldValue.FieldNameWithTable);
                }
                else
                {
                    string pname = CreateParmName();
                    colums.Append(pname);
                    var p = new QueryParameter(pname, values[i]);
                    list.Add(p);
                }
            }
            sql.Append(colums);
            var translater = CreateTranslater(); 
            sql.Append(ExpressionTranslater.SQL_WHERE);
            translater.SetParmStartIndex(paramCounter);
            sql.Append(translater.TranslateWhere(where));
            list.AddRange(translater.Params);

            DbCommand cmd = db.GetSqlStringCommand(sql.ToString());

            db.AddCommandParameter(cmd, list.ToArray());
            return cmd;
        }

        #endregion

        #region 删除

        /// <summary>
        /// 创建删除DbCommand
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public DbCommand CreateDeleteCommand(string tableName, WhereExpression where)
        {
            if (WhereExpression.IsNullOrEmpty(where))
                where = WhereExpression.ALL;
            var translater = CreateTranslater();
            StringBuilder sql = new StringBuilder();
            sql.Append(ExpressionTranslater.SQL_DELETEFROM);
            sql.Append(db.DbProvider.BuildTableName(tableName));
            sql.Append(ExpressionTranslater.SQL_WHERE);
            sql.Append(translater.TranslateWhere(where));
            DbCommand cmd = db.GetSqlStringCommand(sql.ToString());
            db.AddCommandParameter(cmd, translater.Params.ToArray());

            return cmd;
        }

        /// <summary>
        /// 创建删除DbCommand
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DbCommand CreateDeleteCommand<T>(WhereExpression where)
             where T : Entity
        {
            return CreateDeleteCommand(EntityHelper.GetName<T>(), where);
        }

        #endregion

        #region 添加

        /// <summary>
        /// 创建添加DbCommand
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fields"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public DbCommand CreateInsertCommand<T>(Field[] fields, object[] values)
            where T : Entity
        {
            Guard.Check(!EntityHelper.IsReadOnly<T>(), TextResource.CanNotReadOnly.FormatWith(EntityHelper.GetName<T>()));
            if (null == fields || fields.Length == 0 || null == values || values.Length == 0)
                return null;

            StringBuilder sql = new StringBuilder();
            sql.Append(ExpressionTranslater.SQL_INSERTINTO);
            sql.Append(db.DbProvider.BuildTableName(EntityHelper.GetName<T>()));
            sql.Append(" (");

            Field identityField = EntityHelper.GetIdentityField<T>();
            bool identityExist = !Field.IsNullOrEmpty(identityField); 
            Dictionary<string, string> insertFields = new Dictionary<string, string>();
            List<QueryParameter> parameters = new List<QueryParameter>();

            int length = fields.Length;

            for (int i = 0; i < length; i++)
            {
                if (identityExist)
                {
                    if (fields[i].PropertyName.Equals(identityField.PropertyName))
                    { 
                        continue;
                    }
                }

                string panme = CreateParmName();
                insertFields.Add(fields[i].FieldName, panme);
                var p = new QueryParameter(panme, values[i], fields[i].ParameterDbType, fields[i].ParameterSize);
                parameters.Add(p);
            }
            StringBuilder fs = new StringBuilder();
            StringBuilder ps = new StringBuilder();

            foreach (KeyValuePair<string, string> kv in insertFields)
            {
                fs.Append(",");
                fs.Append(kv.Key);

                ps.Append(",");
                ps.Append(kv.Value);
            } 
            sql.Append(fs.ToString().Substring(1));
            sql.Append(") " + ExpressionTranslater.SQL_INSERT_VALUES + " (");
            sql.Append(ps.ToString().Substring(1));
            sql.Append(")"); 
            DbCommand cmd = db.GetSqlStringCommand(sql.ToString()); 
            db.AddCommandParameter(cmd, parameters.ToArray());
            return cmd;
        }

        /// <summary>
        /// 创建添加DbCommand
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public DbCommand CreateInsertCommand<T>(T entity)
            where T : Entity
        {
            if (null == entity)
                return null; 
            List<Field> list = entity.GetChangedFields(); 
            if (null == list || list.Count == 0)
            {
                return CreateInsertCommand<T>(entity.GetFields(), entity.GetValues());
            }
            else
            { 
                var values = new object[list.Count];
                for (var i = 0; i < list.Count; i++)
                {
                    values[i] = entity.GetValue(list[i].PropertyName);
                } 
                return CreateInsertCommand<T>(list.ToArray(), values);
            }

        }

        #endregion


    }
}
