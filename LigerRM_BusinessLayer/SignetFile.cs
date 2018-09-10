using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SignetInternet_BusinessLayer
{
    public class SignetFile
    {
        public long ID
        { get; set; }
        public string SignetID { get; set; }
        public string FileType { get; set; }
        public string FileName { get; set; }
        public byte[] FileData { get; set; }
        public string Memo { get; set; }

        public SignetFile(long id)
        {
            SignetFileHelper helper = new SignetFileHelper();
            DataTable dt = helper.SignetFileSelectByID(id);
            foreach (DataRow row in dt.Rows)
            {
                ID = id;
                SignetID = row["sf_signet_id"].ToString();
                FileType = row["sf_file_type"].ToString();
                FileName = row["sf_file_name"].ToString();
                FileData = (byte[])row["sf_file_data"];
                Memo = row["sf_file_demo"].ToString();
            }
        }
    }
}
