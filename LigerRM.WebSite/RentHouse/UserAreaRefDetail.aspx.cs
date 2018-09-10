using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SignetInternet_BusinessLayer;

public partial class BaseManage_UserAreaRefDetail : LigerRM.Common.ViewPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            UserInfoHelper helper = new UserInfoHelper();

            ddlDept.DataSource = helper.GetDeptList();
            ddlDept.DataBind();

            ddlUsers.DataSource = helper.GetCFUserList(ddlDept.SelectedValue);
            ddlUsers.DataBind();
        }
    }
    protected void ddlUsers_SelectedIndexChanged(object sender, EventArgs e)
    {
        UserInfoHelper helper = new UserInfoHelper();
        ddlUsers.DataSource = helper.GetCFUserList(ddlDept.SelectedValue);
        ddlUsers.DataBind();
    }
}