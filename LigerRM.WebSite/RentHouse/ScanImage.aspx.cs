using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LigerRM.Common;
using SignetInternet_BusinessLayer;
using System.Configuration;
using LigerRM.Common.Payment;
using System.Data;
using System.Text;

public partial class RentHouse_ScanImage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string imgUrl = Request.QueryString["url"];
            imgScan.ImageUrl = "~/images/" + imgUrl;
            timer.Enabled = true;
            //string imgUrl = Request.QueryString["url"];
            //string ran = Request.QueryString["ran"];
            //imgScan.ImageUrl = "~/images/" + imgUrl;

            ////string url = "https://nid.sdtt.com.cn/AppRegSvr/thirdsysinforsvr/hauthretquery/'AppID':'0000004','strRandomNum':'" + ran + "'";
            //string ret = LigerRM.Common.WebRequestHelper.WebRequestPoster.HttpGet("https://nid.sdtt.com.cn/AppRegSvr/thirdsysinforsvr/hauthretquery/'AppID':'0000004','strRandomNum':'SDT-HOUSE-3634323337393230313730333233313134393530323036'", "");
            //Dictionary<string, string> result = JSONHelper.FromJson<Dictionary<string, string>>(ret);
        }
    }
    protected void timer_Tick(object sender, EventArgs e)
    {
        lblRet.Text = "验证中，请不要关闭页面......";
        string imgUrl = Request.QueryString["url"];
        string ran = Request.QueryString["ran"];
        imgScan.ImageUrl = "~/images/" + imgUrl;

        RentAttributeHelper helper = new RentAttributeHelper();
        DataTable dt = helper.GetRentAttribute(ran);

        if (dt.Rows[0]["RRAStatus"].ToString() == ((int)RentAttributeHelper.AttributeStatus.NeedPay).ToString())
        {
            string isPayment = ConfigurationManager.AppSettings["IsPayment"];
            if (!string.IsNullOrEmpty(isPayment) && isPayment.Equals("1"))
            {
                string payUrl = ConfigurationManager.AppSettings["PaymentUrl"];
                string payUser = ConfigurationManager.AppSettings["PaymentUser"];
                string payCost = ConfigurationManager.AppSettings["PaymentCost"];

                StringBuilder sbHtml = new StringBuilder();
                sbHtml.Append("<form id='payBillForm' action='" + payUrl + "' method='post'>");

                sbHtml.Append("<input type='hidden' name='GoodsName' value='" + LigerRM.Common.Global.Encryp.DESEncrypt(ran) + "'/>");
                sbHtml.Append("<input type='hidden' name='Cost' value='" + LigerRM.Common.Global.Encryp.DESEncrypt(payCost) + "'/>");
                sbHtml.Append("<input type='hidden' name='memo' value='" + LigerRM.Common.Global.Encryp.DESEncrypt("出租屋支付") + "'/>");
                sbHtml.Append("<input type='hidden' name='user_id' value='" + LigerRM.Common.Global.Encryp.DESEncrypt(payUser) + "'/>");
                //submit按钮控件请不要含有name属性
                sbHtml.Append("<input type='submit' value='tijiao' style='display:none;'></form>");
                sbHtml.Append("<script>document.forms['payBillForm'].submit();</script>");

                Response.Write(sbHtml.ToString());
            }
        }
        //string ret = LigerRM.Common.WebRequestHelper.WebRequestPoster.HttpGet("https://nid.sdtt.com.cn/AppRegSvr/thirdsysinforsvr/hauthretquery/'AppID':'0000004','strRandomNum':'"+ran+"'", "");
        //Dictionary<string, string> result = JSONHelper.FromJson<Dictionary<string, string>>(ret);
        //if (result["ret"] == "1") //认证成功
        //{
        //    timer.Enabled = false;
        //    RentAttribute rentAttribute = Session["RentOrder"] as RentAttribute;
        //    RentAttributeHelper rentAttributeHelper = new RentAttributeHelper();
        //    rentAttributeHelper.AddRentAttribute(rentAttribute);

        //    string isPayment = ConfigurationManager.AppSettings["IsPayment"];
        //    if (!string.IsNullOrEmpty(isPayment) && isPayment.Equals("1"))
        //    {
        //        Response.Redirect("~/Payment/OrderConfirm.aspx");
        //    }
        //    else
        //        ScriptManager.RegisterStartupScript(this, GetType(), "warning", "javascript:SubmitDialog('" + rentAttribute.RentNo + "');", true);
        //}

        //if (result["ret"] == "0") //尚未认证，等待
        //{ 
        
        //}

        //if (result["ret"] != "1" && result["ret"] != "0")
        //{
        //    //timer.Enabled = false;
        //    lblRet.Text = result["desc"];
        //    ScriptManager.RegisterStartupScript(this, GetType(), "warning", "javascript:ErrorDialog('" + result["desc"] + "');", true);
        //}
    }
}