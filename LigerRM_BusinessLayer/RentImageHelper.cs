using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using LigerRM.Common;
using SignetInternet_BusinessLayer;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;

namespace LigerRM_BusinessLayer
{
    public class RentImageHelper
    {
        private static String SqlConnString = MySQLHelper.SqlConnString;
        public void AddRentImage(string guid, string RentNO, string fileName, string memo, string userId)
        {

            StringBuilder strSql1 = new StringBuilder();

            strSql1.Append(" Insert into Rent_Image values ('" + guid + "','" + RentNO + "','" + fileName + "',null,'" + DateTime.Now.ToString() + "','" + userId + "','" + memo + "')");

            List<SqlCommand> listSQL = new List<SqlCommand>();
            listSQL.Add(MySQLHelper.CreateCommand(strSql1.ToString()));

            MySQLHelper.ExecuteNonQueryTrans(SqlConnString, listSQL);
        }

        public void UpdateRentImage(string id, string memo, byte[] data)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@data", SqlDbType.Image),
                    new SqlParameter("@momo", SqlDbType.VarChar,100),
                    new SqlParameter("@id", SqlDbType.VarChar,50)
					};
            parameters[0].Value = data;
            parameters[1].Value = memo;
            parameters[2].Value = id;
            MySQLHelper.ExecuteNonQuery(SqlConnString, MySQLHelper.CreateCommand(CommandType.StoredProcedure, "up_Rent_RentImageUpdateByID", parameters));

        }

        public List<Hashtable> GetRentImages(string rentNO, out string imageCount)
        {
            //List<string> images = new List<string>();
            var images = new List<Hashtable>();
            string sql = "select * from rent_image where rentNo='"+rentNO+"'";
            DataSet ds = MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(sql));
            int count = 0;
            imageCount = ds.Tables[0].Rows.Count.ToString();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (!row.IsNull("ImageData"))
                {
                    var item = new Hashtable();
                    //byte[] data = new byte[0];
                    byte[] zipdata = (byte[])row["ImageData"];//
                    //data = LigerRM.Common.GZipHelper.Decompress(zipdata);
                    FileStream fs = new FileStream(System.Web.HttpContext.Current.Server.MapPath("~") + "\\UploadedFiles\\" + rentNO + count.ToString() + ".jpg", FileMode.OpenOrCreate, FileAccess.Write,FileShare.ReadWrite);
                    fs.Write(zipdata, 0, zipdata.Length);
                    fs.Close();
                    //LigerRM.Common.GZipHelper.DecompressFile(System.Web.HttpContext.Current.Server.MapPath("~") + "\\UploadedFiles\\" + rentNO + count.ToString() + ".gz", System.Web.HttpContext.Current.Server.MapPath("~") + "\\UploadedFiles\\" + rentNO + count.ToString() + ".jpg");
                    string ip = LigerRM.Common.Global.GlobalHelper.GetIPAddress();
                    item.Add("ImageId", row["ImageId"].ToString());
                    item.Add("ImagePath", "UploadedFiles/" + rentNO + count.ToString() + ".jpg");
                    count++;
                    images.Add(item);
                }

            }
            return images;
        }

        public void DelRentImages(string ImageId, string ImagePath)
        {
            string[] sArray = Regex.Split(ImagePath, "/", RegexOptions.IgnoreCase);
            string file = System.Web.HttpContext.Current.Server.MapPath("~") + "\\" + sArray[0] + "\\" + sArray[1];
            if (System.IO.File.Exists(file))
            {
                System.IO.File.Delete(file);
            }
            string sql = "delete from rent_image where ImageID='" + ImageId + "'";
            DataSet ds = MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(sql));
        }
    }
}
