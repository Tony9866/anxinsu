using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LigerRM.Common;
using System.Configuration;
using System.Web.Configuration;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string mac = LigerRM.Common.Global.RegisterHelper.GetMacAddress();
            string province = ConfigurationManager.AppSettings["Province"];
            string sourceCode = mac + province + "Eric";

            string mac1 = LigerRM.Common.Global.RegisterHelper.GetNetworkAdpater();

            lblUserCode.Text = LigerRM.Common.Global.Encryp.DESEncrypt(sourceCode);
            //txtCrackNumber.Text = LigerRM.Common.Global.Encryp.MD5(lblUserCode.Text);
        }
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        string sourceCode = lblUserCode.Text;
        if (txtCrackNumber.Text.Trim().Equals(LigerRM.Common.Global.Encryp.MD5(sourceCode)))
        {
            try
            {
                Configuration config = WebConfigurationManager.OpenWebConfiguration("/Config");
                AppSettingsSection app = config.AppSettings;
                if (app.Settings.AllKeys.Contains("CrackNumber"))
                {
                    app.Settings["CrackNumber"].Value = txtCrackNumber.Text;
                    config.Save(ConfigurationSaveMode.Modified);
                }
                else
                {
                    app.Settings.Add("CrackNumber", txtCrackNumber.Text);
                    config.Save(ConfigurationSaveMode.Modified);
                }
                ScriptManager.RegisterStartupScript(btnRegister, btnRegister.GetType(), "OK", "javascript:alert('系统注册成功！');window.location.href='index.aspx';", true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(btnRegister, btnRegister.GetType(), "OK", "javascript:alert('注册码错误，请联系管理员！！');window.location.href='index.aspx';", true);
        }
    }
}