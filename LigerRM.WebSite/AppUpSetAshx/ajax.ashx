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
                context.Response.Write(SetBanner(context));
                break;
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

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}