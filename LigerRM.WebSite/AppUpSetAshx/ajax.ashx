<%@ WebHandler Language="C#" Class="ajax" %>

using System;
using System.Web;
using SignetInternet_BusinessLayer;

public class ajax : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        switch (context.Request["type"].ToString())
        {
            case "GetHousing":
                context.Response.Write(SetBanner(context));
                break;
            case "GetMod":
                context.Response.Write(GetMod(context));
                break;
            case "DeleteBanner":
                context.Response.Write(DeleteBanner(context));
                break;
            case "GetListCity":
                context.Response.Write(GetListCity(context));
                break;
        }
    }
    public string DeleteBanner(HttpContext context)
    {
        AppHomeHelper apphome = new AppHomeHelper();
        try
        {
            AppHomeHelper app = new AppHomeHelper();
            return app.DeleteBanner(long.Parse(context.Request["BannerId"].ToString()));
        }
        catch (Exception ex)
        {

            throw;
        }
    }
    public string SetBanner(HttpContext context)
    {
        AppHomeHelper apphome = new AppHomeHelper();
        try
        {
            AppHomeHelper app = new AppHomeHelper();
            return app.SetBanner(context.Request["data"].ToString(), 1);
        }
        catch (Exception ex)
        {

            throw;
        }
    }

    public string GetMod(HttpContext context)
    {
        try
        {
            return new AppHomeHelper().GetMod(long.Parse(context.Request["BannerId"].ToString()));
        }
        catch (Exception ex)
        {

            throw;
        }
    }

    public string GetListCity(HttpContext context)
    {
        try
        {
            return new AppHomeHelper().GetListCity(context.Request["provinceid"].ToString());
        }
        catch (Exception ex)
        {

            throw;
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