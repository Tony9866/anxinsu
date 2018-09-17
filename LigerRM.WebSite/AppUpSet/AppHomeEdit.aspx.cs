using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SignetInternet_BusinessLayer;
using LigerRM.Common;

public partial class AppUpSet_AppHomeEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public class lis
    {
        public int MyProperty { get; set; }
    }

    public List<lis> LIST()
    {
        return new List<lis>();
    }

    
    public string GetHousing()
    {
        //测试一下
        AppHomeHelper apphome = new AppHomeHelper();
        try
        {
            string html = " <option value=\"-1\">--请选择--</option>";
            foreach (var item in apphome.GetListClass())
            {
                html += " <option value=\"" + item.classId + "\">" + item.class_Name + "</option>";
            }
            return html;

        }
        catch (Exception ex)
        {
            
            throw;
        }
    }

}