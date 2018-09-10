using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SignetInternet_BusinessLayer;
using LigerRM.Common;

public partial class Messages : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string carveIds = SysContext.CurrentCarveIDs;
            MessageHelper manager = new MessageHelper();
            if (DataPrivilegeRule.IsAdministrator())
            {
                rptMessage.DataSource = manager.GetAllMessages();
            }
            else
            {
                rptMessage.DataSource = manager.GetMessageByPoliceStation();
            }
            rptMessage.DataBind();

        }
    }
}