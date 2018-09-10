using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SignetInternet_BusinessLayer;
using System.Data;

namespace LigerRM.WebService
{
    /// <summary>
    /// AlertService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class AlertService : System.Web.Services.WebService
    {

        [WebMethod]
        public string GetAlertList(string type,string startdate,string enddate)
        {
            string sql = "select * from dbo.v_PersonAlert_View where uploaddate >'"+startdate+"' and uploaddate<='"+enddate+"'";
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString,MySQLHelper.CreateCommand(sql)).Tables[0];
            return LigerRM.Common.JSONHelper.ToJson(dt);
        }
    }
}
