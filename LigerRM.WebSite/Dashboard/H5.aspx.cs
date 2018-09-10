using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SignetInternet_BusinessLayer;
using System.Data;

public partial class Dashboard_H5 : System.Web.UI.Page
{
    public string HOUSE_TOTALCOUNT = string.Empty;
    public string HOUSE_LEFTCOUNT = string.Empty;
    public string HOUSE_USEDCOUNT = string.Empty;

    public string MOTOR_TOTALCOUNT = string.Empty;
    public string MOTOR_LEFTCOUNT = string.Empty;
    public string MOTOR_USEDCOUNT = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetHouseInfo();
            GetMotorInfo();
            GetPrice("0", dlCai);
            GetPrice("1", dlFruit);
        }
    }

    private void GetHouseInfo()
    {
        RentInfoHelper helper = new RentInfoHelper();
        DataTable dt = helper.GetRentsByStreet("9");
        HOUSE_TOTALCOUNT = dt.Rows.Count.ToString();
        int leftCount = 0;
        int usedCount = 0;

        foreach (DataRow row in dt.Rows)
        {
            if (row["Available"].ToString() == "True")
            {
                leftCount++;
            }
            else
                usedCount++;
        }

        HOUSE_LEFTCOUNT = leftCount.ToString();
        HOUSE_USEDCOUNT = usedCount.ToString();

    }

    private void GetMotorInfo()
    {
        string sql = "select 'UsedCount' = (select COUNT(0) from dbo.Motor_BerthesInfo where status='0'),'LeftCount' = (select COUNT(0) from dbo.Motor_BerthesInfo where status='1')";
        DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
        MOTOR_LEFTCOUNT = dt.Rows[0]["LeftCount"].ToString();
        MOTOR_USEDCOUNT = dt.Rows[0]["UsedCount"].ToString();
        MOTOR_TOTALCOUNT = (int.Parse(dt.Rows[0]["LeftCount"].ToString()) + int.Parse(dt.Rows[0]["UsedCount"].ToString())).ToString();

    }

    private void GetPrice(string category,DataList dl)
    { 
        string sql = "select * from Service_Price where category='"+category+"'";
        DataTable dt= MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
        dl.DataSource = dt;
        dl.DataBind();
    }
}