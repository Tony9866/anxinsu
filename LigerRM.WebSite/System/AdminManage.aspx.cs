using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_AdminManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        if (txtCode.Text.Trim().Substring(0, 4) == "Eric")
        {
            txtCrackNumber.Text = LigerRM.Common.Global.Encryp.MD5(txtCode.Text.Trim().Substring(4));
        }
    }
}