using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using LigerRM.Common;

namespace SignetInternet_BusinessLayer
{
    public class DataTransferHelper
    {
        //Create table----------------------------------------------------------------------------
        //GO

        ///****** Object:  Table [dbo].[T_DataTransfer]    Script Date: 11/16/2017 16:30:23 ******/
        //SET ANSI_NULLS ON
        //GO

        //SET QUOTED_IDENTIFIER ON
        //GO

        //SET ANSI_PADDING ON
        //GO

        //CREATE TABLE [dbo].[T_DataTransfer](
        //    [ID] [bigint] IDENTITY(1,1) NOT NULL,
        //    [TableName] [varchar](50) NOT NULL,
        //    [PrimaryKeyID] [varchar](50) NOT NULL,
        //    [PrimaryKeyType] [varchar] (50) NOT NULL,
        //    [KeyValue] [varchar](500) NOT NULL,
        //    [RecordStatus] [varchar](50) NOT NULL,
        //    [RecordDate] [datetime] NOT NULL,
        //    [ExcuteStatus] [bit] NOT NULL,
        //    [ExcuteDate] [datetime] NULL,
        // CONSTRAINT [PK_T_DataTransfer] PRIMARY KEY CLUSTERED 
        //(
        //    [ID] ASC
        //)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
        //) ON [PRIMARY]

        //GO

        //SET ANSI_PADDING OFF
        //GO

        //Trigger ------------------------------------------------------------
        //CREATE trigger [dbo].[t_transfer_data] on [dbo].[t_person_info] 
        //for insert,update,delete as
        //begin
        //declare @id int
        //IF exists(select 1 from inserted) and not exists(select 1 from deleted)
        //begin
        //--INSERT
        //    select @id= ID from inserted
        //    insert into T_DataTransfer values ('t_person_info','ID','int',@id,'0',GETDATE(),'0',null)
        //end

        //IF exists(select 1 from inserted) and exists(select 1 from deleted)
        //begin
        //--UPDATE
        //    select @id= ID from inserted
        //    insert into T_DataTransfer values ('t_person_info','ID','int',@id,'1',GETDATE(),'0',null)
        //end

        //IF exists(select 1 from deleted) and not exists(select 1 from inserted)
        //begin
        //--DELETE
        //    select @id= ID from  deleted
        //    insert into T_DataTransfer values ('t_person_info','ID','int',@id,'2',GETDATE(),'0',null)
        //end
        //end

        private DataTable GetTableStructure(string tableName)
        {
            string sql = "SELECT COLUMN_NAME,DATA_TYPE FROM INFORMATION_SCHEMA.columns WHERE TABLE_NAME='" + tableName + "'";
            return MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
        }

        public void CreateXML(string filename)
        {
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand("select * from T_DataTransfer where ExcuteStatus=0")).Tables[0];
            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "GB2312", null);
            doc.AppendChild(dec);
            //创建一个根节点（一级）
            XmlElement root = doc.CreateElement("Package");
            doc.AppendChild(root);
            //创建节点（二级）
            XmlNode headnode = doc.CreateElement("PackageHead");
            //创建节点（三级）
            XmlElement element1 = doc.CreateElement("UploadTime");
            element1.InnerText = DateTime.Now.ToString("yyyyMMddHHmmss");
            headnode.AppendChild(element1);
            root.AppendChild(headnode);

            XmlNode datanode = doc.CreateElement("Data");

