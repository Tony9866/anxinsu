using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace LigerRM.WebService
{
    /// <summary>
    /// NewWebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class NewWebService : System.Web.Services.WebService
    {

        public Authentication authentication = new Authentication();
        public ServiceCredential myCredential;
        /// <summary>
        /// 封装所有方法
        /// </summary>
        Api api = new Api();


        [WebMethod]
        [SoapHeader("authentication")]
        public string AppHome()
        {
            //if (!authentication.ValideUser())
            //{
            //    return "{'headerError'}";
            //}
            return api.AppHome();
        }

        [WebMethod]
        [SoapHeader("authentication")]
        public string GetUserName()
        {
            //if (!authentication.ValideUser())
            //{
            //    return "{'headerError'}";
            //}
            //return api.AppLogin();
            return "";
        }

    }
}
