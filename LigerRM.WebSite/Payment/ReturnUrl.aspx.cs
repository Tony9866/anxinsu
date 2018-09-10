using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LigerRM.Common.Payment;

public partial class Payment_ReturnUrl : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string orderId = Request["OrderId"];
            OrderHelper helper = new OrderHelper();
            helper.UpdateOrderStatus(orderId, OrderInfo.OrderStatus.Successed);
        }
    }
}