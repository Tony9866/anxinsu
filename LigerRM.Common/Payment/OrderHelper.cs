using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LigerRM.Common.Payment
{
    public class OrderHelper
    {
        public void AddOrder(OrderInfo info)
        {
            string sql = "insert into order_base values ('"+ info.OrderID
                + "','" + info.OrderNO
                +"','"+ info.DTOrder
                +"','"+ info.OidPartner 
                +"','"+info.UserId
                + "','" + info.KeyID
                +"','"+info.SignType
                + "','" + info.Sign
                + "','" + info.PayType
                +"','"+info.BusiPartner
                +"','"+info.Version
                +"','"+info.OrderDesc
                +"','"+info.NotifyUrl
                +"','"+info.ReturnUrl
                +"','"+info.RequestIP
                +"','"+info.OrderUrl
                +"','"+info.OrderValid
                +"','"+info.Timestamp
                +"','"+info.Risk
                +"','"+info.DimensionUrl
                +"','"+info.CreatedBy
                +"','"+info.CreateDate.ToString()
                + "','" + info.PayDate
                +"','"+info.Status+"')";

            DbHelper.Db.ExecuteNonQuery(sql);

            foreach (OrderDetailInfo i in info.DetailInfos)
            {
                string detailStr = "Insert into order_detail values ('"+i.OrderDetailID+"','"+i.OrderID+"','"+i.GoodsName+"','"+i.Cost+"')";
                DbHelper.Db.ExecuteNonQuery(detailStr);
            }
        }

        public void UpdateOrderStatus(string orderId, OrderInfo.OrderStatus status)
        {
            string sql = "update order_base set status='" + ((int)status).ToString() + "',PayDate='"+DateTime.Now.ToString()+"' where orderid='" + orderId + "'";
            DbHelper.Db.ExecuteNonQuery(sql);
        }

        public void AddOrderDetail(OrderDetailInfo info)
        {
            string sql = "insert into order_detail values ('"+info.OrderDetailID+"','"+info.OrderID+"','"+info.GoodsName+"','"+info.Cost+"')";
            DbHelper.Db.ExecuteNonQuery(sql);
        }

        public void UpdateDemitionUrl(string orderId, string url,string orderNo)
        {
            string sql = "update order_base set DimensionUrl='" + url + "',OrderNO='"+orderNo+"' where orderid='" + orderId + "'";
            DbHelper.Db.ExecuteNonQuery(sql);
        }
    }
}
