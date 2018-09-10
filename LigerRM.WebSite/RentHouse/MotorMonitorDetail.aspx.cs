using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LigerRM.Common;
using SignetInternet_BusinessLayer;

public partial class RentHouse_MotorMonitorDetail : System.Web.UI.Page
{
    private string ID { get { return Request["ID"]; } }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindTypes();
            if (!string.IsNullOrEmpty(ID))
            {
                MonitorMotorInfo info = new MonitorMotorInfo(ID);
                txtName.Text = info.MotorNO;
                txtStart.Text = info.StartDate.ToString();
                txtEnd.Text = info.EndDate.HasValue ? info.EndDate.ToString() : string.Empty;
                ddlType.SelectedIndex = ddlType.Items.IndexOf(ddlType.Items.FindByValue(info.MotorType));
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        MonitorMotorInfo info = new MonitorMotorInfo(ID);
        MonitorPersonHelper helper = new MonitorPersonHelper();
        if (!string.IsNullOrEmpty(ID))
        {
            info.MotorNO = txtName.Text;
            info.StartDate = DateTime.Parse(txtStart.Text);
            if (!string.IsNullOrEmpty(txtEnd.Text))
                info.EndDate = DateTime.Parse(txtEnd.Text);
            info.MotorType = ddlType.SelectedValue;
            helper.UpdateMonitorMotor(info);
        }
        else
        {
            info.ID = Guid.NewGuid().ToString();
            info.MotorNO = txtName.Text;
            info.StartDate = DateTime.Parse(txtStart.Text);
            if (!string.IsNullOrEmpty(txtEnd.Text))
                info.EndDate = DateTime.Parse(txtEnd.Text);
            info.MotorType = ddlType.SelectedValue;
            info.CreatedBy = SysContext.CurrentUserID.ToString();
            info.CreatedOn = DateTime.Now;
            info.Status = "A";
            helper.AddMonitorMotor(info);
        }

        ScriptManager.RegisterStartupScript(btnSave, btnSave.GetType(), "success", "SubmitDialog();", true);
    }

    private void BindTypes()
    {
        SignetInternet_BusinessLayer.SignetBaseInfoManager mamanger = new SignetInternet_BusinessLayer.SignetBaseInfoManager();
        ddlType.DataValueField = "gc_id";
        ddlType.DataTextField = "gc_name";
        ddlType.DataSource = mamanger.GetGeneralCode("MM");
        ddlType.DataBind();
    }
}