<%@ WebHandler Language="C#" Class="tree" %>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Reflection;
using LigerRM.Common;
using Liger.Common.Extensions;
using Liger.Data;
using Liger.Model;
using Liger.Common.JSON;

/// <summary>
/// 前台树数据入口
/// </summary>
public class tree : IHttpHandler
{
    
    /// <summary>
    /// 视图自定义加载函数列表
    /// </summary>
    private static Dictionary<string, Func<string>> viewMatch = new Dictionary<string, Func<string>>()
    {
        {"MyMenus",() => SystemService.GetUserMenusTreeJSON(SysContext.CurrentUserID)}
    };
    
    
    public void ProcessRequest (HttpContext context) { 
        context.Response.ContentType = "text/plain";
        string view = context.Request["view"];
        string json = "[]";
        //如果视图注册了 视图自定义加载函数
        if (viewMatch.ContainsKey(view))
        {
            json = viewMatch[view]();
        } 
        else
        {
            json = DbHelper.Db.GetTreeJSON(context);
        }
        context.Response.Write(json);
        context.Response.End();   
    } 
    
    
    
    public bool IsReusable {
        get {
            return false;
        }
    }

}