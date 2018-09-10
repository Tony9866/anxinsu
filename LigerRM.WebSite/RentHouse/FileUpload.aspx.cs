using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LigerRM.Common;

public partial class InfoRegister_FileUpload : ViewPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        upFile.Attributes.Add("onchange", "javascript:PreviewImage();");
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        string file = "UploadedFiles/S" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".bmp";
        upFile.SaveAs(Server.MapPath("~") + "/" + file);
        ScriptManager.RegisterStartupScript(btnSave, GetType(), "su", "javascript:GetReturnFile('"+file+"');", true);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

    }
}