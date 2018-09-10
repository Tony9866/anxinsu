<%@ WebHandler Language="C#" Class="FileUploadHandler" Debug="true" %>

using System;
using System.Web;
using System.IO;
using SignetInternet_BusinessLayer;

public class FileUploadHandler : IHttpHandler {

    private static object _lockObj = new object();
    public void ProcessRequest(HttpContext context)
    {
        
        if (context.Request.ContentType == "application/octet-stream" || context.Request.ContentType=="")
        {
            Random ran = new Random();
            
            var filepath = context.Server.MapPath("~/UploadedFiles");
            var filename = context.Request.Headers["FileName"] == null ? DateTime.Now.ToString("yyyyMMddHHmmss")+ran.Next(100,999).ToString()+".jpg" : context.Request.Headers["FileName"];
            var convertFile = "C" + filename;//context.Request.Headers["FileName"] == null ? DateTime.Now.ToString("yyyyMMddHHmmss") + ran.Next(100, 999).ToString() + ".jpg" : context.Request.Headers["FileName"];
            var convertPath = context.Server.MapPath("~/UploadedFiles");
            filepath = Path.Combine(filepath, filename);
            convertPath = Path.Combine(convertPath,convertFile);
            lock (_lockObj)
            {
                if (File.Exists(filepath))
                    File.Delete(filepath);

                int len = 0;
                byte[] buffer = new byte[1024];

                using (var fs = new FileStream(filepath, FileMode.CreateNew))
                {
                    do
                    {
                        len = context.Request.InputStream.Read(buffer, 0, buffer.Length);
                        fs.Write(buffer, 0, len);
                    } while (len > 0);
                }
            }

            SignetImageHelper.GetPicThumbnail(filepath, convertPath, 0, 0, 50);

            FileInfo fi = new FileInfo(convertPath);
            FileStream fs1 = fi.OpenRead();
            byte[] bytes = new byte[fs1.Length];
            fs1.Read(bytes, 0, Convert.ToInt32(fs1.Length));
            fs1.Close();

            string[] signetId = context.Request["SignetID"].Split(',');
            string type = context.Request["type"];

            SignetFileHelper helper = new SignetFileHelper();
            foreach (string s in signetId)
            {
                if (!string.IsNullOrEmpty(s))
                    helper.AddSignetFile(s, type, filename, bytes, "扫描文件");
            }
            fi.Delete();
            context.Response.ContentType = "text/plain";
            context.Response.Write("javascript:parent.f_reload();");
        }
        else
        {
            context.Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
            context.Response.ContentType = "text/plain";
            context.Response.Write("0");
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}