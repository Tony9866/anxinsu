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

        [WebMethod]
        [SoapHeader("authentication")]
        public string VerificationCode(string phone, int SendType)
        {
            //if (!authentication.ValideUser())
            //{
            //    return "{'headerError'}";
            //}
            return api.VerificationCode(phone, SendType);
        }


        [WebMethod]
        [SoapHeader("authentication")]
        public string BindingPhone(string Data, string Phone, string Code)
        {
            //if (!authentication.ValideUser())
            //{
            //    return "{'headerError'}";
            //}
            return api.BindingPhone(Data, Phone, Code);
        }


        [WebMethod]
        [SoapHeader("authentication")]
        public string ThirdParty(string Access_Token, string Openid, int LoginType)
        {
            //if (!authentication.ValideUser())
            //{
            //    return "{'headerError'}";
            //}
            return api.ThirdParty(Access_Token, Openid, LoginType);
        }


        /// <summary>
        /// 获取省
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetProvinces()
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            return api.GetProvinces();
        }

        /// <summary>
        /// 获取市
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetCity(string ProvincesId)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            return api.GetCity(ProvincesId);
        }

        /// <summary>
        /// 获取区(县)
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetArea(string CityId)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            return api.GetArea(CityId);
        }

        /// <summary>
        /// 获取房屋属性(发布房屋,请求房屋需要设置的属性)
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetBasicAttributes()
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            return api.GetBasicAttributes();
        }

        

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
                //http://api.map.baidu.com/geocoder/v2/?ak=KDvCCHCGFeWj10e2rHFSCX3p83b8Gz5COk&callback=renderReverse&location=  自己网上申请
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
