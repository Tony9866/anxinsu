using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SignetInternet_BusinessLayer;

public partial class RentHouse_RentOwner : LigerRM.Common.ViewPageBase
{
    public string m_IdCard = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CFUserInfo user = new CFUserInfo(LigerRM.Common.SysContext.CurrentUserName);
            m_IdCard = user.IDCard;
        }
    }
}