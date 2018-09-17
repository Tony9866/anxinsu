using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SignetInternet_BusinessLayer;

public partial class AppUpSet_sepcialEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    //public class lis
    //{
    //    public int MyProperty { get; set; }
    //}

    //public List<lis> LIST()
    //{
    //    return new List<lis>();
    //}


    public string GetProvince()
    {
        //测试一下
        AppHomeHelper apphome_Province = new AppHomeHelper();
        try
        {
            string html = " <option value=\"-1\">--请选择省份--</option>";
            foreach (var item in apphome_Province.GetListProvince())
            {
                html += " <option value=\"" + item.provinceid + "\">" + item.province + "</option>";
            }
            return html;
        }
        catch (Exception ex)
        {

            throw;
        }
    }


    //public string GetCity(string provinceid)
    //{
    //    //测试一下
    //    //AppHomeHelper apphome_City = new AppHomeHelper();
    //    //try
    //    //{
    //    //    string html = " <option value=\"-1\">--请选择城市--</option>";
    //    //    foreach (var item in apphome_City.GetListCity(provinceid))
    //    //    {
    //    //        html += " <option value=\"" + item.provinceid + "\">" + item.city + "</option>";
    //    //    }
    //    //    return html;
    //    //}
    //    //catch (Exception ex)
    //    //{

    //    //    throw;
    //    //}
    //}
}