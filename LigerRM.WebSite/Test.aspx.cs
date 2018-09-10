using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Net;
using SignetInternet_BusinessLayer;
using System.Drawing;
using ThoughtWorks.QRCode.Codec;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Security.Cryptography;
using XGAPI;
using XGAPI.Enums;
using LigerRM.Common;
using System.Data;
using LigerRM.Common.FileHelper;
using LigerRM.Common.WebRequestHelper;


public partial class Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //MotorHelper helper = new MotorHelper();
        //helper.LoginMotorPlatform();
        //helper.GetIOLetInfos();
        //DataTransferHelper helper = new DataTransferHelper();
        //helper.TransferDataFromXML("d:\\data.xml");
        //helper.GetPartInfos();
        //string json = "{\"res\":[{\"whois\":{\"pln\":\"TESTA5\",\"etag\":\"\"},\"loc\":{\"logicid\":\"1\"},\"status\":1,\"timeStamp\":\"2017-09-21T10:05:55+08:00\"}]}";
       // Dictionary<string, BanEvent[]> ret1 = JSONHelper.FromJson<Dictionary<string, BanEvent[]>>(json);

       // System.Collections.ArrayList b = JSONHelper.FromJson<System.Collections.ArrayList>(ret1["res"].ToString());

        //List<string> des = new List<string>();
        //des.Add("hzb12345");
        //LockServices.IhzbAttenServiceservice service = new LockServices.IhzbAttenServiceservice();
        //string userId = "hzb_yskj".PadRight(30, ' ') ;
        //string doorId = "0201075500100001";

        ////byte[] hex0 = strToToHexByte(userId + doorId);
        ////byte[] hex1 = strToToHexByte(des[0]);
        //string aa = LigerRM.Common.Global.Encryp.DESEncrypt(userId + doorId, des[0]);
        //string passStr = ToDESEncrypt(userId + doorId, des[0]);
        //string desa = LigerRM.Common.Global.Encryp.DESDecrypt(aa, des[0]);
        //string ret = service.hzb_SetDoorOpen(99, "02500262", userId + doorId);//"52127BFACD980186398D2429CCABEA5F398D2429CCABEA5FA58E70C9F17FA7376D0414DA1BE76F91B2C9CA3A0FDC9F7F");

        //string door = Decrypt(ret.Substring(1), des[0]);

        //LockManager manager = new LockManager();
        //string ret = manager.GetDeviceStatus("0201075500100001");

        //string returnStr = "";
        //var custom = new Dictionary<string, object>();
        //custom.Add("Param", "1");
        //XingeApp androidPush = new XingeApp(2100266015, "30eabd4f5ffe5c06d460be58a6ab29b5");
        //var isSuccess = androidPush.pushSingleDevice("7f52199bcbe92a5a49c7ad995a9cc2a1692bb1d9", "", "单发", "Android测试推送内容", (int)DeviceType.Android, 0, custom, out returnStr);
        //isSuccess = androidPush.pushAllDevice("群发", "Android测试推送内容", (int)DeviceType.Android, 0, custom, out returnStr);
        //RentAttributeHelper h = new RentAttributeHelper();
        //h.ExpiredOrders();

        //LockManager manager = new LockManager();
        //manager.SendMessageToDevice("3a51f8393ab2be20964c4139c096eb73530578fd7767f32a362b3304577a120e", "IOS测试2");
        //RentAttribute info = new RentAttribute(357);

        //RentAttributeHelper helper = new RentAttributeHelper();
        //helper.UploadPersonInfo(info);

        //string sql = "select * from Rent_RentAttribute";
        //DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
        //foreach (DataRow r in dt.Rows)
        //{
        //    try
        //    {
        //        RentInfo info = new RentInfo(r["RentNO"].ToString());
        //        RentAttribute attr = new RentAttribute(int.Parse(r["RRAID"].ToString()));
        //        HuaZeServiceHelper helper = new HuaZeServiceHelper();
        //        string a = helper.UploadRentInfoToHZ(info, attr);
        //    }
        //    catch (Exception ex)
        //    {
        //        continue;
        //    }
        //}
        //string sql = "select * from rent_rent where rentno not in (select rentno from rent_map)";
        //DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
        //RentInfoHelper helper = new RentInfoHelper();
        //foreach (DataRow row in dt.Rows)
        //{
        //    string address = row["raddress"].ToString();

        //    string retStr = helper.GetLocationInfo(address, "天津");
        //    if (retStr.IndexOf("lng") > 0)
        //    {
        //        retStr = retStr.Substring(retStr.IndexOf("\"lng\""));
        //        string lng = retStr.Substring(6, retStr.IndexOf("\n"));
        //        lng = lng.Replace("\n", "").Trim().Replace(",", "");
        //        retStr = retStr.Substring(retStr.IndexOf("\"lat\""));
        //        string lat = retStr.Substring(6, retStr.IndexOf("\n"));
        //        lat = lat.Replace("\n", "").Trim().Replace(",", "");

        //        sql = "insert into rent_map values ('" + row["rentno"].ToString() + "'," + lng + "," + lat + ")";
        //        MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
        //    }
        //}

        //FTPHelper.FtpServerIP = "127.0.0.1";
        //FTPHelper.FtpUserID = "ftp";
        //FTPHelper.FtpPassword = "ftp";
        //FTPHelper.FtpUploadFile("d:\\bb.xml", null);

        //DataTransferHelper helper = new DataTransferHelper();
        //string a = helper.CreateJsonStr();

        //RentAttributeHelper helper = new RentAttributeHelper();
        //RentAttribute info = new RentAttribute();
        //info.RRAID = 688;
        //info.RRAContactName = "周琦";
        //info.RRAIDCard = "130402199101161511";
        //info.RentNo = "1510802898290";
        //helper.UploadPersonInfo(info);

        //int a = (DateTime.Parse("2018-01-17 15:00:00.000") - DateTime.Parse("2018-01-16 15:00:00.000")).Hours;

        //WebRequestPoster.Post("http://219.150.56.178:8081/basemanage/LockManage_ReturnUrl.aspx", "{\"resutcode\":\"0\",\"reason\":\"\"}");
        //if (!Page.IsPostBack)
        //{
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("id");
        //    DataRow row = dt.NewRow();
        //    dt.Rows.Add(row);
        //    DataRow row1 = dt.NewRow();
        //    dt.Rows.Add(row1);
        //    dlImages.DataSource = dt;
        //    dlImages.DataBind();
        //}

        //UserInfoHelper helper = new UserInfoHelper();
        ////helper.InsertUserRole("220", "20");

        //string decode = "";
        //byte[] bytes = Convert.FromBase64String("QW4gZXJyb3Igb2NjdXJyZWQgd2hpbGUgc2VuZGluZyB0aGUgcmVxdWVzdC4NCiAgIGF0IFN5c3RlbS5SdW50aW1lLkNvbXBpbGVyU2VydmljZXMuVGFza0F3YWl0ZXIuVGhyb3dGb3JOb25TdWNjZXNzKFRhc2sgdGFzaykNCiAgIGF0IFN5c3RlbS5SdW50aW1lLkNvbXBpbGVyU2VydmljZXMuVGFza0F3YWl0ZXIuSGFuZGxlTm9uU3VjY2Vzc0FuZERlYnVnZ2VyTm90aWZpY2F0aW9uKFRhc2sgdGFzaykNCiAgIGF0IFN5c3RlbS5SdW50aW1lLkNvbXBpbGVyU2VydmljZXMuVGFza0F3YWl0ZXJgMS5HZXRSZXN1bHQoKQ0KICAgYXQgR29uZ1NoYW5nUHJveHkuU2VydmljZS5SZXF1ZXN0SGFuZGxlci48SGFuZGxlPmRfXzIyLk1vdmVOZXh0KCkNClVuYWJsZSB0byBjb25uZWN0IHRvIHRoZSByZW1vdGUgc2VydmVyDQogICBhdCBTeXN0ZW0uTmV0Lkh0dHBXZWJSZXF1ZXN0LkVuZEdldFJlc3BvbnNlKElBc3luY1Jlc3VsdCBhc3luY1Jlc3VsdCkNCiAgIGF0IFN5c3RlbS5OZXQuSHR0cC5IdHRwQ2xpZW50SGFuZGxlci5HZXRSZXNwb25zZUNhbGxiYWNrKElBc3luY1Jlc3VsdCBhcikNCueUseS6jui/nuaOpeaWueWcqOS4gOauteaXtumXtOWQjuayoeacieato+ehruetlOWkjeaIlui/nuaOpeeahOS4u+acuuayoeacieWPjeW6lO+8jOi/nuaOpeWwneivleWksei0peOAgiAxNzIuMjMuMTMyLjE5OTo4MDgwDQogICBhdCBTeXN0ZW0uTmV0LlNvY2tldHMuU29ja2V0LkVuZENvbm5lY3QoSUFzeW5jUmVzdWx0IGFzeW5jUmVzdWx0KQ0KICAgYXQgU3lzdGVtLk5ldC5TZXJ2aWNlUG9pbnQuQ29ubmVjdFNvY2tldEludGVybmFsKEJvb2xlYW4gY29ubmVjdEZhaWx1cmUsIFNvY2tldCBzNCwgU29ja2V0IHM2LCBTb2NrZXQmIHNvY2tldCwgSVBBZGRyZXNzJiBhZGRyZXNzLCBDb25uZWN0U29ja2V0U3RhdGUgc3RhdGUsIElBc3luY1Jlc3VsdCBhc3luY1Jlc3VsdCwgRXhjZXB0aW9uJiBleGNlcHRpb24pDQo=");

        //string strPath = System.Text.ASCIIEncoding.Default.GetString(bytes);

        //RentAttributeHelper helper = new RentAttributeHelper();
        //helper.SendSMSMessage("毛乃峥", "13920887566");
        LockService.LockManageServices service = new LockService.LockManageServices();
        LockService.Authentication au = new LockService.Authentication();
        au.UserID = "admin";
        au.PassWord = "Lock$$123654";
        au.TimeStamp = "1530542085";
        au.Token = "6010c758a2a84aca0c8f62130b4a3572";
        service.AuthenticationValue = au;
        string ret =  service.DataBindInfo("", "");
    }

    public static bool RemoteCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        if (sslPolicyErrors == SslPolicyErrors.None)
            return true;
        return true;
    }

    public static string ToDESEncrypt(string encryptString, string sKey)
    {
        try
        {

            byte[] keyBytes = Encoding.UTF8.GetBytes(sKey);
            byte[] keyIV = keyBytes;
            byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);

            DESCryptoServiceProvider desProvider = new DESCryptoServiceProvider();

            // java 默认的是ECB模式，PKCS5padding；c#默认的CBC模式，PKCS7padding 所以这里我们默认使用ECB方式
            desProvider.Mode = CipherMode.CBC;
            MemoryStream memStream = new MemoryStream();
            CryptoStream crypStream = new CryptoStream(memStream, desProvider.CreateEncryptor(keyBytes, keyIV), CryptoStreamMode.Write);

            crypStream.Write(inputByteArray, 0, inputByteArray.Length);
            crypStream.FlushFinalBlock();
            //return Convert.ToBase64String(memStream.ToArray());
            return Test.byteToHexStr(memStream.ToArray());
        }
        catch
        {
            return encryptString;
        }
    }

    public string Encrypt(string pToEncrypt, string sKey)
    {
        using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
        {
            byte[] inputByteArray = Encoding.UTF8.GetBytes(pToEncrypt);
            des.Key = Encoding.UTF8.GetBytes(sKey);
            des.IV = Encoding.UTF8.GetBytes(sKey);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();

             //DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
             //MemoryStream mStream = new MemoryStream();
             //CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);

            using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
            {
                
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                cs.Close();
            }
            //string str = Convert.ToBase64String(ms.ToArray());
            string str = Test.byteToHexStr(ms.ToArray());
            ms.Close();
            return str;
        }
    }

     public static string EncryptDES(string encryptString, string encryptKey)
      {
          try
          {           
              byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
              byte[] rgbIV = Encoding.UTF8.GetBytes(encryptKey);
              byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
               DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
               dCSP.Mode = CipherMode.ECB;
               MemoryStream mStream = new MemoryStream();
               CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
               cStream.Write(inputByteArray, 0, inputByteArray.Length);
               cStream.FlushFinalBlock();
               string str = Test.byteToHexStr(mStream.ToArray());
               return str; //Convert.ToBase64String(mStream.ToArray());
           }
          catch
          {
              return encryptString;
          }
      }

    public static string byteToHexStr(byte[] bytes)
    {
        string returnStr = "";
        if (bytes != null)
        {
            for (int i = 0; i < bytes.Length; i++)
            {
                returnStr += bytes[i].ToString("X2");
            }
        }
        return returnStr;
    }



    public string Decrypt(string pToDecrypt, string sKey)
    {
        byte[] inputByteArray = Convert.FromBase64String(pToDecrypt);
        using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
        {
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
            {
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                cs.Close();
            }
            string str = Encoding.UTF8.GetString(ms.ToArray());
            ms.Close();
            return str;
        }
    }

    public static string Encrypt_DES16(string str_in_data, string str_DES_KEY) //数据为十六进制
    {
        try
        {
            byte[] shuju = new byte[8];
            byte[] keys = new byte[8];
            for (int i = 0; i < 8; i++)
            {
                shuju[i] = Convert.ToByte(str_in_data.Substring(i * 2, 2), 16);
                keys[i] = Convert.ToByte(str_DES_KEY.Substring(i * 2, 2), 16);
            }
            DES desEncrypt = new DESCryptoServiceProvider();
            desEncrypt.Mode = CipherMode.CBC;
            //desEncrypt.Key = ASCIIEncoding.ASCII.GetBytes(str_DES_KEY);
            desEncrypt.Key = keys;
            byte[] Buffer;
            Buffer = shuju;//ASCIIEncoding.ASCII.GetBytes(str_in_data);
            ICryptoTransform transForm = desEncrypt.CreateEncryptor();
            byte[] R;
            R = transForm.TransformFinalBlock(Buffer, 0, Buffer.Length);
            string return_str = "";
            foreach (byte b in R)
            {
                return_str += b.ToString("X2");
            }
            return_str = return_str.Substring(0, 16);
            return return_str;
        }
        catch (Exception e)
        {
            throw e;
        }
    }



    public string CreateQR(string nr)
    {
        Bitmap bt;
        if (!string.IsNullOrEmpty(nr))
        {
            string filename = Guid.NewGuid().ToString().ToUpper();
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            bt = qrCodeEncoder.Encode(nr, Encoding.UTF8);
            string imgPath = System.Web.HttpContext.Current.Server.MapPath("~/Images/") + filename + ".jpg";
            try
            {
                bt.Save(imgPath);
                return imgPath;
            }
            catch (Exception)
            {
                return "";
            }
        }
        else
        {
            return "";
        }
    }
    protected void btnLoad_Click(object sender, EventArgs e)
    {
        ((System.Web.UI.WebControls.Image)(((Button)sender).Parent).FindControl("imgTarget")).ImageUrl = "~/images/house-1.png";
    }
}