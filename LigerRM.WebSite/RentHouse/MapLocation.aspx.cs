using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InfoRegister_MapLocation : System.Web.UI.Page
{
    public string Lan;
    public string Lat;
    protected void Page_Load(object sender, EventArgs e)
    {
        Lan = Request.QueryString["Lan"];
        Lat = Request.QueryString["Lat"];
    }
}