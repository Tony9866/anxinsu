using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LigerRM.Common;
using SignetInternet_BusinessLayer;
using System.Data;

public partial class BaseManage_MessageDetail : LigerRM.Common.ViewPageBase
{
    public string EditType { get { return Request["EditType"]; } }
    public string MessageID { get { return Request["Id"]; } }
    public string UserLevel { get { return Request["userLevel"]; } }
    public string CarveIDs { get { return Request["carveId"]; } }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (EditType != "E" && EditType!="V")
            {
                lblReporter.Text = SysContext.CurrentRealName;
                lblDate.Text = DateTime.Now.ToString();
            }
            else
            {
                MessageHelper helper = new MessageHelper();
                DataTable dt = helper.GetMessage(MessageID);
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtTitle.Text = dt.Rows[0]["wt_title"].ToString();
                    txtContent.Text = dt.Rows[0]["wt_text"].ToString();
                    lblReporter.Text = dt.Rows[0]["wt_reporter"].ToString();
                    lblDate.Text = dt.Rows[0]["wt_time"].ToString();
                }

                if (EditType == "V")
                {
                    txtTitle.ReadOnly = txtContent.ReadOnly = true;
                    btnOK.Visible = false;
                    trCarves.Visible = false;
                    if (UserLevel == "2")
                    {
                        MessageHelper shelper = new MessageHelper();
                        shelper.ReadMessage(MessageID, SysContext.CurrentAreaIDs);
                    }
                }
            }
        }
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        MessageHelper helper = new MessageHelper();
        if (EditType != "E")
        {
            helper.AddMessage(txtTitle.Text, txtContent.Text, lblReporter.Text,hdCarve.Value);
        }
        else
        {
            helper.UpdateMessage(txtTitle.Text, txtContent.Text, MessageID);
        }
        ScriptManager.RegisterStartupScript(btnOK, btnOK.GetType(), "success", "javascript:var manager = $.ligerDialog.alert('信息发布成功！', '提示', 'success', function (item, Dialog, index) {parent.$.ligerDialog.close();parent.window.f_reload();parent.$(\".l-dialog,.l-window-mask\").css(\"display\", \"none\");});", true);
    }
}