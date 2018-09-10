using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SignetInternet_BusinessLayer;
using LigerRM.Common.RedPackageHelper;

public partial class Activity_RedPackageDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindArea();
        }
    }

    protected void BindArea()
    {
        string sql = "select * from Rent_PoliceStation where ParentID='0'";
        DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
        ddlArea.DataSource = dt;
        ddlArea.DataBind();

        ddlArea_SelectedIndexChanged(ddlArea, new EventArgs());
    }
    protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
    {
        string sql = "select * from Rent_PoliceStation where ParentID='"+ddlArea.SelectedValue+"'";
        DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
        ddlPoliceStation.DataSource = dt;
        ddlPoliceStation.DataBind();

        ddlPoliceStation_SelectedIndexChanged(ddlPoliceStation, new EventArgs());
    }
    protected void ddlPoliceStation_SelectedIndexChanged(object sender, EventArgs e)
    {
        string sql = "select * from dbo.Rent_Road where LDID='" + ddlPoliceStation.SelectedValue + "'";
        DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
        ddlXiaoQu.DataSource = dt;
        ddlXiaoQu.DataBind();

        ddlXiaoQu_SelectedIndexChanged(ddlXiaoQu, new EventArgs());
    }
    protected void ddlXiaoQu_SelectedIndexChanged(object sender, EventArgs e)
    {
        string sql = "select rentNo, RAddress,flag=CAST(0 as bit)  from dbo.Rent_Rent where RPSID='" + ddlXiaoQu.SelectedValue + "'";
        DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];

        gvHouse.DataSource = dt;
        gvHouse.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        long[] redPackages = RedPackageHelper.generate(long.Parse(txtTotal.Text) * 10, int.Parse(txtNum.Text), long.Parse(txtMax.Text) * 10, long.Parse(txtMin.Text) * 10);
        string createdOn = DateTime.Now.ToString();
        for (int i = 0; i < redPackages.Count(); i++)
        {
            string rentNo = gvHouse.Rows[i].Cells[1].Text;
            string id = Guid.NewGuid().ToString();
            string sql = "Insert into Sys_RedPackage values ('" + id + "','" + rentNo + "'," + (double.Parse(redPackages[i].ToString()) / 10).ToString() + ",'" + txtStartDate.Text + "','" + txtEndDate.Text + "','0','" + rblType.SelectedValue + "','','" + createdOn + "','','','','')";
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
        }
    }
}