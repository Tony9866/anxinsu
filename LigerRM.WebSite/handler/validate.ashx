<%@ WebHandler Language="C#" Class="validate" %>

using System;
using System.Web;
using Liger.Common;
using Liger.Model;
using LigerRM.Common;
using Liger.Data;
using System.Linq;
using Liger.Data.Linq;
using System.Web.SessionState;

/// <summary>
/// 前台验证数据入口
/// </summary>
public class validate : IHttpHandler, IRequiresSessionState
{
    private DbContext DB = DbHelper.Db;
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        try
        {
            if (context.Request.Params["Action"] == "Exist")
                ValidateExist();
            if (context.Request.Params["Action"] == "Login")
                ValidateLogin();
            if (context.Request.Params["Action"] == "ValidateTimes")
                ValidateLoginTimes();
            if (context.Request.Params["Action"] == "AddTimes")
                AddLoginTimes();
            if (context.Request.Params["Action"] == "Region")
                ValidateRegions();
        } 
        catch (Exception err)
        {
            context.Response.Write("true");
        }
        context.Response.End();
    }

    
    
    void ValidateExist()
    {
        var context = System.Web.HttpContext.Current;
        string view = context.Request.Params["View"].ToLower(); 
        switch (view)
        {
            case "user":
                string username = context.Request.Params["LoginName"]; 
                var existUser = DB.Query<CFUser>().Where(c => c.LoginName == username).Any();
                context.Response.Write(existUser ? "false" : "true");
                break;
            case "role":
                string rolename = context.Request.Params["RoleName"];
                var existRole = DB.Query<CFRole>().Where(c => c.RoleName == rolename).Any();
                context.Response.Write(existRole ? "false" : "true");
                break;
            case "menu":
                string menuno = context.Request.Params["MenuNo"];
                var existMenu = DB.Query<SysMenu>().Where(c => c.MenuNo == menuno).Any();
                context.Response.Write(existMenu ? "false" : "true");
                break;
            case "dataprivilege":
                string DataPrivilegeView = context.Request.Params["DataPrivilegeView"];
                var existDataPrivilege = DB.Query<CFDataPrivilege>().Where(c => c.DataPrivilegeView == DataPrivilegeView).Any();
                context.Response.Write(existDataPrivilege ? "false" : "true");
                break;
        }  
    }
    void ValidateLogin()
    {
        var context = System.Web.HttpContext.Current;
        string username = context.Request.Params["rentUserName"];
        string password = context.Request.Params["rentPassword"];

        context.Response.Write(SystemService.UserLogin(username, password) ? "true" : "false");
    }
    void ValidateLoginTimes()
    {
        var context = System.Web.HttpContext.Current;
        string username = context.Request.Params["username"];
        context.Response.Write(SystemService.ValidateLoginTimes(username,5,10) ? "true" : "false");
    }

    void ValidateRegions()
    {
        var context = System.Web.HttpContext.Current;
        string username = context.Request.Params["username"];
        if (SystemService.IsAdministrator(SysContext.CurrentUserID))
            context.Response.Write("true");
        else
            context.Response.Write(SystemService.ValidateRegions(username) ? "true" : "false");
    }

    void AddLoginTimes()
    {
        var context = System.Web.HttpContext.Current;
        string username = context.Request.Params["username"];
        string status = context.Request.Params["status"];
        context.Response.Write(SystemService.AddLoginTimes(username, status)?"true":"false");
    }
    
    public bool IsReusable {
        get {
            return false;
        }
    }

}