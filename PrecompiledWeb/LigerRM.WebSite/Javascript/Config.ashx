<%@ WebHandler Language="C#" Class="Config" %>

using System;
using System.Web;

public class Config : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        var json = LigerRM.Server.AjaxRequests.AjaxPage.GetUploadFileUrl(context.Request["version"].ToString());
        context.Response.Write(json);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}