using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SignetInternet_BusinessLayer;
using System.Data;

public partial class BaseManage_LockDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ddlDeviceType.Items.Add(new ListItem("智能旧锁", "0"));
            ddlDeviceType.Items.Add(new ListItem("智能新锁", "1"));

            ddlStatus.Items.Add(new ListItem("在线", "0"));
            ddlStatus.Items.Add(new ListItem("离线", "1"));
            ddlStatus.Items.Add(new ListItem("低电", "2"));
            ddlStatus.Items.Add(new ListItem("冻结", "3"));

            if (Request["DeviceID"] != null)
            { 
                LockManager manager = new LockManager();
                DataTable dt = manager.GetDeviceDetailInfo(string.IsNullOrEmpty(Request["DeviceID"].ToString())?"0":Request["DeviceID"].ToString());
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtDeviceID.Text = dt.Rows[0]["DeviceID"].ToString();
                    ddlDeviceType.SelectedIndex = ddlDeviceType.Items.IndexOf(ddlDeviceType.Items.FindByValue(dt.Rows[0]["DeviceType"].ToString()));
                    
                    RentInfo info = new RentInfo(dt.Rows[0]["RentNo"].ToString());
                    hdRentNO.Value = dt.Rows[0]["RentNo"].ToString();

                    txtRentNO.Text = info.RAddress;

                    txtVersion.Text = dt.Rows[0]["VersionID"].ToString();
                    txtBatch.Text = dt.Rows[0]["BatchNO"].ToString();
                    txtDate.Text = dt.Rows[0]["ProductDate"].ToString();
                    ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue(dt.Rows[0]["Status"].ToString()));
                    txtMemo.Text = dt.Rows[0]["Memo"].ToString();

                    string ret =  manager.GetDeviceStatus(dt.Rows[0]["DeviceID"].ToString());

                    if (string.IsNullOrEmpty(ret))
                    {
                        lblStatus.Text = "未知";
                    }
                    else
                    {
                        if (ret.Substring(0, 1).Equals("0"))
                        {
                            lblStatus.Text = "在线";
                        }
                        if (ret.Substring(0, 1).Equals("1"))
                        {
                            lblStatus.Text = "离线";
                        }
                        if (ret.Substring(0, 1).Equals("2"))
                        {
                            lblStatus.Text = "低电";
                        }
                    }
                }
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        LockManager manager = new LockManager();
        if (Request["DeviceID"] != null && !string.IsNullOrEmpty(Request["DeviceID"]))
        {
            manager.UpdateLockDevice(Request["DeviceID"].ToString(), ddlDeviceType.SelectedValue, hdRentNO.Value, txtVersion.Text, txtBatch.Text, txtMemo.Text, ddlStatus.SelectedValue);
        }
        else
            manager.AddLockDevice(txtDeviceID.Text, ddlDeviceType.SelectedValue, hdRentNO.Value
                , txtVersion.Text, txtBatch.Text, txtMemo.Text, ddlStatus.SelectedValue);
        ScriptManager.RegisterStartupScript(btnSave, btnSave.GetType(), "success", "javascript:SaveDialog();", true);
    }
    protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}