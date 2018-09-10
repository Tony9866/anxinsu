using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SignetInternet_BusinessLayer;
using LigerRM.Common;

public partial class RentHouse_PersonMonitorDetail : System.Web.UI.Page
{
    private string ID { get { return Request["ID"]; } }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindTypes();
            if (!string.IsNullOrEmpty(ID))
            {
                MonitorPersonInfo info = new MonitorPersonInfo(ID);
                txtName.Text = info.Name;
                txtIdCard.Text = info.IDCard;
                txtPhone.Text = info.Phone;
                txtStart.Text = info.StartDate.ToString();
                txtEnd.Text = info.EndDate.HasValue ? info.EndDate.ToString() : string.Empty;
                ddlType.SelectedIndex = ddlType.Items.IndexOf(ddlType.Items.FindByValue(info.PersonType));
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        MonitorPersonInfo info = new MonitorPersonInfo(ID);
        MonitorPersonHelper helper = new MonitorPersonHelper();
        if (!string.IsNullOrEmpty(ID))
        {
            info.Name = txtName.Text;
            info.IDCard = txtIdCard.Text;
            info.Phone = txtPhone.Text;
            info.StartDate = DateTime.Parse(txtStart.Text);
            if (!string.IsNullOrEmpty(txtEnd.Text))
                info.EndDate = DateTime.Parse(txtEnd.Text);
            info.PersonType = ddlType.SelectedValue;
            helper.UpdateMonitorPerson(info);
        }
        else
        {
            info.ID = Guid.NewGuid().ToString();
            info.Name = txtName.Text;
            info.IDCard = txtIdCard.Text;
            info.Phone = txtPhone.Text;
            info.StartDate = DateTime.Parse(txtStart.Text);
            if (!string.IsNullOrEmpty(txtEnd.Text))
                info.EndDate = DateTime.Parse(txtEnd.Text);
            info.PersonType = ddlType.SelectedValue;
            info.CreatedBy = SysContext.CurrentUserID.ToString();
            info.CreatedOn = DateTime.Now;
            info.Status = "A";
            helper.AddMonitorPerson(info);
        }

        ScriptManager.RegisterStartupScript(btnSave, btnSave.GetType(), "success", "SubmitDialog();", true);
    }

    private void BindTypes()
    {
        SignetInternet_BusinessLayer.SignetBaseInfoManager mamanger = new SignetInternet_BusinessLayer.SignetBaseInfoManager();
        ddlType.DataValueField = "gc_id";
        ddlType.DataTextField = "gc_name";
        ddlType.DataSource = mamanger.GetGeneralCode("PM");
        ddlType.DataBind();
    }
}