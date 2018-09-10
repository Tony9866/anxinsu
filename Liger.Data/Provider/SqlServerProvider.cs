using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using Liger.Common;

namespace Liger.Data.SqlServer
{
    public class SqlServerProvider : DbProvider
    {
        public SqlServerProvider(string connectionString)
            : this(connectionString, SqlClientFactory.Instance)
        {
        }

        public SqlServerProvider(string connectionString, DbProviderFactory dbFactory)
            : base(connectionString, dbFactory, '[', ']', '@')
        {
        }

        public override string RowAutoID
        {
            get { return "select scope_identity()"; }
        }

        public override bool SupportBatch
        {
            get { return true; }
        }


        public override void PrepareCommand(DbCommand cmd)
        {
            base.PrepareCommand(cmd); 
            foreach (DbParameter p in cmd.Parameters)
            {
                if (p.Direction == ParameterDirection.Output || p.Direction == ParameterDirection.ReturnValue)
                {
                    continue;
                } 
                object value = p.Value;
                if (value == DBNull.Value || value == null)
                {
                    p.Value = DBNull.Value;
                    continue;
                }
                Type type = value.GetType();
                SqlParameter sqlParam = (SqlParameter)p; 
                if (type == typeof(Guid))
                {
                    sqlParam.SqlDbType = SqlDbType.UniqueIdentifier;
                    continue;
                } 
                switch (p.DbType)
                {
                    case DbType.Binary:
                        if (((byte[])value).Length > 8000)
                        {
                            sqlParam.SqlDbType = SqlDbType.Image;
                        }
                        break;
                    case DbType.Time: 
                    case DbType.DateTime:
                        sqlParam.SqlDbType = SqlDbType.DateTime;
                        break;
                    case DbType.AnsiString:
                        if (value.ToString().Length > 8000)
                        {
                            sqlParam.SqlDbType = SqlDbType.Text;
                        }
                        break;
                    case DbType.String:
                        if (value.ToString().Length > 4000)
                        {
                            sqlParam.SqlDbType = SqlDbType.NText;
                        }
                        break;
                    case DbType.Object:
                        sqlParam.SqlDbType = SqlDbType.NText;
                        p.Value = SerializationManager.Serialize(value);
                        break;
                } 
                if (sqlParam.SqlDbType == SqlDbType.DateTime && type == typeof(TimeSpan))
                {
                    sqlParam.Value = new DateTime(1900, 1, 1).Add((TimeSpan)value);
                    continue;
                }
            } 
        }
    }
}
