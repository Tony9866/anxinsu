using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SignetInternet_BusinessLayer;
using System.Data;
using System.Configuration;

public partial class RentHouseReport_RentScattergram : System.Web.UI.Page
{
    private string category = string.Empty;
    private string year = string.Empty;
    private string month = string.Empty;
    private string day = string.Empty;
    private string psname = string.Empty;
 
    public string dataInfo = string.Empty;
    public string defaultLon = string.Empty;
    public string defaultLat = string.Empty;

    //Scattergram.aspx?category=0&sDate=&eDate=&corpId=&regDeptId=
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            defaultLon = ConfigurationManager.AppSettings["defaultLon"];
            defaultLat = ConfigurationManager.AppSettings["defaultLat"];

            category = Request["category"];
            year = Request["year"];
            month = Request["month"];
            day = Request["day"];
            psname = Request["psname"];


            RentInfoHelper helper = new RentInfoHelper();

            string startDate = string.Empty;
            string endDate = string.Empty;
            if (!string.IsNullOrEmpty(day))
            {
                startDate = day;
                endDate = Convert.ToDateTime(startDate).AddDays(1).ToString("yyyy-MM-dd");
            }
            else if (!string.IsNullOrEmpty(month) && string.IsNullOrEmpty(day) == true)
            {
                startDate = year + "-" + month + "-01";
                endDate = Convert.ToDateTime(startDate).AddMonths(1).ToString("yyyy-MM-dd");
            }
            else if (string.IsNullOrEmpty(month) && string.IsNullOrEmpty(day))
            {
                startDate = year + "-01-01";
                endDate = Convert.ToDateTime(startDate).AddYears(1).ToString("yyyy-MM-dd");
            }


            DataTable dt = helper.GetScattergramData(startDate, endDate, psname == "全部" ? "" : psname,LigerRM.Common.SysContext.CurrentUserID.ToString());

            foreach (DataRow row in dt.Rows)
            {
                dataInfo += "[" + row["Longitude"].ToString() + ", " + row["Latitude"].ToString() +
                    //", \"警局：" + row["RPSName"].ToString() + "<br/>" +
                        //"租赁人：" + row["RRAContactName"].ToString() + " " + helper.OverString(row["RRAContactTel"].ToString()) + "<br/>" +
                    ", \"地址：" + row["RAddress"].ToString() + "<br/>" +
                        "房主：" + row["ROwner"].ToString() + " " + helper.OverString(row["RIDCard"].ToString()) + "<br/>" +
                        "状态：" + (row["IsAvailable"].ToString().ToUpper() == "已租" ? "<span style='color:red;'>出租中</span>" : "空闲") +
                        //"时间：" + DateTime.Parse(row["RRAStartDate"].ToString()).ToString("yyyy-MM-dd") + " " + DateTime.Parse(row["RRAEndDate"].ToString()).ToString("yyyy-MM-dd") + 
                        "\"],";
            }

            if (!string.IsNullOrEmpty(dataInfo))
                dataInfo = dataInfo.Substring(0, dataInfo.Length - 1);
        }
    }
}