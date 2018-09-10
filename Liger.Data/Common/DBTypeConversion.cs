using System;
using System.Data;
using System.Data.SqlClient;

namespace Liger.Data
{
    public class DBTypeConversion
    {
        private static String[,] DBTypeConversionKey = new String[,] 
        {
         {"BigInt","System.Int64"},
         {"Binary","System.Byte[]"},
         {"Bit","System.Boolean"},
         {"Char","System.String"},
         {"DateTime","System.DateTime"},
         {"Decimal","System.Decimal"},
         {"Float","System.Double"},
         {"Image","System.Byte[]"},
         {"Int","System.Int32"},
         {"Money","System.Decimal"},
         {"NChar","System.String"},
         {"NText","System.String"},
         {"NVarChar","System.String"},
         {"Real","System.Single"},
         {"SmallDateTime","System.DateTime"},
         {"SmallInt","System.Int16"},
         {"SmallMoney","System.Decimal"},
         {"Text","System.String"},
         {"Timestamp","System.DateTime"},
         {"TinyInt","System.Byte"},
         {"UniqueIdentifer","System.Guid"},
         {"VarBinary","System.Byte[]"},
         {"VarChar","System.String"},
         {"Variant","System.Object"}
        }; 
        public static SqlDbType SystemTypeToDbType(System.Type sourceType)
        {
            SqlDbType result;
            String SystemType = sourceType.ToString();
            String DBType = String.Empty;
            int keyCount = DBTypeConversionKey.GetLength(0); 
            for (int i = 0; i < keyCount; i++)
            {
                if (DBTypeConversionKey[i, 1].Equals(SystemType)) DBType = DBTypeConversionKey[i, 0];
            } 
            if (DBType == String.Empty) DBType = "Variant"; 
            result = (SqlDbType)Enum.Parse(typeof(SqlDbType), DBType); 
            return result;
        } 
        public static Type DbTypeToSystemType(SqlDbType sourceType)
        {
            Type result;
            String SystemType = String.Empty;
            String DBType = sourceType.ToString();
            int keyCount = DBTypeConversionKey.GetLength(0); 
            for (int i = 0; i < keyCount; i++)
            {
                if (DBTypeConversionKey[i, 0].Equals(DBType)) SystemType = DBTypeConversionKey[i, 1];
            } 
            if (SystemType == String.Empty) SystemType = "System.Object"; 
            result = Type.GetType(SystemType); 
            return result;
        }
        public static DbType GetDbType(Type type)
        {

            String name = type.Name; 
            DbType val = DbType.String; // default value 
            try
            { 
                val = (DbType)Enum.Parse(typeof(DbType), name, true);

            } 
            catch (Exception)
            { 
                // add error handling to suit your taste 
            } 
            return val;

        }
    }
}