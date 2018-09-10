using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SignetInternet_BusinessLayer;
using LigerRM.Common;
using System.Data;
using System.Configuration;
public partial class RentHouse_RentInfoHistory : ViewPageBase
{
    public string RentNo
    {
        set { ViewState["RentNo"] = value; }
        get { return ViewState["RentNo"] == null ? Request["RentNo"] == null ? string.Empty : LigerRM.Common.Global.Encryp.DESDecrypt(Request["RentNo"].ToString()) : ViewState["RentNo"].ToString(); }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}