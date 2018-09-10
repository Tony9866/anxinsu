using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SignetInternet_BusinessLayer;

public partial class RentHouse_UserCommunityDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            UserInfoHelper helper = new UserInfoHelper();
            RentInfoHelper rentHelper = new RentInfoHelper();

            ddlStation.DataSource = rentHelper.dtPoliceStation("0");
            ddlStation.DataBind();

            ddlPolice.DataSource = rentHelper.dtPoliceStation(ddlStation.SelectedValue);
            ddlPolice.DataBind();
            
            ddlUsers.DataSource = helper.GetCFUserList("7");
            ddlUsers.DataBind();
        }
    }
    protected void ddlUsers_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlStation_SelectedIndexChanged(object sender, EventArgs e)
    {
        RentInfoHelper rentHelper = new RentInfoHelper();

        ddlPolice.DataSource = rentHelper.dtPoliceStation(ddlStation.SelectedValue);
        ddlPolice.DataBind();
    }
    protected void ddlPolice_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}