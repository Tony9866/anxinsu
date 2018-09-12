using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Net;
using System.Xml;
using System.IO;
using System.Text;
//using System.Net.Security;
//using System.Security.Cryptography.X509Certificates;

namespace LigerRM.WebService
{
    /// <summary>
    /// NewWebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class NewWebService : System.Web.Services.WebService
    {

        public Authentication authentication = new Authentication();
        public ServiceCredential myCredential;
        /// <summary>
        /// 封装所有方法
        /// </summary>
        Api api = new Api();

        /// <summary>
        /// 首页数据
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string AppHome(string lng, string lat)
        {
            //if (!authentication.ValideUser())
            //{
            //    return "{'headerError'}";
            //}
            return api.AppHome(GetAddress(lng, lat));
        }

        [WebMethod]
        [SoapHeader("authentication")]
        public string GetUserName()
        {
            //if (!authentication.ValideUser())
            //{
            //    return "{'headerError'}";
            //}
            //return api.AppLogin();
            return "";
        }



        //private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        //{
        //    return true; //总是接受   
        //}

        //public static HttpWebResponse CreatePostHttpResponse(string url, string datas, Encoding charset)
        //{
        //    HttpWebRequest request = null;
        //    //HTTPSQ请求
        //    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
        //    request = WebRequest.Create(url) as HttpWebRequest;
        //    request.ProtocolVersion = HttpVersion.Version10;
        //    request.Method = "POST";
        //    request.ContentType = "application/x-www-form-urlencoded";
        //    StringBuilder buffer = new StringBuilder();
        //    buffer.AppendFormat(datas);
        //    byte[] data = charset.GetBytes(buffer.ToString());
        //    using (Stream stream = request.GetRequestStream())
        //    {
        //        stream.Write(data, 0, data.Length);
        //    }
        //    return request.GetResponse() as HttpWebResponse;
        //}



        ///// <summary>
        ///// 根据经纬度获取地址
        ///// </summary>
        ///// <param name="lat">纬度</param>
        ///// <param name="lng">经度</param>
        ///// <returns></returns>
        //[WebMethod]
        //[SoapHeader("authentication")]
        //public string GetAddress(string lat, string lng)
        //{
        //    //if (!authentication.ValideUser())
        //    //{
        //    //    return "{'headerError'}";
        //    //}
        //    string res = "";

        //    string url = "http://api.map.baidu.com/geocoder?output=json&location=" + lat + ",%20" + lng + "&key=37492c0ee6f924cb5e934fa08c6b1676";
        //    WebRequest request = WebRequest.Create(url);
        //    request.Method = "POST";
        //    XmlDocument xmlDoc = new XmlDocument();
        //    string sendData = xmlDoc.InnerXml;
        //    byte[] byteArray = Encoding.Default.GetBytes(sendData);

        //    Stream dataStream = request.GetRequestStream();
        //    dataStream.Write(byteArray, 0, byteArray.Length);
        //    dataStream.Close();

        //    WebResponse response = request.GetResponse();
        //    dataStream = response.GetResponseStream();
        //    StreamReader reader = new StreamReader(dataStream, System.Text.Encoding.GetEncoding("utf-8"));
        //    string responseXml = reader.ReadToEnd();

        //    return responseXml;
        //}






        /// <summary>
        /// 根据经纬度获取地址
        /// </summary>
        /// <param name="lat">纬度</param>
        /// <param name="lng">经度</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        private string GetAddress(string lng, string lat)
        {
            try
            {
                //http://api.map.baidu.com/geocoder/v2/?ak=KDvCCHCGFeWjO9rHFSCX3p83b8Gz5COk&callback=renderReverse&location=  自己网上申请
                string url = @"http://api.map.baidu.com/geocoder/v2/?ak=KDvCCHCGFeWjO9rHFSCX3p83b8Gz5COk&callback=renderReverse&location=" + lat + "," + lng + @"&output=xml&pois=1";
                WebRequest request = WebRequest.Create(url);
                request.Method = "POST";
                XmlDocument xmlDoc = new XmlDocument();
                string sendData = xmlDoc.InnerXml;
                byte[] byteArray = Encoding.Default.GetBytes(sendData);

                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                WebResponse response = request.GetResponse();
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream, System.Text.Encoding.GetEncoding("utf-8"));
                string responseXml = reader.ReadToEnd();

                XmlDocument xml = new XmlDocument();
                xml.LoadXml(responseXml);
                string status = xml.DocumentElement.SelectSingleNode("status").InnerText;
                if (status == "0")
                {
                    //("city")city参数是通过xml里获得的，属返回标签名称如<city></city>
                    XmlNodeList nodes = xml.DocumentElement.GetElementsByTagName("city");
                    if (nodes.Count > 0)
                    {
                        return nodes[0].InnerText;
                    }
                    else
                        return "未获取到位置信息,错误码3";
                }
                else
                {
                    return "未获取到位置信息,错误码1";
                }
            }
            catch (System.Exception ex)
            {
                return "未获取到位置信息,错误码2";
            }
        }

    }
}
