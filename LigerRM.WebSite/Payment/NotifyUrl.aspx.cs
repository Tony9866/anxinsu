using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using LigerRM.Common.Payment;
using LigerRM.Common;

public partial class Payment_NotifyUrl : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        SortedDictionary<string, string> sPara = GetRequestPost();


        if (sPara.Count > 0)//判断是否有带返回参数
        {

            Console.WriteLine("接收支付异步通知数据：【" + sPara.ToString() + "】");

            if (!YinTongUtil.checkSign(sPara, PartnerConfig.YT_PUB_KEY, //验证失败
                PartnerConfig.MD5_KEY))
            {
                Response.Write(@"{""ret_code"":""9999"",""ret_msg"":""验签失败""}");
                Console.WriteLine("支付异步通知验签失败");
                return;
            }
            else
            {
                Response.Write(@"{""ret_code"":""0000"",""ret_msg"":""交易成功""}");
                Response.Write("支付异步通知数据接收处理成功");
            }
        }
        else
        {
            Response.Write(@"{""ret_code"":""9999"",""ret_msg"":""交易失败""}");
        }

        // 解析异步通知对象
        // sPara 字典对象
        // TODO:更新订单，发货等后续处理

    }

    /// <summary>
    /// 获取POST过来通知消息，并以“参数名=参数值”的形式组成字典
    /// </summary>
    /// <returns>request回来的信息组成的数组</returns>
    public SortedDictionary<string, string> GetRequestPost()
    {
        string reqStr = readReqStr();

        SortedDictionary<string, string> sArray = JSONHelper.FromJson<SortedDictionary<string, string>>(reqStr);
        return sArray;
    }


    //从request中读取流，组成字符串返回
    public String readReqStr()
    {
        StringBuilder sb = new StringBuilder();

        HttpRequest request = HttpContext.Current.Request;
        Stream reqStream = request.InputStream;
        StreamReader reader = new StreamReader(reqStream, System.Text.Encoding.UTF8);

        String line = null;
        while ((line = reader.ReadLine()) != null)
        {
            sb.Append(line);
        }
        reader.Close();
        return sb.ToString();

    }
}