using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SignetInternet_BusinessLayer;
using System.IO;
using LigerRM.Common;

public partial class InfoRegister_SignetFileDetail : ViewPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lblSignetId.Text = Request["SignetID"].Replace("'","");
            //string type = Request["type"];
            SignetBaseInfoManager manager = new SignetBaseInfoManager();
            ddlFileType.DataSource = manager.GetGeneralCode("CF");
            ddlFileType.DataBind();

            //ddlFileType.SelectedIndex = ddlFileType.Items.IndexOf(ddlFileType.Items.FindByValue(type));
            //ddlFileType.Enabled = false;
            
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (fuFile.HasFile)
        {

            string fileName = Server.MapPath("~") + "\\UploadedFiles\\" + fuFile.FileName;
            string realName = fileName.Substring(fileName.LastIndexOf("\\") + 1);
            fuFile.SaveAs(fileName);
            FileInfo fi = new FileInfo(fileName);
            FileStream fs = fi.OpenRead();
            byte[] bytes = new byte[fs.Length];
            fs.Read(bytes, 0, Convert.ToInt32(fs.Length));
            fs.Close();

            SignetFileHelper helper = new SignetFileHelper();
            string[] signetIds = lblSignetId.Text.Split(',');
            foreach (string s in signetIds)
            {
                helper.AddSignetFile(s, ddlFileType.SelectedValue, realName, bytes, txtMemo.Text);
            }
            //helper.UpdateSignetFile(realName, bytes, txtMemo.Text, id);
            ScriptManager.RegisterStartupScript(btnOK, btnOK.GetType(), "success", "javascript:SaveDialog();", true);
        }
    }


}