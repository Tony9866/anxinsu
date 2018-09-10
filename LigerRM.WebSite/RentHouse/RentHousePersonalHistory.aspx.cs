using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SignetInternet_BusinessLayer;

public partial class RentHouse_RentHousePersonalHistory : System.Web.UI.Page
{
    public string UserIDCard = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string sql = "select * from cf_user where userid=" + LigerRM.Common.SysContext.CurrentUserID.ToString();
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            if (dt.Rows.Count > 0)
                UserIDCard = dt.Rows[0]["IDCard"].ToString();
        }
    }
}