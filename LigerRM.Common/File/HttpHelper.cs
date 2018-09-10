using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;

namespace LigerRM.Common.File
{
    public static class HttpHelper
    {
        private static readonly Encoding DEFAULTENCODE = Encoding.UTF8;

        /// <summary>
        /// HttpUploadFile
        /// </summary>
        /// <param name="url"></param>
        /// <param name="file"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string HttpUploadFile(string url, string file, NameValueCollection data)
        {
            return HttpUploadFile(url, file, data, DEFAULTENCODE);
        }

        /// <summary>
        /// HttpUploadFile
        /// </summary>
        /// <param name="url"></param>
        /// <param name="file"></param>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string HttpUploadFile(string url, string file, NameValueCollection data, Encoding encoding)
        {
            return HttpUploadFile(url, new string[] { file }, data, encoding);
        }

        /// <summary>
        /// HttpUploadFile
        /// </summary>
        /// <param name="url"></param>
        /// <param name="files"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string HttpUploadFile(string url, string[] files, NameValueCollection data)
        {
            return HttpUploadFile(url, files, data, DEFAULTENCODE);
        }

        /// <summary>
        /// HttpUploadFile
        /// </summary>
        /// <param name="url"></param>
        /// <param name="files"></param>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string HttpUploadFile(string url, string[] files, NameValueCollection data, Encoding encoding)
        {
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
            byte[] endbytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");

            //1.HttpWebRequest
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            request.Method = "POST";
            request.KeepAlive = true;
            request.Credentials = CredentialCache.DefaultCredentials;

            using (Stream stream = request.GetRequestStream())
            {
                //1.1 key/value
                string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
                if (data != null)
                {
                    foreach (string key in data.Keys)
                    {
                        stream.Write(boundarybytes, 0, boundarybytes.Length);
                        string formitem = string.Format(formdataTemplate, key, data[key]);
                        byte[] formitembytes = encoding.GetBytes(formitem);
                        stream.Write(formitembytes, 0, formitembytes.Length);
                    }
                }

                //1.2 file
                string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: application/octet-stream\r\n\r\n";
                byte[] buffer = new byte[4096];
                int bytesRead = 0;
                for (int i = 0; i < files.Length; i++)
                {
                    stream.Write(boundarybytes, 0, boundarybytes.Length);
                    string header = string.Format(headerTemplate, "file" + i, Path.GetFileName(files[i]));
                    byte[] headerbytes = encoding.GetBytes(header);
                    stream.Write(headerbytes, 0, headerbytes.Length);
                    using (FileStream fileStream = new FileStream(files[i], FileMode.Open, FileAccess.Read))
                    {
                        while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            stream.Write(buffer, 0, bytesRead);
                        }
                    }
                }

                //1.3 form end
                stream.Write(endbytes, 0, endbytes.Length);
            }
            //2.WebResponse
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            {
                return stream.ReadToEnd();
            }
        }


       public static string UploadFileEx( string uploadfile, string url,     string fileFormName, string contenttype,NameValueCollection querystring,     CookieContainer cookies)   
       {     
           if( (fileFormName== null) ||       (fileFormName.Length ==0))     
           {       fileFormName = "file";     }        
           if( (contenttype== null) ||       (contenttype.Length ==0))     
           {       contenttype = "application/octet-stream";     }      
           string postdata;    
           postdata = "?";     
           if (querystring!=null)     
           {       
               foreach(string key in querystring.Keys)       
               {         
                   postdata+= key +"=" + querystring.Get(key)+"&";       
               }     
           }     
           Uri uri = new Uri(url+postdata);       
           string boundary = "----------" + DateTime.Now.Ticks.ToString("x");     
           HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(uri);     
           webrequest.CookieContainer = cookies;     
           webrequest.ContentType = "multipart/form-data; boundary=" + boundary;     
           webrequest.Method = "POST";       // Build up the post message header     
           StringBuilder sb = new StringBuilder();     
           sb.Append("--");     
           sb.Append(boundary);     
           sb.Append("");     
           sb.Append("Content-Disposition: form-data; name=\"");     
           sb.Append(fileFormName);     sb.Append("\"; filename=\"");     
           sb.Append(Path.GetFileName(uploadfile));     
           sb.Append("\"");     
           sb.Append("");     
           sb.Append("Content-Type: ");     
           sb.Append(contenttype);     
           sb.Append("");     
           sb.Append("");              
           string postHeader = sb.ToString();     
           byte[] postHeaderBytes = Encoding.UTF8.GetBytes(postHeader);        // Build the trailing boundary string as a byte array     // ensuring the boundary appears on a line by itself     
           byte[] boundaryBytes =         Encoding.ASCII.GetBytes("--" + boundary + "");        
           FileStream fileStream = new FileStream(uploadfile,FileMode.Open, FileAccess.Read);     
           long length = postHeaderBytes.Length + fileStream.Length +  boundaryBytes.Length;     
           webrequest.ContentLength = length;        
           Stream requestStream = webrequest.GetRequestStream();        // Write out our post header     
           requestStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);        // Write out the file contents     
           byte[] buffer = new Byte[fileStream.Length];     
           int bytesRead = 0;     
           while ( (bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0 )       
               requestStream.Write(buffer, 0, bytesRead);        // Write out the trailing boundary     
           requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);     
           WebResponse responce = webrequest.GetResponse();     
           Stream s = responce.GetResponseStream();     
           StreamReader sr = new StreamReader(s);        
           return sr.ReadToEnd();   }

       public static string UploadFileEx(string uploadfile, string url)
       {
           string reqestMsg = "Tom";
           string responseMsg = string.Empty;
           byte[] buffer = Encoding.UTF8.GetBytes(reqestMsg);

           try
           {
               //把请求地址换成博客园的 如http://www.cnblogs.com 就返回了整个页面数据　　
               HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
               request.Method = "POST";
               request.ContentLength = buffer.Length;

               FileStream fileStream = new FileStream(uploadfile,FileMode.Open, FileAccess.Read);  
               buffer = new Byte[fileStream.Length];
               int bytesRead = 0;


               using (Stream requestStream = request.GetRequestStream())
               {
                   while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                       requestStream.Write(buffer, 0, bytesRead);        // Write out the trailing boundary     
                   requestStream.Write(buffer, 0, buffer.Length); 
               }

               HttpWebResponse resonse = (HttpWebResponse)request.GetResponse();
               Stream responseStream = resonse.GetResponseStream();

               using (StreamReader sr = new StreamReader(responseStream))
               {
                   responseMsg = sr.ReadToEnd();
               }

               resonse.Close();
           }
           catch (Exception ex)
           {
               responseMsg = ex.Message;
           }
           return responseMsg;
       }
    }
}