using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SignetInternet_BusinessLayer;

public partial class Dashboard_ElectronicAndWaterMonitor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindData();
        }
    }

    protected void BindData()
    {
        string sql = "select * from rent_rent";
        ddlAddress.DataTextField = "RAddress";
        ddlAddress.DataValueField = "RentNO";
        DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
        ddlAddress.DataSource = dt;
        ddlAddress.DataBind();
    }
}