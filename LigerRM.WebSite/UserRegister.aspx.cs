using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserRegister : System.Web.UI.Page
{
    protected void txtPhone_TextChanged(object sender, EventArgs e)
    {
        if (chkPhone.Checked)
        {
            txtUserId.Text = txtPhone.Text;
        }
    }
    protected void chkPhone_CheckedChanged(object sender, EventArgs e)
    {
        if (chkPhone.Checked)
        {

            txtUserId.Enabled = false;
            txtUserId.Text = txtPhone.Text;
        }
        else
        {
            txtUserId.Enabled = true;
        }
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        SignetInternet_BusinessLayer.UserInfoHelper helper = new SignetInternet_BusinessLayer.UserInfoHelper();
        SignetInternet_BusinessLayer.CFUserInfo info = new SignetInternet_BusinessLayer.CFUserInfo(txtUserId.Text);
        if (!string.IsNullOrEmpty(info.LoginName))
        {
            ScriptManager.RegisterStartupScript(btnRegister, btnRegister.GetType(), "error", "$.ligerDialog.warn('相同的用户名已经存在，请重新输入!');", true);
            
        }
        else
        {
            if (helper.IsExistsSamePhone(txtPhone.Text))
            {
                ScriptManager.RegisterStartupScript(btnRegister, btnRegister.GetType(), "error", "$.ligerDialog.warn('相同的电话号码已经注册，无法使用该电话号码注册!');", true);
            }
            else
            {
                helper.AddUserInfo(txtUserId.Text, txtPassword.Text, txtName.Text, rblSex.SelectedValue, txtPhone.Text, txtIdCard.Text);
                bool ret = SystemService.UserLogin(txtUserId.Text, txtPassword.Text);
                if (ret)
                    Response.Redirect("index.aspx");
            }
        }
    }
    /// <summary>
    /// 判断是否勾选协议
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void checkbox_CheckedChanged(object sender, EventArgs e)
    {
        if (checkbox.Checked)
        {

            btnRegister.Enabled = true;
            txtUserId.Text = txtPhone.Text;
        }
        else
        {
            btnRegister.Enabled = false;
        }
    }
}