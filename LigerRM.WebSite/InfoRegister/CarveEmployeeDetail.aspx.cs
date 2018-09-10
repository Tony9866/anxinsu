using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SignetInternet_BusinessLayer;
using LigerRM.Common;

public partial class InfoRegister_CarveEmployeeDetail : System.Web.UI.Page
{
    public string EditType //E: Means edit, V: means view only
    {
        get { return Request["type"] == null ? "V" : Request["type"].ToString(); }
    }
    public string EmployeeID
    {
        set { ViewState["EmpId"] = value; }
        get { return ViewState["EmpId"] == null ? Request["EmpId"] == null ? string.Empty : LigerRM.Common.Global.Encryp.DESDecrypt(Request["EmpId"].ToString()) : ViewState["EmpId"].ToString(); }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SignetBaseInfoManager manager = new SignetBaseInfoManager();
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

            //CarveCorpHelper carveHelper = new CarveCorpHelper();
            //DataTable cDt = carveHelper.GetCarveCorpByRegions(ddlRegion.SelectedValue);
            //DataTable cDt1 = carveHelper.GetAllCarveCorpByUserID(SysContext.CurrentUserID.ToString());
            //List<DataRow> rows = new List<DataRow>();
            //if (cDt1.Rows.Count > 0 && regDeptId.Count() > 0)
            //{
            //    foreach (DataRow row in cDt1.Rows)
            //    {
            //        rows.Add(row);
            //    }
            //}
            //else
            //{
            //    foreach (DataRow row in cDt.Rows)
            //    {
            //        if (SysContext.CurrentCarveIDs.Contains(row["cac_corp_id"].ToString()))
            //            rows.Add(row);
            //    }


            //}
            //ddlCarve.DataSource = cDt1;
            //ddlCarve.DataBind();

            //CarveCorpHelper helper = new CarveCorpHelper();
            //lblEmployeeId.Text = helper.GetEmployeeId(ddlCarve.SelectedValue);

            SignetBaseInfoManager gmanager = new SignetBaseInfoManager();
            ddlNational.DataValueField = "gc_id";
            ddlNational.DataTextField = "gc_name";
            ddlNational.DataSource = manager.GetGeneralCode("NG");
            ddlNational.DataBind();

            ddlPosition.DataValueField = "gc_id";
            ddlPosition.DataTextField = "gc_name";
            ddlPosition.DataSource = manager.GetGeneralCode("PP");
            ddlPosition.DataBind();

            if (!string.IsNullOrEmpty(EmployeeID))
            {
                CarveEmployeeInfo info = new CarveEmployeeInfo(EmployeeID);
                trRegion.Visible = false;
                ddlCarve.Visible = false;
                lblEmployeeId.Text = EmployeeID;
                txtName.Text = info.EmployeeName;
                rblGender.SelectedValue = info.Gender;
                txtIDCard.Text = info.IDCard;
                ddlPosition.SelectedValue = info.Position;
                ddlNational.SelectedValue = info.Nationality;
                txtPhone.Text = info.Phone;
                txtAddress.Text = info.Address;
                txtTempAddress.Text = info.TempAddress;
                txtLink.Text = info.Linker;
                txtLinkWay.Text = info.Linkway;
                txtMemo.Text = info.Memo;

                if (EditType == "V")
                    btnSave.Visible = false;
                else
                    btnSave.Visible = true;
            }
        }
    }
    protected void ddlCarve_SelectedIndexChanged(object sender, EventArgs e)
    {
        //CarveCorpHelper helper = new CarveCorpHelper();
        //lblEmployeeId.Text =  helper.GetEmployeeId(ddlCarve.SelectedValue);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        CarveEmployeeInfo info = new CarveEmployeeInfo(lblEmployeeId.Text);
        info.EmployeeId = lblEmployeeId.Text;
        info.EmployeeName = txtName.Text;
        info.CarveCorpId = ddlCarve.SelectedValue;
        info.Gender = rblGender.SelectedValue;
        info.IDCard = txtIDCard.Text;
        info.Position = ddlPosition.SelectedValue;
        info.Nationality = ddlNational.SelectedValue;
        info.Address = txtAddress.Text;
        info.TempAddress = txtTempAddress.Text;
        info.Phone = txtPhone.Text;
        info.Linker = txtLink.Text;
        info.Linkway = txtLinkWay.Text;
        info.RegistDate = DateTime.Now;
        info.Register = SysContext.CurrentUserID.ToString();
        info.Memo = txtMemo.Text;
        info.Obsolete = false;

        //CarveCorpHelper helper = new CarveCorpHelper();
        //helper.UpdateEmployee(info);
        //ScriptManager.RegisterStartupScript(btnSave, GetType(), "warning", "javascript:SaveDialog();", true);
    }
    protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ddlCarve.Items.Clear();
        //SignetHelper helper = new SignetHelper();
        //CarveCorpHelper carveHelper = new CarveCorpHelper();
        //ddlCarve.DataSource = carveHelper.GetCarveCorpByRegions(ddlRegion.SelectedValue);
        //ddlCarve.DataBind();

        //string[] regDeptId = SysContext.CurrentAreaIDs.Replace("'", "").Split(',');
        //DataTable cDt = carveHelper.GetCarveCorpByRegions(ddlRegion.SelectedValue);
        //DataTable cDt1 = carveHelper.GetAllCarveCorpByUserID(SysContext.CurrentUserID.ToString());
        //List<DataRow> rows = new List<DataRow>();
        //if (cDt1.Rows.Count > 0 && regDeptId.Count() > 0)
        //{
        //    foreach (DataRow row in cDt1.Rows)
        //    {
        //        rows.Add(row);
        //    }
        //}
        //else
        //{
        //    foreach (DataRow row in cDt.Rows)
        //    {
        //        if (SysContext.CurrentCarveIDs.Contains(row["cac_corp_id"].ToString()))
        //            rows.Add(row);
        //    }
        //}
        //ddlCarve.DataSource = rows;
        //ddlCarve.DataBind();
    }
}