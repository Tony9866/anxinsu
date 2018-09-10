using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Xml;

namespace LigerRM.Common.WebRequestHelper
{
    public static class WebRequestPoster
    {
        public static string PostHttpRequest(string url, string data)
        {

            //string postData = "arg0=hello"; // 要发放的数据 
            byte[] byteArray = Encoding.UTF8.GetBytes(data);
            X509Certificate objx509 = new X509Certificate(System.Web.HttpContext.Current.Server.MapPath("~") + "\\cer\\nid.crt");
            HttpWebRequest objWebRequest = (HttpWebRequest)WebRequest.Create(url);
            objWebRequest.ClientCertificates.Add(objx509);
            objWebRequest.Method = "POST";
            objWebRequest.ContentType = "application/x-www-form-urlencoded";
            Stream newStream = objWebRequest.GetRequestStream();
            // Send the data. 
            newStream.Write(byteArray, 0, byteArray.Length); //写入参数 
            newStream.Close();
            //ProtocolVersion = System.Net.HttpVersion.Version10
            //objWebRequest.ServicePoint.Expect100Continue = false;
            //objWebRequest.ProtocolVersion = System.Net.HttpVersion.Version10;
            ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidationCallback;
            HttpWebResponse response = (HttpWebResponse)objWebRequest.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string textResponse = sr.ReadToEnd(); // 返回的数据
            if (response != null)
            {
                response.Close();
            }
            if (objWebRequest != null)
            {
                objWebRequest.Abort();
            }
            return textResponse;
        }

        public static string Post(string url, string jsonParas)
        {

            //创建一个HTTP请求  
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //Post请求方式  
            request.Method = "POST";
            //内容类型
            request.ContentType = "application/x-www-form-urlencoded";

            //设置参数，并进行URL编码  
            //虽然我们需要传递给服务器端的实际参数是JsonParas(格式：[{\"UserID\":\"0206001\",\"UserName\":\"ceshi\"}])，
            //但是需要将该字符串参数构造成键值对的形式（注："paramaters=[{\"UserID\":\"0206001\",\"UserName\":\"ceshi\"}]"），
            //其中键paramaters为WebService接口函数的参数名，值为经过序列化的Json数据字符串
            //最后将字符串参数进行Url编码
            string paraUrlCoded = System.Web.HttpUtility.UrlEncode("strData");
            paraUrlCoded += "=" + System.Web.HttpUtility.UrlEncode(jsonParas);

            byte[] payload;
            //将Json字符串转化为字节  
            payload = System.Text.Encoding.UTF8.GetBytes(paraUrlCoded);
            //设置请求的ContentLength   
            //request.ContentLength = payload.Length;
            //发送请求，获得请求流  

            Stream writer;
            try
            {
                X509Certificate objx509 = new X509Certificate(System.Web.HttpContext.Current.Server.MapPath("~") + "\\cer\\nid.crt");
                request.ClientCertificates.Add(objx509);
                writer = request.GetRequestStream();//获取用于写入请求数据的Stream对象
            }
            catch (Exception)
            {
                writer = null;
                Console.Write("连接服务器失败!");
            }
            //将请求参数写入流
            writer.Write(payload, 0, payload.Length);
            writer.Close();//关闭请求流

            String strValue = "";//strValue为http响应所返回的字符流
            HttpWebResponse response;
            try
            {
                //获得响应流
                ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidationCallback;
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                response = ex.Response as HttpWebResponse;
            }

            Stream s = response.GetResponseStream();
            StreamReader sr = new StreamReader(s, Encoding.UTF8);
            strValue = sr.ReadToEnd();

            return strValue;//返回Json数据
        }

