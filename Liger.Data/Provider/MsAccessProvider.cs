using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data.Common;
using System.Data;
using Liger.Data;
using Liger.Common;
using Liger.Common.Extensions;
using System.Text.RegularExpressions;

namespace Liger.Data.MsAccess
{
    public class MsAccessProvider : DbProvider
    {
         
        public MsAccessProvider(string connectionString)
            : base(connectionString, OleDbFactory.Instance, '[', ']', '@')
        {
        }

        public override string RowAutoID
        {
            get { return string.Empty; }
        }

        public override bool SupportBatch
        {
            get { return false; }
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
                OleDbParameter oleDbParam = (OleDbParameter)p;
                DbType dbType = oleDbParam.DbType;
                object value = p.Value;
                if (value == DBNull.Value || value == null)
                {
                    p.Value = DBNull.Value;
                    continue;
                }
                Type valueType = value.GetType();  
                if (dbType != DbType.Guid && valueType == typeof(Guid))
                {
                    oleDbParam.OleDbType = OleDbType.Char;
                    oleDbParam.Size = 36;
                    continue;
                }

                if ((dbType == DbType.Time || dbType == DbType.DateTime) && valueType == typeof(TimeSpan))
                {
                    oleDbParam.OleDbType = OleDbType.Double;
                    oleDbParam.Value = ((TimeSpan)value).TotalDays;
                    continue;
                } 
                switch (dbType)
                {
                    case DbType.Binary:
                        if (((byte[])value).Length > 2000)
                        {
                            oleDbParam.OleDbType = OleDbType.LongVarBinary;
                        }
                        break;
                    case DbType.Time:
                        oleDbParam.OleDbType = OleDbType.LongVarWChar;
                        p.Value = value.ToString();
                        break;
                    case DbType.DateTime:
                        oleDbParam.OleDbType = OleDbType.LongVarWChar;
                        var dateValue = value as Nullable<DateTime>;
                        if(dateValue != null && dateValue.HasValue){
                            p.Value = dateValue.Value.ToString("yyyy-MM-dd hh:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                        }else{
                        p.Value = value.ToString();
                        }
                        break;
                    case DbType.AnsiString:
                        if (value.ToString().Length > 4000)
                        {
                            oleDbParam.OleDbType = OleDbType.LongVarChar;
                        }
                        break;
                    case DbType.String:
                        if (value.ToString().Length > 2000)
                        {
                            oleDbParam.OleDbType = OleDbType.LongVarWChar;
                        }
                        break;
                    case DbType.Object:
                        oleDbParam.OleDbType = OleDbType.LongVarWChar;
                        p.Value = SerializationManager.Serialize(value);
                        break;
                }
            }

            //replace "N'" to "'"
            cmd.CommandText = cmd.CommandText.Replace("N'", "'");

            //replace msaccess specific function names in cmdText
            cmd.CommandText = cmd.CommandText.Replace("upper(", "ucase(")
                            .Replace("lower(", "lcase(")
                            .Replace("substring(", "mid(")
                            .Replace("getdate()", "date() + time()")
                            .Replace("datepart(year", "datepart('yyyy'")
                            .Replace("datepart(month", "datepart('m'")
                            .Replace("datepart(day", "datepart('d'");

            if (REGEX_ISNULL.IsMatch(cmd.CommandText))
            {
                var isnullMath =  REGEX_ISNULL.Match(cmd.CommandText);
                var isnullGroup1 = isnullMath.Groups[1];
                var isnullGroup2 = isnullMath.Groups[2];

                cmd.CommandText = REGEX_ISNULL.Replace(cmd.CommandText, " iif( isnull({0}),{1},{0} )".FormatWith(isnullGroup1, isnullGroup2));
            }
        }
    }

}