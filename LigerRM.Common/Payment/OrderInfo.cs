using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace LigerRM.Common.Payment
{
    public class OrderInfo
    {
        //0 成功 1 未支付 9 支付失败 2 已冲正 3已退款 4 部分退款 5 已撤销 6 支付关闭7 预授权申请成功
        public enum OrderStatus
        { 
            Successed=0,
            NotPay=1,
            PaymentFailed=9,
            RollBack=3,
            PartRollBack=4,
            Cancelled=5,
            Closed=6
        }

        public enum PaymentType { WeChart=0, Card=1, AliPay=5,ApplePay=7}

        private string m_OrderID;
        private string m_OrderNO;
        private string m_DTOrder;
        private string m_OidPartner;
        private string m_UserId;
        private string m_KeyID;
        private string m_SignType;
        private string m_Sign;
        private string m_PayType;
        private string m_BusiPartner;
        private string m_Version;
        private string m_OrderDesc;
        private string m_NotifyUrl;
        private string m_ReturnUrl;
        private string m_RequestIP;
        private string m_OrderUrl;
        private string m_OrderValid;
        private string m_Timestamp;
        private string m_Risk;
        private string m_DimensionUrl;
        private string m_CreatedBy;
        private DateTime m_CreateDate;
        private string m_PayDate;
        private string m_Status;
        private string m_Cost;

        private List<OrderDetailInfo> m_detailInfo = new List<OrderDetailInfo>();

        public string OrderID { get { return m_OrderID; } set { m_OrderID = value; } }
        public string OrderNO { get { return m_OrderNO; } set { m_OrderNO = value; } }
        public string DTOrder { get { return m_DTOrder; } set { m_DTOrder = value; } }
        public string OidPartner { get { return m_OidPartner; } set { m_OidPartner = value; } }
        public string UserId { get { return m_UserId; } set { m_UserId = value; } }
        public string KeyID { get { return m_KeyID; } set { m_KeyID = value; } }
        public string SignType { get { return m_SignType; } set { m_SignType = value; } }
        public string Sign { get { return m_Sign; } set { m_Sign = value; } }
        public string PayType { get { return m_PayType; } set { m_PayType = value; } }
        public string BusiPartner { get { return m_BusiPartner; } set { m_BusiPartner = value; } }

        public string Version { get { return m_Version; } set { m_Version = value; } }
        public string OrderDesc { get { return m_OrderDesc; } set { m_OrderDesc = value; } }
        public string NotifyUrl { get { return m_NotifyUrl; } set { m_NotifyUrl = value; } }
        public string ReturnUrl { get { return m_ReturnUrl; } set { m_ReturnUrl = value; } }
        public string RequestIP { get { return m_RequestIP; } set { m_RequestIP = value; } }

        public string OrderUrl { get { return m_OrderUrl; } set { m_OrderUrl = value; } }
        public string OrderValid { get { return m_OrderValid; } set { m_OrderValid = value; } }
        public string Timestamp { get { return m_Timestamp; } set { m_Timestamp = value; } }
        public string Risk { get { return m_Risk; } set { m_Risk = value; } }
        public string DimensionUrl { get { return m_DimensionUrl; } set { m_DimensionUrl = value; } }
        public string CreatedBy { get { return m_CreatedBy; } set { m_CreatedBy = value; } }
        public DateTime CreateDate { get { return m_CreateDate; } set { m_CreateDate = value; } }
        public string PayDate { get { return m_PayDate; } set { m_PayDate = value; } }
        public string Status { get { return m_Status; } set { m_Status = value; } }
        public string Cost { get { return m_Cost; } set { m_Cost = value; } }

        public List<OrderDetailInfo> DetailInfos { get { return m_detailInfo; } set { m_detailInfo = value; } }

        public OrderInfo(string orderId)
        {
            m_OrderID = orderId;
            DataTable dt = DbHelper.Db.ExecuteDataSet("select * from Order_base where orderId='"+orderId+"'").Tables[0];
            foreach (DataRow row in dt.Rows)
            { 
                m_OrderID = row.IsNull("OrderID")?"":row["OrderID"].ToString();
                m_OrderNO = row.IsNull("OrderNO") ? "" : row["OrderNO"].ToString();
                m_DTOrder = row.IsNull("DTOrder")?"":row["DTOrder"].ToString();
                m_OidPartner = row.IsNull("OidPartner")?"":row["OidPartner"].ToString();
                m_UserId = row.IsNull("UserId")?"":row["UserId"].ToString();
                m_KeyID = row.IsNull("KeyID") ? "" : row["KeyID"].ToString();
                m_SignType = row.IsNull("SignType")?"":row["SignType"].ToString();
                m_Sign = row.IsNull("Sign") ? "" : row["Sign"].ToString();
                m_PayType = row.IsNull("PayType") ? "" : row["PayType"].ToString();
                m_BusiPartner = row.IsNull("BusiPartner")?"":row["BusiPartner"].ToString();
                m_Version = row.IsNull("Version")?"":row["Version"].ToString();
                m_OrderDesc = row.IsNull("OrderDesc")?"":row["OrderDesc"].ToString();
                m_NotifyUrl = row.IsNull("NotifyUrl")?"":row["NotifyUrl"].ToString();

                m_ReturnUrl = row.IsNull("ReturnUrl")?"":row["ReturnUrl"].ToString();
                m_RequestIP = row.IsNull("RequestIP")?"":row["RequestIP"].ToString();
                m_OrderUrl = row.IsNull("OrderUrl")?"":row["OrderUrl"].ToString();
                m_OrderValid = row.IsNull("OrderValid")?"":row["OrderValid"].ToString();
                m_Timestamp = row.IsNull("Timestamp")?"":row["Timestamp"].ToString();
                m_Risk = row.IsNull("Risk")?"":row["Risk"].ToString();

                m_DimensionUrl = row.IsNull("DimensionUrl")?"":row["DimensionUrl"].ToString();
                m_CreatedBy = row.IsNull("CreatedBy")?"":row["CreatedBy"].ToString();
                m_CreateDate = DateTime.Parse(row["CreatedDate"].ToString());
                m_PayDate = row.IsNull("PayDate") ? "" : row["PayDate"].ToString();
                m_Status = row.IsNull("Status") ? "" : row["Status"].ToString();
            }

            DataTable dt1 = DbHelper.Db.ExecuteDataSet("select * from Order_detail where orderId='" + orderId + "'").Tables[0];
            decimal c = 0;
            foreach (DataRow r in dt1.Rows)
            {
                c += decimal.Parse(r["cost"].ToString());
            }

            m_Cost = c.ToString();
        }
    }
}
