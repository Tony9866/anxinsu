using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SignetInternet_BusinessLayer;

public partial class RentHouseReport_RentLineChart : System.Web.UI.Page
{
    public string year = string.Empty;
    public string month = string.Empty;
    public string day = string.Empty;
    public string type = string.Empty;
    public string psname = string.Empty;
    public string title;
    public string subtitle;
    public string yTitle;
    public string xTitle;
    public string category;
    public string serieTitle;
    public string chartData;
    public string[] serialName;
    public string[] serialData;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            category = Request["type"];
            type = Request["category"];
            year = Request["year"];
            month = Request["month"];
            day = Request["day"];
            psname = Request["psname"];
            RentInfoHelper helper = new RentInfoHelper();
            //chartData = "{";

            switch (type)
            {
                case "0":
                    title = "年度信息统计";
                    subtitle = "日期：" + year;
                    yTitle = "入住数量";
                    category = "'1月', '2月', '3月', '4月', '5月', '6月', '7月', '8月', '9月', '10月', '11月', '12月'";
                    DataTable dt = helper.GetStatisticTimeData(category, type, year, month, day, psname, LigerRM.Common.SysContext.CurrentUserID.ToString());
                    serialName = new string[dt.Rows.Count];
                    serialData = new string[dt.Rows.Count];

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        serialName[i] = dt.Rows[i]["PSName"].ToString();
                        serialData[i] = dt.Rows[i]["num1"].ToString() + "," + dt.Rows[i]["num2"].ToString() + "," + dt.Rows[i]["num3"].ToString() + "," + dt.Rows[i]["num4"].ToString() + "," + dt.Rows[i]["num5"].ToString() + "," + dt.Rows[i]["num6"].ToString() + "," + dt.Rows[i]["num7"].ToString() + ","
                            + dt.Rows[i]["num8"].ToString() + "," + dt.Rows[i]["num9"].ToString() + "," + dt.Rows[i]["num10"].ToString() + "," + dt.Rows[i]["num11"].ToString() + "," + dt.Rows[i]["num12"].ToString();
                    }
                    break;
                case "1":
                    title = "月度信息统计";
                    subtitle = "日期：" + year + "年" + month + "月";
                    yTitle = "入住数量";
                    DataTable dt1 = helper.GetStatisticTimeData(category, type, year, month, day, psname, LigerRM.Common.SysContext.CurrentUserID.ToString());
                    serialName = new string[dt1.Rows.Count];
                    serialData = new string[dt1.Rows.Count];

