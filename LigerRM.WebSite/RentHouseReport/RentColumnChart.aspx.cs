using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SignetInternet_BusinessLayer;
using System.Data;

public partial class RentHouseReport_RentColumnChart : System.Web.UI.Page
{
    public string startDate = string.Empty;
    public string endDate = string.Empty;
    public string policeStationName = string.Empty;
    public string chartData = string.Empty;
    public string statisticType = string.Empty;

    public string mtitle;
    public string stitle;
    public string yTitle;
    public string xTitle;
    public string category;
    public string serieTitle;
    public string data;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string psName = Request["psname"];
            startDate = Request["sDate"];
            endDate = Request["eDate"];
             
            statisticType = Request["category"];
            RentInfoHelper helper = new RentInfoHelper();
            chartData = "[";
            switch (statisticType)
            {
                case "AllPoliceStation":
                                        if (policeStationName != "全部")
                    {
                        policeStationName = psName;
                    }
                    mtitle = "<b>房源全量统计</b>";
                    stitle = "所属警局：" + policeStationName + " <br />统计日期：" + startDate + " 至 " + endDate;
                    yTitle = "入住数量";
                    serieTitle = "入住量";

                    DataTable dt = helper.GetStatisticData(statisticType, startDate, endDate, psName == "全部" ? "" : psName,LigerRM.Common.SysContext.CurrentUserID.ToString());
                    foreach (DataRow row in dt.Rows)
                    {
                        chartData += "['" + row["PSName"].ToString() + "'," + row["RentRecordCount"].ToString() + "],";
                    }
                    break;
                   
                case "AllDistrict":

                    if (policeStationName != "全部")
                    {
                        DataTable dt1 = helper.GetDataTable("select * from Rent_PoliceStation where PSName='" + psName + "'");
                        if (dt1.Rows.Count > 0)
                            policeStationName = dt1.Rows[0]["co_corp_name"].ToString();
                    }

                    mtitle = "<b>所属区域全量统计</b>";
                    stitle = "所属区域：" + policeStationName + " <br />统计日期：" + startDate + " 至 " + endDate;
                    yTitle = "入住数量";
                    serieTitle = "入住量";

                    DataTable dt2 = helper.GetStatisticData(statisticType, startDate, endDate, psName == "全部" ? "" : psName, LigerRM.Common.SysContext.CurrentUserID.ToString());
                    foreach (DataRow row in dt2.Rows)
                    {
                        chartData += "['" + row["rd_reg_dept_name"].ToString() + "'," + row["PackageCount"].ToString() + "],";
                    }
                    break;
                case "AllPoliceHouse":
                    if (policeStationName != "全部")
                    {
                        policeStationName = psName;
                    }
                    mtitle = "<b>所属警局全量统计</b>";
                    stitle = "所属警局：" + policeStationName + " <br />统计日期：" + startDate + " 至 " + endDate;
                    yTitle = "入住数量";
                    serieTitle = "入住量";

                    DataTable dt3 = helper.GetStatisticData(statisticType, startDate, endDate, psName == "全部" ? "" : psName, LigerRM.Common.SysContext.CurrentUserID.ToString());
                    foreach (DataRow row in dt3.Rows)
                    {
                        chartData += "['" + row["PSName"].ToString() + "'," + row["RentRecordCount"].ToString() + "],";
                    }
                    break;
            }
            if (!string.IsNullOrEmpty(chartData))
                chartData = chartData.Substring(0, chartData.Length - 1);
            chartData = chartData + "]";

        }
    }
}