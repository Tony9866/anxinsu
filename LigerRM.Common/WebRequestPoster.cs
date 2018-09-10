using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Configuration;

namespace LigerRM.Common.WebRequestHelper
{
    public static class WebRequestPoster
    {
        private static string PostHttpRequest(string url, string data)
        {

            //string postData = "arg0=hello"; // 要发放的数据 
            byte[] byteArray = Encoding.UTF8.GetBytes(data);

            HttpWebRequest objWebRequest = (HttpWebRequest)WebRequest.Create(url);
            objWebRequest.Method = "POST";
            //objWebRequest.ContentType = "text/xml"; 
            objWebRequest.ContentType = "application/x-www-form-urlencoded";
            //objWebRequest.ContentLength = byteArray.Length;
            objWebRequest.KeepAlive = true;
            objWebRequest.Timeout = 20000;
            Stream newStream = objWebRequest.GetRequestStream();
            // Send the data. 
            newStream.Write(byteArray, 0, byteArray.Length); //写入参数 
            newStream.Close();
            //ProtocolVersion = System.Net.HttpVersion.Version10
            objWebRequest.ServicePoint.Expect100Continue = false;
            objWebRequest.ProtocolVersion = System.Net.HttpVersion.Version10;
            HttpWebResponse response = (HttpWebResponse)objWebRequest.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.Default);
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

        public static string PostHttpRequest(string data)
        {
            string url = ConfigurationManager.AppSettings["ElectronicServiceUrl"];
            return PostHttpRequest(url, data);
        }
    }
}
