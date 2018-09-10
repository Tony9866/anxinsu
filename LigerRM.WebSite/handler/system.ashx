<%@ WebHandler Language="C#" Class="system" %>

using System;
using System.Collections.Generic;
using System.Web;
using Liger.Common;
using Liger.Common.JSON;
using Liger.Model;
using LigerRM.Common;
using Liger.Data;
using System.Linq;
using Liger.Data.Linq;
using System.Web.SessionState; 

/// <summary>
/// 前台权限许可数据入口
/// </summary>
public class system : IHttpHandler, IRequiresSessionState
{
    private DbContext DB = DbHelper.Db;
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        try
        { 
            if (context.Request.Params["Action"] == "GetButton")
                GetButton();
            if (context.Request.Params["Action"] == "GetRole")
                GetRole();
        }
        catch (Exception err)
        {
            var message = err.Message;
            if (err.InnerException != null && err.InnerException.Message != null)
                message += "<BR>" + err.InnerException.Message;
            var a = AjaxResult.Error(message);
            var json = new MsJSONSerializer().Serialize(a);
            context.Response.Write(json);
        }
        context.Response.End();
    }
    bool IsAdministrator()
    {
        return SystemService.IsAdministrator(SysContext.CurrentUserID);
    } 
    
    void GetButton()
    {
        var context = HttpContext.Current;
        string MenuNo = context.Request.Params["MenuNo"]; 
        List<SysButton> list = null;
        //系统管理员,不需要权限过滤
        if (IsAdministrator())
        {
            list = DB.From<SysButton>().ToList();
        }
        else
        {
            //var userservice = new UserService(); 
            //list = userservice.GetButtons(MenuNo);
        }
        var jsonlist = (from a in list
                        select new
                        {
                            id = a.BtnNo,
                            icon = a.BtnIcon, 
                            name = a.BtnName
                        }
                       ).ToArray();

        context.Response.Write(new MsJSONSerializer().Serialize(jsonlist));
    }
    void GetRole()
    {
        var list = DB.From<CFRole>().ToList();
        var jsonlist = (from a in list
                        select new
                        {
                            id = a.RoleID,
                            text = a.RoleName 
                        }
                       ).ToArray();

        HttpContext.Current.Response.Write(new MsJSONSerializer().Serialize(jsonlist));
    }
    
    public bool IsReusable {
        get {
            return false;
        }
    }

}