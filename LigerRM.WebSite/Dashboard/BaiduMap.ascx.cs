using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SignetInternet_BusinessLayer;
using System.Data;

public partial class Dashboard_BaiduMap : System.Web.UI.UserControl
{
    public string dataInfo = string.Empty;
    public string motordataInfo = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            RentInfoHelper helper = new RentInfoHelper();
            DataTable dt = helper.GetRentsByStreet("9");

            foreach (DataRow row in dt.Rows)
            {
                dataInfo += "[" + row["Longitude"].ToString() + ", " + row["Latitude"].ToString() +", '"+row["Available"].ToString()+
                    "', \"地址：" + row["RAddress"].ToString() + "<br/>" +
                        "房主：" + row["ROwner"].ToString() + " " + helper.OverString(row["RIDCard"].ToString()) + "<br/>" +
                        "状态：" + (row["Available"].ToString().ToUpper() == "已租" ? "<span style='color:red;'>出租中</span>" : "空闲") +
                        "\"],";
            }

            if (!string.IsNullOrEmpty(dataInfo))
                dataInfo = dataInfo.Substring(0, dataInfo.Length - 1);

            string sql = "select * from Motor_BerthesInfo";
            DataTable mDt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            foreach (DataRow row in mDt.Rows)
            {
                motordataInfo += "[" + row["Lon"].ToString() + ", " + row["Lat"].ToString() + ", '" + row["Status"].ToString() + "','" + row["BertheNumber"].ToString() + "'],";
            }

            if (!string.IsNullOrEmpty(motordataInfo))
                motordataInfo = motordataInfo.Substring(0, motordataInfo.Length - 1);
        }
    }
}