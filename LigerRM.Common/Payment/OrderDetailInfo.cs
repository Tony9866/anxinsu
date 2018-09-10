using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LigerRM.Common.Payment
{
    public class OrderDetailInfo
    {
        private string m_OrderDetailID;
        private string m_OrderID;
        private string m_GoodsName;
        private string m_Cost;

        public string OrderDetailID { get { return m_OrderDetailID; } set { m_OrderDetailID = value; } }
        public string OrderID { get { return m_OrderID; } set { m_OrderID = value; } }
        public string GoodsName { get { return m_GoodsName; } set { m_GoodsName = value; } }
        public string Cost { get { return m_Cost; } set { m_Cost = value; } }
    }
}
