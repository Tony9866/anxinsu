<%@ WebHandler Language="C#" Class="treegrid" %>

using System;
using System.Web;
using System.Reflection;
using LigerRM.Common;
using Liger.Common.Extensions;
using Liger.Data;
using Liger.Model;
using Liger.Common.JSON;

/// <summary>
/// 前台表格数据入口
/// </summary>
public class treegrid : IHttpHandler
{ 
    public void ProcessRequest (HttpContext context) { 
        context.Response.ContentType = "text/plain"; 
        var json = DbHelper.Db.GetGridTreeJSON(context);
        context.Response.Write(json);
        context.Response.End();   
    } 
    
    public bool IsReusable {
        get {
            return false;
        }
    }

}