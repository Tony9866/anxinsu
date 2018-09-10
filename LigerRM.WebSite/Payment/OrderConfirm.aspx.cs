using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LigerRM.Common.Payment;
using LigerRM.Common;
using System.Text;
using System.Net;
using System.IO;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public partial class Payment_OrderConfirm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lblOrderID.Text = YinTongUtil.getCurrentDateTimeStr();
            lblGoodsName.Text = "出租屋测试支付";
            lblCount.Text = "1";
            lblCost.Text ="0.01";
            lblMemo.Text = "无";

        }
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
        OrderInfo info = new OrderInfo(lblOrderID.Text);
        if (rbUnion.Checked)
        {
            /**订单信息**/
            // 商户订单时间
            string dt_order = YinTongUtil.getCurrentDateTimeStr();
            // 交易金额 单位为RMB-元
            string money_order = lblCost.Text;
            // 商品名称
            string name_goods = lblGoodsName.Text;
            // 订单描述
            string info_order = lblGoodsName.Text;

            /** 商户提交参数**/
            string version = PartnerConfig.VERSION;						//接口版本号
            string oid_partner = LigerRM.Common.Payment.PartnerConfig.OID_PARTNER;		//商户编号
            string user_id = SysContext.CurrentUserID.ToString();
            string sign_type = PartnerConfig.SIGN_TYPE;					//签名类型：RSA/MD5
            string busi_partner = PartnerConfig.BUSI_PARTNER; 			//业务类型 虚拟商品销售
            string notify_url = PartnerConfig.NOTIFY_URL;				//接收异步通知地
            string url_return = PartnerConfig.URL_RETURN;				//支付结束后返回地址
            string userreq_ip = Request.UserHostAddress;        		//IP *
            string url_order = "";
            string valid_order = "10080";								// 订单有效期 单位分钟，可以为空，默认7天
            string timestamp = YinTongUtil.getCurrentDateTimeStr();		//时间戳


            if (!string.IsNullOrEmpty(info.DTOrder))
            {

                sParaTemp.Add("version", info.Version);
                sParaTemp.Add("oid_partner", info.OidPartner);
                sParaTemp.Add("user_id", info.UserId);
                sParaTemp.Add("sign_type", info.SignType);
                sParaTemp.Add("busi_partner", info.BusiPartner);
                sParaTemp.Add("no_order", info.OrderID);
                sParaTemp.Add("dt_order", info.DTOrder);
                sParaTemp.Add("name_goods", info.OrderDesc);
                sParaTemp.Add("info_order", info.OrderDesc);
                sParaTemp.Add("money_order", info.Cost);
                sParaTemp.Add("notify_url", info.NotifyUrl);
                sParaTemp.Add("url_return", info.ReturnUrl);
                sParaTemp.Add("userreq_ip", info.RequestIP);
                sParaTemp.Add("url_order", info.OrderUrl);
                sParaTemp.Add("valid_order", info.OrderValid);
                sParaTemp.Add("timestamp", info.Timestamp);
                sParaTemp.Add("risk_item", "pass");
                sParaTemp.Add("sign", info.Sign);
            }
            else
            {

                sParaTemp.Add("version", version);
                sParaTemp.Add("oid_partner", oid_partner);
                sParaTemp.Add("user_id", user_id);
                sParaTemp.Add("sign_type", sign_type);
                sParaTemp.Add("busi_partner", busi_partner);
                sParaTemp.Add("no_order", lblOrderID.Text);
                sParaTemp.Add("dt_order", dt_order);
                sParaTemp.Add("name_goods", name_goods);
                sParaTemp.Add("info_order", info_order);
                sParaTemp.Add("money_order", money_order);
                sParaTemp.Add("notify_url", notify_url);
                sParaTemp.Add("url_return", string.Format(url_return, lblOrderID.Text));
                sParaTemp.Add("userreq_ip", userreq_ip);
                sParaTemp.Add("url_order", url_order);
                sParaTemp.Add("valid_order", valid_order);
                sParaTemp.Add("timestamp", timestamp);
                sParaTemp.Add("risk_item", "pass");
                //加签
                string sign = YinTongUtil.addSign(sParaTemp, PartnerConfig.TRADER_PRI_KEY, PartnerConfig.MD5_KEY);
                sParaTemp.Add("sign", sign);


                info.OrderID = lblOrderID.Text;
                info.DTOrder = dt_order;
                info.OidPartner = oid_partner;
                info.UserId = user_id;
                info.KeyID = string.Empty;
                info.Sign = sign;
                info.SignType = sign_type;
                info.PayType = ((int)OrderInfo.PaymentType.Card).ToString();
                info.BusiPartner = busi_partner;
                info.Version = version;
                info.OrderDesc = info_order;
                info.NotifyUrl = notify_url;
                info.ReturnUrl = string.Format(url_return, lblOrderID.Text);
                info.RequestIP = userreq_ip;
                info.OrderUrl = url_order;
                info.OrderValid = valid_order;
                info.Timestamp = timestamp;
                info.Risk = "pass";
                info.DimensionUrl = string.Empty;
                info.CreatedBy = user_id;
                info.CreateDate = DateTime.Now;
                info.Status = ((int)OrderInfo.OrderStatus.NotPay).ToString();

                OrderDetailInfo dInfo = new OrderDetailInfo();
                dInfo.OrderDetailID = YinTongUtil.getCurrentDateTimeStr();
                dInfo.OrderID = info.OrderID;
                dInfo.GoodsName = lblGoodsName.Text;
                dInfo.Cost = lblCost.Text;

                info.DetailInfos.Add(dInfo);

                OrderHelper helper = new OrderHelper();
                helper.AddOrder(info);


            }

            StringBuilder sbHtml = new StringBuilder();

            sbHtml.Append("<form id='payBillForm' action='" + ServerURLConfig.PAY_URL + "' method='post'>");

            foreach (KeyValuePair<string, string> temp in sParaTemp)
            {
                sbHtml.Append("<input type='hidden' name='" + temp.Key + "' value='" + temp.Value + "'/>");
            }
            //submit按钮控件请不要含有name属性
            sbHtml.Append("<input type='submit' value='tijiao' style='display:none;'></form>");
            sbHtml.Append("<script>document.forms['payBillForm'].submit();</script>");
            string sHtmlText = sbHtml.ToString();
            Response.Write(sHtmlText);
        }


        if (rbWeChart.Checked)
        {
            string url = ServerURLConfig.WECHARTPAY_URL;
            Encoding encoding = Encoding.GetEncoding("utf-8");
            /**订单信息**/
            // 商户唯一订单号
            //string no_order = YinTongUtil.getCurrentDateTimeStr();
            // 商户订单时间
            string dt_order = YinTongUtil.getCurrentDateTimeStr();
            // 交易金额 单位为RMB-元
            string money_order = lblCost.Text;
            // 商品名称
            string name_goods = lblGoodsName.Text;
            // 订单描述
            string info_order = lblGoodsName.Text;

            /** 商户提交参数**/
            string version = WeChartParentConfig.VERSION;						//接口版本号
            string oid_partner = LigerRM.Common.Payment.WeChartParentConfig.OID_PARTNER;		//商户编号
            //string user_id = Request["user_id"].Trim();				//用户ID
            string sign_type = WeChartParentConfig.SIGN_TYPE;					//签名类型：RSA/MD5
            string busi_partner = WeChartParentConfig.BUSI_PARTNER; 			//业务类型 虚拟商品销售
            string notify_url = WeChartParentConfig.NOTIFY_URL;				//接收异步通知地
            string url_return = WeChartParentConfig.URL_RETURN;				//支付结束后返回地址
            string userreq_ip = Request.UserHostAddress;        		//IP *
            string url_order = "";
            string valid_order = "10080";								// 订单有效期 单位分钟，可以为空，默认7天
            string timestamp = YinTongUtil.getCurrentDateTimeStr();		//时间戳

            //sParaTemp.Add("version", version);
            sParaTemp.Add("no_order", lblOrderID.Text);
            sParaTemp.Add("oid_partner", oid_partner);
            sParaTemp.Add("money_order", money_order);
            sParaTemp.Add("dt_order", dt_order);
            sParaTemp.Add("notify_url", notify_url);
            sParaTemp.Add("info_order", info_order);
            sParaTemp.Add("name_goods", name_goods);
            sParaTemp.Add("pay_type", ((int)OrderInfo.PaymentType.WeChart).ToString());
            sParaTemp.Add("risk_item", "pass");
            sParaTemp.Add("sign_type", sign_type);

            string sign = YinTongUtil.addSign(sParaTemp, WeChartParentConfig.TRADER_PRI_KEY, WeChartParentConfig.MD5_KEY);
            sParaTemp.Add("sign", sign);


            HttpWebResponse response = CreatePostHttpResponse(url, sParaTemp, encoding);
            Stream stream = response.GetResponseStream();   //获取响应的字符串流  
            StreamReader sr = new StreamReader(stream); //创建一个stream读取流  
            string html = sr.ReadToEnd();   //从头读到尾，放到字符串html  

            Dictionary<string, string> returnStr = JSONHelper.FromJson<Dictionary<string, string>>(html);

            if (returnStr["ret_code"] == "000000" && returnStr.Keys.Contains("pay_status") && returnStr["pay_status"] == "1")
            {
                info.OrderID = lblOrderID.Text;
                info.DTOrder = dt_order;
                info.OidPartner = oid_partner;
                info.UserId = SysContext.CurrentUserID.ToString();
                info.KeyID = string.Empty;
                info.Sign = sign;
                info.PayType = ((int)OrderInfo.PaymentType.WeChart).ToString();
                info.SignType = sign_type;
                info.BusiPartner = busi_partner;
                info.Version = version;
                info.OrderDesc = info_order;
                info.NotifyUrl = notify_url;
                info.ReturnUrl = string.Format(url_return, lblOrderID.Text);
                info.RequestIP = userreq_ip;
                info.OrderUrl = url_order;
                info.OrderValid = valid_order;
                info.Timestamp = timestamp;
                info.Risk = "pass";
                info.DimensionUrl = string.Empty;
                info.CreatedBy = SysContext.CurrentUserID.ToString();
                info.CreateDate = DateTime.Now;
                info.Status = ((int)OrderInfo.OrderStatus.NotPay).ToString();

                OrderDetailInfo dInfo = new OrderDetailInfo();
                dInfo.OrderDetailID = YinTongUtil.getCurrentDateTimeStr();
                dInfo.OrderID = info.OrderID;
                dInfo.GoodsName = lblGoodsName.Text;
                dInfo.Cost = lblCost.Text;
                info.DimensionUrl = returnStr["dimension_url"];
                info.OrderNO = returnStr["no_order"];
                info.DetailInfos.Add(dInfo);

                OrderHelper helper = new OrderHelper();
                helper.AddOrder(info);
                string imgurl = QRCodeHelper.CreateQR(returnStr["dimension_url"]);
                //helper.UpdateDemitionUrl(lblOrderID.Text, returnStr["dimension_url"], returnStr["no_order"]);
                timer.Enabled = true;
                imgCode.ImageUrl = "~/images/" + imgurl;
                lblTitle.Text = "微信支付-扫面下方二维码完成支付";
                ScriptManager.RegisterStartupScript(btnNext,btnNext.GetType(),"show", "javascript:showdiv();",true);
            }
        }
    }

    public static HttpWebResponse CreatePostHttpResponse(string url, IDictionary<string, string> parameters, Encoding charset)
    {
        HttpWebRequest request = null;
        //HTTPSQ请求  
        ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
        request = WebRequest.Create(url) as HttpWebRequest;
        request.ProtocolVersion = HttpVersion.Version10;
        request.Method = "POST";
        request.ContentType = "application/json;charset=UTF-8";
        //request.UserAgent = DefaultUserAgent;
        //如果需要POST数据     
        if (!(parameters == null || parameters.Count == 0))
        {
            StringBuilder buffer = new StringBuilder();
            buffer.Append("{");
            int i = 0;
            foreach (string key in parameters.Keys)
            {
                if (i > 0)
                {
                    buffer.AppendFormat(",\"{0}\":\"{1}\"", key, parameters[key]);
                }
                else
                {
                    buffer.AppendFormat("\"{0}\":\"{1}\"", key, parameters[key]);
                }
                i++;
            }
            buffer.Append("}");
            byte[] data = charset.GetBytes(buffer.ToString());

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
        }
        return request.GetResponse() as HttpWebResponse;
    }

    private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
    {
        return true; //总是接受     
    }

    protected void timer_Tick(object sender, EventArgs e)
    {
        //timer.Enabled = false;
        OrderInfo info = new OrderInfo(lblOrderID.Text);
        SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();

        Encoding encoding = Encoding.GetEncoding("utf-8");
        sParaTemp.Add("no_order", info.OrderNO);//20170425140229
        sParaTemp.Add("oid_partner", LigerRM.Common.Payment.WeChartParentConfig.OID_PARTNER);
        sParaTemp.Add("sign_type", WeChartParentConfig.SIGN_TYPE);

        string sign = YinTongUtil.addSign(sParaTemp, WeChartParentConfig.TRADER_PRI_KEY, WeChartParentConfig.MD5_KEY);
        sParaTemp.Add("sign", sign);

        HttpWebResponse response = CreatePostHttpResponse(ServerURLConfig.WECHARTQUERY_URL, sParaTemp, encoding);

        Stream stream = response.GetResponseStream();   //获取响应的字符串流  
        StreamReader sr = new StreamReader(stream); //创建一个stream读取流  
        string html = sr.ReadToEnd();   //从头读到尾，放到字符串html  

        Dictionary<string, string> ret = new Dictionary<string, string>();
        ret = JSONHelper.FromJson<Dictionary<string, string>>(html);

        if (ret["ret_code"] == "000000" && ret.Keys.Contains("pay_status") && ret["pay_status"]=="0")
        {
            Response.Redirect("ReturnUrl.aspx?OrderID=" + lblOrderID.Text);
            timer.Enabled = false;
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        timer.Enabled = false;
    }
}