        public static bool RemoteCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == SslPolicyErrors.None)
                return true;
            return true;
        }

        public static string PostHttpRequest(string data)
        {
            string url = ConfigurationManager.AppSettings["ElectronicServiceUrl"];
            return PostHttpRequest(url, data);
        }

        /// <summary>
        /// GET请求与获取结果
        /// </summary>
        public static string HttpGet(string Url, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            X509Certificate objx509 = new X509Certificate(System.Web.HttpContext.Current.Server.MapPath("~") + "\\cer\\nid.crt");
            request.ClientCertificates.Add(objx509);

            ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidationCallback;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }

        public static string PostJson(string Url, string jsonParas,Dictionary<string,string> otherParas)
        {
            string strURL = Url;

            //创建一个HTTP请求  
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strURL);
            //Post请求方式  
            request.Method = "POST";
            foreach (KeyValuePair<string, string> kv in otherParas)
            {
                request.Headers.Add(kv.Key, kv.Value);
            }
            //request.Headers.Add("ResourceId", "login");
            //request.Headers.Add("RequestId", "EBA1000S");
            //内容类型
            request.ContentType = "application/json";

            //设置参数，并进行URL编码 

            string paraUrlCoded = jsonParas;//System.Web.HttpUtility.UrlEncode(jsonParas);   

            byte[] payload;
            //将Json字符串转化为字节  
            payload = System.Text.Encoding.UTF8.GetBytes(paraUrlCoded);
            //设置请求的ContentLength   
            request.ContentLength = payload.Length;
            //发送请求，获得请求流 

            Stream writer;
            try
            {
                writer = request.GetRequestStream();//获取用于写入请求数据的Stream对象
            }
            catch (Exception)
            {
                writer = null;
                Console.Write("连接服务器失败!");
            }
            //将请求参数写入流
            writer.Write(payload, 0, payload.Length);
            writer.Close();//关闭请求流

            String strValue = "";//strValue为http响应所返回的字符流
            HttpWebResponse response;
            try
            {
                //获得响应流
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                response = ex.Response as HttpWebResponse;
            }

            Stream s = response.GetResponseStream();
            StreamReader sRead = new StreamReader(s);
            string postContent = sRead.ReadToEnd();
            sRead.Close();


            return postContent;//返回Json数据
        }

        public static string GetJson(string Url, Dictionary<string, string> otherParas)
        {

            string serviceAddress = Url;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceAddress);
            request.Method = "GET";
            request.Accept = "Application/json";
            request.ContentType = "Application/json";
            
            foreach (KeyValuePair<string, string> kv in otherParas)
            {
                request.Headers.Add(kv.Key, kv.Value);
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            return retString;
        }

        public static string Post(string Url)
        {
            string strURL = Url;

            //创建一个HTTP请求  
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strURL);
            //Post请求方式  
            request.Method = "POST";
            request.ContentType = "application/json";

            Stream writer;
            try
            {
                writer = request.GetRequestStream();//获取用于写入请求数据的Stream对象
            }
            catch (Exception)
            {
                writer = null;
                Console.Write("连接服务器失败!");
            }

            writer.Close();//关闭请求流

            String strValue = "";//strValue为http响应所返回的字符流
            HttpWebResponse response;
            try
            {
                //获得响应流
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                response = ex.Response as HttpWebResponse;
            }

            Stream s = response.GetResponseStream();
            StreamReader sRead = new StreamReader(s);
            string postContent = sRead.ReadToEnd();
            sRead.Close();


            return postContent;//返回Json数据
        }

        /**
* @param string url 请求路由
* @param string jsonParas 请求参数
* @param string httpKey 请求key
* 
* @return json
**/
        public static string JsonHttpPost(string url, string jsonParas, string httpKey)
        {

            //创建一个HTTP请求  
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //Post请求方式  
            request.Method = "POST";
            //内容类型
            request.ContentType = "application/x-www-form-urlencoded";

            //设置参数，并进行URL编码  
            //虽然我们需要传递给服务器端的实际参数是JsonParas(格式：[{\"UserID\":\"0206001\",\"UserName\":\"ceshi\"}])，
            //但是需要将该字符串参数构造成键值对的形式（注："paramaters=[{\"UserID\":\"0206001\",\"UserName\":\"ceshi\"}]"），
            //其中键paramaters为WebService接口函数的参数名，值为经过序列化的Json数据字符串
            //最后将字符串参数进行Url编码
            string paraUrlCoded = System.Web.HttpUtility.UrlEncode(httpKey);
            paraUrlCoded += "=" + System.Web.HttpUtility.UrlEncode(jsonParas);

            byte[] payload;
            //将Json字符串转化为字节  
            payload = System.Text.Encoding.UTF8.GetBytes(paraUrlCoded);
            //设置请求的ContentLength   
            //request.ContentLength = payload.Length;
            //发送请求，获得请求流  

            Stream writer;
            try
            {
                //X509Certificate objx509 = new X509Certificate(System.Web.HttpContext.Current.Server.MapPath("~") + "\\cer\\nid.crt");
                //request.ClientCertificates.Add(objx509);
                writer = request.GetRequestStream();//获取用于写入请求数据的Stream对象
            }
            catch (Exception)
            {
                writer = null;
                Console.Write("连接服务器失败!");
            }
            //将请求参数写入流
            writer.Write(payload, 0, payload.Length);
            writer.Close();//关闭请求流

            String strValue = "";//strValue为http响应所返回的字符流
            HttpWebResponse response;
            try
            {
                //获得响应流
                ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidationCallback;
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                response = ex.Response as HttpWebResponse;
            }

            Stream s = response.GetResponseStream();
            StreamReader sr = new StreamReader(s, Encoding.UTF8);
            strValue = sr.ReadToEnd();

            return strValue;//返回Json数据
        }
    }
}
