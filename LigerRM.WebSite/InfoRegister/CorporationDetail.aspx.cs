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

public partial class InfoRegister_CorporationDetail : ViewPageBase
{
        public string CorporationID
        {
            set { ViewState["CorpId"] = value; }
            get { return ViewState["CorpId"] == null ? Request["CorpId"] == null ? string.Empty : LigerRM.Common.Global.Encryp.DESDecrypt(Request["CorpId"].ToString()) : ViewState["CorpId"].ToString(); }
        }

        public string EditType //E: Means edit, V: means view only
        {
            get { return Request["type"] == null ? "V" : Request["type"].ToString(); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string pass = "&*Js";
                if (Session["CorporationId"] != null)
                {
                    CorporationInfo corp = new CorporationInfo(Session["CorporationId"].ToString());
                    pass = corp.PassWord;
                }
                //UserInfoHelper.IsValidCorporation(CorporationID, pass);
                InitialControls();
            }
        }

        protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            CorporationHelper corHelper = new CorporationHelper();
            lblCorpId.Text = corHelper.GetCorporationID(ddlRegion.SelectedValue);
        }

        protected void InitialControls()
        {
            SignetBaseInfoManager manager = new SignetBaseInfoManager();
            ddlType.DataSource = null;// manager.GetCorporationClass();
            ddlType.DataBind();
            ddlCategory.DataSource = manager.GetGeneralCode("CT");
            ddlCategory.DataBind();
            ddlArea.DataSource = null;// manager.GetAllAreas();
            ddlArea.DataBind();
            CorporationHelper corHelper = new CorporationHelper();


            if (string.IsNullOrEmpty(CorporationID) && EditType == "E")
            {
                ddlRegion.Enabled = true;
                ddlRegion.Visible = true;

                string[] regDeptId = SysContext.CurrentAreaIDs.Replace("'", "").Split(',');
                if (regDeptId.Count() <= 0)
                {
                    DataTable dt = manager.GetAllRegisters();
                    ddlRegion.Items.Add(new ListItem(dt.Rows[0]["rd_reg_dept_name"].ToString(), dt.Rows[0]["rd_reg_dept_Id"].ToString()));
                }
                else
                {
                    foreach (string regId in regDeptId)
                    {
                        DataTable dt = manager.GetReisterArea(regId);
                        ddlRegion.Items.Add(new ListItem(dt.Rows[0]["rd_reg_dept_name"].ToString(), regId));
                    }
                }
                lblCorpId.Text = corHelper.GetCorporationID(ddlRegion.SelectedValue);
                lblUserCode.Text = corHelper.CreateUserCode(6);
                lblQueryCode.Text = corHelper.CreateVerifyCode(6);
            }
            else
            {
                CorporationInfo corInfo = new CorporationInfo(CorporationID);
                ViewState["CorpId"] = CorporationID;
                ddlRegion.Enabled = false;
                ddlRegion.Visible = false;
                lblCorpId.Text = corInfo.CorpID;
                txtCorpname.Text = corInfo.CorpName;
                txtAliasName.Text = corInfo.AliasName;
                txtEnglishName.Text = corInfo.FullName;
                ddlType.SelectedIndex = ddlType.Items.IndexOf(ddlType.Items.FindByText(corInfo.CorpClassName));
                ddlCategory.SelectedIndex = ddlCategory.Items.IndexOf(ddlCategory.Items.FindByText(corInfo.CorpTypeName));
                lblQueryCode.Text = corInfo.OtherNo;
                lblUserCode.Text = corInfo.PassWord;
                txtBoss.Text = corInfo.BossName;
                txtIDCard.Text = corInfo.BossIDCard;
                txtLinker.Text = corInfo.Linker;
                txtOrgnization.Text = corInfo.AccountNo;
                txtLinkWay.Text = corInfo.LinkWay;
                txtPostCode.Text = corInfo.PostCode;
                txtMemo.Text = corInfo.Memo;
                //txtBizNo.Text = corInfo.BizNo;
                ddlCerType.SelectedIndex = ddlCerType.Items.IndexOf(ddlCerType.Items.FindByValue(corInfo.BizNo));
                txtTaxNo.Text = corInfo.TaxNo;
                txtAddress.Text = corInfo.Address;
                ddlArea.SelectedIndex = ddlArea.Items.IndexOf(ddlArea.Items.FindByText(corInfo.AreaName));

                if (EditType == "E")
                    btnSave.Visible = true;
                else
                    btnSave.Visible = false;
            }

            string isShowArea = ConfigurationManager.AppSettings["IsShowArea"];
            if (isShowArea.Equals("0"))
            {
                tdAreaTitle.Visible = false;
                ddlArea.Visible = false;
            }
        }

        protected void grdSignet_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#29426d';this.style.cursor='pointer'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor;");
                e.Row.Attributes.Add("onclick", "wopen('SignetDetail.aspx?SignetID=" + e.Row.Cells[0].Text + "', '印章详细信息', '630','600');");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            CorporationHelper corHelper = new CorporationHelper();

            if (corHelper.IsExistsSameCorp(txtCorpname.Text) && ddlRegion.Visible)
            {
                ScriptManager.RegisterStartupScript(btnSave, GetType(), "warning", "javascript:$.ligerDialog.warn('相同的单位名称已经存在，请重新填写！');", true);
            }
            else
            {
                CorporationInfo corInfo = new CorporationInfo(lblCorpId.Text);
                if (string.IsNullOrEmpty(CorporationID) && EditType == "E")
                { 
                    if (corHelper.IsExists(lblCorpId.Text))
                    {
                        corInfo.CorpID = corHelper.GetCorporationID(ddlRegion.SelectedValue);
                    }
                    else
                        corInfo.CorpID = lblCorpId.Text;
                }
                
                corInfo.CorpName = txtCorpname.Text;
                corInfo.AliasName = txtAliasName.Text;
                corInfo.FullName = txtEnglishName.Text;
                corInfo.CorpClass = ddlType.SelectedValue;
                corInfo.CorpType = ddlCategory.SelectedValue;

                corInfo.TaxNo = txtTaxNo.Text.Trim();
                corInfo.BizNo = ddlCerType.SelectedValue;
                corInfo.OtherNo = lblQueryCode.Text;
                corInfo.PassWord = lblUserCode.Text;
                corInfo.BossName = txtBoss.Text;
                corInfo.BossIDCard = txtIDCard.Text;
                corInfo.Linker = txtLinker.Text;
                corInfo.LinkWay = txtLinkWay.Text;
                corInfo.PostCode = txtPostCode.Text;
                corInfo.Memo = txtMemo.Text;
                corInfo.Address = txtAddress.Text;
                corInfo.AreaID = ddlArea.SelectedValue;
                corInfo.CreateDate = DateTime.Now;
                corInfo.Status = "A";
                corInfo.AccountNo = txtOrgnization.Text;
                corInfo.Creator = SysContext.CurrentUserName;
                corInfo.Region = ddlRegion.SelectedValue;
                if (ddlRegion.Visible )
                    corInfo.RegionName = ddlRegion.SelectedItem.Text;
                
                corHelper.UpdateCorporation(corInfo);
                ScriptManager.RegisterStartupScript(btnSave, GetType(), "warning", "javascript:SubmitDialog();", true);
            }
        }

        protected void btnSignet_Click(object sender, EventArgs e)
        {
            CorporationHelper corHelper = new CorporationHelper();

            if (corHelper.IsExistsSameCorp(txtCorpname.Text) && ddlRegion.Visible)
            {
                ScriptManager.RegisterStartupScript(btnSave, GetType(), "warning", "javascript:$.ligerDialog.warn('相同的单位名称已经存在，请重新填写！');", true);
            }
            else
            {
                CorporationInfo corInfo = new CorporationInfo(lblCorpId.Text);
                if (string.IsNullOrEmpty(CorporationID) && EditType == "E")
                {
                    if (corHelper.IsExists(lblCorpId.Text))
                    {
                        corInfo.CorpID = corHelper.GetCorporationID(ddlRegion.SelectedValue);
                    }
                    else
                        corInfo.CorpID = lblCorpId.Text;
                }

                corInfo.CorpName = txtCorpname.Text;
                corInfo.AliasName = txtAliasName.Text;
                corInfo.FullName = txtEnglishName.Text;
                corInfo.CorpClass = ddlType.SelectedValue;
                corInfo.CorpType = ddlCategory.SelectedValue;

                corInfo.TaxNo = txtTaxNo.Text.Trim();
                corInfo.BizNo = ddlCerType.SelectedValue;
                corInfo.OtherNo = lblQueryCode.Text;
                corInfo.PassWord = lblUserCode.Text;
                corInfo.BossName = txtBoss.Text;
                corInfo.BossIDCard = txtIDCard.Text;
                corInfo.Linker = txtLinker.Text;
                corInfo.LinkWay = txtLinkWay.Text;
                corInfo.PostCode = txtPostCode.Text;
                corInfo.Memo = txtMemo.Text;
                corInfo.Address = txtAddress.Text;
                corInfo.AreaID = ddlArea.SelectedValue;
                corInfo.CreateDate = DateTime.Now;
                corInfo.Status = "A";
                corInfo.AccountNo = txtOrgnization.Text;
                corInfo.Creator = SysContext.CurrentUserName;
                corInfo.Region = ddlRegion.SelectedValue;
                if (ddlRegion.Visible)
                    corInfo.RegionName = ddlRegion.SelectedItem.Text;

                corHelper.UpdateCorporation(corInfo);
                Session["SignetList"] = null;
                Session["Corporation"] = null;
                ScriptManager.RegisterStartupScript(btnSave, GetType(), "warning", "javascript:AddSignetDialog('"+corInfo.CorpID+"');", true);
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

        }
}