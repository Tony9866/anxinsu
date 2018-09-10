<%@ WebHandler Language="C#" Class="ajax" %>

using System;
using System.Web;
using System.Reflection;
using LigerRM.Common;
using LigerRM.Service.Setting;

/// <summary>
/// 前台Ajax请求(包括数据请求、表单提交)入口
/// 这个类会利用反射的机制自动调用指定方法({type}.{method})
/// 并允许传入方法参数，参数名称对应即可
/// 如果方法参数是自定义类，那么跟类的 属性名 对应即可
/// </summary>
public class ajax : IHttpHandler
{
    private HttpContext context;


    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        this.context = context;

        try
        {
            Run(context);
        }
        catch (Exception err)
        {
            
        } 
    }

    void Run(HttpContext context)
    { 
        var method = AjaxRequestHelper.GetMethod(TypeName, MethodName);
        if (method == null)
        {
            System.Threading.Thread.Sleep(1000);
            context.Response.Write(AjaxResult.Error(string.Format("找不到类{0} 方法{1}", TypeName, MethodName)));
            context.ApplicationInstance.CompleteRequest();
            return;
        }

        //如果当前方法 配置了管理员专属
        if (MethodSettingHelper.Exist(TypeName, MethodName) && !SystemService.IsAdministrator())
        {
            LogManager.WriteLog("USER", SysContext.CurrentUserTitle + "执行管理员方法" + TypeName + "." + MethodName);
            
            System.Threading.Thread.Sleep(1000);
            context.Response.Write(AjaxResult.Error("非管理员不允许此操作"));
            context.ApplicationInstance.CompleteRequest();
            return;
        }

        object obj = null;
        if (IncludeHttpContext)
        {
            var objtype = AjaxRequestHelper.GetType(TypeName);
            obj = Activator.CreateInstance(objtype, new object[1] { context });
        }
        else if (IsInstance)
        {
            var objtype = AjaxRequestHelper.GetType(TypeName);
            obj = Activator.CreateInstance(objtype);
        }
        var result = method.Invoke(obj, AjaxRequestHelper.GetMethodParms(method, context));
        context.Response.Write(result);
        context.ApplicationInstance.CompleteRequest();
    }
    /// <summary>
    /// 类名
    /// </summary>
    protected string TypeName
    {
        get { return this.context.Request["type"]; }
    }
    /// <summary>
    /// 方法名
    /// </summary>
    protected string MethodName
    {
        get { return this.context.Request["method"]; }
    }
    /// <summary>
    /// 是否以httpcontext为第一个参数，创建一个实例
    /// </summary>
    protected bool IncludeHttpContext
    {
        get { return !string.IsNullOrEmpty(this.context.Request["HttpContext"]); }
    }

    /// <summary>
    /// 是否 实例化对象
    /// </summary>
    public bool IsInstance
    {
        get { return !string.IsNullOrEmpty(this.context.Request["Instance"]); }
    }
    
    public bool IsReusable {
        get {
            return false;
        }
    }

}