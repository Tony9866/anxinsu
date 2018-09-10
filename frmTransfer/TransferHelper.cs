using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;



namespace frmTransfer
{
    public class TransferHelper
    {
        public string CreateJsonStr(DataRow r)
        {

            // {
            //    "transactionType": 1,
            //    "userId": "",
            //    "table": [
            //        {
            //            "mainTable": true,
            //            "name": "rk_czrk",
            //            "row": [
            //                {
            //                    "column": [
            //                        {
            //                            "name": "c_sfzh",
            //                            "value": "测试身份证号"
            //                        },
            //                        {
            //                            "name": "c_xm",
            //                            "value": "测试姓名"
            //                        }
            //                    ],
            //                    "srcCondition": "",
            //                    "type": "insert"
            //                }
            //            ]
            //        }
            //    ],
            //    "iduXml": "",
            //    "version": "20140501"
            //}

            //string sql = "select top 2 * from T_DataTransfer";
            //DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            IObject obj = new IObject();
            try
            {
                obj.version = "20140501";
                obj.transactionType = 1;
                obj.iduXml = string.Empty;
                obj.userId = string.Empty;
                obj.table = new List<IfaceTable>();

                //foreach (DataRow r in dt.Rows)
                //{
                IfaceTable table = new IfaceTable();
                table.row = new List<IfaceRow>();
                table.name = r["TableName"].ToString();
                table.mainTable = true;

                IfaceRow row = new IfaceRow();
                row.column = new List<IfaceColumn>();
                row.type = r["RecordStatus"].ToString().Equals("0") ? "insert" : r["RecordStatus"].ToString().Equals("1") ? "update" : "delete";
                row.srcCondition = r["RecordStatus"].ToString().Equals("0") ? "" : r["PrimaryKeyID"].ToString() + "=" + FormatValuesByType(r["PrimaryKeyType"].ToString(), r["KeyValue"].ToString());

                string sql1 = "select * from " + r["TableName"].ToString() + " where " + r["PrimaryKeyID"].ToString() + "=" + FormatValuesByType(r["PrimaryKeyType"].ToString(), r["KeyValue"].ToString());
                DataTable dt1 = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql1)).Tables[0];
                DateTime dateValue;
                DataTable columnTable = GetTableStructure(r["TableName"].ToString());
                foreach (DataRow cRow in columnTable.Rows)
                {
                    IfaceColumn column = new IfaceColumn();
                    column.name = cRow["COLUMN_NAME"].ToString();
                    if (dt1.Rows[0].IsNull(column.name))
                        column.value = string.Empty;
                    else
                    {
                        column.value = dt1.Rows[0][column.name].ToString();
                        if (DateTime.TryParse(column.value, out dateValue))
                        {
                            column.value = dateValue.ToString("yyyy-MM-dd HH:mm:ss");
                        }
                    }

                    row.column.Add(column);
                }
                table.row.Add(row);
                obj.table.Add(table);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return JSONHelper.ToJson(obj);
        }

        private DataTable GetTableStructure(string tableName)
        {
            string sql = "SELECT COLUMN_NAME,DATA_TYPE FROM INFORMATION_SCHEMA.columns WHERE TABLE_NAME='" + tableName + "'";
            return MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
        }

        private string FormatValuesByType(string type, string value)
        {
            string formatValue = string.Empty;
            switch (type)
            {
                case "int":
                case "decimal":
                    formatValue = value;
                    break;
                case "varchar":
                case "date":
                case "datetime":
                    formatValue = "'" + value + "'";
                    break;
                case "image":
                    break;
                default:
                    formatValue = "'" + value + "'";
                    break;
            }
            return formatValue;
        }
    }

    public class IObject
    {
        public string version { get; set; }
        public int transactionType { get; set; }
        public string userId { get; set; }
        public List<IfaceTable> table { get; set; }
        public string iduXml { get; set; }
    }

    public class IfaceTable
    {
        public string name { get; set; }
        public bool mainTable { get; set; }
        public List<IfaceRow> row { get; set; }
    }

    public class IfaceRow
    {
        public string type { get; set; }
        public string srcCondition { get; set; }
        public List<IfaceColumn> column { get; set; }
    }

    public class IfaceColumn
    {
        public string name { get; set; }
        public string value { get; set; }
    }
}