            foreach (DataRow row in dt.Rows)
            {
                //数据集合
                XmlElement recordList = doc.CreateElement("Record");
                recordList.SetAttribute("Name", row["TableName"].ToString());
                recordList.SetAttribute("Key", row["PrimaryKeyID"].ToString());
                recordList.SetAttribute("KeyType", row["PrimaryKeyType"].ToString());
                recordList.SetAttribute("KeyValue", row["KeyValue"].ToString());
                recordList.SetAttribute("OptType", row["RecordStatus"].ToString());

                if (!row["RecordStatus"].ToString().Equals("2")) //for insert and update, exclude delete
                {
                    DataTable dtChild = GetTableStructure(row["TableName"].ToString());
                    foreach (DataRow r in dtChild.Rows) //获取列，循环获取数据
                    {
                        string childSql = string.Empty;
                        if (row["PrimaryKeyType"].ToString().ToLower() == "int" || row["PrimaryKeyType"].ToString().ToLower() == "decimal")
                            childSql = "select * from " + row["TableName"].ToString() + " where " + row["PrimaryKeyID"].ToString() + "=" + row["KeyValue"].ToString();
                        else
                            childSql = "select * from " + row["TableName"].ToString() + " where " + row["PrimaryKeyID"].ToString() + "='" + row["KeyValue"].ToString() + "'";
                        DataTable dtData = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(childSql)).Tables[0];

                        foreach (DataRow rr in dtData.Rows)
                        {
                            XmlElement record = doc.CreateElement(r["COLUMN_NAME"].ToString());
                            record.SetAttribute("DataType", r["DATA_TYPE"].ToString());
                            if (!dtData.Rows[0].IsNull(r["COLUMN_NAME"].ToString()))
                            {
                                if (r["DATA_TYPE"].ToString().ToLower() == "image")
                                    record.InnerText = Convert.ToBase64String((byte[])rr[r["COLUMN_NAME"].ToString()]);
                                else
                                    record.InnerText = rr[r["COLUMN_NAME"].ToString()].ToString();
                            }
                            recordList.AppendChild(record);
                        }
                    }
                }
                datanode.AppendChild(recordList);
            }
            root.AppendChild(datanode);
            doc.Save(filename);
            Console.Write(doc.OuterXml);
        }

        public void TransferDataFromXML(string filename)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(filename);

            XmlNode xn = xml.SelectSingleNode("Package");
            XmlNode xn1 = xn.SelectSingleNode("Data");
            TransferData(xn1);
        }

        private void TransferData(XmlNode xn)
        {
            foreach (XmlNode n in xn.ChildNodes)
            {
                XmlElement xe = (XmlElement)n;
                string tableName = xe.GetAttribute("Name").ToString();
                string key = xe.GetAttribute("Key").ToString();
                string keyType = xe.GetAttribute("KeyType").ToString();
                string optType = xe.GetAttribute("OptType").ToString();
                string keyValue = xe.GetAttribute("KeyValue").ToString();

                string sql = string.Empty;
                DataTable dt = GetTableStructure(tableName);
                //tableName += "_test";
                switch (optType)
                { 
                    case "0": //insert
                        sql = "insert into "+tableName+" ";
                        string columnStr = "(";
                        string valueStr = "values(";
                        foreach (DataRow r in dt.Rows)
                        {
                            columnStr += r["COLUMN_NAME"].ToString() + ",";
                            valueStr += FormatValuesByType(r["DATA_TYPE"].ToString(), n.SelectSingleNode(r["COLUMN_NAME"].ToString()).InnerText) + ",";
                        }
                        columnStr = columnStr.Substring(0, columnStr.Length - 1)+") ";
                        valueStr = valueStr.Substring(0, valueStr.Length - 1) + ") ";
                        sql = sql + columnStr + valueStr;
                        break;
                    case "1":
                        sql = "update " + tableName + " set ";
                        columnStr = "";
                        foreach (DataRow r in dt.Rows)
                        {
                            if (!r["COLUMN_NAME"].ToString().ToLower().Equals(key.ToLower()))
                                columnStr += r["COLUMN_NAME"].ToString() + "=" + FormatValuesByType(r["DATA_TYPE"].ToString(), n.SelectSingleNode(r["COLUMN_NAME"].ToString()).InnerText) + ",";
                        }
                        columnStr= columnStr.Substring(0,columnStr.Length-1);
                        sql = sql + columnStr + " where " + key + "=" + FormatValuesByType(keyType, keyValue);
                        break;
                    case "2":
                        sql = "delete from " + tableName + " where " + key + "=" + FormatValuesByType(keyType, keyValue);
                        break;
                }

                MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
            }
        }

        public string CreateJsonStr()
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

            string sql = "select * from T_DataTransfer";
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            IObject obj = new IObject();
            obj.version = "20140501";
            obj.transactionType = 1;
            obj.iduXml = string.Empty;
            obj.userId = string.Empty;
            obj.table = new List<IfaceTable>();

            foreach (DataRow r in dt.Rows)
            {
                IfaceTable table = new IfaceTable();
                table.row = new List<IfaceRow>();
                table.name = r["TableName"].ToString();
                table.mainTable = true;

                IfaceRow row = new IfaceRow();
                row.column = new List<IfaceColumn>();
                row.type = r["RecordStatus"].ToString().Equals("0") ? "insert" : r["RecordStatus"].ToString().Equals("1") ? "update" : "delete";
                row.srcCondition = r["RecordStatus"].ToString().Equals("0") ?"":r["PrimaryKeyID"].ToString()+"="+FormatValuesByType(r["PrimaryKeyType"].ToString(),r["KeyValue"].ToString());
                
                string sql1 = "select * from "+r["TableName"].ToString()+" where "+r["PrimaryKeyID"].ToString()+"="+FormatValuesByType(r["PrimaryKeyType"].ToString(),r["KeyValue"].ToString());
                DataTable dt1 = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql1)).Tables[0];

                DataTable columnTable = GetTableStructure(r["TableName"].ToString());
                foreach (DataRow cRow in columnTable.Rows)
                {
                    IfaceColumn column = new IfaceColumn();
                    column.name = cRow["COLUMN_NAME"].ToString();
                    if (dt1.Rows[0].IsNull(column.name))
                        column.value = string.Empty;
                    else
                        column.value = dt1.Rows[0][column.name].ToString();

                    row.column.Add(column);
                }
                table.row.Add(row);
                obj.table.Add(table);
            }
            
            return JSONHelper.ToJson(obj);
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
}
