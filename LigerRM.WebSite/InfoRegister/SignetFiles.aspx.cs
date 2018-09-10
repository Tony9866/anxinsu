using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LigerRM.Common;
using System.Configuration;

public partial class InfoRegister_SignetFiles : ViewPageBase
{
    public string CameraVersion { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CameraVersion = ConfigurationManager.AppSettings["CameraVersion"];
        }
    }
}