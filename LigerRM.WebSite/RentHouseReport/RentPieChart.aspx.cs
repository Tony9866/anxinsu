using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SignetInternet_BusinessLayer;
using System.Data;

public partial class RentHouseReport_RentPieChart : System.Web.UI.Page
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
                case "AllPoliceHouse":

                    if (policeStationName != "全部")
                    {
                        policeStationName = psName;
                    }
                    mtitle = "<b>房源全量统计</b>";
                    stitle = "所属警局：" + policeStationName + " <br />统计日期：" + startDate + " 至 " + endDate;
                    yTitle = "入住数量";
                    serieTitle = "入住量";

                    DataTable dt = helper.GetStatisticData(statisticType, startDate, endDate, psName == "全部" ? "" : psName,LigerRM.Common.SysContext.CurrentUserID.ToString());
                    decimal totalCount = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                         totalCount += decimal.Parse(row["RentRecordCount"].ToString());
                    }

                    Random ran = new Random(1);
                    int rowIndex = ran.Next(0, dt.Rows.Count-1);
                    int index = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        //{
                        //    name: 'Chrome',
                        //    y: 12.8,
                        //    sliced: true,
                        //    selected: true
                        //},
                        if (rowIndex==index)
                            chartData += "{name:'" + row["PSName"].ToString() + "',y:" + ((decimal.Parse(row["RentRecordCount"].ToString()) / totalCount) * 100).ToString("f2") + ",sliced: true,selected: true},";
                        else
                            chartData += "['" + row["PSName"].ToString() + "'," + ((decimal.Parse(row["RentRecordCount"].ToString()) / totalCount) * 100).ToString("f2") + "],";
                        index++;
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
                //case "AllPoliceHouse":
                //    if (policeStationName != "全部")
                //    {
                //        policeStationName = psName;
                //    }
                //    mtitle = "<b>所属警局全量统计</b>";
                //    stitle = "所属警局：" + policeStationName + " <br />统计日期：" + startDate + " 至 " + endDate;
                //    yTitle = "入住数量";
                //    serieTitle = "入住量";

                //    DataTable dt3 = helper.GetStatisticData(statisticType, startDate, endDate, psName == "全部" ? "" : psName);
                //    foreach (DataRow row in dt3.Rows)
                //    {
                //        chartData += "['" + row["PSName"].ToString() + "'," + row["RentRecordCount"].ToString() + "],";
                //    }
                //    break;
            }
            if (!string.IsNullOrEmpty(chartData))
                chartData = chartData.Substring(0, chartData.Length - 1);
            chartData = chartData + "]";

        }
    }
}