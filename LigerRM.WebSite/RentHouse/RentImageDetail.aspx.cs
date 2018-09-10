using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;



public partial class RentHouse_RentImageDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblSignetId.Text = Request["RentNO"];
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

            LigerRM_BusinessLayer.RentImageHelper helper1 = new LigerRM_BusinessLayer.RentImageHelper();
            //SignetFileHelper helper = new SignetFileHelper();
            string[] signetIds = lblSignetId.Text.Split(',');
            foreach (string s in signetIds)
            {
                string guid = Guid.NewGuid().ToString();
                //helper1.aaa();
               //helper1.AddRentImage1(guid,s, txtName.Text, txtMemo.Text, LigerRM.Common.SysContext.CurrentUserID.ToString());
               //helper1.UpdateRentImage1(guid, txtMemo.Text, bytes);
            }
            
            ScriptManager.RegisterStartupScript(btnOK, btnOK.GetType(), "success", "javascript:SaveDialog();", true);
        }
    }
}