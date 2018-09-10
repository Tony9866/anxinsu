using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using Liger.Common.Extensions;
using Liger.Data.Extensions;
using Liger.Data;
namespace LigerRM.Common
{
    public class SqlServer9GridDataBuliderProvider : SqlServerGridDataBuliderProvider
    {
        public SqlServer9GridDataBuliderProvider(DbContext dbContext)
            : base(dbContext)
        {

        }


        /// <summary>
        /// SQL2005/SQL2008的分页方案，你也可以改成存储过程的方式
        /// </summary>
        /// <param name="view"></param>
        /// <param name="where"> </param>
        /// <param name="sortname"></param>
        /// <param name="sortorder"></param>
        /// <param name="pagenumber"></param>
        /// <param name="pagesize"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public override DataTable GetGridRows(string view, string where, string sortname, string sortorder, int? pagenumber, int? pagesize, FilterParam[] parms)
        {
            string commandText = "";

            bool pagable = pagenumber.HasValue && pagesize.HasValue;
            bool sortable = !sortname.IsNullOrEmpty() && !sortorder.IsNullOrEmpty();
             
            if (pagable)
            {
                if (!sortable)
                { 
                    throw new Exception("必须指定一个排序条件"); 
                }
                var orderby = string.Concat("ORDER BY ", sortname, " ", sortorder.EqualsTo("asc") ? "ASC" : "DESC");
                var orderbyREV = string.Concat("ORDER BY ", sortname, " ", sortorder.EqualsTo("asc") ? "DESC" : "ASC");
                var sql = @"SELECT * FROM (SELECT {TOP} FROM {VIEW} WHERE {WHERE}) AS tmptableinner WHERE rowId between {N} and {M}";
                sql = sql.Replace("{N}", ((pagenumber - 1) * pagesize + 1).ToString());
                sql = sql.Replace("{M}", (pagenumber * pagesize).ToString());
                sql = sql.Replace("{VIEW}", view);
                sql = sql.Replace("{TOP}", string.Concat("row_number() over (", orderby, ") as rowId,*"));
                sql = sql.Replace("{WHERE}", where.IsNullOrEmpty() ? "1=1" : where);

                commandText = sql;
            }
            else
            {
                commandText = "SELECT * FROM {VIEW} WHERE {WHERE} ";
                if (sortable)
                {
                    commandText += string.Concat(" ORDER BY ", sortname, " ", sortorder.EqualsTo("asc") ? "ASC" : "DESC");
                }
                commandText = commandText.Replace("{WHERE}", where.IsNullOrEmpty() ? "1=1" : where);
                commandText = commandText.Replace("{VIEW}", view);
            }

            //创建command
            var cmd = this.CreateCommand(commandText, parms);
            //使用liger.Data内置的数据适配器预处理command
            this.DbProvider.PrepareCommand(cmd);
            //执行command
            var ds = this.DbContext.ExecuteDataSet(cmd);
            if (ds == null || ds.Tables.Count == 0)
                return null;
            return ds.Tables[0];
        }
    }
}
