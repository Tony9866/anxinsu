using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace SignetInternet_BusinessLayer
{
    public class AttachmentInfo
    {
        private static String SqlConnString = MySQLHelper.SqlConnString;

        private string m_signetId;
        private int? m_attachmentId;
        private string m_attachmentTitle;
        private string m_attachmentDemo;
        private DateTime m_createDate;
        private byte[] m_fileInfo;

        public int? AttachmentID { get { return m_attachmentId; } set { m_attachmentId = value; } }
        public string SignetID { get { return m_signetId; } set { m_signetId = value; } }
        public string Title { get { return m_attachmentTitle; } set { m_attachmentTitle = value; } }
        public string AttachmentDemo { get { return m_attachmentDemo; } set { m_attachmentDemo = value; } }
        public DateTime CreateDate { get { return m_createDate; } set { m_createDate = value; } }
        public byte[] FileInfo { get { return m_fileInfo; } set { m_fileInfo = value; } }

        public AttachmentInfo() { }
        public AttachmentInfo(int attachmentId)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select * from t_signet_attachment where sa_attachment_id=@attachmentId");
            SqlParameter[] parameters = {
                                        new SqlParameter("@attachmentId",SqlDbType.BigInt),
                                        };
            parameters[0].Value = attachmentId;
            DataTable attachmentTable = MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(sqlStr.ToString(), parameters)).Tables[0];
            if (attachmentTable != null && attachmentTable.Rows.Count > 0)
            {
                m_attachmentId = attachmentId;
                m_signetId = attachmentTable.Rows[0]["sa_signet_id"].ToString();
                m_attachmentTitle = attachmentTable.Rows[0]["sa_attachment_description"].ToString();
                m_attachmentDemo = attachmentTable.Rows[0]["sa_attachment_demo"].ToString();
                m_createDate = DateTime.Parse(attachmentTable.Rows[0]["sa_attachment_date"].ToString());
                if (!attachmentTable.Rows[0].IsNull("sa_attachment_mark"))
                {
                    m_fileInfo = (byte[])attachmentTable.Rows[0]["sa_attachment_mark"];
                    FileStream fileStream = new FileStream(System.Web.HttpContext.Current.Server.MapPath("~") + "\\temp_" + attachmentId.ToString() + ".jpg", FileMode.Create, FileAccess.ReadWrite);
                    fileStream.Write(m_fileInfo, 0, m_fileInfo.Length);
                    fileStream.Flush();
                    fileStream.Dispose();
                }
            }
        }
    }
}