                    switch (month)
                    {
                        case "1":
                        case "3":
                        case "5":
                        case "7":
                        case "8":
                        case "10":
                        case "12":
                            category = "'1', '2', '3', '4', '5', '6', '7', '8', '9', '10', '11', '12', '13', '14', '15', '16', '17', '18', '19', '20', '21', '22', '23', '24', '25', '26', '27', '28', '29', '30', '31'";
                            for (int i = 0; i < dt1.Rows.Count; i++)
                            {
                                serialName[i] = dt1.Rows[i]["PSName"].ToString();
                                serialData[i] = dt1.Rows[i]["num1"].ToString() + "," + dt1.Rows[i]["num2"].ToString() + "," + dt1.Rows[i]["num3"].ToString() + "," + dt1.Rows[i]["num4"].ToString() + "," + dt1.Rows[i]["num5"].ToString() + "," + dt1.Rows[i]["num6"].ToString() + "," + dt1.Rows[i]["num7"].ToString() + ","
                                    + dt1.Rows[i]["num8"].ToString() + "," + dt1.Rows[i]["num9"].ToString() + "," + dt1.Rows[i]["num10"].ToString() + "," + dt1.Rows[i]["num11"].ToString() + "," + dt1.Rows[i]["num12"].ToString() + "," + dt1.Rows[i]["num13"].ToString() + "," + dt1.Rows[i]["num14"].ToString() + "," + dt1.Rows[i]["num15"].ToString()
                                    + "," + dt1.Rows[i]["num16"].ToString() + "," + dt1.Rows[i]["num17"].ToString() + "," + dt1.Rows[i]["num18"].ToString() + "," + dt1.Rows[i]["num19"].ToString() + "," + dt1.Rows[i]["num20"].ToString() + "," + dt1.Rows[i]["num21"].ToString() + "," + dt1.Rows[i]["num22"].ToString() + "," + dt1.Rows[i]["num23"].ToString()
                                    + "," + dt1.Rows[i]["num24"].ToString() + "," + dt1.Rows[i]["num25"].ToString() + "," + dt1.Rows[i]["num26"].ToString() + "," + dt1.Rows[i]["num27"].ToString() + "," + dt1.Rows[i]["num28"].ToString() + "," + dt1.Rows[i]["num29"].ToString() + "," + dt1.Rows[i]["num30"].ToString() + "," + dt1.Rows[i]["num31"].ToString();
                            }
                            break;
                        case "4":
                        case "6":
                        case "9":
                        case "11":
                            category = "'1', '2', '3', '4', '5', '6', '7', '8', '9', '10', '11', '12', '13', '14', '15', '16', '17', '18', '19', '20', '21', '22', '23', '24', '25', '26', '27', '28', '29', '30'";
                            for (int i = 0; i < dt1.Rows.Count; i++)
                            {
                                serialName[i] = dt1.Rows[i]["PSName"].ToString();
                                serialData[i] = dt1.Rows[i]["num1"].ToString() + "," + dt1.Rows[i]["num2"].ToString() + "," + dt1.Rows[i]["num3"].ToString() + "," + dt1.Rows[i]["num4"].ToString() + "," + dt1.Rows[i]["num5"].ToString() + "," + dt1.Rows[i]["num6"].ToString() + "," + dt1.Rows[i]["num7"].ToString() + ","
                                    + dt1.Rows[i]["num8"].ToString() + "," + dt1.Rows[i]["num9"].ToString() + "," + dt1.Rows[i]["num10"].ToString() + "," + dt1.Rows[i]["num11"].ToString() + "," + dt1.Rows[i]["num12"].ToString() + "," + dt1.Rows[i]["num13"].ToString() + "," + dt1.Rows[i]["num14"].ToString() + "," + dt1.Rows[i]["num15"].ToString()
                                    + "," + dt1.Rows[i]["num16"].ToString() + "," + dt1.Rows[i]["num17"].ToString() + "," + dt1.Rows[i]["num18"].ToString() + "," + dt1.Rows[i]["num19"].ToString() + "," + dt1.Rows[i]["num20"].ToString() + "," + dt1.Rows[i]["num21"].ToString() + "," + dt1.Rows[i]["num22"].ToString() + "," + dt1.Rows[i]["num23"].ToString()
                                    + "," + dt1.Rows[i]["num24"].ToString() + "," + dt1.Rows[i]["num25"].ToString() + "," + dt1.Rows[i]["num26"].ToString() + "," + dt1.Rows[i]["num27"].ToString() + "," + dt1.Rows[i]["num28"].ToString() + "," + dt1.Rows[i]["num29"].ToString() + "," + dt1.Rows[i]["num30"].ToString();
                            }
                            break;
                        case "2":
                            if (IsLeap(int.Parse(year)))
                            {
                                category = "'1', '2', '3', '4', '5', '6', '7', '8', '9', '10', '11', '12', '13', '14', '15', '16', '17', '18', '19', '20', '21', '22', '23', '24', '25', '26', '27', '28', '29'";
                                for (int i = 0; i < dt1.Rows.Count; i++)
                                {
                                    serialName[i] = dt1.Rows[i]["PSName"].ToString();
                                    serialData[i] = dt1.Rows[i]["num1"].ToString() + "," + dt1.Rows[i]["num2"].ToString() + "," + dt1.Rows[i]["num3"].ToString() + "," + dt1.Rows[i]["num4"].ToString() + "," + dt1.Rows[i]["num5"].ToString() + "," + dt1.Rows[i]["num6"].ToString() + "," + dt1.Rows[i]["num7"].ToString() + ","
                                        + dt1.Rows[i]["num8"].ToString() + "," + dt1.Rows[i]["num9"].ToString() + "," + dt1.Rows[i]["num10"].ToString() + "," + dt1.Rows[i]["num11"].ToString() + "," + dt1.Rows[i]["num12"].ToString() + "," + dt1.Rows[i]["num13"].ToString() + "," + dt1.Rows[i]["num14"].ToString() + "," + dt1.Rows[i]["num15"].ToString()
                                        + "," + dt1.Rows[i]["num16"].ToString() + "," + dt1.Rows[i]["num17"].ToString() + "," + dt1.Rows[i]["num18"].ToString() + "," + dt1.Rows[i]["num19"].ToString() + "," + dt1.Rows[i]["num20"].ToString() + "," + dt1.Rows[i]["num21"].ToString() + "," + dt1.Rows[i]["num22"].ToString() + "," + dt1.Rows[i]["num23"].ToString()
                                        + "," + dt1.Rows[i]["num24"].ToString() + "," + dt1.Rows[i]["num25"].ToString() + "," + dt1.Rows[i]["num26"].ToString() + "," + dt1.Rows[i]["num27"].ToString() + "," + dt1.Rows[i]["num28"].ToString() + "," + dt1.Rows[i]["num29"].ToString();
                                }
                            }
                            else
                            {
                                category = "'1', '2', '3', '4', '5', '6', '7', '8', '9', '10', '11', '12', '13', '14', '15', '16', '17', '18', '19', '20', '21', '22', '23', '24', '25', '26', '27', '28'";
                                for (int i = 0; i < dt1.Rows.Count; i++)
                                {
                                    serialName[i] = dt1.Rows[i]["PSName"].ToString();
                                    serialData[i] = dt1.Rows[i]["num1"].ToString() + "," + dt1.Rows[i]["num2"].ToString() + "," + dt1.Rows[i]["num3"].ToString() + "," + dt1.Rows[i]["num4"].ToString() + "," + dt1.Rows[i]["num5"].ToString() + "," + dt1.Rows[i]["num6"].ToString() + "," + dt1.Rows[i]["num7"].ToString() + ","
                                        + dt1.Rows[i]["num8"].ToString() + "," + dt1.Rows[i]["num9"].ToString() + "," + dt1.Rows[i]["num10"].ToString() + "," + dt1.Rows[i]["num11"].ToString() + "," + dt1.Rows[i]["num12"].ToString() + "," + dt1.Rows[i]["num13"].ToString() + "," + dt1.Rows[i]["num14"].ToString() + "," + dt1.Rows[i]["num15"].ToString()
                                        + "," + dt1.Rows[i]["num16"].ToString() + "," + dt1.Rows[i]["num17"].ToString() + "," + dt1.Rows[i]["num18"].ToString() + "," + dt1.Rows[i]["num19"].ToString() + "," + dt1.Rows[i]["num20"].ToString() + "," + dt1.Rows[i]["num21"].ToString() + "," + dt1.Rows[i]["num22"].ToString() + "," + dt1.Rows[i]["num23"].ToString()
                                        + "," + dt1.Rows[i]["num24"].ToString() + "," + dt1.Rows[i]["num25"].ToString() + "," + dt1.Rows[i]["num26"].ToString() + "," + dt1.Rows[i]["num27"].ToString() + "," + dt1.Rows[i]["num28"].ToString();
                                }
                            }
                            break;
                    }
                    break;
                case "2":
                    title = "日信息统计";
                    subtitle = "日期：" + day;
                    yTitle = "入住数量";
                    category = "'00:00', '01:00', '02:00', '03:00', '04:00', '05:00', '06:00', '07:00', '08:00', '09:00', '10:00', '11:00', '12:00', '13:00', '14:00', '15:00', '16:00', '17:00', '18:00', '19:00', '20:00', '21:00', '22:00', '23:00'";
                    DataTable dt2 = helper.GetStatisticTimeData(category, type, year, month, day, psname, LigerRM.Common.SysContext.CurrentUserID.ToString());
                    serialName = new string[dt2.Rows.Count];
                    serialData = new string[dt2.Rows.Count];

                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        serialName[i] = dt2.Rows[i]["PSName"].ToString();
                        serialData[i] = dt2.Rows[i]["num1"].ToString() + "," + dt2.Rows[i]["num2"].ToString() + "," + dt2.Rows[i]["num3"].ToString() + "," + dt2.Rows[i]["num4"].ToString() + "," + dt2.Rows[i]["num5"].ToString() + "," + dt2.Rows[i]["num6"].ToString() + "," + dt2.Rows[i]["num7"].ToString() + ","
                            + dt2.Rows[i]["num8"].ToString() + "," + dt2.Rows[i]["num9"].ToString() + "," + dt2.Rows[i]["num10"].ToString() + "," + dt2.Rows[i]["num11"].ToString() + "," + dt2.Rows[i]["num12"].ToString() + "," + dt2.Rows[i]["num13"].ToString() + "," + dt2.Rows[i]["num14"].ToString() + "," + dt2.Rows[i]["num15"].ToString()
                            + "," + dt2.Rows[i]["num16"].ToString() + "," + dt2.Rows[i]["num17"].ToString() + "," + dt2.Rows[i]["num18"].ToString() + "," + dt2.Rows[i]["num19"].ToString() + "," + dt2.Rows[i]["num20"].ToString() + "," + dt2.Rows[i]["num21"].ToString() + "," + dt2.Rows[i]["num22"].ToString() + "," + dt2.Rows[i]["num23"].ToString() + "," + dt2.Rows[i]["num24"].ToString();
                    }
                    break;
            }
            if (!string.IsNullOrEmpty(chartData))
                chartData = chartData.Substring(0, chartData.Length - 1);
            chartData = chartData + "}";
        }
    }

    public static bool IsLeap(int yN)
    {

        if ((yN % 400 == 0 && yN % 3200 != 0)
           || (yN % 4 == 0 && yN % 100 != 0)
           || (yN % 3200 == 0 && yN % 172800 == 0))
            return true;
        else
            return false;

    }
}