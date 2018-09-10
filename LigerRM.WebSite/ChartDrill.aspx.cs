using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LigerRM.Common;
using System.Data;
using SignetInternet_BusinessLayer;
using System.Configuration;

public partial class ChartDrill : LigerRM.Common.ViewPageBase
{
    public string Title = string.Empty;
    public string SubTitle = string.Empty;
    public string Categorys = string.Empty;
    public string yAxis = string.Empty;
    public string Series = string.Empty;
    public string Data = string.Empty;
    public string Name = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //string c = Request["category"];
            //string startDate = Request["sDate"];
            //string endDate = Request["eDate"];
            //string signType = Request["type"];
            //string region = Request["region"];
            //if (string.IsNullOrEmpty(startDate))
            //    startDate = "1900-01-01";
            //if (string.IsNullOrEmpty(endDate))
            //    endDate = DateTime.Now.AddDays(1).ToShortDateString();

            //if (string.IsNullOrEmpty(c))
            //    return;
            //DataTable statisticTable = null;
            //SignetHelper helper = new SignetHelper();
            //switch (c)
            //{ 
            //    case "CorType":
            //            Title = "印章数量统计报表";
            //            Name = "企业类型";
            //            SubTitle = DateTime.Parse(startDate).ToString("yyyy年MM月dd日") + " - " + DateTime.Parse(endDate).ToString("yyyy年MM月dd日");
            //            yAxis = "数量";
            //            statisticTable = helper.SignetStatisticByCorType(startDate, endDate, signType, SysContext.CurrentAreaIDs);
            //            for (int i = 0; i < statisticTable.Rows.Count; i++)
            //            {
            //                Categorys += statisticTable.Rows[i]["gc_name"].ToString() + "','";
            //                Data += "{y: " + (string.IsNullOrEmpty(statisticTable.Rows[i]["total_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["total_cnt"].ToString()) + ",color: colors[0],"
            //                    + "drilldown: {name: '印章状态分组',categories: ['注册章','已录入','已登记','已备案','已退回','已承接','已交付','已撤销','已报废','已缴销','已挂失','公安登记章','联审章','企业登记章']," +
            //                    "data: ["+ (string.IsNullOrEmpty(statisticTable.Rows[i]["reg_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["reg_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["input_cnt"].ToString())?"0":statisticTable.Rows[i]["input_cnt"].ToString())
            //                    + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["register_cnt"].ToString())?"0":statisticTable.Rows[i]["register_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["approve_cnt"].ToString())?"0": statisticTable.Rows[i]["approve_cnt"].ToString())+ "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["reject_cnt"].ToString())?"0":statisticTable.Rows[i]["reject_cnt"].ToString())
            //                    + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["accept_cnt"].ToString())?"0":statisticTable.Rows[i]["accept_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["deliver_cnt"].ToString())?"0":statisticTable.Rows[i]["deliver_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["repeal_cnt"].ToString())?"0":statisticTable.Rows[i]["repeal_cnt"].ToString())
            //                    + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["cancel_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["cancel_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["delete_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["delete_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["loss_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["loss_cnt"].ToString())
            //                    + ", " + (string.IsNullOrEmpty(statisticTable.Rows[i]["reg1_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["reg1_cnt"].ToString()) + ", " + (string.IsNullOrEmpty(statisticTable.Rows[i]["union_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["union_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["carve_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["carve_cnt"].ToString()) +"],color: colors[0]}},";
            //            }
            //        break;
            //    case "CorClass":
            //            Title = "印章数量统计报表";
            //            Name = "企业类别";
            //            SubTitle = DateTime.Parse(startDate).ToString("yyyy年MM月dd日") + " - " + DateTime.Parse(endDate).ToString("yyyy年MM月dd日");
            //            yAxis = "数量";
            //            statisticTable = helper.SignetStatisticByCorClass(startDate, endDate, signType, SysContext.CurrentAreaIDs);
            //            for (int i = 0; i < statisticTable.Rows.Count; i++)
            //            {
            //                Categorys += statisticTable.Rows[i]["cc_description"].ToString() + "','";
            //                Data += "{y: " + (string.IsNullOrEmpty(statisticTable.Rows[i]["total_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["total_cnt"].ToString()) + ",color: colors[0],"
            //                    + "drilldown: {name: '印章状态分组',categories: ['注册章','已录入','已登记','已备案','已退回','已承接','已交付','已撤销','已报废','已缴销','已挂失','公安登记章','联审章','企业登记章']," +
            //                    "data: ["+ (string.IsNullOrEmpty(statisticTable.Rows[i]["reg_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["reg_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["input_cnt"].ToString())?"0":statisticTable.Rows[i]["input_cnt"].ToString())
            //                    + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["register_cnt"].ToString())?"0":statisticTable.Rows[i]["register_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["approve_cnt"].ToString())?"0": statisticTable.Rows[i]["approve_cnt"].ToString())+ "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["reject_cnt"].ToString())?"0":statisticTable.Rows[i]["reject_cnt"].ToString())
            //                    + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["accept_cnt"].ToString())?"0":statisticTable.Rows[i]["accept_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["deliver_cnt"].ToString())?"0":statisticTable.Rows[i]["deliver_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["repeal_cnt"].ToString())?"0":statisticTable.Rows[i]["repeal_cnt"].ToString())
            //                    + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["cancel_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["cancel_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["delete_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["delete_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["loss_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["loss_cnt"].ToString())
            //                    + ", " + (string.IsNullOrEmpty(statisticTable.Rows[i]["reg1_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["reg1_cnt"].ToString()) + ", " + (string.IsNullOrEmpty(statisticTable.Rows[i]["union_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["union_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["carve_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["carve_cnt"].ToString()) +"],color: colors[0]}},";
            //            }
            //        break;
            //    case "SignetType":
            //        Title = "印章数量统计报表";
            //        Name = "印章类型";
            //        SubTitle = DateTime.Parse(startDate).ToString("yyyy年MM月dd日") + " - " + DateTime.Parse(endDate).ToString("yyyy年MM月dd日");
            //        yAxis = "数量";
            //        statisticTable = helper.SignetStatisticByType(startDate, endDate, region);
            //        for (int i = 0; i < statisticTable.Rows.Count; i++)
            //        {
            //            Categorys += statisticTable.Rows[i]["st_description"].ToString() + "','";
            //            Data += "{y: " + (string.IsNullOrEmpty(statisticTable.Rows[i]["total_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["total_cnt"].ToString()) + ",color: colors[0],"
            //                + "drilldown: {name: '印章状态分组',categories: ['注册章','已录入','已登记','已备案','已退回','已承接','已交付','已撤销','已报废','已缴销','已挂失','公安登记章','联审章','企业登记章']," +
            //                "data: [" + (string.IsNullOrEmpty(statisticTable.Rows[i]["reg_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["reg_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["input_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["input_cnt"].ToString())
            //                + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["register_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["register_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["approve_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["approve_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["reject_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["reject_cnt"].ToString())
            //                + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["accept_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["accept_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["deliver_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["deliver_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["repeal_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["repeal_cnt"].ToString())
            //                + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["cancel_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["cancel_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["delete_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["delete_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["loss_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["loss_cnt"].ToString())
            //                + ", " + (string.IsNullOrEmpty(statisticTable.Rows[i]["reg1_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["reg1_cnt"].ToString()) + ", " + (string.IsNullOrEmpty(statisticTable.Rows[i]["union_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["union_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["carve_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["carve_cnt"].ToString()) + "],color: colors[0]}},";
            //        }
            //        break;
            //    case "Region":
            //        Title = "印章数量统计报表";
            //        Name = "登记区域";
            //        SubTitle = DateTime.Parse(startDate).ToString("yyyy年MM月dd日") + " - " + DateTime.Parse(endDate).ToString("yyyy年MM月dd日");
            //        yAxis = "数量";
            //        statisticTable = helper.SignetStatisticByRegDept(startDate, endDate, signType, SysContext.CurrentAreaIDs);
            //        for (int i = 0; i < statisticTable.Rows.Count; i++)
            //        {
            //            Categorys += statisticTable.Rows[i]["rd_reg_dept_name"].ToString().Trim() + "','";
            //            Data += "{y: " + (string.IsNullOrEmpty(statisticTable.Rows[i]["total_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["total_cnt"].ToString()) + ",color: colors[0],"
            //                + "drilldown: {name: '印章状态分组',categories: ['注册章','已录入','已登记','已备案','已退回','已承接','已交付','已撤销','已报废','已缴销','已挂失','公安登记章','联审章','企业登记章']," +
            //                "data: [" + (string.IsNullOrEmpty(statisticTable.Rows[i]["reg_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["reg_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["input_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["input_cnt"].ToString())
            //                + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["register_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["register_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["approve_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["approve_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["reject_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["reject_cnt"].ToString())
            //                + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["accept_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["accept_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["deliver_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["deliver_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["repeal_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["repeal_cnt"].ToString())
            //                + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["cancel_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["cancel_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["delete_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["delete_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["loss_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["loss_cnt"].ToString())
            //                + ", " + (string.IsNullOrEmpty(statisticTable.Rows[i]["reg1_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["reg1_cnt"].ToString()) + ", " + (string.IsNullOrEmpty(statisticTable.Rows[i]["union_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["union_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["carve_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["carve_cnt"].ToString()) + "],color: colors[0]}},";
            //        }
            //        break;
            //    case "Carve":
            //        string version = ConfigurationManager.AppSettings["Version"];
            //        string carvecorpIds = string.Empty;
            //        if (version.Equals("2"))
            //        {
            //            carvecorpIds = SysContext.CurrentCarveIDs;
            //        }
            //        Title = "印章数量统计报表";
            //        Name = "制章单位";
            //        SubTitle = DateTime.Parse(startDate).ToString("yyyy年MM月dd日") + " - " + DateTime.Parse(endDate).ToString("yyyy年MM月dd日");
            //        yAxis = "数量";
            //        statisticTable = helper.SignetStatisticByCarveCorp(startDate, endDate, signType, SysContext.CurrentAreaIDs,carvecorpIds);
            //        for (int i = 0; i < statisticTable.Rows.Count; i++)
            //        {
            //            Categorys += statisticTable.Rows[i]["cac_corp_name"].ToString() + "','";
            //            Data += "{y: " + (string.IsNullOrEmpty(statisticTable.Rows[i]["total_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["total_cnt"].ToString()) + ",color: colors[0],"
            //                + "drilldown: {name: '印章状态分组',categories: ['注册章','已录入','已登记','已备案','已退回','已承接','已交付','已撤销','已报废','已缴销','已挂失','公安登记章','联审章','企业登记章']," +
            //                "data: [" + (string.IsNullOrEmpty(statisticTable.Rows[i]["reg_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["reg_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["input_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["input_cnt"].ToString())
            //                + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["register_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["register_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["approve_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["approve_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["reject_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["reject_cnt"].ToString())
            //                + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["accept_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["accept_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["deliver_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["deliver_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["repeal_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["repeal_cnt"].ToString())
            //                + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["cancel_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["cancel_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["delete_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["delete_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["loss_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["loss_cnt"].ToString())
            //                + ", " + (string.IsNullOrEmpty(statisticTable.Rows[i]["reg1_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["reg1_cnt"].ToString()) + ", " + (string.IsNullOrEmpty(statisticTable.Rows[i]["union_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["union_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["carve_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["carve_cnt"].ToString()) + "],color: colors[0]}},";
            //        }
            //        break;
            //    case "Approver":
            //        Title = "印章数量统计报表";
            //        Name = "备案人员";
            //        SubTitle = DateTime.Parse(startDate).ToString("yyyy年MM月dd日") + " - " + DateTime.Parse(endDate).ToString("yyyy年MM月dd日");
            //        yAxis = "数量";
            //        statisticTable = helper.SignetStatisticByApprover(startDate, endDate, signType, SysContext.CurrentAreaIDs);
            //        for (int i = 0; i < statisticTable.Rows.Count; i++)
            //        {
            //            Categorys += statisticTable.Rows[i]["RealName"].ToString() + "','";
            //            Data += "{y: " + (string.IsNullOrEmpty(statisticTable.Rows[i]["total_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["total_cnt"].ToString()) + ",color: colors[0],"
            //                + "drilldown: {name: '印章状态分组',categories: ['注册章','已录入','已登记','已备案','已退回','已承接','已交付','已撤销','已报废','已缴销','已挂失','公安登记章','联审章','企业登记章']," +
            //                "data: [" + (string.IsNullOrEmpty(statisticTable.Rows[i]["reg_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["reg_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["input_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["input_cnt"].ToString())
            //                + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["register_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["register_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["approve_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["approve_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["reject_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["reject_cnt"].ToString())
            //                + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["accept_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["accept_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["deliver_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["deliver_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["repeal_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["repeal_cnt"].ToString())
            //                + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["cancel_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["cancel_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["delete_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["delete_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["loss_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["loss_cnt"].ToString())
            //                + ", " + (string.IsNullOrEmpty(statisticTable.Rows[i]["reg1_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["reg1_cnt"].ToString()) + ", " + (string.IsNullOrEmpty(statisticTable.Rows[i]["union_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["union_cnt"].ToString()) + "," + (string.IsNullOrEmpty(statisticTable.Rows[i]["carve_cnt"].ToString()) ? "0" : statisticTable.Rows[i]["carve_cnt"].ToString()) + "],color: colors[0]}},";
            //        }
            //        break;
            //}

            //if (!string.IsNullOrEmpty(Series))
            //    Series = Series.Substring(0, Series.Length - 1);
            //if (!string.IsNullOrEmpty(Categorys))
            //    Categorys = Categorys.Substring(0, Categorys.Length - 3);
            //if (!string.IsNullOrEmpty(Data))
            //    Data = Data.Substring(0, Data.Length - 1);
        }
    }
}