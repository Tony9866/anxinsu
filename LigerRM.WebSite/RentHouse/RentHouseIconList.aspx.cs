using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SignetInternet_BusinessLayer;
using System.Data;

public partial class RentHouse_RentHouseIconList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        { 
            
        }
    }

    protected void BindHouse()
    {
        string start = string.IsNullOrEmpty(hdStart.Value)?DateTime.Today.ToString("yyyy-MM-dd"):hdStart.Value + " 12:00:00";
        string end = hdEnd.Value + " 12:00:00";

        string sql = "select * from rent_rentattribute where (('" + start + "'>=RRAStartDate and '" + start + "'< RRAEndDate)" +
                    " or ('" + end + "'>RRAStartDate and '" + end + "'<=RRAEndDate) or ('" + start + "'<RRAStartDate and '" + end + "'>RRAEndDate)) and rrastatus not in ('5','7','8','9') order by RRACreatedDate desc";
        DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];

        Dictionary<string, string> rentNOs = new Dictionary<string, string>();
        foreach (DataRow r in dt.Rows)
        {
            rentNOs.Add(r["rraId"].ToString(),r["RentNO"].ToString());
        }
        sql = "select * from v_RentDetail_view where RIDCard=(select idcard from CF_User where LoginName='"+LigerRM.Common.SysContext.CurrentUserName+"')";

        dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
        dt.Columns.Add("IsUsed");
        dt.Columns.Add("RRAID");
        foreach (DataRow r in dt.Rows)
        {
            if (rentNOs.Values.Contains(r["RentNO"].ToString()))
            {
                r["IsUsed"] = "1";
                r["RRAID"] = rentNOs.FirstOrDefault(q => q.Value == r["RentNO"].ToString()).Key;
            }
            else
            {
                r["IsUsed"] = "0";
                r["RRAID"] = string.Empty;
            }
        }
        dlHouse.DataSource = dt;
        dlHouse.DataBind();
    }

    protected void btnPost_Click(object sender, EventArgs e)
    {
        BindHouse();
    }
}