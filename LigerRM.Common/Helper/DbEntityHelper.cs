using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Liger.Common;
using Liger.Data;

namespace LigerRM.Common
{
    public class DbEntityHelper
    {
        /// <summary>
        /// DataTableToEntities
        /// </summary> 
        public static List<T> DataTableToEntities<T>(DataTable dt)
            where T: Entity,new()
        {
            var entities = new List<T>();

            if (dt == null) return entities;
            foreach (DataRow dr in dt.Rows)
            {
                var t = DataRowToEntity<T>(dr);
                entities.Add(t);
            }
            return entities;
        }

        /// <summary>
        /// DataRowToEntity
        /// </summary>
        public static T DataRowToEntity<T>(DataRow dr)
            where T : Entity, new()
        {
            T entity = new T();
            foreach (DataColumn column in dr.Table.Columns)
            {
                entity.SetValue(column.ColumnName, dr[column.ColumnName]);
            }
            return entity;
        }
    }
}
