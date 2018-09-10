<%@ WebHandler Language="C#" Class="UploadHandler" %>

using System;
using System.Web;

public class UploadHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        HttpRequest request = context.Request;
        HttpResponse response = context.Response;
        int fileLen = request.ContentLength;
        Random ran = new Random();
        var filepath = context.Server.MapPath("~/UploadedFiles");
        var filename = context.Request.Headers["FileName"] == null ? DateTime.Now.ToString("yyyyMMddHHmmss") + ran.Next(100, 999).ToString() + ".jpg" : context.Request.Headers["FileName"];
        filepath = System.IO.Path.Combine(filepath, filename);
        
        request.Files[0].SaveAs(filepath);

        System.IO.FileInfo fi = new System.IO.FileInfo(filepath);
        System.IO.FileStream fs1 = fi.OpenRead();
        byte[] bytes = new byte[fs1.Length];
        fs1.Read(bytes, 0, Convert.ToInt32(fs1.Length));
        fs1.Close();

        string[] signetId = context.Request["SignetID"].Split(',');
        string type = context.Request["type"];

        SignetInternet_BusinessLayer.SignetFileHelper helper = new SignetInternet_BusinessLayer.SignetFileHelper();
        foreach (string s in signetId)
        {
            if (!string.IsNullOrEmpty(s))
            {
                helper.AddSignetFile(s.Replace("'",""), type, filename, bytes, "扫描文件");
            }
        }
        fi.Delete();
        context.Response.Write("javascript:parent.f_reload();");

    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}